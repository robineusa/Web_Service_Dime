using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.WebServices;
using Telmexla.Servicios.DIME.WebServices.MainWebService;
using Telmexla.Servicios.DIME.IWebServices;
using Telmexla.Servicios.DIME.Entity;
using System.Diagnostics;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Helpers.Encription;

namespace Telmexla.Servicios.DIME.Ejecutor
{
    class Program
    {
        static void Main()
        {
            //POMSolicitudesService poms = new POMSolicitudesService();
            //POMSolicitudes sol = new POMSolicitudes();
            //DateTime fecha = DateTime.Now;
            //sol.CuentaCliente = 307;
            //sol.FechaSolicitud = fecha;
            //sol.TelefonoCeluar = 3228451001;
            //sol.CorreoElectronico = "robinson.neusa@gmail.com";
            //sol.MovilClaro = "SI";
            //sol.UsuarioSolicitud = "1032381244";
            //poms.RegistrarSolicitudPom(sol);
            //var Z = "";

            LoginService log = new LoginService();
            List<string> Users = new List<string>();
            Users.Add("1076622744");
            Users.Add("10766");
            var r = log.ListaDatosUsuariosDimePorCedulas(Users);
            var z = "";
        }
    }
}
