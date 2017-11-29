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
    public class BannerAlertasBusiness
    {
        public bool ValidarClienteEnConvenioElectronico(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.clientesTodo.Find(c => c.Cuenta == CuentaCliente && c.Convenio.Equals("SI")).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public bool ValidarClienteEnClaroVideo(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.clientesTodo.Find(c => c.Cuenta == CuentaCliente && c.Clarovideo.Equals("SI")).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public bool ValidarClienteEnMejorOferta(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.CuentaSMO.Find(c => c.CuentaCliente == CuentaCliente).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public bool ValidarClienteEnSiembraHD(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.CuentasSiembraHD.Find(c => c.CuentaCliente == CuentaCliente).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public bool ValidarClienteEnMejorasTecnicas(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.CuentasMejorasTecnicas.Find(c => c.Cuenta == CuentaCliente).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public bool ValidarClienteEnFox(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.CargaBaseFoxInbound.Find(c => c.Cuenta == CuentaCliente).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public CuentasSiguienteMejorOferta ConsultarClienteMejorOferta(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            CuentasSiguienteMejorOferta SMO = unitWork.CuentaSMO.Find(x => x.CuentaCliente == CuentaCliente).FirstOrDefault(); ;
            return SMO;
        }
        public void RegistrarSMO(SiguienteMejorOferta smo)
        {
            try
            {
                smo.FechaGestion = DateTime.Now;

                //actualiza informacion de los maestros
                UnitOfWorkMaestros unitWorkMaestros = new UnitOfWorkMaestros(new MaestrosContext());

                smo.TipoContacto = unitWorkMaestros.maestrosOutboundTipoContactos.Get(Convert.ToInt32(smo.TipoContacto)).TipoContacto;
                smo.Gestion = unitWorkMaestros.maestrosOutboundCierres.Get(Convert.ToInt32(smo.Gestion)).Cierre;
                smo.Cierre = unitWorkMaestros.maestrosOutboundRazon.Get(Convert.ToInt32(smo.Cierre)).Razon;
                smo.Razon = unitWorkMaestros.maestrosOutboundCausa.Get(Convert.ToInt32(smo.Razon)).Causa;

                unitWorkMaestros.Complete();
                unitWorkMaestros.Dispose();


                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.SMO.Add(smo);
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
        public void RegistrarClaroVideo(ActivacionClaroVideo ClaroVideo)
        {
            try
            {
                ClaroVideo.FechaGestion = DateTime.Now;

                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.activacionClaroVideo.Add(ClaroVideo);
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
        public CuentasSiembraHD ConsultarCuentaSiembraHD(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            CuentasSiembraHD SiembraHD = unitWork.CuentasSiembraHD.Find(x => x.CuentaCliente == CuentaCliente).FirstOrDefault(); ;
            return SiembraHD;
        }
        public void RegistrarSiembraHD(SiembraHD siembra)
        {
            try
            {
                siembra.FechaGestion = DateTime.Now;

                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.ActivacionSiembraHD.Add(siembra);
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
        public CuentasMejorasTecnicas ConsultarCuentaMejorasTecnicas(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            CuentasMejorasTecnicas MejoraTecnica = unitWork.CuentasMejorasTecnicas.Find(x => x.Cuenta == CuentaCliente).FirstOrDefault(); ;
            return MejoraTecnica;
        }
        public void RegistrarMejorasTecnicas(MejorasTecnicas Mejoras)
        {
            try
            {
                Mejoras.FechaGestion = DateTime.Now;

                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.MejorasTecnicas.Add(Mejoras);
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
        public CargaBaseFoxInbound ConsultaCuentaBaseFox(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            CargaBaseFoxInbound CuentasFox = unitWork.CargaBaseFoxInbound.Find(x => x.Cuenta == CuentaCliente).FirstOrDefault(); ;
            return CuentasFox;
        }
        public void RegistraFox(GestionFoxInbound Fox)
        {
            try
            {
                Fox.FechaGestion = DateTime.Now;

                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.GestionFoxInbound.Add(Fox);
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
        public void RegistraUsabilidadBanner(UsabilidadAlertasInbound Usabilidad)
        {
            try
            {
                Usabilidad.FechaRevision = DateTime.Now;

                UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                unitWork.UsabilidadAlertasInbound.Add(Usabilidad);
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
        //actualizacion de datos
        public bool ValidarClienteEnActualizaciondeDatos(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.BACActualizarDatos.Find(c => c.CuentaAsociada == CuentaCliente).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public List<BACActualizarDatos> ListaClientesPorTelefono(decimal Telefono)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            List<BACActualizarDatos> Lista = new List<BACActualizarDatos>();
            Lista = unitWork.BACActualizarDatos.Find(x => x.Telefono == Telefono).ToList();
            return Lista;
        }
        public void RegistrarActualizaciondeDatos(List<string> IdAsociadosSi, BAPActualizarDatos Datos)
        {
            Datos.FechaGestion = DateTime.Now;
            decimal Telefono = ConsultarTelefonoPorCuenta(Datos.CuentaAsociada);

            //agrega los id con select si
            DimeContext context = new DimeContext();
            List<decimal> IdDatos = IdAsociadosSi.ConvertAll(s => Convert.ToDecimal(s));
            foreach (decimal ID in IdDatos)
            {


                UnitOfWork UnitOfWorkSolicitdActualizable = new UnitOfWork(new DimeContext());
                BACActualizarDatos SolicitudActualizable = new BACActualizarDatos();
                SolicitudActualizable = UnitOfWorkSolicitdActualizable.BACActualizarDatos.Find(c => c.Id == ID).FirstOrDefault();

                if (SolicitudActualizable != null)
                {
                    //IGUALA Y CREA LA ENTIDAD PARA GUARDAD
                    BAPActualizarDatos Nueva = new BAPActualizarDatos();
                    Nueva.FechaGestion = Datos.FechaGestion;
                    Nueva.UsuarioGestion = Datos.UsuarioGestion;
                    Nueva.AliadoGestion = Datos.AliadoGestion;
                    Nueva.OperacionGestion = Datos.OperacionGestion;
                    Nueva.Telefono = SolicitudActualizable.Telefono;
                    Nueva.CuentaAsociada = SolicitudActualizable.CuentaAsociada;
                    Nueva.Direccion = SolicitudActualizable.Direccion;
                    Nueva.Ciudad = SolicitudActualizable.Ciudad;
                    Nueva.PropiedadCliente = "SI";
                    
                    //GUARDA LOS DATOS
                    UnitOfWork UnitOfWordGuardar = new UnitOfWork(new DimeContext());
                    UnitOfWordGuardar.BAPActualizarDatos.Add(Nueva);
                    UnitOfWordGuardar.Complete();
                    UnitOfWordGuardar.Dispose();

                    //ELIMINA LOS DATOS ANTERIORES
                    UnitOfWork UnitOfWordEliminar = new UnitOfWork(new DimeContext());
                    BACActualizarDatos RegistroParaEliminar = UnitOfWordEliminar.BACActualizarDatos.Find(x => x.Id == SolicitudActualizable.Id).FirstOrDefault();
                    if (RegistroParaEliminar != null)
                    {
                        UnitOfWordEliminar.BACActualizarDatos.Remove(RegistroParaEliminar);
                        UnitOfWordEliminar.Complete();
                        UnitOfWordEliminar.Dispose();
                    }
                }
            }
           
            List<decimal> ListaNo = ListaClientesPorTelefono(Telefono).Select(x=> x.Id).ToList();

            //inserta id con select no
            DimeContext context2 = new DimeContext();
            foreach (decimal Id in ListaNo)
            {
                UnitOfWork UnitOfWorkSolicitdActualizable2 = new UnitOfWork(new DimeContext());
                BACActualizarDatos SolicitudActualizable2 = new BACActualizarDatos();
                SolicitudActualizable2 = UnitOfWorkSolicitdActualizable2.BACActualizarDatos.Find(c => c.Id == Id).FirstOrDefault();

                if (SolicitudActualizable2 != null)
                {
                    //IGUALA LA ENTIDAD Y CREA ESTRUCTURA PARA GUARDAR
                    BAPActualizarDatos Nueva2 = new BAPActualizarDatos();
                    Nueva2.FechaGestion = Datos.FechaGestion;
                    Nueva2.UsuarioGestion = Datos.UsuarioGestion;
                    Nueva2.AliadoGestion = Datos.AliadoGestion;
                    Nueva2.OperacionGestion = Datos.OperacionGestion;
                    Nueva2.Telefono = SolicitudActualizable2.Telefono;
                    Nueva2.CuentaAsociada = SolicitudActualizable2.CuentaAsociada;
                    Nueva2.Direccion = SolicitudActualizable2.Direccion;
                    Nueva2.Ciudad = SolicitudActualizable2.Ciudad;
                    Nueva2.PropiedadCliente = "NO";

                    //GUARDA LA INFORMACION
                    UnitOfWork UnitOfWordGuardar2 = new UnitOfWork(new DimeContext());
                    UnitOfWordGuardar2.BAPActualizarDatos.Add(Nueva2);
                    UnitOfWordGuardar2.Complete();
                    UnitOfWordGuardar2.Dispose();

                    //ELIMINA DATOS ANTERIORES
                    UnitOfWork UnitOfWordEliminar2 = new UnitOfWork(new DimeContext());
                    BACActualizarDatos RegistroParaEliminar2 = UnitOfWordEliminar2.BACActualizarDatos.Find(x => x.Id == SolicitudActualizable2.Id).FirstOrDefault();
                    if (RegistroParaEliminar2 != null)
                    {
                        UnitOfWordEliminar2.BACActualizarDatos.Remove(RegistroParaEliminar2);
                        UnitOfWordEliminar2.Complete();
                        UnitOfWordEliminar2.Dispose();
                    }
                }
            }

        }
        public decimal ConsultarTelefonoPorCuenta(decimal CuentaCliente)
        {
            UnitOfWork UnitOfWork = new UnitOfWork(new DimeContext());
           BACActualizarDatos result = new BACActualizarDatos();
            result.Telefono = UnitOfWork.BACActualizarDatos.Find(x => x.CuentaAsociada == CuentaCliente).Select(x=> x.Telefono).FirstOrDefault();
            return result.Telefono;
        }
    }
}
