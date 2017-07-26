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
    public class CierreCicloService : ICierreCicloService
    {
        public List<DatoConsultaCCResidencialPredictivo> ListaResidencialPredictivoDeCuenta(float cuenta)
        {
            CierreCicloBusiness cierreCicloBusi = new CierreCicloBusiness();
           return  cierreCicloBusi.HistorialDeCuentaResidencialPredictivo(cuenta);
        }

        public CcResidencialPredictivoInfo GetResidencialPredictivoInfoPorId(int id)
        {
            CierreCicloBusiness cierreCicloBusi = new CierreCicloBusiness();
            return cierreCicloBusi.RecibirResidencialPredictivoInfoPorId(id);
        }

        public CcBaseMejoramiento RecibirBaseMejoramientoDeResdPredInfo(double cuenta, string problemaEdAMotivo)
        {
            CierreCicloBusiness cierreCicloBusi = new CierreCicloBusiness();
            DateTime ultimaFechaDeCuenta = cierreCicloBusi.GetUltimaFechaDeCuenta(cuenta, problemaEdAMotivo);
            return cierreCicloBusiGetBaseMejoramientoDeResdPredInfo(cuenta, problemaEdAMotivo, ultimaFechaDeCuenta);
        }

        private CcBaseMejoramiento cierreCicloBusiGetBaseMejoramientoDeResdPredInfo(double cuenta, string problemaEdAMotivo, DateTime ultimaFechaDeCuenta)
        {
            throw new NotImplementedException();
        }
    }
}
