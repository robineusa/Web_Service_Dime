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
    public class IngresoRepository : Repository<Ingreso>, IIngresoRepository
    {
        public IngresoRepository(DimeContext context) : base(context)
        {

        }

        public DimeContext dimeContext
        {
            get { return Context as DimeContext; }
        }

        public string ActualizarComprobarUsuarioBackOffice(int idIngreso, string usrBackOffice)
        {
          var result=   dimeContext.ActualizarUsuarioGestionBackIngreso(idIngreso, usrBackOffice);
            if (result.Count > 0)
                return result.First().USUARIO_BACKOFFICE;
            else
                return "";
        }
    }
}
