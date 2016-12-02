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
    public interface IClientesService
    {

        [OperationContract]
        bool RegistrarActualizarDatosAdicionalesCliente(DatosAdicionalesCliente datosAdicionalesCliente);

        [OperationContract]
        ClientesTodo TraerClienteCompletoPorCuenta(int cuenta);

        [OperationContract]
        DatosAdicionalesCliente TraerDatosAdicionalesCliente(int cuenta);

        [OperationContract]
        ClientesTodoCollection ConsultarCuentasPorcedula(string cedula);

        [OperationContract]
        List<string> ConsultarHobbiesOptions();


    }
}
