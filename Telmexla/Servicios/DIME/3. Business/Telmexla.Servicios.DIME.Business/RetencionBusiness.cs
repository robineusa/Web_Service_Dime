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
        public decimal RegistrarSolicitudRetencion(RSPSeguimientos Solicitud)
        {
            //registra solicitud
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            Solicitud.FechaSolicitud = DateTime.Now;
            Solicitud.FechaActualizacion = Solicitud.FechaSolicitud;
            Solicitud.UsuarioActualizacion = Solicitud.UsuarioSolicitud;
            Solicitud.NombreUsuarioActualizacion = Solicitud.NombreUsuarioSolicitud;

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

    }
}
