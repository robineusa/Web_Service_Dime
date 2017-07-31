using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;
using Telmexla.Servicios.DIME.WebServices;

namespace Telmexla.Servicios.DIME.WebServices
{
    public class RecurrenciaService
    {
        public ClientesTodo TraerInformacionCuentaRecurrencia(int idAsesor)
        {
            RecurrenciaBusiness recurrenciaBusiness = new RecurrenciaBusiness();
            return recurrenciaBusiness.TraerInformacionCuentaRecurrencia(idAsesor, 0);

        }
        public RecurrenciaCargaBase TraerDatosRecurrencia(int idAsesor, int CuentaCliente)
        {
            RecurrenciaBusiness recurrenciaBusiness = new RecurrenciaBusiness();
            return recurrenciaBusiness.TraerDatosRecurrencia(idAsesor, CuentaCliente);
        }
    }
}
