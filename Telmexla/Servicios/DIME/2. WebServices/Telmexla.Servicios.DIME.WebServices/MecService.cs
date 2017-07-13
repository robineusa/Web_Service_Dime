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
        }
}
