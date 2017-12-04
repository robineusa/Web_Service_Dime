using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.Data;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.Helpers.Encription;
using Telmexla.Servicios.DIME.IWebServices;
using Telmexla.Servicios.DIME.Helpers.ExtenMethods;
using System.Data.Entity;
using System.Data.Entity.Validation;
using Telmexla.Servicios.DIME.Business;

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
            //var userLastDate = context.UsuariosXAccesoes.OrderByDescending(x => x.FechaCreacion).Where(c => c.IdUsuario == usuario.Id).Select(x => new { x.FechaCreacion }).FirstOrDefault();
            //var userLastTime = context.UsuariosXAccesoes.OrderByDescending(x => x.HoraCreacion).Where(c => c.IdUsuario == usuario.Id && c.FechaCreacion == userLastDate.FechaCreacion).Select(x => new { x.HoraCreacion }).FirstOrDefault();
            //var r = context.UsuariosXAccesoes.FirstOrDefault(c => c.IdUsuario == usuario.Id && c.FechaCreacion == userLastDate.FechaCreacion && c.HoraCreacion == userLastTime.HoraCreacion && (c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoAdministrador || c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoAsesor
            //|| c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoCelula)).IdAcceso;
            if (usuario.Id != 0 && usuario.Contrasena.Equals(context.Usuarios.Single(c => c.Cedula == usuario.Cedula).Contrasena)
              && context.UsuariosXAccesoes.Any(c => c.IdUsuario == usuario.Id && (c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoAdministrador || c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoAsesor
                 || c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoCelula)))
            {
                return context.UsuariosXAccesoes.FirstOrDefault(c => c.IdUsuario == usuario.Id && (c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoAdministrador || c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoAsesor
                 || c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoCelula)).IdAcceso;
            }
            else
            {
                if (!context.UsuariosXAccesoes.Any(c => c.IdUsuario == usuario.Id && (c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoAdministrador || c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoAsesor
                   || c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoCelula)))
                {
                    return -1;
                }
                return 0;
            }


        }


        public bool PreguntasDesbloqueoCompletas(int id)
        {
            DimeContext context = new DimeContext();
            if (context.UsuariosXPreguntasDesbs.Where(c => c.IdUsuario == id).Count() == 5)
            {
                return true;
            }
            else { return false; }
        }

        public bool DatosUsuarioCompleto(int id)
        {
            DimeContext context = new DimeContext();
            Usuario usuario = context.Usuarios.Where(c => c.Id == id).Single();
            if (usuario.Correo == null || usuario.FechaNacimiento == null || usuario.Genero == null || usuario.Telefono == null)
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
            if ((((int)(DateTime.Now - datePasswordPut).TotalDays) > 30) || usuario.FechaContrasena == null)
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
            var result = context.Usuarios.SingleOrDefault(c => c.Cedula == cedula);
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
            for (int i = 0; i < noPreguntas; i++)
            {
                if (i < preguntas.Count() && i < respuestas.Count())
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
        {
            DimeContext context = new DimeContext();
            var userLastDate = context.UsuariosXAccesoes.OrderByDescending(x => x.FechaCreacion).Where(c => c.IdUsuario == id).Select(x => new { x.FechaCreacion }).FirstOrDefault();
            var userLastTime = context.UsuariosXAccesoes.OrderByDescending(x => x.HoraCreacion).Where(c => c.IdUsuario == id).Select(x => new { x.HoraCreacion }).FirstOrDefault();
            var permisosUsuario = context.UsuariosXAccesoes.Where(c => c.IdUsuario == id && c.FechaCreacion == userLastDate.FechaCreacion && c.HoraCreacion == userLastTime.HoraCreacion);
            var permisosQuitar = permisosUsuario.Where(c => (c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoAdministrador || c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoAsesor
                  || c.IdAcceso == (int)IDS_MODOS_ACCESOS.IngresoCelula));
            if (permisosQuitar.Any())
            {
                permisosUsuario = permisosUsuario.Except(permisosQuitar);
                var permisosUsuarioList = permisosUsuario.ToList();
                for (int i = 0; i < permisosUsuarioList.Count(); i++)
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
            }
            else
            {
                return false;
            }
        }

        public List<String> ObtenerPreguntasRegistradas(int id)
        {
            DimeContext context = new DimeContext();
            var result = (from b in context.UsuariosXPreguntasDesbs
                          join c in context.PreguntasDesbloqueos on b.IdPregunta equals c.Id
                          where b.IdUsuario == id
                          select c.Nombre).ToList();
            return result;
        }

        public bool RespuestasValidas(List<string> respuestas, int idUsuario)
        {
            for (int i = 0; i < respuestas.Count; i++)
            {
                respuestas[i] = new GeneralEncriptor().GetEncriptedData(respuestas[i].ToUpperNoSpecialChars());
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

        public AccesoCollection ListaAccesosDeLinea(int idLinea)
        {
            DimeContext context = new DimeContext();
            AccesoCollection result = new AccesoCollection();
            result.AddRange(context.Accesoes.Where(c => c.AccesosXLineas.Any(d => d.IdLinea == idLinea)).ToList());
            return result;
        }

        public LineaCollection ListaLineasDePerfil(int idPerfil)
        {
            DimeContext context = new DimeContext();
            LineaCollection result = new LineaCollection();
            result.AddRange(context.Lineas.Where(c => c.IdModoLogin == idPerfil).ToList());
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
            List<decimal> usuariosDime = context.Usuarios.Where(x => x.Linea.IdModoLogin == idPerfil).Select(c => c.Cedula ?? 0).ToList();

            holosResult = holosResult.Where(c => usuariosDime.Contains(c.Cedula)).ToList();
            result.AddRange(holosResult);
            return result;
        }

        public void CrearUsuario(int idLinea, int idPerfil, BasePersonalHolo usuarioHolos, string[] permisosOtorgados, string contraseña, string usuarioCambio)
        {
            DimeContext dimContext = new DimeContext();
            Usuario usuario = new Usuario();
            usuario.Cedula = usuarioHolos.Cedula;
            usuario.Nombre = usuarioHolos.Nombre;
            usuario.Contrasena = new GeneralEncriptor().GetEncriptedData(contraseña);
            usuario.FechaContrasena = Convert.ToDateTime("2015-05-28");
            usuario.Capacitado = false;
            usuario.IdLinea = idLinea;
            dimContext.Usuarios.Add(usuario);
            dimContext.SaveChanges();

            DateTime fechaActual = DateTime.Now;
            for (int i = 0; i < permisosOtorgados.Length; i++)
            {
                UsuariosXAcceso accesosUsuario = new UsuariosXAcceso();
                accesosUsuario.IdUsuario = usuario.Id;
                accesosUsuario.IdAcceso = Convert.ToInt32(permisosOtorgados[i]);
                accesosUsuario.IdUserCambioo = Convert.ToInt32(usuarioCambio);
                accesosUsuario.FechaCreacion = fechaActual;
                accesosUsuario.HoraCreacion = fechaActual.TimeOfDay;
                dimContext.UsuariosXAccesoes.Add(accesosUsuario);
            }
            dimContext.SaveChanges();
        }

        public string LineaDeUsuario(int idUsuario)
        {
            DimeContext context = new DimeContext();
            return context.Usuarios.Where(c => c.Id == idUsuario).Select(x => x.Linea.Nombre).FirstOrDefault();
        }
        public int IdLineaDeUsuario(int idUsuario)
        {
            DimeContext context = new DimeContext();
            return context.Usuarios.Where(c => c.Id == idUsuario).Select(x => x.Linea.Id).FirstOrDefault();
        }


        public string PerfilDeUsuario(int idUsuario)
        {
            DimeContext context = new DimeContext();
            return context.Usuarios.Where(c => c.Id == idUsuario).Select(x => x.Linea.ModosLogin.Nombre).FirstOrDefault();
        }

        public int IdPerfilDeUsuario(int idUsuario)
        {
            DimeContext context = new DimeContext();
            return context.Usuarios.Where(c => c.Id == idUsuario).Select(x => x.Linea.ModosLogin.Id).FirstOrDefault();
        }


        public List<string> ListaAccesosDeUsuario(int cedUsuario)
        {
            DimeContext context = new DimeContext();
            int idUsuario = context.Usuarios.Where(c => c.Cedula == cedUsuario).Select(x => x.Id).FirstOrDefault();


            List<UsuariosXAcceso> userAcces = context.UsuariosXAccesoes.Where(c => c.IdUsuario == idUsuario).OrderBy(d => d.FechaCreacion).ThenBy(e => e.HoraCreacion).ToList();
            //DateTime? ultimaFecha = userAcces.Last().FechaCreacion;
            //TimeSpan? ultimaHora = userAcces.Last().HoraCreacion;
            List<string> result = new List<string>();
            foreach (var item in userAcces)
            {
                //if(item.HoraCreacion == ultimaHora && item.FechaCreacion == ultimaFecha)
                result.Add(context.Accesoes.Where(c => c.Id == item.IdAcceso).SingleOrDefault().Nombre);
            }
            return result;
        }

        public void ActualizarAccesosUsuario(int idUsuario, int idPerfil, int idLinea, string[] permisosOtorgados, string contraseña, string usuarioCambioo)
        {

            DimeContext dimContext = new DimeContext();
            Usuario usuario = dimContext.Set<Usuario>().Find(idUsuario);
            usuario.IdLinea = idLinea;
            dimContext.SaveChanges();
            if (contraseña != null && contraseña != "")
            {
                usuario.Contrasena = new GeneralEncriptor().GetEncriptedData(contraseña);
                usuario.FechaContrasena = Convert.ToDateTime("2015-05-28");
                dimContext.SaveChanges();
            }
            DateTime fechaActual = DateTime.Now;
            for (int i = 0; i < permisosOtorgados.Length; i++)
            {
                var IdAcceso = Convert.ToInt32(permisosOtorgados[i]);
                var Validacion = dimContext.UsuariosXAccesoes.FirstOrDefault(c => c.IdUsuario == idUsuario && c.IdAcceso == IdAcceso);
                if (Validacion == null)
                {
                    UsuariosXAcceso accesosUsuario = new UsuariosXAcceso();
                    accesosUsuario.IdUsuario = usuario.Id;
                    accesosUsuario.IdAcceso = Convert.ToInt32(permisosOtorgados[i]);
                    accesosUsuario.IdUserCambioo = Convert.ToInt32(usuarioCambioo);
                    accesosUsuario.FechaCreacion = fechaActual;
                    accesosUsuario.HoraCreacion = fechaActual.TimeOfDay;
                    dimContext.UsuariosXAccesoes.Add(accesosUsuario);
                    dimContext.SaveChanges();
                }
                else
                {

                }
            }
            
        }

        public void ActualizarAccesosUsuarioMasivo(List<string> listaUsuariosCambiados, int idLinea, List<string> listaPermisos, string idUsuarioCambioo)
        {
            DimeContext dimContext = new DimeContext();

            foreach (string cedUsuario in listaUsuariosCambiados)
            {
                decimal cedulaUsuario = Convert.ToDecimal(cedUsuario);
                Usuario usuario = dimContext.Set<Usuario>().Where(c => c.Cedula == cedulaUsuario).FirstOrDefault();
                if (idLinea != 0)
                {
                    usuario.IdLinea = idLinea;
                    dimContext.SaveChanges();
                }
                DateTime fechaActual = DateTime.Now;

                for (int i = 0; i < listaPermisos.Count; i++)
                {
                    var IdAcceso = Convert.ToInt32(listaPermisos[i]);
                    var Validacion = dimContext.UsuariosXAccesoes.FirstOrDefault(c => c.IdUsuario == usuario.Id && c.IdAcceso == IdAcceso);
                    if (Validacion == null)
                    {
                        UsuariosXAcceso accesosUsuario = new UsuariosXAcceso();
                        accesosUsuario.IdUsuario = usuario.Id;
                        accesosUsuario.IdAcceso = Convert.ToInt32(listaPermisos[i]);
                        accesosUsuario.IdUserCambioo = Convert.ToInt32(idUsuarioCambioo);
                        accesosUsuario.FechaCreacion = fechaActual;
                        accesosUsuario.HoraCreacion = fechaActual.TimeOfDay;
                        dimContext.UsuariosXAccesoes.Add(accesosUsuario);
                        dimContext.SaveChanges();
                    }
                    else { }
                }
                
            }

        }


        public List<UsuariosMasivoData> ListaDatosUsuariosHolosPorCedulas(List<string> cedulas)
        {
            DimeContext context = new DimeContext();
            List<UsuariosMasivoData> result = new List<UsuariosMasivoData>();
            List<decimal> cedulasDecimal = cedulas.ConvertAll(s => Convert.ToDecimal(s));
            List<BasePersonalHolo> holosResult = context.BasePersonalHoloes.Where(c => cedulasDecimal.Contains(c.Cedula)).ToList();

            foreach (var item in holosResult)
            {
                UsuariosMasivoData nuevoUsuario = new UsuariosMasivoData();
                nuevoUsuario.Aliado = item.Aliado;
                nuevoUsuario.Apellido1 = item.Apellido1;
                nuevoUsuario.Apellido2 = item.Apellido2;
                nuevoUsuario.Canal = item.Canal;
                nuevoUsuario.Cargo = item.Cargo;
                nuevoUsuario.Cedula = item.Cedula;
                nuevoUsuario.Estado = item.Estado;
                nuevoUsuario.Grupo = item.Grupo;
                nuevoUsuario.Nombre = item.Nombre;
                nuevoUsuario.Nombre1 = item.Nombre1;
                nuevoUsuario.Nombre2 = item.Nombre2;
                nuevoUsuario.NombreLinea = item.NombreLinea;
                nuevoUsuario.Operacion = item.Operacion;
                nuevoUsuario.Segmento = item.Segmento;
                nuevoUsuario.UsuarioAgendamiento = item.UsuarioAgendamiento;
                nuevoUsuario.UsuarioGerencia = item.UsuarioGerencia;
                nuevoUsuario.UsuarioRr = item.UsuarioRr;
                result.Add(nuevoUsuario);
            }

            for (int i = 0; i < cedulasDecimal.Count; i++)
            {
                if (!result.Any(c => c.Cedula == cedulasDecimal[i]))
                {
                    UsuariosMasivoData nuevoUsuario = new UsuariosMasivoData();
                    nuevoUsuario.Cedula = cedulasDecimal[i];
                    //nuevoUsuario.InfoRegistro = "El usuario no se encuentra en holos";
                    result.Remove(nuevoUsuario);
                }
            }

            for (int j = 0; j < cedulasDecimal.Count; j++)
            {
                decimal cedulaUnica = cedulasDecimal[j];
                if (context.Usuarios.Where(c => c.Cedula == cedulaUnica).Any())
                {
                    if (result.Any(c => c.Cedula == cedulasDecimal[j]))
                    {
                        UsuariosMasivoData nuevoUsuario = result.FirstOrDefault(c => c.Cedula == cedulasDecimal[j]);
                        result.Remove(nuevoUsuario);
                        //nuevoUsuario.InfoRegistro = "El usuario ya se encuentra creado";
                        //result.Add(nuevoUsuario);
                    }
                    else
                    {
                        UsuariosMasivoData nuevoUsuario = new UsuariosMasivoData();
                        nuevoUsuario.Cedula = cedulasDecimal[j];
                        nuevoUsuario.InfoRegistro = "El usuario ya se encuentra creado";
                        result.Remove(nuevoUsuario);
                        //result.Add(nuevoUsuario);

                    }

                }

            }

            return result;
        }



        public void GuardarUsuariosMasivosConAccesos(List<string> cedulas, List<string> accesosCrear, int perfilCrear, int lineaCrear, string contraMasiva, int idUsuario)
        {

            DimeContext context = new DimeContext();
            List<decimal> cedulasDecimal = cedulas.ConvertAll(s => Convert.ToDecimal(s));
            List<int> accesosInt = accesosCrear.ConvertAll(s => Convert.ToInt32(s));

            foreach (decimal cedula in cedulasDecimal)
            {
                BasePersonalHolo usuarioHolos = context.BasePersonalHoloes.First(c => c.Cedula == cedula);
                Usuario usuario = new Usuario();
                usuario.Cedula = usuarioHolos.Cedula;
                usuario.Nombre = usuarioHolos.Nombre;
                usuario.Contrasena = new GeneralEncriptor().GetEncriptedData(contraMasiva);
                usuario.FechaContrasena = Convert.ToDateTime("2015-05-28");
                usuario.Capacitado = false;
                usuario.IdLinea = lineaCrear;
                context.Usuarios.Add(usuario);
                context.SaveChanges();

                DateTime fechaActual = DateTime.Now;
                for (int i = 0; i < accesosCrear.Count; i++)
                {
                    UsuariosXAcceso accesosUsuario = new UsuariosXAcceso();
                    accesosUsuario.IdUsuario = usuario.Id;
                    accesosUsuario.IdAcceso = Convert.ToInt32(accesosCrear[i]);
                    accesosUsuario.IdUserCambioo = Convert.ToInt32(idUsuario);
                    accesosUsuario.FechaCreacion = fechaActual;
                    accesosUsuario.HoraCreacion = fechaActual.TimeOfDay;
                    context.UsuariosXAccesoes.Add(accesosUsuario);
                }
                context.SaveChanges();
            }

        }

        public Usuario RecibirUsuarioConId(int idUsuario)
        {
            DimeContext dimeContext = new DimeContext();
            return dimeContext.Usuarios.Find(idUsuario);
        }


        public string AliadoDeUsuario(decimal? cedula)
        {
            DimeContext dimeContext = new DimeContext();
            return dimeContext.BasePersonalHoloes.Where(c => c.Cedula == cedula).First().Aliado;

        }

        public string LineaDeUsuarioPorId(int idLinea)
        {
            DimeContext dimeContext = new DimeContext();
            return dimeContext.Lineas.Find(idLinea).Nombre;

        }

        public string ModoLoginPorId(int idLinea)
        {
            DimeContext dimeContext = new DimeContext();
            return dimeContext.Lineas.Find(idLinea).IdModoLogin.ToString();
        }

        public bool ExisteUsuarioHolos(decimal cedula)
        {
            DimeContext dimeContext = new DimeContext();
            return dimeContext.BasePersonalHoloes.Any(c => c.Cedula == cedula);
        }


        public string OperacionPorCedula(int Cedula)
        {
            DimeContext dimeContext = new DimeContext();
            var FindUser = dimeContext.SkillsUsuariosBlending.Any(A => A.Cedula == Cedula).ToString();
            if (FindUser != "False")
            {
                return dimeContext.SkillsUsuariosBlending.Where(A => A.Cedula == Cedula).First().Operacion;
            }
            else
            {
                return FindUser;
            }
        }

        public string CampañaPorCedula(int Cedula)
        {
            DimeContext dimeContext = new DimeContext();
            var FindUser = dimeContext.SkillsUsuariosBlending.Any(A => A.Cedula == Cedula).ToString();
            if (FindUser != "False")
            {
                return dimeContext.SkillsUsuariosBlending.Where(a => a.Cedula == Cedula).First().Campaña;
            }
            else
            {
                return FindUser;
            }

        }

        public List<UsuariosMasivoData> ListaDatosUsuariosDimePorCedulas(List<string> cedulas)
        {
            DimeContext context = new DimeContext();
            List<UsuariosMasivoData> result = new List<UsuariosMasivoData>();
            List<decimal> cedulasDecimal = cedulas.ConvertAll(s => Convert.ToDecimal(s));

            List<BasePersonalHolo> holosResult = context.BasePersonalHoloes.Where(c => cedulasDecimal.Contains(c.Cedula)).ToList();

            foreach (var item in holosResult)
            {
                UsuariosMasivoData nuevoUsuario = new UsuariosMasivoData();
                nuevoUsuario.Aliado = item.Aliado;
                nuevoUsuario.Apellido1 = item.Apellido1;
                nuevoUsuario.Apellido2 = item.Apellido2;
                nuevoUsuario.Canal = item.Canal;
                nuevoUsuario.Cargo = item.Cargo;
                nuevoUsuario.Cedula = item.Cedula;
                nuevoUsuario.Estado = item.Estado;
                nuevoUsuario.Grupo = item.Grupo;
                nuevoUsuario.Nombre = item.Nombre;
                nuevoUsuario.Nombre1 = item.Nombre1;
                nuevoUsuario.Nombre2 = item.Nombre2;
                nuevoUsuario.NombreLinea = item.NombreLinea;
                nuevoUsuario.Operacion = item.Operacion;
                nuevoUsuario.Segmento = item.Segmento;
                nuevoUsuario.UsuarioAgendamiento = item.UsuarioAgendamiento;
                nuevoUsuario.UsuarioGerencia = item.UsuarioGerencia;
                nuevoUsuario.UsuarioRr = item.UsuarioRr;
                result.Add(nuevoUsuario);
            }

            for (int i = 0; i < cedulasDecimal.Count; i++)
            {
                if (!result.Any(c => c.Cedula == cedulasDecimal[i]))
                {
                    UsuariosMasivoData nuevoUsuario = new UsuariosMasivoData();
                    result.Remove(nuevoUsuario);
                }
            }

            for (int j = 0; j < cedulasDecimal.Count; j++)
            {
                decimal cedulaUnica = cedulasDecimal[j];
                if (context.Usuarios.Where(c => c.Cedula == cedulaUnica).Any())
                {
                    if (result.Any(c => c.Cedula == cedulasDecimal[j]))
                    {
                        UsuariosMasivoData nuevoUsuario = result.FirstOrDefault(c => c.Cedula == cedulasDecimal[j]);
                        result.Remove(nuevoUsuario);
                        nuevoUsuario.InfoRegistro = "Modificable";
                        result.Add(nuevoUsuario);
                    }
                    else
                    {

                    }

                }
                else
                {
                    UsuariosMasivoData nuevoUsuario = result.FirstOrDefault(c => c.Cedula == cedulasDecimal[j]);
                    result.Remove(nuevoUsuario);
                }

            }

            return result;
        }
        public List<ListaAccesoSUsuario> ListaAccesosDeUsuario2(int cedUsuario)
        {
            DimeContext context = new DimeContext();
            int idUsuario = context.Usuarios.Where(c => c.Cedula == cedUsuario).Select(x => x.Id).FirstOrDefault();

            //List<UsuariosXAcceso> userAcces = context.UsuariosXAccesoes.Where(c => c.IdUsuario == idUsuario).OrderBy(d => d.FechaCreacion).ThenBy(e => e.HoraCreacion).ToList();

            List<ListaAccesoSUsuario> result = new List<ListaAccesoSUsuario>();
            var objetosResult = (from a in context.UsuariosXAccesoes
                                 join b in context.Accesoes on a.IdAcceso equals b.Id
                                 where a.IdUsuario == idUsuario
                                 orderby a.IdAcceso ascending
                                 select new
                                 {
                                     a.IdAcceso,
                                     b.Nombre,
                                     b.Descripcion
                                 }).ToList();
            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new ListaAccesoSUsuario());
                result[i].IdAcceso = objetosResult[i].IdAcceso;
                result[i].NombreAcceso = objetosResult[i].Nombre;
                result[i].DescripcionAcceso = objetosResult[i].Descripcion;
            }
            return result;
        }
        public void EliminarAccesosUsuario(int idUsuario, int idAcceso)
        {
            DimeContext dimContext = new DimeContext();
            //Usuario usuario = dimContext.Set<Usuario>().Find(idUsuario);
            UsuariosXAcceso accesosUsuario = new UsuariosXAcceso();
            accesosUsuario = dimContext.UsuariosXAccesoes.FirstOrDefault(c => c.IdUsuario == idUsuario && c.IdAcceso == idAcceso);
            dimContext.UsuariosXAccesoes.Remove(accesosUsuario);
            dimContext.SaveChanges();
        }
        public void EjecutraProcedimiento()
        {
            UnitOfWork unitOfWork = new UnitOfWork(new DimeContext());
            //Usuario usuario = context.Usuarios.Where(c => c.Id == id).Single();
            unitOfWork.usuarios.ActualizaBDPersonal();
            //unitOfWork.RecurrenciaCargaBase.ApartarCuentaaGestionarRecurrencia(idAsesor);
        }
        public List<Acceso> ListaAccesos()
        {
            DimeContext context = new DimeContext();
            List<Acceso> result = new List<Acceso>();
            var objetosResult = (from a in context.Accesoes
                                 orderby a.Id ascending
                                 select new
                                 {
                                     a.Id,
                                     a.Nombre,
                                     a.IdModoLogin,
                                     a.Descripcion
                                 }).ToList();

            for (int i = 0; i < objetosResult.Count; i++)
            {
                result.Add(new Acceso());
                result[i].Id = objetosResult[i].Id;
                result[i].Nombre = objetosResult[i].Nombre;
                result[i].IdModoLogin = objetosResult[i].IdModoLogin;
                result[i].Descripcion = objetosResult[i].Descripcion;                
            }

            return result;
        }
    }
}
