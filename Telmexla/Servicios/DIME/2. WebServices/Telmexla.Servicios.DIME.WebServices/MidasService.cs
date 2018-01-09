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
    public class MidasService : IMidasService
    {
        public List<ArbolesMidas> ListasDeArbolesMidasAdmin(decimal IdPadre)
        {
            MidasBusiness miadasBusiness = new MidasBusiness();
            return miadasBusiness.ListasDeArbolesMidasAdmin(IdPadre);
        }
        public void ActualizarArbolesMidas(ArbolesMidas Arbol)
        {
            MidasBusiness miadasBusiness = new MidasBusiness();
            miadasBusiness.ActualizarArbolesMidas(Arbol);
        }
        public void RegistrarNuevoArbolesMidas(ArbolesMidas Arbol)
        {
            MidasBusiness miadasBusiness = new MidasBusiness();
            miadasBusiness.RegistrarNuevoArbolesMidas(Arbol);
        }
        public ArbolesMidas TraerArbolMidasPorId(decimal IdArbol)
        {
            MidasBusiness miadasBusiness = new MidasBusiness();
            return miadasBusiness.TraerArbolMidasPorId(IdArbol);
        }
        public CargueBaseMidas TraeCuentaMidas(decimal CuentaCliente)
        {
            MidasBusiness miadasBusiness = new MidasBusiness();
            return miadasBusiness.TraeCuentaMidas(CuentaCliente);
        }
        public List<ArbolesMidas> ArbolDeGestionAgenteMidas(decimal IdPadre)
        {
            MidasBusiness miadasBusiness = new MidasBusiness();
            return miadasBusiness.ArbolDeGestionAgenteMidas(IdPadre);
        }
        public void RegistrarMidasTipificador(GPMMidas model)
        {
            MidasBusiness miadasBusiness = new MidasBusiness();
            miadasBusiness.RegistrarMidasTipificador(model);
        }
        public void ActualizarMidasTipificador(GPMMidas model)
        {
            MidasBusiness miadasBusiness = new MidasBusiness();
            miadasBusiness.ActualizarMidasTipificador(model);
        }
        public List<GPMMidas> TraerSeguimientosTipificador()
        {
            MidasBusiness miadasBusiness = new MidasBusiness();
            return miadasBusiness.TraerSeguimientosTipificador();
        }
        public List<GPMMidas> CargaHistorialCuenta(decimal Cuenta)
        {
            MidasBusiness miadasBusiness = new MidasBusiness();
            return miadasBusiness.CargaHistorialCuenta(Cuenta);
        }
        public GPMMidas VerificaCliente(decimal CuentaCliente)
        {
            MidasBusiness miadasBusiness = new MidasBusiness();
            return miadasBusiness.VerificaCliente(CuentaCliente);
        }
        public List<GPMMidas> ConsultaMidasAdminPrincipal(DateTime FechaInicial, DateTime FechaFinal)
        {
            MidasBusiness miadasBusiness = new MidasBusiness();
            return miadasBusiness.ConsultaMidasAdminPrincipal(FechaInicial, FechaFinal);
        }
        public List<GLMMidas> ConsultaMidasAdminLog(DateTime FechaInicial, DateTime FechaFinal)
        {
            MidasBusiness miadasBusiness = new MidasBusiness();
            return miadasBusiness.ConsultaMidasAdminLog(FechaInicial, FechaFinal);
        }

    }
}
