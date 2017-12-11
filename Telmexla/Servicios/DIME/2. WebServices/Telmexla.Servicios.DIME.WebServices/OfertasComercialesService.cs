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
    public class OfertasComercialesService
    {
        public decimal RegistrarImagen(IMGOfertasComeciales Imagen)
        {
            OfertasComercialesBusiness OfertasBusiness = new OfertasComercialesBusiness();
            return OfertasBusiness.RegistrarImagen(Imagen);
        }
        public IMGOfertasComeciales ConsultarImagenPorId(decimal IdImagen)
        {
            OfertasComercialesBusiness OfertasBusiness = new OfertasComercialesBusiness();
            return OfertasBusiness.ConsultarImagenPorId(IdImagen);
        }
        public void ActualizarImagen(IMGOfertasComeciales Imagen)
        {
            OfertasComercialesBusiness OfertasBusiness = new OfertasComercialesBusiness();
            OfertasBusiness.ActualizarImagen(Imagen);
        }
        public List<IMGOfertasComeciales> ListaDeImagenesAdmin()
        {
            OfertasComercialesBusiness OfertasBusiness = new OfertasComercialesBusiness();
            return OfertasBusiness.ListaDeImagenesAdmin();
        }
        public List<IMGOfertasComeciales> ListaDeImagenesActivas()
        {
            OfertasComercialesBusiness OfertasBusiness = new OfertasComercialesBusiness();
            return OfertasBusiness.ListaDeImagenesActivas();
        }
    }
}
