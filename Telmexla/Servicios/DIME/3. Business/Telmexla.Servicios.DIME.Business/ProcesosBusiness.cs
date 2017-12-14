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
            nodo.CodigoHtml = string.Empty;
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

        /// <summary>
        /// Elimina los nodos y sus hijos
        /// </summary>
        /// <param name="idNodo"></param>
        public void EliminaNodo(int idNodo)
        {
            DimeContext dimContext = new DimeContext();
            List<int> idEliminar = new List<int>();
            List<int> nodoHijo = new List<int>();
            List<int> NodosEliminar = new List<int>();
            //Consulta los nodos hijos principales
            idEliminar = (from n in dimContext.Nodo
                          where n.IdPadre == idNodo
                          select n.Id).ToList();

            UnitOfWork unitWork;
            Nodo EntidadEliminar = new Nodo();
            //Busca y elimina los nodos hijos 
            if (idEliminar.Count > 0)
            {
                NodosEliminar = BuscarHijos(idEliminar);

                foreach (var item in NodosEliminar)
                {
                    unitWork = new UnitOfWork(new DimeContext());
                    EntidadEliminar = unitWork.Nodo.Find(f => f.Id == item).FirstOrDefault();
                    if (EntidadEliminar != null)
                        unitWork.Nodo.Remove(EntidadEliminar);
                    unitWork.Complete();
                    unitWork.Dispose();
                }
            }
            //Elimina el nodo seleccionado
            unitWork = new UnitOfWork(new DimeContext());
            EntidadEliminar = unitWork.Nodo.Find(f => f.Id == idNodo).FirstOrDefault();
            if (EntidadEliminar != null)
            {
                unitWork.Nodo.Remove(EntidadEliminar);
                unitWork.Complete();
                unitWork.Dispose();
            }
        }
        /// <summary>
        /// Consulta el nodo para cargar el codigo html correspondiente
        /// </summary>
        /// <param name="IdNodo"></param>
        /// <returns></returns>
        public Nodo ConsultarCodigoHtmlNodo(int IdNodo)
        {
            DimeContext dimContext = new DimeContext();
            Nodo nodo = new Nodo();
            nodo = (from n in dimContext.Nodo
                    where n.Id== IdNodo
                    select n).FirstOrDefault();
            return nodo;
        }
        /// <summary>
        /// Guarda el codigo Html del nodo correspondiente
        /// </summary>
        /// <param name="IdNodo"></param>
        /// <param name="CodigoHtml"></param>
        public string GuardarCodigoHtmlNodo(int IdNodo,string CodigoHtml,bool NodoFinal)
        {
          Nodo nodo = new Nodo();
            string mensaje = string.Empty;
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            nodo = unitWork.Nodo.Find(f => f.Id == IdNodo).FirstOrDefault();

            if (nodo != null)
            {
                nodo.CodigoHtml = CodigoHtml;
                nodo.EsNodoFinal = NodoFinal;
            }

            mensaje = nodo != null ? "Se han guardado los cambios efectuados" : "No se pudo guardar los cambios, revise si existe el nodo";
            unitWork.Complete();
            unitWork.Dispose();
            return mensaje;
        }

        /// <summary>
        /// Busca todos los nodos hijos y dependiendo, los hijos de sus hijos y asi sucesivamente
        /// </summary>
        /// <param name="idEliminar"></param>
        /// <returns></returns>
        private List<int> BuscarHijos(List<int> idEliminar)
        {
            List<int> nodoHijo;
            List<int> nodos = new List<int>();
            DimeContext dimContext = new DimeContext();

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
                        //Revisa que el id no exista dentro de la coleccion idEliminar
                        if (!idEliminar.Any(a => a == n))
                        {
                            idEliminar.Add(n);
                            return BuscarHijos(idEliminar);
                        }
                    }
                }
            }

            return idEliminar;
        }
        /// <summary>
        /// Cambia el nombre del nodo 
        /// </summary>
        /// <param name="idNodo"></param>
        /// <param name="nuevoNombre"></param>
        public void CambiarNombreNodo(int idNodo, string NuevoNombre)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            Nodo NodoCambiarNombre = new Nodo();

            NodoCambiarNombre = unitWork.Nodo.Find(f => f.Id == idNodo).FirstOrDefault();

            if (NodoCambiarNombre != null)
            {
                NodoCambiarNombre.NombreNodo = NuevoNombre;
                unitWork.Complete();
                unitWork.Dispose();
            }
        }

    }
}



