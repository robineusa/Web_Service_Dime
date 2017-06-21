﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;


namespace Telmexla.Servicios.DIME.Business
{
    public class IngresoTrasladoBusiness
    {
        public void InsertIngresoTraslado(IngresoTraslado ingreso, NotasTraslado notaTraslado, TraficoTraslado transaccion)
        {
            //inserta registro de creacion de Direccion
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            ingreso.TipoGestion = "CREACION DE DIRECCION";
            ingreso.FechaApertura = DateTime.Now;
            ingreso.HoraApertura = DateTime.Now;
            ingreso.FechaUltimaActualizacion = DateTime.Now;
            ingreso.HoraUltimaActualizacion = DateTime.Now;
            ingreso.EstadoTransaccion = "PENDIENTE POR CREAR";
            ingreso.NombreLineaEscalado = "CELULA CREACION DIRECCION";


            unitWork.ingresoTraslados.Add(ingreso);
            unitWork.Complete();
            unitWork.Dispose();

            //inserta las notas de la transaccion
            UnitOfWork unitWorkNotas = new UnitOfWork(new DimeContext());

            notaTraslado.IdTransaccion = ingreso.IdTransaccion;
            notaTraslado.UsuarioTransaccion = ingreso.UsuarioApertura;
            notaTraslado.CanalTransaccion = "INBOUND TRASLADOS";
            notaTraslado.FechaTransaccion = DateTime.Now;
            notaTraslado.NombreLineaTransaccion = ingreso.NombreLineaIngreso;
            notaTraslado.CuentaCliente = ingreso.CuentaCliente;
            notaTraslado.Razon = "SOLICITUD INBOUND";
            notaTraslado.Subrazon = "CREACION DE DIRECCION";
            notaTraslado.EstadoTransaccion = "PENDIENTE POR CREAR";

            unitWorkNotas.notasTraslados.Add(notaTraslado);
            unitWorkNotas.Complete();
            unitWorkNotas.Dispose();

            //registro de tiempos y transaccion
            UnitOfWork unitofworkTransaccion = new UnitOfWork(new DimeContext());

            transaccion.IdTransaccion = ingreso.IdTransaccion;
            transaccion.UsuarioTransaccion = notaTraslado.UsuarioTransaccion;
            transaccion.EstadoTransaccion = notaTraslado.EstadoTransaccion;

            unitofworkTransaccion.traficoTraslados.Add(transaccion);
            unitofworkTransaccion.Complete();
            unitofworkTransaccion.Dispose();

        }
        public bool ExisteCuentaEscalada(decimal cuenta)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.ingresoTraslados.Find(c => c.CuentaCliente.Equals(cuenta) && c.TipoGestion == "CREACION DE DIRECCION" && (c.EstadoTransaccion == "PENDIENTE POR CREAR" || c.EstadoTransaccion == "SEGUIMIENTO" || c.EstadoTransaccion == "EN GESTION" || c.EstadoTransaccion == "INGRESADA")).Count() >= 1;

        }
        public List<DatoConsultaDirecciones> ListaSolicitudesCrearDireccion(string Usuario)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 join b in (from m in dimContext.NotasTraslados select new { m.IdTransaccion, m.UsuarioBackOffice }).Distinct() on a.IdTransaccion equals b.IdTransaccion
                                 where a.EstadoTransaccion.Equals("PENDIENTE POR CREAR") && (b.UsuarioBackOffice == null || b.UsuarioBackOffice == Usuario)
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.CuentaCliente,
                                     a.FechaApertura,
                                     a.UsuarioApertura,
                                     a.EstadoTransaccion,
                                     a.NombreLineaIngreso,
                                     a.NombreLineaEscalado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].IngresoTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].IngresoTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].IngresoTrasladoGetSet.FechaApertura = objetosResult[i].FechaApertura;
                result[i].IngresoTrasladoGetSet.UsuarioApertura = objetosResult[i].UsuarioApertura;
                result[i].IngresoTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].IngresoTrasladoGetSet.NombreLineaIngreso = objetosResult[i].NombreLineaIngreso;
                result[i].IngresoTrasladoGetSet.NombreLineaEscalado = objetosResult[i].NombreLineaEscalado;

            }


            return result;
        }
        public NotasTrasladoCollection ListaInteraccionesCrearDireccion(int id)
        {

            UnitOfWork unitwork = new UnitOfWork(new DimeContext());
            NotasTrasladoCollection result = new NotasTrasladoCollection();
            result.AddRange(unitwork.notasTraslados.Find(c => c.IdTransaccion == id).Select(a => new NotasTraslado
            {
                Id = a.Id,
                IdTransaccion = a.IdTransaccion,
                UsuarioTransaccion = a.UsuarioTransaccion,
                CanalTransaccion = a.CanalTransaccion,
                FechaTransaccion = a.FechaTransaccion,
                NombreLineaTransaccion = a.NombreLineaTransaccion,
                CuentaCliente = a.CuentaCliente,
                DireccionACrear = a.DireccionACrear,
                Estrato = a.Estrato,
                Nodo = a.Nodo,
                TelefonoCelular = a.TelefonoCelular,
                TelefonoFijo = a.TelefonoFijo,
                Razon = a.Razon,
                Subrazon = a.Subrazon,
                Observacion = a.Observacion,
                EstadoTransaccion = a.EstadoTransaccion
            }).ToList());

            return result;
        }
        public void ActualizarSolicitudCrearDireccion(IngresoTraslado ingreso, NotasTraslado notaTraslado, TraficoTraslado transaccion)
        {
            //actualiza informacion del ingreso
            UnitOfWork unitWorkIA = new UnitOfWork(new DimeContext());
            IngresoTraslado ingresoActualizable = unitWorkIA.ingresoTraslados.Get(Convert.ToInt32(ingreso.IdTransaccion));

            DateTime fechaActual = DateTime.Now;
            if (ingreso.EstadoTransaccion == "FINALIZADO")
            {
                ingresoActualizable.FechaCierre = fechaActual;
                ingresoActualizable.HoraCierre = fechaActual;
                ingresoActualizable.UsuarioCierre = ingreso.UsuarioUltimaActualizacion;
            }
            ingresoActualizable.FechaUltimaActualizacion = fechaActual;
            ingresoActualizable.HoraUltimaActualizacion = fechaActual;
            ingresoActualizable.UsuarioUltimaActualizacion = ingreso.UsuarioUltimaActualizacion;
            ingresoActualizable.EstadoTransaccion = ingreso.EstadoTransaccion;

            unitWorkIA.Complete();
            unitWorkIA.Dispose();

            //inserta la nota de la transaccion
            UnitOfWork unitWorkNT = new UnitOfWork(new DimeContext());
            NotasTraslado notaTransaccion = new NotasTraslado();

            notaTransaccion.IdTransaccion = ingresoActualizable.IdTransaccion;
            notaTransaccion.UsuarioTransaccion = notaTraslado.UsuarioTransaccion;
            notaTransaccion.CanalTransaccion = notaTraslado.CanalTransaccion;
            notaTransaccion.FechaTransaccion = fechaActual;
            notaTransaccion.NombreLineaTransaccion = notaTraslado.NombreLineaTransaccion;
            notaTransaccion.CuentaCliente = ingresoActualizable.CuentaCliente;
            notaTransaccion.DireccionACrear = notaTraslado.DireccionACrear;
            notaTransaccion.Estrato = notaTraslado.Estrato;
            notaTransaccion.Nodo = notaTraslado.Nodo;
            notaTransaccion.TelefonoCelular = notaTraslado.TelefonoCelular;
            notaTransaccion.TelefonoFijo = notaTraslado.TelefonoFijo;
            notaTransaccion.Razon = notaTraslado.Razon;
            notaTransaccion.Subrazon = notaTraslado.Subrazon;
            notaTransaccion.Observacion = notaTraslado.Observacion;
            notaTransaccion.EstadoTransaccion = notaTraslado.EstadoTransaccion;
            notaTransaccion.UsuarioBackOffice = null;
            notaTransaccion.UsuarioBackOutbound = null;

            unitWorkNT.notasTraslados.Add(notaTransaccion);
            unitWorkNT.Complete();
            unitWorkNT.Dispose();

            //actualizar la lista de usuarios del back a nulos
            UnitOfWork unitWorkNA = new UnitOfWork(new DimeContext());
            List<NotasTraslado> notasactualizables = unitWorkNA.notasTraslados.Find(c => c.IdTransaccion == ingreso.IdTransaccion).ToList();
            foreach (var item in notasactualizables)
            {
                item.UsuarioBackOffice = null;
                item.UsuarioBackOutbound = null;
            };

            unitWorkNA.Complete();
            unitWorkNA.Dispose();

            //registro de tiempos y transaccion
            UnitOfWork unitWorkRT = new UnitOfWork(new DimeContext());

            transaccion.IdTransaccion = ingresoActualizable.IdTransaccion;
            transaccion.UsuarioTransaccion = notaTransaccion.UsuarioTransaccion;
            transaccion.EstadoTransaccion = notaTransaccion.EstadoTransaccion;

            unitWorkRT.traficoTraslados.Add(transaccion);
            unitWorkRT.Complete();
            unitWorkRT.Dispose();

        }
        public bool TransaccionEnGestion(int id, String usrABackOffice)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            string result = unitWork.notasTraslados.ComprobarActualizarUsrBackoffice(id, usrABackOffice);
            if (result == usrABackOffice) return false;
            else return true;
        }
        public List<DatoConsultaDirecciones> ListaSeguimientosDireccionesCelula(string usrABackOffice)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 join b in (from m in dimContext.NotasTraslados select new { m.IdTransaccion, m.UsuarioBackOffice }).Distinct() on a.IdTransaccion equals b.IdTransaccion
                                 where a.EstadoTransaccion.Equals("EN GESTION") && (b.UsuarioBackOffice == usrABackOffice || b.UsuarioBackOffice == null)
                                 orderby a.HoraUltimaActualizacion ascending
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.CuentaCliente,
                                     a.FechaApertura,
                                     a.HoraUltimaActualizacion,
                                     a.UsuarioApertura,
                                     a.EstadoTransaccion,
                                     a.NombreLineaIngreso,
                                     a.NombreLineaEscalado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].IngresoTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].IngresoTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].IngresoTrasladoGetSet.FechaApertura = objetosResult[i].FechaApertura;
                result[i].IngresoTrasladoGetSet.HoraUltimaActualizacion = objetosResult[i].HoraUltimaActualizacion;
                result[i].IngresoTrasladoGetSet.UsuarioApertura = objetosResult[i].UsuarioApertura;
                result[i].IngresoTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].IngresoTrasladoGetSet.NombreLineaIngreso = objetosResult[i].NombreLineaIngreso;
                result[i].IngresoTrasladoGetSet.NombreLineaEscalado = objetosResult[i].NombreLineaEscalado;

            }


            return result;
        }
        public List<DatoConsultaDirecciones> ListaDireccionesCreadasOutbound(string Usuario)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 join b in (from m in dimContext.NotasTraslados select new { m.IdTransaccion, m.UsuarioBackOutbound }).Distinct() on a.IdTransaccion equals b.IdTransaccion
                                 where (a.EstadoTransaccion.Equals("INGRESADA") || a.EstadoTransaccion.Equals("NO INGRESADA")) && (b.UsuarioBackOutbound == null || b.UsuarioBackOutbound == Usuario)
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.CuentaCliente,
                                     a.FechaApertura,
                                     a.UsuarioApertura,
                                     a.EstadoTransaccion,
                                     a.NombreLineaIngreso,
                                     a.NombreLineaEscalado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].IngresoTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].IngresoTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].IngresoTrasladoGetSet.FechaApertura = objetosResult[i].FechaApertura;
                result[i].IngresoTrasladoGetSet.UsuarioApertura = objetosResult[i].UsuarioApertura;
                result[i].IngresoTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].IngresoTrasladoGetSet.NombreLineaIngreso = objetosResult[i].NombreLineaIngreso;
                result[i].IngresoTrasladoGetSet.NombreLineaEscalado = objetosResult[i].NombreLineaEscalado;

            }


            return result;
        }
        public bool TransaccionEnGestionOut(int id, String usrOut)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            string result = unitWork.notasTraslados.ComprobarActualizarUsrOutbound(id, usrOut);
            if (result == usrOut) return false;
            else return true;
        }
        public List<DatoConsultaDirecciones> ListaSeguimientosDireccionesOutbound(string UsuarioOut)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 join b in (from m in dimContext.NotasTraslados select new { m.IdTransaccion, m.UsuarioBackOutbound }).Distinct() on a.IdTransaccion equals b.IdTransaccion
                                 where a.EstadoTransaccion.Equals("SEGUIMIENTO") && (b.UsuarioBackOutbound == UsuarioOut || b.UsuarioBackOutbound == null)
                                 orderby a.HoraUltimaActualizacion ascending
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.CuentaCliente,
                                     a.FechaApertura,
                                     a.HoraUltimaActualizacion,
                                     a.UsuarioApertura,
                                     a.EstadoTransaccion,
                                     a.NombreLineaIngreso,
                                     a.NombreLineaEscalado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].IngresoTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].IngresoTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].IngresoTrasladoGetSet.FechaApertura = objetosResult[i].FechaApertura;
                result[i].IngresoTrasladoGetSet.HoraUltimaActualizacion = objetosResult[i].HoraUltimaActualizacion;
                result[i].IngresoTrasladoGetSet.UsuarioApertura = objetosResult[i].UsuarioApertura;
                result[i].IngresoTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].IngresoTrasladoGetSet.NombreLineaIngreso = objetosResult[i].NombreLineaIngreso;
                result[i].IngresoTrasladoGetSet.NombreLineaEscalado = objetosResult[i].NombreLineaEscalado;

            }


            return result;
        }
        public List<DatoConsultaDirecciones> ListGestionCrearDireccion(DateTime FechaInicial, DateTime FechaFinal, string usrTransac)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.NotasTraslados
                                 join b in dimContext.IngresoTraslados on a.IdTransaccion equals b.IdTransaccion
                                 where a.FechaTransaccion >= FechaInicial && a.FechaTransaccion <= FechaFinal && a.UsuarioTransaccion == usrTransac
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.CuentaCliente,
                                     a.UsuarioTransaccion,
                                     a.CanalTransaccion,
                                     a.FechaTransaccion,
                                     a.NombreLineaTransaccion,
                                     a.EstadoTransaccion,
                                     a.Razon,
                                     a.Subrazon,
                                     a.Observacion
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].NotaTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].NotaTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NotaTrasladoGetSet.UsuarioTransaccion = objetosResult[i].UsuarioTransaccion;
                result[i].NotaTrasladoGetSet.CanalTransaccion = objetosResult[i].CanalTransaccion;
                result[i].NotaTrasladoGetSet.FechaTransaccion = objetosResult[i].FechaTransaccion;
                result[i].NotaTrasladoGetSet.NombreLineaTransaccion = objetosResult[i].NombreLineaTransaccion;
                result[i].NotaTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].NotaTrasladoGetSet.Razon = objetosResult[i].Razon;
                result[i].NotaTrasladoGetSet.Subrazon = objetosResult[i].Subrazon;
                result[i].NotaTrasladoGetSet.Observacion = objetosResult[i].Observacion;

            }


            return result;
        }
        //INICIA METODOS PARA PROCESO DE CAMBIO DE ESTRATO
        public void InsertIngresoCambioEstrato(IngresoTraslado ingreso, CambioEstrato cambioEstrato, TraficoTraslado transaccion)
        {
            //inserta registro de cambio de estrato
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());

            ingreso.TipoGestion = "CAMBIO DE ESTRATO";
            ingreso.FechaApertura = DateTime.Now;
            ingreso.HoraApertura = DateTime.Now;
            ingreso.FechaUltimaActualizacion = DateTime.Now;
            ingreso.HoraUltimaActualizacion = DateTime.Now;
            ingreso.EstadoTransaccion = "PENDIENTE POR CREAR";
            ingreso.NombreLineaEscalado = "CELULA CAMBIO DE ESTRATO";

            unitWork.ingresoTraslados.Add(ingreso);
            unitWork.Complete();
            unitWork.Dispose();

            //inserta notas de cambio de estrato
            UnitOfWork unitWorkcambioEstrato = new UnitOfWork(new DimeContext());

            cambioEstrato.IdTransaccion = ingreso.IdTransaccion;
            cambioEstrato.UsuarioTransaccion = ingreso.UsuarioApertura;
            cambioEstrato.CanalTransaccion = "INBOUND TRASLADOS";
            cambioEstrato.FechaTransaccion = DateTime.Now;
            cambioEstrato.NombreLineaTransaccion = ingreso.NombreLineaIngreso;
            cambioEstrato.CuentaCliente = ingreso.CuentaCliente;
            cambioEstrato.Razon = "SOLICITUD INBOUND";
            cambioEstrato.Subrazon = "CAMBIO DE ESTRATO";
            cambioEstrato.EstadoTransaccion = "PENDIENTE POR CREAR";

            unitWorkcambioEstrato.cambioEstratos.Add(cambioEstrato);
            unitWorkcambioEstrato.Complete();
            unitWorkcambioEstrato.Dispose();

            //registro de tiempos y transaccion
            UnitOfWork unitWorktransaccion = new UnitOfWork(new DimeContext());

            transaccion.IdTransaccion = ingreso.IdTransaccion;
            transaccion.UsuarioTransaccion = cambioEstrato.UsuarioTransaccion;
            transaccion.EstadoTransaccion = cambioEstrato.EstadoTransaccion;

            unitWorktransaccion.traficoTraslados.Add(transaccion);
            unitWorktransaccion.Complete();
            unitWorktransaccion.Dispose();
        }
        public bool ExisteCuentaEscaladaCambioEstrato(decimal cuenta)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.ingresoTraslados.Find(c => c.CuentaCliente.Equals(cuenta) && c.EstadoTransaccion != "FINALIZADO" && c.TipoGestion == "CAMBIO DE ESTRATO").Count() >= 1;

        }
        public List<DatoConsultaDirecciones> ListaSolicitudesCambioEstrato(string Usuario)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 join b in (from m in dimContext.cambioEstratos select new { m.IdTransaccion, m.UsuarioBackOffice }).Distinct() on a.IdTransaccion equals b.IdTransaccion
                                 where a.EstadoTransaccion.Equals("PENDIENTE POR CREAR") && (b.UsuarioBackOffice == null || b.UsuarioBackOffice == Usuario)
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.CuentaCliente,
                                     a.FechaApertura,
                                     a.UsuarioApertura,
                                     a.EstadoTransaccion,
                                     a.NombreLineaIngreso,
                                     a.NombreLineaEscalado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].IngresoTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].IngresoTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].IngresoTrasladoGetSet.FechaApertura = objetosResult[i].FechaApertura;
                result[i].IngresoTrasladoGetSet.UsuarioApertura = objetosResult[i].UsuarioApertura;
                result[i].IngresoTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].IngresoTrasladoGetSet.NombreLineaIngreso = objetosResult[i].NombreLineaIngreso;
                result[i].IngresoTrasladoGetSet.NombreLineaEscalado = objetosResult[i].NombreLineaEscalado;

            }


            return result;
        }
        public CambioEstratoCollection ListaInteraccionesCambioEstrato(int id)
        {

            UnitOfWork unitwork = new UnitOfWork(new DimeContext());
            CambioEstratoCollection result = new CambioEstratoCollection();
            result.AddRange(unitwork.cambioEstratos.Find(c => c.IdTransaccion == id).Select(a => new CambioEstrato
            {
                Id = a.Id,
                IdTransaccion = a.IdTransaccion,
                UsuarioTransaccion = a.UsuarioTransaccion,
                CanalTransaccion = a.CanalTransaccion,
                FechaTransaccion = a.FechaTransaccion,
                NombreLineaTransaccion = a.NombreLineaTransaccion,
                CuentaCliente = a.CuentaCliente,
                Direccion = a.Direccion,
                Estrato = a.Estrato,
                Nodo = a.Nodo,
                TelefonoCelular = a.TelefonoCelular,
                TelefonoFijo = a.TelefonoFijo,
                Razon = a.Razon,
                Subrazon = a.Subrazon,
                Observacion = a.Observacion,
                EstadoTransaccion = a.EstadoTransaccion,
                CorreoElectronico = a.CorreoElectronico
            }).ToList());

            return result;
        }
        public void ActualizarSolicitudCambioEstrato(IngresoTraslado ingreso, CambioEstrato CambioEstrato, TraficoTraslado transaccion)
        {
            //Actualiza el ingreso
            UnitOfWork unitWorkIA = new UnitOfWork(new DimeContext());
            IngresoTraslado ingresoActualizable = unitWorkIA.ingresoTraslados.Get(Convert.ToInt32(ingreso.IdTransaccion));
            DateTime fechaActual = DateTime.Now;

            if (ingreso.EstadoTransaccion == "FINALIZADO")
            {
                ingresoActualizable.FechaCierre = fechaActual;
                ingresoActualizable.HoraCierre = fechaActual;
                ingresoActualizable.UsuarioCierre = ingreso.UsuarioUltimaActualizacion;
            }
            ingresoActualizable.FechaUltimaActualizacion = fechaActual;
            ingresoActualizable.HoraUltimaActualizacion = fechaActual;
            ingresoActualizable.UsuarioUltimaActualizacion = ingreso.UsuarioUltimaActualizacion;
            ingresoActualizable.EstadoTransaccion = ingreso.EstadoTransaccion;

            unitWorkIA.Complete();
            unitWorkIA.Dispose();

            //inserta la nota de la transaccion
            UnitOfWork unitWorkNT = new UnitOfWork(new DimeContext());
            CambioEstrato notaTransaccion = new CambioEstrato();

            notaTransaccion.IdTransaccion = ingresoActualizable.IdTransaccion;
            notaTransaccion.UsuarioTransaccion = CambioEstrato.UsuarioTransaccion;
            notaTransaccion.CanalTransaccion = CambioEstrato.CanalTransaccion;
            notaTransaccion.FechaTransaccion = fechaActual;
            notaTransaccion.NombreLineaTransaccion = CambioEstrato.NombreLineaTransaccion;
            notaTransaccion.CuentaCliente = ingresoActualizable.CuentaCliente;
            notaTransaccion.Direccion = CambioEstrato.Direccion;
            notaTransaccion.Estrato = CambioEstrato.Estrato;
            notaTransaccion.Nodo = CambioEstrato.Nodo;
            notaTransaccion.TelefonoCelular = CambioEstrato.TelefonoCelular;
            notaTransaccion.TelefonoFijo = CambioEstrato.TelefonoFijo;
            notaTransaccion.Razon = CambioEstrato.Razon;
            notaTransaccion.Subrazon = CambioEstrato.Subrazon;
            notaTransaccion.Observacion = CambioEstrato.Observacion;
            notaTransaccion.EstadoTransaccion = CambioEstrato.EstadoTransaccion;
            notaTransaccion.UsuarioBackOffice = null;
            notaTransaccion.CorreoElectronico = CambioEstrato.CorreoElectronico;

            unitWorkNT.cambioEstratos.Add(notaTransaccion);
            unitWorkNT.Complete();
            unitWorkNT.Dispose();

            //actualiza la lista de cambio estrato a nulos
            UnitOfWork unitWorkNA = new UnitOfWork(new DimeContext());
            List<CambioEstrato> cambioestratoactualizable = unitWorkNA.cambioEstratos.Find(c => c.IdTransaccion == ingreso.IdTransaccion).ToList();
            foreach (var item in cambioestratoactualizable)
            {
                item.UsuarioBackOffice = null;
            }
            unitWorkNA.Complete();
            unitWorkNA.Dispose();

            //registro de tiempos y transaccion
            UnitOfWork unitWorkRT = new UnitOfWork(new DimeContext());
            transaccion.IdTransaccion = ingresoActualizable.IdTransaccion;
            transaccion.UsuarioTransaccion = notaTransaccion.UsuarioTransaccion;
            transaccion.EstadoTransaccion = notaTransaccion.EstadoTransaccion;

            unitWorkRT.traficoTraslados.Add(transaccion);
            unitWorkRT.Complete();
            unitWorkRT.Dispose();

        }
        public bool TransaccionEnGestionCambioEstrato(int id, String usrABackOffice)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            string result = unitWork.cambioEstratos.ComprobarActualizarUsrBackoffice(id, usrABackOffice);
            if (result == usrABackOffice) return false;
            else return true;
        }
        public List<DatoConsultaDirecciones> ListaSeguimientosCambiodeEstratoCelula(string usrABackOffice)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 join b in (from m in dimContext.cambioEstratos select new { m.IdTransaccion, m.UsuarioBackOffice }).Distinct() on a.IdTransaccion equals b.IdTransaccion
                                 where a.EstadoTransaccion.Equals("SEGUIMIENTO") && (b.UsuarioBackOffice == usrABackOffice || b.UsuarioBackOffice == null)
                                 orderby a.HoraUltimaActualizacion ascending
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.CuentaCliente,
                                     a.FechaApertura,
                                     a.HoraUltimaActualizacion,
                                     a.UsuarioApertura,
                                     a.EstadoTransaccion,
                                     a.NombreLineaIngreso,
                                     a.NombreLineaEscalado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].IngresoTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].IngresoTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].IngresoTrasladoGetSet.FechaApertura = objetosResult[i].FechaApertura;
                result[i].IngresoTrasladoGetSet.HoraUltimaActualizacion = objetosResult[i].HoraUltimaActualizacion;
                result[i].IngresoTrasladoGetSet.UsuarioApertura = objetosResult[i].UsuarioApertura;
                result[i].IngresoTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].IngresoTrasladoGetSet.NombreLineaIngreso = objetosResult[i].NombreLineaIngreso;
                result[i].IngresoTrasladoGetSet.NombreLineaEscalado = objetosResult[i].NombreLineaEscalado;

            }


            return result;
        }
        public List<DatoConsultaDirecciones> ListGestionCambioDeEstrato(DateTime FechaInicial, DateTime FechaFinal, string usrTransac)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.cambioEstratos
                                 join b in dimContext.IngresoTraslados on a.IdTransaccion equals b.IdTransaccion
                                 where a.FechaTransaccion >= FechaInicial && a.FechaTransaccion <= FechaFinal && a.UsuarioTransaccion == usrTransac
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.CuentaCliente,
                                     a.UsuarioTransaccion,
                                     a.CanalTransaccion,
                                     a.FechaTransaccion,
                                     a.NombreLineaTransaccion,
                                     a.EstadoTransaccion,
                                     a.Razon,
                                     a.Subrazon,
                                     a.Observacion
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].NotaTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].NotaTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NotaTrasladoGetSet.UsuarioTransaccion = objetosResult[i].UsuarioTransaccion;
                result[i].NotaTrasladoGetSet.CanalTransaccion = objetosResult[i].CanalTransaccion;
                result[i].NotaTrasladoGetSet.FechaTransaccion = objetosResult[i].FechaTransaccion;
                result[i].NotaTrasladoGetSet.NombreLineaTransaccion = objetosResult[i].NombreLineaTransaccion;
                result[i].NotaTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].NotaTrasladoGetSet.Razon = objetosResult[i].Razon;
                result[i].NotaTrasladoGetSet.Subrazon = objetosResult[i].Subrazon;
                result[i].NotaTrasladoGetSet.Observacion = objetosResult[i].Observacion;

            }


            return result;
        }
        //INICIA METODOS PARA PROCESO DE LIBERACIONES DE HOME PASS
        public void InsertIngresoLiberacionHomePass(IngresoTraslado ingreso, LiberacionHomePass liberacion, TraficoTraslado transaccion)
        {
            //inserta ingreso liberacion de Home Pass
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());

            ingreso.TipoGestion = "LIBERACION DE HOMEPASS";
            ingreso.FechaApertura = DateTime.Now;
            ingreso.HoraApertura = DateTime.Now;
            ingreso.FechaUltimaActualizacion = DateTime.Now;
            ingreso.HoraUltimaActualizacion = DateTime.Now;
            ingreso.EstadoTransaccion = "PENDIENTE POR CREAR";
            ingreso.NombreLineaEscalado = "CELULA LIBERACION DE HOMEPASS";

            unitWork.ingresoTraslados.Add(ingreso);
            unitWork.Complete();
            unitWork.Dispose();

            //Inserta las notas de la Transaccion
            UnitOfWork unitWorkliberacion = new UnitOfWork(new DimeContext());

            liberacion.IdTransaccion = ingreso.IdTransaccion;
            liberacion.UsuarioTransaccion = ingreso.UsuarioApertura;
            liberacion.CanalTransaccion = "INBOUND TRASLADOS";
            liberacion.FechaTransaccion = DateTime.Now;
            liberacion.NombreLineaTransaccion = ingreso.NombreLineaIngreso;
            liberacion.Razon = "SOLICITUD INBOUND";
            liberacion.Subrazon = "LIBERACION DE HOMEPASS";
            liberacion.EstadoTransaccion = "PENDIENTE POR CREAR";

            unitWorkliberacion.liberacionesHomePass.Add(liberacion);
            unitWorkliberacion.Complete();
            unitWorkliberacion.Dispose();

            //registro de tiempos y transaccion
            UnitOfWork unitWorktransaccion = new UnitOfWork(new DimeContext());

            transaccion.IdTransaccion = ingreso.IdTransaccion;
            transaccion.UsuarioTransaccion = liberacion.UsuarioTransaccion;
            transaccion.EstadoTransaccion = liberacion.EstadoTransaccion;

            unitWorktransaccion.traficoTraslados.Add(transaccion);
            unitWorktransaccion.Complete();
            unitWorktransaccion.Dispose();
        }
        public bool ExisteCuentaEscaladaLiberacionHomePass(decimal cuenta)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.ingresoTraslados.Find(c => c.CuentaCliente.Equals(cuenta) && c.EstadoTransaccion != "FINALIZADO" && c.TipoGestion == "LIBERACION DE HOMEPASS").Count() >= 1;

        }
        public List<DatoConsultaDirecciones> ListaSolicitudesLiberacionesHomePass(string Usuario)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 join b in (from m in dimContext.liberacionesHomePass select new { m.IdTransaccion, m.UsuarioBackOffice, m.CuentaTraslada, m.MotivoLiberacion }).Distinct() on a.IdTransaccion equals b.IdTransaccion
                                 where a.EstadoTransaccion.Equals("PENDIENTE POR CREAR") && (b.UsuarioBackOffice == null || b.UsuarioBackOffice == Usuario)
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.CuentaCliente,
                                     b.CuentaTraslada,
                                     b.MotivoLiberacion,
                                     a.FechaApertura,
                                     a.UsuarioApertura,
                                     a.EstadoTransaccion,
                                     a.NombreLineaIngreso,
                                     a.NombreLineaEscalado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].IngresoTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].IngresoTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].LiberacionHomePass.CuentaTraslada = objetosResult[i].CuentaTraslada;
                result[i].LiberacionHomePass.MotivoLiberacion = objetosResult[i].MotivoLiberacion;
                result[i].IngresoTrasladoGetSet.FechaApertura = objetosResult[i].FechaApertura;
                result[i].IngresoTrasladoGetSet.UsuarioApertura = objetosResult[i].UsuarioApertura;
                result[i].IngresoTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].IngresoTrasladoGetSet.NombreLineaIngreso = objetosResult[i].NombreLineaIngreso;
                result[i].IngresoTrasladoGetSet.NombreLineaEscalado = objetosResult[i].NombreLineaEscalado;

            }


            return result;
        }
        public LiberacionHomePassCollection ListaInteraccionesLiberacionHomePass(int id)
        {

            UnitOfWork unitwork = new UnitOfWork(new DimeContext());
            LiberacionHomePassCollection result = new LiberacionHomePassCollection();
            result.AddRange(unitwork.liberacionesHomePass.Find(c => c.IdTransaccion == id).Select(a => new LiberacionHomePass
            {
                Id = a.Id,
                IdTransaccion = a.IdTransaccion,
                UsuarioTransaccion = a.UsuarioTransaccion,
                CanalTransaccion = a.CanalTransaccion,
                FechaTransaccion = a.FechaTransaccion,
                NombreLineaTransaccion = a.NombreLineaTransaccion,
                CuentaOcupa = a.CuentaOcupa,
                CuentaTraslada = a.CuentaTraslada,
                Direccion = a.Direccion,
                Nodo = a.Nodo,
                TelefonoCelular = a.TelefonoCelular,
                TelefonoFijo = a.TelefonoFijo,
                Razon = a.Razon,
                Subrazon = a.Subrazon,
                Observacion = a.Observacion,
                EstadoTransaccion = a.EstadoTransaccion,
                MotivoLiberacion = a.MotivoLiberacion
            }).ToList());

            return result;
        }
        public void ActualizarSolicitudLiberacionesHomePass(IngresoTraslado ingreso, LiberacionHomePass liberacion, TraficoTraslado transaccion)
        {
            //Actualiza informacion del ingreso
            UnitOfWork unitWorkIA = new UnitOfWork(new DimeContext());
            IngresoTraslado ingresoActualizable = unitWorkIA.ingresoTraslados.Get(Convert.ToInt32(ingreso.IdTransaccion));
            DateTime fechaActual = DateTime.Now;

            if (ingreso.EstadoTransaccion == "FINALIZADO")
            {
                ingresoActualizable.FechaCierre = fechaActual;
                ingresoActualizable.HoraCierre = fechaActual;
                ingresoActualizable.UsuarioCierre = ingreso.UsuarioUltimaActualizacion;
            }
            ingresoActualizable.FechaUltimaActualizacion = fechaActual;
            ingresoActualizable.HoraUltimaActualizacion = fechaActual;
            ingresoActualizable.UsuarioUltimaActualizacion = ingreso.UsuarioUltimaActualizacion;
            ingresoActualizable.EstadoTransaccion = ingreso.EstadoTransaccion;

            unitWorkIA.Complete();
            unitWorkIA.Dispose();

            //inserta Nota Transaccion Liberacion
            UnitOfWork unitWorkNT = new UnitOfWork(new DimeContext());
            LiberacionHomePass notaTransaccion = new LiberacionHomePass();

            notaTransaccion.IdTransaccion = ingresoActualizable.IdTransaccion;
            notaTransaccion.UsuarioTransaccion = liberacion.UsuarioTransaccion;
            notaTransaccion.CanalTransaccion = liberacion.CanalTransaccion;
            notaTransaccion.FechaTransaccion = fechaActual;
            notaTransaccion.NombreLineaTransaccion = liberacion.NombreLineaTransaccion;
            notaTransaccion.CuentaOcupa = ingresoActualizable.CuentaCliente;
            notaTransaccion.CuentaTraslada = liberacion.CuentaTraslada;
            notaTransaccion.Direccion = liberacion.Direccion;
            notaTransaccion.Nodo = liberacion.Nodo;
            notaTransaccion.TelefonoCelular = liberacion.TelefonoCelular;
            notaTransaccion.TelefonoFijo = liberacion.TelefonoFijo;
            notaTransaccion.Razon = liberacion.Razon;
            notaTransaccion.Subrazon = liberacion.Subrazon;
            notaTransaccion.Observacion = liberacion.Observacion;
            notaTransaccion.EstadoTransaccion = liberacion.EstadoTransaccion;
            notaTransaccion.UsuarioBackOffice = null;
            notaTransaccion.MotivoLiberacion = liberacion.MotivoLiberacion;

            unitWorkNT.liberacionesHomePass.Add(notaTransaccion);
            unitWorkNT.Complete();
            unitWorkNT.Dispose();

            //actualiza la lista de la liberacion de home pass
            UnitOfWork unitWorkNA = new UnitOfWork(new DimeContext());
            List<LiberacionHomePass> liberacionactualizable = unitWorkNA.liberacionesHomePass.Find(c => c.IdTransaccion == ingreso.IdTransaccion).ToList();
            foreach (var item in liberacionactualizable)
            {
                item.UsuarioBackOffice = null;
            }
            unitWorkNA.Complete();
            unitWorkNA.Dispose();

            //registro de tiempos y transaccion
            UnitOfWork unitWorkRT = new UnitOfWork(new DimeContext());

            transaccion.IdTransaccion = ingresoActualizable.IdTransaccion;
            transaccion.UsuarioTransaccion = notaTransaccion.UsuarioTransaccion;
            transaccion.EstadoTransaccion = notaTransaccion.EstadoTransaccion;

            unitWorkRT.traficoTraslados.Add(transaccion);
            unitWorkRT.Complete();
            unitWorkRT.Dispose();

        }
        public bool TransaccionEnGestionLiberacionHomePass(int id, String usrABackOffice)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            string result = unitWork.liberacionesHomePass.ComprobarActualizarUsrBackoffice(id, usrABackOffice);
            if (result == usrABackOffice) return false;
            else return true;
        }
        public List<DatoConsultaDirecciones> ListaSeguimientosLiberacionHomePassCelula(string usrABackOffice)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 join b in (from m in dimContext.liberacionesHomePass select new { m.IdTransaccion, m.UsuarioBackOffice, m.CuentaTraslada, m.MotivoLiberacion }).Distinct() on a.IdTransaccion equals b.IdTransaccion
                                 where a.EstadoTransaccion.Equals("SEGUIMIENTO") && (b.UsuarioBackOffice == usrABackOffice || b.UsuarioBackOffice == null)
                                 orderby a.HoraUltimaActualizacion ascending
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.CuentaCliente,
                                     b.CuentaTraslada,
                                     b.MotivoLiberacion,
                                     a.FechaApertura,
                                     a.HoraUltimaActualizacion,
                                     a.UsuarioApertura,
                                     a.EstadoTransaccion,
                                     a.NombreLineaIngreso,
                                     a.NombreLineaEscalado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].IngresoTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].IngresoTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].LiberacionHomePass.CuentaTraslada = objetosResult[i].CuentaTraslada;
                result[i].LiberacionHomePass.MotivoLiberacion = objetosResult[i].MotivoLiberacion;
                result[i].IngresoTrasladoGetSet.FechaApertura = objetosResult[i].FechaApertura;
                result[i].IngresoTrasladoGetSet.HoraUltimaActualizacion = objetosResult[i].HoraUltimaActualizacion;
                result[i].IngresoTrasladoGetSet.UsuarioApertura = objetosResult[i].UsuarioApertura;
                result[i].IngresoTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].IngresoTrasladoGetSet.NombreLineaIngreso = objetosResult[i].NombreLineaIngreso;
                result[i].IngresoTrasladoGetSet.NombreLineaEscalado = objetosResult[i].NombreLineaEscalado;

            }


            return result;
        }
        public List<DatoConsultaDirecciones> ListGestionLiberacionHomePass(DateTime FechaInicial, DateTime FechaFinal, string usrTransac)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.liberacionesHomePass
                                 join b in dimContext.IngresoTraslados on a.IdTransaccion equals b.IdTransaccion
                                 where a.FechaTransaccion >= FechaInicial && a.FechaTransaccion <= FechaFinal && a.UsuarioTransaccion == usrTransac
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.CuentaOcupa,
                                     a.CuentaTraslada,
                                     a.UsuarioTransaccion,
                                     a.CanalTransaccion,
                                     a.FechaTransaccion,
                                     a.NombreLineaTransaccion,
                                     a.EstadoTransaccion,
                                     a.Razon,
                                     a.Subrazon,
                                     a.Observacion,
                                     a.MotivoLiberacion
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].LiberacionHomePass.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].LiberacionHomePass.CuentaOcupa = objetosResult[i].CuentaOcupa;
                result[i].LiberacionHomePass.CuentaTraslada = objetosResult[i].CuentaTraslada;
                result[i].LiberacionHomePass.UsuarioTransaccion = objetosResult[i].UsuarioTransaccion;
                result[i].LiberacionHomePass.CanalTransaccion = objetosResult[i].CanalTransaccion;
                result[i].LiberacionHomePass.FechaTransaccion = objetosResult[i].FechaTransaccion;
                result[i].LiberacionHomePass.NombreLineaTransaccion = objetosResult[i].NombreLineaTransaccion;
                result[i].LiberacionHomePass.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].LiberacionHomePass.Razon = objetosResult[i].Razon;
                result[i].LiberacionHomePass.Subrazon = objetosResult[i].Subrazon;
                result[i].LiberacionHomePass.Observacion = objetosResult[i].Observacion;
                result[i].LiberacionHomePass.MotivoLiberacion = objetosResult[i].MotivoLiberacion;

            }


            return result;
        }

        //PROCESO GESTION DE MATRICES
        public void InsertIngresoGestionMatriz(IngresoTraslado ingreso, GestionMatriz matriz, TraficoTraslado transaccion)
        {
            //Inserta Ingreso de Gestion de Matrices
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());

            ingreso.TipoGestion = "GESTION DE MATRICES";
            ingreso.FechaApertura = DateTime.Now;
            ingreso.HoraApertura = DateTime.Now;
            ingreso.FechaUltimaActualizacion = DateTime.Now;
            ingreso.HoraUltimaActualizacion = DateTime.Now;
            if (matriz.TipoGestionMatriz == "CREAR MATRIZ")
            {
                ingreso.EstadoTransaccion = "PENDIENTE POR CREAR";
                ingreso.NombreLineaEscalado = "CELULA CREACION MATRICES";
                matriz.Subrazon = "CREACION DE MATRIZ";
                matriz.EstadoTransaccion = "PENDIENTE POR CREAR";
            }
            else if (matriz.TipoGestionMatriz == "GESTIONAR MATRIZ")
            {
                ingreso.EstadoTransaccion = "PENDIENTE POR GESTIONAR";
                ingreso.NombreLineaEscalado = "CELULA GESTION MATRICES";
                matriz.Subrazon = "GESTION DE MATRIZ";
                matriz.EstadoTransaccion = "PENDIENTE POR GESTIONAR";
            }
            else { }


            unitWork.ingresoTraslados.Add(ingreso);
            unitWork.Complete();
            unitWork.Dispose();

            //Insertar Nota de Gestion Matriz
            UnitOfWork unitWorkmatriz = new UnitOfWork(new DimeContext());

            matriz.IdTransaccion = ingreso.IdTransaccion;
            matriz.UsuarioTransaccion = ingreso.UsuarioApertura;
            matriz.CanalTransaccion = "INBOUND TRASLADOS";
            matriz.FechaTransaccion = DateTime.Now;
            matriz.NombreLineaTransaccion = ingreso.NombreLineaIngreso;
            matriz.CuentaCliente = ingreso.CuentaCliente;
            matriz.Razon = "SOLICITUD INBOUND";

            unitWorkmatriz.gestionMatrices.Add(matriz);
            unitWorkmatriz.Complete();
            unitWorkmatriz.Dispose();

            //registro de tiempos y transaccion
            UnitOfWork unitWorktransaccion = new UnitOfWork(new DimeContext());

            transaccion.IdTransaccion = ingreso.IdTransaccion;
            transaccion.UsuarioTransaccion = matriz.UsuarioTransaccion;
            transaccion.EstadoTransaccion = matriz.EstadoTransaccion;

            unitWorktransaccion.traficoTraslados.Add(transaccion);
            unitWorktransaccion.Complete();
            unitWorktransaccion.Dispose();
        }
        public bool ExisteCuentaEscaladaMatriz(decimal cuenta)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.ingresoTraslados.Find(c => c.CuentaCliente.Equals(cuenta) && c.EstadoTransaccion != "FINALIZADO" && c.TipoGestion == "GESTION DE MATRICES").Count() >= 1;

        }
        public List<DatoConsultaDirecciones> ListaSolicitudesCreaciondeMatriz(string Usuario)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 join b in (from m in dimContext.gestionMatrices select new { m.IdTransaccion, m.UsuarioBackOfficeCreacion }).Distinct() on a.IdTransaccion equals b.IdTransaccion
                                 where a.EstadoTransaccion.Equals("PENDIENTE POR CREAR") && (b.UsuarioBackOfficeCreacion == null || b.UsuarioBackOfficeCreacion == Usuario)
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.CuentaCliente,
                                     a.FechaApertura,
                                     a.UsuarioApertura,
                                     a.TipoGestion,
                                     a.EstadoTransaccion,
                                     a.NombreLineaIngreso,
                                     a.NombreLineaEscalado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].IngresoTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].IngresoTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].IngresoTrasladoGetSet.FechaApertura = objetosResult[i].FechaApertura;
                result[i].IngresoTrasladoGetSet.UsuarioApertura = objetosResult[i].UsuarioApertura;
                result[i].IngresoTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].IngresoTrasladoGetSet.NombreLineaIngreso = objetosResult[i].NombreLineaIngreso;
                result[i].IngresoTrasladoGetSet.NombreLineaEscalado = objetosResult[i].NombreLineaEscalado;

            }


            return result;
        }
        public GestionMatrizColleciton ListaInteraccionesMatrices(int id)
        {

            UnitOfWork unitwork = new UnitOfWork(new DimeContext());
            GestionMatrizColleciton result = new GestionMatrizColleciton();
            result.AddRange(unitwork.gestionMatrices.Find(c => c.IdTransaccion == id).Select(a => new GestionMatriz
            {
                Id = a.Id,
                IdTransaccion = a.IdTransaccion,
                UsuarioTransaccion = a.UsuarioTransaccion,
                CanalTransaccion = a.CanalTransaccion,
                FechaTransaccion = a.FechaTransaccion,
                NombreLineaTransaccion = a.NombreLineaTransaccion,
                TipoGestionMatriz = a.TipoGestionMatriz,
                TipoCliente = a.TipoCliente,
                CuentaCliente = a.CuentaCliente,
                CuentaMatriz = a.CuentaMatriz,
                OrdenTrabajo = a.OrdenTrabajo,
                Direccion = a.Direccion,
                Nodo = a.Nodo,
                NombreConjuntoEdificio = a.NombreConjuntoEdificio,
                TelefonoCLiente = a.TelefonoCLiente,
                TelefonoAdministrador = a.TelefonoAdministrador,
                NombreAdministrador = a.NombreAdministrador,
                Razon = a.Razon,
                Subrazon = a.Subrazon,
                Observacion = a.Observacion,
                EstadoTransaccion = a.EstadoTransaccion,
                UsuarioBackOfficeCreacion = a.UsuarioBackOfficeCreacion,
                UsuarioBackOfficeGestion = a.UsuarioBackOfficeGestion
            }).ToList());

            return result;
        }
        public void ActualizarSolicitudMatrices(IngresoTraslado ingreso, GestionMatriz matriz, TraficoTraslado transaccion)
        {

            //Actualiza Informacion del Ingreso
            UnitOfWork unitWorkIA = new UnitOfWork(new DimeContext());
            IngresoTraslado ingresoActualizable = unitWorkIA.ingresoTraslados.Get(Convert.ToInt32(ingreso.IdTransaccion));
            DateTime fechaActual = DateTime.Now;

            if (ingreso.EstadoTransaccion == "FINALIZADO")
            {
                ingresoActualizable.FechaCierre = fechaActual;
                ingresoActualizable.HoraCierre = fechaActual;
                ingresoActualizable.UsuarioCierre = ingreso.UsuarioUltimaActualizacion;
            }
            if (matriz.Subrazon == "SE CREO MATRIZ CORRECTAMENTE")
            {
                ingresoActualizable.NombreLineaEscalado = "CELULA GESTION MATRICES";
            }
            
            ingresoActualizable.FechaUltimaActualizacion = fechaActual;
            ingresoActualizable.HoraUltimaActualizacion = fechaActual;
            ingresoActualizable.UsuarioUltimaActualizacion = ingreso.UsuarioUltimaActualizacion;
            ingresoActualizable.EstadoTransaccion = ingreso.EstadoTransaccion;

            unitWorkIA.Complete();
            unitWorkIA.Dispose();

            //Inserta Nota Transaccion Matrices
            UnitOfWork unitWorkNT = new UnitOfWork(new DimeContext());
            GestionMatriz notaTransaccion = new GestionMatriz();

            notaTransaccion.IdTransaccion = ingresoActualizable.IdTransaccion;
            notaTransaccion.UsuarioTransaccion = matriz.UsuarioTransaccion;
            notaTransaccion.CanalTransaccion = matriz.CanalTransaccion;
            notaTransaccion.FechaTransaccion = fechaActual;
            notaTransaccion.NombreLineaTransaccion = matriz.NombreLineaTransaccion;
            notaTransaccion.TipoGestionMatriz = matriz.TipoGestionMatriz;
            notaTransaccion.TipoCliente = matriz.TipoCliente;
            notaTransaccion.CuentaCliente = ingresoActualizable.CuentaCliente;
            notaTransaccion.CuentaMatriz = matriz.CuentaMatriz;
            notaTransaccion.OrdenTrabajo = matriz.OrdenTrabajo;
            notaTransaccion.Direccion = matriz.Direccion;
            notaTransaccion.Nodo = matriz.Nodo;
            notaTransaccion.NombreConjuntoEdificio = matriz.NombreConjuntoEdificio;
            notaTransaccion.TelefonoCLiente = matriz.TelefonoCLiente;
            notaTransaccion.TelefonoAdministrador = matriz.TelefonoAdministrador;
            notaTransaccion.NombreAdministrador = matriz.NombreAdministrador;
            notaTransaccion.Razon = matriz.Razon;
            notaTransaccion.Subrazon = matriz.Subrazon;
            notaTransaccion.Observacion = matriz.Observacion;
            notaTransaccion.EstadoTransaccion = matriz.EstadoTransaccion;
            notaTransaccion.UsuarioBackOfficeCreacion = null;
            notaTransaccion.UsuarioBackOfficeGestion = null;

            unitWorkNT.gestionMatrices.Add(notaTransaccion);
            unitWorkNT.Complete();
            unitWorkNT.Dispose();

            //actualiza lista de gestion de matrices
            UnitOfWork unitWorkNA = new UnitOfWork(new DimeContext());
            List<GestionMatriz> matrizactualizable = unitWorkNA.gestionMatrices.Find(c => c.IdTransaccion == ingreso.IdTransaccion).ToList();
            foreach (var item in matrizactualizable)
            {
                item.UsuarioBackOfficeCreacion = null;
                item.UsuarioBackOfficeGestion = null;
            }
            unitWorkNA.Complete();
            unitWorkNA.Dispose();

            //registro de tiempos y transaccion
            UnitOfWork unitWorkRT = new UnitOfWork(new DimeContext());

            transaccion.IdTransaccion = ingresoActualizable.IdTransaccion;
            transaccion.UsuarioTransaccion = notaTransaccion.UsuarioTransaccion;
            transaccion.EstadoTransaccion = notaTransaccion.EstadoTransaccion;

            unitWorkRT.traficoTraslados.Add(transaccion);
            unitWorkRT.Complete();
            unitWorkRT.Dispose();

        }
        public bool TransaccionCrearMatrizEnGestion(int id, String usrABackOffice)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            string result = unitWork.gestionMatrices.ComprobarActualizarUsrBackofficeCreacion(id, usrABackOffice);
            if (result == usrABackOffice) return false;
            else return true;
        }
        public List<DatoConsultaDirecciones> ListaSeguimientosCrearMatrizCelula(string usrABackOffice)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 join b in (from m in dimContext.gestionMatrices select new { m.IdTransaccion, m.UsuarioBackOfficeCreacion }).Distinct() on a.IdTransaccion equals b.IdTransaccion
                                 where a.EstadoTransaccion.Equals("SEGUIMIENTO") && a.NombreLineaEscalado.Equals("CELULA CREACION MATRICES") && (b.UsuarioBackOfficeCreacion == usrABackOffice || b.UsuarioBackOfficeCreacion == null)
                                 orderby a.HoraUltimaActualizacion ascending
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.CuentaCliente,
                                     a.FechaApertura,
                                     a.HoraUltimaActualizacion,
                                     a.UsuarioApertura,
                                     a.EstadoTransaccion,
                                     a.NombreLineaIngreso,
                                     a.NombreLineaEscalado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].IngresoTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].IngresoTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].IngresoTrasladoGetSet.FechaApertura = objetosResult[i].FechaApertura;
                result[i].IngresoTrasladoGetSet.HoraUltimaActualizacion = objetosResult[i].HoraUltimaActualizacion;
                result[i].IngresoTrasladoGetSet.UsuarioApertura = objetosResult[i].UsuarioApertura;
                result[i].IngresoTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].IngresoTrasladoGetSet.NombreLineaIngreso = objetosResult[i].NombreLineaIngreso;
                result[i].IngresoTrasladoGetSet.NombreLineaEscalado = objetosResult[i].NombreLineaEscalado;

            }


            return result;
        }
        public List<DatoConsultaDirecciones> ListaSolicitudesGestionMatriz(string Usuario)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 join b in (from m in dimContext.gestionMatrices select new { m.IdTransaccion, m.UsuarioBackOfficeGestion }).Distinct() on a.IdTransaccion equals b.IdTransaccion
                                 where a.EstadoTransaccion.Equals("PENDIENTE POR GESTIONAR") && a.NombreLineaEscalado.Equals("CELULA GESTION MATRICES") &&(b.UsuarioBackOfficeGestion == null || b.UsuarioBackOfficeGestion == Usuario)
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.CuentaCliente,
                                     a.FechaApertura,
                                     a.UsuarioApertura,
                                     a.EstadoTransaccion,
                                     a.NombreLineaIngreso,
                                     a.NombreLineaEscalado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].IngresoTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].IngresoTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].IngresoTrasladoGetSet.FechaApertura = objetosResult[i].FechaApertura;
                result[i].IngresoTrasladoGetSet.UsuarioApertura = objetosResult[i].UsuarioApertura;
                result[i].IngresoTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].IngresoTrasladoGetSet.NombreLineaIngreso = objetosResult[i].NombreLineaIngreso;
                result[i].IngresoTrasladoGetSet.NombreLineaEscalado = objetosResult[i].NombreLineaEscalado;

            }


            return result;
        }
        public bool TransaccionGestionMatrizEnGestion(int id, String usrOut)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            string result = unitWork.gestionMatrices.ComprobarActualizarUsrBackofficeGestion(id, usrOut);
            if (result == usrOut) return false;
            else return true;
        }
        public List<DatoConsultaDirecciones> ListaSeguimientosGestionMatricesCelula(string UsuarioOut)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 join b in (from m in dimContext.gestionMatrices select new { m.IdTransaccion, m.UsuarioBackOfficeGestion }).Distinct() on a.IdTransaccion equals b.IdTransaccion
                                 where a.EstadoTransaccion.Equals("SEGUIMIENTO") && a.NombreLineaEscalado.Equals("CELULA GESTION MATRICES") && (b.UsuarioBackOfficeGestion == UsuarioOut || b.UsuarioBackOfficeGestion == null)
                                 orderby a.HoraUltimaActualizacion ascending
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.CuentaCliente,
                                     a.FechaApertura,
                                     a.HoraUltimaActualizacion,
                                     a.UsuarioApertura,
                                     a.EstadoTransaccion,
                                     a.NombreLineaIngreso,
                                     a.NombreLineaEscalado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].IngresoTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].IngresoTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].IngresoTrasladoGetSet.FechaApertura = objetosResult[i].FechaApertura;
                result[i].IngresoTrasladoGetSet.HoraUltimaActualizacion = objetosResult[i].HoraUltimaActualizacion;
                result[i].IngresoTrasladoGetSet.UsuarioApertura = objetosResult[i].UsuarioApertura;
                result[i].IngresoTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].IngresoTrasladoGetSet.NombreLineaIngreso = objetosResult[i].NombreLineaIngreso;
                result[i].IngresoTrasladoGetSet.NombreLineaEscalado = objetosResult[i].NombreLineaEscalado;

            }


            return result;
        }
        public List<DatoConsultaDirecciones> ListGestionMatrices(DateTime FechaInicial, DateTime FechaFinal, string usrTransac)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.gestionMatrices
                                 join b in dimContext.IngresoTraslados on a.IdTransaccion equals b.IdTransaccion
                                 where a.FechaTransaccion >= FechaInicial && a.FechaTransaccion <= FechaFinal && a.UsuarioTransaccion == usrTransac
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.CuentaCliente,
                                     a.UsuarioTransaccion,
                                     a.CanalTransaccion,
                                     a.FechaTransaccion,
                                     a.NombreLineaTransaccion,
                                     a.EstadoTransaccion,
                                     a.Razon,
                                     a.Subrazon,
                                     a.Observacion
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].NotaTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].NotaTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NotaTrasladoGetSet.UsuarioTransaccion = objetosResult[i].UsuarioTransaccion;
                result[i].NotaTrasladoGetSet.CanalTransaccion = objetosResult[i].CanalTransaccion;
                result[i].NotaTrasladoGetSet.FechaTransaccion = objetosResult[i].FechaTransaccion;
                result[i].NotaTrasladoGetSet.NombreLineaTransaccion = objetosResult[i].NombreLineaTransaccion;
                result[i].NotaTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].NotaTrasladoGetSet.Razon = objetosResult[i].Razon;
                result[i].NotaTrasladoGetSet.Subrazon = objetosResult[i].Subrazon;
                result[i].NotaTrasladoGetSet.Observacion = objetosResult[i].Observacion;

            }


            return result;
        }
        public List<DatoConsultaDirecciones> ListaGeneralIngresosTraslados(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 where a.FechaApertura >= FechaInicial && a.FechaApertura <= FechaFinal
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.CuentaCliente,
                                     a.TipoGestion,
                                     a.FechaApertura,
                                     a.HoraApertura,
                                     a.FechaCierre,
                                     a.HoraCierre,
                                     a.FechaUltimaActualizacion,
                                     a.HoraUltimaActualizacion,
                                     a.UsuarioUltimaActualizacion,
                                     a.UsuarioApertura,
                                     a.UsuarioCierre,
                                     a.EstadoTransaccion,
                                     a.AliadoApertura,
                                     a.NombreLineaIngreso,
                                     a.NombreLineaEscalado

                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].IngresoTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].IngresoTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].IngresoTrasladoGetSet.TipoGestion = objetosResult[i].TipoGestion;
                result[i].IngresoTrasladoGetSet.FechaApertura = objetosResult[i].FechaApertura;
                result[i].IngresoTrasladoGetSet.HoraApertura = objetosResult[i].HoraApertura;
                result[i].IngresoTrasladoGetSet.FechaUltimaActualizacion = objetosResult[i].FechaUltimaActualizacion;
                result[i].IngresoTrasladoGetSet.HoraUltimaActualizacion = objetosResult[i].HoraUltimaActualizacion;
                result[i].IngresoTrasladoGetSet.FechaCierre = objetosResult[i].FechaCierre;
                result[i].IngresoTrasladoGetSet.HoraCierre = objetosResult[i].HoraCierre;
                result[i].IngresoTrasladoGetSet.UsuarioApertura = objetosResult[i].UsuarioApertura;
                result[i].IngresoTrasladoGetSet.UsuarioCierre = objetosResult[i].UsuarioCierre;
                result[i].IngresoTrasladoGetSet.UsuarioUltimaActualizacion = objetosResult[i].UsuarioUltimaActualizacion;
                result[i].IngresoTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].IngresoTrasladoGetSet.AliadoApertura = objetosResult[i].AliadoApertura;
                result[i].IngresoTrasladoGetSet.NombreLineaIngreso = objetosResult[i].NombreLineaIngreso;
                result[i].IngresoTrasladoGetSet.NombreLineaEscalado = objetosResult[i].NombreLineaEscalado;

            }
            return result;
        }
        public List<DatoConsultaDirecciones> ListaGeneralIngresosCrearDireccion(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.NotasTraslados
                                 where a.FechaTransaccion >= FechaInicial && a.FechaTransaccion <= FechaFinal
                                 select new
                                 {
                                     a.Id,
                                     a.IdTransaccion,
                                     a.UsuarioTransaccion,
                                     a.CuentaCliente,
                                     a.CanalTransaccion,
                                     a.FechaTransaccion,
                                     a.NombreLineaTransaccion,
                                     a.DireccionACrear,
                                     a.Estrato,
                                     a.Nodo,
                                     a.TelefonoCelular,
                                     a.TelefonoFijo,
                                     a.Razon,
                                     a.Subrazon,
                                     a.Observacion,
                                     a.EstadoTransaccion,
                                     a.UsuarioBackOffice,
                                     a.UsuarioBackOutbound,


                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].NotaTrasladoGetSet.Id = objetosResult[i].Id;
                result[i].NotaTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].NotaTrasladoGetSet.UsuarioTransaccion = objetosResult[i].UsuarioTransaccion;
                result[i].NotaTrasladoGetSet.CanalTransaccion = objetosResult[i].CanalTransaccion;
                result[i].NotaTrasladoGetSet.FechaTransaccion = objetosResult[i].FechaTransaccion;
                result[i].NotaTrasladoGetSet.NombreLineaTransaccion = objetosResult[i].NombreLineaTransaccion;
                result[i].NotaTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NotaTrasladoGetSet.DireccionACrear = objetosResult[i].DireccionACrear;
                result[i].NotaTrasladoGetSet.Estrato = objetosResult[i].Estrato;
                result[i].NotaTrasladoGetSet.Nodo = objetosResult[i].Nodo;
                result[i].NotaTrasladoGetSet.TelefonoCelular = objetosResult[i].TelefonoCelular;
                result[i].NotaTrasladoGetSet.TelefonoFijo = objetosResult[i].TelefonoFijo;
                result[i].NotaTrasladoGetSet.Razon = objetosResult[i].Razon;
                result[i].NotaTrasladoGetSet.Subrazon = objetosResult[i].Subrazon;
                result[i].NotaTrasladoGetSet.Observacion = objetosResult[i].Observacion;
                result[i].NotaTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].NotaTrasladoGetSet.UsuarioBackOffice = objetosResult[i].UsuarioBackOffice;
                result[i].NotaTrasladoGetSet.UsuarioBackOutbound = objetosResult[i].UsuarioBackOutbound;
            }
            return result;
        }
        public List<DatoConsultaDirecciones> ListaGeneralIngresosCambiEstrato(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.cambioEstratos
                                 where a.FechaTransaccion >= FechaInicial && a.FechaTransaccion <= FechaFinal
                                 select new
                                 {
                                     a.Id,
                                     a.IdTransaccion,
                                     a.UsuarioTransaccion,
                                     a.CuentaCliente,
                                     a.CanalTransaccion,
                                     a.FechaTransaccion,
                                     a.NombreLineaTransaccion,
                                     a.Direccion,
                                     a.Estrato,
                                     a.Nodo,
                                     a.TelefonoCelular,
                                     a.TelefonoFijo,
                                     a.Razon,
                                     a.Subrazon,
                                     a.Observacion,
                                     a.EstadoTransaccion,
                                     a.UsuarioBackOffice,
                                     a.CorreoElectronico,


                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].CambioEstrato.Id = objetosResult[i].Id;
                result[i].CambioEstrato.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].CambioEstrato.UsuarioTransaccion = objetosResult[i].UsuarioTransaccion;
                result[i].CambioEstrato.CanalTransaccion = objetosResult[i].CanalTransaccion;
                result[i].CambioEstrato.FechaTransaccion = objetosResult[i].FechaTransaccion;
                result[i].CambioEstrato.NombreLineaTransaccion = objetosResult[i].NombreLineaTransaccion;
                result[i].CambioEstrato.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].CambioEstrato.Direccion = objetosResult[i].Direccion;
                result[i].CambioEstrato.Estrato = objetosResult[i].Estrato;
                result[i].CambioEstrato.Nodo = objetosResult[i].Nodo;
                result[i].CambioEstrato.TelefonoCelular = objetosResult[i].TelefonoCelular;
                result[i].CambioEstrato.TelefonoFijo = objetosResult[i].TelefonoFijo;
                result[i].CambioEstrato.Razon = objetosResult[i].Razon;
                result[i].CambioEstrato.Subrazon = objetosResult[i].Subrazon;
                result[i].CambioEstrato.Observacion = objetosResult[i].Observacion;
                result[i].CambioEstrato.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].CambioEstrato.UsuarioBackOffice = objetosResult[i].UsuarioBackOffice;
                result[i].CambioEstrato.CorreoElectronico = objetosResult[i].CorreoElectronico;
            }
            return result;
        }
        public List<DatoConsultaDirecciones> ListaGeneralIngresosLiberaciones(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.liberacionesHomePass
                                 where a.FechaTransaccion >= FechaInicial && a.FechaTransaccion <= FechaFinal
                                 select new
                                 {
                                     a.Id,
                                     a.IdTransaccion,
                                     a.UsuarioTransaccion,
                                     a.CanalTransaccion,
                                     a.FechaTransaccion,
                                     a.NombreLineaTransaccion,
                                     a.CuentaOcupa,
                                     a.CuentaTraslada,
                                     a.Direccion,
                                     a.Nodo,
                                     a.TelefonoCelular,
                                     a.TelefonoFijo,
                                     a.Razon,
                                     a.Subrazon,
                                     a.Observacion,
                                     a.EstadoTransaccion,
                                     a.UsuarioBackOffice,
                                     a.MotivoLiberacion,


                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].LiberacionHomePass.Id = objetosResult[i].Id;
                result[i].LiberacionHomePass.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].LiberacionHomePass.UsuarioTransaccion = objetosResult[i].UsuarioTransaccion;
                result[i].LiberacionHomePass.CanalTransaccion = objetosResult[i].CanalTransaccion;
                result[i].LiberacionHomePass.FechaTransaccion = objetosResult[i].FechaTransaccion;
                result[i].LiberacionHomePass.NombreLineaTransaccion = objetosResult[i].NombreLineaTransaccion;
                result[i].LiberacionHomePass.CuentaOcupa = objetosResult[i].CuentaOcupa;
                result[i].LiberacionHomePass.CuentaTraslada = objetosResult[i].CuentaTraslada;
                result[i].LiberacionHomePass.Direccion = objetosResult[i].Direccion;
                result[i].LiberacionHomePass.Nodo = objetosResult[i].Nodo;
                result[i].LiberacionHomePass.TelefonoCelular = objetosResult[i].TelefonoCelular;
                result[i].LiberacionHomePass.TelefonoFijo = objetosResult[i].TelefonoFijo;
                result[i].LiberacionHomePass.Razon = objetosResult[i].Razon;
                result[i].LiberacionHomePass.Subrazon = objetosResult[i].Subrazon;
                result[i].LiberacionHomePass.Observacion = objetosResult[i].Observacion;
                result[i].LiberacionHomePass.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].LiberacionHomePass.UsuarioBackOffice = objetosResult[i].UsuarioBackOffice;
                result[i].LiberacionHomePass.MotivoLiberacion = objetosResult[i].MotivoLiberacion;
            }
            return result;
        }
        public List<DatoConsultaDirecciones> ListaGeneralIngresosmatrices(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.gestionMatrices
                                 where a.FechaTransaccion >= FechaInicial && a.FechaTransaccion <= FechaFinal
                                 select new
                                 {
                                     a.Id,
                                     a.IdTransaccion,
                                     a.UsuarioTransaccion,
                                     a.CanalTransaccion,
                                     a.FechaTransaccion,
                                     a.NombreLineaTransaccion,
                                     a.TipoGestionMatriz,
                                     a.TipoCliente,
                                     a.CuentaCliente,
                                     a.CuentaMatriz,
                                     a.OrdenTrabajo,
                                     a.Direccion,
                                     a.Nodo,
                                     a.NombreConjuntoEdificio,
                                     a.TelefonoCLiente,
                                     a.TelefonoAdministrador,
                                     a.NombreAdministrador,
                                     a.Razon,
                                     a.Subrazon,
                                     a.Observacion,
                                     a.EstadoTransaccion,
                                     a.UsuarioBackOfficeCreacion,
                                     a.UsuarioBackOfficeGestion
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].GestionMatriz.Id = objetosResult[i].Id;
                result[i].GestionMatriz.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].GestionMatriz.UsuarioTransaccion = objetosResult[i].UsuarioTransaccion;
                result[i].GestionMatriz.CanalTransaccion = objetosResult[i].CanalTransaccion;
                result[i].GestionMatriz.FechaTransaccion = objetosResult[i].FechaTransaccion;
                result[i].GestionMatriz.NombreLineaTransaccion = objetosResult[i].NombreLineaTransaccion;
                result[i].GestionMatriz.TipoGestionMatriz = objetosResult[i].TipoGestionMatriz;
                result[i].GestionMatriz.TipoCliente = objetosResult[i].TipoCliente;
                result[i].GestionMatriz.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].GestionMatriz.CuentaMatriz = objetosResult[i].CuentaMatriz;
                result[i].GestionMatriz.OrdenTrabajo = objetosResult[i].OrdenTrabajo;
                result[i].GestionMatriz.Direccion = objetosResult[i].Direccion;
                result[i].GestionMatriz.Nodo = objetosResult[i].Nodo;
                result[i].GestionMatriz.NombreConjuntoEdificio = objetosResult[i].NombreConjuntoEdificio;
                result[i].GestionMatriz.TelefonoCLiente = objetosResult[i].TelefonoCLiente;
                result[i].GestionMatriz.TelefonoAdministrador = objetosResult[i].TelefonoAdministrador;
                result[i].GestionMatriz.NombreAdministrador = objetosResult[i].NombreAdministrador;
                result[i].GestionMatriz.Razon = objetosResult[i].Razon;
                result[i].GestionMatriz.Subrazon = objetosResult[i].Subrazon;
                result[i].GestionMatriz.Observacion = objetosResult[i].Observacion;
                result[i].GestionMatriz.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].GestionMatriz.UsuarioBackOfficeCreacion = objetosResult[i].UsuarioBackOfficeCreacion;
                result[i].GestionMatriz.UsuarioBackOfficeGestion = objetosResult[i].UsuarioBackOfficeGestion;
            }
            return result;
        }
        public List<DatoConsultaDirecciones> ConsultaIngresosTrasladosAsesor(decimal CuentaCliente)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 where a.CuentaCliente == CuentaCliente
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.CuentaCliente,
                                     a.TipoGestion,
                                     a.FechaApertura,
                                     a.HoraApertura,
                                     a.FechaCierre,
                                     a.HoraCierre,
                                     a.FechaUltimaActualizacion,
                                     a.HoraUltimaActualizacion,
                                     a.UsuarioUltimaActualizacion,
                                     a.UsuarioApertura,
                                     a.UsuarioCierre,
                                     a.EstadoTransaccion,
                                     a.AliadoApertura,
                                     a.NombreLineaIngreso,
                                     a.NombreLineaEscalado

                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].IngresoTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].IngresoTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].IngresoTrasladoGetSet.TipoGestion = objetosResult[i].TipoGestion;
                result[i].IngresoTrasladoGetSet.FechaApertura = objetosResult[i].FechaApertura;
                result[i].IngresoTrasladoGetSet.HoraApertura = objetosResult[i].HoraApertura;
                result[i].IngresoTrasladoGetSet.FechaUltimaActualizacion = objetosResult[i].FechaUltimaActualizacion;
                result[i].IngresoTrasladoGetSet.HoraUltimaActualizacion = objetosResult[i].HoraUltimaActualizacion;
                result[i].IngresoTrasladoGetSet.FechaCierre = objetosResult[i].FechaCierre;
                result[i].IngresoTrasladoGetSet.HoraCierre = objetosResult[i].HoraCierre;
                result[i].IngresoTrasladoGetSet.UsuarioApertura = objetosResult[i].UsuarioApertura;
                result[i].IngresoTrasladoGetSet.UsuarioCierre = objetosResult[i].UsuarioCierre;
                result[i].IngresoTrasladoGetSet.UsuarioUltimaActualizacion = objetosResult[i].UsuarioUltimaActualizacion;
                result[i].IngresoTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].IngresoTrasladoGetSet.AliadoApertura = objetosResult[i].AliadoApertura;
                result[i].IngresoTrasladoGetSet.NombreLineaIngreso = objetosResult[i].NombreLineaIngreso;
                result[i].IngresoTrasladoGetSet.NombreLineaEscalado = objetosResult[i].NombreLineaEscalado;

            }
            return result;
        }
        //consultas general asesor
        public List<DatoConsultaDirecciones> ListaGeneralIngresosCrearDireccionAsesor(decimal CuentaCliente)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.NotasTraslados
                                 where a.CuentaCliente == CuentaCliente
                                 select new
                                 {
                                     a.Id,
                                     a.IdTransaccion,
                                     a.UsuarioTransaccion,
                                     a.CuentaCliente,
                                     a.CanalTransaccion,
                                     a.FechaTransaccion,
                                     a.NombreLineaTransaccion,
                                     a.DireccionACrear,
                                     a.Estrato,
                                     a.Nodo,
                                     a.TelefonoCelular,
                                     a.TelefonoFijo,
                                     a.Razon,
                                     a.Subrazon,
                                     a.Observacion,
                                     a.EstadoTransaccion,
                                     a.UsuarioBackOffice,
                                     a.UsuarioBackOutbound,


                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].NotaTrasladoGetSet.Id = objetosResult[i].Id;
                result[i].NotaTrasladoGetSet.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].NotaTrasladoGetSet.UsuarioTransaccion = objetosResult[i].UsuarioTransaccion;
                result[i].NotaTrasladoGetSet.CanalTransaccion = objetosResult[i].CanalTransaccion;
                result[i].NotaTrasladoGetSet.FechaTransaccion = objetosResult[i].FechaTransaccion;
                result[i].NotaTrasladoGetSet.NombreLineaTransaccion = objetosResult[i].NombreLineaTransaccion;
                result[i].NotaTrasladoGetSet.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NotaTrasladoGetSet.DireccionACrear = objetosResult[i].DireccionACrear;
                result[i].NotaTrasladoGetSet.Estrato = objetosResult[i].Estrato;
                result[i].NotaTrasladoGetSet.Nodo = objetosResult[i].Nodo;
                result[i].NotaTrasladoGetSet.TelefonoCelular = objetosResult[i].TelefonoCelular;
                result[i].NotaTrasladoGetSet.TelefonoFijo = objetosResult[i].TelefonoFijo;
                result[i].NotaTrasladoGetSet.Razon = objetosResult[i].Razon;
                result[i].NotaTrasladoGetSet.Subrazon = objetosResult[i].Subrazon;
                result[i].NotaTrasladoGetSet.Observacion = objetosResult[i].Observacion;
                result[i].NotaTrasladoGetSet.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].NotaTrasladoGetSet.UsuarioBackOffice = objetosResult[i].UsuarioBackOffice;
                result[i].NotaTrasladoGetSet.UsuarioBackOutbound = objetosResult[i].UsuarioBackOutbound;
            }
            return result;
        }
        public List<DatoConsultaDirecciones> ListaGeneralIngresosCambiEstratoAsesor(decimal CuentaCliente)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.cambioEstratos
                                 where a.CuentaCliente == CuentaCliente
                                 select new
                                 {
                                     a.Id,
                                     a.IdTransaccion,
                                     a.UsuarioTransaccion,
                                     a.CuentaCliente,
                                     a.CanalTransaccion,
                                     a.FechaTransaccion,
                                     a.NombreLineaTransaccion,
                                     a.Direccion,
                                     a.Estrato,
                                     a.Nodo,
                                     a.TelefonoCelular,
                                     a.TelefonoFijo,
                                     a.Razon,
                                     a.Subrazon,
                                     a.Observacion,
                                     a.EstadoTransaccion,
                                     a.UsuarioBackOffice,
                                     a.CorreoElectronico,


                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].CambioEstrato.Id = objetosResult[i].Id;
                result[i].CambioEstrato.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].CambioEstrato.UsuarioTransaccion = objetosResult[i].UsuarioTransaccion;
                result[i].CambioEstrato.CanalTransaccion = objetosResult[i].CanalTransaccion;
                result[i].CambioEstrato.FechaTransaccion = objetosResult[i].FechaTransaccion;
                result[i].CambioEstrato.NombreLineaTransaccion = objetosResult[i].NombreLineaTransaccion;
                result[i].CambioEstrato.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].CambioEstrato.Direccion = objetosResult[i].Direccion;
                result[i].CambioEstrato.Estrato = objetosResult[i].Estrato;
                result[i].CambioEstrato.Nodo = objetosResult[i].Nodo;
                result[i].CambioEstrato.TelefonoCelular = objetosResult[i].TelefonoCelular;
                result[i].CambioEstrato.TelefonoFijo = objetosResult[i].TelefonoFijo;
                result[i].CambioEstrato.Razon = objetosResult[i].Razon;
                result[i].CambioEstrato.Subrazon = objetosResult[i].Subrazon;
                result[i].CambioEstrato.Observacion = objetosResult[i].Observacion;
                result[i].CambioEstrato.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].CambioEstrato.UsuarioBackOffice = objetosResult[i].UsuarioBackOffice;
                result[i].CambioEstrato.CorreoElectronico = objetosResult[i].CorreoElectronico;
            }
            return result;
        }
        public List<DatoConsultaDirecciones> ListaGeneralIngresosLiberacionesAsesor(decimal CuentaCliente)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.liberacionesHomePass
                                 where a.CuentaOcupa == CuentaCliente
                                 select new
                                 {
                                     a.Id,
                                     a.IdTransaccion,
                                     a.UsuarioTransaccion,
                                     a.CanalTransaccion,
                                     a.FechaTransaccion,
                                     a.NombreLineaTransaccion,
                                     a.CuentaOcupa,
                                     a.CuentaTraslada,
                                     a.Direccion,
                                     a.Nodo,
                                     a.TelefonoCelular,
                                     a.TelefonoFijo,
                                     a.Razon,
                                     a.Subrazon,
                                     a.Observacion,
                                     a.EstadoTransaccion,
                                     a.UsuarioBackOffice,
                                     a.MotivoLiberacion,


                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].LiberacionHomePass.Id = objetosResult[i].Id;
                result[i].LiberacionHomePass.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].LiberacionHomePass.UsuarioTransaccion = objetosResult[i].UsuarioTransaccion;
                result[i].LiberacionHomePass.CanalTransaccion = objetosResult[i].CanalTransaccion;
                result[i].LiberacionHomePass.FechaTransaccion = objetosResult[i].FechaTransaccion;
                result[i].LiberacionHomePass.NombreLineaTransaccion = objetosResult[i].NombreLineaTransaccion;
                result[i].LiberacionHomePass.CuentaOcupa = objetosResult[i].CuentaOcupa;
                result[i].LiberacionHomePass.CuentaTraslada = objetosResult[i].CuentaTraslada;
                result[i].LiberacionHomePass.Direccion = objetosResult[i].Direccion;
                result[i].LiberacionHomePass.Nodo = objetosResult[i].Nodo;
                result[i].LiberacionHomePass.TelefonoCelular = objetosResult[i].TelefonoCelular;
                result[i].LiberacionHomePass.TelefonoFijo = objetosResult[i].TelefonoFijo;
                result[i].LiberacionHomePass.Razon = objetosResult[i].Razon;
                result[i].LiberacionHomePass.Subrazon = objetosResult[i].Subrazon;
                result[i].LiberacionHomePass.Observacion = objetosResult[i].Observacion;
                result[i].LiberacionHomePass.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].LiberacionHomePass.UsuarioBackOffice = objetosResult[i].UsuarioBackOffice;
                result[i].LiberacionHomePass.MotivoLiberacion = objetosResult[i].MotivoLiberacion;
            }
            return result;
        }
        public List<DatoConsultaDirecciones> ListaGeneralIngresosmatricesAsesor(decimal CuentaCliente)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.gestionMatrices
                                 where a.CuentaCliente == CuentaCliente
                                 select new
                                 {
                                     a.Id,
                                     a.IdTransaccion,
                                     a.UsuarioTransaccion,
                                     a.CanalTransaccion,
                                     a.FechaTransaccion,
                                     a.NombreLineaTransaccion,
                                     a.TipoGestionMatriz,
                                     a.TipoCliente,
                                     a.CuentaCliente,
                                     a.CuentaMatriz,
                                     a.OrdenTrabajo,
                                     a.Direccion,
                                     a.Nodo,
                                     a.NombreConjuntoEdificio,
                                     a.TelefonoCLiente,
                                     a.TelefonoAdministrador,
                                     a.NombreAdministrador,
                                     a.Razon,
                                     a.Subrazon,
                                     a.Observacion,
                                     a.EstadoTransaccion,
                                     a.UsuarioBackOfficeCreacion,
                                     a.UsuarioBackOfficeGestion
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].GestionMatriz.Id = objetosResult[i].Id;
                result[i].GestionMatriz.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].GestionMatriz.UsuarioTransaccion = objetosResult[i].UsuarioTransaccion;
                result[i].GestionMatriz.CanalTransaccion = objetosResult[i].CanalTransaccion;
                result[i].GestionMatriz.FechaTransaccion = objetosResult[i].FechaTransaccion;
                result[i].GestionMatriz.NombreLineaTransaccion = objetosResult[i].NombreLineaTransaccion;
                result[i].GestionMatriz.TipoGestionMatriz = objetosResult[i].TipoGestionMatriz;
                result[i].GestionMatriz.TipoCliente = objetosResult[i].TipoCliente;
                result[i].GestionMatriz.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].GestionMatriz.CuentaMatriz = objetosResult[i].CuentaMatriz;
                result[i].GestionMatriz.OrdenTrabajo = objetosResult[i].OrdenTrabajo;
                result[i].GestionMatriz.Direccion = objetosResult[i].Direccion;
                result[i].GestionMatriz.Nodo = objetosResult[i].Nodo;
                result[i].GestionMatriz.NombreConjuntoEdificio = objetosResult[i].NombreConjuntoEdificio;
                result[i].GestionMatriz.TelefonoCLiente = objetosResult[i].TelefonoCLiente;
                result[i].GestionMatriz.TelefonoAdministrador = objetosResult[i].TelefonoAdministrador;
                result[i].GestionMatriz.NombreAdministrador = objetosResult[i].NombreAdministrador;
                result[i].GestionMatriz.Razon = objetosResult[i].Razon;
                result[i].GestionMatriz.Subrazon = objetosResult[i].Subrazon;
                result[i].GestionMatriz.Observacion = objetosResult[i].Observacion;
                result[i].GestionMatriz.EstadoTransaccion = objetosResult[i].EstadoTransaccion;
                result[i].GestionMatriz.UsuarioBackOfficeCreacion = objetosResult[i].UsuarioBackOfficeCreacion;
                result[i].GestionMatriz.UsuarioBackOfficeGestion = objetosResult[i].UsuarioBackOfficeGestion;
            }
            return result;
        }
        //traslados fallidos
        public void InsertIngresoTrasladoFallido(IngresoTraslado ingreso, TrasladoFallido notaTraslado, TraficoTraslado transaccion)
        {
            //Inserta Transaccion de Traslado Fallido
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            
            ingreso.TipoGestion = "TRASLADO FALLIDO";
            ingreso.FechaApertura = DateTime.Now;
            ingreso.HoraApertura = DateTime.Now;
            ingreso.FechaUltimaActualizacion = DateTime.Now;
            ingreso.HoraUltimaActualizacion = DateTime.Now;
            ingreso.FechaCierre = DateTime.Now;
            ingreso.UsuarioCierre = ingreso.UsuarioApertura;
            ingreso.HoraCierre = DateTime.Now;
            ingreso.EstadoTransaccion = "FINALIZADO";

            unitWork.ingresoTraslados.Add(ingreso);
            unitWork.Complete();
            unitWork.Dispose();

            //Inserta Nota Transaccion de Traslado Fallido
            UnitOfWork unitWorknotaTraslado = new UnitOfWork(new DimeContext());

            notaTraslado.IdTransaccion = ingreso.IdTransaccion;
            notaTraslado.UsuarioTransaccion = ingreso.UsuarioApertura;
            notaTraslado.CanalTransaccion = "INBOUND TRASLADOS";
            notaTraslado.FechaTransaccion = DateTime.Now;
            notaTraslado.NombreLineaTransaccion = ingreso.NombreLineaIngreso;
            notaTraslado.CuentaCliente = ingreso.CuentaCliente;

            unitWorknotaTraslado.trasladosFallidos.Add(notaTraslado);
            unitWorknotaTraslado.Complete();
            unitWorknotaTraslado.Dispose();

            //registro de tiempos y transaccion
            UnitOfWork unitWorktransaccion = new UnitOfWork(new DimeContext());

            transaccion.IdTransaccion = ingreso.IdTransaccion;
            transaccion.UsuarioTransaccion = ingreso.UsuarioApertura;
            transaccion.EstadoTransaccion = ingreso.EstadoTransaccion;
            unitWorktransaccion.traficoTraslados.Add(transaccion);
            unitWorktransaccion.Complete();
            unitWorktransaccion.Dispose();
            
        }
        public List<DatoConsultaDirecciones> ConsultaTrasladoFallidoCliente(decimal CuentaCliente)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.TrasladoFallidos
                                 where a.CuentaCliente == CuentaCliente
                                 select new
                                 {
                                     a.Id,
                                     a.IdTransaccion,
                                     a.UsuarioTransaccion,
                                     a.CanalTransaccion,
                                     a.FechaTransaccion,
                                     a.NombreLineaTransaccion,
                                     a.MotivoTrasladoFallido,
                                     a.CuentaCliente,
                                     a.CuentaOcupa,
                                     a.CuentaTraslada,
                                     a.CuentaMatriz,
                                     a.NombreConjunto,
                                     a.EstadoMatriz,
                                     a.Direccion,
                                     a.NombreDepartamento,
                                     a.NombreComunidad,
                                     a.Comunidad,
                                     a.Red,
                                     a.EstratoOrigen,
                                     a.EstratoDestino,
                                     a.TarifaActual,
                                     a.TarifaNueva,
                                     a.GestionPorTraslado,
                                     a.Nodo,
                                     a.TelefonoCelular,
                                     a.TelefonoFijo,
                                     a.CorreoElectronico,
                                     a.Observacion
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].TrasladoFallido.Id = objetosResult[i].Id;
                result[i].TrasladoFallido.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].TrasladoFallido.UsuarioTransaccion = objetosResult[i].UsuarioTransaccion;
                result[i].TrasladoFallido.CanalTransaccion = objetosResult[i].CanalTransaccion;
                result[i].TrasladoFallido.FechaTransaccion = objetosResult[i].FechaTransaccion;
                result[i].TrasladoFallido.NombreLineaTransaccion = objetosResult[i].NombreLineaTransaccion;
                result[i].TrasladoFallido.MotivoTrasladoFallido = objetosResult[i].MotivoTrasladoFallido;
                result[i].TrasladoFallido.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TrasladoFallido.CuentaOcupa = objetosResult[i].CuentaOcupa;
                result[i].TrasladoFallido.CuentaTraslada = objetosResult[i].CuentaTraslada;
                result[i].TrasladoFallido.CuentaMatriz = objetosResult[i].CuentaMatriz;
                result[i].TrasladoFallido.NombreConjunto = objetosResult[i].NombreConjunto;
                result[i].TrasladoFallido.EstadoMatriz = objetosResult[i].EstadoMatriz;
                result[i].TrasladoFallido.Direccion = objetosResult[i].Direccion;
                result[i].TrasladoFallido.NombreDepartamento = objetosResult[i].NombreDepartamento;
                result[i].TrasladoFallido.NombreComunidad = objetosResult[i].NombreComunidad;
                result[i].TrasladoFallido.Comunidad = objetosResult[i].Comunidad;
                result[i].TrasladoFallido.Red = objetosResult[i].Red;
                result[i].TrasladoFallido.EstratoOrigen = objetosResult[i].EstratoOrigen;
                result[i].TrasladoFallido.EstratoDestino = objetosResult[i].EstratoDestino;
                result[i].TrasladoFallido.TarifaActual = objetosResult[i].TarifaActual;
                result[i].TrasladoFallido.TarifaNueva = objetosResult[i].TarifaNueva;
                result[i].TrasladoFallido.GestionPorTraslado = objetosResult[i].GestionPorTraslado;
                result[i].TrasladoFallido.Nodo = objetosResult[i].Nodo;
                result[i].TrasladoFallido.TelefonoCelular = objetosResult[i].TelefonoCelular;
                result[i].TrasladoFallido.TelefonoFijo = objetosResult[i].TelefonoFijo;
                result[i].TrasladoFallido.CorreoElectronico = objetosResult[i].CorreoElectronico;
                result[i].TrasladoFallido.Observacion = objetosResult[i].Observacion;
            }
            return result;
        }
        public List<DatoConsultaDirecciones> ConsultaGeneralTrasladosFallidos(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.TrasladoFallidos
                                 where a.FechaTransaccion >= FechaInicial && a.FechaTransaccion <= FechaFinal
                                 select new
                                 {
                                     a.Id,
                                     a.IdTransaccion,
                                     a.UsuarioTransaccion,
                                     a.CanalTransaccion,
                                     a.FechaTransaccion,
                                     a.NombreLineaTransaccion,
                                     a.MotivoTrasladoFallido,
                                     a.CuentaCliente,
                                     a.CuentaOcupa,
                                     a.CuentaTraslada,
                                     a.CuentaMatriz,
                                     a.NombreConjunto,
                                     a.EstadoMatriz,
                                     a.Direccion,
                                     a.NombreDepartamento,
                                     a.NombreComunidad,
                                     a.Comunidad,
                                     a.Red,
                                     a.EstratoOrigen,
                                     a.EstratoDestino,
                                     a.TarifaActual,
                                     a.TarifaNueva,
                                     a.GestionPorTraslado,
                                     a.Nodo,
                                     a.TelefonoCelular,
                                     a.TelefonoFijo,
                                     a.CorreoElectronico,
                                     a.Observacion
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].TrasladoFallido.Id = objetosResult[i].Id;
                result[i].TrasladoFallido.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].TrasladoFallido.UsuarioTransaccion = objetosResult[i].UsuarioTransaccion;
                result[i].TrasladoFallido.CanalTransaccion = objetosResult[i].CanalTransaccion;
                result[i].TrasladoFallido.FechaTransaccion = objetosResult[i].FechaTransaccion;
                result[i].TrasladoFallido.NombreLineaTransaccion = objetosResult[i].NombreLineaTransaccion;
                result[i].TrasladoFallido.MotivoTrasladoFallido = objetosResult[i].MotivoTrasladoFallido;
                result[i].TrasladoFallido.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TrasladoFallido.CuentaOcupa = objetosResult[i].CuentaOcupa;
                result[i].TrasladoFallido.CuentaTraslada = objetosResult[i].CuentaTraslada;
                result[i].TrasladoFallido.CuentaMatriz = objetosResult[i].CuentaMatriz;
                result[i].TrasladoFallido.NombreConjunto = objetosResult[i].NombreConjunto;
                result[i].TrasladoFallido.EstadoMatriz = objetosResult[i].EstadoMatriz;
                result[i].TrasladoFallido.Direccion = objetosResult[i].Direccion;
                result[i].TrasladoFallido.NombreDepartamento = objetosResult[i].NombreDepartamento;
                result[i].TrasladoFallido.NombreComunidad = objetosResult[i].NombreComunidad;
                result[i].TrasladoFallido.Comunidad = objetosResult[i].Comunidad;
                result[i].TrasladoFallido.Red = objetosResult[i].Red;
                result[i].TrasladoFallido.EstratoOrigen = objetosResult[i].EstratoOrigen;
                result[i].TrasladoFallido.EstratoDestino = objetosResult[i].EstratoDestino;
                result[i].TrasladoFallido.TarifaActual = objetosResult[i].TarifaActual;
                result[i].TrasladoFallido.TarifaNueva = objetosResult[i].TarifaNueva;
                result[i].TrasladoFallido.GestionPorTraslado = objetosResult[i].GestionPorTraslado;
                result[i].TrasladoFallido.Nodo = objetosResult[i].Nodo;
                result[i].TrasladoFallido.TelefonoCelular = objetosResult[i].TelefonoCelular;
                result[i].TrasladoFallido.TelefonoFijo = objetosResult[i].TelefonoFijo;
                result[i].TrasladoFallido.CorreoElectronico = objetosResult[i].CorreoElectronico;
                result[i].TrasladoFallido.Observacion = objetosResult[i].Observacion;
            }
            return result;
        }

        public List<DatoConsultaDirecciones> ConsultaGestionTrasladoFallido(DateTime FechaInicial, DateTime FechaFinal, string Usuario)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.TrasladoFallidos
                                 where a.FechaTransaccion >= FechaInicial && a.FechaTransaccion <= FechaFinal && a.UsuarioTransaccion == Usuario
                                 select new
                                 {
                                     a.Id,
                                     a.IdTransaccion,
                                     a.UsuarioTransaccion,
                                     a.CanalTransaccion,
                                     a.FechaTransaccion,
                                     a.NombreLineaTransaccion,
                                     a.MotivoTrasladoFallido,
                                     a.CuentaCliente,
                                     a.CuentaOcupa,
                                     a.CuentaTraslada,
                                     a.CuentaMatriz,
                                     a.NombreConjunto,
                                     a.EstadoMatriz,
                                     a.Direccion,
                                     a.NombreDepartamento,
                                     a.NombreComunidad,
                                     a.Comunidad,
                                     a.Red,
                                     a.EstratoOrigen,
                                     a.EstratoDestino,
                                     a.TarifaActual,
                                     a.TarifaNueva,
                                     a.GestionPorTraslado,
                                     a.Nodo,
                                     a.TelefonoCelular,
                                     a.TelefonoFijo,
                                     a.CorreoElectronico,
                                     a.Observacion
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new DatoConsultaDirecciones());
                result[i].TrasladoFallido.Id = objetosResult[i].Id;
                result[i].TrasladoFallido.IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].TrasladoFallido.UsuarioTransaccion = objetosResult[i].UsuarioTransaccion;
                result[i].TrasladoFallido.CanalTransaccion = objetosResult[i].CanalTransaccion;
                result[i].TrasladoFallido.FechaTransaccion = objetosResult[i].FechaTransaccion;
                result[i].TrasladoFallido.NombreLineaTransaccion = objetosResult[i].NombreLineaTransaccion;
                result[i].TrasladoFallido.MotivoTrasladoFallido = objetosResult[i].MotivoTrasladoFallido;
                result[i].TrasladoFallido.CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TrasladoFallido.CuentaOcupa = objetosResult[i].CuentaOcupa;
                result[i].TrasladoFallido.CuentaTraslada = objetosResult[i].CuentaTraslada;
                result[i].TrasladoFallido.CuentaMatriz = objetosResult[i].CuentaMatriz;
                result[i].TrasladoFallido.NombreConjunto = objetosResult[i].NombreConjunto;
                result[i].TrasladoFallido.EstadoMatriz = objetosResult[i].EstadoMatriz;
                result[i].TrasladoFallido.Direccion = objetosResult[i].Direccion;
                result[i].TrasladoFallido.NombreDepartamento = objetosResult[i].NombreDepartamento;
                result[i].TrasladoFallido.NombreComunidad = objetosResult[i].NombreComunidad;
                result[i].TrasladoFallido.Comunidad = objetosResult[i].Comunidad;
                result[i].TrasladoFallido.Red = objetosResult[i].Red;
                result[i].TrasladoFallido.EstratoOrigen = objetosResult[i].EstratoOrigen;
                result[i].TrasladoFallido.EstratoDestino = objetosResult[i].EstratoDestino;
                result[i].TrasladoFallido.TarifaActual = objetosResult[i].TarifaActual;
                result[i].TrasladoFallido.TarifaNueva = objetosResult[i].TarifaNueva;
                result[i].TrasladoFallido.GestionPorTraslado = objetosResult[i].GestionPorTraslado;
                result[i].TrasladoFallido.Nodo = objetosResult[i].Nodo;
                result[i].TrasladoFallido.TelefonoCelular = objetosResult[i].TelefonoCelular;
                result[i].TrasladoFallido.TelefonoFijo = objetosResult[i].TelefonoFijo;
                result[i].TrasladoFallido.CorreoElectronico = objetosResult[i].CorreoElectronico;
                result[i].TrasladoFallido.Observacion = objetosResult[i].Observacion;
            }
            return result;
        }
    }
}