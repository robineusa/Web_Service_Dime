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
    public class BannerAlertasService: IBannerAlertasService
    {
        public bool ValidarClienteEnConvenioElectronico(decimal CuentaCliente)
        {
            BannerAlertasBusiness banneralertasbusiness = new BannerAlertasBusiness();
            return banneralertasbusiness.ValidarClienteEnConvenioElectronico(CuentaCliente);
        }
        public bool ValidarClienteEnClaroVideo(decimal CuentaCliente)
        {
            BannerAlertasBusiness banneralertasbusiness = new BannerAlertasBusiness();
            return banneralertasbusiness.ValidarClienteEnClaroVideo(CuentaCliente);
        }
        public bool ValidarClienteEnMejorOferta(decimal CuentaCliente)
        {
            BannerAlertasBusiness banneralertasbusiness = new BannerAlertasBusiness();
            return banneralertasbusiness.ValidarClienteEnMejorOferta(CuentaCliente);
        }
        public bool ValidarClienteEnSiembraHD(decimal CuentaCliente)
        {
            BannerAlertasBusiness banneralertasbusiness = new BannerAlertasBusiness();
            return banneralertasbusiness.ValidarClienteEnSiembraHD(CuentaCliente);
        }
        public bool ValidarClienteEnMejorasTecnicas(decimal CuentaCliente)
        {
            BannerAlertasBusiness banneralertasbusiness = new BannerAlertasBusiness();
            return banneralertasbusiness.ValidarClienteEnMejorasTecnicas(CuentaCliente);
        }
        public bool ValidarClienteEnFox(decimal CuentaCliente)
        {
            BannerAlertasBusiness banneralertasbusiness = new BannerAlertasBusiness();
            return banneralertasbusiness.ValidarClienteEnFox(CuentaCliente);
        }
        public CuentasSiguienteMejorOferta ConsultarClienteMejorOferta(decimal CuentaCliente)
        {
            BannerAlertasBusiness banneralertasbusiness = new BannerAlertasBusiness();
            return banneralertasbusiness.ConsultarClienteMejorOferta(CuentaCliente);
        }
    }
}
