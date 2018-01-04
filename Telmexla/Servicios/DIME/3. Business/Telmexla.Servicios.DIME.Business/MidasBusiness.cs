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
        public CargueBaseMidas TraeCuentaMidas(decimal CuentaCliente)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            CargueBaseMidas Registro = UnitOfWork.CargueBaseMidas.Find(x => x.CuentaCliente == CuentaCliente).FirstOrDefault();
            return Registro;
        }
<<<<<<< HEAD
        public List<ArbolesMidas> ArbolDeGestionAgenteMidas(decimal IdPadre)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<ArbolesMidas> Lista = new List<ArbolesMidas>();
            Lista = unitOfWork.ArbolesMidas.Find(x => x.IdPadre == IdPadre && x.EstadoArbol.Equals("ACTIVO")).ToList();
            Lista = Lista.OrderBy(x => x.Descripcion).ToList();
            return Lista;
        }


=======
>>>>>>> 114f4a5efe85d6a92b37b98b72b3d5d44b44bf9e
    }
}
