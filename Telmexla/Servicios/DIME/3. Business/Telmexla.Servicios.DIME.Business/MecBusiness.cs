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
    public class MecBusiness
    {
        public void IsertarMonitoreo(MecMonitoreosP Monitoreo)
        {
            //trae la informacion de los procesos y las lineas seleccionadas
            UnitOfWork UnitOfWorkProceso = new UnitOfWork(new DimeContext());
            Monitoreo.NombreProceso = UnitOfWorkProceso.MecProcesos.Get(Monitoreo.IdProceso).Proceso;
            Monitoreo.NombreLinea = UnitOfWorkProceso.MecLineas.Get(Monitoreo.IdLinea).NombreLinea;
            UnitOfWorkProceso.Complete();
            UnitOfWorkProceso.Dispose();

            //inserta monitoreo principal
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            Monitoreo.FechaGestion = DateTime.Now;
            Monitoreo.EstadoMonitoreo = "REGISTRADO";
            unitWork.MecMonitoreosP.Add(Monitoreo);
            unitWork.Complete();
            unitWork.Dispose();

            //inserta monitoreo al log
            UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
            MecMonitoreosL MonitoreoLog = new MecMonitoreosL();

            MonitoreoLog.IdMonitoreo = Monitoreo.IdMonitoreo;
            MonitoreoLog.FechaGestion = Monitoreo.FechaGestion;
            MonitoreoLog.UsuarioGestion = Monitoreo.UsuarioGestion;
            MonitoreoLog.CedulaUsuarioGestion = Monitoreo.CedulaUsuarioGestion;
            MonitoreoLog.NombreUsuarioGestion = Monitoreo.NombreUsuarioGestion;
            MonitoreoLog.AliadoGestion = Monitoreo.AliadoGestion;
            MonitoreoLog.IdProceso = Monitoreo.IdProceso;
            MonitoreoLog.NombreProceso = Monitoreo.NombreProceso;
            MonitoreoLog.IdLinea = Monitoreo.IdLinea;
            MonitoreoLog.NombreLinea = Monitoreo.NombreLinea;
            MonitoreoLog.UsuarioMonitoreado = Monitoreo.UsuarioMonitoreado;
            MonitoreoLog.NombreUsuarioMonitoreado = Monitoreo.NombreUsuarioMonitoreado;
            MonitoreoLog.OperacionUsuarioMonitoreado = Monitoreo.OperacionUsuarioMonitoreado;
            MonitoreoLog.AliadoUsuarioMonitoreado = Monitoreo.AliadoUsuarioMonitoreado;
            MonitoreoLog.CuentaCliente = Monitoreo.CuentaCliente;
            MonitoreoLog.Division = Monitoreo.Division;
            MonitoreoLog.Area = Monitoreo.Area;
            MonitoreoLog.Zona = Monitoreo.Zona;
            MonitoreoLog.Comunidad = Monitoreo.Comunidad;
            MonitoreoLog.TipoCliente = Monitoreo.TipoCliente;
            MonitoreoLog.DescripcionTipoCliente = Monitoreo.DescripcionTipoCliente;
            MonitoreoLog.MarcacionRegistradaRR = Monitoreo.MarcacionRegistradaRR;
            MonitoreoLog.MarcacionCorrectaRR = Monitoreo.MarcacionCorrectaRR;
            MonitoreoLog.CampoOpcional1 = Monitoreo.CampoOpcional1;
            MonitoreoLog.CampoOpcional2 = Monitoreo.CampoOpcional2;
            MonitoreoLog.CampoOpcional3 = Monitoreo.CampoOpcional3;
            MonitoreoLog.CampoOpcional4 = Monitoreo.CampoOpcional4;
            MonitoreoLog.CampoOpcional5 = Monitoreo.CampoOpcional5;
            MonitoreoLog.NotaObtenida = Monitoreo.NotaObtenida;
            MonitoreoLog.TipoDeAlarma = Monitoreo.TipoDeAlarma;
            MonitoreoLog.RegistroMonitoreo = Monitoreo.RegistroMonitoreo;
            MonitoreoLog.MotivoAlarma = Monitoreo.MotivoAlarma;
            MonitoreoLog.AnalisisDeGestion = Monitoreo.AnalisisDeGestion;
            MonitoreoLog.AccionEmprender = Monitoreo.AccionEmprender;
            MonitoreoLog.EtiquetaDeLlamada = Monitoreo.EtiquetaDeLlamada;
            MonitoreoLog.IdListaDistribucion = Monitoreo.IdListaDistribucion;
            MonitoreoLog.EstadoMonitoreo = Monitoreo.EstadoMonitoreo;

            unitWorkLog.MecMonitoreosL.Add(MonitoreoLog);
            unitWorkLog.Complete();
            unitWorkLog.Dispose();
        }
    }
}
