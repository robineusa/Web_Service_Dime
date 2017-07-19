using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;

namespace Telmexla.Servicios.DIME.IWebServices
{
    [ServiceContract]
    public interface ICierreCicloService
    {
        [OperationContract]
        List<DatoConsultaCCResidencialPredictivo> ListaResidencialPredictivoDeCuenta(float cuenta);


    }
}
