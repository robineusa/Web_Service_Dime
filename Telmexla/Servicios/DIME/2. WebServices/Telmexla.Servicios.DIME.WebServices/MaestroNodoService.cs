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
    public class MaestroNodoService : IMaestroNodoService
    {
        public void InsertarNodo(MaestroNodo nodo)
        {
            MaestroNodoBusiness nodobusines = new MaestroNodoBusiness();
            nodobusines.InsertarNodo(nodo);
        }
        public bool ExisteNodo(string nodo)
        {
            MaestroNodoBusiness nodobusines = new MaestroNodoBusiness();
            return nodobusines.ExisteNodo(nodo);
        }
    }
}
