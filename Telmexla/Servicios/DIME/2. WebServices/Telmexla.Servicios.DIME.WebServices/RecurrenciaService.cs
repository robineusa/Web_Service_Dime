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
        public List<MaestroOpcionesRecurrencia> GetOpcionesRecurrencia(int idProceso)
        {
            ArbolesDeTipificacion ArbolBusiness = new ArbolesDeTipificacion();
            return ArbolBusiness.GetOpcionesRecurrencia(idProceso);
        }
        public List<MaestroFallaEspecifica> GetFallaEspecifica(int idOpcionesRecurrencia)
        {
            ArbolesDeTipificacion ArbolBusiness = new ArbolesDeTipificacion();
            return ArbolBusiness.GetFallaEspecifica(idOpcionesRecurrencia);
        }
        public List<MaestroFallaCausaRaiz> GetFallaCausaRaiz(int idFallaEspecifica)
        {
            ArbolesDeTipificacion ArbolBusiness = new ArbolesDeTipificacion();
            return ArbolBusiness.GetFallaCausaRaiz(idFallaEspecifica);
        }
        public void EliminaCuentaRecurrencia(decimal Cuenta)
        {
            RecurrenciaBusiness recurrenciaBusiness = new RecurrenciaBusiness();
            recurrenciaBusiness.EliminaCuentaRecurrencia(Cuenta);
        }

        public void InsertarGRecurrencia(GPrincipalRecurrencia recurrencia)
        {
            RecurrenciaBusiness recurrenciaBusiness = new RecurrenciaBusiness();
            recurrenciaBusiness.InsertarGRecurrencia(recurrencia);
        }
        public void ActualizarGRecurrencia(GPrincipalRecurrencia recurrencia)
        {
            RecurrenciaBusiness recurrenciaBusiness = new RecurrenciaBusiness();
            recurrenciaBusiness.ActualizarGRecurrencia(recurrencia);
        }
        public GPrincipalRecurrencia TraerGPrinRecurrencia(int CuentaCliente)
        {
            RecurrenciaBusiness recurrenciaBusiness = new RecurrenciaBusiness();
            return recurrenciaBusiness.TraerGPrinRecurrencia(CuentaCliente);
        }
        public List<GPrincipalRecurrencia> ListaSeguimientosRecurrencia()
        {
            RecurrenciaBusiness recurrenciaBusiness = new RecurrenciaBusiness();
            return recurrenciaBusiness.ListaSeguimientosRecurrencia();
        }
        public void UsuarioGestionandoGRecurrencia(int idUsuario, int idCaso)
        {
            RecurrenciaBusiness recurrenciaBusiness = new RecurrenciaBusiness();
            recurrenciaBusiness.UsuarioGestionandoGRecurrencia(idUsuario, idCaso);
        }
    }
}