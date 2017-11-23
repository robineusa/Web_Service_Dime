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
        public decimal RegistrarSolicitudRetencionAutomatico(RSPSeguimientos Solicitud)
        {
            RetencionBusiness retencionbusiness = new RetencionBusiness();
            return retencionbusiness.RegistrarSolicitudRetencionAutomatico(Solicitud);
        }
        public decimal RegistrarSolicitudRetencionFormulario(RSPSeguimientos Solicitud)
        {
            RetencionBusiness retencionbusiness = new RetencionBusiness();
            return retencionbusiness.RegistrarSolicitudRetencionFormulario(Solicitud);
        }
        public List<RSMArboles> ListasDeArbolesRetencion(decimal IdPadre)
        {
            RetencionBusiness retencionbusiness = new RetencionBusiness();
            return retencionbusiness.ListasDeArbolesRetencion(IdPadre);
        }
    }
}
