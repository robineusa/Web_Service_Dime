using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Data.Context;
using Telmexla.Servicios.DIME.IData;

namespace Telmexla.Servicios.DIME.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DimeContext dimeContext;

        public UnitOfWork(DimeContext dimeContext)
        {
            this.dimeContext = dimeContext;
            accesos = new AccesoRepository(this.dimeContext);
            clientesTodo = new ClientesTodoRepository(this.dimeContext);
            gestionesOutbound = new GestionOutboundRepository(this.dimeContext);
            conveniosElectronicos = new ConvenioElectronicoRepository(this.dimeContext);
            docsisOverlaps = new DocsisOverlapRepository(this.dimeContext);
            usuarios = new UsuarioRepository(this.dimeContext);
            claroVideos = new ClaroVideoRepository(this.dimeContext);
            cierreCiclos = new CierreCicloRepository(this.dimeContext);
            maestroMarcaciones = new MaestroMarcacioneRepository(this.dimeContext);
            notificacionesBuenServicio = new NotificacionesBuenServicioRepository(this.dimeContext);
            logConveniosElectronicos = new LogConvenioElectronicoRepository(this.dimeContext);
            logDocsisOverlaps = new LogDocsisOverlapRepository(this.dimeContext);
            logClaroVideos = new LogClaroVideoRepository(this.dimeContext);
            logCierreCiclos = new LogCierreCicloRepository(this.dimeContext);
            ingresos = new IngresoRepository(this.dimeContext);
            notasIngresos = new NotasIngresoRepository(this.dimeContext);
            pqrMaestroCodigos = new PqrMaestroCodCierreRepository(this.dimeContext);
            rechazos = new RechazoRepository(this.dimeContext);
            ingresoTraslados = new IngresoTrasladoRepository(this.dimeContext);
            notasTraslados = new NotasTrasladoRepository(this.dimeContext);
            maestroNodos = new MaestroNodoRepository(this.dimeContext);
            activacionClaroVideo = new ActivacionClaroVideoRepository(this.dimeContext);
            CuentasSiembraHD = new CuentasSiembraHDRepository(this.dimeContext);
            ActivacionSiembraHD = new SiembraHDRepository(this.dimeContext);
            cambioEstratos = new CambioEstratoRepository(this.dimeContext);
            traficoTraslados = new TraficoTrasladoRepository(this.dimeContext);
            liberacionesHomePass = new LiberacionHomePassRepository(this.dimeContext);
            gestionMatrices = new GestionMatrizRepository(this.dimeContext);
            ingresosSoporte = new IngresoSoporteRepository(this.dimeContext);
            usuariosNotificados = new UsuariosNotificadosRepository(this.dimeContext);
            balanceScoreCards = new BalaceScoreCardRepository(this.dimeContext);
            CuentaSMO = new CuentasSiguienteMejorOfertaRepository(this.dimeContext);
            SMO = new SiguienteMejorOfertaRepository(this.dimeContext);
            trasladosFallidos = new TrasladoFallidoRepository(this.dimeContext);
            UsabilidadAlertasInbound = new UsabilidadAlertasInboundRepository(this.dimeContext);
            Departamentos = new DepartamentoRepository(this.dimeContext);
            UsabilidadCuentaInbound = new UsabilidadBusquedaCuentaInboundRepository(this.dimeContext);
            SkillsUsuariosBlending = new SkillsUsuariosBlendingRepository(this.dimeContext);
            blendingFueraNiveles = new BlendingFueraNivelRepository(this.dimeContext);
            distribucionesBlending = new DistribucionBlendingRepository(this.dimeContext);
            GBPFueradeNiveles = new GBPFueraNivelesRepository(this.dimeContext);
            GBLFueradeNiveles = new GBLFueraNivelesRepository(this.dimeContext);
            GBLRentabilizacion = new GBLRentabilizacionRepository(this.dimeContext);
            GBPRentabilizacion = new GBPRentabilizacionRepository(this.dimeContext);
            GBCRentabilizacion = new GBCRentabilizacionRepository(this.dimeContext);
            CuentasMejorasTecnicas = new CuentasMejorasTecnicasRepository(this.dimeContext);
            MejorasTecnicas = new MejorasTecnicasRepository(this.dimeContext);
            GBPProducto = new GBPProductoRepository(this.dimeContext);
            GBLProducto = new GBLProductoRepository(this.dimeContext);
            GBCProducto = new GBCProductoRepository(this.dimeContext);
            GBPDocsis = new GBPDocsisRepository(this.dimeContext);
            GBLDocsis = new GBLDocsisRepository(this.dimeContext);
            GBCDocsis = new GBCDocsisRepository(this.dimeContext);
            Retencion = new RetencionRepository(this.dimeContext);
            MultiplayCargue = new MultiplayCargueRepository(this.dimeContext);
            MultiPlayRegistro = new MultiPlayRegistroRepository(this.dimeContext);
            MecMonitoreosP = new MecMonitoreosPRepository(this.dimeContext);
            MecMonitoreosL = new MecMonitoreosLRepository(this.dimeContext);
            MecProcesos = new MecProcesosRepository(this.dimeContext);
            MecLineas = new MecLineasRepository(this.dimeContext);
            MecListasDistribucion = new MecListasDistribucionRepository(this.dimeContext);
            MecTipoAlarmas = new MecTipoAlarmasRepository(this.dimeContext);
            CargaBaseFoxInbound = new CargueBaseFoxInboundRepository(this.dimeContext);
            GestionFoxInbound = new GestionFoxInboundRepository(this.dimeContext);
            BELSolicitudes = new BELSolicitudesRepository(this.dimeContext);
            BEMDetalleDeGestion = new BEMDetalleDeGestionRepository(this.dimeContext);
            BEMDetalleEscalamientos = new BEMDetalleEscalamientosRepository(this.dimeContext);
            BEMDistribuciones = new BEMDistribucionesRepository(this.dimeContext);
            BEMRazonMalEscalamiento = new BEMRazonMalEscalamientoRepository(this.dimeContext);
            BEMTipoDeEscalamientos = new BEMTipoDeEscalamientosRepository(this.dimeContext);
            BEPSolicitudes = new BEPSolicitudesRepository(this.dimeContext);
            NodosZonificados = new NodosZonificadosRepository(this.dimeContext);
            CcGestionResidencialPredictivo = new CcGestionResidencialPredictivoRepository(this.dimeContext);
            CcSegundaTipificacion = new CcSegundaTipificacionRepository(this.dimeContext);
            RecurrenciaCargaBase = new RecurrenciaCargaBaseRepository(this.dimeContext);
            GPrincipalRecurrencia = new GPrincipalRecurrenciaRepository(this.dimeContext);
            GLogRecurrencia = new GLogRecurrenciaRepository(this.dimeContext);
            BIPBitacoraIncidentes = new BIPBitacoraIncidentesRepository(this.dimeContext);
            BILBitacoraIncidentes = new BILBitacoraIncidentesRepository(this.dimeContext);
            BIMGerencias = new BIMGerenciasRepository(this.dimeContext);
            BIMAliados = new BIMAliadosRepository(this.dimeContext);
            BIMOperaciones = new BIMOperacionesRepository(this.dimeContext);
            BIPIncidentesPorOperacion = new BIPIncidentesPorOperacionRepository(this.dimeContext);
            BIMTipoFalla = new BIMTipoFallaRepository(this.dimeContext);
            BIMPrioridades = new BIMPrioridadesRepository(this.dimeContext);
            BIMHerramientas = new BIMHerramientasRepository(this.dimeContext);
            AccesosXLinea = new AccesosXLineaRepository(this.dimeContext);
            POMSolicitudes = new POMSolicitudesRepository(this.dimeContext);
            FidelizacionMaestroServicios = new FidelizacionMaestroServiciosRepository(this.dimeContext);
            FidelizacionMotivosCancelacion = new FidelizacionMotivosCancelacionRepository(this.dimeContext);
            FidelizacionSubmotivosCancelacion = new FidelizacionSubmotivosCancelacionRepository(this.dimeContext);
            FidelizacionOtrosOfrecimientos = new FidelizacionOtrosOfrecimientosRepository(this.dimeContext);
            FidelizacionTipificacion = new FidelizacionTipificacionRepository(this.dimeContext);
            FidelizacionRecursiva = new FidelizacionRecursivaRepository(this.dimeContext);
            FidelizacionRegistro = new FidelizacionRegistroRepository(this.dimeContext);
            VIPSolicitudes = new VIPSolicitudesRepository(this.dimeContext);
            VILSolicitudes = new VILSolicitudesRepository(this.dimeContext);
            VIPSolicitudesPorEquipo = new VIPSolicitudesPorEquipoRepository(this.dimeContext);
            VIMTipoDeEquipos = new VIMTipoDeEquiposRepository(this.dimeContext);
            VIMTipoDeRequerimiento = new VIMTipoDeRequerimientoRepository(this.dimeContext);
            VIMGestion = new VIMGestionRepository(this.dimeContext);
            VIMSubrazon = new VIMSubrazonRepository(this.dimeContext);
            VIMAliadoTecnico = new VIMAliadoTecnicoRepository(this.dimeContext);
            GPrincipalRecurrenciaInbound = new GPrincipalRecurrenciaInboundRepository(this.dimeContext);
            GLogRecurrenciaInbound = new GLogRecurrenciaInboundRepository(this.dimeContext);
            InventarioEquipos = new InventarioEquiposRepository(this.dimeContext);
            BSCAdministracionBalanced = new BSCAdministracionBalancedRepository(this.dimeContext);
            BSCAdministracionBalancedLog = new BSCAdministracionBalancedLogRepository(this.dimeContext);
            VisitasAutorizadas = new VisitasAutorizadasRepository(this.dimeContext);
            VAMotivosSolicitud = new VAMotivosSolicitudRepository(this.dimeContext);
            FidelizacionOtrosCampos = new FidelizacionOtrosCamposRepository(this.dimeContext);
            FidelizacionRegistroCampos = new FidelizacionRegistroCamposRepository(this.dimeContext);
            FidelizacionRecursivaVista = new FidelizacionRecursivaVistaRepository(this.dimeContext);
            Arbol = new ArbolRepository(this.dimeContext);
            Nodo = new NodoRepository(this.dimeContext);
            RSPSeguimientos = new RSPSeguimientosRepository(this.dimeContext);
            RSLSeguimientos = new RSLSeguimientosRepository(this.dimeContext);
            RSMArboles = new RSMArbolesRepository(this.dimeContext);
            BACActualizarDatos = new BACActualizarDatosRepository(this.dimeContext);
            BAPActualizarDatos = new BAPActualizarDatosRepository(this.dimeContext);
            IMGOfertasComeciales = new IMGOfertasComecialesRepository(this.dimeContext);
            NotificacionSignalR = new NotificacionSignalRRepository(this.dimeContext);
            UsuariosNotificadosSignalR = new UsuariosNotificadosSignalRRepository(this.dimeContext);
            CEPAsigDesconexiones = new CEPAsigDesconexionesRepository(this.dimeContext);
            CEPDesconexiones = new CEPDesconexionesRepository(this.dimeContext);
            CELDesconexiones = new CELDesconexionesRepository(this.dimeContext);
            CEMArbolesDeGestion = new CEMArbolesDeGestionRepository(this.dimeContext);

        }
        public IAccesosXLineaRepository AccesosXLinea
        {
            get; private set;
        }
        public ICcSegundaTipificacionRepository CcSegundaTipificacion
        {
            get; private set;
        }
        public IIngresoSoporteRepository ingresosSoporte
        {
            get; private set;
        }
        public IRechazoRepository rechazos
        {
            get; private set;
        }
        public IPqrMaestroCodCierreRepository pqrMaestroCodigos
        {
            get; private set;
        }
        public INotasIngresoRepository notasIngresos
        {
            get; private set;
        }
        public IIngresoRepository ingresos
        {
            get; private set;
        }

        public ILogConvenioElectronicoRepository logConveniosElectronicos
        {
            get; private set;
        }

        public ILogDocsisOverlapRepository logDocsisOverlaps
        {
            get; private set;
        }

        public ILogClaroVideoRepository logClaroVideos
        {
            get; private set;
        }

        public ILogCierreCicloRepository logCierreCiclos
        {
            get; private set;
        }

        public IConvenioElectronicoRepository conveniosElectronicos
        {
            get; private set;
        }

        public IDocsisOverlapRepository docsisOverlaps
        {
            get; private set;
        }

        public IUsuarioRepository usuarios
        {
            get; private set;
        }
        public IClaroVideoRepository claroVideos
        {
            get; private set;
        }
        public ICierreCicloRepository cierreCiclos
        {
            get; private set;
        }
        public IMaestroMarcacioneRepository maestroMarcaciones
        {
            get; private set;
        }
        public INotificacionesBuenServicioRepository notificacionesBuenServicio
        {
            get; private set;
        }

        public IAccesoRepository accesos
        {
            get; private set;
        }

        public IClientesTodoRespository clientesTodo
        {
            get; private set;
        }

        public IGestionOutboundRepository gestionesOutbound
        {
            get; private set;
        }
        public IIngresoTrasladoRepository ingresoTraslados
        {
            get; private set;
        }
        public INotasTrasladoRepository notasTraslados
        {
            get; private set;
        }
        public IMaestroNodoRepository maestroNodos
        {
            get; private set;
        }
        public IActivacionClaroVideoRepository activacionClaroVideo
        {
            get; private set;
        }
        public ICuentasSiembraHDRepository CuentasSiembraHD
        {
            get; private set;
        }
        public ISiembraHDRepository ActivacionSiembraHD
        {
            get; private set;
        }
        public ICambioEstratoRepository cambioEstratos
        {
            get; private set;
        }
        public ITraficoTrasladoRepository traficoTraslados
        {
            get; private set;
        }
        public ILiberacionHomePassRepository liberacionesHomePass
        {
            get; private set;
        }
        public IGestionMatrizRepository gestionMatrices
        {
            get; private set;
        }
        public IUsuariosNotificadosRepository usuariosNotificados
        {
            get; private set;
        }
        public IBalanceScoreCardRepository balanceScoreCards
        {
            get; private set;
        }
        public ICuentasSiguienteMejorOfertaRepository CuentaSMO
        {
            get; private set;
        }
        public ISiguienteMejorOfertaRepository SMO
        {
            get; private set;
        }
        public ITrasladoFallidoRepository trasladosFallidos
        {
            get; private set;
        }
        public IUsabilidadAlertasInboundRepository UsabilidadAlertasInbound
        {
            get; private set;
        }
        public IDepartamentoRepository Departamentos
        {
            get; private set;
        }
        public IUsabilidadBusquedaCuentaInboundRepositiry UsabilidadCuentaInbound
        {
            get; private set;
        }
        public ISkillsUsuariosBlendingRepository SkillsUsuariosBlending
        {
            get; private set;
        }
        public IBlendingFueraNivelRepository blendingFueraNiveles
        {
            get; private set;
        }
        public IDistribucionBlendingRepository distribucionesBlending
        {
            get; private set;
        }
        public IGBPFueraNivelesRepository GBPFueradeNiveles
        {
            get; private set;
        }
        public IGBLFueraNivelesRepository GBLFueradeNiveles
        {
            get; private set;
        }
        public IGBLRentabilizacionRepository GBLRentabilizacion
        {
            get; private set;
        }
        public IGBPRentabilizacionRepository GBPRentabilizacion
        {
            get; private set;
        }
        public IGBCRentabilizacionRepository GBCRentabilizacion
        {
            get; private set;
        }
        public ICuentasMejorasTecnicasRepository CuentasMejorasTecnicas
        {
            get; private set;
        }
        public IMejorasTecnicasRepository MejorasTecnicas
        {
            get; private set;
        }

        public IGBPProductoRepository GBPProducto
        {
            get; private set;
        }
        public IGBLProductoRepository GBLProducto
        {
            get; private set;
        }
        public IGBCProductoRepository GBCProducto
        {
            get; private set;
        }
        public IGBPDocsisRepository GBPDocsis
        {
            get; private set;
        }
        public IGBLDocsisRepository GBLDocsis
        {
            get; private set;
        }
        public IGBCDocsisRepository GBCDocsis
        {
            get; private set;
        }
        public IRetencionRepository Retencion
        {
            get; private set;
        }
        public IMultiplayCargueRepository MultiplayCargue
        {
            get; private set;
        }
        public IMultiPlayRegistroRepository MultiPlayRegistro
        {
            get; private set;
        }

        public IMecMonitoreosPRepository MecMonitoreosP
        {
            get; private set;
        }
        public IMecMonitoreosLRepository MecMonitoreosL
        {
            get; private set;
        }
        public IMecProcesosRepository MecProcesos
        {
            get; private set;
        }
        public IMecLineasRepository MecLineas
        {
            get; private set;
        }
        public IMecListasDistribucionRepository MecListasDistribucion
        {
            get; private set;
        }
        public IMecTipoAlarmasRepository MecTipoAlarmas
        {
            get; private set;
        }
        public ICargueBaseFoxInboundRepository CargaBaseFoxInbound
        {
            get; private set;
        }
        public IGestionFoxInboundRepository GestionFoxInbound
        {
            get; private set;
        }
        public IBELSolicitudesRepository BELSolicitudes
        {
            get; private set;
        }

        public IBEMDetalleDeGestionRepository BEMDetalleDeGestion
        {
            get; private set;
        }
        public IBEMDetalleEscalamientosRepository BEMDetalleEscalamientos
        {
            get; private set;
        }
        public IBEMDistribucionesRepository BEMDistribuciones
        {
            get; private set;
        }
        public IBEMRazonMalEscalamientoRepository BEMRazonMalEscalamiento
        {
            get; private set;
        }
        public IBEMTipoDeEscalamientosRepository BEMTipoDeEscalamientos
        {
            get; private set;
        }
        public IBEPSolicitudesRepository BEPSolicitudes
        {
            get; private set;
        }
        public INodosZonificadosRepository NodosZonificados
        {
            get; private set;
        }

        public ICcGestionResidencialPredictivoRepository CcGestionResidencialPredictivo
        {
            get; private set;
        }
        public IRecurrenciaCargaBaseRepository RecurrenciaCargaBase
        {
            get; private set;
        }
        public IGPrincipalRecurrenciaRepository GPrincipalRecurrencia
        {
            get; private set;
        }
        public IGLogRecurrenciaRepository GLogRecurrencia
        {
            get; private set;
        }
        public IBIPBitacoraIncidentesRepository BIPBitacoraIncidentes
        {
            get; private set;
        }
        public IBILBitacoraIncidentesRepository BILBitacoraIncidentes
        {
            get; private set;
        }
        public IBIMGerenciasRepository BIMGerencias
        {
            get; private set;
        }
        public IBIMAliadosRepository BIMAliados
        {
            get; private set;
        }
        public IBIMOperacionesRepository BIMOperaciones
        {
            get; private set;
        }
        public IBIPIncidentesPorOperacionRepository BIPIncidentesPorOperacion
        {
            get; private set;
        }
        public IBIMTipoFallaRepository BIMTipoFalla
        {
            get; private set;
        }
        public IBIMPrioridadesRepository BIMPrioridades
        {
            get; private set;
        }
        public IBIMHerramientasRepository BIMHerramientas
        {
            get; private set;
        }
        public IPOMSolicitudesRepository POMSolicitudes
        {
            get; private set;
        }
        public IFidelizacionMaestroServiciosRepository FidelizacionMaestroServicios
        {
            get; private set;
        }
        public IFidelizacionMotivosCancelacionRepository FidelizacionMotivosCancelacion
        {
            get; private set;
        }
        public IFidelizacionSubmotivosCancelacionRepository FidelizacionSubmotivosCancelacion
        {
            get; private set;
        }
        public IFidelizacionOtrosOfrecimientosRepository FidelizacionOtrosOfrecimientos
        {
            get; private set;
        }

        public IFidelizacionTipificacionRepository FidelizacionTipificacion
        {
            get; private set;
        }
        public IFidelizacionRecursivaRepository FidelizacionRecursiva
        {
            get; private set;
        }
        public IFidelizacionRegistroRepository FidelizacionRegistro
        {
            get; private set;
        }
        public IVIPSolicitudesRepository VIPSolicitudes
        {
            get; private set;
        }
        public IVILSolicitudesRepository VILSolicitudes
        {
            get; private set;
        }
        public IVIPSolicitudesPorEquipoRepository VIPSolicitudesPorEquipo
        {
            get; private set;
        }
        public IVIMTipoDeEquiposRepository VIMTipoDeEquipos
        {
            get; private set;
        }
        public IVIMTipoDeRequerimientoRepository VIMTipoDeRequerimiento
        {
            get; private set;
        }
        public IVIMGestionRepository VIMGestion
        {
            get; private set;
        }
        public IVIMSubrazonRepository VIMSubrazon
        {
            get; private set;
        }
        public IVIMAliadoTecnicoRepository VIMAliadoTecnico
        {
            get; private set;
        }
        public IGPrincipalRecurrenciaInboundRepository GPrincipalRecurrenciaInbound
        {
            get; private set;
        }
        public IGLogRecurrenciaInboundRepository GLogRecurrenciaInbound
        {
            get; private set;
        }
        public IInventarioEquiposRepository InventarioEquipos
        {
            get; private set;
        }
        public IBSCAdministracionBalancedRepository BSCAdministracionBalanced
        {
            get; private set;
        }
        public IBSCAdministracionBalancedLogRepository BSCAdministracionBalancedLog
        {
            get; private set;
        }
        public IVisitasAutorizadasRepository VisitasAutorizadas
        {
            get; private set;
        }
        public IVAMotivosSolicitudRepository VAMotivosSolicitud
        {
            get; private set;
        }
        public IFidelizacionOtrosCamposRepository FidelizacionOtrosCampos
        {
            get; private set;
        }
        public IFidelizacionRegistroCamposRepository FidelizacionRegistroCampos
        {
            get; private set;
        }
        public IFidelizacionRecursivaVistaRepository FidelizacionRecursivaVista
        {
            get; private set;
        }
        public IArbolRepository Arbol
        {
            get; private set;
        }
        public INodoRepository Nodo
        {
            get; private set;
        }
        public IRSPSeguimientosRepository RSPSeguimientos
        {
            get; private set;
        }
        public IRSLSeguimientosRepository RSLSeguimientos
        {
            get; private set;
        }
        public IRSMArbolesRepository RSMArboles
        {
            get; private set;
        }
        public IBACActualizarDatosRepository BACActualizarDatos
        {
            get; private set;
        }
        public IBAPActualizarDatosRepository BAPActualizarDatos
        {
            get; private set;
        }
        public IIMGOfertasComecialesRepository IMGOfertasComeciales
        {
            get; private set;
        }
        public INotificacionSignalRRepository NotificacionSignalR
        {
            get; private set;
        }
        public IUsuariosNotificadosSignalRRepository UsuariosNotificadosSignalR
        {
            get; private set;
        }
        public ICEPAsigDesconexionesRepository CEPAsigDesconexiones
        {
            get; private set;
        }
        public ICEPDesconexionesRepository CEPDesconexiones
        {
            get; private set;
        }
        public ICELDesconexionesRepository CELDesconexiones
        {
            get; private set;
        }
        public ICEMArbolesDeGestionRepository CEMArbolesDeGestion
        {
            get; private set;
        }
        public int Complete()
        {
            return this.dimeContext.SaveChanges();
        }
        public void Dispose()
        {
            this.dimeContext.Dispose();
        }
    }
}