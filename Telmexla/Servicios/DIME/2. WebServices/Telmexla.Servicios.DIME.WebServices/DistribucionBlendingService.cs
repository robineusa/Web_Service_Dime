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
    public class DistribucionBlendingService : IDistribucionBlendingService
    {
        public BlendingFueraNivel TraerInformacionCuentaFueraNiveles(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraerInformacionCuentaFueraNiveles(CuentaCliente);

        }
        public ClientesTodo TraerInformacionCuentaBlending(int idAsesor, string formulario, string aliado, string operacion, string campana)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraerInformacionCuentaBlending(idAsesor, formulario, aliado, operacion, campana, 0);

        }
        public void EliminaCuentaGestionadaDistribucion(DistribucionBlending Registro)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            distribucionesBlendingBusiness.EliminaCuentaGestionadaDistribucion(Registro);
        }
        public void InsertarCuentaColaDistribucionBlending(DistribucionBlending Registro)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            distribucionesBlendingBusiness.InsertarCuentaColaDistribucionBlending(Registro);
        }
        public void InsertarRegistroFueraNiveles(GBPFueraNiveles PFueraNivel)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            distribucionesBlendingBusiness.InsertarRegistroFueraNiveles(PFueraNivel);
        }
        public void ActualizarGestionFueraNiveles(GBPFueraNiveles PFueraNivel)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            distribucionesBlendingBusiness.ActualizarGestionFueraNiveles(PFueraNivel);

        }
        public bool ValidarCuentaEnFueraNiveles(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.ValidarCuentaEnFueraNiveles(CuentaCliente);
        }

        public GBPFueraNiveles TraeInformacionActualFueraNiveles(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraeInformacionActualFueraNiveles(CuentaCliente);
        }
        public List<GBLFueraNiveles> TraeListaGestionUsuarioFueraNiveles(string Usuario)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraeListaGestionUsuarioFueraNiveles(Usuario);
        }
        public List<GBPFueraNiveles> TraeListaSeguimientosUsuarioFueraNiveles(string Usuario)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraeListaSeguimientosUsuarioFueraNiveles(Usuario);
        }
        public ClientesTodo AsignarIdCuentaDistribucionBlending(decimal CuentaCliente, string Formulario, string Aliado, string Operacion, string Campana, int Id)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.AsignarIdCuentaDistribucionBlending(CuentaCliente, Formulario, Aliado, Operacion, Campana, Id);
        }
        public GBPFueraNiveles TraerDatosCuentaSelectFueraNivel(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraerDatosCuentaSelectFueraNivel(CuentaCliente);

        }

        public int CantidadToquesCuentaFueraNiveles(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.CantidadToquesCuentaFueraNiveles(CuentaCliente);
        }
        public GBLFueraNiveles TraeUltimaGestionCuenta(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraeUltimaGestionCuenta(CuentaCliente);
        }
        public List<GBPFueraNivelesCA> ConsultaAdminFueraNivelesP(DateTime FechaInicial, DateTime FechaFinal)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.ConsultaAdminFueraNivelesP(FechaInicial, FechaFinal);
        }
        public List<GBLFueraNivelesCA> ConsultaAdminFueraNivelesL(DateTime FechaInicial, DateTime FechaFinal)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.ConsultaAdminFueraNivelesL(FechaInicial, FechaFinal);
        }

        //GESTION BLENDING RENTABILIZACION
        public GBC_Rentabilizacion TraerInformacionCuentaRentabilizacion(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraerInformacionCuentaRentabilizacion(CuentaCliente);
        }
        public void InsertarRegistroRentabilizacion(GBPRentabilizacion PRentabilizacion)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            distribucionesBlendingBusiness.InsertarRegistroRentabilizacion(PRentabilizacion);
        }
        public void ActualizarGestionRentabilizacion(GBPRentabilizacion PRentabilizacion)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            distribucionesBlendingBusiness.ActualizarGestionRentabilizacion(PRentabilizacion);
        }
        public bool ValidarCuentaEnRentabilizacion(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.ValidarCuentaEnRentabilizacion(CuentaCliente);
        }
        public GBPRentabilizacion TraeInformacionActualRentabilizacion(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraeInformacionActualRentabilizacion(CuentaCliente);
        }
        public List<GBLRentabilizacion> TraeListaGestionUsuarioRentabilizacion(string Usuario)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraeListaGestionUsuarioRentabilizacion(Usuario);
        }
        public List<GBPRentabilizacion> TraeListaSeguimientosUsuarioRentabilizacion(string Usuario)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraeListaSeguimientosUsuarioRentabilizacion(Usuario);
        }
        public GBPRentabilizacion TraerDatosCuentaSelectRentabilizacion(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraerDatosCuentaSelectRentabilizacion(CuentaCliente);
        }
        public int CantidadToquesCuentaRentabilizacion(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.CantidadToquesCuentaRentabilizacion(CuentaCliente);
        }
        public GBLRentabilizacion TraeUltimaGestionCuentaRentabilizacion(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraeUltimaGestionCuentaRentabilizacion(CuentaCliente);
        }
        public List<GBPRentabilizacionCA> ConsultaAdminRentabilizacionP(DateTime FechaInicial, DateTime FechaFinal)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.ConsultaAdminRentabilizacionP(FechaInicial, FechaFinal);
        }
        public List<GBLRentabilizacionCA> ConsultaAdminRentabilizacionL(DateTime FechaInicial, DateTime FechaFinal)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.ConsultaAdminRentabilizacionL(FechaInicial, FechaFinal);
        }

        //GESTION BLENDING PRODUCTO
        public GBCProducto TraerInformacionCuentaProducto(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraerInformacionCuentaProducto(CuentaCliente);
        }
        public void InsertarRegistroProducto(GBPProducto GBPProducto)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            distribucionesBlendingBusiness.InsertarRegistroProducto(GBPProducto);
        }
        public void ActualizarGestionProducto(GBPProducto GBPProducto)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            distribucionesBlendingBusiness.ActualizarGestionProducto(GBPProducto);
        }
        public bool ValidarCuentaEnProducto(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.ValidarCuentaEnProducto(CuentaCliente);
        }
        public GBPProducto TraeInformacionActualProducto(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraeInformacionActualProducto(CuentaCliente);
        }
        public List<GBLProducto> TraeListaGestionUsuarioProucto(string Usuario)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraeListaGestionUsuarioProucto(Usuario);
        }
        public List<GBPProducto> TraeListaSeguimientosUsuarioProducto(string Usuario)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraeListaSeguimientosUsuarioProducto(Usuario);
        }
        public GBPProducto TraerDatosCuentaSelectProducto(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraerDatosCuentaSelectProducto(CuentaCliente);
        }
        public int CantidadToquesCuentaProducto(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.CantidadToquesCuentaProducto(CuentaCliente);
        }
        public GBLProducto TraeUltimaGestionCuentaProducto(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraeUltimaGestionCuentaProducto(CuentaCliente);
        }
        public List<GBPProductoCA> ConsultaAdminProductoP(DateTime FechaInicial, DateTime FechaFinal)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.ConsultaAdminProductoP(FechaInicial, FechaFinal);
        }
        public List<GBLProductoCA> ConsultaAdminProductoL(DateTime FechaInicial, DateTime FechaFinal)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.ConsultaAdminProductoL(FechaInicial, FechaFinal);
        }


        //GESTION BLENDING DOCSIS Y OVERLAP
        public GBCDocsis TraerInformacionCuentaDocsis(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraerInformacionCuentaDocsis(CuentaCliente);
        }
        public void InsertarRegistroDocsis(GBPDocsis GBPDocsis)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            distribucionesBlendingBusiness.InsertarRegistroDocsis(GBPDocsis);
        }
        public void ActualizarGestionDocsis(GBPDocsis GBPDocsis)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            distribucionesBlendingBusiness.ActualizarGestionDocsis(GBPDocsis);
        }
        public bool ValidarCuentaEnDocsis(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.ValidarCuentaEnDocsis(CuentaCliente);
        }
        public GBPDocsis TraeInformacionActualDocsis(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraeInformacionActualDocsis(CuentaCliente);
        }
        public List<GBLDocsis> TraeListaGestionUsuarioDocsis(string Usuario)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraeListaGestionUsuarioDocsis(Usuario);
        }
        public List<GBPDocsis> TraeListaSeguimientosUsuarioDocsis(string Usuario)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraeListaSeguimientosUsuarioDocsis(Usuario);
        }
        public GBPDocsis TraerDatosCuentaSelectDocsis(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraerDatosCuentaSelectDocsis(CuentaCliente);
        }
        public int CantidadToquesCuentaDocsis(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.CantidadToquesCuentaDocsis(CuentaCliente);
        }
        public GBLDocsis TraeUltimaGestionCuentaDocsis(decimal CuentaCliente)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.TraeUltimaGestionCuentaDocsis(CuentaCliente);
        }
        public List<GBPDocsisCA> ConsultaAdminDocsisP(DateTime FechaInicial, DateTime FechaFinal)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.ConsultaAdminDocsisP(FechaInicial, FechaFinal);
        }
        public List<GBLDocsisCA> ConsultaAdminDocsisL(DateTime FechaInicial, DateTime FechaFinal)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.ConsultaAdminDocsisL(FechaInicial, FechaFinal);
        }
        public List<ConsultaBlendingFormularioDestinoReturnViewModel> ConsultaBlendingFormularioDestino(string aliado)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.ConsultaBlendingFormularioDestino(aliado);
        }
        public List<ConsultaBlendingOperacionDestinoReturnViewModel> ConsultaBlendingOperacionDestino(string aliado, string formulario)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.ConsultaBlendingOperacionDestino(aliado, formulario);
        }
        public List<ConsultaBlendingCampañaDestinoReturnViewModel> ConsultaBlendingCampanaDestino(string aliado, string formulario, string operacion)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.ConsultaBlendingCampanaDestino(aliado, formulario, operacion);
        }

    }
}
