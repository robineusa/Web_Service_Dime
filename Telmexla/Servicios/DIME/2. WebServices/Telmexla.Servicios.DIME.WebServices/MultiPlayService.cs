using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;


namespace Telmexla.Servicios.DIME.WebServices
{
    public class MultiPlayService : IMultiPlayService
    {
        public MultiplayCargue BuscarDatosMultiplay(decimal cuentacliente)
        {
            MultiplayBusiness Multi = new MultiplayBusiness();
            return Multi.BuscarDatosMultiplay(cuentacliente);
        }
        public void InsertarMultiPlay(MultiPlayRegistro multiplay)
        {
            MultiplayBusiness Multi = new MultiplayBusiness();
            Multi.InsertarMultiPlay(multiplay);
        }
        public void EliminaCuentaDatosMultiplay(decimal Id_Cuenta, decimal Cuenta)
        {
            MultiplayBusiness Multi = new MultiplayBusiness();
            Multi.EliminaCuentaDatosMultiplay(Id_Cuenta, Cuenta);
        }

        public List<MultiPlayRegistro> ConsultaAdminBasePresidencial(DateTime inicial, DateTime final)
        {
            MultiplayBusiness Multi = new MultiplayBusiness();
            return Multi.ConsultaAdminBasePresidencial(inicial, final);
        }
    }
}
