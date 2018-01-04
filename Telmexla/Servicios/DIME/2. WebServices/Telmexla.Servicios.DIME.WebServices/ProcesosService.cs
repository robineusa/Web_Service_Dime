using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;

namespace Telmexla.Servicios.DIME.WebServices
{
    public class ProcesosService : IProcesosService
    {
        public void CrearNodo(Nodo nodo)
        {
            ProcesosBusiness crearnodo = new ProcesosBusiness();
            crearnodo.CrearNodo(nodo);
        }

        public List<Nodo> ConsultarNodos(int IdArbol)
        {
            ProcesosBusiness consultarnodos = new ProcesosBusiness();
            return consultarnodos.ConsultarNodos(IdArbol);
        }

        public Arbol ConsultarArbol(int IdArbol)
        {
            ProcesosBusiness consultararbol = new ProcesosBusiness();
            return consultararbol.ConsultarArbol(IdArbol);
        }
        public Nodo ConsultarNodoCreado(int IdArbol)
        {
            ProcesosBusiness consultarnodocreado = new ProcesosBusiness();
            return consultarnodocreado.ConsultarNodoCreado(IdArbol);
        }
        public void CrearArbol(Arbol arbol)
        {
            ProcesosBusiness creararbol = new ProcesosBusiness();
            creararbol.CrearArbol(arbol);
        }
        public void ActualizaHTMLArbol(Arbol model)
        {
            ProcesosBusiness actualizaHTMLArbol = new ProcesosBusiness();
            actualizaHTMLArbol.ActualizaHTMLArbol(model);
        }
        public List<Arbol> ListaArboles()
        {
            ProcesosBusiness listaArboles = new ProcesosBusiness();
            return listaArboles.ListaArboles();
        }

        public void EliminaNodo(int IdNodo)
        {
            ProcesosBusiness eliminaNodo = new ProcesosBusiness();
            eliminaNodo.EliminaNodo(IdNodo);
        }
        public void CambiarNombreNodo(int IdNodo, string NuevoNombre)
        {
            ProcesosBusiness CambiarNombreNodo = new ProcesosBusiness();
            CambiarNombreNodo.CambiarNombreNodo(IdNodo, NuevoNombre);
        }
        public Nodo ConsultarCodigoHtmlNodo(int IdNodo)
        {
            ProcesosBusiness ConsultarCodigoHtmlNodo = new ProcesosBusiness();
            return ConsultarCodigoHtmlNodo.ConsultarCodigoHtmlNodo(IdNodo);
        }
        public string GuardarCodigoHtmlNodo(int IdNodo, string CodigoHtml, bool NodoFinal, int Categoria, int SubCategoria, int Tipo)
        {
            ProcesosBusiness GuardarCodigoHtmlNodo = new ProcesosBusiness();
            return GuardarCodigoHtmlNodo.GuardarCodigoHtmlNodo(IdNodo, CodigoHtml, NodoFinal, Categoria, SubCategoria, Tipo);
        }
        public void CrearCategoria(Macroprocesos Categoria)
        {
            ProcesosBusiness CrearCategoria = new ProcesosBusiness();
            CrearCategoria.CrearCategoria(Categoria);
        }

        public void EliminarCategoria(int idCategoria)
        {
            ProcesosBusiness EliminarCategoria = new ProcesosBusiness();
            EliminarCategoria.EliminarCategoria(idCategoria);
        }

        public List<Macroprocesos> ConsultarCategorias(int idCategoria, int Tipo, bool EsIdPadre)
        {
            ProcesosBusiness ConsultarCategorias = new ProcesosBusiness();
            return ConsultarCategorias.ConsultarCategorias(idCategoria, Tipo, EsIdPadre);
        }
        public TiposMacroprocesos ConsultarTipoMacroproceso(int IdTipo)
        {
            ProcesosBusiness ConsultarCategorias = new ProcesosBusiness();
            return ConsultarCategorias.ConsultarTipoMacroproceso(IdTipo);
        }

        public Dictionary<string, string> ConsultarTitulos(int idPadre, int idTipo)
        {
            ProcesosBusiness ConsultarTitulos = new ProcesosBusiness();
            return ConsultarTitulos.ConsultarTitulos(idPadre, idTipo);
        }
        public void EditarCategoria(int IdCategoria, string nombreNuevo)
        {
            ProcesosBusiness ConsultarCategorias = new ProcesosBusiness();
            ConsultarCategorias.EditarCategoria(IdCategoria, nombreNuevo);
        }
    }
}
