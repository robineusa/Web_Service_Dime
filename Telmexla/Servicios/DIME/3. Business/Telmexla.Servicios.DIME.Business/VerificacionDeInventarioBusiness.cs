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
    public class VerificacionDeInventarioBusiness
    {
        public decimal ReistrarSolicitud(VIPSolicitudes Solicitud) {
            //trae la informacion de los procesos y las listas seleccionadas
            UnitOfWork UnitOfWorkProceso = new UnitOfWork(new DimeContext());
            Solicitud.TipoDeRequerimiento = UnitOfWorkProceso.VIMTipoDeRequerimiento.Get(Convert.ToInt32(Solicitud.TipoDeRequerimiento)).TipoDeRequerimiento;
            UnitOfWorkProceso.Complete();
            UnitOfWorkProceso.Dispose();

            //REGISTRA SOLICITUD PRINCIPAL
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            DateTime Fecha = DateTime.Now;
            Solicitud.FechaSolicitud = Fecha;
            Solicitud.FechaUltimaActualizacion = Fecha;
            Solicitud.EstadoSolicitud = "PENDIENTE";
            UnitOfWork.VIPSolicitudes.Add(Solicitud);
            UnitOfWork.Complete();
            UnitOfWork.Dispose();

            //REGISTRA LOG
            UnitOfWork UnitOfWorkLog = new UnitOfWork(new DimeContext());
            VILSolicitudes LogSolicitud = new VILSolicitudes();

            LogSolicitud.IdSolicitud = Solicitud.IdSolicitud;
            LogSolicitud.FechaSolicitud = Solicitud.FechaSolicitud;
            LogSolicitud.UsuarioSolicitud = Solicitud.UsuarioSolicitud;
            LogSolicitud.NombreUsuarioSolicitud = Solicitud.NombreUsuarioSolicitud;
            LogSolicitud.AliadoSolicitud = Solicitud.AliadoSolicitud;
            LogSolicitud.OperacionSolicitud = Solicitud.OperacionSolicitud;
            LogSolicitud.FechaTransaccion = Solicitud.FechaUltimaActualizacion;
            LogSolicitud.UsuarioTransaccion = Solicitud.UsuarioUltimaActualizacion;
            LogSolicitud.NombreUsuarioTransaccion = Solicitud.NombreUsuarioUltimaActualizacion;
            LogSolicitud.CuentaCliente = Solicitud.CuentaCliente;
            LogSolicitud.TipoDeRequerimiento = Solicitud.TipoDeRequerimiento;
            LogSolicitud.RequiereAjuste = Solicitud.RequiereAjuste;
            LogSolicitud.Nodo = Solicitud.Nodo;
            LogSolicitud.Gestion = Solicitud.Gestion;
            LogSolicitud.Subrazon = Solicitud.Subrazon;
            LogSolicitud.EstadoSolicitud = Solicitud.EstadoSolicitud;
            LogSolicitud.AliadoTecnico = Solicitud.AliadoTecnico;
            LogSolicitud.Observaciones = Solicitud.Observaciones;
            LogSolicitud.UsuarioGestionando = 0;

            UnitOfWorkLog.VILSolicitudes.Add(LogSolicitud);
            UnitOfWorkLog.Complete();
            UnitOfWorkLog.Dispose();
            return Solicitud.IdSolicitud;
        }
        public void ActualizarSolicitud(VIPSolicitudes Solicitud)
        {
            //trae la informacion de los procesos y las listas seleccionadas
            UnitOfWork UnitOfWorkProceso = new UnitOfWork(new DimeContext());
            Solicitud.TipoDeRequerimiento = UnitOfWorkProceso.VIMTipoDeRequerimiento.Get(Convert.ToInt32(Solicitud.TipoDeRequerimiento)).TipoDeRequerimiento;
            Solicitud.Gestion = UnitOfWorkProceso.VIMGestion.Get(Convert.ToInt32(Solicitud.Gestion)).Gestion;
            Solicitud.Subrazon = UnitOfWorkProceso.VIMSubrazon.Get(Convert.ToInt32(Solicitud.Subrazon)).Subrazon;
            Solicitud.AliadoTecnico = UnitOfWorkProceso.VIMAliadoTecnico.Get(Convert.ToInt32(Solicitud.AliadoTecnico)).AliadoTecnico;
            UnitOfWorkProceso.Complete();
            UnitOfWorkProceso.Dispose();

            //consulta solicitud para actualizar
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            VIPSolicitudes SolicitudActualizable = UnitOfWork.VIPSolicitudes.Find(x => x.IdSolicitud == Solicitud.IdSolicitud).FirstOrDefault();
            DateTime Fecha = DateTime.Now;

            //actualiza solicitud inicial
            SolicitudActualizable.FechaUltimaActualizacion = Fecha;
            SolicitudActualizable.UsuarioUltimaActualizacion = Solicitud.UsuarioUltimaActualizacion;
            SolicitudActualizable.NombreUsuarioUltimaActualizacion = Solicitud.NombreUsuarioUltimaActualizacion;
            SolicitudActualizable.Gestion = Solicitud.Gestion;
            SolicitudActualizable.Subrazon = Solicitud.Subrazon;
            SolicitudActualizable.EstadoSolicitud = Solicitud.EstadoSolicitud;
            SolicitudActualizable.AliadoTecnico = Solicitud.AliadoTecnico;
            SolicitudActualizable.Observaciones = Solicitud.Observaciones;
            UnitOfWork.Complete();
            UnitOfWork.Dispose();

            //registra el log de la transaccion
            UnitOfWork UnitOfWorkLog = new UnitOfWork(new DimeContext());
            VILSolicitudes LogSolicitud = new VILSolicitudes();

            LogSolicitud.IdSolicitud = SolicitudActualizable.IdSolicitud;
            LogSolicitud.FechaSolicitud = SolicitudActualizable.FechaSolicitud;
            LogSolicitud.UsuarioSolicitud = SolicitudActualizable.UsuarioSolicitud;
            LogSolicitud.NombreUsuarioSolicitud = SolicitudActualizable.NombreUsuarioSolicitud;
            LogSolicitud.AliadoSolicitud = SolicitudActualizable.AliadoSolicitud;
            LogSolicitud.OperacionSolicitud = SolicitudActualizable.OperacionSolicitud;
            LogSolicitud.FechaTransaccion = SolicitudActualizable.FechaUltimaActualizacion;
            LogSolicitud.UsuarioTransaccion = SolicitudActualizable.UsuarioUltimaActualizacion;
            LogSolicitud.NombreUsuarioTransaccion = SolicitudActualizable.NombreUsuarioUltimaActualizacion;
            LogSolicitud.CuentaCliente = SolicitudActualizable.CuentaCliente;
            LogSolicitud.TipoDeRequerimiento = SolicitudActualizable.TipoDeRequerimiento;
            LogSolicitud.RequiereAjuste = SolicitudActualizable.RequiereAjuste;
            LogSolicitud.Nodo = SolicitudActualizable.Nodo;
            LogSolicitud.Gestion = SolicitudActualizable.Gestion;
            LogSolicitud.Subrazon = SolicitudActualizable.Subrazon;
            LogSolicitud.EstadoSolicitud = SolicitudActualizable.EstadoSolicitud;
            LogSolicitud.AliadoTecnico = SolicitudActualizable.AliadoTecnico;
            LogSolicitud.Observaciones = SolicitudActualizable.Observaciones;
            LogSolicitud.UsuarioGestionando = SolicitudActualizable.UsuarioUltimaActualizacion;

            UnitOfWorkLog.Complete();
            UnitOfWorkLog.Dispose();
        }
        public List<VIMTipoDeRequerimiento> ListaTiposDeRequerimientos()
        {
            DimeContext dimContext = new DimeContext();
            List<VIMTipoDeRequerimiento> result = new List<VIMTipoDeRequerimiento>();
            var objetosResult = (from a in dimContext.VIMTipoDeRequerimiento
                                 where a.Estado.Equals("ACTIVO")
                                 orderby a.TipoDeRequerimiento ascending
                                 select new
                                 {
                                     a.Id,
                                     a.TipoDeRequerimiento

                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new VIMTipoDeRequerimiento());
                result[i].Id = objetosResult[i].Id;
                result[i].TipoDeRequerimiento = objetosResult[i].TipoDeRequerimiento;

            }
            return result;
        }
        public void RegistrarEquiposPorSolicitud(VIPSolicitudesPorEquipo Equipos)
        {
            //consulta id de desplegables
            UnitOfWork UnitOfWorkProceso = new UnitOfWork(new DimeContext());
            Equipos.TipoDeEquipo = UnitOfWorkProceso.VIMTipoDeEquipos.Get(Convert.ToInt32(Equipos.TipoDeEquipo)).TipoDeEquipo;
            UnitOfWorkProceso.Complete();
            UnitOfWorkProceso.Dispose();

            //registra solicitud
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            UnitOfWork.VIPSolicitudesPorEquipo.Add(Equipos);
            UnitOfWork.Complete();
            UnitOfWork.Dispose();
        }
        public List<VIPSolicitudesPorEquipo> ListaDeEquiposPorSolicitud(decimal IdSolicitud)
        {
            DimeContext dimContext = new DimeContext();
            List<VIPSolicitudesPorEquipo> result = new List<VIPSolicitudesPorEquipo>();
            var objetosResult = (from a in dimContext.VIPSolicitudesPorEquipo
                                 where a.IdSolicitud==IdSolicitud
                                 orderby a.Id ascending
                                 select new
                                 {
                                     a.Id,
                                     a.IdSolicitud,
                                     a.TipoDeEquipo,
                                     a.Mac,
                                     a.Tarjeta
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new VIPSolicitudesPorEquipo());
                result[i].Id = objetosResult[i].Id;
                result[i].IdSolicitud = objetosResult[i].IdSolicitud;
                result[i].TipoDeEquipo = objetosResult[i].TipoDeEquipo;
                result[i].Mac = objetosResult[i].Mac;
                result[i].Tarjeta = objetosResult[i].Tarjeta;

            }
            return result;
        }
        public void EliminarEquiposPorSolicitud(decimal Id)
        {

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            VIPSolicitudesPorEquipo RegistroEliminar = unitWork.VIPSolicitudesPorEquipo.Find(c => c.Id == Id).FirstOrDefault();

            if (RegistroEliminar != null)
            {
                unitWork.VIPSolicitudesPorEquipo.Remove(RegistroEliminar);
                unitWork.Complete();
            }
            else { }
        }
        public void ActualizarEquiposPorSolicitud(VIPSolicitudesPorEquipo Equipos)
        {
            //consulta id de desplegables
            UnitOfWork UnitOfWorkProceso = new UnitOfWork(new DimeContext());
            Equipos.TipoDeEquipo = UnitOfWorkProceso.VIMTipoDeEquipos.Get(Convert.ToInt32(Equipos.TipoDeEquipo)).TipoDeEquipo;
            UnitOfWorkProceso.Complete();
            UnitOfWorkProceso.Dispose();
            
            //registra solicitud
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            VIPSolicitudesPorEquipo EquipoActualizable = UnitOfWork.VIPSolicitudesPorEquipo.Find(x => x.Id == Equipos.Id).FirstOrDefault();
            EquipoActualizable.Mac = Equipos.Mac;
            EquipoActualizable.TipoDeEquipo = Equipos.TipoDeEquipo;
            EquipoActualizable.Tarjeta = Equipos.Tarjeta;
            UnitOfWork.Complete();
            UnitOfWork.Dispose();
        }
        public VIPSolicitudesPorEquipo TraeEquipoPorId(int Id)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            VIPSolicitudesPorEquipo EquipoExistente = UnitOfWork.VIPSolicitudesPorEquipo.Get(Id);
            return EquipoExistente;
        }
        public List<VIMTipoDeEquipos> ListaTipoDeEquipos()
        {
            DimeContext dimContext = new DimeContext();
            List<VIMTipoDeEquipos> result = new List<VIMTipoDeEquipos>();
            var objetosResult = (from a in dimContext.VIMTipoDeEquipos
                                 where a.Estado.Equals("ACTIVO")
                                 orderby a.TipoDeEquipo ascending
                                 select new
                                 {
                                     a.Id,
                                     a.TipoDeEquipo

                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new VIMTipoDeEquipos());
                result[i].Id = objetosResult[i].Id;
                result[i].TipoDeEquipo = objetosResult[i].TipoDeEquipo;

            }
            return result;
        }

    }
}
