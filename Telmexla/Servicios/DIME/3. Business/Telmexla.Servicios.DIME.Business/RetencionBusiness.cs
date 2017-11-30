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
    public class RetencionBusiness
    {
        public decimal RegistrarSolicitudRetencionFormulario(RSPSeguimientos Solicitud)
        {
            //trae datos de arboles
            UnitOfWork unitWorkMaestros = new UnitOfWork(new DimeContext());
            Solicitud.TipoEscalamiento = unitWorkMaestros.RSMArboles.Get(Convert.ToInt32(Solicitud.TipoEscalamiento)).Descripcion;
            Solicitud.DetalleEscalamiento = unitWorkMaestros.RSMArboles.Get(Convert.ToInt32(Solicitud.DetalleEscalamiento)).Descripcion;
            Solicitud.MotivoEscalamiento = unitWorkMaestros.RSMArboles.Get(Convert.ToInt32(Solicitud.MotivoEscalamiento)).Descripcion;
            Solicitud.RazonEscalamiento = unitWorkMaestros.RSMArboles.Get(Convert.ToInt32(Solicitud.RazonEscalamiento)).Descripcion;
            Solicitud.SubRazonEscalamiento = unitWorkMaestros.RSMArboles.Get(Convert.ToInt32(Solicitud.SubRazonEscalamiento)).Descripcion;
            unitWorkMaestros.Complete();
            unitWorkMaestros.Dispose();


            //registra solicitud
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            Solicitud.FechaSolicitud = DateTime.Now;
            Solicitud.FechaActualizacion = Solicitud.FechaSolicitud;
            Solicitud.UsuarioActualizacion = Solicitud.UsuarioSolicitud;
            Solicitud.NombreUsuarioActualizacion = Solicitud.NombreUsuarioSolicitud;
            Solicitud.Estrategia1 = "NO APLICA";
            Solicitud.Estrategia2 = "NO APLICA";
            Solicitud.Estrategia3 = "NO APLICA";
            Solicitud.EstadoSolicitud = "PENDIENTE";

            unitOfWork.RSPSeguimientos.Add(Solicitud);
            unitOfWork.Complete();
            unitOfWork.Dispose();

            //registra log
            UnitOfWork unitOfWorkLog = new UnitOfWork(new DimeContext());
            RSLSeguimientos Log = new RSLSeguimientos();

            Log.IdSolicitud = Solicitud.IdSolicitud;
            Log.FechaTransaccion = Solicitud.FechaSolicitud;
            Log.UsuarioTransaccion = Solicitud.UsuarioSolicitud;
            Log.NombreUsuarioTransaccion = Solicitud.NombreUsuarioSolicitud;
            Log.AliadoTransaccion = Solicitud.AliadoSolicitud;
            Log.OperacionTransaccion = Solicitud.OperacionSolicitud;
            Log.LineaTransaccion = Solicitud.LineaSolicitud;
            Log.CuentaCliente = Solicitud.CuentaCliente;
            Log.TipoEscalamiento = Solicitud.TipoEscalamiento;
            Log.DetalleEscalamiento = Solicitud.DetalleEscalamiento;
            Log.MotivoEscalamiento = Solicitud.MotivoEscalamiento;
            Log.RazonEscalamiento = Solicitud.RazonEscalamiento;
            Log.SubRazonEscalamiento = Solicitud.SubRazonEscalamiento;
            Log.Estrategia1 = Solicitud.Estrategia1;
            Log.Estrategia2 = Solicitud.Estrategia2;
            Log.Estrategia3 = Solicitud.Estrategia3;
            Log.TicketRr = Solicitud.TicketRr;
            Log.EstadoSolicitud = Solicitud.EstadoSolicitud;
            Log.Observaciones = Solicitud.Observaciones;

            unitOfWorkLog.RSLSeguimientos.Add(Log);
            unitOfWorkLog.Complete();
            unitOfWorkLog.Dispose();

            return Solicitud.IdSolicitud;
        }
        public decimal RegistrarSolicitudRetencionAutomatico(RSPSeguimientos Solicitud)
        {
            //registra solicitud
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            Solicitud.FechaSolicitud = DateTime.Now;
            Solicitud.FechaActualizacion = Solicitud.FechaSolicitud;
            Solicitud.UsuarioActualizacion = Solicitud.UsuarioSolicitud;
            Solicitud.NombreUsuarioActualizacion = Solicitud.NombreUsuarioSolicitud;
            Solicitud.EstadoSolicitud = "PENDIENTE";

            unitOfWork.RSPSeguimientos.Add(Solicitud);
            unitOfWork.Complete();
            unitOfWork.Dispose();

            //registra log
            UnitOfWork unitOfWorkLog = new UnitOfWork(new DimeContext());
            RSLSeguimientos Log = new RSLSeguimientos();

            Log.IdSolicitud = Solicitud.IdSolicitud;
            Log.FechaTransaccion = Solicitud.FechaSolicitud;
            Log.UsuarioTransaccion = Solicitud.UsuarioSolicitud;
            Log.NombreUsuarioTransaccion = Solicitud.NombreUsuarioSolicitud;
            Log.AliadoTransaccion = Solicitud.AliadoSolicitud;
            Log.OperacionTransaccion = Solicitud.OperacionSolicitud;
            Log.LineaTransaccion = Solicitud.LineaSolicitud;
            Log.CuentaCliente = Solicitud.CuentaCliente;
            Log.TipoEscalamiento = Solicitud.TipoEscalamiento;
            Log.DetalleEscalamiento = Solicitud.DetalleEscalamiento;
            Log.MotivoEscalamiento = Solicitud.MotivoEscalamiento;
            Log.RazonEscalamiento = Solicitud.RazonEscalamiento;
            Log.SubRazonEscalamiento = Solicitud.SubRazonEscalamiento;
            Log.Estrategia1 = Solicitud.Estrategia1;
            Log.Estrategia2 = Solicitud.Estrategia2;
            Log.Estrategia3 = Solicitud.Estrategia3;
            Log.TicketRr = Solicitud.TicketRr;
            Log.EstadoSolicitud = Solicitud.EstadoSolicitud;
            Log.Observaciones = Solicitud.Observaciones;

            unitOfWorkLog.RSLSeguimientos.Add(Log);
            unitOfWorkLog.Complete();
            unitOfWorkLog.Dispose();

            return Solicitud.IdSolicitud;
        }
        public List<RSMArboles> ListasDeArbolesRetencion(decimal IdPadre)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<RSMArboles> Lista = new List<RSMArboles>();
            Lista = unitOfWork.RSMArboles.Find(x => x.IdPadre == IdPadre && x.Estado.Equals("ACTIVO") && x.Descripcion != "APLICACIÓN DE OFRECIMIENTOS").ToList();
            return Lista;
        }
        //procesos administrador
        public List<RSMArboles> ListasDeArbolesRetencionAdmin(decimal IdPadre)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<RSMArboles> Lista = new List<RSMArboles>();
            Lista = unitOfWork.RSMArboles.Find(x => x.IdPadre == IdPadre).ToList();
            return Lista;
        }
        public void ActualizarArbolRetencion(RSMArboles Arbol)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            RSMArboles ArbolActualizable = unitOfWork.RSMArboles.Find(x => x.IdArbol == Arbol.IdArbol).FirstOrDefault();
            if (ArbolActualizable.IdArbol > 0)
            {
                ArbolActualizable.IdPadre = Arbol.IdPadre;
                ArbolActualizable.Descripcion = Arbol.Descripcion;
                ArbolActualizable.Estado = Arbol.Estado;
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void RegistrarNuevoArbol(RSMArboles Arbol)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            unitOfWork.RSMArboles.Add(Arbol);
            unitOfWork.Complete();
            unitOfWork.Dispose();
        }
        public RSMArboles TraerArbolPorId(decimal IdArbol)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            RSMArboles Arbol = unitOfWork.RSMArboles.Find(x => x.IdArbol == IdArbol).FirstOrDefault();
            if (Arbol.IdArbol > 0)
            {
                return Arbol;
            }
            else
            {
                return new RSMArboles();
            }
        }
        public List<RSPSeguimientos> ConsultaAdministradorPricipal(DateTime FechaInicio, DateTime FechaFin)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<RSPSeguimientos> Lista = new List<RSPSeguimientos>();
            Lista = unitOfWork.RSPSeguimientos.Find(x => x.FechaSolicitud >= FechaInicio && x.FechaSolicitud <= FechaFin).ToList();
            return Lista;

        }
        public List<RSLSeguimientos> ConsultaAdministradorLog(DateTime FechaInicio, DateTime FechaFin)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<RSLSeguimientos> Lista = new List<RSLSeguimientos>();
            Lista = unitOfWork.RSLSeguimientos.Find(x => x.FechaTransaccion >= FechaInicio && x.FechaTransaccion <= FechaFin).ToList();
            return Lista;

        }

    }
}
