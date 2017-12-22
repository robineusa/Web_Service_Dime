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
            CierreExperienciaService CEService = new CierreExperienciaService();
            CEPLiberaciones model = new CEPLiberaciones();

            model.IdGestion = 6;
            model.CuentaCliente = 1;
            //CEService.RegistrarLiberaciones(model);

            CEService.ActualizarLiberaciones(model);

            var z = "";
        }
    }
}
