using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IData;

namespace Telmexla.Servicios.DIME.Data
{
    public  class NodoRepository : Repository<Nodo>, INodoRepository
    {
        public NodoRepository(DimeContext context) : base(context)
        {
        }

        public DimeContext dimeContext
        {
            get { return Context as DimeContext; }
        }
    }
}
