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
    }
}
