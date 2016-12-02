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

    public class AccesoRepository : Repository<Acceso>, IAccesoRepository
    {

        public AccesoRepository(DimeContext context) : base(context)
        {

        }
        /*
        public IEnumerable<Acceso> getTopPersonas(int count)
        {
            return projectContext.Personas.OrderByDescending(c => c.Id).Take(count).ToList();
        }

    */

        public DimeContext dimeContext
        {
            get { return Context as DimeContext; }
        }

    }
}
