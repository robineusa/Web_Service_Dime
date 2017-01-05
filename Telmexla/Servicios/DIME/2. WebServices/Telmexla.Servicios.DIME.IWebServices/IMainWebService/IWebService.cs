using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.Helpers.Mappers;
using Telmexla.Servicios.DIME.IWebServices;

namespace Telmexla.Servicios.DIME.IWebServices.IMainWebService
{
    [ServiceContract]
    public interface IWebService
    {

        //El siguiente metodo no es de uso en ninguna instancia, solo ayuda al cliente de este wcf a reconocer todas las entidades al ponerlo.
        [OperationContract]
        Usuario MuestraEntidades();



    }
}
