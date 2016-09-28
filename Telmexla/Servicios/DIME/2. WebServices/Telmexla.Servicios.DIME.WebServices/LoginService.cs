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

namespace Telmexla.Servicios.DIME.WebServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "LoginService" en el código y en el archivo de configuración a la vez.
    [DataContract]
    public class LoginService : ILoginService
    {

 
        public bool AutenticarUsuario(Usuario usuario)
        { try
            { 
            usuario.Contrasena = new GeneralEncriptor().GetEncriptedData(usuario.Contrasena);
            DimeContext context = new DimeContext();
            if (context.Usuarios.Any(c => c.Cedula == usuario.Cedula) && usuario.Contrasena.Equals(context.Usuarios.Single(c => c.Cedula == usuario.Cedula).Contrasena))
                { 
                return true;
                }
                else return false;
            }
            catch(Exception e)
            { throw e;
            }
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
                     item.Respuesta = respuestas[i].ToUpperNoSpecialChars();
                     context.UsuariosXPreguntasDesbs.Add(item);
                     }
                       else return false;
               }
            context.SaveChanges();
            return true;
        }






    }
}
