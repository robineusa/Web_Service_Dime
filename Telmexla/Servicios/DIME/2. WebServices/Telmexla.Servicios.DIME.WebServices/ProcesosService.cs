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
    public class ProcesosService: IProcesosService
    {
        public void CrearNodo(Nodo nodo)
        {
            ProcesosBusiness crearnodo = new ProcesosBusiness();
            crearnodo.CrearNodo(nodo);
        }

        public List<Nodo> ConsultarNodos(int IdArbol)
        {
            ProcesosBusiness crearnodo = new ProcesosBusiness();
            return crearnodo.ConsultarNodos(IdArbol);
        }

        public Arbol ConsultarArbol(int IdArbol)
        {
            ProcesosBusiness crearnodo = new ProcesosBusiness();
            return crearnodo.ConsultarArbol(IdArbol);
        }
        public Nodo ConsultarNodoCreado()
        {
            ProcesosBusiness crearnodo = new ProcesosBusiness();
            return crearnodo.ConsultarNodoCreado();
        }

    }
}
