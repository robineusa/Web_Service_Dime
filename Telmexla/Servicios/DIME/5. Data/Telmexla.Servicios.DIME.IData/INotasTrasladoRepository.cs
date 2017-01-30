using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.IData
{
    public interface INotasTrasladoRepository : IRepository<NotasTraslado>
    {


        string ComprobarActualizarUsrBackoffice(decimal idTransaccion, string usuarioBack);
        string ComprobarActualizarUsrOutbound(decimal idTransaccion, string usuarioOut);



    }
}
