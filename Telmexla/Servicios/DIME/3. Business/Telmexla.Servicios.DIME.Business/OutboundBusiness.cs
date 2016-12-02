using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Business
{
   public class OutboundBusiness
    {



        public ClientesTodo DatosClienteAutomaticos(int idAsesor, string gestionBlendingActual, int noRecursividad)
        {

            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<int> cuentasGestionandoAsesor = unitOfWork.gestionesOutbound.Find(c => c.UsuarioGestionando == idAsesor && c.NombreBase.Equals(gestionBlendingActual)).Select(x => x.Cuenta).ToList();
            if (cuentasGestionandoAsesor.Count>0)
            {
                ClientesBusiness clientesBusiness = new ClientesBusiness();
                return clientesBusiness.ObtenerClienteCompleto(cuentasGestionandoAsesor[0]);
            }
            else
            {
                unitOfWork.gestionesOutbound.ApartarCuentaAGestionarAsesor(gestionBlendingActual, idAsesor);
                noRecursividad++;
                if (noRecursividad > 1) return null;
                return DatosClienteAutomaticos(idAsesor, gestionBlendingActual, noRecursividad);               
            }

        }






    }
}
