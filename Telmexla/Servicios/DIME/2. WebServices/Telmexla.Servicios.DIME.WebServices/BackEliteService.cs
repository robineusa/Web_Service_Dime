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
    public class BackEliteService: IBackEliteService
    {
        public void RegistrarSolicitud(BEPSolicitudes Solicitud)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            backelitebusiness.RegistrarSolicitud(Solicitud);
        }
        public void ActualizaSolicitud(BEPSolicitudes Solicitud)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            backelitebusiness.ActualizaSolicitud(Solicitud);
        }
        public List<BEMTipoDeEscalamientos> ListaTipoDeEscalamientos()
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.ListaTipoDeEscalamientos();

        }
        public List<BEMDetalleEscalamientos> ListaDetalleDeEscalamientos(decimal IdTipo)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.ListaDetalleDeEscalamientos(IdTipo);
        }
        public List<BEMRazonMalEscalamiento> ListaRazonesMalEscalamiento(decimal IdTipo)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.ListaRazonesMalEscalamiento(IdTipo);
        }
        public List<BEMDetalleDeGestion> ListaDetallesDeGestion(decimal IdTipo)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.ListaDetallesDeGestion(IdTipo);

        }
        public BEMDetalleDeGestion DetalleGestionPorId(decimal IdGestion)
        {
            BackEliteBusiness backelitebusiness = new BackEliteBusiness();
            return backelitebusiness.DetalleGestionPorId(IdGestion);
        }
    }
}
