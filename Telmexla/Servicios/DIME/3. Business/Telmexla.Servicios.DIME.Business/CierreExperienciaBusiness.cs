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
    public class CierreExperienciaBusiness
    {
        /// <summary>
        /// Trae el registro asignado en la base de desconexiones por id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public CEPAsigDesconexiones TraeRegistroAsignacion(decimal Id)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
            CEPAsigDesconexiones Registro = UnitOfWork.CEPAsigDesconexiones.Find(x => x.Id == Id).FirstOrDefault();
            return Registro;
        }
        /// <summary>
        /// Inserta una desconexion en la base de datos
        /// </summary>
        /// <param name="Desconexion"></param>
        /// <param name="IdBaseAsig"></param>
        public void RegistrarDesconexion(CEPDesconexiones Desconexion, decimal IdBaseAsig)
        {
            //trae la informacion del arbol
            UnitOfWork UnitOfWorkArbol = new UnitOfWork(new DimeContext());
            Desconexion.Gestion = UnitOfWorkArbol.CEMArbolesDeGestion.Get(Convert.ToInt32(Desconexion.Gestion)).Descripcion;
            Desconexion.Subrazon = UnitOfWorkArbol.CEMArbolesDeGestion.Get(Convert.ToInt32(Desconexion.Subrazon)).Descripcion;
            Desconexion.ErrorSolicitud = UnitOfWorkArbol.CEMArbolesDeGestion.Get(Convert.ToInt32(Desconexion.ErrorSolicitud)).Descripcion;
            Desconexion.TipoDeError = UnitOfWorkArbol.CEMArbolesDeGestion.Get(Convert.ToInt32(Desconexion.TipoDeError)).Descripcion;
            UnitOfWorkArbol.Complete();
            UnitOfWorkArbol.Dispose();

            //completa informacion de la desconexion
            Desconexion.FechaDeGestion = DateTime.Now;

            //registra desconexion
            UnitOfWork UnitOfWorkRegistro = new UnitOfWork(new DimeContext());
            UnitOfWorkRegistro.CEPDesconexiones.Add(Desconexion);
            UnitOfWorkRegistro.Complete();
            UnitOfWorkRegistro.Dispose();

            //registra log de desconexiones
            CELDesconexiones LogDex = new CELDesconexiones();
            UnitOfWork UnitOfWorkLog = new UnitOfWork(new DimeContext());

            LogDex.IdGestion = Desconexion.IdGestion;
            LogDex.FechaDeTransaccion = Desconexion.FechaDeGestion;
            LogDex.UsuarioDeTransaccion = Desconexion.UsuarioDeGestion;
            LogDex.NombreUsuarioTransaccion = Desconexion.NombreUsuarioGestion;
            LogDex.CanalDeIngreso = Desconexion.CanalDeIngreso;
            LogDex.CuentaCliente = Desconexion.CuentaCliente;
            LogDex.Nota1 = Desconexion.Nota1;
            LogDex.Nota2 = Desconexion.Nota2;
            LogDex.FechaDeSolicitud = Desconexion.FechaDeSolicitud;
            LogDex.FechaDeCorte = Desconexion.FechaDeCorte;
            LogDex.FechaDePreaviso = Desconexion.FechaDePreaviso;
            LogDex.FechaDeAsignacion = Desconexion.FechaDeAsignacion;
            LogDex.Gestion = Desconexion.Gestion;
            LogDex.Subrazon = Desconexion.Subrazon;
            LogDex.Estado = Desconexion.Estado;
            LogDex.FechaDeSeguimiento = Desconexion.FechaDeSeguimiento;
            LogDex.MovieLetter = Desconexion.MovieLetter;
            LogDex.Ajuste = Desconexion.Ajuste;
            LogDex.CantidadServicio = Desconexion.CantidadServicio;
            LogDex.ErrorSolicitud = Desconexion.ErrorSolicitud;
            LogDex.UsuarioSolicitud = Desconexion.UsuarioSolicitud;
            LogDex.TipoDeError = Desconexion.TipoDeError;
            LogDex.Observaciones = Desconexion.Observaciones;

            UnitOfWorkLog.CELDesconexiones.Add(LogDex);
            UnitOfWorkLog.Complete();
            UnitOfWorkLog.Dispose();

            //elimina el registro de la base de datos de asignacion
            if (IdBaseAsig > 0)
            {
                CEPAsigDesconexiones RegistroCargado = new CEPAsigDesconexiones();
                UnitOfWork UnitOfWorkElimina = new UnitOfWork(new DimeContext());
                RegistroCargado = UnitOfWorkElimina.CEPAsigDesconexiones.Find(x => x.Id == IdBaseAsig).FirstOrDefault();
                if (RegistroCargado.Id > 0)
                {
                    UnitOfWorkElimina.CEPAsigDesconexiones.Remove(RegistroCargado);
                    UnitOfWorkElimina.Complete();
                    UnitOfWorkElimina.Dispose();
                }
            }
        }
        /// <summary>
        /// Actualiza informacion de Desconexiones
        /// </summary>
        /// <param name="Desconexion"></param>
        public void ActualizarDesconexion(CEPDesconexiones Desconexion)
        {
            //trae la informacion del arbol
            UnitOfWork UnitOfWorkArbol = new UnitOfWork(new DimeContext());
            Desconexion.Gestion = UnitOfWorkArbol.CEMArbolesDeGestion.Get(Convert.ToInt32(Desconexion.Gestion)).Descripcion;
            Desconexion.Subrazon = UnitOfWorkArbol.CEMArbolesDeGestion.Get(Convert.ToInt32(Desconexion.Subrazon)).Descripcion;
            Desconexion.ErrorSolicitud = UnitOfWorkArbol.CEMArbolesDeGestion.Get(Convert.ToInt32(Desconexion.ErrorSolicitud)).Descripcion;
            Desconexion.TipoDeError = UnitOfWorkArbol.CEMArbolesDeGestion.Get(Convert.ToInt32(Desconexion.TipoDeError)).Descripcion;
            UnitOfWorkArbol.Complete();
            UnitOfWorkArbol.Dispose();

            //completa informacion de la desconexion
            Desconexion.FechaDeGestion = DateTime.Now;

            //actualiza desconexion
            UnitOfWork UnitOfWorkActualizable = new UnitOfWork(new DimeContext());
            CEPDesconexiones RegistroActualizable = UnitOfWorkActualizable.CEPDesconexiones.Get(Convert.ToInt32(Desconexion.IdGestion));

            RegistroActualizable.FechaDeGestion = Desconexion.FechaDeGestion;
            RegistroActualizable.UsuarioDeGestion = Desconexion.UsuarioDeGestion;
            RegistroActualizable.NombreUsuarioGestion = Desconexion.NombreUsuarioGestion;
            RegistroActualizable.CanalDeIngreso = Desconexion.CanalDeIngreso;
            RegistroActualizable.CuentaCliente = Desconexion.CuentaCliente;
            RegistroActualizable.Nota1 = Desconexion.Nota1;
            RegistroActualizable.Nota2 = Desconexion.Nota2;
            RegistroActualizable.FechaDeSolicitud = Desconexion.FechaDeSolicitud;
            RegistroActualizable.FechaDeCorte = Desconexion.FechaDeCorte;
            RegistroActualizable.FechaDePreaviso = Desconexion.FechaDePreaviso;
            RegistroActualizable.FechaDeAsignacion = Desconexion.FechaDeAsignacion;
            RegistroActualizable.Gestion = Desconexion.Gestion;
            RegistroActualizable.Subrazon = Desconexion.Subrazon;
            RegistroActualizable.Estado = Desconexion.Estado;
            RegistroActualizable.FechaDeSeguimiento = Desconexion.FechaDeSeguimiento;
            RegistroActualizable.MovieLetter = Desconexion.MovieLetter;
            RegistroActualizable.Ajuste = Desconexion.Ajuste;
            RegistroActualizable.CantidadServicio = Desconexion.CantidadServicio;
            RegistroActualizable.ErrorSolicitud = Desconexion.ErrorSolicitud;
            RegistroActualizable.UsuarioSolicitud = Desconexion.UsuarioSolicitud;
            RegistroActualizable.TipoDeError = Desconexion.TipoDeError;
            RegistroActualizable.Observaciones = Desconexion.Observaciones;

            UnitOfWorkActualizable.Complete();
            UnitOfWorkActualizable.Dispose();

            //registra log de desconexiones
            CELDesconexiones LogDex = new CELDesconexiones();
            UnitOfWork UnitOfWorkLog = new UnitOfWork(new DimeContext());

            LogDex.IdGestion = Desconexion.IdGestion;
            LogDex.FechaDeTransaccion = Desconexion.FechaDeGestion;
            LogDex.UsuarioDeTransaccion = Desconexion.UsuarioDeGestion;
            LogDex.NombreUsuarioTransaccion = Desconexion.NombreUsuarioGestion;
            LogDex.CanalDeIngreso = Desconexion.CanalDeIngreso;
            LogDex.CuentaCliente = Desconexion.CuentaCliente;
            LogDex.Nota1 = Desconexion.Nota1;
            LogDex.Nota2 = Desconexion.Nota2;
            LogDex.FechaDeSolicitud = Desconexion.FechaDeSolicitud;
            LogDex.FechaDeCorte = Desconexion.FechaDeCorte;
            LogDex.FechaDePreaviso = Desconexion.FechaDePreaviso;
            LogDex.FechaDeAsignacion = Desconexion.FechaDeAsignacion;
            LogDex.Gestion = Desconexion.Gestion;
            LogDex.Subrazon = Desconexion.Subrazon;
            LogDex.Estado = Desconexion.Estado;
            LogDex.FechaDeSeguimiento = Desconexion.FechaDeSeguimiento;
            LogDex.MovieLetter = Desconexion.MovieLetter;
            LogDex.Ajuste = Desconexion.Ajuste;
            LogDex.CantidadServicio = Desconexion.CantidadServicio;
            LogDex.ErrorSolicitud = Desconexion.ErrorSolicitud;
            LogDex.UsuarioSolicitud = Desconexion.UsuarioSolicitud;
            LogDex.TipoDeError = Desconexion.TipoDeError;
            LogDex.Observaciones = Desconexion.Observaciones;

            UnitOfWorkLog.CELDesconexiones.Add(LogDex);
            UnitOfWorkLog.Complete();
            UnitOfWorkLog.Dispose();
            
        }
        /// <summary>
        /// Trae lista de arboles para los desplegables
        /// </summary>
        /// <param name="IdPadre"></param>
        /// <returns></returns>
        public List<CEMArbolesDeGestion> ArbolDeGestionAgente(decimal IdPadre)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<CEMArbolesDeGestion> Lista = new List<CEMArbolesDeGestion>();
            Lista = unitOfWork.CEMArbolesDeGestion.Find(x => x.IdPadre == IdPadre ).ToList();
            Lista = Lista.OrderBy(x => x.Descripcion).ToList();
            return Lista;
        }
        /// <summary>
        /// Actualiza la informacion del Arbol
        /// </summary>
        /// <param name="Arbol"></param>
        public void ActualizarArbolCierreExperiencia(CEMArbolesDeGestion Arbol)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            CEMArbolesDeGestion ArbolActualizable = unitOfWork.CEMArbolesDeGestion.Find(x => x.IdArbol == Arbol.IdArbol).FirstOrDefault();
            if (ArbolActualizable.IdArbol > 0)
            {
                ArbolActualizable.IdPadre = Arbol.IdPadre;
                ArbolActualizable.Descripcion = Arbol.Descripcion;
                ArbolActualizable.EstadoDeGestion = Arbol.EstadoDeGestion;
                ArbolActualizable.EstadoArbol = Arbol.EstadoArbol;
                unitOfWork.Complete();
                unitOfWork.Dispose();
            }
        }
        /// <summary>
        /// Inserta un nuevo arbol en la base de datos
        /// </summary>
        /// <param name="Arbol"></param>
        public void RegistrarNuevoArbolCierreExperiencia(CEMArbolesDeGestion Arbol)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            unitOfWork.CEMArbolesDeGestion.Add(Arbol);
            unitOfWork.Complete();
            unitOfWork.Dispose();
        }
        /// <summary>
        /// Trae la informacion del Arbol por Id
        /// </summary>
        /// <param name="IdArbol"></param>
        /// <returns></returns>
        public CEMArbolesDeGestion TraerArbolCierreExperienciaPorId(decimal IdArbol)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            CEMArbolesDeGestion Arbol = unitOfWork.CEMArbolesDeGestion.Find(x => x.IdArbol == IdArbol).FirstOrDefault();
            if (Arbol.IdArbol > 0)
            {
                return Arbol;
            }
            else
            {
                return new CEMArbolesDeGestion();
            }
        }
        /// <summary>
        /// Trae lista de Seguimientos del Usuario
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public List<CEPDesconexiones> ListaSeguimientosAgenteCierreExperiencia(decimal Usuario)
        {
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            List<CEPDesconexiones> Lista = UnitOfWorkBusqueda.CEPDesconexiones.Find(x => x.UsuarioDeGestion == Usuario && x.Estado.Equals("SEGUIMIENTO")).ToList();
            Lista = Lista.OrderBy(x => x.IdGestion).ToList();
            return Lista;
        }
        /// <summary>
        /// Trae Lista de Gestion realizaada por el usuario
        /// </summary>
        /// <param name="Usuario"></param>
        /// <returns></returns>
        public List<CELDesconexiones> ListaDeGestionAgenteCierreExperiencia(decimal Usuario)
        {

            DateTime FechaInicial;
            DateTime FechaFinal;
            FechaInicial = DateTime.Today;
            FechaFinal = FechaInicial.AddDays(1);
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            List<CELDesconexiones> Lista = UnitOfWorkBusqueda.CELDesconexiones.Find(x => x.UsuarioDeTransaccion == Usuario && x.FechaDeTransaccion>= FechaInicial && x.FechaDeTransaccion<= FechaFinal).ToList();
            Lista = Lista.OrderBy(x => x.IdTransaccion).ToList();
            return Lista;
        }
        /// <summary>
        /// Lista de Gestion Principal - Consulta Administrador
        /// </summary>
        /// <param name="FechaInicial"></param>
        /// <param name="FechaFinal"></param>
        /// <returns></returns>
        public List<CEPDesconexiones> ConsultaGeneralAdministradorCierreExperiencia(DateTime FechaInicial, DateTime FechaFinal)
        {
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            List<CEPDesconexiones> Lista = UnitOfWorkBusqueda.CEPDesconexiones.Find(x => x.FechaDeGestion>= FechaInicial && x.FechaDeGestion<= FechaFinal).ToList();
            Lista = Lista.OrderBy(x => x.IdGestion).ToList();
            return Lista;
        }
        /// <summary>
        /// Lista de Gestion Log - Consulta Administrador
        /// </summary>
        /// <param name="FechaInicial"></param>
        /// <param name="FechaFinal"></param>
        /// <returns></returns>
        public List<CELDesconexiones> ConsultaLogAdministradorCierreExperiencia(DateTime FechaInicial, DateTime FechaFinal)
        {
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            List<CELDesconexiones> Lista = UnitOfWorkBusqueda.CELDesconexiones.Find(x => x.FechaDeTransaccion >= FechaInicial && x.FechaDeTransaccion <= FechaFinal).ToList();
            Lista = Lista.OrderBy(x => x.IdTransaccion).ToList();
            return Lista;
        }
        /// <summary>
        /// Trae desconexion por id de gestion
        /// </summary>
        /// <param name="IdGestion"></param>
        /// <returns></returns>
        public CEPDesconexiones TraeDesconexionPorId(decimal IdGestion)
        {
            UnitOfWork UnitOfWorkBusqueda = new UnitOfWork(new DimeContext());
            CEPDesconexiones Registro = UnitOfWorkBusqueda.CEPDesconexiones.Find(x => x.IdGestion == IdGestion).FirstOrDefault();
            return Registro;
        }
        public CEPAsigDesconexiones ApartarCuentadeDesconexiones(decimal Cedula, int noRecursividad)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            List<decimal> solicitud = unitWork.CEPAsigDesconexiones.Find(c => c.UsuarioGestionando == Cedula).Select(x => x.Id).ToList();
            if (solicitud.Count > 0)
            {
                CEPAsigDesconexiones solicitudencontrada = new CEPAsigDesconexiones();
                return TraeRegistroAsignacion(solicitud[0]);
            }
            else
            {
                unitWork.CEPDesconexiones.ApartarCuentaGestionDesconexiones(Cedula);
                noRecursividad++;
                if (noRecursividad > 1) return null;
                return ApartarCuentadeDesconexiones(Cedula, noRecursividad);
            }
        }
        public List<CEMArbolesDeGestion> ListasDeArbolesCierreExperienciaAdmin(decimal IdPadre)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<CEMArbolesDeGestion> Lista = new List<CEMArbolesDeGestion>();
            Lista = unitOfWork.CEMArbolesDeGestion.Find(x => x.IdPadre == IdPadre).ToList();
            Lista = Lista.OrderBy(x => x.Descripcion).ToList();
            return Lista;
        }
    }
}
