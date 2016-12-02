using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;

namespace Telmexla.Servicios.DIME.WebServices
{
    public class ClientesService : IClientesService
    {
        public ClientesTodoCollection ConsultarCuentasPorcedula(string cedula)
        {
            throw new NotImplementedException();
        }

        public List<string> ConsultarHobbiesOptions()
        {
            throw new NotImplementedException();
        }

        public bool RegistrarActualizarDatosAdicionalesCliente(DatosAdicionalesCliente datosAdicionalesCliente)
        {
            throw new NotImplementedException();
        }

        public ClientesTodo TraerClienteCompletoPorCuenta(int cuenta)
        {
            throw new NotImplementedException();
        }

        public DatosAdicionalesCliente TraerDatosAdicionalesCliente(int cuenta)
        {
            throw new NotImplementedException();
        }
    }
}
