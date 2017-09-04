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
            BitacoraIncidentesService bis = new BitacoraIncidentesService();
            var SD = "SD457896552";
            var Result = bis.TraeIncidentePorCasoSD(SD);
            var W = "";

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

            //InboundService inb = new InboundService();

            //var r = inb.ListaIngresosDeCuenta("52309424");

            //LoginService lo = new LoginService();

            //List<int> Users = new List<int>();
            //Users.Add(1076622744);
            //int i = 0;
            //foreach (var u in Users)
            //{
            //    string[] permisos;
            //    string x = "42-54-45-55-57-56-58-64-63-62-61-60-59";
            //    //List<string> ListaPermisos = new List<string>();
            //    //var r = lo.ListaAccesosDeUsuario(u);
            //    //int j = 1;
            //    //foreach (var rs in r)
            //    //{
            //    //    //var t = r.Count();
            //    //    if (rs != "92")
            //    //    {
            //    //        x = x.Insert(x.Length, rs.ToString() + " ");
            //    //    }
            //    //    j++;
            //    //}
            //    //x = x.Insert(x.Length, "92");
            //    permisos = x.Split('-');
            //    //ListaPermisos = permisos.OfType<string>().ToList();

            //    var id = lo.RecibirIdUsuario(u);
            //    var idP = lo.IdPerfilDeUsuario(id);
            //    var idL = lo.IdLineaDeUsuario(id);

            //    lo.ActualizarAccesosUsuario(id, idP, idL, permisos, "", "41213");
            //    i++;

            //}



            var z = "";
        }
    }
}
