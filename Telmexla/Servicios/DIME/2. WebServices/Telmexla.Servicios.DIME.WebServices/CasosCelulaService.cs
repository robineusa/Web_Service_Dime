using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;

namespace Telmexla.Servicios.DIME.WebServices
{


    public class CasosCelulaService : ICasosCelulaService
    {
        public IngresoCollection ListaCasosAbiertosDeCelulaUser(string lineaUser, string aliadoUser)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            return ingresoBusi.GetCasosAbiertosDeCelulaUser(lineaUser, aliadoUser);
        }

        public IngresoCollection ListaCasosEnSeguimiento(string usuario)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            return ingresoBusi.GetCasosEnSeguimiento(usuario);
        }

        public List<GestionDeCelulaUsr> ListaGestionCasos(DateTime inicial, DateTime final, string idUsr)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            return ingresoBusi.GetGestionesDeCelula(inicial, final, idUsr);
        }

        public IngresoCollection ListaIngresosPorCuenta(string cuenta)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            return ingresoBusi.GetIngresosPorCuenta(cuenta);
        }

        public IngresoCollection ListaIngresosPorId(string id)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            return ingresoBusi.GetIngresoDeId(id);
        }
    }
}
