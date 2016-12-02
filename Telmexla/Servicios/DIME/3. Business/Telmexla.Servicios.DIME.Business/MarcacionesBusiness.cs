using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Business
{
    public class MarcacionesBusiness
    {
        public void RegistrarNuevaMarcacion(MaestroMarcacione marcacion) {
            string nuevo = Regex.Replace(marcacion.QueHacerHtml, "<.*?>", String.Empty);
            nuevo = Regex.Replace(nuevo, "\\r", String.Empty);
            nuevo = Regex.Replace(nuevo, "\\t", " ");
            nuevo = Regex.Replace(nuevo, "\\n", " ");
            nuevo = Regex.Replace(nuevo, "&nbsp;", " ");
            nuevo = Regex.Replace(nuevo, "&otilde;", String.Empty);
            marcacion.QueHacer = nuevo;
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            unitOfWork.maestroMarcaciones.Add(marcacion);
            unitOfWork.Complete();
        }
    }
}
