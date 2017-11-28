using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Business
{
    public class ProcesosBusiness
    {
        
        //Crea los nodos
        public void CrearNodo(Nodo nodo)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            nodo.FechaCreacion = DateTime.Today;
            unitWork.Nodo.Add(nodo);
            unitWork.Complete();
            unitWork.Dispose();
        }
        //Consulta los nodos de un arbol
        public List<Nodo> ConsultarNodos(int IdArbol)
        {
            DimeContext Context = new DimeContext();

            List<Nodo> nodos = (from n in Context.Nodo
                                where n.IdArbol == IdArbol
                                select n).ToList();
            return nodos;
        }
        public Nodo ConsultarNodoCreado(int IdArbol)
        {
            DimeContext Context = new DimeContext();
            Nodo nodo = new Nodo();
            nodo = (from n in Context.Nodo
                    where n.IdArbol== IdArbol
                    orderby n.FechaCreacion descending
                    select n).FirstOrDefault();
            return nodo;

        }

        public Arbol ConsultarArbol(int IdArbol)
        {
            DimeContext Context = new DimeContext();

            Arbol arbol = (from n in Context.Arbol
                           where n.Id == IdArbol
                           select n).FirstOrDefault();
            return arbol;
        }
    }
}
