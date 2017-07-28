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
            var cedula = 1012378617;
            var TT = "INCUMPLIMIENTO";
            int nr = 0;

            var nodo = "AAE";
            BackEliteService BES = new BackEliteService();
            BEPSolicitudes RESUL = new BEPSolicitudes();
            RESUL = BES.ApartarCuentadeSolcitudBackElita(cedula, nr);
            RESUL.DetalleMalEscalado = "NO APLICA";
            RESUL.Gestion = "25";
            BES.ActualizaSolicitud(RESUL);


            var Z = "";
            
        }
    }
}
