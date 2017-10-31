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
    public class VisitasAutorizadasBusiness
    {
        public void AgregarNuevaVisita(VisitasAutorizadas Visita)
        {
            UnitOfWork unitOfWorkDesplegable = new UnitOfWork(new DimeContext());
            decimal Id = Convert.ToDecimal(Visita.Motivo);
            VAMotivosSolicitud MotivoTexto = unitOfWorkDesplegable.VAMotivosSolicitud.Find(x => x.IdMotivo == Id).FirstOrDefault();
            unitOfWorkDesplegable.Complete();
            unitOfWorkDesplegable.Dispose();

            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            DateTime FechaSistema = DateTime.Now;
            Visita.FechaRegistro = FechaSistema;
            Visita.Motivo = MotivoTexto.Motivo;
            unitOfWork.VisitasAutorizadas.Add(Visita);
            unitOfWork.Complete();
            unitOfWork.Dispose();

        }
        public List<VisitasAutorizadas> ConsultaBaseVisitasAutorizadas(DateTime FechaInicial, DateTime FechaFinal)
        {
            DimeContext dimContext = new DimeContext();
            List<VisitasAutorizadas> result = new List<VisitasAutorizadas>();
            var objetosResult = (from a in dimContext.VisitasAutorizadas
                                 //join b in (from m in dimContext.BasePersonalHoloes select new { m.Cedula, m.Nombre,m.UsuarioRr }).Distinct() on a.CedulaUsuarioGestion equals b.Cedula
                                 where a.FechaRegistro >= FechaInicial && a.FechaRegistro<= FechaFinal
                                 orderby a.IdVisita ascending
                                 select new
                                 {
                                     a.IdVisita,
                                     a.FechaRegistro,
                                     a.UsuarioRegistro,
                                     a.AliadoRegistro,
                                     a.OperacionRegistro,
                                     a.CuentaCliente,
                                     a.LlamadaServicio,
                                     a.Aviso,
                                     a.Motivo,
                                     a.CedulaUsuarioGestion
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new VisitasAutorizadas());
                result[i].IdVisita = objetosResult[i].IdVisita;
                result[i].FechaRegistro = objetosResult[i].FechaRegistro;
                result[i].UsuarioRegistro = objetosResult[i].UsuarioRegistro;
                result[i].AliadoRegistro = objetosResult[i].AliadoRegistro;
                result[i].OperacionRegistro = objetosResult[i].OperacionRegistro;
                result[i].CuentaCliente = objetosResult[i].CuentaCliente;
                result[i].LlamadaServicio = objetosResult[i].LlamadaServicio;
                result[i].Aviso = objetosResult[i].Aviso; 
                result[i].Motivo = objetosResult[i].Motivo;
                result[i].CedulaUsuarioGestion = objetosResult[i].CedulaUsuarioGestion;
                
            }
            return result;
        }
        public List<VAMotivosSolicitud> ListaMotivosSolicitud()
        {
            DimeContext dimContext = new DimeContext();
            List<VAMotivosSolicitud> result = new List<VAMotivosSolicitud>();
            var objetosResult = (from a in dimContext.VAMotivosSolicitud
                                 where a.Estado.Equals("ACTIVO")
                                 orderby a.Motivo ascending
                                 select new
                                 {
                                     a.IdMotivo,
                                     a.Motivo
                                 }
                                 ).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new VAMotivosSolicitud());
                result[i].IdMotivo = objetosResult[i].IdMotivo;
                result[i].Motivo = objetosResult[i].Motivo;
            }
            return result;
        }
    }
}
