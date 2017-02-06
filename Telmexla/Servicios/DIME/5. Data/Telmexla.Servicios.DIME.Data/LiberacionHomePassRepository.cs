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
    public class LiberacionHomePassRepository : Repository<LiberacionHomePass>,ILiberacionHomePassRepository
    {
        public LiberacionHomePassRepository(DimeContext context) : base(context)
        {


        }

        public DimeContext dimeContext
        {
            get { return Context as DimeContext; }
        }
        public string ComprobarActualizarUsrBackoffice(decimal idTransaccion, string usuarioBack)
        {
            var result = dimeContext.ActualizaUsuarioGestionBackHomePass(idTransaccion, usuarioBack);
            if (result.Count > 0)
                return result.First().USUARIO_BACKOFFICE;
            else
                return "";
        }
    }
}
