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
            List<decimal> cuentasGestionandoAsesor = unitOfWork.distribucionesBlending.Find(c => c.UsuarioGestionando == idAsesor && c.FormularioDestino.Equals(formulario) && c.AliadoDestino.Equals(aliado) && c.OperacionDestino.Equals(operacion) && c.CampanaDestino.Equals(campana)).Select(x => x.CuentaCliente).ToList();
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
        public void EliminaCuentaGestionadaDistribucion(DistribucionBlending Registro)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            DistribucionBlending CuentaEliminar = unitWork.distribucionesBlending.Find(c => c.CuentaCliente == Registro.CuentaCliente && c.FormularioDestino == Registro.FormularioDestino && c.AliadoDestino == Registro.AliadoDestino && c.OperacionDestino == Registro.OperacionDestino && c.CampanaDestino == Registro.CampanaDestino).FirstOrDefault();

            if (CuentaEliminar != null)
            {
                unitWork.distribucionesBlending.Remove(CuentaEliminar);
                unitWork.Complete();
            }
            else { }
        }
        public void InsertarCuentaColaDistribucionBlending(DistribucionBlending Registro)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            DistribucionBlending CuentaEliminar = unitWork.distribucionesBlending.Find(c => c.CuentaCliente == Registro.CuentaCliente && c.FormularioDestino == Registro.FormularioDestino && c.AliadoDestino == Registro.AliadoDestino && c.OperacionDestino == Registro.OperacionDestino && c.CampanaDestino == Registro.CampanaDestino).FirstOrDefault();

            if (CuentaEliminar != null)
            {
                unitWork.distribucionesBlending.Remove(CuentaEliminar);
                unitWork.Complete();
                unitWork.Dispose();

                //insertar registro cola
                UnitOfWork unitWorkinsert = new UnitOfWork(new DimeContext());

                Registro.UsuarioGestionando = 0;
                Registro.FechaAsignacion = CuentaEliminar.FechaAsignacion;
                Registro.UsuarioAsignacion = CuentaEliminar.UsuarioAsignacion;
                unitWorkinsert.distribucionesBlending.Add(Registro);
                unitWorkinsert.Complete();
                unitWorkinsert.Dispose();
            }
            else { }
        }
        public ClientesTodo AsignarIdCuentaDistribucionBlending(decimal CuentaCliente, string Formulario, string Aliado, string Operacion, string Campana, int Id)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            DistribucionBlending RegistroActualizar = unitWork.distribucionesBlending.Find(c => c.CuentaCliente == CuentaCliente && c.FormularioDestino == Formulario && c.AliadoDestino == Aliado && c.OperacionDestino == Operacion && c.CampanaDestino == Campana).FirstOrDefault();

            if (RegistroActualizar != null)
            {
                RegistroActualizar.UsuarioGestionando = Id;
                unitWork.Complete();
                ClientesBusiness clientesBusiness = new ClientesBusiness();
                return clientesBusiness.ObtenerClienteCompleto(Convert.ToInt32(CuentaCliente));
            }
            else {
                
                return null;
            }
           

        }


        /////NUEVOS PROCESOS DE GESTION BLENDING
        // CABLE MODEM FUERA DE NIVELES
        public BlendingFueraNivel TraerInformacionCuentaFueraNiveles(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.blendingFueraNiveles.Find(c => c.CuentaCliente == CuentaCliente).FirstOrDefault();
        }
       
        
        public void InsertarRegistroFueraNiveles(GBPFueraNiveles PFueraNivel)
        {
            //actualiza informacion de los maestros
            UnitOfWorkMaestros unitWorkMaestros = new UnitOfWorkMaestros(new MaestrosContext());

            PFueraNivel.TipoContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(PFueraNivel.TipoContacto)).TipoContacto;
            PFueraNivel.Gestion = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(PFueraNivel.Gestion)).Cierre;
            PFueraNivel.Cierre = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(PFueraNivel.Cierre)).Razon;
            PFueraNivel.Razon = unitWorkMaestros.maestrosOutboundCausa.Get(Convert.ToInt32(PFueraNivel.Razon)).Causa;
            unitWorkMaestros.Complete();
            unitWorkMaestros.Dispose();

            //InsertarCuentaColaDistribucionBlending registro fuera de niveles
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            
            PFueraNivel.FechaGestion = DateTime.Now;
            unitWork.GBPFueradeNiveles.Add(PFueraNivel);
            unitWork.Complete();
            unitWork.Dispose();

            //inserta log de transaccion
            UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
            GBLFueraNiveles LFueraNivel = new GBLFueraNiveles();

            LFueraNivel.FechaGestion = PFueraNivel.FechaGestion;
            LFueraNivel.UsuarioGestion = PFueraNivel.UsuarioGestion;
            LFueraNivel.AliadoGestion = PFueraNivel.AliadoGestion;
            LFueraNivel.OperacionGestion = PFueraNivel.OperacionGestion;
            LFueraNivel.CampanaGestion = PFueraNivel.CampanaGestion;
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
            unitWorkLog.Dispose();

        }
        public void ActualizarGestionFueraNiveles(GBPFueraNiveles PFueraNivel)
        {
           //actualiza informacion de los maestros de tipificacion
            UnitOfWorkMaestros unitWorkMaestros = new UnitOfWorkMaestros(new MaestrosContext());
            PFueraNivel.TipoContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(PFueraNivel.TipoContacto)).TipoContacto;
            PFueraNivel.Gestion = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(PFueraNivel.Gestion)).Cierre;
            PFueraNivel.Cierre = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(PFueraNivel.Cierre)).Razon;
            PFueraNivel.Razon = unitWorkMaestros.maestrosOutboundCausa.Get(Convert.ToInt32(PFueraNivel.Razon)).Causa;
            unitWorkMaestros.Complete();
            unitWorkMaestros.Dispose();

            //actualiza informacion del registro existente
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            GBPFueraNiveles PFueraNivelActualizable = unitWork.GBPFueradeNiveles.Find(c => c.CuentaCliente == PFueraNivel.CuentaCliente).FirstOrDefault();
            PFueraNivel.FechaGestion = DateTime.Now;
            PFueraNivelActualizable.FechaGestion = PFueraNivel.FechaGestion;
            PFueraNivelActualizable.UsuarioGestion = PFueraNivel.UsuarioGestion;
            PFueraNivelActualizable.AliadoGestion = PFueraNivel.AliadoGestion;
            PFueraNivelActualizable.OperacionGestion = PFueraNivel.OperacionGestion;
            PFueraNivelActualizable.CampanaGestion = PFueraNivel.CampanaGestion;
            PFueraNivelActualizable.NombreCliente = PFueraNivel.NombreCliente;
            PFueraNivelActualizable.ApellidoCliente = PFueraNivel.ApellidoCliente;
            PFueraNivelActualizable.DirInstalacion = PFueraNivel.DirInstalacion;
            PFueraNivelActualizable.DirCorrespondencia = PFueraNivel.DirCorrespondencia;
            PFueraNivelActualizable.Telefono1 = PFueraNivel.Telefono1;
            PFueraNivelActualizable.Telefono2 = PFueraNivel.Telefono2;
            PFueraNivelActualizable.Telefono3 = PFueraNivel.Telefono3;
            PFueraNivelActualizable.Movil1 = PFueraNivel.Movil1;
            PFueraNivelActualizable.Movil2 = PFueraNivel.Movil2;
            PFueraNivelActualizable.MovilPostpago = PFueraNivel.MovilPostpago;
            PFueraNivelActualizable.CorreoActual = PFueraNivel.CorreoActual;
            PFueraNivelActualizable.EstratoCliente = PFueraNivel.EstratoCliente;
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
            unitWork.Dispose();

            //inserta el log de la transaccion
            UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
            GBLFueraNiveles LFueraNivel = new GBLFueraNiveles();
            LFueraNivel.FechaGestion = PFueraNivel.FechaGestion;
            LFueraNivel.UsuarioGestion = PFueraNivel.UsuarioGestion;
            LFueraNivel.AliadoGestion = PFueraNivel.AliadoGestion;
            LFueraNivel.OperacionGestion = PFueraNivel.OperacionGestion;
            LFueraNivel.CampanaGestion = PFueraNivel.CampanaGestion;
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
            unitWorkLog.Dispose();

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
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            GBPFueraNiveles Resultado = unitWork.GBPFueradeNiveles.Find(c => c.CuentaCliente == CuentaCliente && c.FechaGestion>= fecha1 && c.FechaGestion< fecha2).FirstOrDefault();
            return Resultado;
        }
        public List<GBLFueraNiveles> TraeListaGestionUsuarioFueraNiveles(string Usuario)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            DimeContext dimContext = new DimeContext();
            List<GBLFueraNiveles> result = new List<GBLFueraNiveles>();
            var objetosResult = (from a in dimContext.GBLFueradeNiveles
                                 where a.UsuarioGestion.Equals(Usuario) && a.FechaGestion>= fecha1 && a.FechaGestion< fecha2
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
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            DimeContext dimContext = new DimeContext();
            List<GBPFueraNiveles> result = new List<GBPFueraNiveles>();
            var objetosResult = (from a in dimContext.GBPFueradeNiveles
                                 where a.UsuarioGestion.Equals(Usuario) && a.Cierre.Equals("SEGUIMIENTO") && a.FechaGestion >= fecha1 && a.FechaGestion < fecha2
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
      
        public GBPFueraNiveles TraerDatosCuentaSelectFueraNivel(decimal CuentaCliente)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.GBPFueradeNiveles.Find(c => c.CuentaCliente == CuentaCliente && c.FechaGestion>= fecha1 && c.FechaGestion< fecha2).FirstOrDefault();

        }
        public int CantidadToquesCuentaFueraNiveles(decimal CuentaCliente)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
           int Cantidad = unitWork.GBLFueradeNiveles.Find(c => c.CuentaCliente == CuentaCliente && c.FechaGestion>= fecha1 && c.FechaGestion< fecha2).Count();
            if (Cantidad > 0) {
                return Cantidad;
            }
            else {
                return 0; }
        }
        public GBLFueraNiveles TraeUltimaGestionCuenta(decimal CuentaCliente)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            List<GBLFueraNiveles> Registros = unitWork.GBLFueradeNiveles.Find(c => c.CuentaCliente == CuentaCliente && c.FechaGestion>= fecha1 && c.FechaGestion< fecha2).ToList();
            
            if (Registros.Count()>0)
            {
                decimal MaxId = Registros.Max(c => c.Id);
                return unitWork.GBLFueradeNiveles.Get(Convert.ToInt32(MaxId));
            }else
            {   
            return null;}

        }
        public List<GBPFueraNivelesCA> ConsultaAdminFueraNivelesP(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<GBPFueraNivelesCA> result = new List<GBPFueraNivelesCA>();
            var objetosResult = (from a in dimContext.GBPFueradeNiveles
                                 join b in (from m in dimContext.Usuarios select new { m.Id, m.Cedula ,m.Nombre }).Distinct() on Convert.ToInt64(a.UsuarioGestion) equals b.Id
                                 where a.FechaGestion>= FechaInicial && a.FechaGestion<= FechaFinal
                                 orderby a.Id ascending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     b.Cedula,
                                     b.Nombre,
                                     a.AliadoGestion,
                                     a.OperacionGestion,
                                     a.CampanaGestion,
                                     a.CuentaCliente,
                                     a.NombreCliente,
                                     a.ApellidoCliente,
                                     a.DirInstalacion,
                                     a.DirCorrespondencia,
                                     a.Telefono1,
                                     a.Telefono2,
                                     a.Telefono3,
                                     a.Movil1,
                                     a.Movil2,
                                     a.MovilPostpago,
                                     a.CorreoActual,
                                     a.EstratoCliente,
                                     a.ServiciosActuales,
                                     a.Nodo,
                                     a.NombreComunidad,
                                     a.Division,
                                     a.TipoCliente,
                                     a.DescripcionTPC,
                                     a.Cmts,
                                     a.TipoModem,
                                     a.Prioridad,
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
                result.Add(new GBPFueraNivelesCA());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].CedulaUsuario = Convert.ToDecimal(objetosResult[i].Cedula);
                result[i].NombreUsuario = objetosResult[i].Nombre;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].OperacionGestion = objetosResult[i].OperacionGestion;
                result[i].CampanaGestion = objetosResult[i].CampanaGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NombreCliente = objetosResult[i].NombreCliente;
                result[i].ApellidoCliente = objetosResult[i].ApellidoCliente;
                result[i].DirInstalacion = objetosResult[i].DirInstalacion;
                result[i].DirCorrespondencia = objetosResult[i].DirCorrespondencia;
                result[i].Telefono1 = objetosResult[i].Telefono1;
                result[i].Telefono2 = objetosResult[i].Telefono2;
                result[i].Telefono3 = objetosResult[i].Telefono3;
                result[i].Movil1 = objetosResult[i].Movil1;
                result[i].Movil2 = objetosResult[i].Movil2;
                result[i].MovilPostpago = objetosResult[i].MovilPostpago;
                result[i].CorreoActual = objetosResult[i].CorreoActual;
                result[i].EstratoCliente = objetosResult[i].EstratoCliente;
                result[i].ServiciosActuales = objetosResult[i].ServiciosActuales;
                result[i].Nodo = objetosResult[i].Nodo;
                result[i].NombreComunidad = objetosResult[i].NombreComunidad;
                result[i].Division = objetosResult[i].Division;
                result[i].TipoCliente = objetosResult[i].TipoCliente;
                result[i].DescripcionTPC = objetosResult[i].DescripcionTPC;
                result[i].Cmts = objetosResult[i].Cmts;
                result[i].TipoModem = objetosResult[i].TipoModem;
                result[i].Prioridad = objetosResult[i].Prioridad;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Razon = objetosResult[i].Razon;
                result[i].FechaSeguimiento = objetosResult[i].FechaSeguimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public List<GBLFueraNivelesCA> ConsultaAdminFueraNivelesL(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<GBLFueraNivelesCA> result = new List<GBLFueraNivelesCA>();
            var objetosResult = (from a in dimContext.GBLFueradeNiveles
                                 join b in (from m in dimContext.Usuarios select new { m.Id, m.Cedula, m.Nombre }).Distinct() on Convert.ToInt64(a.UsuarioGestion) equals b.Id
                                 where a.FechaGestion >= FechaInicial && a.FechaGestion <= FechaFinal
                                 orderby a.Id ascending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     b.Cedula,
                                     b.Nombre,
                                     a.AliadoGestion,
                                     a.OperacionGestion,
                                     a.CampanaGestion,
                                     a.CuentaCliente,
                                     a.NombreCliente,
                                     a.ApellidoCliente,
                                     a.DirInstalacion,
                                     a.DirCorrespondencia,
                                     a.Telefono1,
                                     a.Telefono2,
                                     a.Telefono3,
                                     a.Movil1,
                                     a.Movil2,
                                     a.MovilPostpago,
                                     a.CorreoActual,
                                     a.EstratoCliente,
                                     a.ServiciosActuales,
                                     a.Nodo,
                                     a.NombreComunidad,
                                     a.Division,
                                     a.TipoCliente,
                                     a.DescripcionTPC,
                                     a.Cmts,
                                     a.TipoModem,
                                     a.Prioridad,
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
                result.Add(new GBLFueraNivelesCA());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].CedulaUsuario =Convert.ToDecimal(objetosResult[i].Cedula);
                result[i].NombreUsuario = objetosResult[i].Nombre;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].OperacionGestion = objetosResult[i].OperacionGestion;
                result[i].CampanaGestion = objetosResult[i].CampanaGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NombreCliente = objetosResult[i].NombreCliente;
                result[i].ApellidoCliente = objetosResult[i].ApellidoCliente;
                result[i].DirInstalacion = objetosResult[i].DirInstalacion;
                result[i].DirCorrespondencia = objetosResult[i].DirCorrespondencia;
                result[i].Telefono1 = objetosResult[i].Telefono1;
                result[i].Telefono2 = objetosResult[i].Telefono2;
                result[i].Telefono3 = objetosResult[i].Telefono3;
                result[i].Movil1 = objetosResult[i].Movil1;
                result[i].Movil2 = objetosResult[i].Movil2;
                result[i].MovilPostpago = objetosResult[i].MovilPostpago;
                result[i].CorreoActual = objetosResult[i].CorreoActual;
                result[i].EstratoCliente = objetosResult[i].EstratoCliente;
                result[i].ServiciosActuales = objetosResult[i].ServiciosActuales;
                result[i].Nodo = objetosResult[i].Nodo;
                result[i].NombreComunidad = objetosResult[i].NombreComunidad;
                result[i].Division = objetosResult[i].Division;
                result[i].TipoCliente = objetosResult[i].TipoCliente;
                result[i].DescripcionTPC = objetosResult[i].DescripcionTPC;
                result[i].Cmts = objetosResult[i].Cmts;
                result[i].TipoModem = objetosResult[i].TipoModem;
                result[i].Prioridad = objetosResult[i].Prioridad;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Razon = objetosResult[i].Razon;
                result[i].FechaSeguimiento = objetosResult[i].FechaSeguimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }

        //GESTION BLENDING RENTABILIZACION
        public GBC_Rentabilizacion TraerInformacionCuentaRentabilizacion(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.GBCRentabilizacion.Find(c => c.CuentaCiente == CuentaCliente).FirstOrDefault();
        }
        public void InsertarRegistroRentabilizacion(GBPRentabilizacion PRentabilizacion)
        {
            //actualiza informacion de maestros de tipificacion
            UnitOfWorkMaestros unitWorkMaestros = new UnitOfWorkMaestros(new MaestrosContext());
            PRentabilizacion.TipoContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(PRentabilizacion.TipoContacto)).TipoContacto;
            PRentabilizacion.Gestion = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(PRentabilizacion.Gestion)).Cierre;
            PRentabilizacion.Cierre = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(PRentabilizacion.Cierre)).Razon;
            PRentabilizacion.Causa = unitWorkMaestros.maestrosOutboundCausa.Get(Convert.ToInt32(PRentabilizacion.Causa)).Causa;
            PRentabilizacion.Motivo = unitWorkMaestros.maestrosOutboundMotivo.Get(Convert.ToInt32(PRentabilizacion.Motivo)).Motivo;
            unitWorkMaestros.Complete();
            unitWorkMaestros.Dispose();

            //inserta registro de rentabilizacion
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            PRentabilizacion.FechaGestion = DateTime.Now;
            unitWork.GBPRentabilizacion.Add(PRentabilizacion);
            unitWork.Complete();
            unitWork.Dispose();

            //inserta log de la transaccion
            UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
            GBLRentabilizacion LRentabilizacion = new GBLRentabilizacion();
            LRentabilizacion.FechaGestion = PRentabilizacion.FechaGestion;
            LRentabilizacion.UsuarioGestion = PRentabilizacion.UsuarioGestion;
            LRentabilizacion.AliadoGestion = PRentabilizacion.AliadoGestion;
            LRentabilizacion.OperacionGestion = PRentabilizacion.OperacionGestion;
            LRentabilizacion.CampanaDestino = PRentabilizacion.CampanaDestino;
            LRentabilizacion.CuentaCliente = PRentabilizacion.CuentaCliente;
            LRentabilizacion.ConsumosPpv = PRentabilizacion.ConsumosPpv;
            LRentabilizacion.UltimaPpv = PRentabilizacion.UltimaPpv;
            LRentabilizacion.SiembraHd = PRentabilizacion.SiembraHd;
            LRentabilizacion.SiembraVoz = PRentabilizacion.SiembraVoz;
            LRentabilizacion.BlindajeInternet = PRentabilizacion.BlindajeInternet;
            LRentabilizacion.UltimaMarcacion = PRentabilizacion.UltimaMarcacion;
            LRentabilizacion.OfrecimientoAceptado = PRentabilizacion.OfrecimientoAceptado;
            LRentabilizacion.TipoContacto = PRentabilizacion.TipoContacto;
            LRentabilizacion.Gestion = PRentabilizacion.Gestion;
            LRentabilizacion.Cierre = PRentabilizacion.Cierre;
            LRentabilizacion.Causa = PRentabilizacion.Causa;
            LRentabilizacion.Motivo = PRentabilizacion.Motivo;
            LRentabilizacion.FechaSeguimiento = PRentabilizacion.FechaSeguimiento;
            LRentabilizacion.Observaciones = PRentabilizacion.Observaciones;

            unitWorkLog.GBLRentabilizacion.Add(LRentabilizacion);
            unitWorkLog.Complete();
            unitWorkLog.Dispose();

        }
        public void ActualizarGestionRentabilizacion(GBPRentabilizacion PRentabilizacion)
        {
            //actualiza informacion de los maestros de tipificacion
            UnitOfWorkMaestros unitWorkMaestros = new UnitOfWorkMaestros(new MaestrosContext());
            PRentabilizacion.TipoContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(PRentabilizacion.TipoContacto)).TipoContacto;
            PRentabilizacion.Gestion = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(PRentabilizacion.Gestion)).Cierre;
            PRentabilizacion.Cierre = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(PRentabilizacion.Cierre)).Razon;
            PRentabilizacion.Causa = unitWorkMaestros.maestrosOutboundCausa.Get(Convert.ToInt32(PRentabilizacion.Causa)).Causa;
            PRentabilizacion.Motivo = unitWorkMaestros.maestrosOutboundMotivo.Get(Convert.ToInt32(PRentabilizacion.Motivo)).Motivo;
            unitWorkMaestros.Complete();
            unitWorkMaestros.Dispose();

            PRentabilizacion.FechaGestion = DateTime.Now;

            //actualiza informacion del registro existente
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            GBPRentabilizacion PRentabilizacionActualizable = unitWork.GBPRentabilizacion.Find(c => c.CuentaCliente == PRentabilizacion.CuentaCliente).FirstOrDefault();

            PRentabilizacionActualizable.FechaGestion = PRentabilizacion.FechaGestion;
            PRentabilizacionActualizable.UsuarioGestion = PRentabilizacion.UsuarioGestion;
            PRentabilizacionActualizable.AliadoGestion = PRentabilizacion.AliadoGestion;
            PRentabilizacionActualizable.OperacionGestion = PRentabilizacion.OperacionGestion;
            PRentabilizacionActualizable.CampanaDestino = PRentabilizacion.CampanaDestino;
            PRentabilizacionActualizable.CuentaCliente = PRentabilizacion.CuentaCliente;
            PRentabilizacionActualizable.ConsumosPpv = PRentabilizacion.ConsumosPpv;
            PRentabilizacionActualizable.UltimaPpv = PRentabilizacion.UltimaPpv;
            PRentabilizacionActualizable.SiembraHd = PRentabilizacion.SiembraHd;
            PRentabilizacionActualizable.SiembraVoz = PRentabilizacion.SiembraVoz;
            PRentabilizacionActualizable.BlindajeInternet = PRentabilizacion.BlindajeInternet;
            PRentabilizacionActualizable.UltimaMarcacion = PRentabilizacion.UltimaMarcacion;
            PRentabilizacionActualizable.OfrecimientoAceptado = PRentabilizacion.OfrecimientoAceptado;
            PRentabilizacionActualizable.TipoContacto = PRentabilizacion.TipoContacto;
            PRentabilizacionActualizable.Gestion = PRentabilizacion.Gestion;
            PRentabilizacionActualizable.Cierre = PRentabilizacion.Cierre;
            PRentabilizacionActualizable.Causa = PRentabilizacion.Causa;
            PRentabilizacionActualizable.Motivo = PRentabilizacion.Motivo;
            PRentabilizacionActualizable.FechaSeguimiento = PRentabilizacion.FechaSeguimiento;
            PRentabilizacionActualizable.Observaciones = PRentabilizacion.Observaciones;

            unitWork.Complete();
            unitWork.Dispose();

            //inserta log de la transaccion
            UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
            GBLRentabilizacion LRentabilizacion = new GBLRentabilizacion();
            LRentabilizacion.FechaGestion = PRentabilizacion.FechaGestion;
            LRentabilizacion.UsuarioGestion = PRentabilizacion.UsuarioGestion;
            LRentabilizacion.AliadoGestion = PRentabilizacion.AliadoGestion;
            LRentabilizacion.OperacionGestion = PRentabilizacion.OperacionGestion;
            LRentabilizacion.CampanaDestino = PRentabilizacion.CampanaDestino;
            LRentabilizacion.CuentaCliente = PRentabilizacion.CuentaCliente;
            LRentabilizacion.ConsumosPpv = PRentabilizacion.ConsumosPpv;
            LRentabilizacion.UltimaPpv = PRentabilizacion.UltimaPpv;
            LRentabilizacion.SiembraHd = PRentabilizacion.SiembraHd;
            LRentabilizacion.SiembraVoz = PRentabilizacion.SiembraVoz;
            LRentabilizacion.BlindajeInternet = PRentabilizacion.BlindajeInternet;
            LRentabilizacion.UltimaMarcacion = PRentabilizacion.UltimaMarcacion;
            LRentabilizacion.OfrecimientoAceptado = PRentabilizacion.OfrecimientoAceptado;
            LRentabilizacion.TipoContacto = PRentabilizacion.TipoContacto;
            LRentabilizacion.Gestion = PRentabilizacion.Gestion;
            LRentabilizacion.Cierre = PRentabilizacion.Cierre;
            LRentabilizacion.Causa = PRentabilizacion.Causa;
            LRentabilizacion.Motivo = PRentabilizacion.Motivo;
            LRentabilizacion.FechaSeguimiento = PRentabilizacion.FechaSeguimiento;
            LRentabilizacion.Observaciones = PRentabilizacion.Observaciones;

            unitWorkLog.GBLRentabilizacion.Add(LRentabilizacion);
            unitWorkLog.Complete();
            unitWorkLog.Dispose();

        }
        public bool ValidarCuentaEnRentabilizacion(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.GBPRentabilizacion.Find(c => c.CuentaCliente == CuentaCliente).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public GBPRentabilizacion TraeInformacionActualRentabilizacion(decimal CuentaCliente)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            GBPRentabilizacion Resultado = unitWork.GBPRentabilizacion.Find(c => c.CuentaCliente == CuentaCliente && c.FechaGestion>= fecha1 && c.FechaGestion< fecha2).FirstOrDefault();
            return Resultado;
        }
        public List<GBLRentabilizacion> TraeListaGestionUsuarioRentabilizacion(string Usuario)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            DimeContext dimContext = new DimeContext();
            List<GBLRentabilizacion> result = new List<GBLRentabilizacion>();
            var objetosResult = (from a in dimContext.GBLRentabilizacion
                                 where a.UsuarioGestion.Equals(Usuario) && a.FechaGestion>= fecha1 && a.FechaGestion< fecha2
                                 orderby a.Id descending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.CuentaCliente,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Causa,
                                     a.Motivo,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBLRentabilizacion());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Causa = objetosResult[i].Causa;
                result[i].Motivo = objetosResult[i].Motivo;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public List<GBPRentabilizacion> TraeListaSeguimientosUsuarioRentabilizacion(string Usuario)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            DimeContext dimContext = new DimeContext();
            List<GBPRentabilizacion> result = new List<GBPRentabilizacion>();
            var objetosResult = (from a in dimContext.GBPRentabilizacion
                                 where a.UsuarioGestion.Equals(Usuario) && a.Cierre.Equals("VENTA EN SEGUIMIENTO") && a.FechaGestion>= fecha1 && a.FechaGestion< fecha2
                                 orderby a.Id descending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.CuentaCliente,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Causa,
                                     a.Motivo,
                                     a.FechaSeguimiento,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBPRentabilizacion());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Causa = objetosResult[i].Causa;
                result[i].Motivo = objetosResult[i].Motivo;
                result[i].FechaSeguimiento = objetosResult[i].FechaSeguimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public GBPRentabilizacion TraerDatosCuentaSelectRentabilizacion(decimal CuentaCliente)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.GBPRentabilizacion.Find(c => c.CuentaCliente == CuentaCliente && c.FechaGestion>= fecha1 && c.FechaGestion< fecha2).FirstOrDefault();

        }
        public int CantidadToquesCuentaRentabilizacion(decimal CuentaCliente)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            } else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            int Cantidad = unitWork.GBLRentabilizacion.Find(c => c.CuentaCliente == CuentaCliente && c.FechaGestion>= fecha1 && c.FechaGestion<fecha2).Count();
            if (Cantidad > 0)
            {
                return Cantidad;
            }
            else
            {
                return 0;
            }
        }
        public GBLRentabilizacion TraeUltimaGestionCuentaRentabilizacion(decimal CuentaCliente)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            List<GBLRentabilizacion> Registros = unitWork.GBLRentabilizacion.Find(c => c.CuentaCliente == CuentaCliente && c.FechaGestion>= fecha1 && c.FechaGestion< fecha2).ToList();

            if (Registros.Count() > 0)
            {
                decimal MaxId = Registros.Max(c => c.Id);
                return unitWork.GBLRentabilizacion.Get(Convert.ToInt32(MaxId));
            }
            else
            {
                return null;
            }

        }
        public List<GBPRentabilizacionCA> ConsultaAdminRentabilizacionP(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<GBPRentabilizacionCA> result = new List<GBPRentabilizacionCA>();
            var objetosResult = (from a in dimContext.GBPRentabilizacion
                                 join b in (from m in dimContext.Usuarios select new { m.Id, m.Cedula, m.Nombre }).Distinct() on a.UsuarioGestion equals  b.Id.ToString()
                                 where a.FechaGestion >= FechaInicial && a.FechaGestion <= FechaFinal
                                 orderby a.Id ascending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     b.Cedula,
                                     b.Nombre,
                                     a.AliadoGestion,
                                     a.OperacionGestion,
                                     a.CampanaDestino,
                                     a.CuentaCliente,
                                     a.ConsumosPpv,
                                     a.UltimaPpv,
                                     a.SiembraHd,
                                     a.SiembraVoz,
                                     a.BlindajeInternet,
                                     a.UltimaMarcacion,
                                     a.OfrecimientoAceptado,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Causa,
                                     a.Motivo,
                                     a.FechaSeguimiento,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBPRentabilizacionCA());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].CedulaUsuario = Convert.ToDecimal(objetosResult[i].Cedula);
                result[i].NombreUsuario = objetosResult[i].Nombre;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].OperacionGestion = objetosResult[i].OperacionGestion;
                result[i].CampanaDestino = objetosResult[i].CampanaDestino;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].ConsumosPpv = objetosResult[i].ConsumosPpv;
                result[i].UltimaPpv = objetosResult[i].UltimaPpv;
                result[i].SiembraHd = objetosResult[i].SiembraHd;
                result[i].SiembraVoz = objetosResult[i].SiembraVoz;
                result[i].BlindajeInternet = objetosResult[i].BlindajeInternet;
                result[i].UltimaMarcacion = objetosResult[i].UltimaMarcacion;
                result[i].OfrecimientoAceptado = objetosResult[i].OfrecimientoAceptado;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Causa = objetosResult[i].Causa;
                result[i].Motivo = objetosResult[i].Motivo;
                result[i].FechaSeguimiento = objetosResult[i].FechaSeguimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public List<GBLRentabilizacionCA> ConsultaAdminRentabilizacionL(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<GBLRentabilizacionCA> result = new List<GBLRentabilizacionCA>();
            var objetosResult = (from a in dimContext.GBLRentabilizacion
                                 join b in (from m in dimContext.Usuarios select new { m.Id, m.Cedula, m.Nombre }).Distinct() on a.UsuarioGestion equals b.Id.ToString()
                                 where a.FechaGestion >= FechaInicial && a.FechaGestion <= FechaFinal
                                 orderby a.Id ascending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     b.Cedula,
                                     b.Nombre,
                                     a.AliadoGestion,
                                     a.OperacionGestion,
                                     a.CampanaDestino,
                                     a.CuentaCliente,
                                     a.ConsumosPpv,
                                     a.UltimaPpv,
                                     a.SiembraHd,
                                     a.SiembraVoz,
                                     a.BlindajeInternet,
                                     a.UltimaMarcacion,
                                     a.OfrecimientoAceptado,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Causa,
                                     a.Motivo,
                                     a.FechaSeguimiento,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBLRentabilizacionCA());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].CedulaUsuario = Convert.ToDecimal(objetosResult[i].Cedula);
                result[i].NombreUsuario = objetosResult[i].Nombre;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].OperacionGestion = objetosResult[i].OperacionGestion;
                result[i].CampanaDestino = objetosResult[i].CampanaDestino;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].ConsumosPpv = objetosResult[i].ConsumosPpv;
                result[i].UltimaPpv = objetosResult[i].UltimaPpv;
                result[i].SiembraHd = objetosResult[i].SiembraHd;
                result[i].SiembraVoz = objetosResult[i].SiembraVoz;
                result[i].BlindajeInternet = objetosResult[i].BlindajeInternet;
                result[i].UltimaMarcacion = objetosResult[i].UltimaMarcacion;
                result[i].OfrecimientoAceptado = objetosResult[i].OfrecimientoAceptado;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Causa = objetosResult[i].Causa;
                result[i].Motivo = objetosResult[i].Motivo;
                result[i].FechaSeguimiento = objetosResult[i].FechaSeguimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }

        // //GESTION BLENDING PRODUCTO
        public GBCProducto TraerInformacionCuentaProducto(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.GBCProducto.Find(c => c.CuentaCliente == CuentaCliente).FirstOrDefault();
        }
        public void InsertarRegistroProducto(GBPProducto GBPProducto)
        {
            //actualiza informacion del maestro de tipificacion
            UnitOfWorkMaestros unitWorkMaestros = new UnitOfWorkMaestros(new MaestrosContext());
            GBPProducto.TipoContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(GBPProducto.TipoContacto)).TipoContacto;
            GBPProducto.Gestion = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(GBPProducto.Gestion)).Cierre;
            GBPProducto.Cierre = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(GBPProducto.Cierre)).Razon;
            GBPProducto.Causa = unitWorkMaestros.maestrosOutboundCausa.Get(Convert.ToInt32(GBPProducto.Causa)).Causa;
            unitWorkMaestros.Complete();
            unitWorkMaestros.Dispose();


            //inserta registro de producto
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            GBPProducto.FechaGestion = DateTime.Now;
            unitWork.GBPProducto.Add(GBPProducto);
            unitWork.Complete();
            unitWork.Dispose();


            //inserta log de la transaccion
            UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
            GBLProducto GBLProducto = new GBLProducto();
            GBLProducto.FechaGestion = GBPProducto.FechaGestion;
            GBLProducto.UsuarioGestion = GBPProducto.UsuarioGestion;
            GBLProducto.NombreUsuarioGestion = GBPProducto.NombreUsuarioGestion;
            GBLProducto.AliadoGestion = GBPProducto.AliadoGestion;
            GBLProducto.OperacionGestion = GBPProducto.OperacionGestion;
            GBLProducto.CampanaGestion = GBPProducto.CampanaGestion;
            GBLProducto.CuentaCliente = GBPProducto.CuentaCliente;
            GBLProducto.TipoContacto = GBPProducto.TipoContacto;
            GBLProducto.Gestion = GBPProducto.Gestion;
            GBLProducto.Cierre = GBPProducto.Cierre;
            GBLProducto.Causa = GBPProducto.Causa;
            GBLProducto.FechaSeguimiento = GBPProducto.FechaSeguimiento;
            GBLProducto.Observaciones = GBPProducto.Observaciones;

            unitWorkLog.GBLProducto.Add(GBLProducto);
            unitWorkLog.Complete();
            unitWorkLog.Dispose();

        }
        public void ActualizarGestionProducto(GBPProducto GBPProducto)
        {
            //actualiza informacion de los maestros de tipificacion
            UnitOfWorkMaestros unitWorkMaestros = new UnitOfWorkMaestros(new MaestrosContext());
            GBPProducto.TipoContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(GBPProducto.TipoContacto)).TipoContacto;
            GBPProducto.Gestion = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(GBPProducto.Gestion)).Cierre;
            GBPProducto.Cierre = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(GBPProducto.Cierre)).Razon;
            GBPProducto.Causa = unitWorkMaestros.maestrosOutboundCausa.Get(Convert.ToInt32(GBPProducto.Causa)).Causa;
            unitWorkMaestros.Complete();
            unitWorkMaestros.Dispose();


            //actualiza informacion del registro existente
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            GBPProducto.FechaGestion = DateTime.Now;
            GBPProducto GBPProductoActualizable = unitWork.GBPProducto.Find(c => c.CuentaCliente == GBPProducto.CuentaCliente).FirstOrDefault();

            GBPProductoActualizable.FechaGestion = GBPProducto.FechaGestion;
            GBPProductoActualizable.UsuarioGestion = GBPProducto.UsuarioGestion;
            GBPProductoActualizable.NombreUsuarioGestion = GBPProducto.NombreUsuarioGestion;
            GBPProductoActualizable.AliadoGestion = GBPProducto.AliadoGestion;
            GBPProductoActualizable.OperacionGestion = GBPProducto.OperacionGestion;
            GBPProductoActualizable.CampanaGestion = GBPProducto.CampanaGestion;
            GBPProductoActualizable.CuentaCliente = GBPProducto.CuentaCliente;
            GBPProductoActualizable.TipoContacto = GBPProducto.TipoContacto;
            GBPProductoActualizable.Gestion = GBPProducto.Gestion;
            GBPProductoActualizable.Cierre = GBPProducto.Cierre;
            GBPProductoActualizable.Causa = GBPProducto.Causa;
            GBPProductoActualizable.FechaSeguimiento = GBPProducto.FechaSeguimiento;
            GBPProductoActualizable.Observaciones = GBPProducto.Observaciones;

            unitWork.Complete();
            unitWork.Dispose();


            //inserta log de la transaccion
            UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
            GBLProducto GBLProducto = new GBLProducto();
            GBLProducto.FechaGestion = GBPProducto.FechaGestion;
            GBLProducto.UsuarioGestion = GBPProducto.UsuarioGestion;
            GBLProducto.NombreUsuarioGestion = GBPProducto.NombreUsuarioGestion;
            GBLProducto.AliadoGestion = GBPProducto.AliadoGestion;
            GBLProducto.OperacionGestion = GBPProducto.OperacionGestion;
            GBLProducto.CampanaGestion = GBPProducto.CampanaGestion;
            GBLProducto.CuentaCliente = GBPProducto.CuentaCliente;
            GBLProducto.TipoContacto = GBPProducto.TipoContacto;
            GBLProducto.Gestion = GBPProducto.Gestion;
            GBLProducto.Cierre = GBPProducto.Cierre;
            GBLProducto.Causa = GBPProducto.Causa;
            GBLProducto.FechaSeguimiento = GBPProducto.FechaSeguimiento;
            GBLProducto.Observaciones = GBPProducto.Observaciones;

            unitWorkLog.GBLProducto.Add(GBLProducto);
            unitWorkLog.Complete();
            unitWorkLog.Dispose();

        }
        public bool ValidarCuentaEnProducto(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.GBPProducto.Find(c => c.CuentaCliente == CuentaCliente).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public GBPProducto TraeInformacionActualProducto(decimal CuentaCliente)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            GBPProducto Resultado = unitWork.GBPProducto.Find(c => c.CuentaCliente == CuentaCliente && c.FechaGestion>= fecha1 && c.FechaGestion < fecha2).FirstOrDefault();
            return Resultado;
        }
        public List<GBLProducto> TraeListaGestionUsuarioProucto(string Usuario)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            DimeContext dimContext = new DimeContext();
            List<GBLProducto> result = new List<GBLProducto>();
            var objetosResult = (from a in dimContext.GBLProducto
                                 where a.UsuarioGestion.Equals(Usuario) && a.FechaGestion >= fecha1 && a.FechaGestion< fecha2
                                 orderby a.Id descending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.CuentaCliente,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Causa,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBLProducto());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Causa = objetosResult[i].Causa;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public List<GBPProducto> TraeListaSeguimientosUsuarioProducto(string Usuario)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            DimeContext dimContext = new DimeContext();
            List<GBPProducto> result = new List<GBPProducto>();
            var objetosResult = (from a in dimContext.GBPProducto
                                 where a.UsuarioGestion.Equals(Usuario) && a.Cierre.Equals("GESTION EN SEGUIMIENTO") && a.FechaGestion>= fecha1 && a.FechaGestion < fecha2
                                 orderby a.Id descending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.CuentaCliente,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Causa,
                                     a.FechaSeguimiento,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBPProducto());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Causa = objetosResult[i].Causa;
                result[i].FechaSeguimiento = objetosResult[i].FechaSeguimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public GBPProducto TraerDatosCuentaSelectProducto(decimal CuentaCliente)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.GBPProducto.Find(c => c.CuentaCliente == CuentaCliente && c.FechaGestion >= fecha1 && c.FechaGestion < fecha2).FirstOrDefault();

        }
        public int CantidadToquesCuentaProducto(decimal CuentaCliente)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            int Cantidad = unitWork.GBLProducto.Find(c => c.CuentaCliente == CuentaCliente && c.FechaGestion >= fecha1 && c.FechaGestion < fecha2).Count();
            if (Cantidad > 0)
            {
                return Cantidad;
            }
            else
            {
                return 0;
            }
        }
        public GBLProducto TraeUltimaGestionCuentaProducto(decimal CuentaCliente)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            List<GBLProducto> Registros = unitWork.GBLProducto.Find(c => c.CuentaCliente == CuentaCliente && c.FechaGestion >= fecha1 && c.FechaGestion < fecha2).ToList();

            if (Registros.Count() > 0)
            {
                decimal MaxId = Registros.Max(c => c.Id);
                return unitWork.GBLProducto.Get(Convert.ToInt32(MaxId));
            }
            else
            {
                return null;
            }

        }
        public List<GBPProductoCA> ConsultaAdminProductoP(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<GBPProductoCA> result = new List<GBPProductoCA>();
            var objetosResult = (from a in dimContext.GBPProducto
                                 join b in (from m in dimContext.Usuarios select new { m.Id, m.Cedula, m.Nombre }).Distinct() on a.UsuarioGestion equals b.Id.ToString()
                                 where a.FechaGestion >= FechaInicial && a.FechaGestion <= FechaFinal
                                 orderby a.Id ascending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     b.Cedula,                                     
                                     a.NombreUsuarioGestion,
                                     a.AliadoGestion,
                                     a.OperacionGestion,
                                     a.CampanaGestion,
                                     a.CuentaCliente,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Causa,
                                     a.FechaSeguimiento,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBPProductoCA());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].CedulaUsuario = Convert.ToDecimal(objetosResult[i].Cedula);
                result[i].NombreUsuarioGestion = objetosResult[i].NombreUsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].OperacionGestion = objetosResult[i].OperacionGestion;
                result[i].CampanaGestion = objetosResult[i].CampanaGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Causa = objetosResult[i].Causa;
                result[i].FechaSeguimiento = objetosResult[i].FechaSeguimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public List<GBLProductoCA> ConsultaAdminProductoL(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<GBLProductoCA> result = new List<GBLProductoCA>();
            var objetosResult = (from a in dimContext.GBLProducto
                                 join b in (from m in dimContext.Usuarios select new { m.Id, m.Cedula, m.Nombre }).Distinct() on a.UsuarioGestion equals b.Id.ToString()
                                 where a.FechaGestion >= FechaInicial && a.FechaGestion <= FechaFinal
                                 orderby a.Id ascending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     b.Cedula,
                                     a.NombreUsuarioGestion,
                                     a.AliadoGestion,
                                     a.OperacionGestion,
                                     a.CampanaGestion,
                                     a.CuentaCliente,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Causa,
                                     a.FechaSeguimiento,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBLProductoCA());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].CedulaUsuario = Convert.ToDecimal(objetosResult[i].Cedula);
                result[i].NombreUsuarioGestion = objetosResult[i].NombreUsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].OperacionGestion = objetosResult[i].OperacionGestion;
                result[i].CampanaGestion = objetosResult[i].CampanaGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Causa = objetosResult[i].Causa;
                result[i].FechaSeguimiento = objetosResult[i].FechaSeguimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }


        // //GESTION BLENDING DOCSIS Y OVERLAP
        public GBCDocsis TraerInformacionCuentaDocsis(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.GBCDocsis.Find(c => c.CuentaCliente == CuentaCliente).FirstOrDefault();
        }
        public void InsertarRegistroDocsis(GBPDocsis GBPDocsis)
        {
            //aqctualiza informacion de los arboles de tipificacion
            UnitOfWorkMaestros unitWorkMaestros = new UnitOfWorkMaestros(new MaestrosContext());
            GBPDocsis.TipoContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(GBPDocsis.TipoContacto)).TipoContacto;
            GBPDocsis.Gestion = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(GBPDocsis.Gestion)).Cierre;
            GBPDocsis.Cierre = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(GBPDocsis.Cierre)).Razon;
            GBPDocsis.Razon = unitWorkMaestros.maestrosOutboundCausa.Get(Convert.ToInt32(GBPDocsis.Razon)).Causa;
            unitWorkMaestros.Complete();
            unitWorkMaestros.Dispose();

            //inserta registro de docsis
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            GBPDocsis.FechaGestion = DateTime.Now;
            unitWork.GBPDocsis.Add(GBPDocsis);
            unitWork.Complete();
            unitWork.Dispose();

            //inserta log de la transaccion
            UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
            GBLDocsis GBLDocsis = new GBLDocsis();
            GBLDocsis.FechaGestion = GBPDocsis.FechaGestion;
            GBLDocsis.UsuarioGestion = GBPDocsis.UsuarioGestion;
            GBLDocsis.NombreUsuarioGestion = GBPDocsis.NombreUsuarioGestion;
            GBLDocsis.AliadoGestion = GBPDocsis.AliadoGestion;
            GBLDocsis.OperacionGestion = GBPDocsis.OperacionGestion;
            GBLDocsis.CampanaGestion = GBPDocsis.CampanaGestion;
            GBLDocsis.CuentaCliente = GBPDocsis.CuentaCliente;
            GBLDocsis.TipoContacto = GBPDocsis.TipoContacto;
            GBLDocsis.Gestion = GBPDocsis.Gestion;
            GBLDocsis.Cierre = GBPDocsis.Cierre;
            GBLDocsis.Razon = GBPDocsis.Razon;
            GBLDocsis.FechaSeguimiento = GBPDocsis.FechaSeguimiento;
            GBLDocsis.Observaciones = GBPDocsis.Observaciones;
            GBLDocsis.Aliado = GBPDocsis.Aliado;

            unitWorkLog.GBLDocsis.Add(GBLDocsis);
            unitWorkLog.Complete();
            unitWorkLog.Dispose();

        }
        public void ActualizarGestionDocsis(GBPDocsis GBPDocsis)
        {
           //actualiza informacion del arbol de tipificacion
            UnitOfWorkMaestros unitWorkMaestros = new UnitOfWorkMaestros(new MaestrosContext());
            GBPDocsis.TipoContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(GBPDocsis.TipoContacto)).TipoContacto;
            GBPDocsis.Gestion = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(GBPDocsis.Gestion)).Cierre;
            GBPDocsis.Cierre = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(GBPDocsis.Cierre)).Razon;
            GBPDocsis.Razon = unitWorkMaestros.maestrosOutboundCausa.Get(Convert.ToInt32(GBPDocsis.Razon)).Causa;
            unitWorkMaestros.Complete();
            unitWorkMaestros.Dispose();

            //actualiza informacion del registro existente
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            GBPDocsis GBPDocsisActualizable = unitWork.GBPDocsis.Find(c => c.CuentaCliente == GBPDocsis.CuentaCliente).FirstOrDefault();
            GBPDocsis.FechaGestion = DateTime.Now;

            GBPDocsisActualizable.FechaGestion = GBPDocsis.FechaGestion;
            GBPDocsisActualizable.UsuarioGestion = GBPDocsis.UsuarioGestion;
            GBPDocsisActualizable.NombreUsuarioGestion = GBPDocsis.NombreUsuarioGestion;
            GBPDocsisActualizable.AliadoGestion = GBPDocsis.AliadoGestion;
            GBPDocsisActualizable.OperacionGestion = GBPDocsis.OperacionGestion;
            GBPDocsisActualizable.CampanaGestion = GBPDocsis.CampanaGestion;
            GBPDocsisActualizable.CuentaCliente = GBPDocsis.CuentaCliente;
            GBPDocsisActualizable.TipoContacto = GBPDocsis.TipoContacto;
            GBPDocsisActualizable.Gestion = GBPDocsis.Gestion;
            GBPDocsisActualizable.Cierre = GBPDocsis.Cierre;
            GBPDocsisActualizable.Razon = GBPDocsis.Razon;
            GBPDocsisActualizable.FechaSeguimiento = GBPDocsis.FechaSeguimiento;
            GBPDocsisActualizable.Observaciones = GBPDocsis.Observaciones;
            GBPDocsisActualizable.Aliado = GBPDocsis.Aliado;

            unitWork.Complete();
            unitWork.Dispose();


            //inserta log de la transaccion
            UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
            GBLDocsis GBLDocsis = new GBLDocsis();
            GBLDocsis.FechaGestion = GBPDocsis.FechaGestion;
            GBLDocsis.UsuarioGestion = GBPDocsis.UsuarioGestion;
            GBLDocsis.NombreUsuarioGestion = GBPDocsis.NombreUsuarioGestion;
            GBLDocsis.AliadoGestion = GBPDocsis.AliadoGestion;
            GBLDocsis.OperacionGestion = GBPDocsis.OperacionGestion;
            GBLDocsis.CampanaGestion = GBPDocsis.CampanaGestion;
            GBLDocsis.CuentaCliente = GBPDocsis.CuentaCliente;
            GBLDocsis.TipoContacto = GBPDocsis.TipoContacto;
            GBLDocsis.Gestion = GBPDocsis.Gestion;
            GBLDocsis.Cierre = GBPDocsis.Cierre;
            GBLDocsis.Razon = GBPDocsis.Razon;
            GBLDocsis.FechaSeguimiento = GBPDocsis.FechaSeguimiento;
            GBLDocsis.Observaciones = GBPDocsis.Observaciones;
            GBLDocsis.Aliado = GBPDocsis.Aliado;

            unitWorkLog.GBLDocsis.Add(GBLDocsis);
            unitWorkLog.Complete();
            unitWorkLog.Dispose();

        }
        public bool ValidarCuentaEnDocsis(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.GBPDocsis.Find(c => c.CuentaCliente == CuentaCliente).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public GBPDocsis TraeInformacionActualDocsis(decimal CuentaCliente)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            GBPDocsis Resultado = unitWork.GBPDocsis.Find(c => c.CuentaCliente == CuentaCliente && c.FechaGestion >= fecha1 && c.FechaGestion < fecha2).FirstOrDefault();
            return Resultado;
        }
        public List<GBLDocsis> TraeListaGestionUsuarioDocsis(string Usuario)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            DimeContext dimContext = new DimeContext();
            List<GBLDocsis> result = new List<GBLDocsis>();
            var objetosResult = (from a in dimContext.GBLDocsis
                                 where a.UsuarioGestion.Equals(Usuario) && a.FechaGestion >= fecha1 && a.FechaGestion < fecha2
                                 orderby a.Id descending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.CuentaCliente,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Razon,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBLDocsis());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Razon = objetosResult[i].Razon;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public List<GBPDocsis> TraeListaSeguimientosUsuarioDocsis(string Usuario)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            DimeContext dimContext = new DimeContext();
            List<GBPDocsis> result = new List<GBPDocsis>();
            var objetosResult = (from a in dimContext.GBPDocsis
                                 where a.UsuarioGestion.Equals(Usuario) && a.Cierre.Equals("SEGUIMIENTO") && a.FechaGestion >= fecha1 && a.FechaGestion < fecha2
                                 orderby a.Id descending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.CuentaCliente,
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
                result.Add(new GBPDocsis());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Razon = objetosResult[i].Razon;
                result[i].FechaSeguimiento = objetosResult[i].FechaSeguimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;

        }
        public GBPDocsis TraerDatosCuentaSelectDocsis(decimal CuentaCliente)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            return unitWork.GBPDocsis.Find(c => c.CuentaCliente == CuentaCliente && c.FechaGestion >= fecha1 && c.FechaGestion < fecha2).FirstOrDefault();

        }
        public int CantidadToquesCuentaDocsis(decimal CuentaCliente)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            int Cantidad = unitWork.GBLDocsis.Find(c => c.CuentaCliente == CuentaCliente && c.FechaGestion >= fecha1 && c.FechaGestion < fecha2).Count();
            if (Cantidad > 0)
            {
                return Cantidad;
            }
            else
            {
                return 0;
            }
        }
        public GBLDocsis TraeUltimaGestionCuentaDocsis(decimal CuentaCliente)
        {
            DateTime fechatemp;
            DateTime fecha1;
            DateTime fecha2;
            fechatemp = DateTime.Today;
            int siguientemes = fechatemp.Month + 1;
            int siguienteano = fechatemp.Year;
            if (siguientemes > 12)
            {
                siguientemes = 01;
                siguienteano = siguienteano + 1;
            }
            else { }
            fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            fecha2 = new DateTime(siguienteano, siguientemes, 1).AddDays(-0);

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            List<GBLDocsis> Registros = unitWork.GBLDocsis.Find(c => c.CuentaCliente == CuentaCliente && c.FechaGestion >= fecha1 && c.FechaGestion < fecha2).ToList();

            if (Registros.Count() > 0)
            {
                decimal MaxId = Registros.Max(c => c.Id);
                return unitWork.GBLDocsis.Get(Convert.ToInt32(MaxId));
            }
            else
            {
                return null;
            }

        }
        public List<GBPDocsisCA> ConsultaAdminDocsisP(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<GBPDocsisCA> result = new List<GBPDocsisCA>();
            var objetosResult = (from a in dimContext.GBPDocsis
                                 join b in (from m in dimContext.Usuarios select new { m.Id, m.Cedula, m.Nombre }).Distinct() on a.UsuarioGestion equals b.Id.ToString()
                                 where a.FechaGestion >= FechaInicial && a.FechaGestion <= FechaFinal
                                 orderby a.Id ascending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     b.Cedula,
                                     a.NombreUsuarioGestion,
                                     a.AliadoGestion,
                                     a.OperacionGestion,
                                     a.CampanaGestion,
                                     a.CuentaCliente,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Razon,
                                     a.FechaSeguimiento,
                                     a.Observaciones,
                                     a.Aliado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBPDocsisCA());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].CedulaUsuario =Convert.ToDecimal(objetosResult[i].Cedula);
                result[i].NombreUsuarioGestion = objetosResult[i].NombreUsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].OperacionGestion = objetosResult[i].OperacionGestion;
                result[i].CampanaGestion = objetosResult[i].CampanaGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Razon = objetosResult[i].Razon;
                result[i].FechaSeguimiento = objetosResult[i].FechaSeguimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
                result[i].Aliado = objetosResult[i].Aliado;
            }
            return result;

        }
        public List<GBLDocsisCA> ConsultaAdminDocsisL(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<GBLDocsisCA> result = new List<GBLDocsisCA>();
            var objetosResult = (from a in dimContext.GBLDocsis
                                 join b in (from m in dimContext.Usuarios select new { m.Id, m.Cedula, m.Nombre }).Distinct() on a.UsuarioGestion equals b.Id.ToString()
                                 where a.FechaGestion >= FechaInicial && a.FechaGestion <= FechaFinal
                                 orderby a.Id ascending
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     b.Cedula,
                                     a.NombreUsuarioGestion,
                                     a.AliadoGestion,
                                     a.OperacionGestion,
                                     a.CampanaGestion,
                                     a.CuentaCliente,
                                     a.TipoContacto,
                                     a.Gestion,
                                     a.Cierre,
                                     a.Razon,
                                     a.FechaSeguimiento,
                                     a.Observaciones,
                                     a.Aliado
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GBLDocsisCA());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].CedulaUsuario = Convert.ToDecimal(objetosResult[i].Cedula);
                result[i].NombreUsuarioGestion = objetosResult[i].NombreUsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].OperacionGestion = objetosResult[i].OperacionGestion;
                result[i].CampanaGestion = objetosResult[i].CampanaGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TipoContacto = objetosResult[i].TipoContacto;
                result[i].Gestion = objetosResult[i].Gestion;
                result[i].Cierre = objetosResult[i].Cierre;
                result[i].Razon = objetosResult[i].Razon;
                result[i].FechaSeguimiento = objetosResult[i].FechaSeguimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
                result[i].Aliado = objetosResult[i].Aliado;
            }
            return result;

        }
        public List<ConsultaBlendingFormularioDestinoReturnViewModel> ConsultaBlendingFormularioDestino(string aliado)
        {
            DimeContext dimContext = new DimeContext();
            List<ConsultaBlendingFormularioDestinoReturnViewModel> result = new List<ConsultaBlendingFormularioDestinoReturnViewModel>();
            result = dimContext.ConsultaBlendingFormularioDestino(aliado);
            return result;

        }
        public List<ConsultaBlendingOperacionDestinoReturnViewModel> ConsultaBlendingOperacionDestino(string aliado, string formulario)
        {
            DimeContext dimContext = new DimeContext();
            List<ConsultaBlendingOperacionDestinoReturnViewModel> result = new List<ConsultaBlendingOperacionDestinoReturnViewModel>();
            result = dimContext.ConsultaBlendingOperacionDestino(aliado, formulario);
            return result;

        }
        public List<ConsultaBlendingCampañaDestinoReturnViewModel> ConsultaBlendingCampanaDestino(string aliado, string formulario, string operacion)
        {
            DimeContext dimContext = new DimeContext();
            List<ConsultaBlendingCampañaDestinoReturnViewModel> result = new List<ConsultaBlendingCampañaDestinoReturnViewModel>();
            result = dimContext.ConsultaBlendingCampanaDestino(aliado, formulario, operacion);
            return result;

        }

    }
}
