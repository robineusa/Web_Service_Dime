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
        List<MecTipoAlarmas> ListaTipoAlarmasMec(decimal IdProceso);
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
        [OperationContract]
        void RegistrarMacroproceso(MecProcesos proceso);
        [OperationContract]
        void ActualizarMacroproceso(MecProcesos proceso);
        [OperationContract]
        void RegistrarLinea(MecLineas Linea);
        [OperationContract]
        void ActualizarLinea(MecLineas Linea);
        [OperationContract]
        void RegistrarListaDistribucion(MecListasDistribucion ListaD);
        [OperationContract]
        void ActualizarListaDistribucion(MecListasDistribucion ListaD);
        [OperationContract]
        void RegistrarTipoAlarma(MecTipoAlarmas Alarma);
        [OperationContract]
        void ActualizarTipoAlarmas(MecTipoAlarmas Alarma);
        [OperationContract]
        List<MecProcesos> ListaProcesosMecAdmin();
        [OperationContract]
        List<MecLineas> ListaLineasMecAdmin(int IdProceso);
        [OperationContract]
        List<MecListasDistribucion> ListasCorreosMecAdmin(int IdLinea);
        [OperationContract]
        List<MecTipoAlarmas> ListaTipoAlarmasMecAdmin();
        [OperationContract]
        MecProcesos ProcesoPorId(decimal IdProceso);
        [OperationContract]
        MecLineas LineaPorId(decimal IdLinea);
        [OperationContract]
        MecListasDistribucion ListaCorreosPorId(decimal IdLista);
    }
}
