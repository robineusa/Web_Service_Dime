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
            return distribucionesBlendingBusiness.TraerInformacionCuentaBlending(idAsesor, formulario, aliado, operacion, campana,0);

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

    }
}
