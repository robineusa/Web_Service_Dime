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
            nodo.FechaCreacion = DateTime.Now;
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
                    where n.IdArbol == IdArbol
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
        public void CrearArbol(Arbol arbol)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());

            unitWork.Arbol.Add(arbol);
            unitWork.Complete();
            unitWork.Dispose();
        }
        public void ActualizaHTMLArbol(Arbol model)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            Arbol ArbolActu = unitWork.Arbol.Find(c => c.Id == model.Id).FirstOrDefault();

            ArbolActu.CodigoHtml = model.CodigoHtml;

            unitWork.Complete();
            unitWork.Dispose();
        }
        public List<Arbol> ListaArboles()
        {
            DimeContext dimContext = new DimeContext();
            List<Arbol> result = new List<Arbol>();
            var objetosResult = (from a in dimContext.Arbol
                                 select new
                                 {
                                     a.Id,
                                     a.NombreArbol,
                                     a.CodigoHtml,
                                     a.Estado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new Arbol());
                result[i].Id = objetosResult[i].Id;
                result[i].NombreArbol = objetosResult[i].NombreArbol;
                result[i].CodigoHtml = objetosResult[i].CodigoHtml;
                result[i].Estado = objetosResult[i].Estado;
            }

            return result;
        }

        public void EliminaNodo(int idNodo)
        {
            DimeContext dimContext = new DimeContext();
            List<int> idEliminar = new List<int>();
            List<int> nodoHijo = new List<int>();
            List<int> preubas = new List<int>();
            idEliminar = (from n in dimContext.Nodo
                          where n.IdPadre == idNodo
                          select n.Id).ToList();

            BuscarHijos(idEliminar);

        }
        public void BuscarHijos(List<int> idEliminar)
        {
            List<int> nodoHijo ;
            List<int> nodos = new List<int>();
            DimeContext dimContext = new DimeContext();
            int index = 0;
            foreach (var item in idEliminar)
            {
                nodoHijo = new List<int>();
                nodoHijo = (from n in dimContext.Nodo
                            where n.IdPadre == item
                            select n.Id).ToList();

                if (nodoHijo.Count > 0)
                {
                    foreach (var n in nodoHijo)
                    {
                        if (!idEliminar.Any(a => a == n))
                        {
                            idEliminar.Add(n);
                            pruebas(idEliminar);
                            break;

                        }
                    }
                }
            }

           
        }
        public void pruebas(List<int> idEliminar)
        {
            BuscarHijos(idEliminar);

        }
    }
}



//public void EliminaNodo(int idNodo, int IdArbol)
//{
//    DimeContext dimContext = new DimeContext();
//    List<int> idEliminar = new List<int>();
//    List<int> nodoHijo = new List<int>();
//    List<int> preubas = new List<int>();
//    idEliminar = (from n in dimContext.Nodo
//                  where n.IdArbol == IdArbol && n.IdPadre == idNodo
//                  select n.Id).ToList();

//    foreach (var item in idEliminar)
//    {
//        nodoHijo = (from n in dimContext.Nodo
//                    where n.IdPadre == item
//                    select n.Id).ToList();
//        if (nodoHijo.Count > 0)
//        {
//            BuscarHijos(nodoHijo);

//        }
//    }
//}
//public void BuscarHijos(List<int> preubas)
//{
//    List<int> nodoHijo = new List<int>();
//    List<int> nodos = new List<int>();
//    DimeContext dimContext = new DimeContext();
//    foreach (var item in preubas)
//    {
//        nodoHijo = (from n in dimContext.Nodo
//                    where n.IdPadre == item
//                    select n.Id).ToList();

//        if (nodoHijo.Count > 0)
//        {
//            foreach (var n in nodoHijo)
//            {
//                if (preubas.Any(a => a != n))
//                {
//                    preubas.Add(n);
//                    BuscarHijos(preubas);
//                }

//            }
//        }

//    }

//}


//for (int i = 0; i < idEliminar.Count; i++)
//{
//    index = idEliminar[i];
//    nodoHijo = (from n in dimContext.Nodo
//                where n.IdPadre == index
//                select n.Id).ToList();
//    if (nodoHijo.Count > 0)
//    {
//        for (int f = 0; f < nodoHijo.Count; f++)
//        {
//            if (!idEliminar.Any(a => a == nodoHijo[f]))
//            {
//                idEliminar.Add(nodoHijo[f]);
//                BuscarHijos(idEliminar);
//                break;

//            }
//        }
//    }

//}