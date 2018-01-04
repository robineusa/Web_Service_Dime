﻿using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.IWebServices
{
    [ServiceContract]
    public interface IProcesosService
    {
        [OperationContract]
        void CrearNodo(Nodo nodo);
        [OperationContract]
        List<Nodo> ConsultarNodos(int IdArbol);
        [OperationContract]
        Arbol ConsultarArbol(int IdArbol);
        [OperationContract]
        Nodo ConsultarNodoCreado(int IdArbol);
        [OperationContract]
        void CrearArbol(Arbol arbol);
        [OperationContract]
        void ActualizaHTMLArbol(Arbol model);
        [OperationContract]
        List<Arbol> ListaArboles();
        [OperationContract]
        void EliminaNodo(int IdNodo);
        [OperationContract]
        void CambiarNombreNodo(int IdNodo,string NuevoNombre);
        [OperationContract]
        Nodo ConsultarCodigoHtmlNodo(int IdNodo);
        [OperationContract]
        string GuardarCodigoHtmlNodo(int IdNodo, string CodigoHtml, bool NodoFinal, int Categoria, int SubCategoria, int Tipo);
        [OperationContract]
        void CrearCategoria(Macroprocesos Categoria);
        [OperationContract]
        List<Macroprocesos> ConsultarCategorias(int idCategoria, int Tipo, bool EsIdPadre);
        [OperationContract]
        void EliminarCategoria(int idCategoria);
        [OperationContract]
        TiposMacroprocesos ConsultarTipoMacroproceso(int IdTipo);
        [OperationContract]
        Dictionary<string, string> ConsultarTitulos(int idPadre, int idTipo);
        [OperationContract]
        void EditarCategoria(int IdCategoria, string nombreNuevo);
    }
}
