﻿using System;
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
            nodo.EsNodoFinal = false;
            nodo.Categoria = 0;
            nodo.SubCategoria = 0;
            nodo.Tipo = 0;
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
                    where n.Id == IdNodo
                    select n).FirstOrDefault();
            return nodo;
        }
        /// <summary>
        /// Guarda el codigo Html del nodo correspondiente
        /// </summary>
        /// <param name="IdNodo"></param>
        /// <param name="CodigoHtml"></param>
        public string GuardarCodigoHtmlNodo(int IdNodo, string CodigoHtml, bool NodoFinal, int Categoria, int SubCategoria, int Tipo)
        {
            Nodo nodo = new Nodo();
            string mensaje = string.Empty;
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            nodo = unitWork.Nodo.Find(f => f.Id == IdNodo).FirstOrDefault();

            if (nodo != null)
            {
                nodo.CodigoHtml = CodigoHtml;
                nodo.EsNodoFinal = NodoFinal;
                nodo.Categoria = Categoria;
                nodo.SubCategoria = SubCategoria;
                nodo.Tipo = Tipo;
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
            }
            unitWork.Complete();
            unitWork.Dispose();
        }

        public List<Macroprocesos> ConsultarCategorias(int idCategoria, int Tipo, bool EsIdPadre)
        {
            DimeContext Context = new DimeContext();
            List<Macroprocesos> Categorias = new List<Macroprocesos>();

            if (EsIdPadre)
            {
                Categorias = (from n in Context.Macroprocesos
                              where n.IdCategoriaPadre == idCategoria && n.TipoMacroproceso == Tipo
                              select n).ToList();
            }
            else
            {
                Categorias = (from n in Context.Macroprocesos
                              where n.IdCategoria == idCategoria && n.TipoMacroproceso == Tipo
                              select n).ToList();
            }
            return Categorias;

        }
        public void CrearCategoria(Macroprocesos Categoria)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            unitWork.Macroprocesos.Add(Categoria);
            unitWork.Complete();
            unitWork.Dispose();
        }
        public void EditarCategoria(int IdCategoria, string nombreNuevo)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            Macroprocesos Categoria = new Macroprocesos();

            Categoria = unitWork.Macroprocesos.Find(f => f.IdCategoria == IdCategoria).FirstOrDefault();

            if (Categoria != null)
            {
                Categoria.Descripcion = nombreNuevo;
            }
            unitWork.Complete();
            unitWork.Dispose();
        }
        public void EliminarCategoria(int idCategoria)
        {
            DimeContext dimContext = new DimeContext();
            List<int> idEliminar = new List<int>();
            List<int> CategoriaEliminar = new List<int>();
            //Consulta los nodos hijos principales
            idEliminar = (from n in dimContext.Macroprocesos
                          where n.IdCategoriaPadre == idCategoria
                          select n.IdCategoria).ToList();

            UnitOfWork unitWork;
            Macroprocesos EntidadEliminar = new Macroprocesos();
            //Busca y elimina los nodos hijos 
            if (idEliminar.Count > 0)
            {
                CategoriaEliminar = BuscarHijosCategoria(idEliminar);

                foreach (var item in CategoriaEliminar)
                {
                    unitWork = new UnitOfWork(new DimeContext());
                    EntidadEliminar = unitWork.Macroprocesos.Find(f => f.IdCategoria == item).FirstOrDefault();
                    if (EntidadEliminar != null)
                        unitWork.Macroprocesos.Remove(EntidadEliminar);
                    unitWork.Complete();
                    unitWork.Dispose();
                }
            }
            //Elimina el nodo seleccionado
            unitWork = new UnitOfWork(new DimeContext());
            EntidadEliminar = unitWork.Macroprocesos.Find(f => f.IdCategoria == idCategoria).FirstOrDefault();
            if (EntidadEliminar != null)
            {
                unitWork.Macroprocesos.Remove(EntidadEliminar);
                unitWork.Complete();
                unitWork.Dispose();
            }
        }

        private List<int> BuscarHijosCategoria(List<int> idEliminar)
        {
            List<int> categoriaHijo;
            DimeContext dimContext = new DimeContext();

            foreach (var item in idEliminar)
            {
                categoriaHijo = new List<int>();
                categoriaHijo = (from n in dimContext.Macroprocesos
                                 where n.IdCategoriaPadre == item
                                 select n.IdCategoria).ToList();

                if (categoriaHijo.Count > 0)
                {
                    foreach (var n in categoriaHijo)
                    {
                        //Revisa que el id no exista dentro de la coleccion idEliminar
                        if (!idEliminar.Any(a => a == n))
                        {
                            idEliminar.Add(n);
                            return BuscarHijosCategoria(idEliminar);
                        }
                    }
                }
            }

            return idEliminar;
        }

        public TiposMacroprocesos ConsultarTipoMacroproceso(int IdTipo)
        {
            DimeContext Context = new DimeContext();
            TiposMacroprocesos tipo = new TiposMacroprocesos();

            tipo = (from n in Context.TiposMacroprocesos
                    where n.IdTipo == IdTipo
                    select n).FirstOrDefault();

            return tipo;
        }
        public Dictionary<string, string> ConsultarTitulos(int idPadre, int idTipo)
        {
            Dictionary<string, string> titulos = new Dictionary<string, string>();
            Macroprocesos tipo = new Macroprocesos();
            DimeContext Context = new DimeContext();


            tipo = (from n in Context.Macroprocesos
                    where n.IdCategoria == idPadre
                    select n).FirstOrDefault();

            string nombrePadre = tipo != null ? tipo.Descripcion : string.Empty;
            string IdAnterior = tipo != null ? tipo.IdCategoriaPadre.ToString() : "0";
            int idAnterior = Convert.ToInt32(IdAnterior);
            string IdTipoAnterior = (from n in Context.Macroprocesos
                                     where n.IdCategoria == idAnterior
                                     select n.TipoMacroproceso).FirstOrDefault().ToString();

            string nombreTipo = (from n in Context.TiposMacroprocesos
                                 where n.IdTipo == idTipo
                                 select n.Descripcion).FirstOrDefault();



            titulos.Add("IdAnterior", IdAnterior);
            titulos.Add("IdTipoAnterior", IdTipoAnterior);
            titulos.Add("NombrePadre", nombrePadre);
            titulos.Add("nombreTipo", nombreTipo);

            return titulos;
        }
        public List<Nodo> consultarNodosArbol(int idArbol, int idNodoPadre)
        {
            List<Nodo> resultado = new List<Nodo>();
            Nodo actual = new Nodo();
            DimeContext Context = new DimeContext();

            //actual = (from n in Context.Nodo
            //          where n.Id== idNodoPadre && n.IdArbol== idArbol
            //          select n).FirstOrDefault();
            //if (actual != null)
            //    resultado.Add(actual);


            resultado = (from l in Context.Nodo
                         where l.IdArbol == idArbol && l.IdPadre == idNodoPadre
                         select l).ToList();


            return resultado;
        }
        public List<IndiceNodoArbol> IndiceNodosArbol(int idNodoActual)
        {
            IndiceNodoArbol indice = new IndiceNodoArbol();
            List<IndiceNodoArbol> ListaIndice = new List<IndiceNodoArbol>();
            List<IndiceNodoArbol> resultadoFinal = new List<IndiceNodoArbol>();
            DimeContext Context = new DimeContext();
            int NodosPrincipales = 1;
            int nodoActual = idNodoActual;
            int cont = 0;

            indice = ConsultarIndice(idNodoActual);
            ListaIndice.Add(indice);
            nodoActual = indice.IdPadre;
            while (NodosPrincipales != 0)
            {
                cont++;
                indice = ConsultarIndice(nodoActual);
                nodoActual = indice.IdPadre;
                if (cont == 2)
                {
                    ListaIndice.Add(indice);
                    cont = 0;
                }
                if (nodoActual == 0)
                    NodosPrincipales = 0;

            }
            //Organiza los indices
            int contador = ListaIndice.Count();
            for (int i = 0; i < contador; i++)
            {
                resultadoFinal.Add(ListaIndice.LastOrDefault());
                ListaIndice.Remove(ListaIndice.LastOrDefault());
            }

            return resultadoFinal;

        }
        private IndiceNodoArbol ConsultarIndice(int nodoActual)
        {
            IndiceNodoArbol indice = new IndiceNodoArbol();
            DimeContext Context = new DimeContext();
            indice = (from n in Context.Nodo.Cast<Nodo>().ToList()
                      where n.Id == nodoActual
                      select new IndiceNodoArbol
                      {
                          IdNodo = n.Id,
                          NombreNodo = n.NombreNodo,
                          IdPadre = n.IdPadre
                      }).FirstOrDefault();

            return indice;

        }

        public void ActualizarTrazabilidad(TrazabilidadArbol TrazaArbol)
        {
            TrazabilidadArbol Consultar = new TrazabilidadArbol();
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());

            Consultar = unitWork.TrazabilidadArbol.Find(f => f.Id == TrazaArbol.Id).FirstOrDefault();

            if (Consultar == null)
            {
                unitWork.TrazabilidadArbol.Add(TrazaArbol);
            }
            else
            {
                Consultar = TrazaArbol;
            }
            unitWork.Complete();
            unitWork.Dispose();

        }

    }
}



