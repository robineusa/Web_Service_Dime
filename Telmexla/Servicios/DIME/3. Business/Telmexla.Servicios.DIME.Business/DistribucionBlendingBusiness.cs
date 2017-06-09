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
    public class DistribucionBlendingBusiness
    {
        //este proceso aparta cuenta blending y trae la informacion de clientes todos
        public ClientesTodo TraerInformacionCuentaBlending(int idAsesor, string formulario, string aliado, string operacion, string campana, int noRecursividad)
        {

            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<decimal> cuentasGestionandoAsesor = unitOfWork.distribucionesBlending.Find(c => c.UsuarioGestionando == idAsesor && c.FormularioDestino.Equals(formulario)).Select(x => x.CuentaCliente).ToList();
            if (cuentasGestionandoAsesor.Count > 0)
            {
                ClientesBusiness clientesBusiness = new ClientesBusiness();
                return clientesBusiness.ObtenerClienteCompleto(Convert.ToInt32(cuentasGestionandoAsesor[0]));
            }
            else
            {
                unitOfWork.distribucionesBlending.ApartarCuentaAGestionarBlendingAsesor(idAsesor, formulario, aliado, operacion, campana);
                noRecursividad++;
                if (noRecursividad > 1) return null;
                return TraerInformacionCuentaBlending(idAsesor, formulario, aliado, operacion, campana, noRecursividad);
            }

        }
        public void EliminaCuentaGestionadaDistribucion(DistribucionBlending Registro)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            DistribucionBlending CuentaEliminar = unitWork.distribucionesBlending.Find(c => c.CuentaCliente == Registro.CuentaCliente && c.FormularioDestino == Registro.FormularioDestino && c.AliadoDestino == Registro.AliadoDestino && c.OperacionDestino == Registro.OperacionDestino && c.CampanaDestino == Registro.CampanaDestino).FirstOrDefault();

            if (CuentaEliminar != null)
            {
                unitWork.distribucionesBlending.Remove(CuentaEliminar);
                unitWork.Complete();
            }
            else { }
        }
        public void InsertarCuentaColaDistribucionBlending(DistribucionBlending Registro)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            DistribucionBlending CuentaEliminar = unitWork.distribucionesBlending.Find(c => c.CuentaCliente == Registro.CuentaCliente && c.FormularioDestino == Registro.FormularioDestino && c.AliadoDestino == Registro.AliadoDestino && c.OperacionDestino == Registro.OperacionDestino && c.CampanaDestino == Registro.CampanaDestino).FirstOrDefault();

            if (CuentaEliminar != null)
            {
                unitWork.distribucionesBlending.Remove(CuentaEliminar);
                unitWork.Complete();
                Registro.UsuarioGestionando = 0;
                Registro.FechaAsignacion = CuentaEliminar.FechaAsignacion;
                Registro.UsuarioAsignacion = CuentaEliminar.UsuarioAsignacion;
                unitWork.distribucionesBlending.Add(Registro);
                unitWork.Complete();
            }
            else { }
        }
        public ClientesTodo AsignarIdCuentaDistribucionBlending(decimal CuentaCliente, string Formulario, string Aliado, string Operacion, string Campana, int Id)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            DistribucionBlending RegistroActualizar = unitWork.distribucionesBlending.Find(c => c.CuentaCliente == CuentaCliente && c.FormularioDestino == Formulario && c.AliadoDestino == Aliado && c.OperacionDestino == Operacion && c.CampanaDestino == Campana).FirstOrDefault();

            if (RegistroActualizar != null)
            {
                RegistroActualizar.UsuarioGestionando = Id;
                unitWork.Complete();
            }
            else { }
            ClientesBusiness clientesBusiness = new ClientesBusiness();
            return clientesBusiness.ObtenerClienteCompleto(Convert.ToInt32(CuentaCliente));

        }


        /////NUEVOS PROCESOS DE GESTION BLENDING
        // CABLE MODEM FUERA DE NIVELES
        public BlendingFueraNivel TraerInformacionCuentaFueraNiveles(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.blendingFueraNiveles.Find(c => c.CuentaCliente == CuentaCliente).FirstOrDefault();
        }
       
        
        public void InsertarRegistroFueraNiveles(GBPFueraNiveles PFueraNivel)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
            UnitOfWorkMaestros unitWorkMaestros = new UnitOfWorkMaestros(new MaestrosContext());

            PFueraNivel.TipoContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(PFueraNivel.TipoContacto)).TipoContacto;
            PFueraNivel.Gestion = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(PFueraNivel.Gestion)).Cierre;
            PFueraNivel.Cierre = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(PFueraNivel.Cierre)).Razon;
            PFueraNivel.Razon = unitWorkMaestros.maestrosOutboundCausa.Get(Convert.ToInt32(PFueraNivel.Razon)).Causa;

            PFueraNivel.FechaGestion = DateTime.Now;
            unitWork.GBPFueradeNiveles.Add(PFueraNivel);
            unitWork.Complete();




            GBLFueraNiveles LFueraNivel = new GBLFueraNiveles();

            LFueraNivel.FechaGestion = PFueraNivel.FechaGestion;
            LFueraNivel.UsuarioGestion = PFueraNivel.UsuarioGestion;
            LFueraNivel.AliadoGestion = PFueraNivel.AliadoGestion;
            LFueraNivel.CuentaCliente = PFueraNivel.CuentaCliente;
            LFueraNivel.NombreCliente = PFueraNivel.NombreCliente;
            LFueraNivel.ApellidoCliente = PFueraNivel.ApellidoCliente;
            LFueraNivel.DirInstalacion = PFueraNivel.DirInstalacion;
            LFueraNivel.DirCorrespondencia = PFueraNivel.DirCorrespondencia;
            LFueraNivel.Telefono1 = PFueraNivel.Telefono1;
            LFueraNivel.Telefono2 = PFueraNivel.Telefono2;
            LFueraNivel.Telefono3 = PFueraNivel.Telefono3;
            LFueraNivel.Movil1 = PFueraNivel.Movil1;
            LFueraNivel.Movil2 = PFueraNivel.Movil2;
            LFueraNivel.MovilPostpago = PFueraNivel.MovilPostpago;
            LFueraNivel.CorreoActual = PFueraNivel.CorreoActual;
            LFueraNivel.EstratoCliente = PFueraNivel.EstratoCliente;
            LFueraNivel.ServiciosActuales = PFueraNivel.ServiciosActuales;
            LFueraNivel.Nodo = PFueraNivel.Nodo;
            LFueraNivel.NombreComunidad = PFueraNivel.NombreComunidad;
            LFueraNivel.Division = PFueraNivel.Division;
            LFueraNivel.TipoCliente = PFueraNivel.TipoCliente;
            LFueraNivel.DescripcionTPC = PFueraNivel.DescripcionTPC;
            LFueraNivel.Cmts = PFueraNivel.Cmts;
            LFueraNivel.TipoModem = PFueraNivel.TipoModem;
            LFueraNivel.Prioridad = PFueraNivel.Prioridad;
            LFueraNivel.TipoContacto = PFueraNivel.TipoContacto;
            LFueraNivel.Gestion = PFueraNivel.Gestion;
            LFueraNivel.Cierre = PFueraNivel.Cierre;
            LFueraNivel.Razon = PFueraNivel.Razon;
            LFueraNivel.FechaSeguimiento = PFueraNivel.FechaSeguimiento;
            LFueraNivel.Observaciones = PFueraNivel.Observaciones;

            unitWorkLog.GBLFueradeNiveles.Add(LFueraNivel);
            unitWorkLog.Complete();

        }
        public void ActualizarGestionFueraNiveles(GBPFueraNiveles PFueraNivel)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
            UnitOfWorkMaestros unitWorkMaestros = new UnitOfWorkMaestros(new MaestrosContext());

            GBPFueraNiveles PFueraNivelActualizable = unitWork.GBPFueradeNiveles.Find(c => c.CuentaCliente == PFueraNivel.CuentaCliente).FirstOrDefault();

            PFueraNivel.TipoContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(PFueraNivel.TipoContacto)).TipoContacto;
            PFueraNivel.Gestion = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(PFueraNivel.Gestion)).Cierre;
            PFueraNivel.Cierre = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(PFueraNivel.Cierre)).Razon;
            PFueraNivel.Razon = unitWorkMaestros.maestrosOutboundCausa.Get(Convert.ToInt32(PFueraNivel.Razon)).Causa;



            PFueraNivel.FechaGestion = DateTime.Now;

            PFueraNivelActualizable.FechaGestion = PFueraNivel.FechaGestion;
            PFueraNivelActualizable.UsuarioGestion = PFueraNivel.UsuarioGestion;
            PFueraNivelActualizable.AliadoGestion = PFueraNivel.AliadoGestion;
            PFueraNivelActualizable.NombreCliente = PFueraNivel.NombreCliente;
            PFueraNivelActualizable.ApellidoCliente = PFueraNivel.ApellidoCliente;
            PFueraNivelActualizable.DirInstalacion = PFueraNivel.DirInstalacion;
            PFueraNivelActualizable.DirCorrespondencia = PFueraNivel.DirCorrespondencia;
            PFueraNivelActualizable.Telefono1 = PFueraNivel.Telefono1;
            PFueraNivelActualizable.Telefono2 = PFueraNivel.Telefono2;
            PFueraNivelActualizable.Telefono3 = PFueraNivel.Telefono3;
            PFueraNivelActualizable.Movil1 = PFueraNivel.Movil1;
            PFueraNivelActualizable.Movil2 = PFueraNivel.Movil2;
            PFueraNivelActualizable.MovilPostpago = PFueraNivel.MovilPostpago;
            PFueraNivelActualizable.CorreoActual = PFueraNivel.CorreoActual;
            PFueraNivelActualizable.EstratoCliente = PFueraNivel.EstratoCliente;
            PFueraNivelActualizable.ServiciosActuales = PFueraNivel.ServiciosActuales;
            PFueraNivelActualizable.Nodo = PFueraNivel.Nodo;
            PFueraNivelActualizable.NombreComunidad = PFueraNivel.NombreComunidad;
            PFueraNivelActualizable.Division = PFueraNivel.Division;
            PFueraNivelActualizable.TipoCliente = PFueraNivel.TipoCliente;
            PFueraNivelActualizable.DescripcionTPC = PFueraNivel.DescripcionTPC;
            PFueraNivelActualizable.Cmts = PFueraNivel.Cmts;
            PFueraNivelActualizable.TipoModem = PFueraNivel.TipoModem;
            PFueraNivelActualizable.Prioridad = PFueraNivel.Prioridad;
            PFueraNivelActualizable.TipoContacto = PFueraNivel.TipoContacto;
            PFueraNivelActualizable.Gestion = PFueraNivel.Gestion;
            PFueraNivelActualizable.Cierre = PFueraNivel.Cierre;
            PFueraNivelActualizable.Razon = PFueraNivel.Razon;
            PFueraNivelActualizable.FechaSeguimiento = PFueraNivel.FechaSeguimiento;
            PFueraNivelActualizable.Observaciones = PFueraNivel.Observaciones;
            unitWork.Complete();

            GBLFueraNiveles LFueraNivel = new GBLFueraNiveles();

            LFueraNivel.FechaGestion = PFueraNivel.FechaGestion;
            LFueraNivel.UsuarioGestion = PFueraNivel.UsuarioGestion;
            LFueraNivel.AliadoGestion = PFueraNivel.AliadoGestion;
            LFueraNivel.CuentaCliente = PFueraNivel.CuentaCliente;
            LFueraNivel.NombreCliente = PFueraNivel.NombreCliente;
            LFueraNivel.ApellidoCliente = PFueraNivel.ApellidoCliente;
            LFueraNivel.DirInstalacion = PFueraNivel.DirInstalacion;
            LFueraNivel.DirCorrespondencia = PFueraNivel.DirCorrespondencia;
            LFueraNivel.Telefono1 = PFueraNivel.Telefono1;
            LFueraNivel.Telefono2 = PFueraNivel.Telefono2;
            LFueraNivel.Telefono3 = PFueraNivel.Telefono3;
            LFueraNivel.Movil1 = PFueraNivel.Movil1;
            LFueraNivel.Movil2 = PFueraNivel.Movil2;
            LFueraNivel.MovilPostpago = PFueraNivel.MovilPostpago;
            LFueraNivel.CorreoActual = PFueraNivel.CorreoActual;
            LFueraNivel.EstratoCliente = PFueraNivel.EstratoCliente;
            LFueraNivel.ServiciosActuales = PFueraNivel.ServiciosActuales;
            LFueraNivel.Nodo = PFueraNivel.Nodo;
            LFueraNivel.NombreComunidad = PFueraNivel.NombreComunidad;
            LFueraNivel.Division = PFueraNivel.Division;
            LFueraNivel.TipoCliente = PFueraNivel.TipoCliente;
            LFueraNivel.DescripcionTPC = PFueraNivel.DescripcionTPC;
            LFueraNivel.Cmts = PFueraNivel.Cmts;
            LFueraNivel.TipoModem = PFueraNivel.TipoModem;
            LFueraNivel.Prioridad = PFueraNivel.Prioridad;
            LFueraNivel.TipoContacto = PFueraNivel.TipoContacto;
            LFueraNivel.Gestion = PFueraNivel.Gestion;
            LFueraNivel.Cierre = PFueraNivel.Cierre;
            LFueraNivel.Razon = PFueraNivel.Razon;
            LFueraNivel.FechaSeguimiento = PFueraNivel.FechaSeguimiento;
            LFueraNivel.Observaciones = PFueraNivel.Observaciones;

            unitWorkLog.GBLFueradeNiveles.Add(LFueraNivel);
            unitWorkLog.Complete();

        }
        public bool ValidarCuentaEnFueraNiveles(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.GBPFueradeNiveles.Find(c => c.CuentaCliente == CuentaCliente).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public GBPFueraNiveles TraeInformacionActualFueraNiveles(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            GBPFueraNiveles Resultado = unitWork.GBPFueradeNiveles.Find(c => c.CuentaCliente == CuentaCliente).FirstOrDefault();
            return Resultado;
        }
        public List<GBLFueraNiveles> TraeListaGestionUsuarioFueraNiveles(string Usuario)
        {
            DimeContext dimContext = new DimeContext();
            List<GBLFueraNiveles> result = new List<GBLFueraNiveles>();
            var objetosResult = (from a in dimContext.GBLFueradeNiveles
                                 where a.UsuarioGestion.Equals(Usuario)
                                 orderby a.Id descending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.CuentaCliente,
                                     a.NombreCliente,
                                     a.ApellidoCliente,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Razon,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBLFueraNiveles());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NombreCliente = objetosResult[i].NombreCliente;
                result[i].ApellidoCliente = objetosResult[i].ApellidoCliente;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Razon = objetosResult[i].Razon;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public List<GBPFueraNiveles> TraeListaSeguimientosUsuarioFueraNiveles(string Usuario)
        {
            DimeContext dimContext = new DimeContext();
            List<GBPFueraNiveles> result = new List<GBPFueraNiveles>();
            var objetosResult = (from a in dimContext.GBPFueradeNiveles
                                 where a.UsuarioGestion.Equals(Usuario) && a.Cierre.Equals("SEGUIMIENTO")
                                 orderby a.Id descending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.CuentaCliente,
                                     a.NombreCliente,
                                     a.ApellidoCliente,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Razon,
                                     a.FechaSeguimiento,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBPFueraNiveles());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NombreCliente = objetosResult[i].NombreCliente;
                result[i].ApellidoCliente = objetosResult[i].ApellidoCliente;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Razon = objetosResult[i].Razon;
                result[i].FechaSeguimiento = objetosResult[i].FechaSeguimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
      
        public GBPFueraNiveles TraerDatosCuentaSelectFueraNivel(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.GBPFueradeNiveles.Find(c => c.CuentaCliente == CuentaCliente).FirstOrDefault();

        }
        public int CantidadToquesCuentaFueraNiveles(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
           int Cantidad = unitWork.GBLFueradeNiveles.Find(c => c.CuentaCliente == CuentaCliente).Count();
            if (Cantidad > 0) {
                return Cantidad;
            }
            else {
                return 0; }
        }
        public GBLFueraNiveles TraeUltimaGestionCuenta(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            List<GBLFueraNiveles> Registros = unitWork.GBLFueradeNiveles.Find(c => c.CuentaCliente == CuentaCliente).ToList();
            
            if (Registros.Count()>0)
            {
                decimal MaxId = Registros.Max(c => c.Id);
                return unitWork.GBLFueradeNiveles.Get(Convert.ToInt32(MaxId));
            }else
            {   
            return null;}

        }
        public List<GBPFueraNiveles> ConsultaAdminFueraNivelesP(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<GBPFueraNiveles> result = new List<GBPFueraNiveles>();
            var objetosResult = (from a in dimContext.GBPFueradeNiveles
                                where a.FechaGestion>= FechaInicial && a.FechaGestion<= FechaFinal
                                 orderby a.Id ascending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     a.AliadoGestion,
                                     a.CuentaCliente,
                                     a.NombreCliente,
                                     a.ApellidoCliente,
                                     a.DirInstalacion,
                                     a.DirCorrespondencia,
                                     a.Telefono1,
                                     a.Telefono2,
                                     a.Telefono3,
                                     a.Movil1,
                                     a.Movil2,
                                     a.MovilPostpago,
                                     a.CorreoActual,
                                     a.EstratoCliente,
                                     a.ServiciosActuales,
                                     a.Nodo,
                                     a.NombreComunidad,
                                     a.Division,
                                     a.TipoCliente,
                                     a.DescripcionTPC,
                                     a.Cmts,
                                     a.TipoModem,
                                     a.Prioridad,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Razon,
                                     a.FechaSeguimiento,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBPFueraNiveles());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NombreCliente = objetosResult[i].NombreCliente;
                result[i].ApellidoCliente = objetosResult[i].ApellidoCliente;
                result[i].DirInstalacion = objetosResult[i].DirInstalacion;
                result[i].DirCorrespondencia = objetosResult[i].DirCorrespondencia;
                result[i].Telefono1 = objetosResult[i].Telefono1;
                result[i].Telefono2 = objetosResult[i].Telefono2;
                result[i].Telefono3 = objetosResult[i].Telefono3;
                result[i].Movil1 = objetosResult[i].Movil1;
                result[i].Movil2 = objetosResult[i].Movil2;
                result[i].MovilPostpago = objetosResult[i].MovilPostpago;
                result[i].CorreoActual = objetosResult[i].CorreoActual;
                result[i].EstratoCliente = objetosResult[i].EstratoCliente;
                result[i].ServiciosActuales = objetosResult[i].ServiciosActuales;
                result[i].Nodo = objetosResult[i].Nodo;
                result[i].NombreComunidad = objetosResult[i].NombreComunidad;
                result[i].Division = objetosResult[i].Division;
                result[i].TipoCliente = objetosResult[i].TipoCliente;
                result[i].DescripcionTPC = objetosResult[i].DescripcionTPC;
                result[i].Cmts = objetosResult[i].Cmts;
                result[i].TipoModem = objetosResult[i].TipoModem;
                result[i].Prioridad = objetosResult[i].Prioridad;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Razon = objetosResult[i].Razon;
                result[i].FechaSeguimiento = objetosResult[i].FechaSeguimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public List<GBLFueraNiveles> ConsultaAdminFueraNivelesL(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<GBLFueraNiveles> result = new List<GBLFueraNiveles>();
            var objetosResult = (from a in dimContext.GBLFueradeNiveles
                                 where a.FechaGestion >= FechaInicial && a.FechaGestion <= FechaFinal
                                 orderby a.Id ascending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     a.AliadoGestion,
                                     a.CuentaCliente,
                                     a.NombreCliente,
                                     a.ApellidoCliente,
                                     a.DirInstalacion,
                                     a.DirCorrespondencia,
                                     a.Telefono1,
                                     a.Telefono2,
                                     a.Telefono3,
                                     a.Movil1,
                                     a.Movil2,
                                     a.MovilPostpago,
                                     a.CorreoActual,
                                     a.EstratoCliente,
                                     a.ServiciosActuales,
                                     a.Nodo,
                                     a.NombreComunidad,
                                     a.Division,
                                     a.TipoCliente,
                                     a.DescripcionTPC,
                                     a.Cmts,
                                     a.TipoModem,
                                     a.Prioridad,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Razon,
                                     a.FechaSeguimiento,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBLFueraNiveles());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NombreCliente = objetosResult[i].NombreCliente;
                result[i].ApellidoCliente = objetosResult[i].ApellidoCliente;
                result[i].DirInstalacion = objetosResult[i].DirInstalacion;
                result[i].DirCorrespondencia = objetosResult[i].DirCorrespondencia;
                result[i].Telefono1 = objetosResult[i].Telefono1;
                result[i].Telefono2 = objetosResult[i].Telefono2;
                result[i].Telefono3 = objetosResult[i].Telefono3;
                result[i].Movil1 = objetosResult[i].Movil1;
                result[i].Movil2 = objetosResult[i].Movil2;
                result[i].MovilPostpago = objetosResult[i].MovilPostpago;
                result[i].CorreoActual = objetosResult[i].CorreoActual;
                result[i].EstratoCliente = objetosResult[i].EstratoCliente;
                result[i].ServiciosActuales = objetosResult[i].ServiciosActuales;
                result[i].Nodo = objetosResult[i].Nodo;
                result[i].NombreComunidad = objetosResult[i].NombreComunidad;
                result[i].Division = objetosResult[i].Division;
                result[i].TipoCliente = objetosResult[i].TipoCliente;
                result[i].DescripcionTPC = objetosResult[i].DescripcionTPC;
                result[i].Cmts = objetosResult[i].Cmts;
                result[i].TipoModem = objetosResult[i].TipoModem;
                result[i].Prioridad = objetosResult[i].Prioridad;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Razon = objetosResult[i].Razon;
                result[i].FechaSeguimiento = objetosResult[i].FechaSeguimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }

        //GESTION BLENDING RENTABILIZACION
        public GBC_Rentabilizacion TraerInformacionCuentaRentabilizacion(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.GBCRentabilizacion.Find(c => c.CuentaCiente == CuentaCliente).FirstOrDefault();
        }
        public void InsertarRegistroRentabilizacion(GBPRentabilizacion PRentabilizacion)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
            UnitOfWorkMaestros unitWorkMaestros = new UnitOfWorkMaestros(new MaestrosContext());

            PRentabilizacion.TipoContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(PRentabilizacion.TipoContacto)).TipoContacto;
            PRentabilizacion.Gestion = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(PRentabilizacion.Gestion)).Cierre;
            PRentabilizacion.Cierre = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(PRentabilizacion.Cierre)).Razon;
            PRentabilizacion.Causa = unitWorkMaestros.maestrosOutboundCausa.Get(Convert.ToInt32(PRentabilizacion.Causa)).Causa;
            PRentabilizacion.Motivo = unitWorkMaestros.maestrosOutboundMotivo.Get(Convert.ToInt32(PRentabilizacion.Motivo)).Motivo;

            PRentabilizacion.FechaGestion = DateTime.Now;
            unitWork.GBPRentabilizacion.Add(PRentabilizacion);
            unitWork.Complete();
            
            GBLRentabilizacion LRentabilizacion = new GBLRentabilizacion();

            LRentabilizacion.FechaGestion = PRentabilizacion.FechaGestion;
            LRentabilizacion.UsuarioGestion = PRentabilizacion.UsuarioGestion;
            LRentabilizacion.AliadoGestion = PRentabilizacion.AliadoGestion;
            LRentabilizacion.OperacionGestion = PRentabilizacion.OperacionGestion;
            LRentabilizacion.CuentaCliente = PRentabilizacion.CuentaCliente;
            LRentabilizacion.ConsumosPpv = PRentabilizacion.ConsumosPpv;
            LRentabilizacion.UltimaPpv = PRentabilizacion.UltimaPpv;
            LRentabilizacion.SiembraHd = PRentabilizacion.SiembraHd;
            LRentabilizacion.SiembraVoz = PRentabilizacion.SiembraVoz;
            LRentabilizacion.BlindajeInternet = PRentabilizacion.BlindajeInternet;
            LRentabilizacion.UltimaMarcacion = PRentabilizacion.UltimaMarcacion;
            LRentabilizacion.OfrecimientoAceptado = PRentabilizacion.OfrecimientoAceptado;
            LRentabilizacion.TipoContacto = PRentabilizacion.TipoContacto;
            LRentabilizacion.Gestion = PRentabilizacion.Gestion;
            LRentabilizacion.Cierre = PRentabilizacion.Cierre;
            LRentabilizacion.Causa = PRentabilizacion.Causa;
            LRentabilizacion.Motivo = PRentabilizacion.Motivo;
            LRentabilizacion.FechaSeguimiento = PRentabilizacion.FechaSeguimiento;
            LRentabilizacion.Observaciones = PRentabilizacion.Observaciones;

            unitWorkLog.GBLRentabilizacion.Add(LRentabilizacion);
            unitWorkLog.Complete();

        }
        public void ActualizarGestionRentabilizacion(GBPRentabilizacion PRentabilizacion)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
            UnitOfWorkMaestros unitWorkMaestros = new UnitOfWorkMaestros(new MaestrosContext());

            GBPRentabilizacion PRentabilizacionActualizable = unitWork.GBPRentabilizacion.Find(c => c.CuentaCliente == PRentabilizacion.CuentaCliente).FirstOrDefault();

            PRentabilizacion.TipoContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(PRentabilizacion.TipoContacto)).TipoContacto;
            PRentabilizacion.Gestion = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(PRentabilizacion.Gestion)).Cierre;
            PRentabilizacion.Cierre = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(PRentabilizacion.Cierre)).Razon;
            PRentabilizacion.Causa = unitWorkMaestros.maestrosOutboundCausa.Get(Convert.ToInt32(PRentabilizacion.Causa)).Causa;
            PRentabilizacion.Motivo = unitWorkMaestros.maestrosOutboundMotivo.Get(Convert.ToInt32(PRentabilizacion.Motivo)).Motivo;



            PRentabilizacion.FechaGestion = DateTime.Now;

            PRentabilizacionActualizable.FechaGestion = PRentabilizacion.FechaGestion;
            PRentabilizacionActualizable.UsuarioGestion = PRentabilizacion.UsuarioGestion;
            PRentabilizacionActualizable.AliadoGestion = PRentabilizacion.AliadoGestion;
            PRentabilizacionActualizable.OperacionGestion = PRentabilizacion.OperacionGestion;
            PRentabilizacionActualizable.CuentaCliente = PRentabilizacion.CuentaCliente;
            PRentabilizacionActualizable.ConsumosPpv = PRentabilizacion.ConsumosPpv;
            PRentabilizacionActualizable.UltimaPpv = PRentabilizacion.UltimaPpv;
            PRentabilizacionActualizable.SiembraHd = PRentabilizacion.SiembraHd;
            PRentabilizacionActualizable.SiembraVoz = PRentabilizacion.SiembraVoz;
            PRentabilizacionActualizable.BlindajeInternet = PRentabilizacion.BlindajeInternet;
            PRentabilizacionActualizable.UltimaMarcacion = PRentabilizacion.UltimaMarcacion;
            PRentabilizacionActualizable.OfrecimientoAceptado = PRentabilizacion.OfrecimientoAceptado;
            PRentabilizacionActualizable.TipoContacto = PRentabilizacion.TipoContacto;
            PRentabilizacionActualizable.Gestion = PRentabilizacion.Gestion;
            PRentabilizacionActualizable.Cierre = PRentabilizacion.Cierre;
            PRentabilizacionActualizable.Causa = PRentabilizacion.Causa;
            PRentabilizacionActualizable.Motivo = PRentabilizacion.Motivo;
            PRentabilizacionActualizable.FechaSeguimiento = PRentabilizacion.FechaSeguimiento;
            PRentabilizacionActualizable.Observaciones = PRentabilizacion.Observaciones;

            unitWork.Complete();

            GBLRentabilizacion LRentabilizacion = new GBLRentabilizacion();

            LRentabilizacion.FechaGestion = PRentabilizacion.FechaGestion;
            LRentabilizacion.UsuarioGestion = PRentabilizacion.UsuarioGestion;
            LRentabilizacion.AliadoGestion = PRentabilizacion.AliadoGestion;
            LRentabilizacion.OperacionGestion = PRentabilizacion.OperacionGestion;
            LRentabilizacion.CuentaCliente = PRentabilizacion.CuentaCliente;
            LRentabilizacion.ConsumosPpv = PRentabilizacion.ConsumosPpv;
            LRentabilizacion.UltimaPpv = PRentabilizacion.UltimaPpv;
            LRentabilizacion.SiembraHd = PRentabilizacion.SiembraHd;
            LRentabilizacion.SiembraVoz = PRentabilizacion.SiembraVoz;
            LRentabilizacion.BlindajeInternet = PRentabilizacion.BlindajeInternet;
            LRentabilizacion.UltimaMarcacion = PRentabilizacion.UltimaMarcacion;
            LRentabilizacion.OfrecimientoAceptado = PRentabilizacion.OfrecimientoAceptado;
            LRentabilizacion.TipoContacto = PRentabilizacion.TipoContacto;
            LRentabilizacion.Gestion = PRentabilizacion.Gestion;
            LRentabilizacion.Cierre = PRentabilizacion.Cierre;
            LRentabilizacion.Causa = PRentabilizacion.Causa;
            LRentabilizacion.Motivo = PRentabilizacion.Motivo;
            LRentabilizacion.FechaSeguimiento = PRentabilizacion.FechaSeguimiento;
            LRentabilizacion.Observaciones = PRentabilizacion.Observaciones;

            unitWorkLog.GBLRentabilizacion.Add(LRentabilizacion);
            unitWorkLog.Complete();

        }
        public bool ValidarCuentaEnRentabilizacion(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.GBPRentabilizacion.Find(c => c.CuentaCliente == CuentaCliente).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public GBPRentabilizacion TraeInformacionActualRentabilizacion(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            GBPRentabilizacion Resultado = unitWork.GBPRentabilizacion.Find(c => c.CuentaCliente == CuentaCliente).FirstOrDefault();
            return Resultado;
        }
        public List<GBLRentabilizacion> TraeListaGestionUsuarioRentabilizacion(string Usuario)
        {
            DimeContext dimContext = new DimeContext();
            List<GBLRentabilizacion> result = new List<GBLRentabilizacion>();
            var objetosResult = (from a in dimContext.GBLRentabilizacion
                                 where a.UsuarioGestion.Equals(Usuario)
                                 orderby a.Id descending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.CuentaCliente,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Causa,
                                     a.Motivo,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBLRentabilizacion());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Causa = objetosResult[i].Causa;
                result[i].Motivo = objetosResult[i].Motivo;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public List<GBPRentabilizacion> TraeListaSeguimientosUsuarioRentabilizacion(string Usuario)
        {
            DimeContext dimContext = new DimeContext();
            List<GBPRentabilizacion> result = new List<GBPRentabilizacion>();
            var objetosResult = (from a in dimContext.GBPRentabilizacion
                                 where a.UsuarioGestion.Equals(Usuario) && a.Cierre.Equals("SEGUIMIENTO")
                                 orderby a.Id descending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.CuentaCliente,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Causa,
                                     a.Motivo,
                                     a.FechaSeguimiento,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBPRentabilizacion());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Causa = objetosResult[i].Causa;
                result[i].Motivo = objetosResult[i].Motivo;
                result[i].FechaSeguimiento = objetosResult[i].FechaSeguimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public GBPRentabilizacion TraerDatosCuentaSelectRentabilizacion(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.GBPRentabilizacion.Find(c => c.CuentaCliente == CuentaCliente).FirstOrDefault();

        }
        public int CantidadToquesCuentaRentabilizacion(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            int Cantidad = unitWork.GBPRentabilizacion.Find(c => c.CuentaCliente == CuentaCliente).Count();
            if (Cantidad > 0)
            {
                return Cantidad;
            }
            else
            {
                return 0;
            }
        }
        public GBLRentabilizacion TraeUltimaGestionCuentaRentabilizacion(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            List<GBLRentabilizacion> Registros = unitWork.GBLRentabilizacion.Find(c => c.CuentaCliente == CuentaCliente).ToList();

            if (Registros.Count() > 0)
            {
                decimal MaxId = Registros.Max(c => c.Id);
                return unitWork.GBLRentabilizacion.Get(Convert.ToInt32(MaxId));
            }
            else
            {
                return null;
            }

        }
        public List<GBPRentabilizacion> ConsultaAdminRentabilizacionP(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<GBPRentabilizacion> result = new List<GBPRentabilizacion>();
            var objetosResult = (from a in dimContext.GBPRentabilizacion
                                 where a.FechaGestion >= FechaInicial && a.FechaGestion <= FechaFinal
                                 orderby a.Id ascending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     a.AliadoGestion,
                                     a.OperacionGestion,
                                     a.CuentaCliente,
                                     a.ConsumosPpv,
                                     a.UltimaPpv,
                                     a.SiembraHd,
                                     a.SiembraVoz,
                                     a.BlindajeInternet,
                                     a.UltimaMarcacion,
                                     a.OfrecimientoAceptado,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Causa,
                                     a.Motivo,
                                     a.FechaSeguimiento,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBPRentabilizacion());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].OperacionGestion = objetosResult[i].OperacionGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].ConsumosPpv = objetosResult[i].ConsumosPpv;
                result[i].UltimaPpv = objetosResult[i].UltimaPpv;
                result[i].SiembraHd = objetosResult[i].SiembraHd;
                result[i].SiembraVoz = objetosResult[i].SiembraVoz;
                result[i].BlindajeInternet = objetosResult[i].BlindajeInternet;
                result[i].UltimaMarcacion = objetosResult[i].UltimaMarcacion;
                result[i].OfrecimientoAceptado = objetosResult[i].OfrecimientoAceptado;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Causa = objetosResult[i].Causa;
                result[i].Motivo = objetosResult[i].Motivo;
                result[i].FechaSeguimiento = objetosResult[i].FechaSeguimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public List<GBLRentabilizacion> ConsultaAdminRentabilizacionL(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<GBLRentabilizacion> result = new List<GBLRentabilizacion>();
            var objetosResult = (from a in dimContext.GBLRentabilizacion
                                 where a.FechaGestion >= FechaInicial && a.FechaGestion <= FechaFinal
                                 orderby a.Id ascending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     a.AliadoGestion,
                                     a.OperacionGestion,
                                     a.CuentaCliente,
                                     a.ConsumosPpv,
                                     a.UltimaPpv,
                                     a.SiembraHd,
                                     a.SiembraVoz,
                                     a.BlindajeInternet,
                                     a.UltimaMarcacion,
                                     a.OfrecimientoAceptado,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Causa,
                                     a.Motivo,
                                     a.FechaSeguimiento,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBLRentabilizacion());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].OperacionGestion = objetosResult[i].OperacionGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].ConsumosPpv = objetosResult[i].ConsumosPpv;
                result[i].UltimaPpv = objetosResult[i].UltimaPpv;
                result[i].SiembraHd = objetosResult[i].SiembraHd;
                result[i].SiembraVoz = objetosResult[i].SiembraVoz;
                result[i].BlindajeInternet = objetosResult[i].BlindajeInternet;
                result[i].UltimaMarcacion = objetosResult[i].UltimaMarcacion;
                result[i].OfrecimientoAceptado = objetosResult[i].OfrecimientoAceptado;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Causa = objetosResult[i].Causa;
                result[i].Motivo = objetosResult[i].Motivo;
                result[i].FechaSeguimiento = objetosResult[i].FechaSeguimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }

    }
}
