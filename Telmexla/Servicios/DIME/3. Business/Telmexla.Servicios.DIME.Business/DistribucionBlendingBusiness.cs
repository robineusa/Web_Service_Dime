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
    public class DistribucionBlendingBusiness
    {
        //este proceso aparta cuenta blending y trae la informacion de clientes todos
        public ClientesTodo TraerInformacionCuentaBlending(int idAsesor, string formulario, string aliado,string operacion, string campana)
        {

            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<decimal> cuentasGestionandoAsesor = unitOfWork.distribucionesBlending.Find(c => c.UsuarioGestionando == idAsesor && c.FormularioDestino.Equals(formulario)).Select(x => x.CuentaCliente).ToList();
            if (cuentasGestionandoAsesor.Count > 0)
            {
                ClientesBusiness clientesBusiness = new ClientesBusiness();
                return clientesBusiness.ObtenerClienteCompleto(Convert.ToInt32(cuentasGestionandoAsesor[0]));
            }
            else
            {
                unitOfWork.distribucionesBlending.ApartarCuentaAGestionarBlendingAsesor(idAsesor,formulario, aliado,operacion, campana);
                return TraerInformacionCuentaBlending(idAsesor, formulario,aliado,operacion,campana);
            }

        }

        /////NUEVOS PROCESOS DE GESTION BLENDING
        // CABLE MODEM FUERA DE NIVELES
        public BlendingFueraNivel TraerInformacionCuentaFueraNiveles(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.blendingFueraNiveles.Find(c => c.CuentaCliente == CuentaCliente).FirstOrDefault();
        }

    }
}
