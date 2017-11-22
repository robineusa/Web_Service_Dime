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
    public class RetencionService: IRetencionService
    {
        public decimal RegistrarSolicitudRetencion(RSPSeguimientos Solicitud)
        {
            RetencionBusiness retencionbusiness = new RetencionBusiness();
            return retencionbusiness.RegistrarSolicitudRetencion(Solicitud);
        }
    }
}
