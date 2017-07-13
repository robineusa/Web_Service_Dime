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
    public interface IMultiPlayService
    {
        [OperationContract]
        MultiplayCargue BuscarDatosMultiplay(decimal cuentacliente);

        [OperationContract]
        void InsertarMultiPlay(MultiPlayRegistro multiplay);

        [OperationContract]
        void EliminaCuentaDatosMultiplay(decimal Id_Cuenta, decimal Cuenta);

        [OperationContract]
        List<MultiPlayRegistro> ConsultaAdminBasePresidencial(DateTime inicial, DateTime final);



    }
}
