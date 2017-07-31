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
    public class RecurrenciaBusiness
    {
        public ClientesTodo TraerInformacionCuentaRecurrencia(int idAsesor, int noRecursividad)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<decimal> cuentasGestionandoAsesor = unitOfWork.RecurrenciaCargaBase.Find(c => c.Usuario_gestionando == idAsesor).Select(x => x.Cuenta).ToList();
            if (cuentasGestionandoAsesor.Count > 0)
            {
                ClientesBusiness clientesBusiness = new ClientesBusiness();
                return clientesBusiness.ObtenerClienteCompleto(Convert.ToInt32(cuentasGestionandoAsesor[0]));
            }
            else
            {
                unitOfWork.RecurrenciaCargaBase.ApartarCuentaaGestionarRecurrencia(idAsesor);
                noRecursividad++;
                if (noRecursividad > 1) return null;
                return TraerInformacionCuentaRecurrencia(idAsesor, noRecursividad);
            }
        }

        public RecurrenciaCargaBase TraerDatosRecurrencia(int idAsesor, int CuentaCliente)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            return unitOfWork.RecurrenciaCargaBase.Find(c => c.Usuario_gestionando == idAsesor && c.Cuenta == CuentaCliente).FirstOrDefault();
        }
    }
}
