using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IData;

namespace Telmexla.Servicios.DIME.Data
{
    public class CEPSuspensionesRepository : Repository<CEPSuspensiones>, ICEPSuspensionesRepository
    {
        public CEPSuspensionesRepository(DimeContext context) : base(context)
        {

        }
        public DimeContext dimeContext
        {
            get { return Context as DimeContext; }
        }
        public bool ApartarCuentaGestionSuspensiones(decimal Cedula)
        {
            dimeContext.ApartarCuentaGestionSuspensiones(Cedula);
            return true;
        }
    }
}
