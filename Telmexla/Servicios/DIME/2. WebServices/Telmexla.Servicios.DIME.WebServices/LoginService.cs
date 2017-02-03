using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.Helpers.Encription;
using Telmexla.Servicios.DIME.IWebServices;
using Telmexla.Servicios.DIME.Helpers.ExtenMethods;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Telmexla.Servicios.DIME.WebServices
{

    public enum IDS_MODOS_ACCESOS
    {
        IngresoAdministrador = (int)41,
        IngresoAsesor = (int)42,
        IngresoCelula = (int)43,

    }

    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "LoginService" en el código y en el archivo de configuración a la vez.
    [DataContract]
    public class LoginService : ILoginService
    {

        public int AutenticarUsuarioEnSesion(Usuario usuario)
        {
            
            usuario.Contrasena = new GeneralEncriptor().GetEncriptedData(usuario.Contrasena);
            DimeContext context = new DimeContext();
            var userLastDate = context.UsuariosXAccesoes.OrderByDescending(x => x.FechaCreacion).Where(c => c.IdUsuario == usuario.Id).Select(x => new { x.FechaCreacion }).FirstOrDefault();
            var userLastTime = context.UsuariosXAccesoes.OrderByDescending(x => x.HoraCreacion).Where(c => c.IdUsuario == usuario.Id && c.FechaCreacion==userLastDate.FechaCreacion).Select(x => new { x.HoraCreacion }).FirstOrDefault();
            if (usuario.Id != 0 && usuario.Contrasena.Equals(context.Usuarios.Single(c => c.Cedula == usuario.Cedula).Contrasena)
              && context.UsuariosXAccesoes.Any(c => c.IdUsuario == usuario.Id && c.FechaCreacion == userLastDate.FechaCreacion && c.HoraCreacion == userLastTime.HoraCreacion && (c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoAdministrador || c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoAsesor
                 || c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoCelula)))
                {
                return context.UsuariosXAccesoes.Single(c => c.IdUsuario == usuario.Id && c.FechaCreacion == userLastDate.FechaCreacion && c.HoraCreacion == userLastTime.HoraCreacion && (c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoAdministrador || c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoAsesor
                 || c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoCelula)).IdAcceso;
                }
            else
            { if (!context.UsuariosXAccesoes.Any(c => c.IdUsuario == usuario.Id && c.FechaCreacion == userLastDate.FechaCreacion && c.HoraCreacion == userLastTime.HoraCreacion && (c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoAdministrador || c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoAsesor
                 || c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoCelula)))
                {
                    return -1;
                }
                return 0;
            }

             
        }


        public bool PreguntasDesbloqueoCompletas(int id)
        {   DimeContext context = new DimeContext();
            if(context.UsuariosXPreguntasDesbs.Where(c=>c.IdUsuario==id).Count()==5)
            {
                return true;
            }
            else { return false; }
        }

        public bool DatosUsuarioCompleto(int id)
        { DimeContext context = new DimeContext();
            Usuario usuario = context.Usuarios.Where(c=>c.Id==id).Single();
            if(usuario.Correo == null || usuario.FechaNacimiento == null || usuario.Genero == null || usuario.Telefono == null)
            {
                return false;
            }
            else { return true; }
        }


        public bool ContraseñaCaducada(int id)
        {
            DimeContext context = new DimeContext();
            var usuario = context.Usuarios.Where(c => c.Id == id).Select(x => new { x.FechaContrasena }).FirstOrDefault();
            DateTime datePasswordPut = usuario.FechaContrasena ?? (DateTime)usuario.FechaContrasena;
            if ( (((int)(DateTime.Now-datePasswordPut).TotalDays) > 30) || usuario.FechaContrasena== null   )
                return true;

            return false;
        }



        public bool Capacitado(int id)
        {
            DimeContext context = new DimeContext();
            var usuario = context.Usuarios.Where(c => c.Id == id).Select(x => new { x.Capacitado }).FirstOrDefault();
            return (bool)usuario.Capacitado;
        }


        public bool CapacitarUsuario(int id)
        {
            DimeContext context = new DimeContext();
            Usuario usuario = new Usuario
            {
                Id = id,
                Capacitado = true
            };
            context.Usuarios.Attach(usuario);
            var entry = context.Entry(usuario);
            entry.Property(e => e.Capacitado).IsModified = true;
            context.SaveChanges();
            return true;
        }

        public int RecibirIdUsuario(decimal? cedula)
        {
            DimeContext context = new DimeContext();
            var result = context.Usuarios.SingleOrDefault(c=>c.Cedula== cedula);
            if (result != null)
            {
                return result.Id;
            }
            else return 0;
        }

        public List<PreguntasDesbloqueo> ObtenerPosiblesPreguntas()
        {
            return new DimeContext().PreguntasDesbloqueos.ToList();
        }

        public Usuario RecibirUsuario()
        {
            DimeContext context = new DimeContext();
            return context.Usuarios.First();
        }


        public bool RegistrarActualizarPreguntas(List<PreguntasDesbloqueo> preguntas, List<String> respuestas, Usuario usuario, int noPreguntas)
        {
            DimeContext context = new DimeContext();
            var contentList = context.UsuariosXPreguntasDesbs.Where(o => o.IdUsuario == usuario.Id);
            context.UsuariosXPreguntasDesbs.RemoveRange(contentList);
            for(int i = 0; i<noPreguntas; i ++)
               {
                if (i< preguntas.Count() && i < respuestas.Count() )
                    { 
                     UsuariosXPreguntasDesb item = new UsuariosXPreguntasDesb();
                      item.IdPregunta = preguntas[i].Id;
                     item.IdUsuario = usuario.Id;
                     item.Respuesta = new GeneralEncriptor().GetEncriptedData(respuestas[i].ToUpperNoSpecialChars());
                     context.UsuariosXPreguntasDesbs.Add(item);
                     }
                       else return false;
               }
            context.SaveChanges();
            return true;
        }

        public bool RegistrarActualizarDatosUsuario(Usuario usuario)
        {
            DimeContext context = new DimeContext();
            context.Usuarios.Attach(usuario);
            var entry = context.Entry(usuario);
            entry.Property(e => e.Genero).IsModified = true;
            entry.Property(e => e.Correo).IsModified = true;
            entry.Property(e => e.FechaNacimiento).IsModified = true;
            entry.Property(e => e.Telefono).IsModified = true;
            context.SaveChanges();
            return true;
        }

        public bool BloquearUsuario(int id, int idUsuarioCambioo, string ipPrivadaCreacion, string ipPublicaCreacion)
        { DimeContext context = new DimeContext();
            var userLastDate = context.UsuariosXAccesoes.OrderByDescending(x => x.FechaCreacion).Where(c => c.IdUsuario == id).Select(x=> new {x.FechaCreacion }).FirstOrDefault();
            var userLastTime = context.UsuariosXAccesoes.OrderByDescending(x => x.HoraCreacion).Where(c => c.IdUsuario == id).Select(x => new { x.HoraCreacion }).FirstOrDefault();
            var permisosUsuario = context.UsuariosXAccesoes.Where(c => c.IdUsuario == id &&  c.FechaCreacion == userLastDate.FechaCreacion && c.HoraCreacion== userLastTime.HoraCreacion);
            var permisosQuitar = permisosUsuario.Where(c => (c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoAdministrador || c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoAsesor
                  || c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoCelula) );
            if(permisosQuitar.Any())
            {
                permisosUsuario=  permisosUsuario.Except(permisosQuitar);
                var permisosUsuarioList = permisosUsuario.ToList();
            for(int i=0; i < permisosUsuarioList.Count(); i++)
                {
                    permisosUsuarioList.ElementAt(i).IdUserCambioo = idUsuarioCambioo;
                    permisosUsuarioList.ElementAt(i).FechaCreacion = DateTime.Now;
                    permisosUsuarioList.ElementAt(i).HoraCreacion = DateTime.Now.TimeOfDay;
                    permisosUsuarioList.ElementAt(i).IpPrivadaCreacion = ipPrivadaCreacion;
                    permisosUsuarioList.ElementAt(i).IpPublicaCreacion = ipPublicaCreacion;
                }

            context.UsuariosXAccesoes.AddRange(permisosUsuarioList);
            context.SaveChanges();
            return true;
            }else
            {
                return false;
            }
        }

        public List<String> ObtenerPreguntasRegistradas(int id)
        {
            DimeContext context = new DimeContext();
            var result = (from b in context.UsuariosXPreguntasDesbs join c in context.PreguntasDesbloqueos on b.IdPregunta equals c.Id
                         where b.IdUsuario == id  select c.Nombre).ToList();
            return result;
        }

        public bool RespuestasValidas(List<string> respuestas, int idUsuario)
        {
         for (int i = 0; i < respuestas.Count; i++)
            { respuestas[i]= new GeneralEncriptor().GetEncriptedData(respuestas[i].ToUpperNoSpecialChars());
            }
            DimeContext context = new DimeContext();
            List<string> result = (from b in context.UsuariosXPreguntasDesbs
                          where b.IdUsuario == idUsuario
                          select b.Respuesta).ToList();
            return respuestas.SequenceEqual(result);
        }

        public bool RestablecerContraseña(string contraseña, int idUsuario)
        {
            

            try
            {
                DimeContext context = new DimeContext();
                contraseña = new GeneralEncriptor().GetEncriptedData(contraseña);
                Usuario usuario = new Usuario
                {
                    Id = idUsuario,
                    Contrasena = contraseña,
                    FechaContrasena = DateTime.Now
                };
                context.Usuarios.Attach(usuario);
                var entry = context.Entry(usuario);
                entry.Property(e => e.Contrasena).IsModified = true;
                entry.Property(e => e.FechaContrasena).IsModified = true;
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            
            }
            return true;
        }

        public bool RegistrarSesionUsuario(RegistroSesion registroSesion)
        {
            DimeContext context = new DimeContext();
            context.RegistroSesions.Add(registroSesion);
            context.SaveChanges();
            return true;
        }


        public AccesoCollection ListaAccesosDePerfil(int idPerfil)
        {
            DimeContext context = new DimeContext();
            AccesoCollection result = new AccesoCollection();
            result.AddRange(context.Accesoes.Where(c => c.IdModoLogin == idPerfil).ToList());
            return result;
        }

        public LineaCollection ListaLineasDePerfil(int idPerfil)
        {
            DimeContext context = new DimeContext();
            LineaCollection result = new LineaCollection();
            result.AddRange(context.Lineas.Where(c => c.IdModoLogin  == idPerfil).ToList());
            return result;
        }


        public BasePersonalHolo ConsultarUsuarioHolos(decimal cedula)
        {
            DimeContext context = new DimeContext();
            return context.BasePersonalHoloes.Where(c => c.Cedula == cedula).FirstOrDefault();
        }


        public BasePersonalHoloCollection ListaUsuariosDePerfilYAliado(int idPerfil, string aliado)
        {
            DimeContext context = new DimeContext();
            BasePersonalHoloCollection result = new BasePersonalHoloCollection();
            List<BasePersonalHolo> holosResult = context.BasePersonalHoloes.Where(c => c.Aliado == aliado).ToList();
            List<decimal> usuariosDime = context.Usuarios.Select(c=> c.Cedula??0).ToList();

            holosResult = holosResult.Where(c=> usuariosDime.Contains(c.Cedula) ).ToList();
            result.AddRange(holosResult);  
            return result;
        }

    }
}
