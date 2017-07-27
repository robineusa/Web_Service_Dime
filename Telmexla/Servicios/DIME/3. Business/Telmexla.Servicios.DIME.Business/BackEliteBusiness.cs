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
    public class BackEliteBusiness
    {
        public void RegistrarSolicitud(BEPSolicitudes Solicitud)
        {
            //trae la informacion de los procesos y las listas seleccionadas
            UnitOfWork UnitOfWorkProceso = new UnitOfWork(new DimeContext());
            Solicitud.TipoDeSolicitud = UnitOfWorkProceso.BEMTipoDeEscalamientos.Get(Convert.ToInt32(Solicitud.TipoDeSolicitud)).TipoEscalamiento;
            Solicitud.DetalleDeSolicitud = UnitOfWorkProceso.BEMDetalleEscalamientos.Get(Convert.ToInt32(Solicitud.DetalleDeSolicitud)).DetalleEscalamiento;
            //Solicitud.DetalleMalEscalado = UnitOfWorkProceso.BEMRazonMalEscalamiento.Get(Convert.ToInt32(Solicitud.DetalleMalEscalado)).NombreRazonEscalamiento;
            //Solicitud.Gestion = UnitOfWorkProceso.BEMDetalleDeGestion.Get(Convert.ToInt32(Solicitud.Gestion)).NombreGestion;
            UnitOfWorkProceso.Complete();
            UnitOfWorkProceso.Dispose();

            //inserta solicitud a la tabla principal
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            Solicitud.FechaDeSolicitud = DateTime.Now;
            Solicitud.FechaUltimaActualizacion = Solicitud.FechaDeSolicitud;
            Solicitud.UsuarioUltimaActualizacion = Solicitud.UsuarioQueSolicita;
            Solicitud.NombreUsuarioUltimaActualizacion = Solicitud.NombreUsuarioQueSolicita;
            Solicitud.EstadoEscalamiento = "PENDIENTE";
            Solicitud.UsuarioGestionando = 0;
            Solicitud.Gestion = "SOLICITUD INICIAL";

            UnitOfWork.BEPSolicitudes.Add(Solicitud);
            UnitOfWork.Complete();
            UnitOfWork.Dispose();

            //inserta solicitud en la tabla del log
            UnitOfWork UnitOfWorkLog = new UnitOfWork(new DimeContext());
            BELSolicitudes SolcitudLog = new BELSolicitudes();

            SolcitudLog.IdSolicitud = Solicitud.IdSolicitud;
            SolcitudLog.CuentaCliente = Solicitud.CuentaCliente;
            SolcitudLog.LlsOt = Solicitud.LlsOt;
            SolcitudLog.TipoDeSolicitud = Solicitud.TipoDeSolicitud;
            SolcitudLog.FechaDeSolicitud = Solicitud.FechaDeSolicitud;
            SolcitudLog.UsuarioQueSolicita = Solicitud.UsuarioQueSolicita;
            SolcitudLog.NombreUsuarioQueSolicita = Solicitud.NombreUsuarioQueSolicita;
            SolcitudLog.AliadoQueSolicita = Solicitud.AliadoQueSolicita;
            SolcitudLog.FechaUltimaActualizacion = Solicitud.FechaUltimaActualizacion;
            SolcitudLog.UsuarioUltimaActualizacion = Solicitud.UsuarioUltimaActualizacion;
            SolcitudLog.NombreUsuarioUltimaActualizacion = Solicitud.NombreUsuarioUltimaActualizacion;
            SolcitudLog.FechaDeFinalizacion = Solicitud.FechaDeFinalizacion;
            SolcitudLog.UsuarioQueFinaliza = Solicitud.UsuarioQueFinaliza;
            SolcitudLog.NombreUsuarioQueFinaliza = Solicitud.NombreUsuarioQueFinaliza;
            SolcitudLog.Nodo = Solicitud.Nodo;
            SolcitudLog.Malescalado = Solicitud.Malescalado;
            SolcitudLog.DetalleMalEscalado = Solicitud.DetalleMalEscalado;
            SolcitudLog.Gestion = Solicitud.Gestion;
            SolcitudLog.EstadoEscalamiento = Solicitud.EstadoEscalamiento;
            SolcitudLog.FechaDeAgenda = Solicitud.FechaDeAgenda;
            SolcitudLog.Observaciones = Solicitud.Observaciones;

            UnitOfWorkLog.BELSolicitudes.Add(SolcitudLog);
            UnitOfWorkLog.Complete();
            UnitOfWorkLog.Dispose();
        }
        public void ActualizaSolicitud(BEPSolicitudes Solicitud)
        {
            //trae la informacion de los procesos y las listas seleccionadas
            UnitOfWork UnitOfWorkProceso = new UnitOfWork(new DimeContext());
            Solicitud.TipoDeSolicitud = UnitOfWorkProceso.BEMTipoDeEscalamientos.Get(Convert.ToInt32(Solicitud.TipoDeSolicitud)).TipoEscalamiento;
            Solicitud.DetalleDeSolicitud = UnitOfWorkProceso.BEMDetalleEscalamientos.Get(Convert.ToInt32(Solicitud.DetalleDeSolicitud)).DetalleEscalamiento;
            Solicitud.DetalleMalEscalado = UnitOfWorkProceso.BEMRazonMalEscalamiento.Get(Convert.ToInt32(Solicitud.DetalleMalEscalado)).NombreRazonEscalamiento;
            Solicitud.Gestion = UnitOfWorkProceso.BEMDetalleDeGestion.Get(Convert.ToInt32(Solicitud.Gestion)).NombreGestion;
            UnitOfWorkProceso.Complete();
            UnitOfWorkProceso.Dispose();

            //busca solicitud para actualizar
            UnitOfWork UnitOfWorkSolicitdActualizable = new UnitOfWork(new DimeContext());
            BEPSolicitudes SolicitdActualizable = UnitOfWorkSolicitdActualizable.BEPSolicitudes.Find(c => c.IdSolicitud == Solicitud.IdSolicitud).FirstOrDefault();
            Solicitud.FechaDeSolicitud = DateTime.Now;
            Solicitud.FechaUltimaActualizacion = Solicitud.FechaDeSolicitud;
            Solicitud.UsuarioUltimaActualizacion = Solicitud.UsuarioQueSolicita;
            Solicitud.NombreUsuarioUltimaActualizacion = Solicitud.NombreUsuarioQueSolicita;
            
            SolicitdActualizable.FechaUltimaActualizacion = Solicitud.FechaUltimaActualizacion;
            SolicitdActualizable.UsuarioUltimaActualizacion = Solicitud.UsuarioUltimaActualizacion;
            SolicitdActualizable.NombreUsuarioUltimaActualizacion = Solicitud.NombreUsuarioUltimaActualizacion;
            SolicitdActualizable.Malescalado = Solicitud.Malescalado;
            SolicitdActualizable.DetalleMalEscalado = Solicitud.DetalleMalEscalado;
            SolicitdActualizable.Gestion = Solicitud.Gestion;
            SolicitdActualizable.EstadoEscalamiento = Solicitud.EstadoEscalamiento;
            SolicitdActualizable.FechaDeAgenda = Solicitud.FechaDeAgenda;
            SolicitdActualizable.Observaciones = Solicitud.Observaciones;
            SolicitdActualizable.UsuarioGestionando = Solicitud.UsuarioGestionando;

            if (Solicitud.EstadoEscalamiento == "FINALIZADO")
            {
                SolicitdActualizable.FechaDeFinalizacion = Solicitud.FechaDeSolicitud;
                SolicitdActualizable.UsuarioQueFinaliza = Solicitud.UsuarioQueSolicita;
                SolicitdActualizable.NombreUsuarioQueFinaliza = Solicitud.NombreUsuarioQueSolicita;
            }

            UnitOfWorkSolicitdActualizable.Complete();
            UnitOfWorkSolicitdActualizable.Dispose();

            //inserta solicitud en la tabla del log
            UnitOfWork UnitOfWorkLog = new UnitOfWork(new DimeContext());
            BELSolicitudes SolcitudLog = new BELSolicitudes();

            SolcitudLog.IdSolicitud = SolicitdActualizable.IdSolicitud;
            SolcitudLog.CuentaCliente = SolicitdActualizable.CuentaCliente;
            SolcitudLog.LlsOt = SolicitdActualizable.LlsOt;
            SolcitudLog.TipoDeSolicitud = SolicitdActualizable.TipoDeSolicitud;
            SolcitudLog.FechaDeSolicitud = SolicitdActualizable.FechaDeSolicitud;
            SolcitudLog.UsuarioQueSolicita = SolicitdActualizable.UsuarioQueSolicita;
            SolcitudLog.NombreUsuarioQueSolicita = SolicitdActualizable.NombreUsuarioQueSolicita;
            SolcitudLog.AliadoQueSolicita = SolicitdActualizable.AliadoQueSolicita;
            SolcitudLog.FechaUltimaActualizacion = SolicitdActualizable.FechaUltimaActualizacion;
            SolcitudLog.UsuarioUltimaActualizacion = SolicitdActualizable.UsuarioUltimaActualizacion;
            SolcitudLog.NombreUsuarioUltimaActualizacion = SolicitdActualizable.NombreUsuarioUltimaActualizacion;
            SolcitudLog.FechaDeFinalizacion = SolicitdActualizable.FechaDeFinalizacion;
            SolcitudLog.UsuarioQueFinaliza = SolicitdActualizable.UsuarioQueFinaliza;
            SolcitudLog.NombreUsuarioQueFinaliza = SolicitdActualizable.NombreUsuarioQueFinaliza;
            SolcitudLog.Nodo = SolicitdActualizable.Nodo;
            SolcitudLog.Malescalado = SolicitdActualizable.Malescalado;
            SolcitudLog.DetalleMalEscalado = SolicitdActualizable.DetalleMalEscalado;
            SolcitudLog.Gestion = SolicitdActualizable.Gestion;
            SolcitudLog.EstadoEscalamiento = SolicitdActualizable.EstadoEscalamiento;
            SolcitudLog.FechaDeAgenda = SolicitdActualizable.FechaDeAgenda;
            SolcitudLog.Observaciones = SolicitdActualizable.Observaciones;

            UnitOfWorkLog.BELSolicitudes.Add(SolcitudLog);
            UnitOfWorkLog.Complete();
            UnitOfWorkLog.Dispose();

        }
        public List<BEMTipoDeEscalamientos> ListaTipoDeEscalamientos()
        {
            DimeContext dimContext = new DimeContext();
            List<BEMTipoDeEscalamientos> result = new List<BEMTipoDeEscalamientos>();
            var objetosResult = (from a in dimContext.BEMTipoDeEscalamientos
                                 where a.Estado.Equals("ACTIVO")
                                 orderby a.TipoEscalamiento ascending
                                 select new
                                 {
                                     a.IdTipo,
                                     a.TipoEscalamiento
                                     
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BEMTipoDeEscalamientos());
                result[i].IdTipo = objetosResult[i].IdTipo;
                result[i].TipoEscalamiento = objetosResult[i].TipoEscalamiento;
                
            }
            return result;
        }
        public List<BEMDetalleEscalamientos> ListaDetalleDeEscalamientos(decimal IdTipo)
        {
            DimeContext dimContext = new DimeContext();
            List<BEMDetalleEscalamientos> result = new List<BEMDetalleEscalamientos>();
            var objetosResult = (from a in dimContext.BEMDetalleEscalamientos
                                 where a.Estado.Equals("ACTIVO") && a.IdTipo.Equals(IdTipo)
                                 orderby a.DetalleEscalamiento ascending
                                 select new
                                 {
                                     a.IdDetalle,
                                     a.DetalleEscalamiento

                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BEMDetalleEscalamientos());
                result[i].IdDetalle = objetosResult[i].IdDetalle;
                result[i].DetalleEscalamiento = objetosResult[i].DetalleEscalamiento;

            }
            return result;
        }
        public List<BEMRazonMalEscalamiento> ListaRazonesMalEscalamiento(decimal IdTipo)
        {
            DimeContext dimContext = new DimeContext();
            List<BEMRazonMalEscalamiento> result = new List<BEMRazonMalEscalamiento>();
            var objetosResult = (from a in dimContext.BEMRazonMalEscalamiento
                                 where a.Estado.Equals("ACTIVO") && a.IdTipo.Equals(IdTipo)
                                 orderby a.NombreRazonEscalamiento ascending
                                 select new
                                 {
                                     a.Id,
                                     a.NombreRazonEscalamiento

                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BEMRazonMalEscalamiento());
                result[i].Id = objetosResult[i].Id;
                result[i].NombreRazonEscalamiento = objetosResult[i].NombreRazonEscalamiento;

            }
            return result;
        }
        public List<BEMDetalleDeGestion> ListaDetallesDeGestion(decimal IdTipo)
        {
            DimeContext dimContext = new DimeContext();
            List<BEMDetalleDeGestion> result = new List<BEMDetalleDeGestion>();
            var objetosResult = (from a in dimContext.BEMDetalleDeGestion
                                 where a.Estado.Equals("ACTIVO") && a.IdTipo.Equals(IdTipo)
                                 orderby a.NombreGestion ascending
                                 select new
                                 {
                                     a.IdGestion,
                                     a.NombreGestion

                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BEMDetalleDeGestion());
                result[i].IdGestion = objetosResult[i].IdGestion;
                result[i].NombreGestion = objetosResult[i].NombreGestion;

            }
            return result;
        }
        public BEMDetalleDeGestion DetalleGestionPorId(decimal IdGestion)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BEMDetalleDeGestion gestion = unitWork.BEMDetalleDeGestion.Find(c => c.IdGestion == IdGestion).FirstOrDefault();
            return gestion;
        }
        public bool ValidarCuentaEnBackElite(decimal CuentaCliente, decimal Ot)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.BEPSolicitudes.Find(c => c.CuentaCliente == CuentaCliente && c.LlsOt == Ot).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public BEPSolicitudes ConsultarSolicitudPorId(decimal IdSolicitud)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BEPSolicitudes solicitud = unitWork.BEPSolicitudes.Find(c => c.IdSolicitud == IdSolicitud).FirstOrDefault();
            return solicitud;
        }
        public BEPSolicitudes ApartarCuentadeSolcitudBackElita(decimal Cedula, string TipoTrabajo,int noRecursividad)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            List < decimal > solicitud = unitWork.BEPSolicitudes.Find(c => c.UsuarioGestionando == Cedula).Select(x => x.IdSolicitud).ToList();
            if (solicitud.Count >0) {
                BEPSolicitudes solicitudencontrada = new BEPSolicitudes();
                return ConsultarSolicitudPorId(solicitud[0]);
            } else {
                unitWork.BEPSolicitudes.ApartarCuentaGestionBackElite(Cedula, TipoTrabajo);
                noRecursividad++;
                if (noRecursividad > 1) return null;
                return ApartarCuentadeSolcitudBackElita(Cedula, TipoTrabajo, noRecursividad);
            }
        }
    }
}

