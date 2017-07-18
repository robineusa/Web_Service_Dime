﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;
using Telmexla.Servicios.DIME.IWebServices;
using Telmexla.Servicios.DIME.IWebServices.IMainWebService;
using Telmexla.Servicios.DIME.Helpers.ExtenMethods;
using Telmexla.Servicios.DIME.Business;
using Telmexla.Servicios.DIME.Helpers.Mappers;

namespace Telmexla.Servicios.DIME.WebServices.MainWebService
{
    public class WebService : IWebService, ILoginService, IInboundService, IMaestrosService, IBlendingService,IMarcacionesService, INotificacionesBuenServicioService, ICasosCelulaService, ICasosAdminService,ITrasladosService,IMaestroNodoService,IActivacionClaroVideoService,IActivacionSiembraHDService,IBalanceScoreCardService, IGraficosService,IUsabilidadService, IDistribucionBlendingService, IMultiPlayService,IMecService, ICierreCicloService    {



        public Usuario MuestraEntidades()
        {
            return new Usuario { Nombre = "Alejandro ", Cedula = 1033478952 };
        }



        #region Login Service
        public int AutenticarUsuarioEnSesion(Usuario usuario)
        {
            LoginService lService = new LoginService();
            return lService.AutenticarUsuarioEnSesion(usuario);
        }


 

        public List<PreguntasDesbloqueo> ObtenerPosiblesPreguntas()
        {
            LoginService lService = new LoginService();
            return lService.ObtenerPosiblesPreguntas();
        }


        public int RecibirIdUsuario(decimal? cedula)
        {
            LoginService lService = new LoginService();
            return lService.RecibirIdUsuario(cedula);
        }

        public Usuario RecibirUsuario()
        {
            LoginService lService = new LoginService();
            return lService.RecibirUsuario();
        }

        public bool RegistrarActualizarPreguntas(List<PreguntasDesbloqueo> preguntas, List<string> respuestas, Usuario usuario, int noPreguntas)
        {
            LoginService lService = new LoginService();
            return lService.RegistrarActualizarPreguntas(preguntas,respuestas, usuario, noPreguntas);
        }

        public bool BloquearUsuario(int id, int idUsuarioCambioo, string ipPrivadaCreacion, string ipPublicaCreacion)
        {
            LoginService lService = new LoginService();
            return lService.BloquearUsuario(id,idUsuarioCambioo, ipPrivadaCreacion, ipPublicaCreacion);
        }

        public List<String> ObtenerPreguntasRegistradas(int id)
        {
            LoginService lService = new LoginService();
            return lService.ObtenerPreguntasRegistradas(id);
        }


        public bool RespuestasValidas(List<string> respuestas, int idUsuario)
        {
            LoginService lService = new LoginService();
            return lService.RespuestasValidas(respuestas, idUsuario);

        }

        public bool RestablecerContraseña(String contraseña, int idUsuario)
        {

            LoginService lService = new LoginService();
            return lService.RestablecerContraseña(contraseña, idUsuario);
        }


        public bool PreguntasDesbloqueoCompletas(int id)
        {   LoginService lService = new LoginService();
            return lService.PreguntasDesbloqueoCompletas(id);
        }

        public bool DatosUsuarioCompleto(int id)
        {
            LoginService lService = new LoginService();
            return lService.DatosUsuarioCompleto(id);
        }

        public bool ContraseñaCaducada(int id)
        {
            LoginService lService = new LoginService();
            return lService.ContraseñaCaducada(id);
        }


        public bool Capacitado(int id)
        {
            LoginService lService = new LoginService();
            return lService.Capacitado(id);
        }
        public bool CapacitarUsuario(int id)
        {
            LoginService lService = new LoginService();
            return lService.CapacitarUsuario(id);

        }
        public bool RegistrarActualizarDatosUsuario(Usuario usuario)
        {
            LoginService lService = new LoginService();
            return lService.RegistrarActualizarDatosUsuario(usuario);

        }
        public  bool RegistrarSesionUsuario(RegistroSesion registroSesion)
        {
            LoginService lService = new LoginService();
            return lService.RegistrarSesionUsuario(registroSesion);
        }


        public AccesoCollection ListaAccesosDePerfil(int idPerfil)
        {
            LoginService lService = new LoginService();
            return lService.ListaAccesosDePerfil(idPerfil);

        }

        public LineaCollection ListaLineasDePerfil(int idPerfil)
        {
            LoginService lService = new LoginService();
            return lService.ListaLineasDePerfil(idPerfil);
        }

        public BasePersonalHolo ConsultarUsuarioHolos(decimal cedula)
        {
            LoginService lService = new LoginService();
            return lService.ConsultarUsuarioHolos(cedula);
        }
        public BasePersonalHoloCollection ListaUsuariosDePerfilYAliado(int idPerfil, string aliado)
        {
            LoginService lService = new LoginService();
            return lService.ListaUsuariosDePerfilYAliado(idPerfil, aliado);
        }

        public void CrearUsuario(int idLinea, int idPerfil, BasePersonalHolo usuarioHolos, string[] permisosOtorgados, string contraseña, string usuarioCambio)
        {
            LoginService lService = new LoginService();
            lService.CrearUsuario(idLinea, idPerfil, usuarioHolos, permisosOtorgados, contraseña, usuarioCambio);
        }


        public string LineaDeUsuario(int idUsuario)
        {
            LoginService lService = new LoginService();
           return  lService.LineaDeUsuario(idUsuario);
        }

        public int IdLineaDeUsuario(int idUsuario)
        {
            LoginService lService = new LoginService();
            return lService.IdLineaDeUsuario(idUsuario);
        }

        public string PerfilDeUsuario(int idUsuario)
        {
            LoginService lService = new LoginService();
           return  lService.PerfilDeUsuario(idUsuario);
        }

        public int IdPerfilDeUsuario(int idUsuario)
        {
            LoginService lService = new LoginService();
            return lService.IdPerfilDeUsuario(idUsuario);
        }


        public List<string> ListaAccesosDeUsuario(int cedUsuario)
        {
            LoginService lService = new LoginService();
            return lService.ListaAccesosDeUsuario(cedUsuario);
        }

        public void ActualizarAccesosUsuario(int idUsuario, int idPerfil, int idLinea, string[] permisosOtorgados, string contraseña, string usuarioCambioo)
        {
            LoginService lService = new LoginService();
            lService.ActualizarAccesosUsuario( idUsuario,  idPerfil,  idLinea,  permisosOtorgados,  contraseña,  usuarioCambioo);
        }

        public void ActualizarAccesosUsuarioMasivo(List<string> listaUsuariosCambiados, int idLinea, List<string> listaPermisos, string idUsuarioCambioo)
        {
            LoginService lService = new LoginService();
            lService.ActualizarAccesosUsuarioMasivo(listaUsuariosCambiados,  idLinea,  listaPermisos,  idUsuarioCambioo);
        }


        public List<UsuariosMasivoData> ListaDatosUsuariosHolosPorCedulas(List<string> cedulas)
        {
            LoginService lService = new LoginService();
           return  lService.ListaDatosUsuariosHolosPorCedulas(cedulas);
        }

        public void GuardarUsuariosMasivosConAccesos(List<string> cedulas, List<string> accesosCrear, int perfilCrear, int lineaCrear, string contraMasiva, int idUsuario)
        {
            LoginService lService = new LoginService();
            lService.GuardarUsuariosMasivosConAccesos(cedulas,  accesosCrear,  perfilCrear,  lineaCrear,  contraMasiva,  idUsuario);
        }


        public Usuario RecibirUsuarioConId(int idUsuario)
        {
            LoginService lService = new LoginService();
            return lService.RecibirUsuarioConId(idUsuario);

        }

