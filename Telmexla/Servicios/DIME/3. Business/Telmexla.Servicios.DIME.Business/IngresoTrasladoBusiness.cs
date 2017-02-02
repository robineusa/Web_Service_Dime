using System;
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
        public void InsertIngresoTraslado(IngresoTraslado ingreso,NotasTraslado notaTraslado)
        {
            try
            {
                ingreso.TipoGestion = "CREACION DE DIRECCION";
                ingreso.FechaApertura = DateTime.Now;
                ingreso.HoraApertura = DateTime.Now;
                ingreso.FechaUltimaActualizacion = DateTime.Now;
                ingreso.HoraUltimaActualizacion = DateTime.Now;
                ingreso.EstadoTransaccion= "PENDIENTE POR CREAR";
                ingreso.NombreLineaEscalado= "CELULA CREACION DIRECCION";

                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.ingresoTraslados.Add(ingreso);
                unitWork.Complete();

                notaTraslado.IdTransaccion = ingreso.IdTransaccion;
                notaTraslado.UsuarioTransaccion = ingreso.UsuarioApertura;
                notaTraslado.CanalTransaccion = "INBOUND TRASLADOS";
                notaTraslado.FechaTransaccion = DateTime.Now;
                notaTraslado.NombreLineaTransaccion = ingreso.NombreLineaIngreso;
                notaTraslado.CuentaCliente = ingreso.CuentaCliente;
                notaTraslado.Razon = "SOLICITUD INBOUND";
                notaTraslado.Subrazon = "CREACION DE DIRECCION";
                notaTraslado.EstadoTransaccion = "PENDIENTE POR CREAR";
                unitWork.notasTraslados.Add(notaTraslado);
                unitWork.Complete();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }


        }
        public bool ExisteCuentaEscalada(decimal cuenta)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.ingresoTraslados.Find(c => c.CuentaCliente.Equals(cuenta) && c.EstadoTransaccion != "FINALIZADO" && c.TipoGestion == "CREACION DE DIRECCION").Count() >= 1;

        }
        public List<DatoConsultaDirecciones> ListaSolicitudesCrearDireccion() {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 join b in (from m in dimContext.NotasTraslados select new { m.IdTransaccion, m.UsuarioBackOffice }  ).Distinct() on a.IdTransaccion equals b.IdTransaccion
                                 where a.EstadoTransaccion.Equals("PENDIENTE POR CREAR") && b.UsuarioBackOffice == null
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

            for(int i = 0; i< objetosResult.Count; i++)
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
        public NotasTrasladoCollection ListaInteraccionesCrearDireccion(int id) {

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
        public void ActualizarSolicitudCrearDireccion(IngresoTraslado ingreso, NotasTraslado notaTraslado)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            IngresoTraslado ingresoActualizable = unitWork.ingresoTraslados.Get(Convert.ToInt32(ingreso.IdTransaccion));
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
            notaTransaccion.UsuarioBackOffice = notaTraslado.UsuarioBackOffice;
            notaTransaccion.UsuarioBackOutbound = notaTraslado.UsuarioBackOutbound;
            unitWork.notasTraslados.Add(notaTransaccion);
            unitWork.Complete();
            
        }
        public bool TransaccionEnGestion(int id, String usrABackOffice)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
          string result =   unitWork.notasTraslados.ComprobarActualizarUsrBackoffice(id, usrABackOffice);
            if (result == usrABackOffice) return false;
            else return true;
        }
        public List<DatoConsultaDirecciones> ListaSeguimientosDireccionesCelula(string usrABackOffice)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 join b in (from m in dimContext.NotasTraslados select new { m.IdTransaccion, m.UsuarioBackOffice }).Distinct() on a.IdTransaccion equals b.IdTransaccion
                                 where a.EstadoTransaccion.Equals("EN GESTION") && b.UsuarioBackOffice == usrABackOffice 
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
        public List<DatoConsultaDirecciones> ListaDireccionesCreadasOutbound()
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 join b in (from m in dimContext.NotasTraslados select new { m.IdTransaccion, m.UsuarioBackOutbound }).Distinct() on a.IdTransaccion equals b.IdTransaccion
                                 where a.EstadoTransaccion.Equals("INGRESADA") && b.UsuarioBackOutbound == null
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
                                 where a.EstadoTransaccion.Equals("SEGUIMIENTO") && b.UsuarioBackOutbound == UsuarioOut
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
        public List<DatoConsultaDirecciones> ListGestionCrearDireccion(DateTime FechaInicial, DateTime FechaFinal, string usrTransac)
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.NotasTraslados
                                 join b in dimContext.IngresoTraslados on a.IdTransaccion equals b.IdTransaccion
                                 where a.FechaTransaccion>= FechaInicial && a.FechaTransaccion<= FechaFinal && a.UsuarioTransaccion== usrTransac
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
        public void InsertIngresoCambioEstrato(IngresoTraslado ingreso, CambioEstrato cambioEstrato)
        {
            try
            {
                ingreso.TipoGestion = "CAMBIO DE ESTRATO";
                ingreso.FechaApertura = DateTime.Now;
                ingreso.HoraApertura = DateTime.Now;
                ingreso.FechaUltimaActualizacion = DateTime.Now;
                ingreso.HoraUltimaActualizacion = DateTime.Now;
                ingreso.EstadoTransaccion = "PENDIENTE POR CREAR";
                ingreso.NombreLineaEscalado = "CELULA CAMBIO DE ESTRATO";

                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.ingresoTraslados.Add(ingreso);
                unitWork.Complete();

                cambioEstrato.IdTransaccion = ingreso.IdTransaccion;
                cambioEstrato.UsuarioTransaccion = ingreso.UsuarioApertura;
                cambioEstrato.CanalTransaccion = "INBOUND TRASLADOS";
                cambioEstrato.FechaTransaccion = DateTime.Now;
                cambioEstrato.NombreLineaTransaccion = ingreso.NombreLineaIngreso;
                cambioEstrato.CuentaCliente = ingreso.CuentaCliente;
                cambioEstrato.Razon = "SOLICITUD INBOUND";
                cambioEstrato.Subrazon = "CAMBIO DE ESTRATO";
                cambioEstrato.EstadoTransaccion = "PENDIENTE POR CREAR";
                unitWork.cambioEstratos.Add(cambioEstrato);
                unitWork.Complete();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }


        }
        public bool ExisteCuentaEscaladaCambioEstrato(decimal cuenta)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.ingresoTraslados.Find(c => c.CuentaCliente.Equals(cuenta) && c.EstadoTransaccion != "FINALIZADO" && c.TipoGestion == "CAMBIO DE ESTRATO").Count() >= 1;

        }
        public List<DatoConsultaDirecciones> ListaSolicitudesCambioEstrato()
        {
            DimeContext dimContext = new DimeContext();
            List<DatoConsultaDirecciones> result = new List<DatoConsultaDirecciones>();
            var objetosResult = (from a in dimContext.IngresoTraslados
                                 join b in (from m in dimContext.cambioEstratos select new { m.IdTransaccion, m.UsuarioBackOffice }).Distinct() on a.IdTransaccion equals b.IdTransaccion
                                 where a.EstadoTransaccion.Equals("PENDIENTE POR CREAR") && b.UsuarioBackOffice == null
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
        public void ActualizarSolicitudCambioEstrato(IngresoTraslado ingreso, CambioEstrato CambioEstrato)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            IngresoTraslado ingresoActualizable = unitWork.ingresoTraslados.Get(Convert.ToInt32(ingreso.IdTransaccion));
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
            notaTransaccion.UsuarioBackOffice = CambioEstrato.UsuarioBackOffice;
            notaTransaccion.CorreoElectronico = CambioEstrato.CorreoElectronico;
            unitWork.cambioEstratos.Add(notaTransaccion);
            unitWork.Complete();

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
                                 where a.EstadoTransaccion.Equals("SEGUIMIENTO") && b.UsuarioBackOffice == usrABackOffice
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
    }
}
