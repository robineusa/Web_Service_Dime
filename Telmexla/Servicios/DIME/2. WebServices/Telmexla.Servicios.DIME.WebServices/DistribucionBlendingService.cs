using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;
using Telmexla.Servicios.DIME.WebServices;
namespace Telmexla.Servicios.DIME.WebServices
{
    public class DistribucionBlendingService: IDistribucionBlendingService
    {
        public BlendingFueraNivel TraerInformacionCuentaFueraNiveles(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraerInformacionCuentaFueraNiveles(CuentaCliente);

        }
        public ClientesTodo TraerInformacionCuentaBlending(int idAsesor, string formulario, string aliado, string operacion, string campana)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraerInformacionCuentaBlending(idAsesor,formulario,aliado,operacion,campana);

        }
    }
}
