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
    }
}
