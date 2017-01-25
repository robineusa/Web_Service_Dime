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
        public MaestroNodoCollection GetInformacionNodo(string nodo)
        {
            UnitOfWork unitwork = new UnitOfWork(new DimeContext());
            MaestroNodoCollection result = new MaestroNodoCollection();
            result.AddRange(unitwork.maestroNodos.Find(c => c.Nodo.Trim() == nodo.Trim()).Select(a => new MaestroNodo
            {
                Nodo= a.Nodo,
                NombreNodo=a.NombreNodo,
                Div=a.Div,
                Com=a.Com,
                Divisional=a.Divisional,
                Area=a.Area,
                Distrito=a.Distrito,
                Ugestion=a.Ugestion,
                Estado=a.Estado,
                Red=a.Red
            }).ToList());

            return result;

        }

     }
}
