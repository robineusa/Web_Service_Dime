﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;

namespace Telmexla.Servicios.DIME.WebServices
{
    public class ProcesosService: IProcesosService
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

    }
}
