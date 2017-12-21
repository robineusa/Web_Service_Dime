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
    public class SignalRBusiness
    {
        public decimal InsertarNotificacionSignalR(NotificacionSignalR model)
        {
            var Id = 0;
            try
            {
                model.FechaEntrega = DateTime.Now;

                //UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                //unitWork.NotificacionSignalR.Add(model);
                //unitWork. ;
                DimeContext context = new DimeContext();
                context.NotificacionSignalR.Add(model);
                context.SaveChanges();
                context.Dispose();
                Id = Convert.ToInt32(model.Id);
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
            return Id;
        }
        public List<NotificacionSignalR> ListaNoNotificados(decimal Usuario)
        {
            DimeContext dimContext = new DimeContext();
            List<NotificacionSignalR> resultado = new List<NotificacionSignalR>();

            List<NotificacionSignalR> Object = (from a in dimContext.NotificacionSignalR
                                                select a).ToList();

            List<UsuariosNotificadosSignalR> object2 = (from a in dimContext.UsuariosNotificadosSignalR
                                                        where a.UsuarioNotificado == Usuario
                                                        select a).ToList();
            //resultado = Object;
            NotificacionSignalR p;
            for (int i = 0; i < Object.Count; i++)
            {
                p = new NotificacionSignalR();
                p.Id = Object[i].Id;
                p.TipoNotificacion = Object[i].TipoNotificacion;
                p.ContenidoAlerta = Object[i].ContenidoAlerta;
                p.UsuarioNotifica = Object[i].UsuarioNotifica;
                p.FechaEntrega = Object[i].FechaEntrega;
                p.NombreUsuarioNotifica = Object[i].NombreUsuarioNotifica;
                resultado.Add(p);
            }
            int contador = resultado.Count;
            List<NotificacionSignalR> retorn = new List<NotificacionSignalR>();
            for (int i = 0; i < contador; i++)
            {
                if (!object2.Any(a => a.IdNotificacion == resultado[i].Id))
                    retorn.Add(resultado[i]);
            }
            return retorn;
        }
        public void InsertarUsuarioNotificadoSignalR(List<string> ListaNotificaciones, UsuariosNotificadosSignalR model)
        {
            foreach (var item in ListaNotificaciones)
            {
                try
                {
                    UnitOfWork unitWork = new UnitOfWork(new DimeContext());
                    model.FechaRevisado = DateTime.Now;
                    model.IdNotificacion = Convert.ToDecimal(item);
                    unitWork.UsuariosNotificadosSignalR.Add(model);
                    unitWork.Complete();
                    unitWork.Dispose();
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
        public List<NotificacionSignalR> ListTodosMensajes()
        {
            DimeContext dimContext = new DimeContext();

            var objeto = (from a in dimContext.NotificacionSignalR.Cast<NotificacionSignalR>().ToList()
                          where a.TipoNotificacion == "Mensaje Global Buen Servicio"
                          select new NotificacionSignalR()
                          {
                              Id = a.Id,
                              TipoNotificacion = a.TipoNotificacion,
                              ContenidoAlerta = a.ContenidoAlerta,
                              UsuarioNotifica = a.UsuarioNotifica,
                              FechaEntrega = a.FechaEntrega,
                              NombreUsuarioNotifica = a.NombreUsuarioNotifica
            }).ToList();
            return objeto;
        }
    }
}
