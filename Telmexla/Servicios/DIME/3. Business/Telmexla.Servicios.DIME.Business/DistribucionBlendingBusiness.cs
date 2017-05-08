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
    public class DistribucionBlendingBusiness
    {
        //este proceso aparta cuenta blending y trae la informacion de clientes todos
        public ClientesTodo TraerInformacionCuentaBlending(int idAsesor, string formulario, string aliado,string operacion, string campana)
        {

            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<decimal> cuentasGestionandoAsesor = unitOfWork.distribucionesBlending.Find(c => c.UsuarioGestionando == idAsesor && c.FormularioDestino.Equals(formulario)).Select(x => x.CuentaCliente).ToList();
            if (cuentasGestionandoAsesor.Count > 0)
            {
                ClientesBusiness clientesBusiness = new ClientesBusiness();
                return clientesBusiness.ObtenerClienteCompleto(Convert.ToInt32(cuentasGestionandoAsesor[0]));
            }
            else
            {
                unitOfWork.distribucionesBlending.ApartarCuentaAGestionarBlendingAsesor(idAsesor,formulario, aliado,operacion, campana);
                return TraerInformacionCuentaBlending(idAsesor, formulario,aliado,operacion,campana);
            }

        }

        /////NUEVOS PROCESOS DE GESTION BLENDING
        // CABLE MODEM FUERA DE NIVELES
        public BlendingFueraNivel TraerInformacionCuentaFueraNiveles(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.blendingFueraNiveles.Find(c => c.CuentaCliente == CuentaCliente).FirstOrDefault();
        }
        public void EliminaCuentaGestionadaDistribucion(decimal CuentaCliente,string Formulario, string Aliado, string Operacion, string Campana)
        {
           UnitOfWork unitWork = new UnitOfWork(new DimeContext());
           DistribucionBlending CuentaEliminar =  unitWork.distribucionesBlending.Find(c => c.CuentaCliente == CuentaCliente && c.FormularioDestino==Formulario && c.AliadoDestino== Aliado && c.OperacionDestino==Operacion && c.CampanaDestino==Campana).FirstOrDefault();
           unitWork.distribucionesBlending.Remove(CuentaEliminar);
           unitWork.Complete();
        }
        public void InsertarCuentaColaDistribucionBlending(DistribucionBlending Registro)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            unitWork.distribucionesBlending.Add(Registro);
            unitWork.Complete();
        }
        public void InsertarRegistroFueraNiveles(GBPFueraNiveles PFueraNivel, GBLFueraNiveles LFueraNivel)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());

            PFueraNivel.FechaGestion = DateTime.Now;
            unitWork.GBPFueradeNiveles.Add(PFueraNivel);
            unitWork.Complete();

            LFueraNivel.FechaGestion = PFueraNivel.FechaGestion;
            LFueraNivel.UsuarioGestion = PFueraNivel.UsuarioGestion;
            LFueraNivel.AliadoGestion = PFueraNivel.AliadoGestion;
            LFueraNivel.CuentaCliente = PFueraNivel.CuentaCliente;
            LFueraNivel.NombreCliente = PFueraNivel.NombreCliente;
            LFueraNivel.ApellidoCliente = PFueraNivel.ApellidoCliente;
            LFueraNivel.DirInstalacion = PFueraNivel.DirInstalacion;
            LFueraNivel.DirCorrespondencia = PFueraNivel.DirCorrespondencia;
            LFueraNivel.Telefono1 = PFueraNivel.Telefono1;
            LFueraNivel.Telefono2 = PFueraNivel.Telefono2;
            LFueraNivel.Telefono3 = PFueraNivel.Telefono3;
            LFueraNivel.Movil1 = PFueraNivel.Movil1;
            LFueraNivel.Movil2 = PFueraNivel.Movil2;
            LFueraNivel.MovilPostpago = PFueraNivel.MovilPostpago;
            LFueraNivel.CorreoActual = PFueraNivel.CorreoActual;
            LFueraNivel.EstratoCliente = PFueraNivel.EstratoCliente;
            LFueraNivel.ServiciosActuales = PFueraNivel.ServiciosActuales;
            LFueraNivel.Nodo = PFueraNivel.Nodo;
            LFueraNivel.NombreComunidad = PFueraNivel.NombreComunidad;
            LFueraNivel.Division = PFueraNivel.Division;
            LFueraNivel.TipoCliente = PFueraNivel.TipoCliente;
            LFueraNivel.DescripcionTPC = PFueraNivel.DescripcionTPC;
            LFueraNivel.Cmts = PFueraNivel.Cmts;
            LFueraNivel.TipoModem = PFueraNivel.TipoModem;
            LFueraNivel.Prioridad = PFueraNivel.Prioridad;
            LFueraNivel.TipoContacto = PFueraNivel.TipoContacto;
            LFueraNivel.Gestion = PFueraNivel.Gestion;
            LFueraNivel.Cierre = PFueraNivel.Cierre;
            LFueraNivel.Razon = PFueraNivel.Razon;
            LFueraNivel.FechaSeguimiento = PFueraNivel.FechaSeguimiento;

            unitWorkLog.GBLFueradeNiveles.Add(LFueraNivel);
            unitWorkLog.Complete();
        }

    }
}
