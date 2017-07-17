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
            Monitoreo.TipoDeAlarma = UnitOfWorkProceso.MecTipoAlarmas.Get(Convert.ToInt32(Monitoreo.TipoDeAlarma)).NombreAlarma;

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
            MonitoreoLog.MotivoLlamada = Monitoreo.MotivoLlamada;
            MonitoreoLog.AnalisisDeGestion = Monitoreo.AnalisisDeGestion;
            MonitoreoLog.AccionEmprender = Monitoreo.AccionEmprender;
            MonitoreoLog.EtiquetaDeLlamada = Monitoreo.EtiquetaDeLlamada;
            MonitoreoLog.IdListaDistribucion = Monitoreo.IdListaDistribucion;
            MonitoreoLog.EstadoMonitoreo = Monitoreo.EstadoMonitoreo;

            unitWorkLog.MecMonitoreosL.Add(MonitoreoLog);
            unitWorkLog.Complete();
            unitWorkLog.Dispose();
        }
        public List<MecProcesos> ListaProcesosMec()
        {
            DimeContext dimContext = new DimeContext();
            List<MecProcesos> result = new List<MecProcesos>();
            var objetosResult = (from a in dimContext.MecProcesos
                                 where a.Estado.Equals("ACTIVO")
                                 orderby a.Proceso ascending
                                 select new
                                 {
                                     a.IdProceso,
                                     a.Proceso
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new MecProcesos());
                result[i].IdProceso = objetosResult[i].IdProceso;
                result[i].Proceso = objetosResult[i].Proceso;
            }
            return result;
        }
        public List<MecLineas> ListaLineasMec(int IdProceso)
        {
            DimeContext dimContext = new DimeContext();
            List<MecLineas> result = new List<MecLineas>();
            var objetosResult = (from a in dimContext.MecLineas
                                 where a.IdProceso.Equals(IdProceso) && a.Estado.Equals("ACTIVO")
                                 orderby a.NombreLinea ascending
                                 select new
                                 {
                                     a.IdLinea,
                                     a.NombreLinea
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new MecLineas());
                result[i].IdLinea = objetosResult[i].IdLinea;
                result[i].NombreLinea = objetosResult[i].NombreLinea;
            }
            return result;
        }
        public List<MecListasDistribucion> ListasCorreosMec(int IdLinea)
        {
            DimeContext dimContext = new DimeContext();
            List<MecListasDistribucion> result = new List<MecListasDistribucion>();
            var objetosResult = (from a in dimContext.MecListasDistribucion
                                 where a.IdLinea.Equals(IdLinea)
                                 select new
                                 {
                                     a.IdLista,
                                     a.Destinatarios
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new MecListasDistribucion());
                result[i].IdLista = objetosResult[i].IdLista;
                result[i].Destinatarios = objetosResult[i].Destinatarios;
            }
            return result;
        }
        public List<MecTipoAlarmas> ListaTipoAlarmasMec()
        {
            DimeContext dimContext = new DimeContext();
            List<MecTipoAlarmas> result = new List<MecTipoAlarmas>();
            var objetosResult = (from a in dimContext.MecTipoAlarmas
                                 orderby a.NombreAlarma ascending
                                 select new
                                 {
                                     a.IdAlarma,
                                     a.NombreAlarma
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new MecTipoAlarmas());
                result[i].IdAlarma = objetosResult[i].IdAlarma;
                result[i].NombreAlarma = objetosResult[i].NombreAlarma;
            }
            return result;
        }
        public MecListasDistribucion DestinatariosMec(int IdLista)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            return UnitOfWork.MecListasDistribucion.Get(IdLista);
        }
        public void ActualizarMonitoreo(MecMonitoreosP Monitoreo)
        {
            //trae la informacion de los procesos y las lineas seleccionadas
            UnitOfWork UnitOfWorkProceso = new UnitOfWork(new DimeContext());
            Monitoreo.NombreProceso = UnitOfWorkProceso.MecProcesos.Get(Monitoreo.IdProceso).Proceso;
            Monitoreo.NombreLinea = UnitOfWorkProceso.MecLineas.Get(Monitoreo.IdLinea).NombreLinea;
            Monitoreo.TipoDeAlarma = UnitOfWorkProceso.MecTipoAlarmas.Get(Convert.ToInt32(Monitoreo.TipoDeAlarma)).NombreAlarma;

            UnitOfWorkProceso.Complete();
            UnitOfWorkProceso.Dispose();

            //busca monitoreo para actualizar
            UnitOfWork UnitOfWorkMonitoreoActualizable = new UnitOfWork(new DimeContext());
            MecMonitoreosP MonitoreoActualizable = UnitOfWorkMonitoreoActualizable.MecMonitoreosP.Find(c=> c.IdMonitoreo == Monitoreo.IdMonitoreo).FirstOrDefault();
            var NuevoEstadoMonitoreo = "ACTUALIZADO";

            
            MonitoreoActualizable.IdProceso = Monitoreo.IdProceso;
            MonitoreoActualizable.NombreProceso = Monitoreo.NombreProceso;
            MonitoreoActualizable.IdLinea = Monitoreo.IdLinea;
            MonitoreoActualizable.NombreLinea = Monitoreo.NombreLinea;
            MonitoreoActualizable.UsuarioMonitoreado = Monitoreo.UsuarioMonitoreado;
            MonitoreoActualizable.NombreUsuarioMonitoreado = Monitoreo.NombreUsuarioMonitoreado;
            MonitoreoActualizable.OperacionUsuarioMonitoreado = Monitoreo.OperacionUsuarioMonitoreado;
            MonitoreoActualizable.AliadoUsuarioMonitoreado = Monitoreo.AliadoUsuarioMonitoreado;
            MonitoreoActualizable.CuentaCliente = Monitoreo.CuentaCliente;
            MonitoreoActualizable.Division = Monitoreo.Division;
            MonitoreoActualizable.Area = Monitoreo.Area;
            MonitoreoActualizable.Zona = Monitoreo.Zona;
            MonitoreoActualizable.Comunidad = Monitoreo.Comunidad;
            MonitoreoActualizable.TipoCliente = Monitoreo.TipoCliente;
            MonitoreoActualizable.DescripcionTipoCliente = Monitoreo.DescripcionTipoCliente;
            MonitoreoActualizable.MarcacionRegistradaRR = Monitoreo.MarcacionRegistradaRR;
            MonitoreoActualizable.MarcacionCorrectaRR = Monitoreo.MarcacionCorrectaRR;
            MonitoreoActualizable.CampoOpcional1 = Monitoreo.CampoOpcional1;
            MonitoreoActualizable.CampoOpcional2 = Monitoreo.CampoOpcional2;
            MonitoreoActualizable.CampoOpcional3 = Monitoreo.CampoOpcional3;
            MonitoreoActualizable.CampoOpcional4 = Monitoreo.CampoOpcional4;
            MonitoreoActualizable.CampoOpcional5 = Monitoreo.CampoOpcional5;
            MonitoreoActualizable.NotaObtenida = Monitoreo.NotaObtenida;
            MonitoreoActualizable.TipoDeAlarma = Monitoreo.TipoDeAlarma;
            MonitoreoActualizable.RegistroMonitoreo = Monitoreo.RegistroMonitoreo;
            MonitoreoActualizable.MotivoLlamada = Monitoreo.MotivoLlamada;
            MonitoreoActualizable.AnalisisDeGestion = Monitoreo.AnalisisDeGestion;
            MonitoreoActualizable.AccionEmprender = Monitoreo.AccionEmprender;
            MonitoreoActualizable.EtiquetaDeLlamada = Monitoreo.EtiquetaDeLlamada;
            MonitoreoActualizable.IdListaDistribucion = Monitoreo.IdListaDistribucion;
            MonitoreoActualizable.EstadoMonitoreo = NuevoEstadoMonitoreo;

            UnitOfWorkMonitoreoActualizable.Complete();
            UnitOfWorkMonitoreoActualizable.Dispose();

            //inserta monitoreo al log
            UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
            MecMonitoreosL MonitoreoLog = new MecMonitoreosL();
            
            var FechaGestion = DateTime.Now;

            MonitoreoLog.IdMonitoreo = Monitoreo.IdMonitoreo;
            MonitoreoLog.FechaGestion = FechaGestion;
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
            MonitoreoLog.MotivoLlamada = Monitoreo.MotivoLlamada;
            MonitoreoLog.AnalisisDeGestion = Monitoreo.AnalisisDeGestion;
            MonitoreoLog.AccionEmprender = Monitoreo.AccionEmprender;
            MonitoreoLog.EtiquetaDeLlamada = Monitoreo.EtiquetaDeLlamada;
            MonitoreoLog.IdListaDistribucion = Monitoreo.IdListaDistribucion;
            MonitoreoLog.EstadoMonitoreo = NuevoEstadoMonitoreo;

            unitWorkLog.MecMonitoreosL.Add(MonitoreoLog);
            unitWorkLog.Complete();
            unitWorkLog.Dispose();

        }
        public List<MecMonitoreosP> ConsultaAdminMonitoreosPrincipal(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<MecMonitoreosP> result = new List<MecMonitoreosP>();
            var objetosResult = (from a in dimContext.MecMonitoreosP
                                 where a.FechaGestion>= FechaInicial && a.FechaGestion<= FechaFinal
                                 orderby a.IdMonitoreo ascending
                                 select new
                                 {
                                     a.IdMonitoreo,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     a.CedulaUsuarioGestion,
                                     a.NombreUsuarioGestion,
                                     a.AliadoGestion,
                                     a.IdProceso,
                                     a.NombreProceso,
                                     a.IdLinea,
                                     a.NombreLinea,
                                     a.UsuarioMonitoreado,
                                     a.NombreUsuarioMonitoreado,
                                     a.OperacionUsuarioMonitoreado,
                                     a.AliadoUsuarioMonitoreado,
                                     a.CuentaCliente,
                                     a.Division,
                                     a.Area,
                                     a.Zona,
                                     a.Comunidad,
                                     a.TipoCliente,
                                     a.DescripcionTipoCliente,
                                    a.MarcacionRegistradaRR,
                                    a.MarcacionCorrectaRR,
                                    a.CampoOpcional1,
                                    a.CampoOpcional2,
                                    a.CampoOpcional3,
                                    a.CampoOpcional4,
                                    a.CampoOpcional5,
                                    a.NotaObtenida,
                                    a.TipoDeAlarma,
                                    a.RegistroMonitoreo,
                                    a.MotivoLlamada,
                                    a.AnalisisDeGestion,
                                    a.AccionEmprender,
                                    a.EtiquetaDeLlamada,
                                    a.IdListaDistribucion,
                                    a.EstadoMonitoreo
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new MecMonitoreosP());
                result[i].IdMonitoreo = objetosResult[i].IdMonitoreo;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].CedulaUsuarioGestion = objetosResult[i].CedulaUsuarioGestion;
                result[i].NombreUsuarioGestion = objetosResult[i].NombreUsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].IdProceso = objetosResult[i].IdProceso;
                result[i].NombreProceso = objetosResult[i].NombreProceso;
                result[i].IdLinea = objetosResult[i].IdLinea;
                result[i].NombreLinea = objetosResult[i].NombreLinea;
                result[i].UsuarioMonitoreado = objetosResult[i].UsuarioMonitoreado;
                result[i].NombreUsuarioMonitoreado = objetosResult[i].NombreUsuarioMonitoreado;
                result[i].OperacionUsuarioMonitoreado = objetosResult[i].OperacionUsuarioMonitoreado;
                result[i].AliadoUsuarioMonitoreado = objetosResult[i].AliadoUsuarioMonitoreado;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].Division = objetosResult[i].Division;
                result[i].Area = objetosResult[i].Area;
                result[i].Zona = objetosResult[i].Zona;
                result[i].Comunidad = objetosResult[i].Comunidad;
                result[i].TipoCliente = objetosResult[i].TipoCliente;
                result[i].DescripcionTipoCliente = objetosResult[i].DescripcionTipoCliente;
                result[i].MarcacionRegistradaRR = objetosResult[i].MarcacionRegistradaRR;
                result[i].MarcacionCorrectaRR = objetosResult[i].MarcacionCorrectaRR;
                result[i].CampoOpcional1 = objetosResult[i].CampoOpcional1;
                result[i].CampoOpcional2 = objetosResult[i].CampoOpcional2;
                result[i].CampoOpcional3 = objetosResult[i].CampoOpcional3;
                result[i].CampoOpcional4 = objetosResult[i].CampoOpcional4;
                result[i].CampoOpcional5 = objetosResult[i].CampoOpcional5;
                result[i].NotaObtenida = objetosResult[i].NotaObtenida;
                result[i].TipoDeAlarma = objetosResult[i].TipoDeAlarma;
                result[i].RegistroMonitoreo = objetosResult[i].RegistroMonitoreo;
                result[i].MotivoLlamada = objetosResult[i].MotivoLlamada;
                result[i].AnalisisDeGestion = objetosResult[i].AnalisisDeGestion;
                result[i].AccionEmprender = objetosResult[i].AccionEmprender;
                result[i].EtiquetaDeLlamada = objetosResult[i].EtiquetaDeLlamada;
                result[i].IdListaDistribucion = objetosResult[i].IdListaDistribucion;
                result[i].EstadoMonitoreo = objetosResult[i].EstadoMonitoreo;
            }
            return result;
        }
        public List<MecMonitoreosL> ConsultaAdminMonitoreosLog(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<MecMonitoreosL> result = new List<MecMonitoreosL>();
            var objetosResult = (from a in dimContext.MecMonitoreosL
                                 where a.FechaGestion >= FechaInicial && a.FechaGestion <= FechaFinal
                                 orderby a.IdMonitoreo ascending
                                 select new
                                 {
                                     a.Id,
                                     a.IdMonitoreo,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     a.CedulaUsuarioGestion,
                                     a.NombreUsuarioGestion,
                                     a.AliadoGestion,
                                     a.IdProceso,
                                     a.NombreProceso,
                                     a.IdLinea,
                                     a.NombreLinea,
                                     a.UsuarioMonitoreado,
                                     a.NombreUsuarioMonitoreado,
                                     a.OperacionUsuarioMonitoreado,
                                     a.AliadoUsuarioMonitoreado,
                                     a.CuentaCliente,
                                     a.Division,
                                     a.Area,
                                     a.Zona,
                                     a.Comunidad,
                                     a.TipoCliente,
                                     a.DescripcionTipoCliente,
                                     a.MarcacionRegistradaRR,
                                     a.MarcacionCorrectaRR,
                                     a.CampoOpcional1,
                                     a.CampoOpcional2,
                                     a.CampoOpcional3,
                                     a.CampoOpcional4,
                                     a.CampoOpcional5,
                                     a.NotaObtenida,
                                     a.TipoDeAlarma,
                                     a.RegistroMonitoreo,
                                     a.MotivoLlamada,
                                     a.AnalisisDeGestion,
                                     a.AccionEmprender,
                                     a.EtiquetaDeLlamada,
                                     a.IdListaDistribucion,
                                     a.EstadoMonitoreo
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new MecMonitoreosL());
                result[i].Id = objetosResult[i].Id;
                result[i].IdMonitoreo = objetosResult[i].IdMonitoreo;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].CedulaUsuarioGestion = objetosResult[i].CedulaUsuarioGestion;
                result[i].NombreUsuarioGestion = objetosResult[i].NombreUsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].IdProceso = objetosResult[i].IdProceso;
                result[i].NombreProceso = objetosResult[i].NombreProceso;
                result[i].IdLinea = objetosResult[i].IdLinea;
                result[i].NombreLinea = objetosResult[i].NombreLinea;
                result[i].UsuarioMonitoreado = objetosResult[i].UsuarioMonitoreado;
                result[i].NombreUsuarioMonitoreado = objetosResult[i].NombreUsuarioMonitoreado;
                result[i].OperacionUsuarioMonitoreado = objetosResult[i].OperacionUsuarioMonitoreado;
                result[i].AliadoUsuarioMonitoreado = objetosResult[i].AliadoUsuarioMonitoreado;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].Division = objetosResult[i].Division;
                result[i].Area = objetosResult[i].Area;
                result[i].Zona = objetosResult[i].Zona;
                result[i].Comunidad = objetosResult[i].Comunidad;
                result[i].TipoCliente = objetosResult[i].TipoCliente;
                result[i].DescripcionTipoCliente = objetosResult[i].DescripcionTipoCliente;
                result[i].MarcacionRegistradaRR = objetosResult[i].MarcacionRegistradaRR;
                result[i].MarcacionCorrectaRR = objetosResult[i].MarcacionCorrectaRR;
                result[i].CampoOpcional1 = objetosResult[i].CampoOpcional1;
                result[i].CampoOpcional2 = objetosResult[i].CampoOpcional2;
                result[i].CampoOpcional3 = objetosResult[i].CampoOpcional3;
                result[i].CampoOpcional4 = objetosResult[i].CampoOpcional4;
                result[i].CampoOpcional5 = objetosResult[i].CampoOpcional5;
                result[i].NotaObtenida = objetosResult[i].NotaObtenida;
                result[i].TipoDeAlarma = objetosResult[i].TipoDeAlarma;
                result[i].RegistroMonitoreo = objetosResult[i].RegistroMonitoreo;
                result[i].MotivoLlamada = objetosResult[i].MotivoLlamada;
                result[i].AnalisisDeGestion = objetosResult[i].AnalisisDeGestion;
                result[i].AccionEmprender = objetosResult[i].AccionEmprender;
                result[i].EtiquetaDeLlamada = objetosResult[i].EtiquetaDeLlamada;
                result[i].IdListaDistribucion = objetosResult[i].IdListaDistribucion;
                result[i].EstadoMonitoreo = objetosResult[i].EstadoMonitoreo;
            }
            return result;
        }
        public MecMonitoreosP ConsultarMonitoreoPorId(int IdMonitoreo)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            return UnitOfWork.MecMonitoreosP.Get(IdMonitoreo);
            
        }
        public List<MecMonitoreosP> ConsultaAgenteMonitoreosPrincipal(DateTime FechaInicial, DateTime FechaFinal, string UsuarioGestion)
        {
            DimeContext dimContext = new DimeContext();
            List<MecMonitoreosP> result = new List<MecMonitoreosP>();
            var objetosResult = (from a in dimContext.MecMonitoreosP
                                 where a.FechaGestion >= FechaInicial && a.FechaGestion <= FechaFinal && a.UsuarioGestion.Equals(UsuarioGestion)
                                 orderby a.IdMonitoreo ascending
                                 select new
                                 {
                                     a.IdMonitoreo,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     a.CedulaUsuarioGestion,
                                     a.NombreUsuarioGestion,
                                     a.AliadoGestion,
                                     a.IdProceso,
                                     a.NombreProceso,
                                     a.IdLinea,
                                     a.NombreLinea,
                                     a.UsuarioMonitoreado,
                                     a.NombreUsuarioMonitoreado,
                                     a.OperacionUsuarioMonitoreado,
                                     a.AliadoUsuarioMonitoreado,
                                     a.CuentaCliente,
                                     a.Division,
                                     a.Area,
                                     a.Zona,
                                     a.Comunidad,
                                     a.TipoCliente,
                                     a.DescripcionTipoCliente,
                                     a.MarcacionRegistradaRR,
                                     a.MarcacionCorrectaRR,
                                     a.CampoOpcional1,
                                     a.CampoOpcional2,
                                     a.CampoOpcional3,
                                     a.CampoOpcional4,
                                     a.CampoOpcional5,
                                     a.NotaObtenida,
                                     a.TipoDeAlarma,
                                     a.RegistroMonitoreo,
                                     a.MotivoLlamada,
                                     a.AnalisisDeGestion,
                                     a.AccionEmprender,
                                     a.EtiquetaDeLlamada,
                                     a.IdListaDistribucion,
                                     a.EstadoMonitoreo
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new MecMonitoreosP());
                result[i].IdMonitoreo = objetosResult[i].IdMonitoreo;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].CedulaUsuarioGestion = objetosResult[i].CedulaUsuarioGestion;
                result[i].NombreUsuarioGestion = objetosResult[i].NombreUsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].IdProceso = objetosResult[i].IdProceso;
                result[i].NombreProceso = objetosResult[i].NombreProceso;
                result[i].IdLinea = objetosResult[i].IdLinea;
                result[i].NombreLinea = objetosResult[i].NombreLinea;
                result[i].UsuarioMonitoreado = objetosResult[i].UsuarioMonitoreado;
                result[i].NombreUsuarioMonitoreado = objetosResult[i].NombreUsuarioMonitoreado;
                result[i].OperacionUsuarioMonitoreado = objetosResult[i].OperacionUsuarioMonitoreado;
                result[i].AliadoUsuarioMonitoreado = objetosResult[i].AliadoUsuarioMonitoreado;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].Division = objetosResult[i].Division;
                result[i].Area = objetosResult[i].Area;
                result[i].Zona = objetosResult[i].Zona;
                result[i].Comunidad = objetosResult[i].Comunidad;
                result[i].TipoCliente = objetosResult[i].TipoCliente;
                result[i].DescripcionTipoCliente = objetosResult[i].DescripcionTipoCliente;
                result[i].MarcacionRegistradaRR = objetosResult[i].MarcacionRegistradaRR;
                result[i].MarcacionCorrectaRR = objetosResult[i].MarcacionCorrectaRR;
                result[i].CampoOpcional1 = objetosResult[i].CampoOpcional1;
                result[i].CampoOpcional2 = objetosResult[i].CampoOpcional2;
                result[i].CampoOpcional3 = objetosResult[i].CampoOpcional3;
                result[i].CampoOpcional4 = objetosResult[i].CampoOpcional4;
                result[i].CampoOpcional5 = objetosResult[i].CampoOpcional5;
                result[i].NotaObtenida = objetosResult[i].NotaObtenida;
                result[i].TipoDeAlarma = objetosResult[i].TipoDeAlarma;
                result[i].RegistroMonitoreo = objetosResult[i].RegistroMonitoreo;
                result[i].MotivoLlamada = objetosResult[i].MotivoLlamada;
                result[i].AnalisisDeGestion = objetosResult[i].AnalisisDeGestion;
                result[i].AccionEmprender = objetosResult[i].AccionEmprender;
                result[i].EtiquetaDeLlamada = objetosResult[i].EtiquetaDeLlamada;
                result[i].IdListaDistribucion = objetosResult[i].IdListaDistribucion;
                result[i].EstadoMonitoreo = objetosResult[i].EstadoMonitoreo;
            }
            return result;
        }
        public void RegistrarMacroproceso(MecProcesos proceso)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            unitWork.MecProcesos.Add(proceso);
            unitWork.Complete();
            unitWork.Dispose();
        }
        public void ActualizarMacroproceso (MecProcesos proceso)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            MecProcesos procesoactualizable = unitWork.MecProcesos.Find(c => c.IdProceso == proceso.IdProceso).FirstOrDefault();
            procesoactualizable.Proceso = proceso.Proceso;
            procesoactualizable.Estado = proceso.Estado;
            unitWork.Complete();
            unitWork.Dispose();
        }
        public void RegistrarLinea(MecLineas Linea)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            unitWork.MecLineas.Add(Linea);
            unitWork.Complete();
            unitWork.Dispose();
        }
        public void ActualizarLinea(MecLineas Linea)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            MecLineas lineaactualizable = unitWork.MecLineas.Find(c => c.IdLinea == Linea.IdLinea).FirstOrDefault();
            lineaactualizable.IdProceso = Linea.IdProceso;
            lineaactualizable.NombreLinea = Linea.NombreLinea;
            lineaactualizable.Estado = Linea.Estado;
            unitWork.Complete();
            unitWork.Dispose();
        }
        public void RegistrarListaDistribucion(MecListasDistribucion ListaD)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            unitWork.MecListasDistribucion.Add(ListaD);
            unitWork.Complete();
            unitWork.Dispose();
        }
        public void ActualizarListaDistribucion(MecListasDistribucion ListaD)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            MecListasDistribucion listaactualizable = unitWork.MecListasDistribucion.Find(c => c.IdLista == ListaD.IdLista).FirstOrDefault();
            listaactualizable.IdLinea = ListaD.IdLinea;
            listaactualizable.Destinatarios = ListaD.Destinatarios;
            unitWork.Complete();
            unitWork.Dispose();
        }
        public void RegistrarTipoAlarma (MecTipoAlarmas Alarma){
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            unitWork.MecTipoAlarmas.Add(Alarma);
            unitWork.Complete();
            unitWork.Dispose();
        }
        public void ActualizarTipoAlarmas(MecTipoAlarmas Alarma)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            MecTipoAlarmas alarmaactualizable = unitWork.MecTipoAlarmas.Find(c => c.IdAlarma == Alarma.IdAlarma).FirstOrDefault();
            alarmaactualizable.NombreAlarma= Alarma.NombreAlarma;
            unitWork.Complete();
            unitWork.Dispose();
        }
        public List<MecProcesos> ListaProcesosMecAdmin()
        {
            DimeContext dimContext = new DimeContext();
            List<MecProcesos> result = new List<MecProcesos>();
            var objetosResult = (from a in dimContext.MecProcesos
                                 orderby a.Proceso ascending
                                 select new
                                 {
                                     a.IdProceso,
                                     a.Proceso
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new MecProcesos());
                result[i].IdProceso = objetosResult[i].IdProceso;
                result[i].Proceso = objetosResult[i].Proceso;
            }
            return result;
        }
        public List<MecLineas> ListaLineasMecAdmin(int IdProceso)
        {
            DimeContext dimContext = new DimeContext();
            List<MecLineas> result = new List<MecLineas>();
            var objetosResult = (from a in dimContext.MecLineas
                                 where a.IdProceso.Equals(IdProceso)
                                 orderby a.NombreLinea ascending
                                 select new
                                 {
                                     a.IdLinea,
                                     a.NombreLinea
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new MecLineas());
                result[i].IdLinea = objetosResult[i].IdLinea;
                result[i].NombreLinea = objetosResult[i].NombreLinea;
            }
            return result;
        }
        public List<MecListasDistribucion> ListasCorreosMecAdmin(int IdLinea)
        {
            DimeContext dimContext = new DimeContext();
            List<MecListasDistribucion> result = new List<MecListasDistribucion>();
            var objetosResult = (from a in dimContext.MecListasDistribucion
                                 where a.IdLinea.Equals(IdLinea)
                                 select new
                                 {
                                     a.IdLista,
                                     a.Destinatarios
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new MecListasDistribucion());
                result[i].IdLista = objetosResult[i].IdLista;
                result[i].Destinatarios = objetosResult[i].Destinatarios;
            }
            return result;
        }
        public List<MecTipoAlarmas> ListaTipoAlarmasMecAdmin()
        {
            DimeContext dimContext = new DimeContext();
            List<MecTipoAlarmas> result = new List<MecTipoAlarmas>();
            var objetosResult = (from a in dimContext.MecTipoAlarmas
                                 orderby a.NombreAlarma ascending
                                 select new
                                 {
                                     a.IdAlarma,
                                     a.NombreAlarma
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new MecTipoAlarmas());
                result[i].IdAlarma = objetosResult[i].IdAlarma;
                result[i].NombreAlarma = objetosResult[i].NombreAlarma;
            }
            return result;
        }
    }
}
