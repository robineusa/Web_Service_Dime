﻿using System;
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
            return unitWork.maestroNodos.Find(c => c.Nodo.Equals(nodo) && c.Estado == "ACT").Count() >= 1;
            
        }
        public MaestroNodo GetInformacionNodo(string nodo)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            return unitOfWork.maestroNodos.Find(c => c.Nodo.Trim() == nodo.Trim()).FirstOrDefault();
           
        }
        public void ActualizarInformacionNodo(MaestroNodo nodo)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            MaestroNodo nodoActualizable = unitWork.maestroNodos.Get(Convert.ToInt32(nodo.IdNodo));
            DateTime fechaActual = DateTime.Now;

            nodoActualizable.Nodo = nodo.Nodo;
            nodoActualizable.NombreNodo = nodo.NombreNodo;
            nodoActualizable.Div = nodo.Div;
            nodoActualizable.Com = nodo.Com;
            nodoActualizable.Divisional = nodo.Divisional;
            nodoActualizable.Area = nodo.Area;
            nodoActualizable.Zona = nodo.Zona;
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
        public MaestroNodoCollection ListaNodosCreados()
        {
            UnitOfWork unitwork = new UnitOfWork(new DimeContext());
            MaestroNodoCollection result = new MaestroNodoCollection();
            result.AddRange(unitwork.maestroNodos.GetAll().Select(a => new MaestroNodo
            {
                IdNodo = a.IdNodo,
                Nodo= a.Nodo,
                NombreNodo= a.NombreNodo,
                Div=a.Div,
                Com=a.Com,
                Divisional=a.Divisional,
                Area=a.Area,
                Zona=a.Zona,
                Distrito=a.Distrito,
                Ugestion=a.Ugestion,
                Usuario=a.Usuario,
                FechaCreacion=a.FechaCreacion,
                Estado=a.Estado,
                Red=a.Red,
                Aliado=a.Aliado,
                NombreComunidad=a.NombreComunidad,
                Departamento=a.Departamento
                
            }).ToList());
            return result;
        }
        public MaestroNodo GetInformacionNodoId(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            return unitOfWork.maestroNodos.Find(c => c.IdNodo == id).FirstOrDefault();

        }

    }
}
