﻿using System;
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
    public class ActivacionSiembraHDService : IActivacionSiembraHDService
    {
        public List<CuentasSiembraHD> BuscarCuentaSiembraHD(decimal cuentacliente)
        {
            CuentasSiembraHDBusiness cuentasbusines = new CuentasSiembraHDBusiness();
            return cuentasbusines.BuscarCuentaSiembraHD(cuentacliente);
        }
        public void InsertarSiembraHDInbound(SiembraHD siembra)
        {
            SiembraHDBusiness activacionbusiness = new SiembraHDBusiness();
            activacionbusiness.InsertarSiembraHDInbound(siembra);
        }
        public List<CuentasSiguienteMejorOferta> BuscarCuentaSMO(decimal cuentacliente)
        {
            CuentasSiembraHDBusiness cuentasbusines = new CuentasSiembraHDBusiness();
            return cuentasbusines.BuscarCuentaSMO(cuentacliente);
        }
        public void InsertarSMOInbound(SiguienteMejorOferta smo)
        {
            SiembraHDBusiness activacionbusiness = new SiembraHDBusiness();
            activacionbusiness.InsertarSMOInbound(smo);
        }

        public SmoRentaActual RentaActualPorCuentaCalRentas(string cuenta)
        {
            SiembraHDBusiness activacionbusiness = new SiembraHDBusiness();
            return activacionbusiness.ConsultaRentaActualDeCuenta(cuenta);
        }

        public SmoTarifaActual TarifaActualDeDatos(string estrato, string voz, string tv, string internet)
        {
            SiembraHDBusiness activacionbusiness = new SiembraHDBusiness();
            return activacionbusiness.ConsultaTarifaActualDeDatos(estrato, voz, tv, internet);
        }

    }
}
