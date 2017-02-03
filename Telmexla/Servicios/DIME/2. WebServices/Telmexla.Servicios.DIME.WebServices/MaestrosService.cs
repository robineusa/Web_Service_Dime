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
    public class MaestrosService : IMaestrosService
    {


        public MaestroOutboundTipoContactoCollection ObtenerTiposDeContactoDeGestion(decimal gestionId)
        {
            ArbolesDeTipificacion arbolesTipi = new ArbolesDeTipificacion();
            return arbolesTipi.GetTipoContactosPorGestion(gestionId);
        }


        public MaestroOutboundCierreCollection ObtenerTiposDeCierresDeContacto(decimal contactoId)
        {
            ArbolesDeTipificacion arbolesTipi = new ArbolesDeTipificacion();
            return arbolesTipi.GetTipoCierrePorContacto(contactoId);
        }

        public MaestroOutboundRazonCollection ObtenerTiposDeRazonDeCierres(decimal cierreId)
        {
            ArbolesDeTipificacion arbolesTipi = new ArbolesDeTipificacion();
            return arbolesTipi.GetTipoRazonPorTipoCierre(cierreId);
        }

        public MaestroOutboundCausaCollection ObtenerTiposDeCausasDeRazon(decimal razonId)
        {
            ArbolesDeTipificacion arbolesTipi = new ArbolesDeTipificacion();
            return arbolesTipi.GetTipoCausanPorTipoRazon(razonId);

        }

        public MaestroOutboundMotivoCollection ObtenerTiposDeMotivoDeCausas(decimal causaId)
        {
            ArbolesDeTipificacion arbolesTipi = new ArbolesDeTipificacion();
            return arbolesTipi.GetTipoMotivoPorTipoCausa(causaId);
        }
       
    }
}
