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
    }
}
