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
    public class BackEliteService: IBackEliteService
    {
        public void RegistrarSolicitud(BEPSolicitudes Solicitud)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            backelitebusiness.RegistrarSolicitud(Solicitud);
        }
        public void ActualizaSolicitud(BEPSolicitudes Solicitud)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            backelitebusiness.ActualizaSolicitud(Solicitud);
        }
        public List<BEMTipoDeEscalamientos> ListaTipoDeEscalamientos()
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.ListaTipoDeEscalamientos();

        }
        public List<BEMDetalleEscalamientos> ListaDetalleDeEscalamientos(decimal IdTipo)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.ListaDetalleDeEscalamientos(IdTipo);
        }
        public List<BEMRazonMalEscalamiento> ListaRazonesMalEscalamiento(decimal IdTipo)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.ListaRazonesMalEscalamiento(IdTipo);
        }
        public List<BEMDetalleDeGestion> ListaDetallesDeGestion(decimal IdTipo)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.ListaDetallesDeGestion(IdTipo);

        }
        public BEMDetalleDeGestion DetalleGestionPorId(decimal IdGestion)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.DetalleGestionPorId(IdGestion);
        }
        public bool ValidarCuentaEnBackElite(decimal CuentaCliente, decimal Ot, string Proceso)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.ValidarCuentaEnBackElite(CuentaCliente, Ot,Proceso);

        }
        public BEPSolicitudes ConsultarSolicitudPorId(decimal IdSolicitud)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.ConsultarSolicitudPorId(IdSolicitud);
        }
        public BEPSolicitudes ApartarCuentadeSolcitudBackElita(decimal Cedula, int noRecursividad)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.ApartarCuentadeSolcitudBackElita(Cedula,noRecursividad);
        }
        public NodosZonificados TraerNodoPorId(string idNodo)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.TraerNodoPorId(idNodo);
        }
        public BEMTipoDeEscalamientos TipoEscalamientoPorNombre(string NombreTipoEs)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.TipoEscalamientoPorNombre(NombreTipoEs);
        }
        public List<BELSolicitudes> ListaInteraccionesSolicitud(decimal IdSolicitud)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.ListaInteraccionesSolicitud(IdSolicitud);
        }
        public List<BEPSolicitudes> ListaSeguimientosAgente(decimal Cedula)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.ListaSeguimientosAgente(Cedula);
        }
        public List<BELSolicitudes> ConsultadeGestionAgente(string Usuario, DateTime FechaInicial, DateTime FechaFinal)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.ConsultadeGestionAgente(Usuario,FechaInicial,FechaFinal);
        }
        public List<BELSolicitudes> ConsultaSolicitudesAdminLog(DateTime FechaInicial, DateTime FechaFinal)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.ConsultaSolicitudesAdminLog(FechaInicial, FechaFinal);

        }
        public List<BEPSolicitudes> ConsultaSolicitudesAdminPricipal(DateTime FechaInicial, DateTime FechaFinal)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.ConsultaSolicitudesAdminPricipal(FechaInicial, FechaFinal);
        }
        public bool ValidarUsuarioDistribucion(decimal Cedula, string Proceso)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.ValidarUsuarioDistribucion(Cedula, Proceso);
        }
        public void RegistrarUsuarioDistribucion(BEMDistribuciones Distribucion)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            backelitebusiness.RegistrarUsuarioDistribucion(Distribucion);
        }
        public void EliminarUsuarioDistribucion(decimal Cedula, string Proceso)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            backelitebusiness.EliminarUsuarioDistribucion(Cedula,Proceso);
        }
        public List<BEMDistribuciones> ListaDistribucionPorIdCedula(decimal Cedula)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.ListaDistribucionPorIdCedula(Cedula);
        }
        public BEMDistribuciones DistribucionPorId(decimal Id)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.DistribucionPorId(Id);
        }
        public List<BEPSolicitudes> ConsultarSolicitudesMasivo(List<string> Solicitudes)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.ConsultarSolicitudesMasivo(Solicitudes);
        }
        public void ActualizarSolicitudesMasivo(List<string> Solicitudes, BEPSolicitudes Solicitud)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            backelitebusiness.ActualizarSolicitudesMasivo(Solicitudes,Solicitud);
        }
    }
}
