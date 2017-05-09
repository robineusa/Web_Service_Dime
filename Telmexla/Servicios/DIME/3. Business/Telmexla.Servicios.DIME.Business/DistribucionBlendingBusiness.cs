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
        public ClientesTodo TraerInformacionCuentaBlending(int idAsesor, string formulario, string aliado, string operacion, string campana, int noRecursividad)
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
                unitOfWork.distribucionesBlending.ApartarCuentaAGestionarBlendingAsesor(idAsesor, formulario, aliado, operacion, campana);
                noRecursividad++;
                if (noRecursividad > 1) return null;
                return TraerInformacionCuentaBlending(idAsesor, formulario, aliado, operacion, campana, noRecursividad);
            }

        }

        /////NUEVOS PROCESOS DE GESTION BLENDING
        // CABLE MODEM FUERA DE NIVELES
        public BlendingFueraNivel TraerInformacionCuentaFueraNiveles(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.blendingFueraNiveles.Find(c => c.CuentaCliente == CuentaCliente).FirstOrDefault();
        }
        public void EliminaCuentaGestionadaDistribucion(DistribucionBlending Registro)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            DistribucionBlending CuentaEliminar = unitWork.distribucionesBlending.Find(c => c.CuentaCliente == Registro.CuentaCliente && c.FormularioDestino == Registro.FormularioDestino && c.AliadoDestino == Registro.AliadoDestino && c.OperacionDestino == Registro.OperacionDestino && c.CampanaDestino == Registro.CampanaDestino).FirstOrDefault();
            unitWork.distribucionesBlending.Remove(CuentaEliminar);
            unitWork.Complete();
        }
        public void InsertarCuentaColaDistribucionBlending(DistribucionBlending Registro)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            DistribucionBlending CuentaEliminar = unitWork.distribucionesBlending.Find(c => c.CuentaCliente == Registro.CuentaCliente && c.FormularioDestino == Registro.FormularioDestino && c.AliadoDestino == Registro.AliadoDestino && c.OperacionDestino == Registro.OperacionDestino && c.CampanaDestino == Registro.CampanaDestino).FirstOrDefault();
            unitWork.distribucionesBlending.Remove(CuentaEliminar);
            unitWork.Complete();

            Registro.UsuarioGestionando = 0;
            Registro.FechaAsignacion = CuentaEliminar.FechaAsignacion;
            Registro.UsuarioAsignacion = CuentaEliminar.UsuarioAsignacion;

            unitWork.distribucionesBlending.Add(Registro);
            unitWork.Complete();
        }
        public void InsertarRegistroFueraNiveles(GBPFueraNiveles PFueraNivel)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
            UnitOfWorkMaestros unitWorkMaestros = new UnitOfWorkMaestros(new MaestrosContext());

            PFueraNivel.TipoContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(PFueraNivel.TipoContacto)).TipoContacto;
            PFueraNivel.Gestion = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(PFueraNivel.Gestion)).Cierre;
            PFueraNivel.Cierre = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(PFueraNivel.Cierre)).Razon;
            PFueraNivel.Razon = unitWorkMaestros.maestrosOutboundCausa.Get(Convert.ToInt32(PFueraNivel.Razon)).Causa;

            PFueraNivel.FechaGestion = DateTime.Now;
            unitWork.GBPFueradeNiveles.Add(PFueraNivel);
            unitWork.Complete();




            GBLFueraNiveles LFueraNivel = new GBLFueraNiveles();

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
            LFueraNivel.Observaciones = PFueraNivel.Observaciones;

            unitWorkLog.GBLFueradeNiveles.Add(LFueraNivel);
            unitWorkLog.Complete();
            
        }
        public void ActualizarGestionFueraNiveles(GBPFueraNiveles PFueraNivel)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
            UnitOfWorkMaestros unitWorkMaestros = new UnitOfWorkMaestros(new MaestrosContext());

            GBPFueraNiveles PFueraNivelActualizable = unitWork.GBPFueradeNiveles.Find(c => c.CuentaCliente == PFueraNivel.CuentaCliente).FirstOrDefault();

                PFueraNivel.TipoContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(PFueraNivel.TipoContacto)).TipoContacto;
                PFueraNivel.Gestion = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(PFueraNivel.Gestion)).Cierre;
                PFueraNivel.Cierre = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(PFueraNivel.Cierre)).Razon;
                PFueraNivel.Razon = unitWorkMaestros.maestrosOutboundCausa.Get(Convert.ToInt32(PFueraNivel.Razon)).Causa;

                

                PFueraNivel.FechaGestion = DateTime.Now;

                PFueraNivelActualizable.FechaGestion = PFueraNivel.FechaGestion;
                PFueraNivelActualizable.UsuarioGestion = PFueraNivel.UsuarioGestion;
                PFueraNivelActualizable.AliadoGestion = PFueraNivel.AliadoGestion;
                PFueraNivelActualizable.NombreCliente = PFueraNivel.NombreCliente;
                PFueraNivelActualizable.ApellidoCliente = PFueraNivel.ApellidoCliente;
                PFueraNivelActualizable.DirInstalacion = PFueraNivel.DirCorrespondencia;
                PFueraNivelActualizable.Telefono1 = PFueraNivel.Telefono1;
                PFueraNivelActualizable.Telefono2 = PFueraNivel.Telefono2;
                PFueraNivelActualizable.Telefono3 = PFueraNivel.Telefono3;
                PFueraNivelActualizable.Movil1 = PFueraNivel.Movil1;
                PFueraNivelActualizable.Movil2 = PFueraNivel.Movil2;
                PFueraNivelActualizable.MovilPostpago = PFueraNivel.MovilPostpago;
                PFueraNivelActualizable.CorreoActual = PFueraNivel.CorreoActual;
                PFueraNivelActualizable.EstratoCliente = PFueraNivel.ServiciosActuales;
                PFueraNivelActualizable.ServiciosActuales = PFueraNivel.ServiciosActuales;
                PFueraNivelActualizable.Nodo = PFueraNivel.Nodo;
                PFueraNivelActualizable.NombreComunidad = PFueraNivel.NombreComunidad;
                PFueraNivelActualizable.Division = PFueraNivel.Division;
                PFueraNivelActualizable.TipoCliente = PFueraNivel.TipoCliente;
                PFueraNivelActualizable.DescripcionTPC = PFueraNivel.DescripcionTPC;
                PFueraNivelActualizable.Cmts = PFueraNivel.Cmts;
                PFueraNivelActualizable.TipoModem = PFueraNivel.TipoModem;
                PFueraNivelActualizable.Prioridad = PFueraNivel.Prioridad;
                PFueraNivelActualizable.TipoContacto = PFueraNivel.TipoContacto;
                PFueraNivelActualizable.Gestion = PFueraNivel.Gestion;
                PFueraNivelActualizable.Cierre = PFueraNivel.Cierre;
                PFueraNivelActualizable.Razon = PFueraNivel.Razon;
                PFueraNivelActualizable.FechaSeguimiento = PFueraNivel.FechaSeguimiento;
                PFueraNivelActualizable.Observaciones = PFueraNivel.Observaciones;
                unitWork.Complete();

                GBLFueraNiveles LFueraNivel = new GBLFueraNiveles();

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
                LFueraNivel.EstratoCliente = PFueraNivel.ServiciosActuales;
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
                LFueraNivel.Observaciones = PFueraNivel.Observaciones;

                unitWorkLog.GBLFueradeNiveles.Add(LFueraNivel);
                unitWorkLog.Complete();
           
        }
        public bool ValidarCuentaEnFueraNiveles(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.GBPFueradeNiveles.Find(c => c.CuentaCliente == CuentaCliente).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public GBPFueraNiveles TraeInformacionActualFueraNiveles(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            GBPFueraNiveles Resultado = unitWork.GBPFueradeNiveles.Find(c => c.CuentaCliente == CuentaCliente).FirstOrDefault();
            return Resultado;
        }
        public List<GBLFueraNiveles> TraeListaGestionUsuarioFueraNiveles(string Usuario)
        {
            DimeContext dimContext = new DimeContext();
            List<GBLFueraNiveles> result = new List<GBLFueraNiveles>();
            var objetosResult = (from a in dimContext.GBLFueradeNiveles
                                 where a.UsuarioGestion.Equals(Usuario)
                                 orderby a.Id descending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.CuentaCliente,
                                     a.NombreCliente,
                                     a.ApellidoCliente,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Razon,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBLFueraNiveles());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NombreCliente = objetosResult[i].NombreCliente;
                result[i].ApellidoCliente = objetosResult[i].ApellidoCliente;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Razon = objetosResult[i].Razon;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public List<GBPFueraNiveles> TraeListaSeguimientosUsuarioFueraNiveles(string Usuario)
        {
            DimeContext dimContext = new DimeContext();
            List<GBPFueraNiveles> result = new List<GBPFueraNiveles>();
            var objetosResult = (from a in dimContext.GBPFueradeNiveles
                                 where a.UsuarioGestion.Equals(Usuario) && a.Cierre.Equals("SEGUIMIENTO")
                                 orderby a.Id descending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.CuentaCliente,
                                     a.NombreCliente,
                                     a.ApellidoCliente,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Razon,
                                     a.FechaSeguimiento,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBPFueraNiveles());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NombreCliente = objetosResult[i].NombreCliente;
                result[i].ApellidoCliente = objetosResult[i].ApellidoCliente;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Razon = objetosResult[i].Razon;
                result[i].FechaSeguimiento = objetosResult[i].FechaSeguimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public ClientesTodo AsignarIdCuentaDistribucionBlending(decimal CuentaCliente, string Formulario,string Aliado, string Operacion, string Campana, int Id)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            DistribucionBlending RegistroActualizar = unitWork.distribucionesBlending.Find(c => c.CuentaCliente == CuentaCliente && c.FormularioDestino == Formulario && c.AliadoDestino == Aliado && c.OperacionDestino == Operacion && c.CampanaDestino == Campana).FirstOrDefault();
            RegistroActualizar.UsuarioGestionando = Id;
            unitWork.Complete();

            ClientesBusiness clientesBusiness = new ClientesBusiness();
            return clientesBusiness.ObtenerClienteCompleto(Convert.ToInt32(CuentaCliente));

        }
        public GBPFueraNiveles TraerDatosCuentaSelectFueraNivel(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.GBPFueradeNiveles.Find(c => c.CuentaCliente == CuentaCliente).FirstOrDefault();

        }
    }
}
