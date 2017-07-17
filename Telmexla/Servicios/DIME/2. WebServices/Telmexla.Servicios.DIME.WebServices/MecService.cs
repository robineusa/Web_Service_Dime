using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;


namespace Telmexla.Servicios.DIME.WebServices
{
    public class MecService: IMecService
    {
        public void IsertarMonitoreo(MecMonitoreosP Monitoreo)
        {
            MecBusiness mecBusiness = new MecBusiness();
            mecBusiness.IsertarMonitoreo(Monitoreo);
        }
        public List<MecProcesos> ListaProcesosMec()
        {
            MecBusiness mecBusiness = new MecBusiness();
            return mecBusiness.ListaProcesosMec();
        }
        public List<MecLineas> ListaLineasMec(int IdProceso)
        {
            MecBusiness mecBusiness = new MecBusiness();
            return mecBusiness.ListaLineasMec(IdProceso);
        }
        public List<MecListasDistribucion> ListasCorreosMec(int IdLinea)
        {
            MecBusiness mecBusiness = new MecBusiness();
            return mecBusiness.ListasCorreosMec(IdLinea);
        }
        public List<MecTipoAlarmas> ListaTipoAlarmasMec()
        {
            MecBusiness mecBusiness = new MecBusiness();
            return mecBusiness.ListaTipoAlarmasMec();
        }
        public MecListasDistribucion DestinatariosMec(int IdLista)
        {
            MecBusiness mecBusiness = new MecBusiness();
            return mecBusiness.DestinatariosMec(IdLista);
        }
        public void ActualizarMonitoreo(MecMonitoreosP Monitoreo)
        {
            MecBusiness mecBusiness = new MecBusiness();
             mecBusiness.ActualizarMonitoreo(Monitoreo);
        }
        public List<MecMonitoreosP> ConsultaAdminMonitoreosPrincipal(DateTime FechaInicial, DateTime FechaFinal)
        {
            MecBusiness mecBusiness = new MecBusiness();
            return mecBusiness.ConsultaAdminMonitoreosPrincipal(FechaInicial,FechaFinal);
        }
        public List<MecMonitoreosL> ConsultaAdminMonitoreosLog(DateTime FechaInicial, DateTime FechaFinal)
        {
            MecBusiness mecBusiness = new MecBusiness();
            return mecBusiness.ConsultaAdminMonitoreosLog(FechaInicial, FechaFinal);
        }
        public MecMonitoreosP ConsultarMonitoreoPorId(int IdMonitoreo)
        {
            MecBusiness mecBusiness = new MecBusiness();
            return mecBusiness.ConsultarMonitoreoPorId(IdMonitoreo);
        }
        public List<MecMonitoreosP> ConsultaAgenteMonitoreosPrincipal(DateTime FechaInicial, DateTime FechaFinal, string UsuarioGestion)
        {
            MecBusiness mecBusiness = new MecBusiness();
            return mecBusiness.ConsultaAgenteMonitoreosPrincipal(FechaInicial, FechaFinal,UsuarioGestion);
        }
        public void RegistrarMacroproceso(MecProcesos proceso)
        {
            MecBusiness mecBusiness = new MecBusiness();
             mecBusiness.RegistrarMacroproceso(proceso);
        }
        public void ActualizarMacroproceso(MecProcesos proceso)
        {
            MecBusiness mecBusiness = new MecBusiness();
            mecBusiness.ActualizarMacroproceso(proceso);
        }
        public void RegistrarLinea(MecLineas Linea)
        {
            MecBusiness mecBusiness = new MecBusiness();
            mecBusiness.RegistrarLinea(Linea);
        }
        public void ActualizarLinea(MecLineas Linea)
        {
            MecBusiness mecBusiness = new MecBusiness();
            mecBusiness.ActualizarLinea(Linea);
        }
        public void RegistrarListaDistribucion(MecListasDistribucion ListaD)
        {
            MecBusiness mecBusiness = new MecBusiness();
            mecBusiness.RegistrarListaDistribucion(ListaD);

        }
        public void ActualizarListaDistribucion(MecListasDistribucion ListaD)
        {
            MecBusiness mecBusiness = new MecBusiness();
            mecBusiness.ActualizarListaDistribucion(ListaD);
        }
        public void RegistrarTipoAlarma(MecTipoAlarmas Alarma)
        {
            MecBusiness mecBusiness = new MecBusiness();
            mecBusiness.RegistrarTipoAlarma(Alarma);

        }
        public void ActualizarTipoAlarmas(MecTipoAlarmas Alarma)
        {
            MecBusiness mecBusiness = new MecBusiness();
            mecBusiness.ActualizarTipoAlarmas(Alarma);
        }
        public List<MecProcesos> ListaProcesosMecAdmin()
        {
            MecBusiness mecBusiness = new MecBusiness();
            return mecBusiness.ListaProcesosMecAdmin();
        }
        public List<MecLineas> ListaLineasMecAdmin(int IdProceso)
        {
            MecBusiness mecBusiness = new MecBusiness();
            return mecBusiness.ListaLineasMecAdmin(IdProceso);
        }
        public List<MecListasDistribucion> ListasCorreosMecAdmin(int IdLinea)
        {
            MecBusiness mecBusiness = new MecBusiness();
            return mecBusiness.ListasCorreosMecAdmin(IdLinea);
        }
        public List<MecTipoAlarmas> ListaTipoAlarmasMecAdmin()
        {
            MecBusiness mecBusiness = new MecBusiness();
            return mecBusiness.ListaTipoAlarmasMecAdmin();
        }

        }
}
