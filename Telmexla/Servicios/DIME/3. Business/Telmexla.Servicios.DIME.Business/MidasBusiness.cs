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
    public class MidasBusiness
    {
        public List<ArbolesMidas> ListasDeArbolesMidasAdmin(decimal IdPadre)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<ArbolesMidas> Lista = new List<ArbolesMidas>();
            Lista = unitOfWork.ArbolesMidas.Find(x => x.IdPadre == IdPadre).ToList();
            Lista = Lista.OrderBy(x => x.Descripcion).ToList();
            return Lista;
        }
        public void ActualizarArbolesMidas(ArbolesMidas Arbol)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            ArbolesMidas ArbolActualizable = new ArbolesMidas();
            ArbolActualizable = unitOfWork.ArbolesMidas.Find(x => x.IdArbol == Arbol.IdArbol).FirstOrDefault();
            if (ArbolActualizable.IdArbol > 0)
            {
                ArbolActualizable.IdPadre = Arbol.IdPadre;
                ArbolActualizable.Descripcion = Arbol.Descripcion;
                ArbolActualizable.EstadoArbol = Arbol.EstadoArbol;
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void RegistrarNuevoArbolesMidas(ArbolesMidas Arbol)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            unitOfWork.ArbolesMidas.Add(Arbol);
            unitOfWork.Complete();
            unitOfWork.Dispose();
        }
        public ArbolesMidas TraerArbolMidasPorId(decimal IdArbol)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            ArbolesMidas Arbol = new ArbolesMidas();
            Arbol = unitOfWork.ArbolesMidas.Find(x => x.IdArbol == IdArbol).FirstOrDefault();
            if (Arbol.IdArbol > 0)
            {
                return Arbol;
            }
            else
            {
                return new ArbolesMidas();
            }
        }
        public CargueBaseMidas TraeCuentaMidas(decimal CuentaCliente)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            CargueBaseMidas Registro = UnitOfWork.CargueBaseMidas.Find(x => x.CuentaCliente == CuentaCliente).FirstOrDefault();
            return Registro;
        }
    }
}
