using System;
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
    public class WebService : IWebService, ILoginService, IInboundService, IMaestrosService, IBlendingService,IMarcacionesService, INotificacionesBuenServicioService, ICasosCelulaService, ICasosAdminService,ITrasladosService,IMaestroNodoService,IActivacionClaroVideoService,IActivacionSiembraHDService
    {



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


        public void RegistrarIngresoInbound(ClientesTodo infoCliente, Ingreso ingreso, string observacion)
        {
            InboundService inboundService = new InboundService();
             inboundService.RegistrarIngresoInbound(infoCliente, ingreso, observacion);
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

        public void  ActualizarIngresoInbound(Ingreso ingreso, string observacion, string llamadaCliente)
        {
            InboundService inboundService = new InboundService();
            inboundService.ActualizarIngresoInbound(ingreso, observacion, llamadaCliente);
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
        #endregion

        #region BlendingService

        public ClientesTodo TraerMisDatosClienteAutomaticos(int idAsesor, string gestionBlendingActual)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerMisDatosClienteAutomaticos(idAsesor, gestionBlendingActual);
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

        public GestionOutbound TraerGestionOutboundInfoDeCuenta(int cuenta, string gestion)
        {
            BlendingService blendingService = new BlendingService();
            return blendingService.TraerGestionOutboundInfoDeCuenta(cuenta, gestion);
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


        public void ActualizarIngresoPorCelula(Ingreso ingreso, string aplicaRechazo, string razonRechazo, string notas)
        {
            CasosCelulaService casosCelulaService = new CasosCelulaService();
            casosCelulaService.ActualizarIngresoPorCelula(ingreso, aplicaRechazo, razonRechazo, notas);
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

        public List<DatoConsultaPaloteo> ListaPaloteo(DateTime inicial, DateTime final)
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
        public List<DatoConsultaDirecciones> ListaSolicitudesCrearDireccion()
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSolicitudesCrearDireccion();
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
        public List<DatoConsultaDirecciones> ListaDireccionesCreadasOutbound()
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaDireccionesCreadasOutbound();
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
        public List<DatoConsultaDirecciones> ListaSolicitudesCambioEstrato()
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSolicitudesCambioEstrato();
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
        public List<DatoConsultaDirecciones> ListaSolicitudesLiberacionesHomePass()
        {
            IngresoTrasladoBusiness ingresoBusi = new IngresoTrasladoBusiness();
            return ingresoBusi.ListaSolicitudesLiberacionesHomePass();
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
        #endregion
        
    }
}
