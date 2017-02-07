using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.IData
{
    public interface IGestionMatrizRepository: IRepository<GestionMatriz>
    {
        string ComprobarActualizarUsrBackofficeCreacion(decimal idTransaccion, string usuarioBack);
        string ComprobarActualizarUsrBackofficeGestion(decimal idTransaccion, string usuarioOut);
    }
}
