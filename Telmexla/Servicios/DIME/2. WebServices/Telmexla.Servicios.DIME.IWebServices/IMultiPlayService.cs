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
    public interface IMultiPlayService
    {
        [OperationContract]
        DatosMultiplay BuscarDatosMultiplay(int cuentacliente);

        [OperationContract]
        void InsertarMultiPlay(MultiPlay multiplay);

        [OperationContract]
        void EliminaCuentaDatosMultiplay(int Id_Cuenta, int Cuenta);

        [OperationContract]
        MultiPlayCollection ConsultaAdminBasePresidencial(DateTime inicial, DateTime final);

        
    }
}
