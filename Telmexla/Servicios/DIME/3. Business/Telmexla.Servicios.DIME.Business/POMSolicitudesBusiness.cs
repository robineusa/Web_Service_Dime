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
        public void RegistrarSolicitud(POMSolicitudes Solicitud)
        {
            UnitOfWork unitWork = new UnitOfWork(new DimeContext());
            DateTime Fecha = DateTime.Now;
            Solicitud.FechaSolicitud = Fecha;
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
                                 where a.FechaSolicitud >= FechaInicial && a.FechaSolicitud <= FechaFinal
                                 orderby a.IdRegistro ascending
                                 select new
                                 {
                                     a.IdRegistro,
                                     a.FechaSolicitud,
                                     a.UsuarioSolicitud,
                                     a.CuentaCliente,
                                     a.TelefonoCeluar,
                                     a.CorreoElectronico,
                                     a.MovilClaro
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new POMSolicitudes());
                result[i].IdRegistro = objetosResult[i].IdRegistro;
                result[i].FechaSolicitud = objetosResult[i].FechaSolicitud;
                result[i].UsuarioSolicitud = objetosResult[i].UsuarioSolicitud;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].TelefonoCeluar = objetosResult[i].TelefonoCeluar;
                result[i].CorreoElectronico = objetosResult[i].CorreoElectronico;
                result[i].MovilClaro = objetosResult[i].MovilClaro;
            }
            return result;

        }
    }
}
