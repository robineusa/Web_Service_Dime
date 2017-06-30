using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;
using Telmexla.Servicios.DIME.WebServices;

namespace Telmexla.Servicios.DIME.WebServices
{
    public class MultiPlayService : IMultiPlayService
    {
        public List<DatosMultiplay> BuscarDatosMultiplay(int cuentacliente)
        {
            MultiplayBusiness Multi = new MultiplayBusiness();
            return Multi.BuscarDatosMultiplay(cuentacliente);
        }
        public void InsertarMultiPlay(MultiPlay multiplay)
        {
            MultiplayBusiness Multi = new MultiplayBusiness();
            Multi.InsertarMultiPlay(multiplay);
        }
    }
}
