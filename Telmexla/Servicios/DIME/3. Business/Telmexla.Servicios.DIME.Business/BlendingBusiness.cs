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
    public class BlendingBusiness
    {


        public ConvenioElectronicoCollection getHistorialConvenioElectroDeAsesor(int idAsesor)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List <ConvenioElectronico> conveniosElectronicos = unitOfWork.conveniosElectronicos.Find(c => c.UsuarioGestion.Equals(idAsesor.ToString())).ToList();
            ConvenioElectronicoCollection result = new ConvenioElectronicoCollection();
            result.AddRange(conveniosElectronicos);
            return result;
        }

        public bool ProcesoGuardarGestionConvenioElectro(int idAsesor, ClientesTodo datosCliente, ConvenioElectronico convElectGestionado)
        {
            UnitOfWorkMaestros unitWorkMaestros = new UnitOfWorkMaestros(new MaestrosContext());

            convElectGestionado.FechaGestion = DateTime.Now;
            convElectGestionado.HoraGestion = DateTime.Now;
            convElectGestionado.UsuarioGestion = idAsesor.ToString();
            convElectGestionado.CuentaCliente = datosCliente.Cuenta;
            convElectGestionado.NombreCliente = datosCliente.Nombre;
            convElectGestionado.ApellidoCliente = datosCliente.Apellido;
            convElectGestionado.DireccionInstalacion = datosCliente.DirInstalacion;
            convElectGestionado.DireccionCorrespondenciaActual = datosCliente.DirCorrespondencia;
            convElectGestionado.TelefonoTelmex = System.Convert.ToDecimal(datosCliente.TelefonoTelmex);
            convElectGestionado.Telefono1 = System.Convert.ToDecimal(datosCliente.Telefono1);
            convElectGestionado.Telefono2 = System.Convert.ToDecimal(datosCliente.Telefono2);
            convElectGestionado.Telefono3 = System.Convert.ToDecimal(datosCliente.Telefono3);
            convElectGestionado.MovilActual = Convert.ToDecimal(datosCliente.TelefonoConv);
            convElectGestionado.CorreoActual = datosCliente.Correo;
            convElectGestionado.TipoContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(convElectGestionado.TipoContacto)).TipoContacto;
            convElectGestionado.Cierre = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(convElectGestionado.Cierre)).Cierre;
            convElectGestionado.Razon = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(convElectGestionado.Razon)).Razon;
            if(convElectGestionado.FechaSeguimiento != null)
            {
                convElectGestionado.Seguimiento = "SI";
            }

            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
        
            //Sig linea actualiza gestiones outbound que usuario esta gestionando para liberar
            GestionOutbound enGestiondeUsuario = new GestionOutbound();
            enGestiondeUsuario = unitOfWork.gestionesOutbound.Find(c => c.UsuarioGestionando == idAsesor && c.NombreBase.Equals("CONVENIO_ELECTRONICO")).SingleOrDefault();
            if (enGestiondeUsuario != null)
            {   
                enGestiondeUsuario.UsuarioGestionando = 0;
                unitOfWork.conveniosElectronicos.Add(convElectGestionado);
            }
            else
            {
                ActualizarConvenioElectronico(unitOfWork, convElectGestionado);
                convElectGestionado.Id = 0;
            }
            unitOfWork.logConveniosElectronicos.Add((LogConvenioElectronico)convElectGestionado);
            unitOfWork.Complete();
            return true;
        }

        public LogDocsisOverlapCollection IteracionesDocsisOverlapsGestionados(DateTime fInicial, DateTime fFinal)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            LogDocsisOverlapCollection docsisResult = new LogDocsisOverlapCollection();
            docsisResult.AddRange(unitWork.logDocsisOverlaps.Find(c => c.FechaGestion >= fInicial && c.FechaGestion <= fFinal).Select(x=>
            new LogDocsisOverlap { FechaGestion = x.FechaGestion, UsuarioGestion = x.UsuarioGestion, NombreUsuarioGestion = x.NombreUsuarioGestion,
                AliadoGestion = x.AliadoGestion, OperacionGestion = x.OperacionGestion, NombreBase = x.NombreBase, CuentaCliente = x.CuentaCliente,
            TipoDeContacto = x.TipoDeContacto, Cierre = x.Cierre, Razon = x.Razon, Observaciones = x.Observaciones, FechaSeguimiento = x.FechaSeguimiento,
            Aliado = x.Aliado}).ToList());
            foreach (var item in docsisResult)
            {
                item.UsuarioGestion = unitWork.usuarios.Get(Convert.ToInt32(item.UsuarioGestion)).Cedula.ToString();
            }

            return docsisResult;
        }

        public LogCierreCicloCollection IteracionesGestionesCierreCiclo(DateTime fInicial, DateTime fFinal)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            LogCierreCicloCollection cierreResult = new LogCierreCicloCollection();
            cierreResult.AddRange(unitWork.logCierreCiclos.Find(c => c.FechaGestion >= fInicial && c.FechaGestion <= fFinal).ToList());
            foreach(var item in cierreResult)
            {
                item.UsuarioGestion = unitWork.usuarios.Get(Convert.ToInt32(item.UsuarioGestion)).Cedula.ToString();
            }
            return cierreResult;
        }


        public LogClaroVideoCollection IteracionesGestionesClaroVideo(DateTime fInicial, DateTime fFinal)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            LogClaroVideoCollection result = new LogClaroVideoCollection();
            result.AddRange(unitWork.logClaroVideos.Find(c => c.FechaGestion >= fInicial && c.FechaGestion <= fFinal).Select(x=> 
            new LogClaroVideo {FechaGestion = x.FechaGestion, UsuarioGestion = x.UsuarioGestion,
                NombreUsuarioGestion = x.NombreUsuarioGestion, AliadoGestion = x.AliadoGestion,
            OperacionGestion = x.OperacionGestion, CuentaCliente = x.CuentaCliente, TipoDeContacto = x.TipoDeContacto, TipoDeGestion = x.TipoDeGestion, Cierre = x.Cierre,
            Razon = x.Razon, Attributo1 = x.Attributo1, Attributo2 = x.Attributo2, Observaciones = x.Observaciones}).ToList());
            foreach(var item in result)
            {
                item.UsuarioGestion = unitWork.usuarios.Get(Convert.ToInt32(item.UsuarioGestion)).Cedula.ToString();
            }

            return result;
        }

        public void ActualizarConvenioElectronico(UnitOfWork unitWork, ConvenioElectronico v)
        {
            ConvenioElectronico loggerConv = unitWork.conveniosElectronicos.Get(v.Id);
            loggerConv.AliadoGestion = v.AliadoGestion;
            loggerConv.ApellidoCliente = v.ApellidoCliente;
            loggerConv.Cierre = v.Cierre;
            loggerConv.CorreoActual = v.CorreoActual;
            loggerConv.CuentaCliente = v.CuentaCliente;
            loggerConv.DireccionCorrespondenciaActual = v.DireccionCorrespondenciaActual;
            loggerConv.DireccionInstalacion = v.DireccionInstalacion;
            loggerConv.FechaGestion = v.FechaGestion;
            loggerConv.FechaSeguimiento = v.FechaSeguimiento;
            loggerConv.HoraGestion = v.HoraGestion;
            loggerConv.Id = v.Id;
            loggerConv.LineaGestion = v.LineaGestion;
            loggerConv.MovilActual = v.MovilActual;
            loggerConv.MovilNuevo = v.MovilNuevo;
            loggerConv.NombreCliente = v.NombreCliente;
            loggerConv.NuevaDireccionCorrespondencia = v.NuevaDireccionCorrespondencia;
            loggerConv.NuevoCorreo = v.NuevoCorreo;
            loggerConv.Razon = v.Razon;
            loggerConv.Seguimiento = v.Seguimiento;
            loggerConv.Telefono1 = v.Telefono1;
            loggerConv.Telefono2 = v.Telefono2;
            loggerConv.Telefono3 = v.Telefono3;
            loggerConv.TelefonoTelmex = v.TelefonoTelmex;
            loggerConv.TipoContacto = v.TipoContacto;
            loggerConv.UsuarioGestion = v.UsuarioGestion;

        }

        public ConvenioElectronico GetConvenioElectronicoPorId(int idGestionado)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
           return  unitOfWork.conveniosElectronicos.Get(idGestionado);
        }

        public ConvenioElectronicoCollection ConveniosElectronicosGestionados(DateTime fInicial, DateTime fFinal)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            List<ConvenioElectronico> conveniosElectro =  unitWork.conveniosElectronicos.Find(c => c.FechaGestion >= fInicial && c.FechaGestion <= fFinal).Select(x=> 
             new ConvenioElectronico {  FechaGestion= x.FechaGestion, HoraGestion = x.HoraGestion, UsuarioGestion = x.UsuarioGestion, AliadoGestion = x.AliadoGestion,
             LineaGestion = x.LineaGestion , CuentaCliente = x.CuentaCliente, TipoContacto =x.TipoContacto , Cierre = x.Cierre, Razon = x.Razon, MovilNuevo = x.MovilNuevo,
             NuevoCorreo = x.NuevoCorreo, NuevaDireccionCorrespondencia = x.NuevaDireccionCorrespondencia } ).ToList();
            ConvenioElectronicoCollection result = new ConvenioElectronicoCollection();
            result.AddRange(conveniosElectro);
            return result;
        }

        public DocsisOverlapCollection getHistorialDocsisDeAsesor(int idAsesor)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<DocsisOverlap> docsisOverlaps = unitOfWork.docsisOverlaps.Find(c => c.UsuarioGestion.Equals(idAsesor.ToString())).ToList();
            DocsisOverlapCollection result = new DocsisOverlapCollection();
            result.AddRange(docsisOverlaps);
            return result;

        }


        public DocsisOverlap getDocsisLineGestionado(int idGestionado)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            return unitOfWork.docsisOverlaps.Get(idGestionado);
        }

        public bool ProcesoGuardarGestionDocsis(int idAsesor, ClientesTodo datosCliente, DocsisOverlap docsisGestionado)
        {
            UnitOfWorkMaestros unitWorkMaestros = new UnitOfWorkMaestros(new MaestrosContext());
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            var gestionOutboundDeGestion = unitOfWork.gestionesOutbound.Find(c => c.Cuenta == datosCliente.Cuenta && c.NombreBase.Equals("DOCSIS_OVERLAP")).Select(c => new { c.OperacionGestion, c.NombreBase, c.Aliado  }).FirstOrDefault();
            docsisGestionado.FechaGestion = DateTime.Now;
            docsisGestionado.UsuarioGestion = idAsesor.ToString();
            if(gestionOutboundDeGestion != null )
            { 
            docsisGestionado.OperacionGestion = gestionOutboundDeGestion.OperacionGestion;
            docsisGestionado.NombreBase = gestionOutboundDeGestion.NombreBase;
            docsisGestionado.Aliado = gestionOutboundDeGestion.Aliado;
            }
            docsisGestionado.CuentaCliente = datosCliente.Cuenta;
            docsisGestionado.NombreCliente = datosCliente.Nombre;
            docsisGestionado.ApellidoCliente = datosCliente.Apellido;
            docsisGestionado.DireccionInstalacion = datosCliente.DirInstalacion;
            docsisGestionado.DireccionCorrespondencia = datosCliente.DirCorrespondencia;
            docsisGestionado.CorreoElectronico = datosCliente.Correo;
            docsisGestionado.Telefono1 = System.Convert.ToDecimal(datosCliente.Telefono1);
            docsisGestionado.Telefono2 = System.Convert.ToDecimal(datosCliente.Telefono2);
            docsisGestionado.Telefono3 = System.Convert.ToDecimal(datosCliente.Telefono3);
            docsisGestionado.Movil1 = System.Convert.ToDecimal(datosCliente.Celular1);
            docsisGestionado.Movil2 = System.Convert.ToDecimal(datosCliente.Celular2);
            docsisGestionado.PaqueteActual = datosCliente.Productos;
            docsisGestionado.TipoDeContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(docsisGestionado.TipoDeContacto)).TipoContacto;
            docsisGestionado.Gestion = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(docsisGestionado.Gestion)).Cierre;
            docsisGestionado.Cierre = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(docsisGestionado.Cierre)).Razon;
            docsisGestionado.Razon = unitWorkMaestros.maestrosOutboundCausa.Get(Convert.ToInt32(docsisGestionado.Razon)).Causa;
            docsisGestionado.NombreUsuarioGestion = unitOfWork.usuarios.Find(c => c.Id == idAsesor ).Select(c => c.Nombre).SingleOrDefault();
    
            if (docsisGestionado.FechaSeguimiento != null)
            {
                docsisGestionado.Seguimiento = "SI";
            }
         
            //Sig linea actualiza gestiones outbound que usuario esta gestionando para liberar
            GestionOutbound enGestiondeUsuario = new GestionOutbound();
            enGestiondeUsuario = unitOfWork.gestionesOutbound.Find(c => c.UsuarioGestionando == idAsesor  && c.NombreBase.Equals("DOCSIS_OVERLAP")).SingleOrDefault();
            if (enGestiondeUsuario != null)
            {
                enGestiondeUsuario.UsuarioGestionando = 0;
                unitOfWork.docsisOverlaps.Add(docsisGestionado);
            }
            else
            {
                ActualizarDocsisOverlap(unitOfWork,  docsisGestionado);
                docsisGestionado.Id = 0;
            }
            unitOfWork.logDocsisOverlaps.Add((LogDocsisOverlap)docsisGestionado);
            unitOfWork.Complete();
            return true;

        }

        public void ActualizarDocsisOverlap(UnitOfWork unitWork , DocsisOverlap v)
        {
            DocsisOverlap logger = unitWork.docsisOverlaps.Get(v.Id);
            logger.Aliado = v.Aliado;
            logger.AliadoGestion = v.AliadoGestion;
            logger.ApellidoCliente = v.ApellidoCliente;
            logger.Cierre = v.Cierre;
            logger.CorreoElectronico = v.CorreoElectronico;
            logger.CuentaCliente = v.CuentaCliente;
            logger.DireccionCorrespondencia = v.DireccionCorrespondencia;
            logger.DireccionInstalacion = v.DireccionInstalacion;
            logger.FechaGestion = v.FechaGestion;
            logger.FechaSeguimiento = v.FechaSeguimiento;
            logger.Gestion = v.Gestion;
            logger.Id = v.Id;
            logger.Movil1 = v.Movil1;
            logger.Movil2 = v.Movil2;
            logger.NombreBase = v.NombreBase;
            logger.NombreCliente = v.NombreCliente;
            logger.NombreUsuarioGestion = v.NombreUsuarioGestion;
            logger.Observaciones = v.Observaciones;
            logger.OperacionGestion = v.OperacionGestion;
            logger.PaqueteActual = v.PaqueteActual;
            logger.Razon = v.Razon;
            logger.Seguimiento = v.Seguimiento;
            logger.Telefono1 = v.Telefono1;
            logger.Telefono2 = v.Telefono2;
            logger.Telefono3 = v.Telefono3;
            logger.TipoDeContacto = v.TipoDeContacto;
            logger.UsuarioGestion = v.UsuarioGestion;
     
        }

        public ClaroVideoCollection GetHistorialClaroVideoAsesor(int idAsesor)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<ClaroVideo> claroVideos = unitOfWork.claroVideos.Find(c => c.UsuarioGestion.Equals(idAsesor.ToString())).ToList();
            ClaroVideoCollection result = new ClaroVideoCollection();
            result.AddRange(claroVideos);
            return result;
        }


        public ClaroVideo GetClaroVideoGestionado(int idGestionado)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            return unitOfWork.claroVideos.Get(idGestionado);
        }

        public bool ProcesoGuardarClaroVideo(int idAsesor, ClientesTodo datosCliente, ClaroVideo claroVideoGestionado)
        {
            UnitOfWorkMaestros unitWorkMaestros = new UnitOfWorkMaestros(new MaestrosContext());
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            var gestionOutboundDeGestion = unitOfWork.gestionesOutbound.Find(c => c.Cuenta == datosCliente.Cuenta && c.NombreBase.Equals("CLARO_VIDEO")).Select(c => new { c.OperacionGestion, c.NombreBase, c.Aliado }).FirstOrDefault();
            claroVideoGestionado.FechaGestion = DateTime.Now;
            claroVideoGestionado.UsuarioGestion = idAsesor.ToString();
            claroVideoGestionado.NombreUsuarioGestion = unitOfWork.usuarios.Find(c => c.Id == idAsesor).Select(c => c.Nombre).SingleOrDefault();
            if(gestionOutboundDeGestion!= null)   claroVideoGestionado.OperacionGestion = gestionOutboundDeGestion.OperacionGestion;
            claroVideoGestionado.CuentaCliente = datosCliente.Cuenta;
            claroVideoGestionado.NombreCliente = datosCliente.Nombre;
            claroVideoGestionado.ApellidoCliente = datosCliente.Apellido;
            claroVideoGestionado.DireccionInstalacion = datosCliente.DirInstalacion;
            claroVideoGestionado.DireccionCorrespondencia = datosCliente.DirCorrespondencia;
            claroVideoGestionado.CorreoElectronico = datosCliente.Correo;
            claroVideoGestionado.Telefono1 = System.Convert.ToDecimal(datosCliente.Telefono1);
            claroVideoGestionado.Telefono2 = System.Convert.ToDecimal(datosCliente.Telefono2);
            claroVideoGestionado.Telefono3 = System.Convert.ToDecimal(datosCliente.Telefono3);
            claroVideoGestionado.Movil1 = System.Convert.ToDecimal(datosCliente.Celular1);
            claroVideoGestionado.Movil2 = System.Convert.ToDecimal(datosCliente.Celular2);
            claroVideoGestionado.PaqueteActual = datosCliente.Productos;
            claroVideoGestionado.TipoDeContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(claroVideoGestionado.TipoDeContacto)).TipoContacto;
            claroVideoGestionado.TipoDeGestion = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(claroVideoGestionado.TipoDeGestion)).Cierre;
            claroVideoGestionado.Cierre = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(claroVideoGestionado.Cierre)).Razon;
            claroVideoGestionado.Razon = unitWorkMaestros.maestrosOutboundCausa.Get(Convert.ToInt32(claroVideoGestionado.Razon)).Causa;
            if (claroVideoGestionado.FechaSeguimiento != null)
            {
                claroVideoGestionado.Seguimiento = "SI";
            }
             //Sig linea actualiza gestiones outbound que usuario esta gestionando para liberar
            GestionOutbound enGestiondeUsuario  = new GestionOutbound();
            enGestiondeUsuario = unitOfWork.gestionesOutbound.Find(c => c.UsuarioGestionando == idAsesor && c.NombreBase.Equals("CLARO_VIDEO")).SingleOrDefault();
            if (enGestiondeUsuario!= null)
            {
                enGestiondeUsuario.UsuarioGestionando = 0;
                unitOfWork.claroVideos.Add(claroVideoGestionado);
            }
            else
            {
                ActualizarClaroVideo(unitOfWork,claroVideoGestionado);
                claroVideoGestionado.Id = 0;
            }

            unitOfWork.logClaroVideos.Add(ConvertALogClaroVideo(claroVideoGestionado));
            unitOfWork.Complete();
            return true;

        }
        public  LogClaroVideo ConvertALogClaroVideo(ClaroVideo v)
        {

            LogClaroVideo logClaro = new LogClaroVideo();
            logClaro.AliadoGestion = v.AliadoGestion;
            logClaro.ApellidoCliente = v.ApellidoCliente;
            logClaro.Attributo1 = v.Attributo1;
            logClaro.Attributo10 = v.Attributo10;
            logClaro.Attributo2 = v.Attributo2;
            logClaro.Attributo3 = v.Attributo3;
            logClaro.Attributo4 = v.Attributo4;
            logClaro.Attributo5 = v.Attributo5;
            logClaro.Attributo6 = v.Attributo6;
            logClaro.Attributo7 = v.Attributo7;
            logClaro.Attributo8 = v.Attributo8;
            logClaro.Attributo9 = v.Attributo9;
            logClaro.Cierre = v.Cierre;
            logClaro.CorreoElectronico = v.CorreoElectronico;
            logClaro.CuentaCliente = v.CuentaCliente;
            logClaro.DireccionCorrespondencia = v.DireccionCorrespondencia;
            logClaro.DireccionInstalacion = v.DireccionInstalacion;
            logClaro.FechaGestion = v.FechaGestion;
            logClaro.FechaSeguimiento = v.FechaSeguimiento;
            logClaro.Id = v.Id;
            logClaro.Movil1 = v.Movil1;
            logClaro.Movil2 = v.Movil2;
            logClaro.NombreCliente = v.NombreCliente;
            logClaro.NombreUsuarioGestion = v.NombreUsuarioGestion;
            logClaro.Observaciones = v.Observaciones;
            logClaro.OperacionGestion = v.OperacionGestion;
            logClaro.PaqueteActual = v.PaqueteActual;
            logClaro.Razon = v.Razon;
            logClaro.Seguimiento = v.Seguimiento;
            logClaro.Telefono1 = v.Telefono1;
            logClaro.Telefono2 = v.Telefono2;
            logClaro.Telefono3 = v.Telefono3;
            logClaro.TipoDeContacto = v.TipoDeContacto;
            logClaro.TipoDeGestion = v.TipoDeGestion;
            logClaro.UsuarioGestion = v.UsuarioGestion;
            return logClaro;
        }

        public void ActualizarClaroVideo(UnitOfWork unitWork, ClaroVideo v)
        {
            ClaroVideo logClaro = unitWork.claroVideos.Get(v.Id);
            logClaro.AliadoGestion = v.AliadoGestion;
            logClaro.ApellidoCliente = v.ApellidoCliente;
            logClaro.Attributo1 = v.Attributo1;
            logClaro.Attributo10 = v.Attributo10;
            logClaro.Attributo2 = v.Attributo2;
            logClaro.Attributo3 = v.Attributo3;
            logClaro.Attributo4 = v.Attributo4;
            logClaro.Attributo5 = v.Attributo5;
            logClaro.Attributo6 = v.Attributo6;
            logClaro.Attributo7 = v.Attributo7;
            logClaro.Attributo8 = v.Attributo8;
            logClaro.Attributo9 = v.Attributo9;
            logClaro.Cierre = v.Cierre;
            logClaro.CorreoElectronico = v.CorreoElectronico;
            logClaro.CuentaCliente = v.CuentaCliente;
            logClaro.DireccionCorrespondencia = v.DireccionCorrespondencia;
            logClaro.DireccionInstalacion = v.DireccionInstalacion;
            logClaro.FechaGestion = v.FechaGestion;
            logClaro.FechaSeguimiento = v.FechaSeguimiento;
            logClaro.Id = v.Id;
            logClaro.Movil1 = v.Movil1;
            logClaro.Movil2 = v.Movil2;
            logClaro.NombreCliente = v.NombreCliente;
            logClaro.NombreUsuarioGestion = v.NombreUsuarioGestion;
            logClaro.Observaciones = v.Observaciones;
            logClaro.OperacionGestion = v.OperacionGestion;
            logClaro.PaqueteActual = v.PaqueteActual;
            logClaro.Razon = v.Razon;
            logClaro.Seguimiento = v.Seguimiento;
            logClaro.Telefono1 = v.Telefono1;
            logClaro.Telefono2 = v.Telefono2;
            logClaro.Telefono3 = v.Telefono3;
            logClaro.TipoDeContacto = v.TipoDeContacto;
            logClaro.TipoDeGestion = v.TipoDeGestion;
            logClaro.UsuarioGestion = v.UsuarioGestion;
        
        }




        public CierreCicloCollection GetHistorialCierreCicloAsesor(int idAsesor)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<CierreCiclo> cierreCiclos = unitOfWork.cierreCiclos.Find(c => c.UsuarioGestion.Equals(idAsesor.ToString())).ToList();
            CierreCicloCollection result = new CierreCicloCollection();
            result.AddRange(cierreCiclos);
            return result;
        }

        public List<String> GetNombresClientesCierreCiclo(CierreCicloCollection cuentasATraer)
        {   List<string> resultado = new List<String>();
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            int cuenta;
            foreach (var item in cuentasATraer)
            {
                cuenta = Convert.ToInt32(item.Cuenta);
                var nombreYApellido = unitOfWork.clientesTodo.Find(c => c.Cuenta == cuenta).Select(x => new { x.Nombre, x.Apellido }).FirstOrDefault();
                if (nombreYApellido != null) 
                resultado.Add(nombreYApellido.Nombre + " " + nombreYApellido.Apellido);
                else resultado.Add("");
            }
            return resultado;
        }

        public GestionOutbound GetGestionOutboundPorAsesor(int cuenta, string gestion, string aliado, string linea)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            return unitOfWork.gestionesOutbound.Find(c => c.Cuenta  == cuenta && c.NombreBase.Equals(gestion) && c.Aliado.Equals(aliado) && c.OperacionGestion.Equals(linea)).SingleOrDefault();

        }

        public CierreCiclo GetCierreCicloGestionado(int id)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
           return unitOfWork.cierreCiclos.Get(id);
        }

        public bool ProcesoGuardarCierreCiclo(int idAsesor, ClientesTodo datosCliente, CierreCiclo cierreCicloGestionado)
        {
            UnitOfWorkMaestros unitWorkMaestros = new UnitOfWorkMaestros(new MaestrosContext());
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            var gestionOutboundDeGestion = unitOfWork.gestionesOutbound.Find(c => c.Cuenta == datosCliente.Cuenta && c.NombreBase.Equals("CIERRE_CICLO")).Select(c => new { c.OperacionGestion, c.NombreBase, c.Aliado }).FirstOrDefault();
            GestionOutbound enGestiondeUsuario = new GestionOutbound();
            enGestiondeUsuario = unitOfWork.gestionesOutbound.Find(c => c.UsuarioGestionando == idAsesor && c.NombreBase.Equals("CIERRE_CICLO")).SingleOrDefault();
            cierreCicloGestionado.FechaGestion = DateTime.Now;
            cierreCicloGestionado.UsuarioGestion = idAsesor.ToString();
            cierreCicloGestionado.Cuenta = datosCliente.Cuenta;
            if(gestionOutboundDeGestion!=null)
            {   cierreCicloGestionado.Base = gestionOutboundDeGestion.NombreBase;
                cierreCicloGestionado.OperacionGestion = gestionOutboundDeGestion.OperacionGestion;
            }
            cierreCicloGestionado.TipoContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(cierreCicloGestionado.TipoContacto)).TipoContacto;
            cierreCicloGestionado.Gestion = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(cierreCicloGestionado.Gestion)).Cierre;
            cierreCicloGestionado.Cierre = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(cierreCicloGestionado.Cierre)).Razon;
            cierreCicloGestionado.Razon = unitWorkMaestros.maestrosOutboundCausa.Get(Convert.ToInt32(cierreCicloGestionado.Razon)).Causa;
            cierreCicloGestionado.Motivo = unitWorkMaestros.maestrosOutboundMotivo.Get(Convert.ToInt32(cierreCicloGestionado.Motivo)).Motivo;
            if (cierreCicloGestionado.FechaSeguimiento != null)  cierreCicloGestionado.Seguimiento = "SI";
            if (enGestiondeUsuario != null)
            {
                                enGestiondeUsuario.UsuarioGestionando = 0;
                unitOfWork.cierreCiclos.Add(cierreCicloGestionado);
            }
            else
            {
                CierreCiclo cierreActualizado = ActualizarCierreCiclo(unitOfWork, cierreCicloGestionado);
                cierreCicloGestionado.Id = 0;
            }
            
            unitOfWork.logCierreCiclos.Add((LogCierreCiclo)cierreCicloGestionado);
            unitOfWork.Complete();
            return true;
        }



        public CierreCiclo ActualizarCierreCiclo(UnitOfWork unitWork, CierreCiclo v )
        {
            CierreCiclo actualizado = unitWork.cierreCiclos.Get(v.Id);
            actualizado.AliadoGestion = v.AliadoGestion;
            actualizado.Base = v.Base;
            actualizado.Cierre = v.Cierre;
            actualizado.Cuenta = v.Cuenta;
            actualizado.FechaGestion = v.FechaGestion;
            actualizado.FechaSeguimiento = v.FechaSeguimiento;
            actualizado.Gestion = v.Gestion;
            actualizado.Motivo = v.Motivo;
            actualizado.Obervaciones = v.Obervaciones;
            actualizado.Ofrecimiento1 = v.Ofrecimiento1;
            actualizado.Ofrecimiento2 = v.Ofrecimiento2;
            actualizado.Ofrecimiento3 = v.Ofrecimiento3;
            actualizado.OperacionGestion = v.OperacionGestion;
            actualizado.PServicio1 = v.PServicio1;
            actualizado.PServicio10 = v.PServicio10;
            actualizado.PServicio11 = v.PServicio11;
            actualizado.PServicio12 = v.PServicio12;
            actualizado.PServicio13 = v.PServicio13;
            actualizado.PServicio14 = v.PServicio14;
            actualizado.PServicio15 = v.PServicio15;
            actualizado.PServicio16 = v.PServicio16;
            actualizado.PServicio17 = v.PServicio17;
            actualizado.PServicio18 = v.PServicio18;
            actualizado.PServicio19 = v.PServicio19;
            actualizado.PServicio20 = v.PServicio20;
            actualizado.PServicio21 = v.PServicio21;
            actualizado.PServicio22 = v.PServicio22;
            actualizado.PServicio23 = v.PServicio23;
            actualizado.PServicio24 = v.PServicio24;
            actualizado.PServicio25 = v.PServicio25;
            actualizado.PServicio26 = v.PServicio26;
            actualizado.PServicio27 = v.PServicio27;
            actualizado.PServicio28 = v.PServicio28;
            actualizado.PServicio29 = v.PServicio29;
            actualizado.PServicio3 = v.PServicio3;
            actualizado.PServicio30 = v.PServicio30;
            actualizado.PServicio31 = v.PServicio31;
            actualizado.PServicio32 = v.PServicio32;
            actualizado.PServicio33 = v.PServicio33;
            actualizado.PServicio34 = v.PServicio34;
            actualizado.PServicio35 = v.PServicio35;
            actualizado.PServicio36 = v.PServicio36;
            actualizado.PServicio4 = v.PServicio4;
            actualizado.PServicio5 = v.PServicio5;
            actualizado.PServicio6 = v.PServicio6;
            actualizado.PServicio7 = v.PServicio7;
            actualizado.PServicio8 = v.PServicio8;
            actualizado.PServicio9 = v.PServicio9;
            actualizado.Razon = v.Razon;
            actualizado.Seguimiento = v.Seguimiento;
            actualizado.TipoContacto = v.TipoContacto;
            actualizado.UsuarioGestion = v.UsuarioGestion;
            return actualizado;
        }

        public SkillsUsuariosBlendingCollection ListaUsuariosAdminBlending(string Operacion)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            List<SkillsUsuariosBlending> listaUsers = unitOfWork.SkillsUsuariosBlending.Find(a =>a.Operacion == Operacion).ToList();
            SkillsUsuariosBlendingCollection result = new SkillsUsuariosBlendingCollection();
            result.AddRange(listaUsers);
            return result;
        }
        public SkillsUsuariosBlending ConsultaUsuarioenAdminBlending(string cedula)
        {
            int Cedula = Convert.ToInt32(cedula);
            DimeContext dimeContext = new DimeContext();
            return dimeContext.SkillsUsuariosBlending.Where(a => a.Cedula == Cedula).FirstOrDefault();
        }
        public List<GestionOutbound> ObtenerCampaña(string Aliado)
        {
            DimeContext dimContext = new DimeContext();
            List<GestionOutbound> result = new List<GestionOutbound>();
            var objetosResult = (from a in dimContext.GestionOutbounds
                                 where a.Aliado == Aliado
                                 select new
                                 {a.Campaña}).Distinct().ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new GestionOutbound());
                result[i].Campaña = objetosResult[i].Campaña;
                
            }
            
            return result;
        }
        public void InsertarSkillsUsuarioBlending(SkillsUsuariosBlending skills)
        {
            try
            {
                skills.Fecha_Actualizacion = DateTime.Now;

                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.SkillsUsuariosBlending.Add(skills);
                unitWork.Complete();
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
        public List<GestionOutbound> CountCuentasOperacionGestion(string operacion, string aliado)
        {
            //int Cedula = Convert.ToInt32(cedula);
            DimeContext dimeContext = new DimeContext();
            return dimeContext.GestionOutbounds.Where(a => a.OperacionGestion.Equals(operacion) &&a.Aliado==aliado && a.UsuarioGestionando == null).ToList();
        }
        public List<GestionOutbound> CountCuentasOperacionCampaña(string operacion, string campaña, string aliado)
        {
            //int Cedula = Convert.ToInt32(cedula);
            DimeContext dimeContext = new DimeContext();
            return dimeContext.GestionOutbounds.Where(a => a.OperacionGestion.Equals(operacion) && a.Campaña==campaña && a.Aliado == aliado && a.UsuarioGestionando == null).ToList();
        }
    }
}
