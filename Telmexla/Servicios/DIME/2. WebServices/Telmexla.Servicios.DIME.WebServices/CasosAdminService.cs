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
    public class CasosAdminService : ICasosAdminService
    {

        public IngresoCollection ListaIngresosPorTicketRr(string noTicket)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            return ingresoBusi.GetIngresosPorCuentaPorTicket(noTicket);
        }

        public IngresoCollection ListaIngresosPorUsuarioCreacion(string ccUsuario)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            return ingresoBusi.ListaIngresosPorUsuarioCreacion(ccUsuario);
        }

        public List<DatoConsultaPaloteo> ListaPaloteo(DateTime inicial, DateTime final)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            return ingresoBusi.GetNotasIngresosYUsuarioData(inicial, final);
        }

        public List<String> ListaAliadosActualesDeHolos()
        {
            ListasSelectBusiness listaBusiness = new ListasSelectBusiness();
            return listaBusiness.ListaDeAliadosHolos();
        }

        public List<DatoConsultaGestionAdmin> ListaGestionAdmin(DateTime inicial, DateTime final, string aliado)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            return ingresoBusi.ListaNotasIngresosYIngresosPorAliado(inicial, final, aliado);
        }

    }
}
