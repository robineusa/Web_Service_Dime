﻿using System;
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
    }
}
