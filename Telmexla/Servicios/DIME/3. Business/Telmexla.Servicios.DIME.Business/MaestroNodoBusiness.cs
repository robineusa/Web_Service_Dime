using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Business
{
    public class MaestroNodoBusiness
    {
        public void InsertarNodo(MaestroNodo nodo)
        {
                nodo.FechaCreacion = DateTime.Now;

                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.maestroNodos.Add(nodo);
                unitWork.Complete();
                          
        }
        public bool ExisteNodo(string nodo)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return   unitWork.maestroNodos.Find(c => c.Nodo.Equals(nodo)).Count() >= 1 ;
            
        }

     }
}
