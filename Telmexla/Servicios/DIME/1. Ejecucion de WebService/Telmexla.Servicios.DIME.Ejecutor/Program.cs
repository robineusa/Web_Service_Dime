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
            List<string> gerencias = new List<string>();
            gerencias.Add("1");
            
            
            List<string> Operaciones = new List<string>();
            Operaciones.Add("1");
            Operaciones.Add("2");
            Operaciones.Add("3");
            decimal id = 2;
            bis.RegistrarOperacionesEnIncidente(Operaciones, id);
            var z = "";
        }
    }
}
