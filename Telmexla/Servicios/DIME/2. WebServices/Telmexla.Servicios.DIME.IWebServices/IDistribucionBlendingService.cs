using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.IWebServices
{
    [ServiceContract]
    public interface IDistribucionBlendingService
    {
        [OperationContract]
        ClientesTodo TraerInformacionCuentaBlending(int idAsesor, string formulario, string aliado, string operacion, string campana);

        [OperationContract]
        BlendingFueraNivel TraerInformacionCuentaFueraNiveles(decimal CuentaCliente);

        [OperationContract]
        void EliminaCuentaGestionadaDistribucion(DistribucionBlending Registro);

        [OperationContract]
        void InsertarCuentaColaDistribucionBlending(DistribucionBlending Registro);

        [OperationContract]
        void InsertarRegistroFueraNiveles(GBPFueraNiveles PFueraNivel);

        [OperationContract]
        void ActualizarGestionFueraNiveles(GBPFueraNiveles PFueraNivel);

        [OperationContract]
        bool ValidarCuentaEnFueraNiveles(decimal CuentaCliente);

        [OperationContract]
        GBPFueraNiveles TraeInformacionActualFueraNiveles(decimal CuentaCliente);

        [OperationContract]
        List<GBLFueraNiveles> TraeListaGestionUsuarioFueraNiveles(string Usuario);

        [OperationContract]
        List<GBPFueraNiveles> TraeListaSeguimientosUsuarioFueraNiveles(string Usuario);

        [OperationContract]
        ClientesTodo AsignarIdCuentaDistribucionBlending(decimal CuentaCliente, string Formulario, string Aliado, string Operacion, string Campana, int Id);

        [OperationContract]
        GBPFueraNiveles TraerDatosCuentaSelectFueraNivel(decimal CuentaCliente);

        [OperationContract]
        int CantidadToquesCuentaFueraNiveles(decimal CuentaCliente);

        [OperationContract]
        GBLFueraNiveles TraeUltimaGestionCuenta(decimal CuentaCliente);

        [OperationContract]
        List<GBPFueraNiveles> ConsultaAdminFueraNivelesP(DateTime FechaInicial, DateTime FechaFinal);

        [OperationContract]
        List<GBLFueraNiveles> ConsultaAdminFueraNivelesL(DateTime FechaInicial, DateTime FechaFinal);

        //GESTION BLENDING RENTABILIZACION

        [OperationContract]
        GBC_Rentabilizacion TraerInformacionCuentaRentabilizacion(decimal CuentaCliente);

        [OperationContract]
        void InsertarRegistroRentabilizacion(GBPRentabilizacion PRentabilizacion);

        [OperationContract]
        void ActualizarGestionRentabilizacion(GBPRentabilizacion PRentabilizacion);

        [OperationContract]
        bool ValidarCuentaEnRentabilizacion(decimal CuentaCliente);

        [OperationContract]
        GBPRentabilizacion TraeInformacionActualRentabilizacion(decimal CuentaCliente);

        [OperationContract]
        List<GBLRentabilizacion> TraeListaGestionUsuarioRentabilizacion(string Usuario);

        [OperationContract]
        List<GBPRentabilizacion> TraeListaSeguimientosUsuarioRentabilizacion(string Usuario);

        [OperationContract]
        GBPRentabilizacion TraerDatosCuentaSelectRentabilizacion(decimal CuentaCliente);

        [OperationContract]
        int CantidadToquesCuentaRentabilizacion(decimal CuentaCliente);

        [OperationContract]
        GBLRentabilizacion TraeUltimaGestionCuentaRentabilizacion(decimal CuentaCliente);

        [OperationContract]
        List<GBPRentabilizacion> ConsultaAdminRentabilizacionP(DateTime FechaInicial, DateTime FechaFinal);

        [OperationContract]
        List<GBLRentabilizacion> ConsultaAdminRentabilizacionL(DateTime FechaInicial, DateTime FechaFinal);

        //GESTION BLENDING RENTABILIZACION

        [OperationContract]
        GBCProducto TraerInformacionCuentaProducto(decimal CuentaCliente);

        [OperationContract]
        void InsertarRegistroProducto(GBPProducto GBPProducto);

        [OperationContract]
        void ActualizarGestionProducto(GBPProducto GBPProducto);

        [OperationContract]
        bool ValidarCuentaEnProducto(decimal CuentaCliente);

        [OperationContract]
        GBPProducto TraeInformacionActualProducto(decimal CuentaCliente);

        [OperationContract]
        List<GBLProducto> TraeListaGestionUsuarioProucto(string Usuario);

        [OperationContract]
        List<GBPProducto> TraeListaSeguimientosUsuarioProducto(string Usuario);

        [OperationContract]
        GBPProducto TraerDatosCuentaSelectProducto(decimal CuentaCliente);

        [OperationContract]
        int CantidadToquesCuentaProducto(decimal CuentaCliente);

        [OperationContract]
        GBLProducto TraeUltimaGestionCuentaProducto(decimal CuentaCliente);

        [OperationContract]
        List<GBPProducto> ConsultaAdminProductoP(DateTime FechaInicial, DateTime FechaFinal);

        [OperationContract]
        List<GBLProducto> ConsultaAdminProductoL(DateTime FechaInicial, DateTime FechaFinal);

        //GESTION BLENDING DOCSIS Y OVERLAP

        [OperationContract]
        GBCDocsis TraerInformacionCuentaDocsis(decimal CuentaCliente);

        [OperationContract]
        void InsertarRegistroDocsis(GBPDocsis GBPDocsis);

        [OperationContract]
        void ActualizarGestionDocsis(GBPDocsis GBPDocsis);

        [OperationContract]
        bool ValidarCuentaEnDocsis(decimal CuentaCliente);

        [OperationContract]
        GBPDocsis TraeInformacionActualDocsis(decimal CuentaCliente);

        [OperationContract]
        List<GBLDocsis> TraeListaGestionUsuarioDocsis(string Usuario);

        [OperationContract]
        List<GBPDocsis> TraeListaSeguimientosUsuarioDocsis(string Usuario);

        [OperationContract]
        GBPDocsis TraerDatosCuentaSelectDocsis(decimal CuentaCliente);

        [OperationContract]
        int CantidadToquesCuentaDocsis(decimal CuentaCliente);

        [OperationContract]
        GBLDocsis TraeUltimaGestionCuentaDocsis(decimal CuentaCliente);

        [OperationContract]
        List<GBPDocsis> ConsultaAdminDocsisP(DateTime FechaInicial, DateTime FechaFinal);

        [OperationContract]
        List<GBLDocsis> ConsultaAdminDocsisL(DateTime FechaInicial, DateTime FechaFinal);
    }
}
