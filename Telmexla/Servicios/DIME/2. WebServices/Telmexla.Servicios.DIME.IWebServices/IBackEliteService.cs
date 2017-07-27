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
    public interface IBackEliteService
    {
        [OperationContract]
        void RegistrarSolicitud(BEPSolicitudes Solicitud);
        [OperationContract]
        void ActualizaSolicitud(BEPSolicitudes Solicitud);
        [OperationContract]
        List<BEMTipoDeEscalamientos> ListaTipoDeEscalamientos();
        [OperationContract]
        List<BEMDetalleEscalamientos> ListaDetalleDeEscalamientos(decimal IdTipo);
        [OperationContract]
        List<BEMRazonMalEscalamiento> ListaRazonesMalEscalamiento(decimal IdTipo);
        [OperationContract]
        List<BEMDetalleDeGestion> ListaDetallesDeGestion(decimal IdTipo);
        [OperationContract]
        BEMDetalleDeGestion DetalleGestionPorId(decimal IdGestion);
        [OperationContract]
        bool ValidarCuentaEnBackElite(decimal CuentaCliente, decimal Ot);
        [OperationContract]
        BEPSolicitudes ConsultarSolicitudPorId(decimal IdSolicitud);
        [OperationContract]
        BEPSolicitudes ApartarCuentadeSolcitudBackElita(decimal Cedula, string TipoTrabajo, int noRecursividad);
        [OperationContract]
        NodosZonificados TraerNodoPorId(string idNodo);
        [OperationContract]
        BEMTipoDeEscalamientos TipoEscalamientoPorNombre(string NombreTipoEs);
    }
}
