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
    public interface IMidasService
    {
        [OperationContract]
        List<ArbolesMidas> ListasDeArbolesMidasAdmin(decimal IdPadre);

        [OperationContract]
        void ActualizarArbolesMidas(ArbolesMidas Arbol);

        [OperationContract]
        void RegistrarNuevoArbolesMidas(ArbolesMidas Arbol);

        [OperationContract]
        ArbolesMidas TraerArbolMidasPorId(decimal IdArbol);

        [OperationContract]
        CargueBaseMidas TraeCuentaMidas(decimal CuentaCliente);

        [OperationContract]
        List<ArbolesMidas> ArbolDeGestionAgenteMidas(decimal IdPadre);

        [OperationContract]
        void RegistrarMidasTipificador(GPMMidas model);

        [OperationContract]
        void ActualizarMidasTipificador(GPMMidas model);

        [OperationContract]
        List<GPMMidas> TraerSeguimientosTipificador();

        [OperationContract]
        List<GPMMidas> CargaHistorialCuenta(decimal Cuenta);

        [OperationContract]
        GPMMidas VerificaCliente(decimal CuentaCliente);

    }
}
