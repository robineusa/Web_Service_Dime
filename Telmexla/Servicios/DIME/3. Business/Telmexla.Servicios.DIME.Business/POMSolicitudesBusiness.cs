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
    public class POMSolicitudesBusiness
    {
        public POMSolicitudes RegistrarSolicitudPom(POMSolicitudes Solicitud)
        {
            Solicitud.IdEncuesta = 1;
            Solicitud.MinOrigen = 0;
            Solicitud.EnviaSoloEmail = "X";
            Solicitud.EnviaReintento = 1;
            Solicitud.FechaEnvioEncuesta = Solicitud.FechaTransaccion;

            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            unitWork.POMSolicitudes.Add(Solicitud);
            unitWork.Complete();
            unitWork.Dispose();
            return Solicitud;
        }
        public bool ValidarCuentaEnBaseSolicitudesPom(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.POMSolicitudes.Find(c => c.CuentaCliente == CuentaCliente).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
        }
        public void EliminarEncuestaDime(POMSolicitudes Encuesta)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            POMSolicitudes EncuestaEncontrada = unitWork.POMSolicitudes.Find(x => x.IdTansaccion == Encuesta.IdTansaccion).FirstOrDefault();
            if (EncuestaEncontrada != null)
            {
                unitWork.POMSolicitudes.Remove(EncuestaEncontrada);
                unitWork.Complete();
                unitWork.Dispose();
            }else { }
        }
        public List<POMSolicitudes> ListaSolicitudesPom(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<POMSolicitudes> result = new List<POMSolicitudes>();
            var objetosResult = (from a in dimContext.POMSolicitudes
                                 where a.FechaTransaccion >= FechaInicial && a.FechaTransaccion <= FechaFinal
                                 orderby a.IdTansaccion ascending
                                 select new
                                 {
                                     a.IdTansaccion,
                                     a.FechaTransaccion,
                                     a.UsuarioTransaccion,
                                     a.CanalTransaccion,
                                     a.ZonaTransaccion,
                                     a.TelefonoCeluar,
                                     a.TelefonoDeContacto,
                                     a.CorreoElectronico,
                                     a.CuentaCliente,
                                     a.Operacion,
                                     a.TokenId,
                                     a.SubCanal,
                                     a.FechaEnvioEncuesta,
                                     a.MinOrigen,
                                     a.EnviaReintento,
                                     a.EnviaSoloEmail,
                                     a.IdEncuesta
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new POMSolicitudes());
                result[i].IdTansaccion = objetosResult[i].IdTansaccion;
                result[i].FechaTransaccion = objetosResult[i].FechaTransaccion;
                result[i].UsuarioTransaccion = objetosResult[i].UsuarioTransaccion;
                result[i].CanalTransaccion = objetosResult[i].CanalTransaccion;
                result[i].ZonaTransaccion = objetosResult[i].ZonaTransaccion;
                result[i].TelefonoCeluar = objetosResult[i].TelefonoCeluar;
                result[i].TelefonoDeContacto = objetosResult[i].TelefonoDeContacto;
                result[i].CorreoElectronico = objetosResult[i].CorreoElectronico;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].Operacion = objetosResult[i].Operacion;
                result[i].TokenId = objetosResult[i].TokenId;
                result[i].SubCanal = objetosResult[i].SubCanal;
                result[i].FechaEnvioEncuesta = objetosResult[i].FechaEnvioEncuesta;
                result[i].MinOrigen = objetosResult[i].MinOrigen;
                result[i].EnviaReintento = objetosResult[i].EnviaReintento;
                result[i].EnviaSoloEmail = objetosResult[i].EnviaSoloEmail;
                result[i].IdEncuesta = objetosResult[i].IdEncuesta;
            }
            return result;

        }
    }
}
