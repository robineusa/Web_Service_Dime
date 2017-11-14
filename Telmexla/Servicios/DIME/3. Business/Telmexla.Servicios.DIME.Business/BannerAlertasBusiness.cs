using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Business
{
    public class BannerAlertasBusiness
    {
        public bool ValidarClienteEnConvenioElectronico(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.clientesTodo.Find(c => c.Cuenta == CuentaCliente && c.Convenio.Equals("SI")).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public bool ValidarClienteEnClaroVideo(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.clientesTodo.Find(c => c.Cuenta == CuentaCliente && c.Clarovideo.Equals("SI")).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public bool ValidarClienteEnMejorOferta(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.CuentaSMO.Find(c => c.CuentaCliente == CuentaCliente).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public bool ValidarClienteEnSiembraHD(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.CuentasSiembraHD.Find(c => c.CuentaCliente == CuentaCliente).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public bool ValidarClienteEnMejorasTecnicas(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.CuentasMejorasTecnicas.Find(c => c.Cuenta == CuentaCliente).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public bool ValidarClienteEnFox(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.CargaBaseFoxInbound.Find(c => c.Cuenta == CuentaCliente).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public CuentasSiguienteMejorOferta ConsultarClienteMejorOferta(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            CuentasSiguienteMejorOferta SMO = unitWork.CuentaSMO.Find(x => x.CuentaCliente == CuentaCliente).FirstOrDefault(); ;
            return SMO;
        }
    }
}
