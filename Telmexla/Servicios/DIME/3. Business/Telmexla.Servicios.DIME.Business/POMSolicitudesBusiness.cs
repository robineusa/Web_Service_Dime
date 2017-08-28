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
        public void RegistrarSolicitudPom(POMSolicitudes Solicitud)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            DateTime Fecha = DateTime.Now;
            Solicitud.FechaTransaccion = Fecha;
            Solicitud.CanalTransaccion = "CAV";
            unitWork.POMSolicitudes.Add(Solicitud);
            unitWork.Complete();
            unitWork.Dispose();
        }
        public bool ValidarCuentaEnBaseSolicitudesPom(decimal CuentaCliente)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            var resultado = unitWork.POMSolicitudes.Find(c => c.CuentaCliente == CuentaCliente).ToList();

            if (resultado.Count() > 0) { return true; }
            else { return false; }
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
                                     a.TokenId
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
            }
            return result;

        }
    }
}
