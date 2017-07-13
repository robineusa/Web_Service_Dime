using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.IWebServices
{
    [ServiceContract]
    public interface IMecService
    {
        [OperationContract]
        void IsertarMonitoreo(MecMonitoreosP Monitoreo);
        [OperationContract]
        List<MecProcesos> ListaProcesosMec();
        [OperationContract]
        List<MecLineas> ListaLineasMec(int IdProceso);
        [OperationContract]
        List<MecListasDistribucion> ListasCorreosMec(int IdLinea);
        [OperationContract]
        List<MecTipoAlarmas> ListaTipoAlarmasMec();
        [OperationContract]
        MecListasDistribucion DestinatariosMec(int IdLista);
        [OperationContract]
        void ActualizarMonitoreo(MecMonitoreosP Monitoreo);
        [OperationContract]
        List<MecMonitoreosP> ConsultaAdminMonitoreosPrincipal(DateTime FechaInicial, DateTime FechaFinal);
        [OperationContract]
        List<MecMonitoreosL> ConsultaAdminMonitoreosLog(DateTime FechaInicial, DateTime FechaFinal);
        [OperationContract]
        MecMonitoreosP ConsultarMonitoreoPorId(int IdMonitoreo);
        [OperationContract]
        List<MecMonitoreosP> ConsultaAgenteMonitoreosPrincipal(DateTime FechaInicial, DateTime FechaFinal, string UsuarioGestion);
    }
}
