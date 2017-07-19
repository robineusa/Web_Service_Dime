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
<<<<<<< HEAD
        List<DatoConsultaCCResidencialPredictivo> ListaResidencialPredictivoDeCuenta(float cuenta);
=======
>>>>>>> 45eddb8d3bcbead4ac47f965ccc31b9e64d5e546

    }
}
