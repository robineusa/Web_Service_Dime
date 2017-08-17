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
            SolcitudLog.DetalleDeSolicitud = Solicitud.DetalleDeSolicitud;
            SolcitudLog.FechaDeSolicitud = Solicitud.FechaDeSolicitud;
            SolcitudLog.UsuarioQueSolicita = Solicitud.UsuarioQueSolicita;
            SolcitudLog.NombreUsuarioQueSolicita = Solicitud.NombreUsuarioQueSolicita;
            SolcitudLog.AliadoQueSolicita = Solicitud.AliadoQueSolicita;
            SolcitudLog.OperacionQueSolicita = Solicitud.OperacionQueSolicita;
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
            if (Solicitud.DetalleMalEscalado.Length > 3) { }
            else
            {
                if (Solicitud.DetalleMalEscalado == "NO APLICA") { }
                else
                {
                    Solicitud.DetalleMalEscalado = UnitOfWorkProceso.BEMRazonMalEscalamiento.Get(Convert.ToInt32(Solicitud.DetalleMalEscalado)).NombreRazonEscalamiento;
                }
            }
            Solicitud.Gestion = UnitOfWorkProceso.BEMDetalleDeGestion.Get(Convert.ToInt32(Solicitud.Gestion)).NombreGestion;
            UnitOfWorkProceso.Complete();
            UnitOfWorkProceso.Dispose();

            //busca solicitud para actualizar
            UnitOfWork UnitOfWorkSolicitdActualizable = new UnitOfWork(new DimeContext());
            BEPSolicitudes SolicitdActualizable = UnitOfWorkSolicitdActualizable.BEPSolicitudes.Find(c => c.IdSolicitud == Solicitud.IdSolicitud).FirstOrDefault();
            DateTime Fecha = DateTime.Now;
            SolicitdActualizable.FechaUltimaActualizacion = Fecha;
            SolicitdActualizable.UsuarioUltimaActualizacion = Solicitud.UsuarioQueSolicita;
            SolicitdActualizable.NombreUsuarioUltimaActualizacion = Solicitud.NombreUsuarioQueSolicita;
            SolicitdActualizable.Malescalado = Solicitud.Malescalado;
            SolicitdActualizable.DetalleMalEscalado = Solicitud.DetalleMalEscalado;
            SolicitdActualizable.Gestion = Solicitud.Gestion;
            SolicitdActualizable.EstadoEscalamiento = Solicitud.EstadoEscalamiento;
            SolicitdActualizable.FechaDeAgenda = Solicitud.FechaDeAgenda;
            SolicitdActualizable.Observaciones = Solicitud.Observaciones;
            SolicitdActualizable.UsuarioGestionando = Solicitud.UsuarioGestionando;

            if (Solicitud.EstadoEscalamiento == "FINALIZADO")
            {
                SolicitdActualizable.FechaDeFinalizacion = Fecha;
                SolicitdActualizable.UsuarioQueFinaliza = Solicitud.UsuarioQueSolicita;
                SolicitdActualizable.NombreUsuarioQueFinaliza = Solicitud.NombreUsuarioQueSolicita;
            }
            if (Solicitud.EstadoEscalamiento == "SEGUIMIENTO")
            {
                SolicitdActualizable.UsuarioGestionando = Convert.ToDecimal(Solicitud.UsuarioQueSolicita);
                
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
            SolcitudLog.DetalleDeSolicitud = SolicitdActualizable.DetalleDeSolicitud;
            SolcitudLog.FechaDeSolicitud = SolicitdActualizable.FechaDeSolicitud;
            SolcitudLog.UsuarioQueSolicita = SolicitdActualizable.UsuarioQueSolicita;
            SolcitudLog.NombreUsuarioQueSolicita = SolicitdActualizable.NombreUsuarioQueSolicita;
            SolcitudLog.AliadoQueSolicita = SolicitdActualizable.AliadoQueSolicita;
            SolcitudLog.OperacionQueSolicita = SolicitdActualizable.OperacionQueSolicita;
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
        public bool ValidarCuentaEnBackElite(decimal CuentaCliente, decimal Ot,string Proceso)
        {
            decimal idpro = Convert.ToDecimal(Proceso);
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            UnitOfWork unitWorkproceso = new UnitOfWork(new DimeContext());
            var TipoSolicitud = unitWorkproceso.BEMTipoDeEscalamientos.Find(c => c.IdTipo == idpro).Select(x => x.TipoEscalamiento).FirstOrDefault();
            var resultado = unitWork.BEPSolicitudes.Find(c => c.CuentaCliente == CuentaCliente && c.LlsOt == Ot && c.EstadoEscalamiento != "FINALIZADO" && c.TipoDeSolicitud.Equals(TipoSolicitud)).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public BEPSolicitudes ConsultarSolicitudPorId(decimal IdSolicitud)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BEPSolicitudes solicitud = unitWork.BEPSolicitudes.Find(c => c.IdSolicitud == IdSolicitud).FirstOrDefault();
            return solicitud;
        }
        public BEPSolicitudes ApartarCuentadeSolcitudBackElita(decimal Cedula,int noRecursividad)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            List < decimal > solicitud = unitWork.BEPSolicitudes.Find(c => c.UsuarioGestionando == Cedula && c.EstadoEscalamiento.Equals("PENDIENTE")).Select(x => x.IdSolicitud).ToList();
            if (solicitud.Count >0) {
                BEPSolicitudes solicitudencontrada = new BEPSolicitudes();
                return ConsultarSolicitudPorId(solicitud[0]);
            } else {
                unitWork.BEPSolicitudes.ApartarCuentaGestionBackElite(Cedula);
                noRecursividad++;
                if (noRecursividad > 1) return null;
                return ApartarCuentadeSolcitudBackElita(Cedula, noRecursividad);
            }
        }
        public NodosZonificados TraerNodoPorId(string idNodo)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            NodosZonificados Nodo = unitWork.NodosZonificados.Find(c => c.Nodo.Equals(idNodo)).FirstOrDefault();
            return Nodo;
        }
        public BEMTipoDeEscalamientos TipoEscalamientoPorNombre(string NombreTipoEs)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BEMTipoDeEscalamientos tipoescalamiento = unitWork.BEMTipoDeEscalamientos.Find(c => c.TipoEscalamiento.Equals(NombreTipoEs)).FirstOrDefault();
            return tipoescalamiento;
        }
        public List<BELSolicitudes> ListaInteraccionesSolicitud(decimal IdSolicitud)
        {
            DimeContext dimContext = new DimeContext();
            List<BELSolicitudes> result = new List<BELSolicitudes>();
            var objetosResult = (from a in dimContext.BELSolicitudes
                                 where a.IdSolicitud.Equals(IdSolicitud)
                                 orderby a.FechaUltimaActualizacion ascending
                                 select new
                                 {
                                     a.Id,
                                     a.IdSolicitud,
                                     a.CuentaCliente,
                                     a.LlsOt,
                                     a.TipoDeSolicitud,
                                     a.DetalleDeSolicitud,
                                     a.FechaDeSolicitud,
                                     a.UsuarioQueSolicita,
                                     a.NombreUsuarioQueSolicita,
                                     a.AliadoQueSolicita,
                                     a.OperacionQueSolicita,
                                     a.FechaUltimaActualizacion,
                                     a.UsuarioUltimaActualizacion,
                                     a.NombreUsuarioUltimaActualizacion,
                                     a.FechaDeFinalizacion,
                                     a.UsuarioQueFinaliza,
                                     a.NombreUsuarioQueFinaliza,
                                     a.Nodo,
                                     a.Malescalado,
                                     a.DetalleMalEscalado,
                                     a.Gestion,
                                     a.EstadoEscalamiento,
                                     a.FechaDeAgenda,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BELSolicitudes());
                result[i].Id = objetosResult[i].Id;
                result[i].IdSolicitud = objetosResult[i].IdSolicitud;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].LlsOt = objetosResult[i].LlsOt;
                result[i].TipoDeSolicitud = objetosResult[i].TipoDeSolicitud;
                result[i].DetalleDeSolicitud = objetosResult[i].DetalleDeSolicitud;
                result[i].FechaDeSolicitud = objetosResult[i].FechaDeSolicitud;
                result[i].UsuarioQueSolicita = objetosResult[i].UsuarioQueSolicita;
                result[i].NombreUsuarioQueSolicita = objetosResult[i].NombreUsuarioQueSolicita;
                result[i].AliadoQueSolicita = objetosResult[i].AliadoQueSolicita;
                result[i].OperacionQueSolicita = objetosResult[i].OperacionQueSolicita;
                result[i].FechaUltimaActualizacion = objetosResult[i].FechaUltimaActualizacion;
                result[i].UsuarioUltimaActualizacion = objetosResult[i].UsuarioUltimaActualizacion;
                result[i].NombreUsuarioUltimaActualizacion = objetosResult[i].NombreUsuarioUltimaActualizacion;
                result[i].FechaDeFinalizacion = objetosResult[i].FechaDeFinalizacion;
                result[i].UsuarioQueFinaliza = objetosResult[i].UsuarioQueFinaliza;
                result[i].NombreUsuarioQueFinaliza = objetosResult[i].NombreUsuarioQueFinaliza;
                result[i].Nodo = objetosResult[i].Nodo;
                result[i].Malescalado = objetosResult[i].Malescalado;
                result[i].DetalleMalEscalado = objetosResult[i].DetalleMalEscalado;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].EstadoEscalamiento = objetosResult[i].EstadoEscalamiento;
                result[i].FechaDeAgenda = objetosResult[i].FechaDeAgenda;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;
        }
        public List<BEPSolicitudes> ListaSeguimientosAgente(decimal Cedula)
        {
            DimeContext dimContext = new DimeContext();
            List<BEPSolicitudes> result = new List<BEPSolicitudes>();
            var objetosResult = (from a in dimContext.BEPSolicitudes
                                 where a.UsuarioGestionando.Equals(Cedula)
                                 orderby a.FechaDeAgenda ascending
                                 select new
                                 {
                                     a.IdSolicitud,
                                     a.CuentaCliente,
                                     a.LlsOt,
                                     a.TipoDeSolicitud,
                                     a.DetalleDeSolicitud,
                                     a.FechaDeSolicitud,
                                     a.UsuarioQueSolicita,
                                     a.NombreUsuarioQueSolicita,
                                     a.AliadoQueSolicita,
                                     a.OperacionQueSolicita,
                                     a.FechaUltimaActualizacion,
                                     a.UsuarioUltimaActualizacion,
                                     a.NombreUsuarioUltimaActualizacion,
                                     a.FechaDeFinalizacion,
                                     a.UsuarioQueFinaliza,
                                     a.NombreUsuarioQueFinaliza,
                                     a.Nodo,
                                     a.Malescalado,
                                     a.DetalleMalEscalado,
                                     a.Gestion,
                                     a.EstadoEscalamiento,
                                     a.FechaDeAgenda,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BEPSolicitudes());
                result[i].IdSolicitud = objetosResult[i].IdSolicitud;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].LlsOt = objetosResult[i].LlsOt;
                result[i].TipoDeSolicitud = objetosResult[i].TipoDeSolicitud;
                result[i].DetalleDeSolicitud = objetosResult[i].DetalleDeSolicitud;
                result[i].FechaDeSolicitud = objetosResult[i].FechaDeSolicitud;
                result[i].UsuarioQueSolicita = objetosResult[i].UsuarioQueSolicita;
                result[i].NombreUsuarioQueSolicita = objetosResult[i].NombreUsuarioQueSolicita;
                result[i].AliadoQueSolicita = objetosResult[i].AliadoQueSolicita;
                result[i].OperacionQueSolicita = objetosResult[i].OperacionQueSolicita;
                result[i].FechaUltimaActualizacion = objetosResult[i].FechaUltimaActualizacion;
                result[i].UsuarioUltimaActualizacion = objetosResult[i].UsuarioUltimaActualizacion;
                result[i].NombreUsuarioUltimaActualizacion = objetosResult[i].NombreUsuarioUltimaActualizacion;
                result[i].FechaDeFinalizacion = objetosResult[i].FechaDeFinalizacion;
                result[i].UsuarioQueFinaliza = objetosResult[i].UsuarioQueFinaliza;
                result[i].NombreUsuarioQueFinaliza = objetosResult[i].NombreUsuarioQueFinaliza;
                result[i].Nodo = objetosResult[i].Nodo;
                result[i].Malescalado = objetosResult[i].Malescalado;
                result[i].DetalleMalEscalado = objetosResult[i].DetalleMalEscalado;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].EstadoEscalamiento = objetosResult[i].EstadoEscalamiento;
                result[i].FechaDeAgenda = objetosResult[i].FechaDeAgenda;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;
        }
        public List<BELSolicitudes> ConsultadeGestionAgente(string Usuario, DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<BELSolicitudes> result = new List<BELSolicitudes>();
            var objetosResult = (from a in dimContext.BELSolicitudes
                                 where a.UsuarioUltimaActualizacion.Equals(Usuario) && a.FechaUltimaActualizacion>= FechaInicial && a.FechaUltimaActualizacion <= FechaFinal
                                 orderby a.FechaUltimaActualizacion ascending
                                 select new
                                 {
                                     a.Id,
                                     a.IdSolicitud,
                                     a.CuentaCliente,
                                     a.LlsOt,
                                     a.TipoDeSolicitud,
                                     a.DetalleDeSolicitud,
                                     a.FechaDeSolicitud,
                                     a.UsuarioQueSolicita,
                                     a.NombreUsuarioQueSolicita,
                                     a.AliadoQueSolicita,
                                     a.OperacionQueSolicita,
                                     a.FechaUltimaActualizacion,
                                     a.UsuarioUltimaActualizacion,
                                     a.NombreUsuarioUltimaActualizacion,
                                     a.FechaDeFinalizacion,
                                     a.UsuarioQueFinaliza,
                                     a.NombreUsuarioQueFinaliza,
                                     a.Nodo,
                                     a.Malescalado,
                                     a.DetalleMalEscalado,
                                     a.Gestion,
                                     a.EstadoEscalamiento,
                                     a.FechaDeAgenda,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BELSolicitudes());
                result[i].Id = objetosResult[i].Id;
                result[i].IdSolicitud = objetosResult[i].IdSolicitud;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].LlsOt = objetosResult[i].LlsOt;
                result[i].TipoDeSolicitud = objetosResult[i].TipoDeSolicitud;
                result[i].DetalleDeSolicitud = objetosResult[i].DetalleDeSolicitud;
                result[i].FechaDeSolicitud = objetosResult[i].FechaDeSolicitud;
                result[i].UsuarioQueSolicita = objetosResult[i].UsuarioQueSolicita;
                result[i].NombreUsuarioQueSolicita = objetosResult[i].NombreUsuarioQueSolicita;
                result[i].AliadoQueSolicita = objetosResult[i].AliadoQueSolicita;
                result[i].OperacionQueSolicita = objetosResult[i].OperacionQueSolicita;
                result[i].FechaUltimaActualizacion = objetosResult[i].FechaUltimaActualizacion;
                result[i].UsuarioUltimaActualizacion = objetosResult[i].UsuarioUltimaActualizacion;
                result[i].NombreUsuarioUltimaActualizacion = objetosResult[i].NombreUsuarioUltimaActualizacion;
                result[i].FechaDeFinalizacion = objetosResult[i].FechaDeFinalizacion;
                result[i].UsuarioQueFinaliza = objetosResult[i].UsuarioQueFinaliza;
                result[i].NombreUsuarioQueFinaliza = objetosResult[i].NombreUsuarioQueFinaliza;
                result[i].Nodo = objetosResult[i].Nodo;
                result[i].Malescalado = objetosResult[i].Malescalado;
                result[i].DetalleMalEscalado = objetosResult[i].DetalleMalEscalado;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].EstadoEscalamiento = objetosResult[i].EstadoEscalamiento;
                result[i].FechaDeAgenda = objetosResult[i].FechaDeAgenda;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;
        }
        public List<BELSolicitudes> ConsultaSolicitudesAdminLog(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<BELSolicitudes> result = new List<BELSolicitudes>();
            var objetosResult = (from a in dimContext.BELSolicitudes
                                 where a.FechaUltimaActualizacion >= FechaInicial && a.FechaUltimaActualizacion <= FechaFinal
                                 orderby a.FechaUltimaActualizacion ascending
                                 select new
                                 {
                                     a.Id,
                                     a.IdSolicitud,
                                     a.CuentaCliente,
                                     a.LlsOt,
                                     a.TipoDeSolicitud,
                                     a.DetalleDeSolicitud,
                                     a.FechaDeSolicitud,
                                     a.UsuarioQueSolicita,
                                     a.NombreUsuarioQueSolicita,
                                     a.AliadoQueSolicita,
                                     a.OperacionQueSolicita,
                                     a.FechaUltimaActualizacion,
                                     a.UsuarioUltimaActualizacion,
                                     a.NombreUsuarioUltimaActualizacion,
                                     a.FechaDeFinalizacion,
                                     a.UsuarioQueFinaliza,
                                     a.NombreUsuarioQueFinaliza,
                                     a.Nodo,
                                     a.Malescalado,
                                     a.DetalleMalEscalado,
                                     a.Gestion,
                                     a.EstadoEscalamiento,
                                     a.FechaDeAgenda,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BELSolicitudes());
                result[i].Id = objetosResult[i].Id;
                result[i].IdSolicitud = objetosResult[i].IdSolicitud;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].LlsOt = objetosResult[i].LlsOt;
                result[i].TipoDeSolicitud = objetosResult[i].TipoDeSolicitud;
                result[i].DetalleDeSolicitud = objetosResult[i].DetalleDeSolicitud;
                result[i].FechaDeSolicitud = objetosResult[i].FechaDeSolicitud;
                result[i].UsuarioQueSolicita = objetosResult[i].UsuarioQueSolicita;
                result[i].NombreUsuarioQueSolicita = objetosResult[i].NombreUsuarioQueSolicita;
                result[i].AliadoQueSolicita = objetosResult[i].AliadoQueSolicita;
                result[i].OperacionQueSolicita = objetosResult[i].OperacionQueSolicita;
                result[i].FechaUltimaActualizacion = objetosResult[i].FechaUltimaActualizacion;
                result[i].UsuarioUltimaActualizacion = objetosResult[i].UsuarioUltimaActualizacion;
                result[i].NombreUsuarioUltimaActualizacion = objetosResult[i].NombreUsuarioUltimaActualizacion;
                result[i].FechaDeFinalizacion = objetosResult[i].FechaDeFinalizacion;
                result[i].UsuarioQueFinaliza = objetosResult[i].UsuarioQueFinaliza;
                result[i].NombreUsuarioQueFinaliza = objetosResult[i].NombreUsuarioQueFinaliza;
                result[i].Nodo = objetosResult[i].Nodo;
                result[i].Malescalado = objetosResult[i].Malescalado;
                result[i].DetalleMalEscalado = objetosResult[i].DetalleMalEscalado;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].EstadoEscalamiento = objetosResult[i].EstadoEscalamiento;
                result[i].FechaDeAgenda = objetosResult[i].FechaDeAgenda;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;
        }
        public List<BEPSolicitudes> ConsultaSolicitudesAdminPricipal(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<BEPSolicitudes> result = new List<BEPSolicitudes>();
            var objetosResult = (from a in dimContext.BEPSolicitudes
                                 where a.FechaUltimaActualizacion >= FechaInicial && a.FechaUltimaActualizacion <= FechaFinal
                                 orderby a.FechaUltimaActualizacion ascending
                                 select new
                                 {
                                     a.IdSolicitud,
                                     a.CuentaCliente,
                                     a.LlsOt,
                                     a.TipoDeSolicitud,
                                     a.DetalleDeSolicitud,
                                     a.FechaDeSolicitud,
                                     a.UsuarioQueSolicita,
                                     a.NombreUsuarioQueSolicita,
                                     a.AliadoQueSolicita,
                                     a.OperacionQueSolicita,
                                     a.FechaUltimaActualizacion,
                                     a.UsuarioUltimaActualizacion,
                                     a.NombreUsuarioUltimaActualizacion,
                                     a.FechaDeFinalizacion,
                                     a.UsuarioQueFinaliza,
                                     a.NombreUsuarioQueFinaliza,
                                     a.Nodo,
                                     a.Malescalado,
                                     a.DetalleMalEscalado,
                                     a.Gestion,
                                     a.EstadoEscalamiento,
                                     a.FechaDeAgenda,
                                     a.Observaciones,
                                     a.UsuarioGestionando
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BEPSolicitudes());
                result[i].IdSolicitud = objetosResult[i].IdSolicitud;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].LlsOt = objetosResult[i].LlsOt;
                result[i].TipoDeSolicitud = objetosResult[i].TipoDeSolicitud;
                result[i].DetalleDeSolicitud = objetosResult[i].DetalleDeSolicitud;
                result[i].FechaDeSolicitud = objetosResult[i].FechaDeSolicitud;
                result[i].UsuarioQueSolicita = objetosResult[i].UsuarioQueSolicita;
                result[i].NombreUsuarioQueSolicita = objetosResult[i].NombreUsuarioQueSolicita;
                result[i].AliadoQueSolicita = objetosResult[i].AliadoQueSolicita;
                result[i].OperacionQueSolicita = objetosResult[i].OperacionQueSolicita;
                result[i].FechaUltimaActualizacion = objetosResult[i].FechaUltimaActualizacion;
                result[i].UsuarioUltimaActualizacion = objetosResult[i].UsuarioUltimaActualizacion;
                result[i].NombreUsuarioUltimaActualizacion = objetosResult[i].NombreUsuarioUltimaActualizacion;
                result[i].FechaDeFinalizacion = objetosResult[i].FechaDeFinalizacion;
                result[i].UsuarioQueFinaliza = objetosResult[i].UsuarioQueFinaliza;
                result[i].NombreUsuarioQueFinaliza = objetosResult[i].NombreUsuarioQueFinaliza;
                result[i].Nodo = objetosResult[i].Nodo;
                result[i].Malescalado = objetosResult[i].Malescalado;
                result[i].DetalleMalEscalado = objetosResult[i].DetalleMalEscalado;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].EstadoEscalamiento = objetosResult[i].EstadoEscalamiento;
                result[i].FechaDeAgenda = objetosResult[i].FechaDeAgenda;
                result[i].Observaciones = objetosResult[i].Observaciones;
                result[i].UsuarioGestionando = objetosResult[i].UsuarioGestionando;
            }
            return result;
        }
        public bool ValidarUsuarioDistribucion(decimal Cedula, string Proceso)
        {
            UnitOfWork UnitOfWorkProceso = new UnitOfWork(new DimeContext());
            Proceso = UnitOfWorkProceso.BEMTipoDeEscalamientos.Get(Convert.ToInt32(Proceso)).TipoEscalamiento;
            UnitOfWorkProceso.Complete();
            UnitOfWorkProceso.Dispose();

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.BEMDistribuciones.Find(c => c.CedulaUsuario == Cedula && c.TipoEscalamientoAsignado == Proceso).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public void RegistrarUsuarioDistribucion(BEMDistribuciones Distribucion)
        {
            //actualiza nombre proceso
            UnitOfWork UnitOfWorkProceso = new UnitOfWork(new DimeContext());
            Distribucion.TipoEscalamientoAsignado = UnitOfWorkProceso.BEMTipoDeEscalamientos.Get(Convert.ToInt32(Distribucion.TipoEscalamientoAsignado)).TipoEscalamiento;
            UnitOfWorkProceso.Complete();
            UnitOfWorkProceso.Dispose();
            //inserta registro
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            UnitOfWork.BEMDistribuciones.Add(Distribucion);
            UnitOfWork.Complete();
            UnitOfWork.Dispose();
        }
        public void EliminarUsuarioDistribucion (decimal Cedula, string Proceso)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BEMDistribuciones RegistroEliminar = unitWork.BEMDistribuciones.Find(c => c.CedulaUsuario == Cedula && c.TipoEscalamientoAsignado == Proceso).FirstOrDefault();

            if (RegistroEliminar != null)
            {
                unitWork.BEMDistribuciones.Remove(RegistroEliminar);
                unitWork.Complete();
            }
            else { }

        }
        public List<BEMDistribuciones> ListaDistribucionPorIdCedula( decimal Cedula)
        {
            DimeContext dimContext = new DimeContext();
            List<BEMDistribuciones> result = new List<BEMDistribuciones>();
            var objetosResult = (from a in dimContext.BEMDistribuciones
                                 where a.CedulaUsuario== Cedula
                                 orderby a.TipoEscalamientoAsignado ascending
                                 select new
                                 {
                                     a.Id,
                                     a.TipoEscalamientoAsignado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new BEMDistribuciones());
                result[i].Id= objetosResult[i].Id;
                result[i].TipoEscalamientoAsignado = objetosResult[i].TipoEscalamientoAsignado;
                
            }
            return result;
        }
        public BEMDistribuciones DistribucionPorId(decimal Id)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            BEMDistribuciones distri = unitWork.BEMDistribuciones.Find(c => c.Id == Id).FirstOrDefault();
            return distri;
        }
        public List<BEPSolicitudes> ConsultarSolicitudesMasivo(List<string> Solicitudes)
        {

            DimeContext context = new DimeContext();
            List<decimal> IdSolicitudes = Solicitudes.ConvertAll(s => Convert.ToDecimal(s));
            List<BEPSolicitudes> ListaSolicitudes = new List<BEPSolicitudes>();
            foreach (decimal ID_SOLICITUD in IdSolicitudes)
            {
                BEPSolicitudes Solicitud = context.BEPSolicitudes.Where(c => c.IdSolicitud == ID_SOLICITUD && c.EstadoEscalamiento.Equals("PENDIENTE") && c.UsuarioGestionando == 0).FirstOrDefault();
                if (Solicitud !=null) 
                {
                    ListaSolicitudes.Add(Solicitud);
                }
            }
            return ListaSolicitudes;
        }
        public void ActualizarSolicitudesMasivo(List<string> Solicitudes, BEPSolicitudes Solicitud)
        {
            
            List<decimal> IdSolicitudes = Solicitudes.ConvertAll(s => Convert.ToDecimal(s));
            foreach (decimal ID_SOLICITUD in IdSolicitudes)
            {
                UnitOfWork UnitOfWorkSolicitdActualizable = new UnitOfWork(new DimeContext());
                BEPSolicitudes SolicitudActualizable = UnitOfWorkSolicitdActualizable.BEPSolicitudes.Find(c => c.IdSolicitud == ID_SOLICITUD && c.EstadoEscalamiento.Equals("PENDIENTE") && c.TipoDeSolicitud.Equals(Solicitud.TipoDeSolicitud) && c.UsuarioGestionando == 0).FirstOrDefault();
                if (SolicitudActualizable != null)
                {
                    //Actualiza solicitud
                    DateTime Fecha = DateTime.Now;
                    SolicitudActualizable.FechaUltimaActualizacion = Fecha;
                    SolicitudActualizable.UsuarioUltimaActualizacion = Solicitud.UsuarioQueSolicita;
                    SolicitudActualizable.NombreUsuarioUltimaActualizacion = Solicitud.NombreUsuarioQueSolicita;
                    SolicitudActualizable.Malescalado = Solicitud.Malescalado;
                    SolicitudActualizable.DetalleMalEscalado = Solicitud.DetalleMalEscalado;
                    SolicitudActualizable.Gestion = Solicitud.Gestion;
                    SolicitudActualizable.EstadoEscalamiento =Solicitud.EstadoEscalamiento;
                    SolicitudActualizable.Observaciones = Solicitud.Observaciones;
                    SolicitudActualizable.FechaDeFinalizacion = Fecha;
                    SolicitudActualizable.UsuarioQueFinaliza = Solicitud.UsuarioQueSolicita;
                    SolicitudActualizable.NombreUsuarioQueFinaliza = Solicitud.NombreUsuarioQueSolicita;
                    SolicitudActualizable.FechaDeAgenda = Solicitud.FechaDeAgenda;

                    UnitOfWorkSolicitdActualizable.Complete();
                    UnitOfWorkSolicitdActualizable.Dispose();

                    //inserta solicitud en la tabla del log
                    UnitOfWork UnitOfWorkLog = new UnitOfWork(new DimeContext());
                    BELSolicitudes SolcitudLog = new BELSolicitudes();

                    SolcitudLog.IdSolicitud = SolicitudActualizable.IdSolicitud;
                    SolcitudLog.CuentaCliente = SolicitudActualizable.CuentaCliente;
                    SolcitudLog.LlsOt = SolicitudActualizable.LlsOt;
                    SolcitudLog.TipoDeSolicitud = SolicitudActualizable.TipoDeSolicitud;
                    SolcitudLog.DetalleDeSolicitud = SolicitudActualizable.DetalleDeSolicitud;
                    SolcitudLog.FechaDeSolicitud = SolicitudActualizable.FechaDeSolicitud;
                    SolcitudLog.UsuarioQueSolicita = SolicitudActualizable.UsuarioQueSolicita;
                    SolcitudLog.NombreUsuarioQueSolicita = SolicitudActualizable.NombreUsuarioQueSolicita;
                    SolcitudLog.AliadoQueSolicita = SolicitudActualizable.AliadoQueSolicita;
                    SolcitudLog.OperacionQueSolicita = SolicitudActualizable.OperacionQueSolicita;
                    SolcitudLog.FechaUltimaActualizacion = SolicitudActualizable.FechaUltimaActualizacion;
                    SolcitudLog.UsuarioUltimaActualizacion = SolicitudActualizable.UsuarioUltimaActualizacion;
                    SolcitudLog.NombreUsuarioUltimaActualizacion = SolicitudActualizable.NombreUsuarioUltimaActualizacion;
                    SolcitudLog.FechaDeFinalizacion = SolicitudActualizable.FechaDeFinalizacion;
                    SolcitudLog.UsuarioQueFinaliza = SolicitudActualizable.UsuarioQueFinaliza;
                    SolcitudLog.NombreUsuarioQueFinaliza = SolicitudActualizable.NombreUsuarioQueFinaliza;
                    SolcitudLog.Nodo = SolicitudActualizable.Nodo;
                    SolcitudLog.Malescalado = SolicitudActualizable.Malescalado;
                    SolcitudLog.DetalleMalEscalado = SolicitudActualizable.DetalleMalEscalado;
                    SolcitudLog.Gestion = SolicitudActualizable.Gestion;
                    SolcitudLog.EstadoEscalamiento = SolicitudActualizable.EstadoEscalamiento;
                    SolcitudLog.FechaDeAgenda = SolicitudActualizable.FechaDeAgenda;
                    SolcitudLog.Observaciones = SolicitudActualizable.Observaciones;

                    UnitOfWorkLog.BELSolicitudes.Add(SolcitudLog);
                    UnitOfWorkLog.Complete();
                    UnitOfWorkLog.Dispose();
                }
            }

        }       
    }
}

