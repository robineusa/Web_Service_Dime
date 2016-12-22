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
    public class MarcacionesService : IMarcacionesService
    {
        public void RegistrarMarcacion(MaestroMarcacione marcacion)
        {
            MarcacionesBusiness marcabusiness = new MarcacionesBusiness();
            marcabusiness.RegistrarNuevaMarcacion(marcacion);
        }

        public MaestroMarcacioneCollection ObtenerMarcacionesPorPalabra(string palabra)
        {
            MarcacionesBusiness marcabusiness = new MarcacionesBusiness();
           return  marcabusiness.ObtenerMarcacionesPorPalabra(palabra);

        }


        public MaestroMarcacione TraerMarcacionPorId(int id)
        {
            MarcacionesBusiness marcabusiness = new MarcacionesBusiness();
            return marcabusiness.ObtenerMarcacionPorId(id);
        }
        public MaestroMarcacioneCollection ListaMarcaciones()
        {
            MarcacionesBusiness marcabusiness = new MarcacionesBusiness();
            return marcabusiness.ObtenerListaMarcaciones();
        }

        public int GetIdMarcacionPorNombre(string nombre)
        {
            MarcacionesBusiness marcabusiness = new MarcacionesBusiness();
            return marcabusiness.GetIdMarcacion(nombre);
        }

        public List<String> ListaNombreCodDeSubmarcacion(string submarcacion)
        {

            MarcacionesBusiness marcabusiness = new MarcacionesBusiness();
            return marcabusiness.GetListraNombreCodigo(submarcacion);
        }

        public void EliminarMarcacion(int id)
        {
            MarcacionesBusiness marcabusiness = new MarcacionesBusiness();
           marcabusiness.RemoverMarcacion(id);
        }

        public MaestroMarcacione GetMarcacionPorId(int id)
        {
            MarcacionesBusiness marcabusiness = new MarcacionesBusiness();
            return marcabusiness.GetMarcacionDeId( id);
        }

        public void ActualizarMarcacion(MaestroMarcacione marcacion)
        {
            MarcacionesBusiness marcabusiness = new MarcacionesBusiness();
            marcabusiness.ActualizarMarcacion(marcacion);
        }

        public PqrMaestroCodCierreCollection ListaCodigosDeCierre()
        {
            MarcacionesBusiness marcabusiness = new MarcacionesBusiness();
            return marcabusiness.GetCodigosCierreTotal();
        }

        public void EliminarCodigoCierre(int id)
        {
            MarcacionesBusiness marcabusiness = new MarcacionesBusiness();
            marcabusiness.EliminarCodigoCierre(id);
        }

        public void AgregarCodigoCierre(PqrMaestroCodCierre codigoCierre)
        {
            MarcacionesBusiness marcabusiness = new MarcacionesBusiness();
            marcabusiness.InsertCodigoCierre(codigoCierre);
        }

        public void ActualizarCodCierre(PqrMaestroCodCierre codigoCierre)
        {
            MarcacionesBusiness marcabusiness = new MarcacionesBusiness();
            marcabusiness.UpdateCodigoCierre(codigoCierre);
        }

        public PqrMaestroCodCierre CodigoCierrePorId(int idCierre)
        {
            MarcacionesBusiness marcaBusiness = new MarcacionesBusiness();
            return marcaBusiness.GetCodigoCierrePorId(idCierre);
        }
    }
}
