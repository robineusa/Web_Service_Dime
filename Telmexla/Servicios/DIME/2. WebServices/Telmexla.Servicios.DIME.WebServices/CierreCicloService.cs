using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.IWebServices;

namespace Telmexla.Servicios.DIME.WebServices
{
    public class CierreCicloService : ICierreCicloService
    {
        public List<DatoConsultaCCResidencialPredictivo> ListaResidencialPredictivoDeCuenta(float cuenta)
        {
            CierreCicloBusiness cierreCicloBusi = new CierreCicloBusiness();
           return  cierreCicloBusi.HistorialDeCuentaResidencialPredictivo(cuenta);
        }
    }
}
