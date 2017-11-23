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
        public List<RSMArboles> ListasDeArbolesRetencionAdmin(decimal IdPadre)
        {
            RetencionBusiness retencionbusiness = new RetencionBusiness();
            return retencionbusiness.ListasDeArbolesRetencionAdmin(IdPadre);
        }
        public void ActualizarArbolRetencion(RSMArboles Arbol)
        {
            RetencionBusiness retencionbusiness = new RetencionBusiness();
            retencionbusiness.ActualizarArbolRetencion(Arbol);
        }
        public void RegistrarNuevoArbol(RSMArboles Arbol)
        {
            RetencionBusiness retencionbusiness = new RetencionBusiness();
            retencionbusiness.RegistrarNuevoArbol(Arbol);
        }
        public RSMArboles TraerArbolPorId(decimal IdArbol)
        {
            RetencionBusiness retencionbusiness = new RetencionBusiness();
            return retencionbusiness.TraerArbolPorId(IdArbol);
        }
    }
}
