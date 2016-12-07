using System;
using System.Collections.Generic;
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
            unitOfWork.conveniosElectronicos.Add(convElectGestionado);
            //Sig linea actualiza gestiones outbound que usuario esta gestionando para liberar
            GestionOutbound enGestiondeUsuario = new GestionOutbound();
            enGestiondeUsuario = unitOfWork.gestionesOutbound.Find(c => c.UsuarioGestionando == idAsesor).SingleOrDefault();
            if (enGestiondeUsuario != null)
                enGestiondeUsuario.UsuarioGestionando = 0;
            unitOfWork.Complete();
            return true;
        }

        public ConvenioElectronico GetConvenioElectronicoPorId(int idGestionado)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
           return  unitOfWork.conveniosElectronicos.Get(idGestionado);
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
            docsisGestionado.OperacionGestion = gestionOutboundDeGestion.OperacionGestion;
            docsisGestionado.NombreBase = gestionOutboundDeGestion.NombreBase;
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
            docsisGestionado.NombreUsuarioGestion = unitOfWork.usuarios.Find(c => c.Id == idAsesor).Select(c => c.Nombre).SingleOrDefault();
            docsisGestionado.Aliado = gestionOutboundDeGestion.Aliado;
            if (docsisGestionado.FechaSeguimiento != null)
            {
                docsisGestionado.Seguimiento = "SI";
            }
            unitOfWork.docsisOverlaps.Add(docsisGestionado);
            //Sig linea actualiza gestiones outbound que usuario esta gestionando para liberar
            GestionOutbound enGestiondeUsuario = new GestionOutbound();
            enGestiondeUsuario = unitOfWork.gestionesOutbound.Find(c => c.UsuarioGestionando == idAsesor).SingleOrDefault();
            if (enGestiondeUsuario != null)
                enGestiondeUsuario.UsuarioGestionando = 0;
            unitOfWork.Complete();
            return true;

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
            claroVideoGestionado.OperacionGestion = gestionOutboundDeGestion.OperacionGestion;
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
            unitOfWork.claroVideos.Add(claroVideoGestionado);
            //Sig linea actualiza gestiones outbound que usuario esta gestionando para liberar
            GestionOutbound enGestiondeUsuario  = new GestionOutbound();
            enGestiondeUsuario = unitOfWork.gestionesOutbound.Find(c => c.UsuarioGestionando == idAsesor).SingleOrDefault();
            if (enGestiondeUsuario!= null)
                enGestiondeUsuario.UsuarioGestionando = 0;
            unitOfWork.Complete();
            return true;

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

        public GestionOutbound GetGestionOutboundPorAsesor(int cuenta, string gestion)
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            return unitOfWork.gestionesOutbound.Find(c => c.Cuenta  == cuenta && c.NombreBase.Equals(gestion)).SingleOrDefault();

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

            cierreCicloGestionado.FechaGestion = DateTime.Now;
            cierreCicloGestionado.UsuarioGestion = idAsesor.ToString();
            cierreCicloGestionado.Cuenta = datosCliente.Cuenta;
            cierreCicloGestionado.Base = gestionOutboundDeGestion.NombreBase;
            cierreCicloGestionado.OperacionGestion = gestionOutboundDeGestion.OperacionGestion;
            cierreCicloGestionado.TipoContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(cierreCicloGestionado.TipoContacto)).TipoContacto;
            cierreCicloGestionado.Gestion = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(cierreCicloGestionado.Gestion)).Cierre;
            cierreCicloGestionado.Cierre = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(cierreCicloGestionado.Cierre)).Razon;
            cierreCicloGestionado.Razon = unitWorkMaestros.maestrosOutboundCausa.Get(Convert.ToInt32(cierreCicloGestionado.Razon)).Causa;
            cierreCicloGestionado.Motivo = unitWorkMaestros.maestrosOutboundMotivo.Get(Convert.ToInt32(cierreCicloGestionado.Motivo)).Motivo;
            if (cierreCicloGestionado.FechaSeguimiento != null)
            {
                cierreCicloGestionado.Seguimiento = "SI";
            }
            unitOfWork.cierreCiclos.Add(cierreCicloGestionado);
            //Sig linea actualiza gestiones outbound que usuario esta gestionando para liberar
            GestionOutbound enGestiondeUsuario = new GestionOutbound();
            enGestiondeUsuario = unitOfWork.gestionesOutbound.Find(c => c.UsuarioGestionando == idAsesor).SingleOrDefault();
            if (enGestiondeUsuario != null)
                enGestiondeUsuario.UsuarioGestionando = 0;
            unitOfWork.Complete();
            return true;

        }

    }
}
