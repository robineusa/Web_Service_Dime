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
   public class VisitasAutorizadasService: IVisitasAutorizadasService
    {
        public void AgregarNuevaVisita(VisitasAutorizadas Visita)
        {
            VisitasAutorizadasBusiness visitasbusines = new VisitasAutorizadasBusiness();
            visitasbusines.AgregarNuevaVisita(Visita);
        }
        public List<VisitasAutorizadas> ConsultaBaseVisitasAutorizadas(DateTime FechaInicial, DateTime FechaFinal)
        {
            VisitasAutorizadasBusiness visitasbusines = new VisitasAutorizadasBusiness();
            return visitasbusines.ConsultaBaseVisitasAutorizadas(FechaInicial,FechaFinal);
        }
    }
}