        public string AliadoDeUsuario(decimal? cedula)
        {
            LoginService lService = new LoginService();
            return lService.AliadoDeUsuario(cedula);

        }

        public string LineaDeUsuarioPorId(int idUsuario)
        {
            LoginService lService = new LoginService();
            return lService.LineaDeUsuarioPorId(idUsuario);

        }

        public string ModoLoginPorId(int idUsuario)
        {
            LoginService lService = new LoginService();
            return lService.ModoLoginPorId(idUsuario);
        }


        public bool ExisteUsuarioHolos(decimal cedula)
        {
            LoginService lService = new LoginService();
            return lService.ExisteUsuarioHolos(cedula);
        }
        public string OperacionPorCedula(int Cedula)
        {
            LoginService lService = new LoginService();
            return lService.OperacionPorCedula(Cedula);
        }
        public string CampañaPorCedula(int Cedula)
        {
            LoginService lService = new LoginService();
            return lService.CampañaPorCedula(Cedula);
        }
        #endregion

        #region Inbound Service 
        public bool RegistrarActualizarDatosAdicionalesCliente(DatosAdicionalesCliente datosAdicionalesCliente)
        {
            InboundService inboundService = new InboundService();
            return inboundService.RegistrarActualizarDatosAdicionalesCliente(datosAdicionalesCliente);
        }

        public ClientesTodo TraerClienteCompletoPorCuenta(int cuenta)
        {
            InboundService inboundService = new InboundService();
            return inboundService.TraerClienteCompletoPorCuenta(cuenta);
        }

        public DatosAdicionalesCliente TraerDatosAdicionalesCliente(int cuenta)
        {
            InboundService inboundService = new InboundService();
            return inboundService.TraerDatosAdicionalesCliente(cuenta);
        }



        public List<ClientesTodo> ConsultarCuentasPorcedula(string cedula)
        {
            InboundService inboundService = new InboundService();
            return inboundService.ConsultarCuentasPorcedula(cedula);
        }


        public List<string> ConsultarHobbiesOptions()
        {
            InboundService inboundService = new InboundService();
            return inboundService.ConsultarHobbiesOptions();

        }


        public void RegistrarIngresoInbound(ClientesTodo infoCliente, Ingreso ingreso, string observacion, IngresosSoporte ingresoSoporte)
        {
            InboundService inboundService = new InboundService();
             inboundService.RegistrarIngresoInbound(infoCliente, ingreso, observacion, ingresoSoporte);
        }


        public IngresoCollection ListaIngresosDeCuenta(string cuenta)
        {
            InboundService inboundService = new InboundService();
            return inboundService.ListaIngresosDeCuenta(cuenta);
        }

        public List<TablaActualizarInbound> ListaHistorialCaso(int idIngreso)
        {
            InboundService inboundService = new InboundService();
            return inboundService.ListaHistorialCaso(idIngreso);
        }

        public void  ActualizarIngresoInbound(Ingreso ingreso, string observacion, string llamadaCliente, IngresosSoporte ingresoSoporte)
        {
            InboundService inboundService = new InboundService();
            inboundService.ActualizarIngresoInbound(ingreso, observacion, llamadaCliente, ingresoSoporte);
        }

        public List<DatoConsultaGestion> ConsultaGestion(DateTime fechaInicial, DateTime fechaFinal, string idUsuario)
        {
            InboundService inboundService = new InboundService();
            return inboundService.ConsultaGestion(fechaInicial, fechaFinal, idUsuario);
        }

        public List<DatoConsultaRechazo> ConsultaRechazos(DateTime fechaInicial, DateTime fechaFinal, string idUsuario, bool esPerfilAdmin)
        {
            InboundService inboundService = new InboundService();
            return inboundService.ConsultaRechazos(fechaInicial, fechaFinal, idUsuario, esPerfilAdmin);
        }

        public IngresoCollection ConsultaSegumiento(string idUsuario)
        {
            InboundService inboundService = new InboundService();
            return inboundService.ConsultaSegumiento(idUsuario);

        }
        public void InsertarRetencionInbound(Retencion retencion)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            ingresoBusi.InsertarRetencionInbound(retencion);
        }
        public RetencionCollection ListaRetencionInbound(DateTime fechaInicial, DateTime fechaFinal)
        {
            IngresoBusiness ingresoBusi = new IngresoBusiness();
            return ingresoBusi.ListaRetencionInbound(fechaInicial, fechaFinal);
        }
        #endregion

        #region MaestrosService 

        public MaestroOutboundTipoContactoCollection ObtenerTiposDeContactoDeGestion(decimal gestionId)
        {
            MaestrosService maestrosService = new MaestrosService();
            return maestrosService.ObtenerTiposDeContactoDeGestion(gestionId);
        }

        public MaestroOutboundCierreCollection ObtenerTiposDeCierresDeContacto(decimal contactoId)
         {
            MaestrosService maestrosService = new MaestrosService();
            return maestrosService.ObtenerTiposDeCierresDeContacto(contactoId);
         }

        public MaestroOutboundRazonCollection ObtenerTiposDeRazonDeCierres(decimal cierreId)
        {   MaestrosService maestrosService = new MaestrosService();
            return maestrosService.ObtenerTiposDeRazonDeCierres(cierreId);
        }

        public MaestroOutboundCausaCollection ObtenerTiposDeCausasDeRazon(decimal razonId)
        {
            MaestrosService maestrosService = new MaestrosService();
            return maestrosService.ObtenerTiposDeCausasDeRazon(razonId);

        }

        public MaestroOutboundMotivoCollection ObtenerTiposDeMotivoDeCausas(decimal causaId)
        {
            MaestrosService maestrosService = new MaestrosService();
            return maestrosService.ObtenerTiposDeMotivoDeCausas(causaId);

        }
        //Departamentos
        public List<Departamento> TraeListaDepartamentos()
        {
            ArbolesDeTipificacion busi = new ArbolesDeTipificacion();
            return busi.TraeListaDepartamentos();
        }
        public List<Departamento> TraeListaCiudades(string Departamento)
        {
            ArbolesDeTipificacion busi = new ArbolesDeTipificacion();
            return busi.TraeListaCiudades(Departamento);
        }
        public List<Departamento> TraeListaComunidad(string Departamento, string NombreComunidad)
        {
            ArbolesDeTipificacion busi = new ArbolesDeTipificacion();
            return busi.TraeListaComunidad(Departamento, NombreComunidad);
        }
        public List<Departamento> TraeListaRed(string Departamento, string NombreComunidad, string Comunidad)
        {
            ArbolesDeTipificacion busi = new ArbolesDeTipificacion();
            return busi.TraeListaRed(Departamento, NombreComunidad, Comunidad);
        }
        public List<MaestroLineasBlending> TraerListaLineasBlending(string Aliado)
        {
            ArbolesDeTipificacion busi = new ArbolesDeTipificacion();
            return busi.GetLineasBlending(Aliado);
        }
        #endregion

        #region BlendingService

