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
        bool ValidarCuentaEnBackElite(decimal CuentaCliente, decimal Ot, string Proceso);
        [OperationContract]
        BEPSolicitudes ConsultarSolicitudPorId(decimal IdSolicitud);
        [OperationContract]
        BEPSolicitudes ApartarCuentadeSolcitudBackElita(decimal Cedula, int noRecursividad);
        [OperationContract]
        NodosZonificados TraerNodoPorId(string idNodo);
        [OperationContract]
        BEMTipoDeEscalamientos TipoEscalamientoPorNombre(string NombreTipoEs);
        [OperationContract]
        List<BELSolicitudes> ListaInteraccionesSolicitud(decimal IdSolicitud);
        [OperationContract]
        List<BEPSolicitudes> ListaSeguimientosAgente(decimal Cedula);
        [OperationContract]
        List<BELSolicitudes> ConsultadeGestionAgente(string Usuario, DateTime FechaInicial, DateTime FechaFinal);
        [OperationContract]
        List<BELSolicitudes> ConsultaSolicitudesAdminLog(DateTime FechaInicial, DateTime FechaFinal);
        [OperationContract]
        List<BEPSolicitudes> ConsultaSolicitudesAdminPricipal(DateTime FechaInicial, DateTime FechaFinal);
        [OperationContract]
        bool ValidarUsuarioDistribucion(decimal Cedula, string Proceso);
        [OperationContract]
        void RegistrarUsuarioDistribucion(BEMDistribuciones Distribucion);
        [OperationContract]
        void EliminarUsuarioDistribucion(decimal Cedula, string Proceso);
        [OperationContract]
        List<BEMDistribuciones> ListaDistribucionPorIdCedula(decimal Cedula);
        [OperationContract]
        BEMDistribuciones DistribucionPorId(decimal Id);
        [OperationContract]
        List<BEPSolicitudes> ConsultarSolicitudesMasivo(List<string> Solicitudes);
        [OperationContract]
        void ActualizarSolicitudesMasivo(List<string> Solicitudes, BEPSolicitudes Solicitud);
        [OperationContract]
        List<BEPSolicitudes> ListaCasosEnGestionPorBack(decimal Cedula);
        [OperationContract]
        void ReasignarGestionBack(List<string> Solicitudes, decimal UsuarioNuevo);
        [OperationContract]
        List<Usuario> ListaDeUsuariosBackElite();
    }
}
