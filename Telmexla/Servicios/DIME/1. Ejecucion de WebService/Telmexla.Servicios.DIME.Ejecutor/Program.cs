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
            TrasladosService ts = new TrasladosService();
            DateTime fecha1 = Convert.ToDateTime("2017-07-31");
            DateTime fecha2 = Convert.ToDateTime("2017-08-01");
            var resultado = ts.ConsultaGeneralTrasladosFallidos(fecha1,fecha2);
            var z = "";

            RecurrenciaService rec = new RecurrenciaService();
            GPrincipalRecurrencia model = new GPrincipalRecurrencia();

            rec.InsertarGRecurrencia(model);
            var y = "";

        }
    }
}