        public ClientesTodo TraerMisDatosClienteAutomaticos(int idAsesor, string gestionBlendingActual, string aliado, string linea)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerMisDatosClienteAutomaticos(idAsesor, gestionBlendingActual, aliado, linea);
        }

        public ConvenioElectronicoCollection TraerHistorialConvenioElectroDeAsesor(int idAsesor)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerHistorialConvenioElectroDeAsesor(idAsesor);
        }


        public bool GuardarGestionConvenioElectronico(int idAsesor, ClientesTodo datosCliente, ConvenioElectronico convElectGestionado)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.GuardarGestionConvenioElectronico(idAsesor, datosCliente, convElectGestionado);

        }

        public ConvenioElectronico TraerConvenioElectronicoGestionado(int idGestionado)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerConvenioElectronicoGestionado(idGestionado);
        }

        public ConvenioElectronicoCollection ListaConveniosElectronicosGestionados(DateTime fInicial, DateTime fFinal)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.ListaConveniosElectronicosGestionados(fInicial, fFinal);

        }
        public DocsisOverlapCollection TraerHistorialDocsisDeAsesor(int idAsesor)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerHistorialDocsisDeAsesor(idAsesor);
        }

        public DocsisOverlap TraerDocsisGestionado(int idGestionado)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerDocsisGestionado(idGestionado);

        }

        public bool GuardarGestionDocsis(int idAsesor, ClientesTodo datosCliente, DocsisOverlap docsisGestionado)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.GuardarGestionDocsis(idAsesor, datosCliente, docsisGestionado);
        }

        public LogDocsisOverlapCollection ListaDocsisOverlapGestionados(DateTime fInicial, DateTime fFinal)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.ListaDocsisOverlapGestionados(fInicial, fFinal);
        }

        public ClaroVideoCollection TraerHistorialClaroVideoDeAsesor(int idAsesor)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerHistorialClaroVideoDeAsesor(idAsesor);
        }

        public ClaroVideo TraerClaroVideoGestionado(int idGestionado)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerClaroVideoGestionado(idGestionado);

        }

        public bool GuardarGestionClaroVideo(int idAsesor, ClientesTodo datosCliente, ClaroVideo claroVideoGestionado)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.GuardarGestionClaroVideo(idAsesor, datosCliente, claroVideoGestionado);

        }

        public LogClaroVideoCollection ListaClaroVideosGestionados(DateTime fInicial, DateTime fFinal)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.ListaClaroVideosGestionados(fInicial, fFinal);
        }

        public CierreCicloCollection TraerHistorialCierreCicloDeAsesor(int idAsesor)
        {

            BlendingService blendingService = new BlendingService();
            return blendingService.TraerHistorialCierreCicloDeAsesor(idAsesor);
        }

        public List<String> TraerNombresDeClientesCierreCiclo(CierreCicloCollection cuentasATraer)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerNombresDeClientesCierreCiclo(cuentasATraer);
        }

        public GestionOutbound TraerGestionOutboundInfoDeCuenta(int cuenta, string gestion, string aliado, string linea)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerGestionOutboundInfoDeCuenta(cuenta, gestion, aliado, linea);
        }

        public CierreCiclo TraerCierreCicloGestionado(int idGestionado)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerCierreCicloGestionado(idGestionado);
        }

        public bool GuardarCierreCiclo(int idAsesor, ClientesTodo datosCliente, CierreCiclo cierreCicloGestionado)
        {

            BlendingService blendingService = new BlendingService();
            return blendingService.GuardarCierreCiclo(idAsesor, datosCliente, cierreCicloGestionado);
        }


        public LogCierreCicloCollection ListaCierresCicloGestionados(DateTime fInicial, DateTime fFinal)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.ListaCierresCicloGestionados(fInicial, fFinal);
        }
        public SkillsUsuariosBlendingCollection ListaUsuariosAdminBlending(string Operacion)
        {
            BlendingBusiness blendingBusiness = new BlendingBusiness();
            return blendingBusiness.ListaUsuariosAdminBlending(Operacion);
        }
        public SkillsUsuariosBlending ConsultaUsuarioenAdminBlending(string cedula)
        {
            BlendingBusiness blendingBusiness = new BlendingBusiness();
            return blendingBusiness.ConsultaUsuarioenAdminBlending(cedula);
        }
        public List<DistribucionBlending> ObtenerCampaña(string Aliado, string Formulario, string Operacion)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.ObtenerCampaña(Aliado, Formulario, Operacion);
        }
        public void InsertarSkillsUsuarioBlending(SkillsUsuariosBlending skills)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            blendingBusin.InsertarSkillsUsuarioBlending(skills);
        }
        public List<DistribucionBlending> CountCuentasOperacionGestion(string aliado, string formulario, string operacion)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.CountCuentasOperacionGestion(aliado, formulario, operacion);
        }
        public List<DistribucionBlending> CountCuentasOperacionCampaña(string aliado, string formulario, string operacion, string campaña)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.CountCuentasOperacionCampaña(aliado, formulario, operacion, campaña);
        }
        public void ActualizarUsuariosBasesBlending(List<string> listaUsuariosCambiados, string Campaña, int Id_Usuario_Actualizacion)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            blendingBusin.ActualizarUsuariosBasesBlending(listaUsuariosCambiados, Campaña, Id_Usuario_Actualizacion);
        }
        public List<DistribucionBlending> GetOperacionBlending(string Aliado, string Formulario)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.GetOperacionBlending(Aliado, Formulario);
        }
        public List<DistribucionBlending> GetFormulariosBlending(string Aliado)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            return blendingBusin.GetFormulariosBlending(Aliado);
        }
        public void ActualizarUsuarioBlending(SkillsUsuariosBlending m)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            blendingBusin.ActualizarUsuarioBlending(m);
        }
        public void EliminaUsuarioSkilles(int Cedula)
        {
            BlendingBusiness blendingBusin = new BlendingBusiness();
            blendingBusin.EliminaUsuarioSkilles(Cedula);
        }
        #endregion

        #region MarcacionesService
        public void RegistrarMarcacion(MaestroMarcacione marcacion)
        {
            MarcacionesService marcacionesService = new MarcacionesService();
            marcacionesService.RegistrarMarcacion(marcacion);
        }

        public MaestroMarcacioneCollection ObtenerMarcacionesPorPalabra(string palabra)
        {
            MarcacionesService marcacionesService = new MarcacionesService();
           return  marcacionesService.ObtenerMarcacionesPorPalabra(palabra);
        }


        public MaestroMarcacione TraerMarcacionPorId(int id)
        {
            MarcacionesService marcacionesService = new MarcacionesService();
            return marcacionesService.TraerMarcacionPorId(id);
        }

        public MaestroMarcacioneCollection ListaMarcaciones()
        {
            MarcacionesService marcacionesService = new MarcacionesService();
            return marcacionesService.ListaMarcaciones();
        }

        public int GetIdMarcacionPorNombre(string nombre)
        {
            MarcacionesService marcacionesService = new MarcacionesService();
            return marcacionesService.GetIdMarcacionPorNombre(nombre);

        }


        public List<String> ListaNombreCodDeSubmarcacion(string submarcacion)
        {
            MarcacionesService marcacionesService = new MarcacionesService();
            return marcacionesService.ListaNombreCodDeSubmarcacion(submarcacion);

        }

        public void EliminarMarcacion(int id)
        {
            MarcacionesService marcacionesService = new MarcacionesService();
            marcacionesService.EliminarMarcacion(id);
        }

        public MaestroMarcacione GetMarcacionPorId(int id)
        {
            MarcacionesService marcacionesService = new MarcacionesService();
            return marcacionesService.GetMarcacionPorId(id);
        }

        public void ActualizarMarcacion(MaestroMarcacione marcacion)
        {
            MarcacionesService marcacionesService = new MarcacionesService();
            marcacionesService.ActualizarMarcacion(marcacion);
        }

        public PqrMaestroCodCierreCollection ListaCodigosDeCierre()
        {
            MarcacionesService marcacionesService = new MarcacionesService();
            return marcacionesService.ListaCodigosDeCierre();
        }

        public void EliminarCodigoCierre(int id)
        {
            MarcacionesService marcacionesService = new MarcacionesService();
            marcacionesService.EliminarCodigoCierre(id);
        }

        public void AgregarCodigoCierre(PqrMaestroCodCierre codigoCierre)
        {
            MarcacionesService marcacionesService = new MarcacionesService();
            marcacionesService.AgregarCodigoCierre(codigoCierre);
        }

        public void ActualizarCodCierre(PqrMaestroCodCierre codigoCierre)
        {
            MarcacionesService marcacionesService = new MarcacionesService();
            marcacionesService.ActualizarCodCierre(codigoCierre);
        }

        public PqrMaestroCodCierre CodigoCierrePorId(int idCierre)
        {
            MarcacionesService marcacionesService = new MarcacionesService();
            return marcacionesService.CodigoCierrePorId(idCierre);
        }
        #endregion

        #region NotificacionesBuenServicioService
        public void RegistrarNotificado(NotificacionesBuenServicio notificado)
        {
            NotificaionesBuenServicioService notificacionesservice = new NotificaionesBuenServicioService();
            notificacionesservice.RegistrarNotificado(notificado);
        }
        public NotificacionesBuenServicioCollection ListaImagenesBuenServicio()
        {
            NotificacionesBuenServicioBusiness ImgBusiness = new NotificacionesBuenServicioBusiness();
            return ImgBusiness.ListaImagenesBuenServicio();
        }
        public NotificacionesBuenServicio ImagenporId(int id)
        {
            NotificacionesBuenServicioBusiness ImgBss = new NotificacionesBuenServicioBusiness();
            return ImgBss.ImagenporId(id);
        }
        public void RegistrarUsuarionotificado(UsuariosNotificados usuarnotificado)
        {
            NotificacionesBuenServicioBusiness usuariosnotifica = new NotificacionesBuenServicioBusiness();
            usuariosnotifica.RegistrarUsuarionotificado(usuarnotificado);
        }
        #endregion

        #region CasosCellService

        public IngresoCollection ListaCasosAbiertosDeCelulaUser(string lineaUser, string aliadoUser)
        {
            CasosCelulaService casosCelulaService = new CasosCelulaService();
            return casosCelulaService.ListaCasosAbiertosDeCelulaUser(lineaUser, aliadoUser);

        }

        public IngresoCollection ListaCasosEnSeguimiento(string usuario)
        {
            CasosCelulaService casosCelulaService = new CasosCelulaService();
            return casosCelulaService.ListaCasosEnSeguimiento(usuario);
        }

        public List<GestionDeCelulaUsr> ListaGestionCasos(DateTime inicial, DateTime final, string idUsr)
        {
            CasosCelulaService casosCelulaService = new CasosCelulaService();
            return casosCelulaService.ListaGestionCasos(inicial, final, idUsr);
        }


        public IngresoCollection ListaIngresosPorCuenta(string cuenta)
        {
            CasosCelulaService casosCelulaService = new CasosCelulaService();
            return casosCelulaService.ListaIngresosPorCuenta(cuenta);
        }

        public IngresoCollection ListaIngresosPorId(string id)
        {
            CasosCelulaService casosCelulaService = new CasosCelulaService();
            return casosCelulaService.ListaIngresosPorId(id);
        }

        public bool CasoTomadoPorUsrBackActualizar(int idIngreso, string usrBack)
        {
            CasosCelulaService casosCelulaService = new CasosCelulaService();
            return casosCelulaService.CasoTomadoPorUsrBackActualizar(idIngreso, usrBack);
        }


        public void ActualizarIngresoPorCelula(Ingreso ingreso, string aplicaRechazo, string razonRechazo, string notas, IngresosSoporte ingresoSoporte)
        {
            CasosCelulaService casosCelulaService = new CasosCelulaService();
            casosCelulaService.ActualizarIngresoPorCelula(ingreso, aplicaRechazo, razonRechazo, notas, ingresoSoporte);
        }


       public  List<RazonIngresoSoporte> ListaRazonesSoporteIngresos()
        {
            CasosCelulaService casosCelulaService = new CasosCelulaService();
           return  casosCelulaService.ListaRazonesSoporteIngresos();
        }


        public List<Subrazon1IngresoSoporte> ListaSubrazon1SoporteIngresos(int idRazon)
        {
            CasosCelulaService casosCelulaService = new CasosCelulaService();
            return casosCelulaService.ListaSubrazon1SoporteIngresos(idRazon);
        }


        public List<Subrazon2IngresoSoporte> ListaSubrazon2SoporteIngresos(int idSubrazon1)
        {
            CasosCelulaService casosCelulaService = new CasosCelulaService();
            return casosCelulaService.ListaSubrazon2SoporteIngresos(idSubrazon1);
        }

        public IngresosSoporte IngresoSoportePorId(int idIngreso)
        {
            CasosCelulaService casosCelulaService = new CasosCelulaService();
            return casosCelulaService.IngresoSoportePorId(idIngreso);
        }
        #endregion CasosCellService

        #region CasosAdminService
        public IngresoCollection ListaIngresosPorTicketRr(string noTicket)
        {
            CasosAdminService casosAdminService = new CasosAdminService();
            return casosAdminService.ListaIngresosPorTicketRr(noTicket);
        }

        public IngresoCollection ListaIngresosPorUsuarioCreacion(string ccUsuario)
        {
            CasosAdminService casosAdminService = new CasosAdminService();
            return casosAdminService.ListaIngresosPorUsuarioCreacion(ccUsuario);

        }

        public List<DatoConsultaPaloteo> ListaPaloteo(string inicial, string final)
        {
            CasosAdminService casosAdminService = new CasosAdminService();
            return casosAdminService.ListaPaloteo(inicial, final);
        }

        public List<String> ListaAliadosActualesDeHolos()
        {
            CasosAdminService casosAdminService = new CasosAdminService();
            return casosAdminService.ListaAliadosActualesDeHolos();
        }

        public List<DatoConsultaGestionAdmin> ListaGestionAdmin(DateTime inicial, DateTime final, string aliado)
        {
            CasosAdminService casosAdminService = new CasosAdminService();
            return casosAdminService.ListaGestionAdmin(inicial, final, aliado);
        }

        public UsuarioCollection ListaUsuariosCelulaActual()
        {
            CasosAdminService casosAdminService = new CasosAdminService();
            return casosAdminService.ListaUsuariosCelulaActual();
        }

        public void ActualizarIngresoPorAdmin(Ingreso ingreso, string notas, string cambioHecho)
        {
            CasosAdminService casosAdminService = new CasosAdminService();
             casosAdminService.ActualizarIngresoPorAdmin(ingreso,notas, cambioHecho);
        }
        #endregion CasosAdminService

        #region registrarTraslado
        public void RegistrarIngresoTraslado(IngresoTraslado ingreso, NotasTraslado notaTraslado, TraficoTraslado transaccion)
        {
            TrasladosService trasladosService = new TrasladosService();
            trasladosService.RegistrarIngresoTraslado(ingreso,notaTraslado,transaccion);
        }
        public bool ExisteCuentaEscalada(decimal cuenta)
        {
            TrasladosService trasladosService = new TrasladosService();
            return   trasladosService.ExisteCuentaEscalada(cuenta);
        }
        public List<DatoConsultaDirecciones> ListaSolicitudesCrearDireccion(string Usuario)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSolicitudesCrearDireccion(Usuario);
        }
        public NotasTrasladoCollection ListaInteraccionesCrearDireccion(int id)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaInteraccionesCrearDireccion(id);
        }
        public void ActualizarSolicitudCrearDireccion(IngresoTraslado ingreso, NotasTraslado notaTraslado, TraficoTraslado transaccion)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.ActualizarSolicitudCrearDireccion(ingreso, notaTraslado,transaccion);
        }
        public bool TransaccionEnGestion(int id, String usrABackOffice)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.TransaccionEnGestion(id, usrABackOffice);
        }
        public List<DatoConsultaDirecciones> ListaSeguimientosDireccionesCelula(string usrABackOffice)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSeguimientosDireccionesCelula(usrABackOffice);
        }
        public List<DatoConsultaDirecciones> ListaDireccionesCreadasOutbound(string Usuario)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaDireccionesCreadasOutbound(Usuario);
        }
        public bool TransaccionEnGestionOut(int id, String usrOut)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.TransaccionEnGestionOut(id, usrOut);
        }
        public List<DatoConsultaDirecciones> ListaSeguimientosDireccionesOutbound(string UsuarioOut)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSeguimientosDireccionesOutbound(UsuarioOut);
        }
        public List<DatoConsultaDirecciones> ListGestionCrearDireccion(DateTime FechaInicial, DateTime FechaFinal, string usrTransac)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListGestionCrearDireccion(FechaInicial, FechaFinal, usrTransac);
        }
        //PROCESOS CAMBIO DE ESTRATO
        public void InsertIngresoCambioEstrato(IngresoTraslado ingreso, CambioEstrato cambioEstrato, TraficoTraslado transaccion)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.InsertIngresoCambioEstrato(ingreso, cambioEstrato,transaccion);
        }
        public bool ExisteCuentaEscaladaCambioEstrato(decimal cuenta)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ExisteCuentaEscaladaCambioEstrato(cuenta);
        }
        public List<DatoConsultaDirecciones> ListaSolicitudesCambioEstrato(string Usuario)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSolicitudesCambioEstrato(Usuario);
        }
        public CambioEstratoCollection ListaInteraccionesCambioEstrato(int id)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaInteraccionesCambioEstrato(id);
        }
        public void ActualizarSolicitudCambioEstrato(IngresoTraslado ingreso, CambioEstrato CambioEstrato, TraficoTraslado transaccion)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.ActualizarSolicitudCambioEstrato(ingreso, CambioEstrato,transaccion);
        }
        public bool TransaccionEnGestionCambioEstrato(int id, String usrABackOffice)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.TransaccionEnGestionCambioEstrato(id, usrABackOffice);
        }
        public List<DatoConsultaDirecciones> ListaSeguimientosCambiodeEstratoCelula(string usrABackOffice)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSeguimientosCambiodeEstratoCelula(usrABackOffice);
        }
        public List<DatoConsultaDirecciones> ListGestionCambioDeEstrato(DateTime FechaInicial, DateTime FechaFinal, string usrTransac)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListGestionCambioDeEstrato(FechaInicial, FechaFinal, usrTransac);
        }
        //PROCESO LIBERACIONES DE HOME PASS
        public void InsertIngresoLiberacionHomePass(IngresoTraslado ingreso, LiberacionHomePass liberacion, TraficoTraslado transaccion)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.InsertIngresoLiberacionHomePass(ingreso, liberacion, transaccion);
        }
        public bool ExisteCuentaEscaladaLiberacionHomePass(decimal cuenta)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ExisteCuentaEscaladaLiberacionHomePass(cuenta);
        }
        public List<DatoConsultaDirecciones> ListaSolicitudesLiberacionesHomePass(string Usuario)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSolicitudesLiberacionesHomePass(Usuario);
        }
        public LiberacionHomePassCollection ListaInteraccionesLiberacionHomePass(int id)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaInteraccionesLiberacionHomePass(id);
        }
        public void ActualizarSolicitudLiberacionesHomePass(IngresoTraslado ingreso, LiberacionHomePass liberacion, TraficoTraslado transaccion)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.ActualizarSolicitudLiberacionesHomePass(ingreso, liberacion, transaccion);
        }
        public bool TransaccionEnGestionLiberacionHomePass(int id, String usrABackOffice)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.TransaccionEnGestionLiberacionHomePass(id, usrABackOffice);
        }
        public List<DatoConsultaDirecciones> ListaSeguimientosLiberacionHomePassCelula(string usrABackOffice)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSeguimientosLiberacionHomePassCelula(usrABackOffice);
        }
        public List<DatoConsultaDirecciones> ListGestionLiberacionHomePass(DateTime FechaInicial, DateTime FechaFinal, string usrTransac)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListGestionLiberacionHomePass(FechaInicial, FechaFinal, usrTransac);
        }
        //PROCESO GESTION DE MATRICES
        public void InsertIngresoGestionMatriz(IngresoTraslado ingreso, GestionMatriz matriz, TraficoTraslado transaccion)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.InsertIngresoGestionMatriz(ingreso, matriz, transaccion);
        }
        public bool ExisteCuentaEscaladaMatriz(decimal cuenta)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ExisteCuentaEscaladaMatriz(cuenta);
        }
        public List<DatoConsultaDirecciones> ListaSolicitudesCreaciondeMatriz(string Usuario)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSolicitudesCreaciondeMatriz(Usuario);
        }
        public GestionMatrizColleciton ListaInteraccionesMatrices(int id)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaInteraccionesMatrices(id);
        }
        public void ActualizarSolicitudMatrices(IngresoTraslado ingreso, GestionMatriz matriz, TraficoTraslado transaccion)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.ActualizarSolicitudMatrices(ingreso, matriz, transaccion);
        }
        public bool TransaccionCrearMatrizEnGestion(int id, String usrABackOffice)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.TransaccionCrearMatrizEnGestion(id, usrABackOffice);
        }
        public List<DatoConsultaDirecciones> ListaSeguimientosCrearMatrizCelula(string usrABackOffice)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSeguimientosCrearMatrizCelula(usrABackOffice);
        }
        public List<DatoConsultaDirecciones> ListaSolicitudesGestionMatriz(string Usuario)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSolicitudesGestionMatriz(Usuario);
        }
        public bool TransaccionGestionMatrizEnGestion(int id, String usrOut)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.TransaccionGestionMatrizEnGestion(id, usrOut);
        }
        public List<DatoConsultaDirecciones> ListaSeguimientosGestionMatricesCelula(string UsuarioOut)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSeguimientosGestionMatricesCelula(UsuarioOut);
        }
        public List<DatoConsultaDirecciones> ListGestionMatrices(DateTime FechaInicial, DateTime FechaFinal, string usrTransac)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListGestionMatrices(FechaInicial, FechaFinal, usrTransac);
        }
        //consultas administracion
        public List<DatoConsultaDirecciones> ListaGeneralIngresosTraslados(DateTime FechaInicial, DateTime FechaFinal)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaGeneralIngresosTraslados(FechaInicial, FechaFinal);
        }
        public List<DatoConsultaDirecciones> ListaGeneralIngresosCrearDireccion(DateTime FechaInicial, DateTime FechaFinal)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaGeneralIngresosCrearDireccion(FechaInicial, FechaFinal);
        }
        public List<DatoConsultaDirecciones> ListaGeneralIngresosCambiEstrato(DateTime FechaInicial, DateTime FechaFinal)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaGeneralIngresosCambiEstrato(FechaInicial, FechaFinal);
        }
        public List<DatoConsultaDirecciones> ListaGeneralIngresosLiberaciones(DateTime FechaInicial, DateTime FechaFinal)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaGeneralIngresosLiberaciones(FechaInicial, FechaFinal);
        }
        public List<DatoConsultaDirecciones> ListaGeneralIngresosmatrices(DateTime FechaInicial, DateTime FechaFinal)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaGeneralIngresosmatrices(FechaInicial, FechaFinal);
        }
        public List<DatoConsultaDirecciones> ConsultaIngresosTrasladosAsesor(decimal CuentaCliente)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ConsultaIngresosTrasladosAsesor(CuentaCliente);
        }
        public List<DatoConsultaDirecciones> ListaGeneralIngresosCrearDireccionAsesor(decimal CuentaCliente)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaGeneralIngresosCrearDireccionAsesor(CuentaCliente);
        }
        public List<DatoConsultaDirecciones> ListaGeneralIngresosCambiEstratoAsesor(decimal CuentaCliente)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaGeneralIngresosCambiEstratoAsesor(CuentaCliente);
        }
        public List<DatoConsultaDirecciones> ListaGeneralIngresosLiberacionesAsesor(decimal CuentaCliente)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaGeneralIngresosLiberacionesAsesor(CuentaCliente);
        }
        public List<DatoConsultaDirecciones> ListaGeneralIngresosmatricesAsesor(decimal CuentaCliente)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaGeneralIngresosmatricesAsesor(CuentaCliente);
        }
        //traslados fallidos
        public void InsertIngresoTrasladoFallido(IngresoTraslado ingreso, TrasladoFallido notaTraslado, TraficoTraslado transaccion)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            ingresoBusi.InsertIngresoTrasladoFallido(ingreso, notaTraslado, transaccion);
        }
        public List<DatoConsultaDirecciones> ConsultaTrasladoFallidoCliente(decimal CuentaCliente)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ConsultaTrasladoFallidoCliente(CuentaCliente);
        }
        public List<DatoConsultaDirecciones> ConsultaGeneralTrasladosFallidos(DateTime FechaInicial, DateTime FechaFinal)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ConsultaGeneralTrasladosFallidos(FechaInicial, FechaFinal);
        }
        public List<DatoConsultaDirecciones> ConsultaGestionTrasladoFallido(DateTime FechaInicial, DateTime FechaFinal, string Usuario)
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ConsultaGestionTrasladoFallido(FechaInicial, FechaFinal, Usuario);
        }

        #endregion

        #region maestroNodos
        public void InsertarNodo(MaestroNodo nodo)
        {
            MaestroNodoBusiness nodobusines = new MaestroNodoBusiness();
            nodobusines.InsertarNodo(nodo);
        }
        public bool ExisteNodo(string nodo)
        {
            MaestroNodoBusiness nodobusines = new MaestroNodoBusiness();
            return nodobusines.ExisteNodo(nodo);
        }
        public MaestroNodo GetInformacionNodo(string nodo)
        {
            MaestroNodoBusiness nodobusines = new MaestroNodoBusiness();
            return nodobusines.GetInformacionNodo(nodo);
        }
        public void ActualizarInformacionNodo(MaestroNodo nodo)
        {
            MaestroNodoBusiness nodobusines = new MaestroNodoBusiness();
            nodobusines.ActualizarInformacionNodo(nodo);
        }
        public MaestroNodoCollection ListaNodosCreados()
        {
            MaestroNodoBusiness nodobusines = new MaestroNodoBusiness();
            return nodobusines.ListaNodosCreados();
        }
        public MaestroNodo GetInformacionNodoId(int id)
        {
            MaestroNodoBusiness nodobusines = new MaestroNodoBusiness();
            return nodobusines.GetInformacionNodoId(id);
        }
        #endregion

        #region ActivacionClaroVideo
        public void InsertarClaroVideoInbound(ActivacionClaroVideo activacion)
        {
            ActivacionClaroVideoBusiness activacionBusi = new ActivacionClaroVideoBusiness();
            activacionBusi.InsertarClaroVideoInbound(activacion);
        }
        #endregion

        #region SiembraHD
        public List<CuentasSiembraHD> BuscarCuentaSiembraHD(decimal cuentacliente)
        {
            CuentasSiembraHDBusiness cuentasbusines = new CuentasSiembraHDBusiness();
            return cuentasbusines.BuscarCuentaSiembraHD(cuentacliente);
        }
        #endregion

        #region ActivacionSiembraHD
        public void InsertarSiembraHDInbound(SiembraHD siembra)
        {
            SiembraHDBusiness activacionbusiness = new SiembraHDBusiness();
            activacionbusiness.InsertarSiembraHDInbound(siembra);
        }

        public SmoRentaActual RentaActualPorCuentaCalRentas(string cuenta)
        {
            ActivacionSiembraHDService activacionService = new ActivacionSiembraHDService();
           return  activacionService.RentaActualPorCuentaCalRentas(cuenta);

        }

        public SmoTarifaActual TarifaActualDeDatos(string estrato, string voz, string tv, string internet)
        {
            ActivacionSiembraHDService activacionService = new ActivacionSiembraHDService();
            return activacionService.TarifaActualDeDatos(estrato,voz,tv,internet);

        }
        public void InsertarMejorasTecnicasInbound(MejorasTecnicas Mejoras)
        {
            SiembraHDBusiness activacionbusiness = new SiembraHDBusiness();
            activacionbusiness.InsertarMejorasTecnicasInbound(Mejoras);
        }
        public CargaBaseFoxInbound BuscarCuentaFoxInbound(decimal cuentacliente)
        {
            ActivacionSiembraHDService cuentasbusines = new ActivacionSiembraHDService();
            return cuentasbusines.BuscarCuentaFoxInbound(cuentacliente);
        }
        public void InsertarFoxInbound(GestionFoxInbound FoxInbound)
        {
            ActivacionSiembraHDService activacionbusiness = new ActivacionSiembraHDService();
            activacionbusiness.InsertarFoxInbound(FoxInbound);
        }
        #endregion

        #region BalanceScoreCard
        public BalanceScoreCard IndicadoresUsuario(decimal cedula)
        {
            BalanceScoreCardBusiness balancebusi = new BalanceScoreCardBusiness();
            return balancebusi.IndicadoresUsuario(cedula);
        }
        #endregion

        #region Graficos
        public List<Graficos> GraficoTrasladosGeneralAsesor(string UsuarioOut)
        {
            GraficosBusiness graficosbusi = new GraficosBusiness();
            return graficosbusi.GraficoTrasladosGeneralAsesor(UsuarioOut);
        }
        public List<Graficos> GraficoAsesorIngresosSac(string UsuarioOut)
        {
            GraficosBusiness graficosbusi = new GraficosBusiness();
            return graficosbusi.GraficoAsesorIngresosSac(UsuarioOut);
        }
        public List<Graficos> GraficoAsesorNotasIngresosSac(string UsuarioOut)
        {
            GraficosBusiness graficosbusi = new GraficosBusiness();
            return graficosbusi.GraficoAsesorNotasIngresosSac(UsuarioOut);
        }
        #endregion

        #region SiguienteMejorOferta
        public List<CuentasSiguienteMejorOferta> BuscarCuentaSMO(decimal cuentacliente)
        {
            CuentasSiembraHDBusiness cuentasbusines = new CuentasSiembraHDBusiness();
            return cuentasbusines.BuscarCuentaSMO(cuentacliente);
        }
        public void InsertarSMOInbound(SiguienteMejorOferta smo)
        {
            SiembraHDBusiness activacionbusiness = new SiembraHDBusiness();
            activacionbusiness.InsertarSMOInbound(smo);
        }
        #endregion

        #region Usabilidad
        public void InsertarUsabilidadInboundConvenio(UsabilidadConvenioInbound convenio)
        {
            UsabilidadBusiness UsabilidaBusi = new UsabilidadBusiness();
            UsabilidaBusi.InsertarUsabilidadInboundConvenio(convenio);
        }
        public void InsertarUsabilidadCuentaInbound(UsabilidadBusquedaCuentaInbound CuentaInbound)
        {
            UsabilidadBusiness UsabilidaBusi = new UsabilidadBusiness();
            UsabilidaBusi.InsertarUsabilidadCuentaInbound(CuentaInbound);
        }
        #endregion

        #region DistribucionBlending
        //aqui se ejecuta los procesos de outbound blending
        public ClientesTodo TraerInformacionCuentaBlending(int idAsesor, string formulario, string aliado, string operacion, string campana)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraerInformacionCuentaBlending(idAsesor,formulario,aliado,operacion,campana);

        }
        public BlendingFueraNivel TraerInformacionCuentaFueraNiveles(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraerInformacionCuentaFueraNiveles(CuentaCliente);

        }
        public void EliminaCuentaGestionadaDistribucion(DistribucionBlending Registro)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            distribucionesBlendingService.EliminaCuentaGestionadaDistribucion(Registro);
        }
        public void InsertarCuentaColaDistribucionBlending(DistribucionBlending Registro)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            distribucionesBlendingService.InsertarCuentaColaDistribucionBlending(Registro);
        }
        public void InsertarRegistroFueraNiveles(GBPFueraNiveles PFueraNivel)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            distribucionesBlendingService.InsertarRegistroFueraNiveles(PFueraNivel);
        }
        public void ActualizarGestionFueraNiveles(GBPFueraNiveles PFueraNivel)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            distribucionesBlendingService.ActualizarGestionFueraNiveles(PFueraNivel);

        }
        public bool ValidarCuentaEnFueraNiveles(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.ValidarCuentaEnFueraNiveles(CuentaCliente);
        }

        public GBPFueraNiveles TraeInformacionActualFueraNiveles(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraeInformacionActualFueraNiveles(CuentaCliente);
        }
        public List<GBLFueraNiveles> TraeListaGestionUsuarioFueraNiveles(string Usuario)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraeListaGestionUsuarioFueraNiveles(Usuario);
        }
        public List<GBPFueraNiveles> TraeListaSeguimientosUsuarioFueraNiveles(string Usuario)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraeListaSeguimientosUsuarioFueraNiveles(Usuario);
        }
        public ClientesTodo  AsignarIdCuentaDistribucionBlending(decimal CuentaCliente, string Formulario, string Aliado, string Operacion, string Campana, int Id)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.AsignarIdCuentaDistribucionBlending(CuentaCliente,Formulario,Aliado,Operacion,Campana,Id);
        }
        public GBPFueraNiveles TraerDatosCuentaSelectFueraNivel(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraerDatosCuentaSelectFueraNivel(CuentaCliente);

        }
        public int CantidadToquesCuentaFueraNiveles(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.CantidadToquesCuentaFueraNiveles(CuentaCliente);
        }
        public GBLFueraNiveles TraeUltimaGestionCuenta(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraeUltimaGestionCuenta(CuentaCliente);
        }
        public List<GBPFueraNivelesCA> ConsultaAdminFueraNivelesP(DateTime FechaInicial, DateTime FechaFinal)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.ConsultaAdminFueraNivelesP(FechaInicial,FechaFinal);
        }
        public List<GBLFueraNivelesCA> ConsultaAdminFueraNivelesL(DateTime FechaInicial, DateTime FechaFinal)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.ConsultaAdminFueraNivelesL(FechaInicial, FechaFinal);
        }

        //GESTION BLENDING RENTABILIZACION
        public GBC_Rentabilizacion TraerInformacionCuentaRentabilizacion(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraerInformacionCuentaRentabilizacion(CuentaCliente);
        }
        public void InsertarRegistroRentabilizacion(GBPRentabilizacion PRentabilizacion)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            distribucionesBlendingService.InsertarRegistroRentabilizacion(PRentabilizacion);
        }
        public void ActualizarGestionRentabilizacion(GBPRentabilizacion PRentabilizacion)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            distribucionesBlendingService.ActualizarGestionRentabilizacion(PRentabilizacion);
        }
        public bool ValidarCuentaEnRentabilizacion(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.ValidarCuentaEnRentabilizacion(CuentaCliente);
        }
        public GBPRentabilizacion TraeInformacionActualRentabilizacion(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraeInformacionActualRentabilizacion(CuentaCliente);
        }
        public List<GBLRentabilizacion> TraeListaGestionUsuarioRentabilizacion(string Usuario)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraeListaGestionUsuarioRentabilizacion(Usuario);
        }
        public List<GBPRentabilizacion> TraeListaSeguimientosUsuarioRentabilizacion(string Usuario)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraeListaSeguimientosUsuarioRentabilizacion(Usuario);
        }
        public GBPRentabilizacion TraerDatosCuentaSelectRentabilizacion(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraerDatosCuentaSelectRentabilizacion(CuentaCliente);
        }
        public int CantidadToquesCuentaRentabilizacion(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.CantidadToquesCuentaRentabilizacion(CuentaCliente);
        }
        public GBLRentabilizacion TraeUltimaGestionCuentaRentabilizacion(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraeUltimaGestionCuentaRentabilizacion(CuentaCliente);
        }
        public List<GBPRentabilizacionCA> ConsultaAdminRentabilizacionP(DateTime FechaInicial, DateTime FechaFinal)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.ConsultaAdminRentabilizacionP(FechaInicial,FechaFinal);
        }
        public List<GBLRentabilizacionCA> ConsultaAdminRentabilizacionL(DateTime FechaInicial, DateTime FechaFinal)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.ConsultaAdminRentabilizacionL(FechaInicial, FechaFinal);
        }

        //GESTION BLENDING PRODUCTO
        public GBCProducto TraerInformacionCuentaProducto(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraerInformacionCuentaProducto(CuentaCliente);
        }
        public void InsertarRegistroProducto(GBPProducto GBPProducto)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            distribucionesBlendingService.InsertarRegistroProducto(GBPProducto);
        }
        public void ActualizarGestionProducto(GBPProducto GBPProducto)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            distribucionesBlendingService.ActualizarGestionProducto(GBPProducto);
        }
        public bool ValidarCuentaEnProducto(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.ValidarCuentaEnProducto(CuentaCliente);
        }
        public GBPProducto TraeInformacionActualProducto(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraeInformacionActualProducto(CuentaCliente);
        }
        public List<GBLProducto> TraeListaGestionUsuarioProucto(string Usuario)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraeListaGestionUsuarioProucto(Usuario);
        }
        public List<GBPProducto> TraeListaSeguimientosUsuarioProducto(string Usuario)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraeListaSeguimientosUsuarioProducto(Usuario);
        }
        public GBPProducto TraerDatosCuentaSelectProducto(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraerDatosCuentaSelectProducto(CuentaCliente);
        }
        public int CantidadToquesCuentaProducto(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.CantidadToquesCuentaProducto(CuentaCliente);
        }
        public GBLProducto TraeUltimaGestionCuentaProducto(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraeUltimaGestionCuentaProducto(CuentaCliente);
        }
        public List<GBPProductoCA> ConsultaAdminProductoP(DateTime FechaInicial, DateTime FechaFinal)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.ConsultaAdminProductoP(FechaInicial, FechaFinal);
        }
        public List<GBLProductoCA> ConsultaAdminProductoL(DateTime FechaInicial, DateTime FechaFinal)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.ConsultaAdminProductoL(FechaInicial, FechaFinal);
        }

        //GESTION BLENDING DOCSIS Y OVERLAP
        public GBCDocsis TraerInformacionCuentaDocsis(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraerInformacionCuentaDocsis(CuentaCliente);
        }
        public void InsertarRegistroDocsis(GBPDocsis GBPDocsis)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            distribucionesBlendingService.InsertarRegistroDocsis(GBPDocsis);
        }
        public void ActualizarGestionDocsis(GBPDocsis GBPDocsis)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            distribucionesBlendingService.ActualizarGestionDocsis(GBPDocsis);
        }
        public bool ValidarCuentaEnDocsis(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.ValidarCuentaEnDocsis(CuentaCliente);
        }
        public GBPDocsis TraeInformacionActualDocsis(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraeInformacionActualDocsis(CuentaCliente);
        }
        public List<GBLDocsis> TraeListaGestionUsuarioDocsis(string Usuario)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraeListaGestionUsuarioDocsis(Usuario);
        }
        public List<GBPDocsis> TraeListaSeguimientosUsuarioDocsis(string Usuario)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraeListaSeguimientosUsuarioDocsis(Usuario);
        }
        public GBPDocsis TraerDatosCuentaSelectDocsis(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraerDatosCuentaSelectDocsis(CuentaCliente);
        }
        public int CantidadToquesCuentaDocsis(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.CantidadToquesCuentaDocsis(CuentaCliente);
        }
        public GBLDocsis TraeUltimaGestionCuentaDocsis(decimal CuentaCliente)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.TraeUltimaGestionCuentaDocsis(CuentaCliente);
        }
        public List<GBPDocsisCA> ConsultaAdminDocsisP(DateTime FechaInicial, DateTime FechaFinal)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.ConsultaAdminDocsisP(FechaInicial, FechaFinal);
        }
        public List<GBLDocsisCA> ConsultaAdminDocsisL(DateTime FechaInicial, DateTime FechaFinal)
        {
            DistribucionBlendingService distribucionesBlendingService = new DistribucionBlendingService();
            return distribucionesBlendingService.ConsultaAdminDocsisL(FechaInicial, FechaFinal);
        }
        public List<ConsultaBlendingFormularioDestinoReturnViewModel> ConsultaBlendingFormularioDestino(string aliado)
        {
            DistribucionBlendingBusiness distribucionesBlendingBusiness = new DistribucionBlendingBusiness();
            return distribucionesBlendingBusiness.ConsultaBlendingFormularioDestino(aliado);
        }
        #endregion

        #region MejorasTecnicas
        public List<CuentasMejorasTecnicas> BuscarCuentaMejorasTecnicas(decimal cuentacliente)
        {
            CuentasSiembraHDBusiness cuentasbusines = new CuentasSiembraHDBusiness();
            return cuentasbusines.BuscarCuentaMejorasTecnicas(cuentacliente);
        }
        #endregion

        #region MultiPlay
        public MultiplayCargue BuscarDatosMultiplay(decimal cuentacliente)
        {
            MultiPlayService Multi = new MultiPlayService();
            return Multi.BuscarDatosMultiplay(cuentacliente);
        }
        public void InsertarMultiPlay(MultiPlayRegistro multiplay)
        {
            MultiPlayService Multi = new MultiPlayService();
            Multi.InsertarMultiPlay(multiplay);
        }
        public void EliminaCuentaDatosMultiplay(decimal Id_Cuenta, decimal Cuenta)
        {
            MultiPlayService Multi = new MultiPlayService();
            Multi.EliminaCuentaDatosMultiplay(Id_Cuenta, Cuenta);
        }
        public List<MultiPlayRegistro> ConsultaAdminBasePresidencial(DateTime inicial, DateTime final)
        {
            MultiPlayService Multi = new MultiPlayService();
            return Multi.ConsultaAdminBasePresidencial(inicial, final);
        }

        #endregion

        #region Procesos Mec
        public void IsertarMonitoreo(MecMonitoreosP Monitoreo)
        {
            MecService mecService = new MecService();
            mecService.IsertarMonitoreo(Monitoreo);

        }
        public List<MecProcesos> ListaProcesosMec()
        {
            MecService mecService = new MecService();
            return mecService.ListaProcesosMec();
        }
        public List<MecLineas> ListaLineasMec(int IdProceso)
        {
            MecService mecService = new MecService();
            return mecService.ListaLineasMec(IdProceso);
        }
        public List<MecListasDistribucion> ListasCorreosMec(int IdLinea)
        {
            MecService mecService = new MecService();
            return mecService.ListasCorreosMec(IdLinea);
        }
        public List<MecTipoAlarmas> ListaTipoAlarmasMec()
        {
            MecService mecService = new MecService();
            return mecService.ListaTipoAlarmasMec();
        }
        public MecListasDistribucion DestinatariosMec(int IdLista)
        {
            MecService mecService = new MecService();
            return mecService.DestinatariosMec(IdLista);
        }
        public void ActualizarMonitoreo(MecMonitoreosP Monitoreo)
        {
            MecService mecService = new MecService();
            mecService.ActualizarMonitoreo(Monitoreo);
        }
        public List<MecMonitoreosP> ConsultaAdminMonitoreosPrincipal(DateTime FechaInicial, DateTime FechaFinal)
        {
            MecService mecService = new MecService();
            return mecService.ConsultaAdminMonitoreosPrincipal(FechaInicial, FechaFinal);
        }
        public List<MecMonitoreosL> ConsultaAdminMonitoreosLog(DateTime FechaInicial, DateTime FechaFinal)
        {
            MecService mecService = new MecService();
            return mecService.ConsultaAdminMonitoreosLog(FechaInicial, FechaFinal);
        }
        public MecMonitoreosP ConsultarMonitoreoPorId(int IdMonitoreo)
        {
            MecService mecService = new MecService();
            return mecService.ConsultarMonitoreoPorId(IdMonitoreo);
        }
        public List<MecMonitoreosP> ConsultaAgenteMonitoreosPrincipal(DateTime FechaInicial, DateTime FechaFinal, string UsuarioGestion)
        {
            MecService mecService = new MecService();
            return mecService.ConsultaAgenteMonitoreosPrincipal(FechaInicial, FechaFinal, UsuarioGestion);
        }

        public void RegistrarMacroproceso(MecProcesos proceso)
        {
            MecService mecService = new MecService();
            mecService.RegistrarMacroproceso(proceso);
        }
        public void ActualizarMacroproceso(MecProcesos proceso)
        {
            MecService mecService = new MecService();
            mecService.ActualizarMacroproceso(proceso);
        }
        public void RegistrarLinea(MecLineas Linea)
        {
            MecService mecService = new MecService();
            mecService.RegistrarLinea(Linea);
        }
        public void ActualizarLinea(MecLineas Linea)
        {
            MecService mecService = new MecService();
            mecService.ActualizarLinea(Linea);
        }
        public void RegistrarListaDistribucion(MecListasDistribucion ListaD)
        {
            MecService mecService = new MecService();
            mecService.RegistrarListaDistribucion(ListaD);

        }
        public void ActualizarListaDistribucion(MecListasDistribucion ListaD)
        {
            MecService mecService = new MecService();
            mecService.ActualizarListaDistribucion(ListaD);
        }
        public void RegistrarTipoAlarma(MecTipoAlarmas Alarma)
        {
            MecService mecService = new MecService();
            mecService.RegistrarTipoAlarma(Alarma);

        }
        public void ActualizarTipoAlarmas(MecTipoAlarmas Alarma)
        {
            MecService mecService = new MecService();
            mecService.ActualizarTipoAlarmas(Alarma);
        }
        public List<MecProcesos> ListaProcesosMecAdmin()
        {
            MecService mecService = new MecService();
            return mecService.ListaProcesosMecAdmin();
        }
        public List<MecLineas> ListaLineasMecAdmin(int IdProceso)
        {
            MecService mecService = new MecService();
            return mecService.ListaLineasMecAdmin(IdProceso);
        }
        public List<MecListasDistribucion> ListasCorreosMecAdmin(int IdLinea)
        {
            MecService mecService = new MecService();
            return mecService.ListasCorreosMecAdmin(IdLinea);
        }
        public List<MecTipoAlarmas> ListaTipoAlarmasMecAdmin()
        {
            MecService mecService = new MecService();
            return mecService.ListaTipoAlarmasMecAdmin();
        }
        public MecProcesos ProcesoPorId(decimal IdProceso)
        {
            MecService mecService = new MecService();
            return mecService.ProcesoPorId(IdProceso);

        }
        public MecLineas LineaPorId(decimal IdLinea)
        {
            MecService mecService = new MecService();
            return mecService.LineaPorId(IdLinea);

        }
        public MecListasDistribucion ListaCorreosPorId(decimal IdLista)
        {
            MecService mecService = new MecService();
            return mecService.ListaCorreosPorId(IdLista);

        }
        #endregion


        #region CierreCiclo



        #endregion

    }
}
