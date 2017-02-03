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
        public MaestroNodo GetInformacionNodo(string nodo)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            return unitOfWork.maestroNodos.Find(c => c.Nodo.Trim() == nodo.Trim()).FirstOrDefault();
           
        }
        public void ActualizarInformacionNodo(MaestroNodo nodo)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            MaestroNodo nodoActualizable = unitWork.maestroNodos.Get(Convert.ToInt32(nodo.Nodo.Trim()));
            DateTime fechaActual = DateTime.Now;

            nodoActualizable.Nodo = nodo.Nodo;
            nodoActualizable.NombreNodo = nodo.NombreNodo;
            nodoActualizable.Div = nodo.Div;
            nodoActualizable.Com = nodo.Com;
            nodoActualizable.Divisional = nodo.Divisional;
            nodoActualizable.Area = nodo.Area;
            nodoActualizable.Distrito = nodo.Distrito;
            nodoActualizable.Ugestion = nodo.Ugestion;
            nodoActualizable.Usuario = nodo.Usuario;
            nodoActualizable.FechaCreacion = fechaActual;
            nodoActualizable.Estado = nodo.Estado;
            nodoActualizable.Red = nodo.Red;
            nodoActualizable.Aliado = nodo.Aliado;
            nodoActualizable.NombreComunidad = nodo.NombreComunidad;
            nodoActualizable.Departamento = nodo.Departamento;
            unitWork.Complete();

        }

    }
}
