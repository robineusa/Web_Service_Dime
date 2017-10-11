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
        public decimal ReistrarSolicitud(VIPSolicitudes Solicitud)
        {
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
            Solicitud.Gestion = "SOLICITUD INBOUND";
            Solicitud.Subrazon = "VERIFICACION DE INVENTARIO";
            Solicitud.UsuarioGestionando = 0;
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
            LogSolicitud.UsuarioGestionando = Solicitud.UsuarioGestionando;

            UnitOfWorkLog.VILSolicitudes.Add(LogSolicitud);
            UnitOfWorkLog.Complete();
            UnitOfWorkLog.Dispose();
            return Solicitud.IdSolicitud;
        }
        public void ActualizarSolicitud(VIPSolicitudes Solicitud)
        {
            //trae la informacion de los procesos y las listas seleccionadas
            UnitOfWork UnitOfWorkProceso = new UnitOfWork(new DimeContext());
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
            LogSolicitud.UsuarioGestionando = SolicitudActualizable.UsuarioGestionando;

            UnitOfWorkLog.VILSolicitudes.Add(LogSolicitud);
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
                                 where a.IdSolicitud == IdSolicitud
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
        public bool ExisteSolicitudEscalada(decimal CuentaCliente)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            VIPSolicitudes Solicitud = UnitOfWork.VIPSolicitudes.Find(x => x.CuentaCliente == CuentaCliente && x.EstadoSolicitud != "FINALIZADO").FirstOrDefault();
            if (Solicitud != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<VIPSolicitudes> ConsultaSolicitudesPorCliente(decimal CuentaCliente)
        {
            DimeContext dimContext = new DimeContext();
            List<VIPSolicitudes> result = new List<VIPSolicitudes>();
            var objetosResult = (from a in dimContext.VIPSolicitudes
                                 where a.CuentaCliente == CuentaCliente
                                 orderby a.IdSolicitud ascending
                                 select new
                                 {
                                     a.IdSolicitud,
                                     a.FechaSolicitud,
                                     a.UsuarioSolicitud,
                                     a.NombreUsuarioSolicitud,
                                     a.AliadoSolicitud,
                                     a.OperacionSolicitud,
                                     a.FechaUltimaActualizacion,
                                     a.UsuarioUltimaActualizacion,
                                     a.NombreUsuarioUltimaActualizacion,
                                     a.CuentaCliente,
                                     a.TipoDeRequerimiento,
                                     a.RequiereAjuste,
                                     a.Nodo,
                                     a.Gestion,
                                     a.Subrazon,
                                     a.EstadoSolicitud,
                                     a.AliadoTecnico,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new VIPSolicitudes());
                result[i].IdSolicitud = objetosResult[i].IdSolicitud;
                result[i].FechaSolicitud = objetosResult[i].FechaSolicitud;
                result[i].UsuarioSolicitud = objetosResult[i].UsuarioSolicitud;
                result[i].NombreUsuarioSolicitud = objetosResult[i].NombreUsuarioSolicitud;
                result[i].AliadoSolicitud = objetosResult[i].AliadoSolicitud;
                result[i].OperacionSolicitud = objetosResult[i].OperacionSolicitud;
                result[i].FechaUltimaActualizacion = objetosResult[i].FechaUltimaActualizacion;
                result[i].UsuarioUltimaActualizacion = objetosResult[i].UsuarioUltimaActualizacion;
                result[i].NombreUsuarioUltimaActualizacion = objetosResult[i].NombreUsuarioUltimaActualizacion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TipoDeRequerimiento = objetosResult[i].TipoDeRequerimiento;
                result[i].RequiereAjuste = objetosResult[i].RequiereAjuste;
                result[i].Nodo = objetosResult[i].Nodo;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Subrazon = objetosResult[i].Subrazon;
                result[i].EstadoSolicitud = objetosResult[i].EstadoSolicitud;
                result[i].AliadoTecnico = objetosResult[i].AliadoTecnico;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public List<VIPSolicitudes> ConsultaAdminSolicitudesPrincipal(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<VIPSolicitudes> result = new List<VIPSolicitudes>();
            var objetosResult = (from a in dimContext.VIPSolicitudes
                                 where a.FechaSolicitud >= FechaInicial && a.FechaSolicitud <= FechaFinal
                                 orderby a.IdSolicitud ascending
                                 select new
                                 {
                                     a.IdSolicitud,
                                     a.FechaSolicitud,
                                     a.UsuarioSolicitud,
                                     a.NombreUsuarioSolicitud,
                                     a.AliadoSolicitud,
                                     a.OperacionSolicitud,
                                     a.FechaUltimaActualizacion,
                                     a.UsuarioUltimaActualizacion,
                                     a.NombreUsuarioUltimaActualizacion,
                                     a.CuentaCliente,
                                     a.TipoDeRequerimiento,
                                     a.RequiereAjuste,
                                     a.Nodo,
                                     a.Gestion,
                                     a.Subrazon,
                                     a.EstadoSolicitud,
                                     a.AliadoTecnico,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new VIPSolicitudes());
                result[i].IdSolicitud = objetosResult[i].IdSolicitud;
                result[i].FechaSolicitud = objetosResult[i].FechaSolicitud;
                result[i].UsuarioSolicitud = objetosResult[i].UsuarioSolicitud;
                result[i].NombreUsuarioSolicitud = objetosResult[i].NombreUsuarioSolicitud;
                result[i].AliadoSolicitud = objetosResult[i].AliadoSolicitud;
                result[i].OperacionSolicitud = objetosResult[i].OperacionSolicitud;
                result[i].FechaUltimaActualizacion = objetosResult[i].FechaUltimaActualizacion;
                result[i].UsuarioUltimaActualizacion = objetosResult[i].UsuarioUltimaActualizacion;
                result[i].NombreUsuarioUltimaActualizacion = objetosResult[i].NombreUsuarioUltimaActualizacion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TipoDeRequerimiento = objetosResult[i].TipoDeRequerimiento;
                result[i].RequiereAjuste = objetosResult[i].RequiereAjuste;
                result[i].Nodo = objetosResult[i].Nodo;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Subrazon = objetosResult[i].Subrazon;
                result[i].EstadoSolicitud = objetosResult[i].EstadoSolicitud;
                result[i].AliadoTecnico = objetosResult[i].AliadoTecnico;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public List<VILSolicitudes> ListaDeInteraccionesPorSolicitud(decimal IdSolicitud)
        {
            DimeContext dimContext = new DimeContext();
            List<VILSolicitudes> result = new List<VILSolicitudes>();
            var objetosResult = (from a in dimContext.VILSolicitudes
                                 where a.IdSolicitud == IdSolicitud
                                 orderby a.IdTransaccion ascending
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.IdSolicitud,
                                     a.FechaSolicitud,
                                     a.UsuarioSolicitud,
                                     a.NombreUsuarioSolicitud,
                                     a.AliadoSolicitud,
                                     a.OperacionSolicitud,
                                     a.FechaTransaccion,
                                     a.UsuarioTransaccion,
                                     a.NombreUsuarioTransaccion,
                                     a.CuentaCliente,
                                     a.TipoDeRequerimiento,
                                     a.RequiereAjuste,
                                     a.Nodo,
                                     a.Gestion,
                                     a.Subrazon,
                                     a.EstadoSolicitud,
                                     a.AliadoTecnico,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new VILSolicitudes());
                result[i].IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].IdSolicitud = objetosResult[i].IdSolicitud;
                result[i].FechaSolicitud = objetosResult[i].FechaSolicitud;
                result[i].UsuarioSolicitud = objetosResult[i].UsuarioSolicitud;
                result[i].NombreUsuarioSolicitud = objetosResult[i].NombreUsuarioSolicitud;
                result[i].AliadoSolicitud = objetosResult[i].AliadoSolicitud;
                result[i].OperacionSolicitud = objetosResult[i].OperacionSolicitud;
                result[i].FechaTransaccion = objetosResult[i].FechaTransaccion;
                result[i].UsuarioTransaccion = objetosResult[i].UsuarioTransaccion;
                result[i].NombreUsuarioTransaccion = objetosResult[i].NombreUsuarioTransaccion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TipoDeRequerimiento = objetosResult[i].TipoDeRequerimiento;
                result[i].RequiereAjuste = objetosResult[i].RequiereAjuste;
                result[i].Nodo = objetosResult[i].Nodo;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Subrazon = objetosResult[i].Subrazon;
                result[i].EstadoSolicitud = objetosResult[i].EstadoSolicitud;
                result[i].AliadoTecnico = objetosResult[i].AliadoTecnico;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public VIPSolicitudes ApartarCuentaVerificacionInventario(decimal Cedula, int noRecursividad)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            List<decimal> solicitud = unitWork.VIPSolicitudes.Find(c => c.UsuarioGestionando == Cedula && c.EstadoSolicitud.Equals("PENDIENTE")).Select(x => x.IdSolicitud).ToList();
            if (solicitud.Count > 0)
            {
                //VIPSolicitudes solicitudencontrada = new VIPSolicitudes();
                return ConsultarSolicitudPorIdInventario(solicitud[0]);
            }
            else
            {
                unitWork.VIPSolicitudes.ProcedimientoApartarCuentaVerificacionInventario(Cedula);
                noRecursividad++;
                if (noRecursividad > 1) return null;
                return ApartarCuentaVerificacionInventario(Cedula, noRecursividad);
            }
        }
        public VIPSolicitudes ConsultarSolicitudPorIdInventario(decimal Id)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            VIPSolicitudes solicitud = unitWork.VIPSolicitudes.Find(c => c.IdSolicitud == Id).FirstOrDefault();
            return solicitud;
        }
        public List<VIMGestion> ListaDeGestion()
        {
            DimeContext dimContext = new DimeContext();
            List<VIMGestion> result = new List<VIMGestion>();
            var objetosResult = (from a in dimContext.VIMGestion
                                 where a.Estado.Equals("ACTIVO")
                                 orderby a.Gestion ascending
                                 select new
                                 {
                                     a.IdGestion,
                                     a.Gestion

                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new VIMGestion());
                result[i].IdGestion = objetosResult[i].IdGestion;
                result[i].Gestion = objetosResult[i].Gestion;

            }
            return result;
        }
        public List<VIMSubrazon> ListaSubrazon(decimal IdGestion)
        {
            DimeContext dimContext = new DimeContext();
            List<VIMSubrazon> result = new List<VIMSubrazon>();
            var objetosResult = (from a in dimContext.VIMSubrazon
                                 where a.Estado.Equals("ACTIVO") && a.IdGestion == IdGestion
                                 orderby a.Subrazon ascending
                                 select new
                                 {
                                     a.IdSubrazon,
                                     a.Subrazon,

                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new VIMSubrazon());
                result[i].IdSubrazon = objetosResult[i].IdSubrazon;
                result[i].Subrazon = objetosResult[i].Subrazon;

            }
            return result;
        }
        public List<VIMAliadoTecnico> ListaAliadosTecnicos()
        {
            DimeContext dimContext = new DimeContext();
            List<VIMAliadoTecnico> result = new List<VIMAliadoTecnico>();
            var objetosResult = (from a in dimContext.VIMAliadoTecnico
                                 where a.Estado.Equals("ACTIVO") 
                                 orderby a.AliadoTecnico ascending
                                 select new
                                 {
                                     a.IdAliado,
                                     a.AliadoTecnico

                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new VIMAliadoTecnico());
                result[i].IdAliado = objetosResult[i].IdAliado;
                result[i].AliadoTecnico = objetosResult[i].AliadoTecnico;

            }
            return result;
        }
        public VIMSubrazon TraeSubrazonporIdGestion(int Id)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            VIMSubrazon solicitud = unitWork.VIMSubrazon.Get(Id);
            return solicitud;
        }
        public List<VIPSolicitudes> SolicitudesEnSeguimiento(decimal Usuario)
        {
            DimeContext dimContext = new DimeContext();
            List<VIPSolicitudes> result = new List<VIPSolicitudes>();
            var objetosResult = (from a in dimContext.VIPSolicitudes
                                 where a.EstadoSolicitud.Equals("SEGUIMIENTO") && a.UsuarioGestionando== Usuario
                                 orderby a.FechaUltimaActualizacion ascending
                                 select new
                                 {
                                     a.IdSolicitud,
                                     a.FechaSolicitud,
                                     a.UsuarioSolicitud,
                                     a.NombreUsuarioSolicitud,
                                     a.AliadoSolicitud,
                                     a.OperacionSolicitud,
                                     a.FechaUltimaActualizacion,
                                     a.UsuarioUltimaActualizacion,
                                     a.NombreUsuarioUltimaActualizacion,
                                     a.CuentaCliente,
                                     a.TipoDeRequerimiento,
                                     a.RequiereAjuste,
                                     a.Nodo,
                                     a.Gestion,
                                     a.Subrazon,
                                     a.EstadoSolicitud,
                                     a.AliadoTecnico,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new VIPSolicitudes());
                result[i].IdSolicitud = objetosResult[i].IdSolicitud;
                result[i].FechaSolicitud = objetosResult[i].FechaSolicitud;
                result[i].UsuarioSolicitud = objetosResult[i].UsuarioSolicitud;
                result[i].NombreUsuarioSolicitud = objetosResult[i].NombreUsuarioSolicitud;
                result[i].AliadoSolicitud = objetosResult[i].AliadoSolicitud;
                result[i].OperacionSolicitud = objetosResult[i].OperacionSolicitud;
                result[i].FechaUltimaActualizacion = objetosResult[i].FechaUltimaActualizacion;
                result[i].UsuarioUltimaActualizacion = objetosResult[i].UsuarioUltimaActualizacion;
                result[i].NombreUsuarioUltimaActualizacion = objetosResult[i].NombreUsuarioUltimaActualizacion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TipoDeRequerimiento = objetosResult[i].TipoDeRequerimiento;
                result[i].RequiereAjuste = objetosResult[i].RequiereAjuste;
                result[i].Nodo = objetosResult[i].Nodo;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Subrazon = objetosResult[i].Subrazon;
                result[i].EstadoSolicitud = objetosResult[i].EstadoSolicitud;
                result[i].AliadoTecnico = objetosResult[i].AliadoTecnico;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public List<VILSolicitudes> ConsultaDeGestionBack(decimal Cedula, DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<VILSolicitudes> result = new List<VILSolicitudes>();
            var objetosResult = (from a in dimContext.VILSolicitudes
                                 where a.UsuarioTransaccion == Cedula && a.FechaTransaccion >= FechaInicial && a.FechaTransaccion <= FechaFinal
                                 orderby a.IdTransaccion ascending
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.IdSolicitud,
                                     a.FechaSolicitud,
                                     a.UsuarioSolicitud,
                                     a.NombreUsuarioSolicitud,
                                     a.AliadoSolicitud,
                                     a.OperacionSolicitud,
                                     a.FechaTransaccion,
                                     a.UsuarioTransaccion,
                                     a.NombreUsuarioTransaccion,
                                     a.CuentaCliente,
                                     a.TipoDeRequerimiento,
                                     a.RequiereAjuste,
                                     a.Nodo,
                                     a.Gestion,
                                     a.Subrazon,
                                     a.EstadoSolicitud,
                                     a.AliadoTecnico,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new VILSolicitudes());
                result[i].IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].IdSolicitud = objetosResult[i].IdSolicitud;
                result[i].FechaSolicitud = objetosResult[i].FechaSolicitud;
                result[i].UsuarioSolicitud = objetosResult[i].UsuarioSolicitud;
                result[i].NombreUsuarioSolicitud = objetosResult[i].NombreUsuarioSolicitud;
                result[i].AliadoSolicitud = objetosResult[i].AliadoSolicitud;
                result[i].OperacionSolicitud = objetosResult[i].OperacionSolicitud;
                result[i].FechaTransaccion = objetosResult[i].FechaTransaccion;
                result[i].UsuarioTransaccion = objetosResult[i].UsuarioTransaccion;
                result[i].NombreUsuarioTransaccion = objetosResult[i].NombreUsuarioTransaccion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TipoDeRequerimiento = objetosResult[i].TipoDeRequerimiento;
                result[i].RequiereAjuste = objetosResult[i].RequiereAjuste;
                result[i].Nodo = objetosResult[i].Nodo;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Subrazon = objetosResult[i].Subrazon;
                result[i].EstadoSolicitud = objetosResult[i].EstadoSolicitud;
                result[i].AliadoTecnico = objetosResult[i].AliadoTecnico;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public List<VILSolicitudes> ConsultaAdminSolicitudesLog(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<VILSolicitudes> result = new List<VILSolicitudes>();
            var objetosResult = (from a in dimContext.VILSolicitudes
                                 where a.FechaTransaccion >= FechaInicial && a.FechaTransaccion <= FechaFinal
                                 orderby a.IdTransaccion ascending
                                 select new
                                 {
                                     a.IdTransaccion,
                                     a.IdSolicitud,
                                     a.FechaSolicitud,
                                     a.UsuarioSolicitud,
                                     a.NombreUsuarioSolicitud,
                                     a.AliadoSolicitud,
                                     a.OperacionSolicitud,
                                     a.FechaTransaccion,
                                     a.UsuarioTransaccion,
                                     a.NombreUsuarioTransaccion,
                                     a.CuentaCliente,
                                     a.TipoDeRequerimiento,
                                     a.RequiereAjuste,
                                     a.Nodo,
                                     a.Gestion,
                                     a.Subrazon,
                                     a.EstadoSolicitud,
                                     a.AliadoTecnico,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new VILSolicitudes());
                result[i].IdTransaccion = objetosResult[i].IdTransaccion;
                result[i].IdSolicitud = objetosResult[i].IdSolicitud;
                result[i].FechaSolicitud = objetosResult[i].FechaSolicitud;
                result[i].UsuarioSolicitud = objetosResult[i].UsuarioSolicitud;
                result[i].NombreUsuarioSolicitud = objetosResult[i].NombreUsuarioSolicitud;
                result[i].AliadoSolicitud = objetosResult[i].AliadoSolicitud;
                result[i].OperacionSolicitud = objetosResult[i].OperacionSolicitud;
                result[i].FechaTransaccion = objetosResult[i].FechaTransaccion;
                result[i].UsuarioTransaccion = objetosResult[i].UsuarioTransaccion;
                result[i].NombreUsuarioTransaccion = objetosResult[i].NombreUsuarioTransaccion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TipoDeRequerimiento = objetosResult[i].TipoDeRequerimiento;
                result[i].RequiereAjuste = objetosResult[i].RequiereAjuste;
                result[i].Nodo = objetosResult[i].Nodo;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Subrazon = objetosResult[i].Subrazon;
                result[i].EstadoSolicitud = objetosResult[i].EstadoSolicitud;
                result[i].AliadoTecnico = objetosResult[i].AliadoTecnico;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        //procesos admin
        public List<VIMTipoDeRequerimiento> ListaTiposDeRequerimientosAdmin()
        {
            DimeContext dimContext = new DimeContext();
            List<VIMTipoDeRequerimiento> result = new List<VIMTipoDeRequerimiento>();
            var objetosResult = (from a in dimContext.VIMTipoDeRequerimiento
                                 orderby a.TipoDeRequerimiento ascending
                                 select new
                                 {
                                     a.Id,
                                     a.TipoDeRequerimiento,
                                     a.Estado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new VIMTipoDeRequerimiento());
                result[i].Id = objetosResult[i].Id;
                result[i].TipoDeRequerimiento = objetosResult[i].TipoDeRequerimiento;
                result[i].Estado = objetosResult[i].Estado;

            }
            return result;
        }
        public List<VIMTipoDeEquipos> ListaTipoDeEquiposAdmin()
        {
            DimeContext dimContext = new DimeContext();
            List<VIMTipoDeEquipos> result = new List<VIMTipoDeEquipos>();
            var objetosResult = (from a in dimContext.VIMTipoDeEquipos
                                 orderby a.TipoDeEquipo ascending
                                 select new
                                 {
                                     a.Id,
                                     a.TipoDeEquipo,
                                     a.Estado

                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new VIMTipoDeEquipos());
                result[i].Id = objetosResult[i].Id;
                result[i].TipoDeEquipo = objetosResult[i].TipoDeEquipo;
                result[i].Estado = objetosResult[i].Estado;

            }
            return result;
        }
        public List<VIMGestion> ListaDeGestionAdmin()
        {
            DimeContext dimContext = new DimeContext();
            List<VIMGestion> result = new List<VIMGestion>();
            var objetosResult = (from a in dimContext.VIMGestion
                                 orderby a.Gestion ascending
                                 select new
                                 {
                                     a.IdGestion,
                                     a.Gestion,
                                     a.Estado

                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new VIMGestion());
                result[i].IdGestion = objetosResult[i].IdGestion;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Estado = objetosResult[i].Estado;

            }
            return result;
        }
        public List<VIMSubrazon> ListaSubrazonAdmin(decimal IdGestion)
        {
            DimeContext dimContext = new DimeContext();
            List<VIMSubrazon> result = new List<VIMSubrazon>();
            var objetosResult = (from a in dimContext.VIMSubrazon
                                 where a.IdGestion == IdGestion
                                 orderby a.Subrazon ascending
                                 select new
                                 {
                                     a.IdSubrazon,
                                     a.Subrazon,
                                     a.EstadoFinal,
                                     a.Estado

                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new VIMSubrazon());
                result[i].IdSubrazon = objetosResult[i].IdSubrazon;
                result[i].Subrazon = objetosResult[i].Subrazon;
                result[i].EstadoFinal = objetosResult[i].EstadoFinal;
                result[i].Estado = objetosResult[i].Estado;

            }
            return result;
        }
        public List<VIMAliadoTecnico> ListaAliadosTecnicosAdmin()
        {
            DimeContext dimContext = new DimeContext();
            List<VIMAliadoTecnico> result = new List<VIMAliadoTecnico>();
            var objetosResult = (from a in dimContext.VIMAliadoTecnico
                                 orderby a.AliadoTecnico ascending
                                 select new
                                 {
                                     a.IdAliado,
                                     a.AliadoTecnico,
                                     a.Estado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new VIMAliadoTecnico());
                result[i].IdAliado = objetosResult[i].IdAliado;
                result[i].AliadoTecnico = objetosResult[i].AliadoTecnico;
                result[i].Estado = objetosResult[i].Estado;

            }
            return result;
        }
        public void AgregarTiposDeRequerimientos(VIMTipoDeRequerimiento TipoRequerimiento)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            UnitOfWork.VIMTipoDeRequerimiento.Add(TipoRequerimiento);
            UnitOfWork.Complete();
            UnitOfWork.Dispose();
        }
        public void ActualizarTiposDeRequerimientos (VIMTipoDeRequerimiento TipoRequerimiento)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            VIMTipoDeRequerimiento TipoRequerimientoEncontrado= UnitOfWork.VIMTipoDeRequerimiento.Find(x=> x.Id==TipoRequerimiento.Id).FirstOrDefault();
            TipoRequerimientoEncontrado.TipoDeRequerimiento = TipoRequerimiento.TipoDeRequerimiento;
            TipoRequerimientoEncontrado.Estado = TipoRequerimiento.Estado;
            UnitOfWork.Complete();
            UnitOfWork.Dispose();
        }
        public void AgregarTipoDeEquipos(VIMTipoDeEquipos TipoEquipos)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            UnitOfWork.VIMTipoDeEquipos.Add(TipoEquipos);
            UnitOfWork.Complete();
            UnitOfWork.Dispose();
        }
        public void ActualizarTipoDeEquipos(VIMTipoDeEquipos TipoEquipos)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            VIMTipoDeEquipos Tipoequipoencontrado = UnitOfWork.VIMTipoDeEquipos.Find(x => x.Id == TipoEquipos.Id).FirstOrDefault();
            Tipoequipoencontrado.TipoDeEquipo = TipoEquipos.TipoDeEquipo;
            Tipoequipoencontrado.Estado = TipoEquipos.Estado;
            UnitOfWork.Complete();
            UnitOfWork.Dispose();
        }
        public void AgregarGestion(VIMGestion Gestion)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            UnitOfWork.VIMGestion.Add(Gestion);
            UnitOfWork.Complete();
            UnitOfWork.Dispose();
        }
        public void ActualizarGestion(VIMGestion Gestion)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            VIMGestion Gestionencontrada = UnitOfWork.VIMGestion.Find(x => x.IdGestion == Gestion.IdGestion).FirstOrDefault();
            Gestionencontrada.Gestion = Gestion.Gestion;
            Gestionencontrada.Estado = Gestion.Estado;
            UnitOfWork.Complete();
            UnitOfWork.Dispose();
        }
        public void AgregarSubrazon (VIMSubrazon DataSubrazon)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            UnitOfWork.VIMSubrazon.Add(DataSubrazon);
            UnitOfWork.Complete();
            UnitOfWork.Dispose();
        }
        public void ActualizarSubrazon(VIMSubrazon DataSubrazon)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            VIMSubrazon Subrazonencontrada = UnitOfWork.VIMSubrazon.Find(x => x.IdSubrazon == DataSubrazon.IdSubrazon).FirstOrDefault();
            Subrazonencontrada.IdGestion = DataSubrazon.IdGestion;
            Subrazonencontrada.Subrazon = DataSubrazon.Subrazon;
            Subrazonencontrada.EstadoFinal = DataSubrazon.EstadoFinal;
            Subrazonencontrada.Estado = DataSubrazon.Estado;
            UnitOfWork.Complete();
            UnitOfWork.Dispose();
        }
        public void AgregarAliadoTecnico(VIMAliadoTecnico DataAliado)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            UnitOfWork.VIMAliadoTecnico.Add(DataAliado);
            UnitOfWork.Complete();
            UnitOfWork.Dispose();

        }
        public void ActualizarAliadoTecnico(VIMAliadoTecnico DataAliado)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            VIMAliadoTecnico Aliadoencontrado = UnitOfWork.VIMAliadoTecnico.Find(x => x.IdAliado == DataAliado.IdAliado).FirstOrDefault();
            Aliadoencontrado.AliadoTecnico = DataAliado.AliadoTecnico;
            Aliadoencontrado.Estado = DataAliado.Estado;
            UnitOfWork.Complete();
            UnitOfWork.Dispose();
        }
        public VIMTipoDeRequerimiento TipoDeRequerimientoPorId(int Id)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            VIMTipoDeRequerimiento Resultado = UnitOfWork.VIMTipoDeRequerimiento.Get(Id);
            return Resultado;
        }
        public VIMTipoDeEquipos TipoDeEquiposPorId(int Id)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            VIMTipoDeEquipos Resultado = UnitOfWork.VIMTipoDeEquipos.Get(Id);
            return Resultado;
        }
        public VIMGestion GestionPorId(int Id)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            VIMGestion Resultado = UnitOfWork.VIMGestion.Get(Id);
            return Resultado;
        }
        public VIMSubrazon SubrazonPorId(int Id)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            VIMSubrazon Resultado = UnitOfWork.VIMSubrazon.Get(Id);
            return Resultado;
        }
        public VIMAliadoTecnico AliadoTecnicoPorId(int Id)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            VIMAliadoTecnico Resultado = UnitOfWork.VIMAliadoTecnico.Get(Id);
            return Resultado;
        }
    }
}
