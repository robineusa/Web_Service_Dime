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
    public class MidasBusiness
    {
        public List<ArbolesMidas> ListasDeArbolesMidasAdmin(decimal IdPadre)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<ArbolesMidas> Lista = new List<ArbolesMidas>();
            List<ArbolesMidas> Lista2 = new List<ArbolesMidas>();
            Lista = unitOfWork.ArbolesMidas.Find(x => x.IdPadre == IdPadre).ToList();
            Lista2 = unitOfWork.ArbolesMidas.GetAll().ToList();
            Lista = Lista.OrderBy(x => x.Descripcion).ToList();
            return Lista;
        }
        public void ActualizarArbolesMidas(ArbolesMidas Arbol)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            ArbolesMidas ArbolActualizable = new ArbolesMidas();
            ArbolActualizable = unitOfWork.ArbolesMidas.Find(x => x.IdArbol == Arbol.IdArbol).FirstOrDefault();
            if (ArbolActualizable.IdArbol > 0)
            {
                ArbolActualizable.IdPadre = Arbol.IdPadre;
                ArbolActualizable.Descripcion = Arbol.Descripcion;
                ArbolActualizable.EstadoArbol = Arbol.EstadoArbol;
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        public void RegistrarNuevoArbolesMidas(ArbolesMidas Arbol)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            unitOfWork.ArbolesMidas.Add(Arbol);
            unitOfWork.Complete();
            unitOfWork.Dispose();
        }
        public ArbolesMidas TraerArbolMidasPorId(decimal IdArbol)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            ArbolesMidas Arbol = new ArbolesMidas();
            Arbol = unitOfWork.ArbolesMidas.Find(x => x.IdArbol == IdArbol).FirstOrDefault();
            if (Arbol.IdArbol > 0)
            {
                return Arbol;
            }
            else
            {
                return new ArbolesMidas();
            }
        }
        public CargueBaseMidas TraeCuentaMidas(decimal CuentaCliente)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            CargueBaseMidas Registro = UnitOfWork.CargueBaseMidas.Find(x => x.CuentaCliente == CuentaCliente).FirstOrDefault();
            return Registro;
        }
        public List<ArbolesMidas> ArbolDeGestionAgenteMidas(decimal IdPadre)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<ArbolesMidas> Lista = new List<ArbolesMidas>();
            Lista = unitOfWork.ArbolesMidas.Find(x => x.IdPadre == IdPadre && x.EstadoArbol.Equals("ACTIVO")).ToList();
            Lista = Lista.OrderBy(x => x.Descripcion).ToList();
            return Lista;
        }
        public void RegistrarMidasTipificador(GPMMidas model)
        {
            model.FechaGestion = DateTime.Now;

            UnitOfWork UnitOfWorkRegistro = new UnitOfWork(new DimeContext());
            UnitOfWorkRegistro.GPMMidas.Add(model);
            UnitOfWorkRegistro.Complete();
            UnitOfWorkRegistro.Dispose();

            GLMMidas Log = new GLMMidas();
            UnitOfWork UnitOfWorkLog = new UnitOfWork(new DimeContext());

            Log.IdGestionPrincipal = model.Id;
            Log.UsuarioGestion = model.UsuarioGestion;
            Log.NombreUsuarioGestion = model.NombreUsuarioGestion;
            Log.AliadoGestion = model.AliadoGestion;
            Log.CuentaCliente = model.CuentaCliente;
            Log.Gestion = model.Gestion;
            Log.Cierre = model.Cierre;
            Log.Razon = model.Razon;
            Log.Motivo = model.Motivo;
            Log.FallaServPrincipalesSoporte = model.FallaServPrincipalesSoporte;
            Log.FallaServAdicionalesSoporte= model.FallaServAdicionalesSoporte;
            Log.TipoFallaSoporte = model.TipoFallaSoporte;
            Log.SolucionEspecificaSoporte = model.SolucionEspecificaSoporte;
            Log.EstadoSoporte = model.EstadoSoporte;
            Log.FechaSeguimientoSoporte = model.FechaSeguimientoSoporte;
            Log.ObservacionesSoporte = model.ObservacionesSoporte;
            Log.ProblemaFacturacion = model.ProblemaFacturacion;
            Log.SolucionFacturacion = model.ProblemaFacturacion;
            Log.EstadoFacturacion = model.EstadoFacturacion;
            Log.FechaSeguimientoFacturacion = model.FechaSeguimientoFacturacion;
            Log.ObservacionesFacturacion = model.ObservacionesFacturacion;
            Log.ClienteIntencionCancelacion = model.ClienteIntencionCancelacion;
            Log.MotivoCancelacion = model.ClienteIntencionCancelacion;
            Log.RazonCancelacion = model.RazonCancelacion;
            Log.ObservacionesCancelacion = model.ObservacionesCancelacion;
            Log.Ofrecimiento1 = model.Ofrecimiento1;
            Log.AceptacionOfrecimiento1 = model.AceptacionOfrecimiento1;
            Log.Ofrecimiento2 = model.Ofrecimiento2;
            Log.AceptacionOfrecimiento2 = model.AceptacionOfrecimiento2;
            Log.Ofrecimiento3 = model.Ofrecimiento3;
            Log.AceptacionOfrecimiento3 = model.AceptacionOfrecimiento3;
            Log.Campaña1 = model.Campaña1;
            Log.Campaña2 = model.Campaña2;
            Log.Campaña3 = model.Campaña3;

            UnitOfWorkLog.GLMMidas.Add(Log);
            UnitOfWorkLog.Complete();
            UnitOfWorkLog.Dispose();

        }
        public void ActualizarMidasTipificador(GPMMidas model)
        {
            model.FechaGestion = DateTime.Now;

            //actualiza desconexion
            UnitOfWork UnitOfWorkActualizable = new UnitOfWork(new DimeContext());
            GPMMidas RegistroActualizable = UnitOfWorkActualizable.GPMMidas.Get(Convert.ToInt32(model.Id));
            
            RegistroActualizable.UsuarioGestion = model.UsuarioGestion;
            RegistroActualizable.NombreUsuarioGestion = model.NombreUsuarioGestion;
            RegistroActualizable.AliadoGestion = model.AliadoGestion;
            RegistroActualizable.CuentaCliente = model.CuentaCliente;
            RegistroActualizable.Gestion = model.Gestion;
            RegistroActualizable.Cierre = model.Cierre;
            RegistroActualizable.Razon = model.Razon;
            RegistroActualizable.Motivo = model.Motivo;
            RegistroActualizable.FallaServPrincipalesSoporte = model.FallaServPrincipalesSoporte;
            RegistroActualizable.FallaServAdicionalesSoporte = model.FallaServAdicionalesSoporte;
            RegistroActualizable.TipoFallaSoporte = model.TipoFallaSoporte;
            RegistroActualizable.SolucionEspecificaSoporte = model.SolucionEspecificaSoporte;
            RegistroActualizable.EstadoSoporte = model.EstadoSoporte;
            RegistroActualizable.FechaSeguimientoSoporte = model.FechaSeguimientoSoporte;
            RegistroActualizable.ObservacionesSoporte = model.ObservacionesSoporte;
            RegistroActualizable.ProblemaFacturacion = model.ProblemaFacturacion;
            RegistroActualizable.SolucionFacturacion = model.ProblemaFacturacion;
            RegistroActualizable.EstadoFacturacion = model.EstadoFacturacion;
            RegistroActualizable.FechaSeguimientoFacturacion = model.FechaSeguimientoFacturacion;
            RegistroActualizable.ObservacionesFacturacion = model.ObservacionesFacturacion;
            RegistroActualizable.ClienteIntencionCancelacion = model.ClienteIntencionCancelacion;
            RegistroActualizable.MotivoCancelacion = model.ClienteIntencionCancelacion;
            RegistroActualizable.RazonCancelacion = model.RazonCancelacion;
            RegistroActualizable.ObservacionesCancelacion = model.ObservacionesCancelacion;
            RegistroActualizable.Ofrecimiento1 = model.Ofrecimiento1;
            RegistroActualizable.AceptacionOfrecimiento1 = model.AceptacionOfrecimiento1;
            RegistroActualizable.Ofrecimiento2 = model.Ofrecimiento2;
            RegistroActualizable.AceptacionOfrecimiento2 = model.AceptacionOfrecimiento2;
            RegistroActualizable.Ofrecimiento3 = model.Ofrecimiento3;
            RegistroActualizable.AceptacionOfrecimiento3 = model.AceptacionOfrecimiento3;
            RegistroActualizable.Campaña1 = model.Campaña1;
            RegistroActualizable.Campaña2 = model.Campaña2;
            RegistroActualizable.Campaña3 = model.Campaña3;

            UnitOfWorkActualizable.Complete();
            UnitOfWorkActualizable.Dispose();

            //registra log de desconexiones
            GLMMidas Log = new GLMMidas();
            UnitOfWork UnitOfWorkLog = new UnitOfWork(new DimeContext());

            Log.IdGestionPrincipal = model.Id;
            Log.UsuarioGestion = model.UsuarioGestion;
            Log.NombreUsuarioGestion = model.NombreUsuarioGestion;
            Log.AliadoGestion = model.AliadoGestion;
            Log.CuentaCliente = model.CuentaCliente;
            Log.Gestion = model.Gestion;
            Log.Cierre = model.Cierre;
            Log.Razon = model.Razon;
            Log.Motivo = model.Motivo;
            Log.FallaServPrincipalesSoporte = model.FallaServPrincipalesSoporte;
            Log.FallaServAdicionalesSoporte = model.FallaServAdicionalesSoporte;
            Log.TipoFallaSoporte = model.TipoFallaSoporte;
            Log.SolucionEspecificaSoporte = model.SolucionEspecificaSoporte;
            Log.EstadoSoporte = model.EstadoSoporte;
            Log.FechaSeguimientoSoporte = model.FechaSeguimientoSoporte;
            Log.ObservacionesSoporte = model.ObservacionesSoporte;
            Log.ProblemaFacturacion = model.ProblemaFacturacion;
            Log.SolucionFacturacion = model.ProblemaFacturacion;
            Log.EstadoFacturacion = model.EstadoFacturacion;
            Log.FechaSeguimientoFacturacion = model.FechaSeguimientoFacturacion;
            Log.ObservacionesFacturacion = model.ObservacionesFacturacion;
            Log.ClienteIntencionCancelacion = model.ClienteIntencionCancelacion;
            Log.MotivoCancelacion = model.ClienteIntencionCancelacion;
            Log.RazonCancelacion = model.RazonCancelacion;
            Log.ObservacionesCancelacion = model.ObservacionesCancelacion;
            Log.Ofrecimiento1 = model.Ofrecimiento1;
            Log.AceptacionOfrecimiento1 = model.AceptacionOfrecimiento1;
            Log.Ofrecimiento2 = model.Ofrecimiento2;
            Log.AceptacionOfrecimiento2 = model.AceptacionOfrecimiento2;
            Log.Ofrecimiento3 = model.Ofrecimiento3;
            Log.AceptacionOfrecimiento3 = model.AceptacionOfrecimiento3;
            Log.Campaña1 = model.Campaña1;
            Log.Campaña2 = model.Campaña2;
            Log.Campaña3 = model.Campaña3;

            UnitOfWorkLog.GLMMidas.Add(Log);
            UnitOfWorkLog.Complete();
            UnitOfWorkLog.Dispose();

        }
    }
}
