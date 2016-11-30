using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IData;

namespace Telmexla.Servicios.DIME.Data
{
    public class CierreCicloRepository : Repository<CierreCiclo>, ICierreCicloRepository
    {

        public CierreCicloRepository(DimeContext context) : base(context)
        {

        }

        public DimeContext dimeContext
        {
            get { return Context as DimeContext; }
        }
    }
}
