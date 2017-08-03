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
<<<<<<< HEAD
            BackEliteService bes = new BackEliteService();
            var cuenta = 73689564;
            var ot = 789456123;
            var proceso = "4";

            var r = bes.ValidarCuentaEnBackElite(cuenta,ot,proceso);

=======
            RecurrenciaService rec = new RecurrenciaService();
            var r = rec.TraerGPrinRecurrencia(307);
            var h = rec.GetOpcionesRecurrencia(1);
>>>>>>> 87a4bc735305ec15f256b0dbe340faa747e31f8a
            var z = "";       
        }
    }
}
