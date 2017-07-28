using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IData;

namespace Telmexla.Servicios.DIME.Data
{
    public class BEPSolicitudesRepository: Repository<BEPSolicitudes>, IBEPSolicitudesRepository
    {
        public BEPSolicitudesRepository(DimeContext context) : base(context)
        {


        }

        public DimeContext dimeContext
        {
            get { return Context as DimeContext; }
        }
        public bool ApartarCuentaGestionBackElite(decimal Cedula)
        {
            dimeContext.ApartarCuentaGestionBackElite(Cedula);
            return true;
        }
    }
}
