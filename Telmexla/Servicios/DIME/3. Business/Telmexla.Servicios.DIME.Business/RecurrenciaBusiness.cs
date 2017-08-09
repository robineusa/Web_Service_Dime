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
    public class RecurrenciaBusiness
    {
        public ClientesTodo TraerInformacionCuentaRecurrencia(int idAsesor, int noRecursividad)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<decimal> cuentasGestionandoAsesor = unitOfWork.RecurrenciaCargaBase.Find(c => c.Usuario_gestionando == idAsesor).Select(x => x.Cuenta).ToList();
            if (cuentasGestionandoAsesor.Count > 0)
            {
                ClientesBusiness clientesBusiness = new ClientesBusiness();
                return clientesBusiness.ObtenerClienteCompleto(Convert.ToInt32(cuentasGestionandoAsesor[0]));
            }
            else
            {
                unitOfWork.RecurrenciaCargaBase.ApartarCuentaaGestionarRecurrencia(idAsesor);
                noRecursividad++;
                if (noRecursividad > 1) return null;
                return TraerInformacionCuentaRecurrencia(idAsesor, noRecursividad);
            }
        }

        public RecurrenciaCargaBase TraerDatosRecurrencia(int idAsesor, int CuentaCliente)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            return unitOfWork.RecurrenciaCargaBase.Find(c => c.Usuario_gestionando == idAsesor && c.Cuenta == CuentaCliente).FirstOrDefault();
        }
        public void EliminaCuentaRecurrencia(decimal Cuenta)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            RecurrenciaCargaBase CuentaEliminar = unitWork.RecurrenciaCargaBase.Find(c => c.Cuenta == Cuenta).FirstOrDefault();

            if (CuentaEliminar != null)
            {
                unitWork.RecurrenciaCargaBase.Remove(CuentaEliminar);
                unitWork.Complete();
                unitWork.Dispose();
            }
            else { }
        }
        public void InsertarGRecurrencia(GPrincipalRecurrencia recurrencia)
        {
            try
            {
                recurrencia.FechaGestion = DateTime.Now;

                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.GPrincipalRecurrencia.Add(recurrencia);
                unitWork.Complete();
                unitWork.Dispose();


                UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
                GLogRecurrencia LogRecurrencia = new GLogRecurrencia();

                LogRecurrencia.FechaGestion = recurrencia.FechaGestion;
                LogRecurrencia.UsuarioGestion = recurrencia.UsuarioGestion;
                LogRecurrencia.NombreUsuarioGestion = recurrencia.NombreUsuarioGestion;
                LogRecurrencia.AliadoGestion = recurrencia.AliadoGestion;
                LogRecurrencia.CuentaCliente = recurrencia.CuentaCliente;
                LogRecurrencia.NombreCliente = recurrencia.NombreCliente;
                LogRecurrencia.ApellidoCliente = recurrencia.ApellidoCliente;
                LogRecurrencia.Division = recurrencia.Division;
                LogRecurrencia.Area = recurrencia.Area;
                LogRecurrencia.Zona = recurrencia.Zona;
                LogRecurrencia.Marcaciones = recurrencia.Marcaciones;
                LogRecurrencia.FechaUltimaMarcacion = recurrencia.FechaUltimaMarcacion;
                LogRecurrencia.FechaUltimaGestion = recurrencia.FechaUltimaGestion;
                LogRecurrencia.Telefono1 = recurrencia.Telefono1;
                LogRecurrencia.Telefono2 = recurrencia.Telefono2;
                LogRecurrencia.Telefono3 = recurrencia.Telefono3;
                LogRecurrencia.TelefonoTelmex = recurrencia.TelefonoTelmex;
                LogRecurrencia.IncluyeClaroVideo = recurrencia.IncluyeClaroVideo;
                LogRecurrencia.UsoClaroVideo = recurrencia.UsoClaroVideo;
                LogRecurrencia.ClienteNagra = recurrencia.ClienteNagra;
                LogRecurrencia.Ofrecimiento1 = recurrencia.Ofrecimiento1;
                LogRecurrencia.Ofrecimiento2 = recurrencia.Ofrecimiento2;
                LogRecurrencia.Ofrecimiento3 = recurrencia.Ofrecimiento3;
                LogRecurrencia.Diferenciador = recurrencia.Diferenciador;
                LogRecurrencia.Prioridad = recurrencia.Prioridad;
                LogRecurrencia.VecesGestionado = recurrencia.VecesGestionado;
                LogRecurrencia.MacroProcesoRecurrencia1 = recurrencia.MacroProcesoRecurrencia1;
                LogRecurrencia.MacroProcesoRecurrencia2 = recurrencia.MacroProcesoRecurrencia2;
                LogRecurrencia.MacroProcesoRecurrencia3 = recurrencia.MacroProcesoRecurrencia3;
                LogRecurrencia.MarcacionRecurrente1 = recurrencia.MarcacionRecurrente1;
                LogRecurrencia.MarcacionRecurrente2 = recurrencia.MarcacionRecurrente2;
                LogRecurrencia.MarcacionRecurrente3 = recurrencia.MarcacionRecurrente3;
                LogRecurrencia.VolvioLlamar = recurrencia.VolvioLlamar;
                LogRecurrencia.PorQue = recurrencia.PorQue;
                LogRecurrencia.Contacto = recurrencia.Contacto;
                LogRecurrencia.VozCliente = recurrencia.VozCliente;
                LogRecurrencia.ClientePresentaNovedades = recurrencia.ClientePresentaNovedades;
                LogRecurrencia.Proceso = recurrencia.Proceso;
                LogRecurrencia.Macroproceso = recurrencia.Macroproceso;
                LogRecurrencia.ServicioAfectado = recurrencia.ServicioAfectado;
                LogRecurrencia.FallaEspecificaArbolCCAA = recurrencia.FallaEspecificaArbolCCAA;
                LogRecurrencia.FallaCausaRaiz = recurrencia.FallaCausaRaiz;
                LogRecurrencia.SolucionEspecifica = recurrencia.SolucionEspecifica;
                LogRecurrencia.Solucionado = recurrencia.Solucionado;
                LogRecurrencia.Estado = recurrencia.Estado;
                LogRecurrencia.ActivacionClaroVideoNagra = recurrencia.ActivacionClaroVideoNagra;
                LogRecurrencia.AceptacionPrimerOfrecimiento = recurrencia.AceptacionPrimerOfrecimiento;
                LogRecurrencia.AceptacionSegundoOfrecimiento = recurrencia.AceptacionSegundoOfrecimiento;
                LogRecurrencia.AceptacionTercerOfrecimiento = recurrencia.AceptacionTercerOfrecimiento;
                LogRecurrencia.Observaciones = recurrencia.Observaciones;
                unitWorkLog.GLogRecurrencia.Add(LogRecurrencia);
                unitWorkLog.Complete();
                unitWorkLog.Dispose();

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
        }
        public void ActualizarGRecurrencia(GPrincipalRecurrencia recurrencia)
        {
            try
            {
                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                recurrencia.FechaGestion = DateTime.Now;
                GPrincipalRecurrencia GPRecurActualizable = unitWork.GPrincipalRecurrencia.Find(c => c.CuentaCliente == recurrencia.CuentaCliente).FirstOrDefault();

                GPRecurActualizable.FechaGestion = recurrencia.FechaGestion;
                GPRecurActualizable.UsuarioGestion = recurrencia.UsuarioGestion;
                GPRecurActualizable.NombreUsuarioGestion = recurrencia.NombreUsuarioGestion;
                GPRecurActualizable.AliadoGestion = recurrencia.AliadoGestion;
                GPRecurActualizable.CuentaCliente = recurrencia.CuentaCliente;
                GPRecurActualizable.NombreCliente = recurrencia.NombreCliente;
                GPRecurActualizable.ApellidoCliente = recurrencia.ApellidoCliente;
                GPRecurActualizable.Division = recurrencia.Division;
                GPRecurActualizable.Area = recurrencia.Area;
                GPRecurActualizable.Zona = recurrencia.Zona;
                GPRecurActualizable.Marcaciones = recurrencia.Marcaciones;
                GPRecurActualizable.FechaUltimaMarcacion = recurrencia.FechaUltimaMarcacion;
                GPRecurActualizable.FechaUltimaGestion = recurrencia.FechaUltimaGestion;
                GPRecurActualizable.Telefono1 = recurrencia.Telefono1;
                GPRecurActualizable.Telefono2 = recurrencia.Telefono2;
                GPRecurActualizable.Telefono3 = recurrencia.Telefono3;
                GPRecurActualizable.TelefonoTelmex = recurrencia.TelefonoTelmex;
                GPRecurActualizable.IncluyeClaroVideo = recurrencia.IncluyeClaroVideo;
                GPRecurActualizable.UsoClaroVideo = recurrencia.UsoClaroVideo;
                GPRecurActualizable.ClienteNagra = recurrencia.ClienteNagra;
                GPRecurActualizable.Ofrecimiento1 = recurrencia.Ofrecimiento1;
                GPRecurActualizable.Ofrecimiento2 = recurrencia.Ofrecimiento2;
                GPRecurActualizable.Ofrecimiento3 = recurrencia.Ofrecimiento3;
                GPRecurActualizable.Diferenciador = recurrencia.Diferenciador;
                GPRecurActualizable.Prioridad = recurrencia.Prioridad;
                GPRecurActualizable.VecesGestionado = recurrencia.VecesGestionado;
                GPRecurActualizable.MacroProcesoRecurrencia1 = recurrencia.MacroProcesoRecurrencia1;
                GPRecurActualizable.MacroProcesoRecurrencia2 = recurrencia.MacroProcesoRecurrencia2;
                GPRecurActualizable.MacroProcesoRecurrencia3 = recurrencia.MacroProcesoRecurrencia3;
                GPRecurActualizable.MarcacionRecurrente1 = recurrencia.MarcacionRecurrente1;
                GPRecurActualizable.MarcacionRecurrente2 = recurrencia.MarcacionRecurrente2;
                GPRecurActualizable.MarcacionRecurrente3 = recurrencia.MarcacionRecurrente3;
                GPRecurActualizable.VolvioLlamar = recurrencia.VolvioLlamar;
                GPRecurActualizable.PorQue = recurrencia.PorQue;
                GPRecurActualizable.Contacto = recurrencia.Contacto;
                GPRecurActualizable.VozCliente = recurrencia.VozCliente;
                GPRecurActualizable.ClientePresentaNovedades = recurrencia.ClientePresentaNovedades;
                GPRecurActualizable.Proceso = recurrencia.Proceso;
                GPRecurActualizable.Macroproceso = recurrencia.Macroproceso;
                GPRecurActualizable.ServicioAfectado = recurrencia.ServicioAfectado;
                GPRecurActualizable.FallaEspecificaArbolCCAA = recurrencia.FallaEspecificaArbolCCAA;
                GPRecurActualizable.FallaCausaRaiz = recurrencia.FallaCausaRaiz;
                GPRecurActualizable.SolucionEspecifica = recurrencia.SolucionEspecifica;
                GPRecurActualizable.Solucionado = recurrencia.Solucionado;
                GPRecurActualizable.Estado = recurrencia.Estado;
                GPRecurActualizable.ActivacionClaroVideoNagra = recurrencia.ActivacionClaroVideoNagra;
                GPRecurActualizable.AceptacionPrimerOfrecimiento = recurrencia.AceptacionPrimerOfrecimiento;
                GPRecurActualizable.AceptacionSegundoOfrecimiento = recurrencia.AceptacionSegundoOfrecimiento;
                GPRecurActualizable.AceptacionTercerOfrecimiento = recurrencia.AceptacionTercerOfrecimiento;
                GPRecurActualizable.Observaciones = recurrencia.Observaciones;
                GPRecurActualizable.UsuarioGestionando = recurrencia.UsuarioGestionando;
                unitWork.Complete();
                unitWork.Dispose();

                UnitOfWork unitWorkLog = new UnitOfWork(new DimeContext());
                GLogRecurrencia LogRecurrencia = new GLogRecurrencia();

                LogRecurrencia.FechaGestion = recurrencia.FechaGestion;
                LogRecurrencia.UsuarioGestion = recurrencia.UsuarioGestion;
                LogRecurrencia.NombreUsuarioGestion = recurrencia.NombreUsuarioGestion;
                LogRecurrencia.AliadoGestion = recurrencia.AliadoGestion;
                LogRecurrencia.CuentaCliente = recurrencia.CuentaCliente;
                LogRecurrencia.NombreCliente = recurrencia.NombreCliente;
                LogRecurrencia.ApellidoCliente = recurrencia.ApellidoCliente;
                LogRecurrencia.Division = recurrencia.Division;
                LogRecurrencia.Area = recurrencia.Area;
                LogRecurrencia.Zona = recurrencia.Zona;
                LogRecurrencia.Marcaciones = recurrencia.Marcaciones;
                LogRecurrencia.FechaUltimaMarcacion = recurrencia.FechaUltimaMarcacion;
                LogRecurrencia.FechaUltimaGestion = recurrencia.FechaUltimaGestion;
                LogRecurrencia.Telefono1 = recurrencia.Telefono1;
                LogRecurrencia.Telefono2 = recurrencia.Telefono2;
                LogRecurrencia.Telefono3 = recurrencia.Telefono3;
                LogRecurrencia.TelefonoTelmex = recurrencia.TelefonoTelmex;
                LogRecurrencia.IncluyeClaroVideo = recurrencia.IncluyeClaroVideo;
                LogRecurrencia.UsoClaroVideo = recurrencia.UsoClaroVideo;
                LogRecurrencia.ClienteNagra = recurrencia.ClienteNagra;
                LogRecurrencia.Ofrecimiento1 = recurrencia.Ofrecimiento1;
                LogRecurrencia.Ofrecimiento2 = recurrencia.Ofrecimiento2;
                LogRecurrencia.Ofrecimiento3 = recurrencia.Ofrecimiento3;
                LogRecurrencia.Diferenciador = recurrencia.Diferenciador;
                LogRecurrencia.Prioridad = recurrencia.Prioridad;
                LogRecurrencia.VecesGestionado = recurrencia.VecesGestionado;
                LogRecurrencia.MacroProcesoRecurrencia1 = recurrencia.MacroProcesoRecurrencia1;
                LogRecurrencia.MacroProcesoRecurrencia2 = recurrencia.MacroProcesoRecurrencia2;
                LogRecurrencia.MacroProcesoRecurrencia3 = recurrencia.MacroProcesoRecurrencia3;
                LogRecurrencia.MarcacionRecurrente1 = recurrencia.MarcacionRecurrente1;
                LogRecurrencia.MarcacionRecurrente2 = recurrencia.MarcacionRecurrente2;
                LogRecurrencia.MarcacionRecurrente3 = recurrencia.MarcacionRecurrente3;
                LogRecurrencia.VolvioLlamar = recurrencia.VolvioLlamar;
                LogRecurrencia.PorQue = recurrencia.PorQue;
                LogRecurrencia.Contacto = recurrencia.Contacto;
                LogRecurrencia.VozCliente = recurrencia.VozCliente;
                LogRecurrencia.ClientePresentaNovedades = recurrencia.ClientePresentaNovedades;
                LogRecurrencia.Proceso = recurrencia.Proceso;
                LogRecurrencia.Macroproceso = recurrencia.Macroproceso;
                LogRecurrencia.ServicioAfectado = recurrencia.ServicioAfectado;
                LogRecurrencia.FallaEspecificaArbolCCAA = recurrencia.FallaEspecificaArbolCCAA;
                LogRecurrencia.FallaCausaRaiz = recurrencia.FallaCausaRaiz;
                LogRecurrencia.SolucionEspecifica = recurrencia.SolucionEspecifica;
                LogRecurrencia.Solucionado = recurrencia.Solucionado;
                LogRecurrencia.Estado = recurrencia.Estado;
                LogRecurrencia.ActivacionClaroVideoNagra = recurrencia.ActivacionClaroVideoNagra;
                LogRecurrencia.AceptacionPrimerOfrecimiento = recurrencia.AceptacionPrimerOfrecimiento;
                LogRecurrencia.AceptacionSegundoOfrecimiento = recurrencia.AceptacionSegundoOfrecimiento;
                LogRecurrencia.AceptacionTercerOfrecimiento = recurrencia.AceptacionTercerOfrecimiento;
                LogRecurrencia.Observaciones = recurrencia.Observaciones;
                unitWorkLog.GLogRecurrencia.Add(LogRecurrencia);
                unitWorkLog.Complete();
                unitWorkLog.Dispose();

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }
        }
        public GPrincipalRecurrencia TraerGPrinRecurrencia(int CuentaCliente)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            return unitOfWork.GPrincipalRecurrencia.Find(c => c.CuentaCliente == CuentaCliente).FirstOrDefault();
        }
        public List<GPrincipalRecurrencia> ListaSeguimientosRecurrencia()
        {
            DimeContext dimContext = new DimeContext();
            List<GPrincipalRecurrencia> result = new List<GPrincipalRecurrencia>();
            var objetosResult = (from a in dimContext.GPrincipalRecurrencia
                                 where a.Estado == "SEGUIMIENTO"
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     a.NombreUsuarioGestion,
                                     a.AliadoGestion,
                                     a.CuentaCliente,
                                     a.NombreCliente,
                                     a.ApellidoCliente,
                                     a.Division,
                                     a.Area,
                                     a.Zona,
                                     a.Marcaciones,
                                     a.FechaUltimaMarcacion,
                                     a.FechaUltimaGestion,
                                     a.Telefono1,
                                     a.Telefono2,
                                     a.Telefono3,
                                     a.TelefonoTelmex,
                                     a.IncluyeClaroVideo,
                                     a.UsoClaroVideo,
                                     a.ClienteNagra,
                                     a.Ofrecimiento1,
                                     a.Ofrecimiento2,
                                     a.Ofrecimiento3,
                                     a.Diferenciador,
                                     a.Prioridad,
                                     a.VecesGestionado,
                                     a.MacroProcesoRecurrencia1,
                                     a.MacroProcesoRecurrencia2,
                                     a.MacroProcesoRecurrencia3,
                                     a.MarcacionRecurrente1,
                                     a.MarcacionRecurrente2,
                                     a.MarcacionRecurrente3,
                                     a.VolvioLlamar,
                                     a.PorQue,
                                     a.Contacto,
                                     a.VozCliente,
                                     a.ClientePresentaNovedades,
                                     a.Proceso,
                                     a.Macroproceso,
                                     a.ServicioAfectado,
                                     a.FallaEspecificaArbolCCAA,
                                     a.FallaCausaRaiz,
                                     a.SolucionEspecifica,
                                     a.Solucionado,
                                     a.Estado,
                                     a.ActivacionClaroVideoNagra,
                                     a.AceptacionPrimerOfrecimiento,
                                     a.AceptacionSegundoOfrecimiento,
                                     a.AceptacionTercerOfrecimiento,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GPrincipalRecurrencia());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].NombreUsuarioGestion = objetosResult[i].NombreUsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NombreCliente = objetosResult[i].NombreCliente;
                result[i].ApellidoCliente = objetosResult[i].ApellidoCliente;
                result[i].Division = objetosResult[i].Division;
                result[i].Area = objetosResult[i].Area;
                result[i].Zona = objetosResult[i].Zona;
                result[i].Marcaciones = objetosResult[i].Marcaciones;
                result[i].FechaUltimaMarcacion = objetosResult[i].FechaUltimaMarcacion;
                result[i].FechaUltimaGestion = objetosResult[i].FechaUltimaGestion;
                result[i].Telefono1 = objetosResult[i].Telefono1;
                result[i].Telefono2 = objetosResult[i].Telefono2;
                result[i].Telefono3 = objetosResult[i].Telefono3;
                result[i].TelefonoTelmex = objetosResult[i].TelefonoTelmex;
                result[i].IncluyeClaroVideo = objetosResult[i].IncluyeClaroVideo;
                result[i].UsoClaroVideo = objetosResult[i].UsoClaroVideo;
                result[i].ClienteNagra = objetosResult[i].ClienteNagra;
                result[i].Ofrecimiento1 = objetosResult[i].Ofrecimiento1;
                result[i].Ofrecimiento2 = objetosResult[i].Ofrecimiento2;
                result[i].Ofrecimiento3 = objetosResult[i].Ofrecimiento3;
                result[i].Diferenciador = objetosResult[i].Diferenciador;
                result[i].Prioridad = objetosResult[i].Prioridad;
                result[i].VecesGestionado = objetosResult[i].VecesGestionado;
                result[i].MacroProcesoRecurrencia1 = objetosResult[i].MacroProcesoRecurrencia1;
                result[i].MacroProcesoRecurrencia2 = objetosResult[i].MacroProcesoRecurrencia2;
                result[i].MacroProcesoRecurrencia3 = objetosResult[i].MacroProcesoRecurrencia3;
                result[i].MarcacionRecurrente1 = objetosResult[i].MarcacionRecurrente1;
                result[i].MarcacionRecurrente2 = objetosResult[i].MarcacionRecurrente2;
                result[i].MarcacionRecurrente3 = objetosResult[i].MarcacionRecurrente3;
                result[i].VolvioLlamar = objetosResult[i].VolvioLlamar;
                result[i].PorQue = objetosResult[i].PorQue;
                result[i].Contacto = objetosResult[i].Contacto;
                result[i].VozCliente = objetosResult[i].VozCliente;
                result[i].ClientePresentaNovedades = objetosResult[i].ClientePresentaNovedades;
                result[i].Proceso = objetosResult[i].Proceso;
                result[i].Macroproceso = objetosResult[i].Macroproceso;
                result[i].ServicioAfectado = objetosResult[i].ServicioAfectado;
                result[i].FallaEspecificaArbolCCAA = objetosResult[i].FallaEspecificaArbolCCAA;
                result[i].FallaCausaRaiz = objetosResult[i].FallaCausaRaiz;
                result[i].SolucionEspecifica = objetosResult[i].SolucionEspecifica;
                result[i].Solucionado = objetosResult[i].Solucionado;
                result[i].Estado = objetosResult[i].Estado;
                result[i].ActivacionClaroVideoNagra = objetosResult[i].ActivacionClaroVideoNagra;
                result[i].AceptacionPrimerOfrecimiento = objetosResult[i].AceptacionPrimerOfrecimiento;
                result[i].AceptacionSegundoOfrecimiento = objetosResult[i].AceptacionSegundoOfrecimiento;
                result[i].AceptacionTercerOfrecimiento = objetosResult[i].AceptacionTercerOfrecimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;
        }
        public void UsuarioGestionandoGRecurrencia(int idUsuario, int idCaso)
        {

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            GPrincipalRecurrencia GPRecurActualizable = unitWork.GPrincipalRecurrencia.Find(c => c.Id == idCaso).FirstOrDefault();

            GPRecurActualizable.UsuarioGestionando = idUsuario;
            unitWork.Complete();
            unitWork.Dispose();
        }
        public List<GPrincipalRecurrencia> ConsultaAdminGPrincipalRecurrencia(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<GPrincipalRecurrencia> result = new List<GPrincipalRecurrencia>();
            var objetosResult = (from a in dimContext.GPrincipalRecurrencia
                                 where a.FechaGestion >= FechaInicial && a.FechaGestion <= FechaFinal
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     a.NombreUsuarioGestion,
                                     a.AliadoGestion,
                                     a.CuentaCliente,
                                     a.NombreCliente,
                                     a.ApellidoCliente,
                                     a.Division,
                                     a.Area,
                                     a.Zona,
                                     a.Marcaciones,
                                     a.FechaUltimaMarcacion,
                                     a.FechaUltimaGestion,
                                     a.Telefono1,
                                     a.Telefono2,
                                     a.Telefono3,
                                     a.TelefonoTelmex,
                                     a.IncluyeClaroVideo,
                                     a.UsoClaroVideo,
                                     a.ClienteNagra,
                                     a.Ofrecimiento1,
                                     a.Ofrecimiento2,
                                     a.Ofrecimiento3,
                                     a.Diferenciador,
                                     a.Prioridad,
                                     a.VecesGestionado,
                                     a.MacroProcesoRecurrencia1,
                                     a.MacroProcesoRecurrencia2,
                                     a.MacroProcesoRecurrencia3,
                                     a.MarcacionRecurrente1,
                                     a.MarcacionRecurrente2,
                                     a.MarcacionRecurrente3,
                                     a.VolvioLlamar,
                                     a.PorQue,
                                     a.Contacto,
                                     a.VozCliente,
                                     a.ClientePresentaNovedades,
                                     a.Proceso,
                                     a.Macroproceso,
                                     a.ServicioAfectado,
                                     a.FallaEspecificaArbolCCAA,
                                     a.FallaCausaRaiz,
                                     a.SolucionEspecifica,
                                     a.Solucionado,
                                     a.Estado,
                                     a.ActivacionClaroVideoNagra,
                                     a.AceptacionPrimerOfrecimiento,
                                     a.AceptacionSegundoOfrecimiento,
                                     a.AceptacionTercerOfrecimiento,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GPrincipalRecurrencia());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].NombreUsuarioGestion = objetosResult[i].NombreUsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NombreCliente = objetosResult[i].NombreCliente;
                result[i].ApellidoCliente = objetosResult[i].ApellidoCliente;
                result[i].Division = objetosResult[i].Division;
                result[i].Area = objetosResult[i].Area;
                result[i].Zona = objetosResult[i].Zona;
                result[i].Marcaciones = objetosResult[i].Marcaciones;
                result[i].FechaUltimaMarcacion = objetosResult[i].FechaUltimaMarcacion;
                result[i].FechaUltimaGestion = objetosResult[i].FechaUltimaGestion;
                result[i].Telefono1 = objetosResult[i].Telefono1;
                result[i].Telefono2 = objetosResult[i].Telefono2;
                result[i].Telefono3 = objetosResult[i].Telefono3;
                result[i].TelefonoTelmex = objetosResult[i].TelefonoTelmex;
                result[i].IncluyeClaroVideo = objetosResult[i].IncluyeClaroVideo;
                result[i].UsoClaroVideo = objetosResult[i].UsoClaroVideo;
                result[i].ClienteNagra = objetosResult[i].ClienteNagra;
                result[i].Ofrecimiento1 = objetosResult[i].Ofrecimiento1;
                result[i].Ofrecimiento2 = objetosResult[i].Ofrecimiento2;
                result[i].Ofrecimiento3 = objetosResult[i].Ofrecimiento3;
                result[i].Diferenciador = objetosResult[i].Diferenciador;
                result[i].Prioridad = objetosResult[i].Prioridad;
                result[i].VecesGestionado = objetosResult[i].VecesGestionado;
                result[i].MacroProcesoRecurrencia1 = objetosResult[i].MacroProcesoRecurrencia1;
                result[i].MacroProcesoRecurrencia2 = objetosResult[i].MacroProcesoRecurrencia2;
                result[i].MacroProcesoRecurrencia3 = objetosResult[i].MacroProcesoRecurrencia3;
                result[i].MarcacionRecurrente1 = objetosResult[i].MarcacionRecurrente1;
                result[i].MarcacionRecurrente2 = objetosResult[i].MarcacionRecurrente2;
                result[i].MarcacionRecurrente3 = objetosResult[i].MarcacionRecurrente3;
                result[i].VolvioLlamar = objetosResult[i].VolvioLlamar;
                result[i].PorQue = objetosResult[i].PorQue;
                result[i].Contacto = objetosResult[i].Contacto;
                result[i].VozCliente = objetosResult[i].VozCliente;
                result[i].ClientePresentaNovedades = objetosResult[i].ClientePresentaNovedades;
                result[i].Proceso = objetosResult[i].Proceso;
                result[i].Macroproceso = objetosResult[i].Macroproceso;
                result[i].ServicioAfectado = objetosResult[i].ServicioAfectado;
                result[i].FallaEspecificaArbolCCAA = objetosResult[i].FallaEspecificaArbolCCAA;
                result[i].FallaCausaRaiz = objetosResult[i].FallaCausaRaiz;
                result[i].SolucionEspecifica = objetosResult[i].SolucionEspecifica;
                result[i].Solucionado = objetosResult[i].Solucionado;
                result[i].Estado = objetosResult[i].Estado;
                result[i].ActivacionClaroVideoNagra = objetosResult[i].ActivacionClaroVideoNagra;
                result[i].AceptacionPrimerOfrecimiento = objetosResult[i].AceptacionPrimerOfrecimiento;
                result[i].AceptacionSegundoOfrecimiento = objetosResult[i].AceptacionSegundoOfrecimiento;
                result[i].AceptacionTercerOfrecimiento = objetosResult[i].AceptacionTercerOfrecimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;
        }
        public List<GLogRecurrencia> ConsultaAdminGLogRecurrencia(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<GLogRecurrencia> result = new List<GLogRecurrencia>();
            var objetosResult = (from a in dimContext.GLogRecurrencia
                                 where a.FechaGestion >= FechaInicial && a.FechaGestion <= FechaFinal
                                 select new
                                 {
                                     a.Id,
                                     a.FechaGestion,
                                     a.UsuarioGestion,
                                     a.NombreUsuarioGestion,
                                     a.AliadoGestion,
                                     a.CuentaCliente,
                                     a.NombreCliente,
                                     a.ApellidoCliente,
                                     a.Division,
                                     a.Area,
                                     a.Zona,
                                     a.Marcaciones,
                                     a.FechaUltimaMarcacion,
                                     a.FechaUltimaGestion,
                                     a.Telefono1,
                                     a.Telefono2,
                                     a.Telefono3,
                                     a.TelefonoTelmex,
                                     a.IncluyeClaroVideo,
                                     a.UsoClaroVideo,
                                     a.ClienteNagra,
                                     a.Ofrecimiento1,
                                     a.Ofrecimiento2,
                                     a.Ofrecimiento3,
                                     a.Diferenciador,
                                     a.Prioridad,
                                     a.VecesGestionado,
                                     a.MacroProcesoRecurrencia1,
                                     a.MacroProcesoRecurrencia2,
                                     a.MacroProcesoRecurrencia3,
                                     a.MarcacionRecurrente1,
                                     a.MarcacionRecurrente2,
                                     a.MarcacionRecurrente3,
                                     a.VolvioLlamar,
                                     a.PorQue,
                                     a.Contacto,
                                     a.VozCliente,
                                     a.ClientePresentaNovedades,
                                     a.Proceso,
                                     a.Macroproceso,
                                     a.ServicioAfectado,
                                     a.FallaEspecificaArbolCCAA,
                                     a.FallaCausaRaiz,
                                     a.SolucionEspecifica,
                                     a.Solucionado,
                                     a.Estado,
                                     a.ActivacionClaroVideoNagra,
                                     a.AceptacionPrimerOfrecimiento,
                                     a.AceptacionSegundoOfrecimiento,
                                     a.AceptacionTercerOfrecimiento,
                                     a.Observaciones
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GLogRecurrencia());
                result[i].Id = objetosResult[i].Id;
                result[i].FechaGestion = objetosResult[i].FechaGestion;
                result[i].UsuarioGestion = objetosResult[i].UsuarioGestion;
                result[i].NombreUsuarioGestion = objetosResult[i].NombreUsuarioGestion;
                result[i].AliadoGestion = objetosResult[i].AliadoGestion;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].NombreCliente = objetosResult[i].NombreCliente;
                result[i].ApellidoCliente = objetosResult[i].ApellidoCliente;
                result[i].Division = objetosResult[i].Division;
                result[i].Area = objetosResult[i].Area;
                result[i].Zona = objetosResult[i].Zona;
                result[i].Marcaciones = objetosResult[i].Marcaciones;
                result[i].FechaUltimaMarcacion = objetosResult[i].FechaUltimaMarcacion;
                result[i].FechaUltimaGestion = objetosResult[i].FechaUltimaGestion;
                result[i].Telefono1 = objetosResult[i].Telefono1;
                result[i].Telefono2 = objetosResult[i].Telefono2;
                result[i].Telefono3 = objetosResult[i].Telefono3;
                result[i].TelefonoTelmex = objetosResult[i].TelefonoTelmex;
                result[i].IncluyeClaroVideo = objetosResult[i].IncluyeClaroVideo;
                result[i].UsoClaroVideo = objetosResult[i].UsoClaroVideo;
                result[i].ClienteNagra = objetosResult[i].ClienteNagra;
                result[i].Ofrecimiento1 = objetosResult[i].Ofrecimiento1;
                result[i].Ofrecimiento2 = objetosResult[i].Ofrecimiento2;
                result[i].Ofrecimiento3 = objetosResult[i].Ofrecimiento3;
                result[i].Diferenciador = objetosResult[i].Diferenciador;
                result[i].Prioridad = objetosResult[i].Prioridad;
                result[i].VecesGestionado = objetosResult[i].VecesGestionado;
                result[i].MacroProcesoRecurrencia1 = objetosResult[i].MacroProcesoRecurrencia1;
                result[i].MacroProcesoRecurrencia2 = objetosResult[i].MacroProcesoRecurrencia2;
                result[i].MacroProcesoRecurrencia3 = objetosResult[i].MacroProcesoRecurrencia3;
                result[i].MarcacionRecurrente1 = objetosResult[i].MarcacionRecurrente1;
                result[i].MarcacionRecurrente2 = objetosResult[i].MarcacionRecurrente2;
                result[i].MarcacionRecurrente3 = objetosResult[i].MarcacionRecurrente3;
                result[i].VolvioLlamar = objetosResult[i].VolvioLlamar;
                result[i].PorQue = objetosResult[i].PorQue;
                result[i].Contacto = objetosResult[i].Contacto;
                result[i].VozCliente = objetosResult[i].VozCliente;
                result[i].ClientePresentaNovedades = objetosResult[i].ClientePresentaNovedades;
                result[i].Proceso = objetosResult[i].Proceso;
                result[i].Macroproceso = objetosResult[i].Macroproceso;
                result[i].ServicioAfectado = objetosResult[i].ServicioAfectado;
                result[i].FallaEspecificaArbolCCAA = objetosResult[i].FallaEspecificaArbolCCAA;
                result[i].FallaCausaRaiz = objetosResult[i].FallaCausaRaiz;
                result[i].SolucionEspecifica = objetosResult[i].SolucionEspecifica;
                result[i].Solucionado = objetosResult[i].Solucionado;
                result[i].Estado = objetosResult[i].Estado;
                result[i].ActivacionClaroVideoNagra = objetosResult[i].ActivacionClaroVideoNagra;
                result[i].AceptacionPrimerOfrecimiento = objetosResult[i].AceptacionPrimerOfrecimiento;
                result[i].AceptacionSegundoOfrecimiento = objetosResult[i].AceptacionSegundoOfrecimiento;
                result[i].AceptacionTercerOfrecimiento = objetosResult[i].AceptacionTercerOfrecimiento;
                result[i].Observaciones = objetosResult[i].Observaciones;
            }
            return result;
        }
    }
}
    