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
    public interface IInboundService
    {
        [OperationContract]
        bool RegistrarActualizarDatosAdicionalesCliente(DatosAdicionalesCliente datosAdicionalesCliente);

        [OperationContract]
        ClientesTodo TraerClienteCompletoPorCuenta(int cuenta);

        [OperationContract]
        DatosAdicionalesCliente TraerDatosAdicionalesCliente(int cuenta);

        [OperationContract]
        List<ClientesTodo> ConsultarCuentasPorcedula(string cedula);

        [OperationContract]
        List<string> ConsultarHobbiesOptions();


        [OperationContract]
        void RegistrarIngresoInbound(ClientesTodo infoCliente, Ingreso ingreso, string observacion);


        [OperationContract]
        IngresoCollection ListaIngresosDeCuenta(string cuenta);

        [OperationContract]
        List<TablaActualizarInbound> ListaHistorialCaso(int idIngreso);

        [OperationContract]
        void ActualizarIngresoInbound(Ingreso ingreso, string observacion, string llamadaCliente);


        [OperationContract]
        List<DatoConsultaGestion> ConsultaGestion(DateTime fechaInicial, DateTime fechaFinal, string idUsuario);


        [OperationContract]
        List<DatoConsultaRechazo> ConsultaRechazos(DateTime fechaInicial, DateTime fechaFinal, string idUsuario, bool esPerfilAdmin);

        [OperationContract]
        IngresoCollection ConsultaSegumiento(string idUsuario);
    }
}
