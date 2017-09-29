// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.51
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

namespace Telmexla.Servicios.DIME.Data.Context
{
    using Configuration;
    using Entity;
    using IData.IContext;
    using System.Linq;


    public class DimeContext : System.Data.Entity.DbContext, IDimeContext
    {
        public System.Data.Entity.DbSet<Acceso> Accesoes { get; set; } // TBL_ACCESOS
        public System.Data.Entity.DbSet<BasePersonalHolo> BasePersonalHoloes { get; set; } // TBL_BASE_PERSONAL_HOLOS
        public System.Data.Entity.DbSet<ClientesTodo> ClientesTodoes { get; set; } // TBL_CLIENTES_TODOS
        public System.Data.Entity.DbSet<DatosAdicionalesCliente> DatosAdicionalesClientes { get; set; } // TBL_DATOS_ADICIONALES_CLIENTES
        public System.Data.Entity.DbSet<GestionOutbound> GestionOutbounds { get; set; } // TBL_GESTION_OUTBOUND
        public System.Data.Entity.DbSet<Linea> Lineas { get; set; } // TBL_LINEA
        public System.Data.Entity.DbSet<ModosLogin> ModosLogins { get; set; } // TBL_MODOS_LOGINS
        public System.Data.Entity.DbSet<PreguntasDesbloqueo> PreguntasDesbloqueos { get; set; } // TBL_PREGUNTAS_DESBLOQUEO
        public System.Data.Entity.DbSet<RegistroSesion> RegistroSesions { get; set; } // TBL_REGISTRO_SESION
        public System.Data.Entity.DbSet<Usuario> Usuarios { get; set; } // TBL_USUARIOS
        public System.Data.Entity.DbSet<UsuariosXAcceso> UsuariosXAccesoes { get; set; } // TBL_USUARIOS_X_ACCESOS
        public System.Data.Entity.DbSet<UsuariosXPreguntasDesb> UsuariosXPreguntasDesbs { get; set; } // TBL_USUARIOS_X_PREGUNTAS_DESB
        public System.Data.Entity.DbSet<TmpMaestroHobbiesCliente> TmpMaestroHobbiesClientes { get; set; } // TMP_MAESTRO_HOBBIES_CLIENTE
        public System.Data.Entity.DbSet<CierreCiclo> CierreCicloes { get; set; } // TBL_CIERRE_CICLO
        public System.Data.Entity.DbSet<ClaroVideo> ClaroVideos { get; set; } // TBL_CLARO_VIDEO
        public System.Data.Entity.DbSet<ConvenioElectronico> ConvenioElectronicoes { get; set; } // TBL_CONVENIO_ELECTRONICO
        public System.Data.Entity.DbSet<DocsisOverlap> DocsisOverlaps { get; set; } // TBL_DOCSIS_OVERLAP
        public System.Data.Entity.DbSet<Ingreso> Ingresoes { get; set; } // TBL_INGRESOS
        public System.Data.Entity.DbSet<NotasIngreso> NotasIngresoes { get; set; } // TBL_NOTAS_INGRESO
        public System.Data.Entity.DbSet<MaestroMarcacione> MaestroMarcaciones { get; set; }//  TMP_MAESTRO_MARCACIONES 
        public System.Data.Entity.DbSet<NotificacionesBuenServicio> NotificacionesBuenServicio { get; set; }//  NOTIFICACIONES_BUEN_SERVICIO
        public System.Data.Entity.DbSet<LogCierreCiclo> LogCierreCicloes { get; set; } // TBL_LOG_CIERRE_CICLO
        public System.Data.Entity.DbSet<LogClaroVideo> LogClaroVideos { get; set; } // TBL_LOG_CLARO_VIDEO
        public System.Data.Entity.DbSet<LogConvenioElectronico> LogConvenioElectronicoes { get; set; } // TBL_LOG_CONVENIO_ELECTRONICO
        public System.Data.Entity.DbSet<LogDocsisOverlap> LogDocsisOverlaps { get; set; } // TBL_LOG_DOCSIS_OVERLAP
        public System.Data.Entity.DbSet<PqrMaestroCodCierre> PqrMaestroCodCierres { get; set; } // TMP_PQR_MAESTRO_COD_CIERRE
        public System.Data.Entity.DbSet<Rechazo> Rechazoes { get; set; } // TBL_RECHAZOS
        public System.Data.Entity.DbSet<IngresoTraslado> IngresoTraslados { get; set; } // TBL_INGRESOS_TRASLADOS
        public System.Data.Entity.DbSet<NotasTraslado> NotasTraslados { get; set; } // TBL_NOTAS_TRASLADOS
        public System.Data.Entity.DbSet<MaestroNodo> MaestroNodos { get; set; } // TBL_NOTAS_TRASLADOS
        public System.Data.Entity.DbSet<ActivacionClaroVideo> ActivacionesClaroVideo { get; set; } // TBL_ACTIVACION_CLARO_VIDEO
        public System.Data.Entity.DbSet<CuentasSiembraHD> CuentasSiembra { get; set; } // TBL_CUENTAS_SIEMBRA_HD
        public System.Data.Entity.DbSet<SiembraHD> ActivacionSiembra { get; set; } // TBL_SIEMBRA_HD
        public System.Data.Entity.DbSet<CambioEstrato> cambioEstratos { get; set; } // TBL_CAMBIO_DE_ESTRATO
        public System.Data.Entity.DbSet<TraficoTraslado> traficoTraslados { get; set; } // TBL_TRAFICO_TRASLADO
        public System.Data.Entity.DbSet<LiberacionHomePass> liberacionesHomePass { get; set; } // TBL_LIBERACION_HOME_PASS
        public System.Data.Entity.DbSet<GestionMatriz> gestionMatrices { get; set; } // TBL_GESTION_MATRICES
        public System.Data.Entity.DbSet<IngresosSoporte> IngresosSoportes { get; set; } // TBL_INGRESOS_SOPORTE
        public System.Data.Entity.DbSet<RazonIngresoSoporte> RazonIngresoSoportes { get; set; } // TBL_RAZON_INGRESO_SOPORTE
        public System.Data.Entity.DbSet<Subrazon1IngresoSoporte> Subrazon1IngresoSoporte { get; set; } // TBL_SUBRAZON1_INGRESO_SOPORTE
        public System.Data.Entity.DbSet<Subrazon2IngresoSoporte> Subrazon2IngresoSoporte { get; set; } // TBL_SUBRAZON2_INGRESO_SOPORTE
        public System.Data.Entity.DbSet<UsuariosNotificados> usuariosNotificados{ get; set; } // TBL_USUARIOS_NOTIFICADOS
        public System.Data.Entity.DbSet<BalanceScoreCard> balanceScoreCards { get; set; } // TBL_BALANCE_SCORE_CARD
        public System.Data.Entity.DbSet<CuentasSiguienteMejorOferta> CuentaSMO { get; set; } // TBL_CUENTAS_SIGUENTE_MEJOR_OFERTA
        public System.Data.Entity.DbSet<SiguienteMejorOferta> SMO { get; set; } // TBL_VENTAS_SMO_INBOUND
        public System.Data.Entity.DbSet<SmoRentaActual> SmoRentaActuals { get; set; } // TBL_SMO_RENTA_ACTUAL
        public System.Data.Entity.DbSet<SmoTarifaActual> SmoTarifaActuals { get; set; } // TBL_SMO_TARIFA_ACTUAL
        public System.Data.Entity.DbSet<TrasladoFallido> TrasladoFallidos { get; set; } // TBL_TRASLADOS_FALLIDOS
        public System.Data.Entity.DbSet<UsabilidadConvenioInbound> UsabilidadConvenioInbound { get; set; } // TBL_USABILIDAD_ACTIVACION_CONVENIO
        public System.Data.Entity.DbSet<Departamento> Departamentos { get; set; } // TBL_DEPARTAMENTOS_CIUDADES
        public System.Data.Entity.DbSet<UsabilidadBusquedaCuentaInbound> UsabilidadBusquedaClienteInbound { get; set; } // TBL_USABILIDAD_BUSQUEDA_CLIENTE
        public System.Data.Entity.DbSet<SkillsUsuariosBlending> SkillsUsuariosBlending { get; set; } // TBL_SKILLS_USUARIOS_BLENDING
        public System.Data.Entity.DbSet<BlendingFueraNivel> blendingFueraNiveles { get; set; } // TMP_GBC_FUERA_NIVELES
        public System.Data.Entity.DbSet<DistribucionBlending> DistribucionBlendings { get; set; } // TBL_DISTRIBUCIONES_BLENDING
        public System.Data.Entity.DbSet<GBPFueraNiveles> GBPFueradeNiveles { get; set; } // TBL_GBP_FUERA_NIVELES
        public System.Data.Entity.DbSet<GBLFueraNiveles> GBLFueradeNiveles { get; set; } // TBL_GBL_FUERA_NIVELES
        public System.Data.Entity.DbSet<GBPRentabilizacion> GBPRentabilizacion { get; set; } // TBL_GBP_RENTABILIZACON
        public System.Data.Entity.DbSet<GBLRentabilizacion> GBLRentabilizacion { get; set; } // TBL_GBL_RENTABILIZACON
        public System.Data.Entity.DbSet<GBC_Rentabilizacion> GBCRentabilizacion { get; set; } // TMP_GBC_RENTABILIZACON
        public System.Data.Entity.DbSet<CuentasMejorasTecnicas> CuentasMejorasTecnicas { get; set; } // TBL_CUENTAS_MEJORAS_TECNICAS
        public System.Data.Entity.DbSet<MejorasTecnicas> MejorasTecnicas { get; set; } // TBL_MEJORAS_TECNICAS
        public System.Data.Entity.DbSet<GBPProducto> GBPProducto { get; set; } // TBL_GBP_PRODUCTO
        public System.Data.Entity.DbSet<GBLProducto> GBLProducto { get; set; } // TBL_GBL_PRODUCTO
        public System.Data.Entity.DbSet<GBCProducto> GBCProducto { get; set; } // TMP_GBC_PRODUCTO
        public System.Data.Entity.DbSet<GBPDocsis> GBPDocsis { get; set; } // TBL_GBP_DOCSIS_OVERLAP
        public System.Data.Entity.DbSet<GBLDocsis> GBLDocsis { get; set; } // TBL_GBL_DOCSIS_OVERLAP
        public System.Data.Entity.DbSet<GBCDocsis> GBCDocsis { get; set; } // TMP_GBC_DOCSIS_OVERLAP
        public System.Data.Entity.DbSet<Retencion> Retencion { get; set; } // TBL_RETENCION
        public System.Data.Entity.DbSet<MultiplayCargue> MultiplayCargue { get; set; } 
        public System.Data.Entity.DbSet<MultiPlayRegistro> MultiPlayRegistro { get; set; }
        public System.Data.Entity.DbSet<MecMonitoreosP> MecMonitoreosP { get; set; }
        public System.Data.Entity.DbSet<MecMonitoreosL> MecMonitoreosL { get; set; }
        public System.Data.Entity.DbSet<MecProcesos> MecProcesos { get; set; }
        public System.Data.Entity.DbSet<MecLineas> MecLineas { get; set; }
        public System.Data.Entity.DbSet<MecListasDistribucion> MecListasDistribucion { get; set; }
        public System.Data.Entity.DbSet<MecTipoAlarmas> MecTipoAlarmas { get; set; }
        public System.Data.Entity.DbSet<CargaBaseFoxInbound> CargaBaseFoxInbound { get; set; }
        public System.Data.Entity.DbSet<GestionFoxInbound> GestionFoxInbound { get; set; }
        public System.Data.Entity.DbSet<CcBaseMejoramiento> CcBaseMejoramientoes { get; set; } // TBL_CC_BASE_MEJORAMIENTO
        public System.Data.Entity.DbSet<CcGestionResidencialPredictivo> CcGestionResidencialPredictivoes { get; set; } // TBL_CC_GESTION_RESIDENCIAL_PREDICTIVO
        public System.Data.Entity.DbSet<CcResidencialPredictivoInfo> CcResidencialPredictivoInfoes { get; set; } // TBL_CC_RESIDENCIAL_PREDICTIVO_INFO
        public System.Data.Entity.DbSet<BELSolicitudes> BELSolicitudes { get; set; }
        public System.Data.Entity.DbSet<BEMDetalleDeGestion> BEMDetalleDeGestion { get; set; }
        public System.Data.Entity.DbSet<BEMDetalleEscalamientos> BEMDetalleEscalamientos { get; set; }
        public System.Data.Entity.DbSet<BEMDistribuciones> BEMDistribuciones { get; set; }
        public System.Data.Entity.DbSet<BEMRazonMalEscalamiento> BEMRazonMalEscalamiento { get; set; }
        public System.Data.Entity.DbSet<BEMTipoDeEscalamientos> BEMTipoDeEscalamientos { get; set; }
        public System.Data.Entity.DbSet<BEPSolicitudes> BEPSolicitudes { get; set; }
        public System.Data.Entity.DbSet<NodosZonificados> NodosZonificados { get; set; }
        public System.Data.Entity.DbSet<CcSegundaTipificacion> CcSegundaTipificacions { get; set; }
        public System.Data.Entity.DbSet<RecurrenciaCargaBase> RecurrenciaCargaBase { get; set; }
        public System.Data.Entity.DbSet<GPrincipalRecurrencia> GPrincipalRecurrencia { get; set; }
        public System.Data.Entity.DbSet<GLogRecurrencia> GLogRecurrencia { get; set; }
        public System.Data.Entity.DbSet<BIPBitacoraIncidentes> BIPBitacoraIncidentes { get; set; }
        public System.Data.Entity.DbSet<BILBitacoraIncidentes> BILBitacoraIncidentes { get; set; }
        public System.Data.Entity.DbSet<BIMGerencias> BIMGerencias { get; set; }
        public System.Data.Entity.DbSet<BIMAliados> BIMAliados { get; set; }
        public System.Data.Entity.DbSet<BIMOperaciones> BIMOperaciones { get; set; }
        public System.Data.Entity.DbSet<BIPIncidentesPorOperacion> BIPIncidentesPorOperacion { get; set; }
        public System.Data.Entity.DbSet<BIMTipoFalla> BIMTipoFalla { get; set; }
        public System.Data.Entity.DbSet<BIMPrioridades> BIMPrioridades { get; set; }
        public System.Data.Entity.DbSet<BIMHerramientas> BIMHerramientas { get; set; }
        public System.Data.Entity.DbSet<AccesosXLinea> AccesosXLineas { get; set; } // TBL_ACCESOS_X_LINEA
        public System.Data.Entity.DbSet<POMSolicitudes> POMSolicitudes { get; set; }
        public System.Data.Entity.DbSet<FidelizacionMaestroServicios> FidelizacionMaestroServicios { get; set; }
        public System.Data.Entity.DbSet<FidelizacionMotivosCancelacion> FidelizacionMotivosCancelacion { get; set; }
        public System.Data.Entity.DbSet<FidelizacionSubmotivosCancelacion> FidelizacionSubmotivosCancelacion { get; set; }
        public System.Data.Entity.DbSet<FidelizacionOtrosOfrecimientos> FidelizacionOtrosOfrecimientos { get; set; }
        public System.Data.Entity.DbSet<FidelizacionTipificacion> FidelizacionTipificacion { get; set; }
        public System.Data.Entity.DbSet<FidelizacionRecursiva> FidelizacionRecursiva { get; set; }
        public System.Data.Entity.DbSet<FidelizacionRegistro> FidelizacionRegistro { get; set; }
        public System.Data.Entity.DbSet<VIPSolicitudes> VIPSolicitudes { get; set; }
        public System.Data.Entity.DbSet<VILSolicitudes> VILSolicitudes { get; set; }
        public System.Data.Entity.DbSet<VIPSolicitudesPorEquipo> VIPSolicitudesPorEquipo { get; set; }
        public System.Data.Entity.DbSet<VIMTipoDeEquipos> VIMTipoDeEquipos { get; set; }
        public System.Data.Entity.DbSet<VIMTipoDeRequerimiento> VIMTipoDeRequerimiento { get; set; }
        public System.Data.Entity.DbSet<VIMGestion> VIMGestion { get; set; }
        public System.Data.Entity.DbSet<VIMSubrazon> VIMSubrazon { get; set; }
        public System.Data.Entity.DbSet<VIMAliadoTecnico> VIMAliadoTecnico { get; set; }
        public System.Data.Entity.DbSet<GPrincipalRecurrenciaInbound> GPrincipalRecurrenciaInbound { get; set; }
        public System.Data.Entity.DbSet<GLogRecurrenciaInbound> GLogRecurrenciaInbound { get; set; }


        static DimeContext()
        {
            System.Data.Entity.Database.SetInitializer<DimeContext>(null);

        }

        public DimeContext()
            : base("Name=DimeContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = true;
        }

        public DimeContext(string connectionString)
            : base(connectionString)
        {
        }

        public DimeContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
        }

        public DimeContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public DimeContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new AccesoConfiguration());
            modelBuilder.Configurations.Add(new CierreCicloConfiguration());
            modelBuilder.Configurations.Add(new ClaroVideoConfiguration());
            modelBuilder.Configurations.Add(new ClientesTodoConfiguration());
            modelBuilder.Configurations.Add(new ConvenioElectronicoConfiguration());
            modelBuilder.Configurations.Add(new DatosAdicionalesClienteConfiguration());
            modelBuilder.Configurations.Add(new DocsisOverlapConfiguration());
            modelBuilder.Configurations.Add(new GestionOutboundConfiguration());
            modelBuilder.Configurations.Add(new IngresoConfiguration());
            modelBuilder.Configurations.Add(new LineaConfiguration());
            modelBuilder.Configurations.Add(new ModosLoginConfiguration());
            modelBuilder.Configurations.Add(new NotasIngresoConfiguration());
            modelBuilder.Configurations.Add(new PreguntasDesbloqueoConfiguration());
            modelBuilder.Configurations.Add(new RegistroSesionConfiguration());
            modelBuilder.Configurations.Add(new TmpMaestroHobbiesClienteConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new UsuariosXAccesoConfiguration());
            modelBuilder.Configurations.Add(new UsuariosXPreguntasDesbConfiguration());
            modelBuilder.Configurations.Add(new MaestroMarcacionesConfiguration());
            modelBuilder.Configurations.Add(new NotificacionesBuenServicioConfiguration());
            modelBuilder.Configurations.Add(new LogCierreCicloConfiguration());
            modelBuilder.Configurations.Add(new LogClaroVideoConfiguration());
            modelBuilder.Configurations.Add(new LogConvenioElectronicoConfiguration());
            modelBuilder.Configurations.Add(new LogDocsisOverlapConfiguration());
            modelBuilder.Configurations.Add(new PqrMaestroCodCierreConfiguration());
            modelBuilder.Configurations.Add(new RechazoConfiguration());
            modelBuilder.Configurations.Add(new IngresoTrasladoConfiguration());
            modelBuilder.Configurations.Add(new NotasTrasladoConfiguration());
            modelBuilder.Configurations.Add(new MaestroNodoConfiguration());
            modelBuilder.Configurations.Add(new BasePersonalHoloConfiguration());
            modelBuilder.Configurations.Add(new ActivacionClaroVideoConfiguration());
            modelBuilder.Configurations.Add(new CuentasSiembraHDConfiguration());
            modelBuilder.Configurations.Add(new CambioEstratoConfiguration());
            modelBuilder.Configurations.Add(new SiembraHDConfiguration());
            modelBuilder.Configurations.Add(new TraficoTrasladoConfiguration());
            modelBuilder.Configurations.Add(new LiberacionHomePassConfiguration());
            modelBuilder.Configurations.Add(new GestionMatrizConfiguration());
            modelBuilder.Configurations.Add(new IngresosSoporteConfiguration());
            modelBuilder.Configurations.Add(new RazonIngresoSoporteConfiguration());
            modelBuilder.Configurations.Add(new Subrazon1IngresoSoporteConfiguration());
            modelBuilder.Configurations.Add(new Subrazon2IngresoSoporteConfiguration());
            modelBuilder.Configurations.Add(new UsuariosNotificadosConfiguration());
            modelBuilder.Configurations.Add(new BalanceScoreCardConfiguration());
            modelBuilder.Configurations.Add(new CuentasSiguienteMejorOfertaConfiguration());
            modelBuilder.Configurations.Add(new SiguienteMejorOfertaConfiguration());
            modelBuilder.Configurations.Add(new SmoRentaActualConfiguration());
            modelBuilder.Configurations.Add(new SmoTarifaActualConfiguration());
            modelBuilder.Configurations.Add(new TrasladoFallidoConfiguration());
            modelBuilder.Configurations.Add(new UsabilidadConvenioInboundConfiguration());
            modelBuilder.Configurations.Add(new DepartamentoConfiguration());
            modelBuilder.Configurations.Add(new UsabilidadBusquedaCuentaInboundConfiguration());
            modelBuilder.Configurations.Add(new SkillsUsuariosBlendingConfiguration());
            modelBuilder.Configurations.Add(new BlendingFueraNivelConfiguration());
            modelBuilder.Configurations.Add(new DistribucionBlendingConfiguration());
            modelBuilder.Configurations.Add(new GBPFueraNivelesConfiguration());
            modelBuilder.Configurations.Add(new GBLFueraNivelesConfiguration());
            modelBuilder.Configurations.Add(new GBLRentabilizacionConfiguration());
            modelBuilder.Configurations.Add(new GBPRentabilizacionConfiguration());
            modelBuilder.Configurations.Add(new GBCRentabilizacionConfiguration());
            modelBuilder.Configurations.Add(new CuentasMejorasTecnicasConfiguration());
            modelBuilder.Configurations.Add(new MejorasTecnicasConfiguration());
            modelBuilder.Configurations.Add(new GBPProductoConfiguration());
            modelBuilder.Configurations.Add(new GBLProductoConfiguration());
            modelBuilder.Configurations.Add(new GBCProductoConfiguration());
            modelBuilder.Configurations.Add(new GBPDocsisConfiguration());
            modelBuilder.Configurations.Add(new GBLDocsisConfiguration());
            modelBuilder.Configurations.Add(new GBCDocsisConfiguration());
            modelBuilder.Configurations.Add(new RetencionConfiguration());
            modelBuilder.Configurations.Add(new MultiplayCargueConfiguration());
            modelBuilder.Configurations.Add(new MultiPlayRegistroConfiguration());
            modelBuilder.Configurations.Add(new MecMonitoreosPConfiguration());
            modelBuilder.Configurations.Add(new MecMonitoreosLConfiguration());
            modelBuilder.Configurations.Add(new MecProcesosConfiguration());
            modelBuilder.Configurations.Add(new MecLineasConfiguration());
            modelBuilder.Configurations.Add(new MecListasDistribucionConfiguration());
            modelBuilder.Configurations.Add(new MecTipoAlarmasConfiguration());
            modelBuilder.Configurations.Add(new CargueBaseFoxInboundConfiguration());
            modelBuilder.Configurations.Add(new GestionFoxInboundConfiguration());
            modelBuilder.Configurations.Add(new CcBaseMejoramientoConfiguration());
            modelBuilder.Configurations.Add(new CcGestionResidencialPredictivoConfiguration());
            modelBuilder.Configurations.Add(new CcResidencialPredictivoInfoConfiguration());
            modelBuilder.Configurations.Add(new BELSolicitudesConfiguration());
            modelBuilder.Configurations.Add(new BEMDetalleDeGestionConfiguration());
            modelBuilder.Configurations.Add(new BEMDetalleDeEscalamientosConfiguration());
            modelBuilder.Configurations.Add(new BEMDistribucionesConfiguration());
            modelBuilder.Configurations.Add(new BEMRazonMalEscalamientoConfiguration());
            modelBuilder.Configurations.Add(new BEMTipoDeEscalamientosConfiguration());
            modelBuilder.Configurations.Add(new BEPSolicitudesConfiguration());
            modelBuilder.Configurations.Add(new NodosZonificadosConfiguration());
            modelBuilder.Configurations.Add(new CcSegundaTipificacionConfiguration());
            modelBuilder.Configurations.Add(new RecurrenciaCargueBaseConfiguration());
            modelBuilder.Configurations.Add(new GPrincipalRecurrenciaConfiguration());
            modelBuilder.Configurations.Add(new GLogRecurrenciaConfiguration());
            modelBuilder.Configurations.Add(new BIPBitacoraIncidentesConfiguration());
            modelBuilder.Configurations.Add(new BILBitacoraIncidentesConfiguration());
            modelBuilder.Configurations.Add(new BIMGerenciasConfiguration());
            modelBuilder.Configurations.Add(new BIMAliadosConfiguration());
            modelBuilder.Configurations.Add(new BIMOperacionesConfiguration());
            modelBuilder.Configurations.Add(new BIPIncidentesPorOperacionConfiguration());
            modelBuilder.Configurations.Add(new BIMTipoFallaConfiguration());
            modelBuilder.Configurations.Add(new BIMPrioridadesConfiguration());
            modelBuilder.Configurations.Add(new BIMHerramientasConfiguration());
            modelBuilder.Configurations.Add(new AccesosXLineaConfiguration());
            modelBuilder.Configurations.Add(new POMSolicitudesConfiguration());
            modelBuilder.Configurations.Add(new FidelizacionMaestroServiciosConfiguration());
            modelBuilder.Configurations.Add(new FidelizacionMotivosCancelacionConfiguration());
            modelBuilder.Configurations.Add(new FidelizacionSubmotivosCancelacionConfiguration());
            modelBuilder.Configurations.Add(new FidelizacionOtrosOfrecimientosConfiguration());
            modelBuilder.Configurations.Add(new FidelizacionTipificacionConfiguration());
            modelBuilder.Configurations.Add(new FidelizacionRecursivaConfiguration());
            modelBuilder.Configurations.Add(new FidelizacionRegistroConfiguration());
            modelBuilder.Configurations.Add(new VIPSolicitudesConfiguration());
            modelBuilder.Configurations.Add(new VILSolicitudesConfiguration());
            modelBuilder.Configurations.Add(new VIPSolicitudesPorEquipoConfiguration());
            modelBuilder.Configurations.Add(new VIMTipoDeEquiposConfiguration());
            modelBuilder.Configurations.Add(new VIMTipoDeRequerimientoConfiguration());
            modelBuilder.Configurations.Add(new VIMGestionConfiguration());
            modelBuilder.Configurations.Add(new VIMSubrazonConfiguration());
            modelBuilder.Configurations.Add(new VIMAliadoTecnicoConfiguration());
            modelBuilder.Configurations.Add(new GPrincipalRecurrenciaInboundConfiguration());
            modelBuilder.Configurations.Add(new GLogRecurrenciaInboundConfiguration());
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new AccesoConfiguration(schema));
            modelBuilder.Configurations.Add(new BasePersonalHoloConfiguration(schema));
            modelBuilder.Configurations.Add(new CierreCicloConfiguration(schema));
            modelBuilder.Configurations.Add(new ClaroVideoConfiguration(schema));
            modelBuilder.Configurations.Add(new ClientesTodoConfiguration(schema));
            modelBuilder.Configurations.Add(new ConvenioElectronicoConfiguration(schema));
            modelBuilder.Configurations.Add(new DatosAdicionalesClienteConfiguration(schema));
            modelBuilder.Configurations.Add(new DocsisOverlapConfiguration(schema));
            modelBuilder.Configurations.Add(new GestionOutboundConfiguration(schema));
            modelBuilder.Configurations.Add(new IngresoConfiguration(schema));
            modelBuilder.Configurations.Add(new LineaConfiguration(schema));
            modelBuilder.Configurations.Add(new ModosLoginConfiguration(schema));
            modelBuilder.Configurations.Add(new NotasIngresoConfiguration(schema));
            modelBuilder.Configurations.Add(new PreguntasDesbloqueoConfiguration(schema));
            modelBuilder.Configurations.Add(new RegistroSesionConfiguration(schema));
            modelBuilder.Configurations.Add(new TmpMaestroHobbiesClienteConfiguration(schema));
            modelBuilder.Configurations.Add(new UsuarioConfiguration(schema));
            modelBuilder.Configurations.Add(new UsuariosXAccesoConfiguration(schema));
            modelBuilder.Configurations.Add(new UsuariosXPreguntasDesbConfiguration(schema));
            modelBuilder.Configurations.Add(new MaestroMarcacionesConfiguration(schema));
            modelBuilder.Configurations.Add(new NotificacionesBuenServicioConfiguration(schema));
            modelBuilder.Configurations.Add(new LogCierreCicloConfiguration(schema));
            modelBuilder.Configurations.Add(new LogClaroVideoConfiguration(schema));
            modelBuilder.Configurations.Add(new LogConvenioElectronicoConfiguration(schema));
            modelBuilder.Configurations.Add(new LogDocsisOverlapConfiguration(schema));
            modelBuilder.Configurations.Add(new PqrMaestroCodCierreConfiguration(schema));
            modelBuilder.Configurations.Add(new RechazoConfiguration(schema));
            modelBuilder.Configurations.Add(new IngresoTrasladoConfiguration(schema));
            modelBuilder.Configurations.Add(new NotasTrasladoConfiguration(schema));
            modelBuilder.Configurations.Add(new MaestroNodoConfiguration(schema));
            modelBuilder.Configurations.Add(new ActivacionClaroVideoConfiguration(schema));
            modelBuilder.Configurations.Add(new CuentasSiembraHDConfiguration(schema));
            modelBuilder.Configurations.Add(new CambioEstratoConfiguration(schema));
            modelBuilder.Configurations.Add(new SiembraHDConfiguration(schema));
            modelBuilder.Configurations.Add(new TraficoTrasladoConfiguration(schema));
            modelBuilder.Configurations.Add(new LiberacionHomePassConfiguration(schema));
            modelBuilder.Configurations.Add(new GestionMatrizConfiguration(schema));
            modelBuilder.Configurations.Add(new IngresosSoporteConfiguration(schema));
            modelBuilder.Configurations.Add(new RazonIngresoSoporteConfiguration(schema));
            modelBuilder.Configurations.Add(new Subrazon1IngresoSoporteConfiguration(schema));
            modelBuilder.Configurations.Add(new Subrazon2IngresoSoporteConfiguration(schema));
            modelBuilder.Configurations.Add(new UsuariosNotificadosConfiguration(schema));
            modelBuilder.Configurations.Add(new BalanceScoreCardConfiguration(schema));
            modelBuilder.Configurations.Add(new CuentasSiguienteMejorOfertaConfiguration(schema));
            modelBuilder.Configurations.Add(new SiguienteMejorOfertaConfiguration(schema));
            modelBuilder.Configurations.Add(new SmoRentaActualConfiguration(schema));
            modelBuilder.Configurations.Add(new SmoTarifaActualConfiguration(schema));
            modelBuilder.Configurations.Add(new TrasladoFallidoConfiguration(schema));
            modelBuilder.Configurations.Add(new UsabilidadConvenioInboundConfiguration(schema));
            modelBuilder.Configurations.Add(new DepartamentoConfiguration(schema));
            modelBuilder.Configurations.Add(new UsabilidadBusquedaCuentaInboundConfiguration(schema));
            modelBuilder.Configurations.Add(new SkillsUsuariosBlendingConfiguration(schema));
            modelBuilder.Configurations.Add(new BlendingFueraNivelConfiguration(schema));
            modelBuilder.Configurations.Add(new DistribucionBlendingConfiguration(schema));
            modelBuilder.Configurations.Add(new GBPFueraNivelesConfiguration(schema));
            modelBuilder.Configurations.Add(new GBLFueraNivelesConfiguration(schema));
            modelBuilder.Configurations.Add(new GBLRentabilizacionConfiguration(schema));
            modelBuilder.Configurations.Add(new GBPRentabilizacionConfiguration(schema));
            modelBuilder.Configurations.Add(new GBCRentabilizacionConfiguration(schema));
            modelBuilder.Configurations.Add(new CuentasMejorasTecnicasConfiguration(schema));
            modelBuilder.Configurations.Add(new MejorasTecnicasConfiguration(schema));
            modelBuilder.Configurations.Add(new GBPProductoConfiguration(schema));
            modelBuilder.Configurations.Add(new GBLProductoConfiguration(schema));
            modelBuilder.Configurations.Add(new GBCProductoConfiguration(schema));
            modelBuilder.Configurations.Add(new GBPDocsisConfiguration(schema));
            modelBuilder.Configurations.Add(new GBLDocsisConfiguration(schema));
            modelBuilder.Configurations.Add(new GBCDocsisConfiguration(schema));
            modelBuilder.Configurations.Add(new RetencionConfiguration(schema));
            modelBuilder.Configurations.Add(new MultiplayCargueConfiguration(schema));
            modelBuilder.Configurations.Add(new MultiPlayRegistroConfiguration(schema));
            modelBuilder.Configurations.Add(new MecMonitoreosPConfiguration(schema));
            modelBuilder.Configurations.Add(new MecMonitoreosLConfiguration(schema));
            modelBuilder.Configurations.Add(new MecProcesosConfiguration(schema));
            modelBuilder.Configurations.Add(new MecLineasConfiguration(schema));
            modelBuilder.Configurations.Add(new MecListasDistribucionConfiguration(schema));
            modelBuilder.Configurations.Add(new MecTipoAlarmasConfiguration(schema));
            modelBuilder.Configurations.Add(new CargueBaseFoxInboundConfiguration(schema));
            modelBuilder.Configurations.Add(new GestionFoxInboundConfiguration(schema));
            modelBuilder.Configurations.Add(new CcBaseMejoramientoConfiguration(schema));
            modelBuilder.Configurations.Add(new CcGestionResidencialPredictivoConfiguration(schema));
            modelBuilder.Configurations.Add(new CcResidencialPredictivoInfoConfiguration(schema));
            modelBuilder.Configurations.Add(new BELSolicitudesConfiguration(schema));
            modelBuilder.Configurations.Add(new BEMDetalleDeGestionConfiguration(schema));
            modelBuilder.Configurations.Add(new BEMDetalleDeEscalamientosConfiguration(schema));
            modelBuilder.Configurations.Add(new BEMDistribucionesConfiguration(schema));
            modelBuilder.Configurations.Add(new BEMRazonMalEscalamientoConfiguration(schema));
            modelBuilder.Configurations.Add(new BEMTipoDeEscalamientosConfiguration(schema));
            modelBuilder.Configurations.Add(new BEPSolicitudesConfiguration(schema));
            modelBuilder.Configurations.Add(new NodosZonificadosConfiguration(schema));
            modelBuilder.Configurations.Add(new CcSegundaTipificacionConfiguration(schema));
            modelBuilder.Configurations.Add(new RecurrenciaCargueBaseConfiguration(schema));
            modelBuilder.Configurations.Add(new GPrincipalRecurrenciaConfiguration(schema));
            modelBuilder.Configurations.Add(new GLogRecurrenciaConfiguration(schema));
            modelBuilder.Configurations.Add(new BIPBitacoraIncidentesConfiguration(schema));
            modelBuilder.Configurations.Add(new BILBitacoraIncidentesConfiguration(schema));
            modelBuilder.Configurations.Add(new BIMGerenciasConfiguration(schema));
            modelBuilder.Configurations.Add(new BIMAliadosConfiguration(schema));
            modelBuilder.Configurations.Add(new BIMOperacionesConfiguration(schema));
            modelBuilder.Configurations.Add(new BIPIncidentesPorOperacionConfiguration(schema));
            modelBuilder.Configurations.Add(new BIMTipoFallaConfiguration(schema));
            modelBuilder.Configurations.Add(new BIMPrioridadesConfiguration(schema));
            modelBuilder.Configurations.Add(new BIMHerramientasConfiguration(schema));
            modelBuilder.Configurations.Add(new AccesosXLineaConfiguration(schema));
            modelBuilder.Configurations.Add(new POMSolicitudesConfiguration(schema));
            modelBuilder.Configurations.Add(new FidelizacionMaestroServiciosConfiguration(schema));
            modelBuilder.Configurations.Add(new FidelizacionMotivosCancelacionConfiguration(schema));
            modelBuilder.Configurations.Add(new FidelizacionSubmotivosCancelacionConfiguration(schema));
            modelBuilder.Configurations.Add(new FidelizacionOtrosOfrecimientosConfiguration(schema));
            modelBuilder.Configurations.Add(new FidelizacionTipificacionConfiguration(schema));
            modelBuilder.Configurations.Add(new FidelizacionRecursivaConfiguration(schema));
            modelBuilder.Configurations.Add(new FidelizacionRegistroConfiguration(schema));
            modelBuilder.Configurations.Add(new VIPSolicitudesConfiguration(schema));
            modelBuilder.Configurations.Add(new VILSolicitudesConfiguration(schema));
            modelBuilder.Configurations.Add(new VIPSolicitudesPorEquipoConfiguration(schema));
            modelBuilder.Configurations.Add(new VIMTipoDeEquiposConfiguration(schema));
            modelBuilder.Configurations.Add(new VIMTipoDeRequerimientoConfiguration(schema));
            modelBuilder.Configurations.Add(new VIMGestionConfiguration(schema));
            modelBuilder.Configurations.Add(new VIMSubrazonConfiguration(schema));
            modelBuilder.Configurations.Add(new VIMAliadoTecnicoConfiguration(schema));
            modelBuilder.Configurations.Add(new GPrincipalRecurrenciaInboundConfiguration(schema));
            modelBuilder.Configurations.Add(new GLogRecurrenciaInboundConfiguration(schema));

            return modelBuilder;
        }

        // Stored Procedures
        public System.Collections.Generic.List<ActualizarUsuarioGestionBackIngresoReturnModel> ActualizarUsuarioGestionBackIngreso(decimal? idIngreso, string usuarioBack)
        {
            int procResult;
            return ActualizarUsuarioGestionBackIngreso(idIngreso, usuarioBack, out procResult);
        }

        public System.Collections.Generic.List<ActualizarUsuarioGestionBackIngresoReturnModel> ActualizarUsuarioGestionBackIngreso(decimal? idIngreso, string usuarioBack, out int procResult)
        {
            var idIngresoParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Id_Ingreso", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = idIngreso.GetValueOrDefault(), Precision = 18, Scale = 0 };
            if (!idIngreso.HasValue)
                idIngresoParam.Value = System.DBNull.Value;

            var usuarioBackParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Usuario_Back", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = usuarioBack, Size = 30 };
            if (usuarioBackParam.Value == null)
                usuarioBackParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };
            var procResultData = Database.SqlQuery<ActualizarUsuarioGestionBackIngresoReturnModel>("EXEC @procResult = [dbo].[ACTUALIZAR_USUARIO_GESTION_BACK_INGRESO] @Id_Ingreso, @Usuario_Back", idIngresoParam, usuarioBackParam, procResultParam).ToList();

            procResult = (int)procResultParam.Value;
            return procResultData;
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.List<ActualizarUsuarioGestionBackIngresoReturnModel>> ActualizarUsuarioGestionBackIngresoAsync(decimal? idIngreso, string usuarioBack)
        {
            var idIngresoParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Id_Ingreso", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = idIngreso.GetValueOrDefault(), Precision = 18, Scale = 0 };
            if (!idIngreso.HasValue)
                idIngresoParam.Value = System.DBNull.Value;

            var usuarioBackParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Usuario_Back", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = usuarioBack, Size = 30 };
            if (usuarioBackParam.Value == null)
                usuarioBackParam.Value = System.DBNull.Value;

            var procResultData = await Database.SqlQuery<ActualizarUsuarioGestionBackIngresoReturnModel>("EXEC [dbo].[ACTUALIZAR_USUARIO_GESTION_BACK_INGRESO] @Id_Ingreso, @Usuario_Back", idIngresoParam, usuarioBackParam).ToListAsync();

            return procResultData;
        }

        public System.Collections.Generic.List<ActualizaUsuarioGestionBackTrasladoReturnModel> ActualizaUsuarioGestionBackTraslado(decimal? idTransaccion, string usuarioBack)
        {
            int procResult;
            return ActualizaUsuarioGestionBackTraslado(idTransaccion, usuarioBack, out procResult);
        }

        public System.Collections.Generic.List<ActualizaUsuarioGestionBackTrasladoReturnModel> ActualizaUsuarioGestionBackTraslado(decimal? idTransaccion, string usuarioBack, out int procResult)
        {
            var idTransaccionParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Id_Transaccion", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = idTransaccion.GetValueOrDefault(), Precision = 18, Scale = 0 };
            if (!idTransaccion.HasValue)
                idTransaccionParam.Value = System.DBNull.Value;

            var usuarioBackParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Usuario_Back", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = usuarioBack, Size = 30 };
            if (usuarioBackParam.Value == null)
                usuarioBackParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };
            var procResultData = Database.SqlQuery<ActualizaUsuarioGestionBackTrasladoReturnModel>("EXEC @procResult = [dbo].[ACTUALIZAR_USUARIO_GESTION_BACK_TRASLADO] @Id_Transaccion, @Usuario_Back", idTransaccionParam, usuarioBackParam, procResultParam).ToList();

            procResult = (int)procResultParam.Value;
            return procResultData;
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.List<ActualizaUsuarioGestionBackTrasladoReturnModel>> ActualizaUsuarioGestionBackTrasladoAsync(decimal? idTransaccion, string usuarioBack)
        {
            var idTransaccionParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Id_Transaccion", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = idTransaccion.GetValueOrDefault(), Precision = 18, Scale = 0 };
            if (!idTransaccion.HasValue)
                idTransaccionParam.Value = System.DBNull.Value;

            var usuarioBackParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Usuario_Back", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = usuarioBack, Size = 30 };
            if (usuarioBackParam.Value == null)
                usuarioBackParam.Value = System.DBNull.Value;

            var procResultData = await Database.SqlQuery<ActualizaUsuarioGestionBackTrasladoReturnModel>("EXEC [dbo].[ACTUALIZAR_USUARIO_GESTION_BACK_TRASLADO] @Id_Transaccion, @Usuario_Back", idTransaccionParam, usuarioBackParam).ToListAsync();

            return procResultData;
        }

        public int ApartarCuentaGestionOutboundAsesor(int? idAsesor, string gestion, string aliado, string linea)
        {
            var idAsesorParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Id_Asesor", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Input, Value = idAsesor.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!idAsesor.HasValue)
                idAsesorParam.Value = System.DBNull.Value;

            var gestionParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Gestion", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = gestion, Size = 50 };
            if (gestionParam.Value == null)
                gestionParam.Value = System.DBNull.Value;

            var aliadoParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Aliado", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = aliado, Size = 200 };
            if (aliadoParam.Value == null)
                aliadoParam.Value = System.DBNull.Value;

            var lineaParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Linea", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = linea, Size = 200 };
            if (lineaParam.Value == null)
                lineaParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };

            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[APARTAR_CUENTA_GESTION_OUTBOUND_ASESOR] @Id_Asesor, @Gestion, @Aliado, @Linea", idAsesorParam, gestionParam, aliadoParam, lineaParam, procResultParam);

            return (int)procResultParam.Value;
        }

        //este procedimiento aparta una cuenta para la gestion outbound
        public int ApartarCuentaGestionOutbound(int? idAsesor, string formulario, string aliado, string operacion, string campana)
        {
            var idAsesorParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Id_Asesor", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Input, Value = idAsesor.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!idAsesor.HasValue)
                idAsesorParam.Value = System.DBNull.Value;

            var formularioParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Formulario", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = formulario, Size = 255 };
            if (formularioParam.Value == null)
                formularioParam.Value = System.DBNull.Value;

            var aliadoParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Aliado", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = aliado, Size = 255 };
            if (aliadoParam.Value == null)
                aliadoParam.Value = System.DBNull.Value;

            var operacionParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Operacion", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = operacion, Size = 255 };
            if (operacionParam.Value == null)
                operacionParam.Value = System.DBNull.Value;

            var campanaParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Campana", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = campana, Size = 255 };
            if (campanaParam.Value == null)
                campanaParam.Value = System.DBNull.Value;


            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };

            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[Apartar_Cuenta_Gestion_Blending] @Id_Asesor, @Formulario, @Aliado, @Operacion, @Campana", idAsesorParam, formularioParam, aliadoParam, operacionParam,campanaParam, procResultParam);

            return (int)procResultParam.Value;
        }

        public int Consultas(decimal? nombreCab, System.Data.DataTable detalles)
        {
            var nombreCabParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Nombre_Cab", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = nombreCab.GetValueOrDefault(), Precision = 18, Scale = 0 };
            if (!nombreCab.HasValue)
                nombreCabParam.Value = System.DBNull.Value;

            var detallesParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Detalles", SqlDbType = System.Data.SqlDbType.Structured, Direction = System.Data.ParameterDirection.Input, Value = detalles, TypeName = "dbo.TipoIConsultas" };
            if (detallesParam.Value == null)
                detallesParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };

            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[Consultas] @Nombre_Cab, @Detalles", nombreCabParam, detallesParam, procResultParam);

            return (int)procResultParam.Value;
        }
        public System.Collections.Generic.List<ActualizaUsuarioGestionOutTrasladoReturnModel> ActualizaUsuarioGestionOutTraslado(decimal? idTransaccion, string usuarioOut)
        {
            int procResult;
            return ActualizaUsuarioGestionOutTraslado(idTransaccion, usuarioOut, out procResult);
        }

        public System.Collections.Generic.List<ActualizaUsuarioGestionOutTrasladoReturnModel> ActualizaUsuarioGestionOutTraslado(decimal? idTransaccion, string usuarioOut, out int procResult)
        {
            var idTransaccionParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Id_Transaccion", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = idTransaccion.GetValueOrDefault(), Precision = 18, Scale = 0 };
            if (!idTransaccion.HasValue)
                idTransaccionParam.Value = System.DBNull.Value;

            var usuarioOutParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Usuario_Out", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = usuarioOut, Size = 30 };
            if (usuarioOutParam.Value == null)
                usuarioOutParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };
            var procResultData = Database.SqlQuery<ActualizaUsuarioGestionOutTrasladoReturnModel>("EXEC @procResult = [dbo].[ACTUALIZAR_USUARIO_GESTION_OUT_TRASLADO] @Id_Transaccion, @Usuario_Out", idTransaccionParam, usuarioOutParam, procResultParam).ToList();

            procResult = (int)procResultParam.Value;
            return procResultData;
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.List<ActualizaUsuarioGestionOutTrasladoReturnModel>> ActualizaUsuarioGestionOutTrasladoAsync(decimal? idTransaccion, string usuarioOut)
        {
            var idTransaccionParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Id_Transaccion", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = idTransaccion.GetValueOrDefault(), Precision = 18, Scale = 0 };
            if (!idTransaccion.HasValue)
                idTransaccionParam.Value = System.DBNull.Value;

            var usuarioOutParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Usuario_Out", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = usuarioOut, Size = 30 };
            if (usuarioOutParam.Value == null)
                usuarioOutParam.Value = System.DBNull.Value;

            var procResultData = await Database.SqlQuery<ActualizaUsuarioGestionOutTrasladoReturnModel>("EXEC [dbo].[ACTUALIZAR_USUARIO_GESTION_OUT_TRASLADO] @Id_Transaccion, @Usuario_Out", idTransaccionParam, usuarioOutParam).ToListAsync();

            return procResultData;
        }
        //procedure Cambio Estrato
        public System.Collections.Generic.List<ActualizaUsuarioGestionCambioEstratoReturnViewModel> ActualizaUsuarioGestionBackCambioEstrato(decimal? idTransaccion, string usuarioBack)
        {
            int procResult;
            return ActualizaUsuarioGestionBackCambioEstrato(idTransaccion, usuarioBack, out procResult);
        }

        public System.Collections.Generic.List<ActualizaUsuarioGestionCambioEstratoReturnViewModel> ActualizaUsuarioGestionBackCambioEstrato(decimal? idTransaccion, string usuarioBack, out int procResult)
        {
            var idTransaccionParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Id_Transaccion", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = idTransaccion.GetValueOrDefault(), Precision = 18, Scale = 0 };
            if (!idTransaccion.HasValue)
                idTransaccionParam.Value = System.DBNull.Value;

            var usuarioBackParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Usuario_Back", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = usuarioBack, Size = 30 };
            if (usuarioBackParam.Value == null)
                usuarioBackParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };
            var procResultData = Database.SqlQuery<ActualizaUsuarioGestionCambioEstratoReturnViewModel>("EXEC @procResult = [dbo].[ACTUALIZAR_USUARIO_GESTION_BACK_CAMBIO_ESTRATO] @Id_Transaccion, @Usuario_Back", idTransaccionParam, usuarioBackParam, procResultParam).ToList();

            procResult = (int)procResultParam.Value;
            return procResultData;
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.List<ActualizaUsuarioGestionCambioEstratoReturnViewModel>> ActualizaUsuarioGestionBackCambioEstratoAsync(decimal? idTransaccion, string usuarioBack)
        {
            var idTransaccionParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Id_Transaccion", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = idTransaccion.GetValueOrDefault(), Precision = 18, Scale = 0 };
            if (!idTransaccion.HasValue)
                idTransaccionParam.Value = System.DBNull.Value;

            var usuarioBackParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Usuario_Back", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = usuarioBack, Size = 30 };
            if (usuarioBackParam.Value == null)
                usuarioBackParam.Value = System.DBNull.Value;

            var procResultData = await Database.SqlQuery<ActualizaUsuarioGestionCambioEstratoReturnViewModel>("EXEC [dbo].[ACTUALIZAR_USUARIO_GESTION_BACK_CAMBIO_ESTRATO] @Id_Transaccion, @Usuario_Back", idTransaccionParam, usuarioBackParam).ToListAsync();

            return procResultData;
        }

        //procedure Liberaciones de Home Pass
        public System.Collections.Generic.List<ActualizarUsuarioGestionHHPPReturnViewModel> ActualizaUsuarioGestionBackHomePass(decimal? idTransaccion, string usuarioBack)
        {
            int procResult;
            return ActualizaUsuarioGestionBackHomePass(idTransaccion, usuarioBack, out procResult);
        }

        public System.Collections.Generic.List<ActualizarUsuarioGestionHHPPReturnViewModel> ActualizaUsuarioGestionBackHomePass(decimal? idTransaccion, string usuarioBack, out int procResult)
        {
            var idTransaccionParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Id_Transaccion", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = idTransaccion.GetValueOrDefault(), Precision = 18, Scale = 0 };
            if (!idTransaccion.HasValue)
                idTransaccionParam.Value = System.DBNull.Value;

            var usuarioBackParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Usuario_Back", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = usuarioBack, Size = 30 };
            if (usuarioBackParam.Value == null)
                usuarioBackParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };
            var procResultData = Database.SqlQuery<ActualizarUsuarioGestionHHPPReturnViewModel>("EXEC @procResult = [dbo].[ACTUALIZAR_USUARIO_GESTION_BACK_HHPP] @Id_Transaccion, @Usuario_Back", idTransaccionParam, usuarioBackParam, procResultParam).ToList();

            procResult = (int)procResultParam.Value;
            return procResultData;
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.List<ActualizarUsuarioGestionHHPPReturnViewModel>> ActualizaUsuarioGestionBackHomePassAsync(decimal? idTransaccion, string usuarioBack)
        {
            var idTransaccionParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Id_Transaccion", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = idTransaccion.GetValueOrDefault(), Precision = 18, Scale = 0 };
            if (!idTransaccion.HasValue)
                idTransaccionParam.Value = System.DBNull.Value;

            var usuarioBackParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Usuario_Back", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = usuarioBack, Size = 30 };
            if (usuarioBackParam.Value == null)
                usuarioBackParam.Value = System.DBNull.Value;

            var procResultData = await Database.SqlQuery<ActualizarUsuarioGestionHHPPReturnViewModel>("EXEC [dbo].[ACTUALIZAR_USUARIO_GESTION_BACK_HHPP] @Id_Transaccion, @Usuario_Back", idTransaccionParam, usuarioBackParam).ToListAsync();

            return procResultData;
        }

        //STORE PROCEDURE MATRICES

        public System.Collections.Generic.List<ActualizarUsuarioGestionBackCreacionMatrizReturnModel> ActualizaUsuarioGestionBackCreacionMatriz(decimal? idTransaccion, string usuarioBack)
        {
            int procResult;
            return ActualizaUsuarioGestionBackCreacionMatriz(idTransaccion, usuarioBack, out procResult);
        }

        public System.Collections.Generic.List<ActualizarUsuarioGestionBackCreacionMatrizReturnModel> ActualizaUsuarioGestionBackCreacionMatriz(decimal? idTransaccion, string usuarioBack, out int procResult)
        {
            var idTransaccionParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Id_Transaccion", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = idTransaccion.GetValueOrDefault(), Precision = 18, Scale = 0 };
            if (!idTransaccion.HasValue)
                idTransaccionParam.Value = System.DBNull.Value;

            var usuarioBackParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Usuario_Back", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = usuarioBack, Size = 30 };
            if (usuarioBackParam.Value == null)
                usuarioBackParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };
            var procResultData = Database.SqlQuery<ActualizarUsuarioGestionBackCreacionMatrizReturnModel>("EXEC @procResult = [dbo].[ACTUALIZAR_USUARIO_GESTION_BACK_CREACION_MATRIZ] @Id_Transaccion, @Usuario_Back", idTransaccionParam, usuarioBackParam, procResultParam).ToList();

            procResult = (int)procResultParam.Value;
            return procResultData;
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.List<ActualizarUsuarioGestionBackCreacionMatrizReturnModel>> ActualizaUsuarioGestionBackCreacionMatrizAsync(decimal? idTransaccion, string usuarioBack)
        {
            var idTransaccionParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Id_Transaccion", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = idTransaccion.GetValueOrDefault(), Precision = 18, Scale = 0 };
            if (!idTransaccion.HasValue)
                idTransaccionParam.Value = System.DBNull.Value;

            var usuarioBackParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Usuario_Back", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = usuarioBack, Size = 30 };
            if (usuarioBackParam.Value == null)
                usuarioBackParam.Value = System.DBNull.Value;

            var procResultData = await Database.SqlQuery<ActualizarUsuarioGestionBackCreacionMatrizReturnModel>("EXEC [dbo].[ACTUALIZAR_USUARIO_GESTION_BACK_CREACION_MATRIZ] @Id_Transaccion, @Usuario_Back", idTransaccionParam, usuarioBackParam).ToListAsync();

            return procResultData;
        }

        public System.Collections.Generic.List<ActualizarUsuarioGestionBackGestionMatrizReturnModel> ActualizaUsuarioGestionBackGestionMatriz(decimal? idTransaccion, string usuarioBack)
        {
            int procResult;
            return ActualizaUsuarioGestionBackGestionMatriz(idTransaccion, usuarioBack, out procResult);
        }

        public System.Collections.Generic.List<ActualizarUsuarioGestionBackGestionMatrizReturnModel> ActualizaUsuarioGestionBackGestionMatriz(decimal? idTransaccion, string usuarioBack, out int procResult)
        {
            var idTransaccionParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Id_Transaccion", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = idTransaccion.GetValueOrDefault(), Precision = 18, Scale = 0 };
            if (!idTransaccion.HasValue)
                idTransaccionParam.Value = System.DBNull.Value;

            var usuarioBackParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Usuario_Back", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = usuarioBack, Size = 30 };
            if (usuarioBackParam.Value == null)
                usuarioBackParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };
            var procResultData = Database.SqlQuery<ActualizarUsuarioGestionBackGestionMatrizReturnModel>("EXEC @procResult = [dbo].[ACTUALIZAR_USUARIO_GESTION_BACK_GESTION_MATRIZ] @Id_Transaccion, @Usuario_Back", idTransaccionParam, usuarioBackParam, procResultParam).ToList();

            procResult = (int)procResultParam.Value;
            return procResultData;
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.List<ActualizarUsuarioGestionBackGestionMatrizReturnModel>> ActualizaUsuarioGestionBackGestionMatrizAsync(decimal? idTransaccion, string usuarioBack)
        {
            var idTransaccionParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Id_Transaccion", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = idTransaccion.GetValueOrDefault(), Precision = 18, Scale = 0 };
            if (!idTransaccion.HasValue)
                idTransaccionParam.Value = System.DBNull.Value;

            var usuarioBackParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Usuario_Back", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = usuarioBack, Size = 30 };
            if (usuarioBackParam.Value == null)
                usuarioBackParam.Value = System.DBNull.Value;

            var procResultData = await Database.SqlQuery<ActualizarUsuarioGestionBackGestionMatrizReturnModel>("EXEC [dbo].[ACTUALIZAR_USUARIO_GESTION_BACK_GESTION_MATRIZ] @Id_Transaccion, @Usuario_Back", idTransaccionParam, usuarioBackParam).ToListAsync();

            return procResultData;
        }

        public System.Collections.Generic.List<ConsultaPaloteoSqlReturnModel> ConsultaPaloteoSql(string fechaInicial, string fechaFinal)
        {
            int procResult;
            return ConsultaPaloteoSql(fechaInicial, fechaFinal, out procResult);
        }

        public System.Collections.Generic.List<ConsultaPaloteoSqlReturnModel> ConsultaPaloteoSql(string fechaInicial, string fechaFinal, out int procResult)
        {
            var fechaInicialParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Fecha_Inicial", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = fechaInicial, Size = 30 };
            if (fechaInicialParam.Value == null)
                fechaInicialParam.Value = System.DBNull.Value;

            var fechaFinalParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Fecha_Final", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = fechaFinal, Size = 30 };
            if (fechaFinalParam.Value == null)
                fechaFinalParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };
            var procResultData = Database.SqlQuery<ConsultaPaloteoSqlReturnModel>("EXEC @procResult = [dbo].[CONSULTA_PALOTEO_SQL] @Fecha_Inicial, @Fecha_Final", fechaInicialParam, fechaFinalParam, procResultParam).ToList();

            procResult = (int)procResultParam.Value;
            return procResultData;
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.List<ConsultaPaloteoSqlReturnModel>> ConsultaPaloteoSqlAsync(string fechaInicial, string fechaFinal)
        {
            var fechaInicialParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Fecha_Inicial", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = fechaInicial, Size = 30 };
            if (fechaInicialParam.Value == null)
                fechaInicialParam.Value = System.DBNull.Value;

            var fechaFinalParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Fecha_Final", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = fechaFinal, Size = 30 };
            if (fechaFinalParam.Value == null)
                fechaFinalParam.Value = System.DBNull.Value;

            var procResultData = await Database.SqlQuery<ConsultaPaloteoSqlReturnModel>("EXEC [dbo].[CONSULTA_PALOTEO_SQL] @Fecha_Inicial, @Fecha_Final", fechaInicialParam, fechaFinalParam).ToListAsync();

            return procResultData;
        }

        public System.Collections.Generic.List<ConsultaGestionSqlReturnModel> ConsultaGestionSql(System.DateTime? fechaInicial, System.DateTime? fechaFinal, string aliado)
        {
            int procResult;
            return ConsultaGestionSql(fechaInicial, fechaFinal, aliado, out procResult);
        }

        public System.Collections.Generic.List<ConsultaGestionSqlReturnModel> ConsultaGestionSql(System.DateTime? fechaInicial, System.DateTime? fechaFinal, string aliado, out int procResult)
        {
            var fechaInicialParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Fecha_Inicial", SqlDbType = System.Data.SqlDbType.Date, Direction = System.Data.ParameterDirection.Input, Value = fechaInicial.GetValueOrDefault() };
            if (!fechaInicial.HasValue)
                fechaInicialParam.Value = System.DBNull.Value;

            var fechaFinalParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Fecha_Final", SqlDbType = System.Data.SqlDbType.Date, Direction = System.Data.ParameterDirection.Input, Value = fechaFinal.GetValueOrDefault() };
            if (!fechaFinal.HasValue)
                fechaFinalParam.Value = System.DBNull.Value;

            var aliadoParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Aliado", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = aliado, Size = 200 };
            if (aliadoParam.Value == null)
                aliadoParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };
            var procResultData = Database.SqlQuery<ConsultaGestionSqlReturnModel>("EXEC @procResult = [dbo].[CONSULTA_GESTION_SQL] @Fecha_Inicial, @Fecha_Final, @Aliado", fechaInicialParam, fechaFinalParam, aliadoParam, procResultParam).ToList();

            procResult = (int)procResultParam.Value;
            return procResultData;
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.List<ConsultaGestionSqlReturnModel>> ConsultaGestionSqlAsync(System.DateTime? fechaInicial, System.DateTime? fechaFinal, string aliado)
        {
            var fechaInicialParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Fecha_Inicial", SqlDbType = System.Data.SqlDbType.Date, Direction = System.Data.ParameterDirection.Input, Value = fechaInicial.GetValueOrDefault() };
            if (!fechaInicial.HasValue)
                fechaInicialParam.Value = System.DBNull.Value;

            var fechaFinalParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Fecha_Final", SqlDbType = System.Data.SqlDbType.Date, Direction = System.Data.ParameterDirection.Input, Value = fechaFinal.GetValueOrDefault() };
            if (!fechaFinal.HasValue)
                fechaFinalParam.Value = System.DBNull.Value;

            var aliadoParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Aliado", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = aliado, Size = 200 };
            if (aliadoParam.Value == null)
                aliadoParam.Value = System.DBNull.Value;

            var procResultData = await Database.SqlQuery<ConsultaGestionSqlReturnModel>("EXEC [dbo].[CONSULTA_GESTION_SQL] @Fecha_Inicial, @Fecha_Final, @Aliado", fechaInicialParam, fechaFinalParam, aliadoParam).ToListAsync();

            return procResultData;
        }

        public System.Collections.Generic.List<ConsultaRechazosAdminSqlReturnModel> ConsultaRechazosAdminSql(System.DateTime? fechaInicial, System.DateTime? fechaFinal)
        {
            int procResult;
            return ConsultaRechazosAdminSql(fechaInicial, fechaFinal, out procResult);
        }

        public System.Collections.Generic.List<ConsultaRechazosAdminSqlReturnModel> ConsultaRechazosAdminSql(System.DateTime? fechaInicial, System.DateTime? fechaFinal, out int procResult)
        {
            var fechaInicialParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Fecha_Inicial", SqlDbType = System.Data.SqlDbType.Date, Direction = System.Data.ParameterDirection.Input, Value = fechaInicial.GetValueOrDefault() };
            if (!fechaInicial.HasValue)
                fechaInicialParam.Value = System.DBNull.Value;

            var fechaFinalParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Fecha_Final", SqlDbType = System.Data.SqlDbType.Date, Direction = System.Data.ParameterDirection.Input, Value = fechaFinal.GetValueOrDefault() };
            if (!fechaFinal.HasValue)
                fechaFinalParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };
            var procResultData = Database.SqlQuery<ConsultaRechazosAdminSqlReturnModel>("EXEC @procResult = [dbo].[CONSULTA_RECHAZOS_ADMIN_SQL] @Fecha_Inicial, @Fecha_Final", fechaInicialParam, fechaFinalParam, procResultParam).ToList();

            procResult = (int)procResultParam.Value;
            return procResultData;
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.List<ConsultaRechazosAdminSqlReturnModel>> ConsultaRechazosAdminSqlAsync(System.DateTime? fechaInicial, System.DateTime? fechaFinal)
        {
            var fechaInicialParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Fecha_Inicial", SqlDbType = System.Data.SqlDbType.Date, Direction = System.Data.ParameterDirection.Input, Value = fechaInicial.GetValueOrDefault() };
            if (!fechaInicial.HasValue)
                fechaInicialParam.Value = System.DBNull.Value;

            var fechaFinalParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Fecha_Final", SqlDbType = System.Data.SqlDbType.Date, Direction = System.Data.ParameterDirection.Input, Value = fechaFinal.GetValueOrDefault() };
            if (!fechaFinal.HasValue)
                fechaFinalParam.Value = System.DBNull.Value;

            var procResultData = await Database.SqlQuery<ConsultaRechazosAdminSqlReturnModel>("EXEC [dbo].[CONSULTA_RECHAZOS_ADMIN_SQL] @Fecha_Inicial, @Fecha_Final", fechaInicialParam, fechaFinalParam).ToListAsync();

            return procResultData;
        }


        public System.Collections.Generic.List<ConsultaBlendingFormularioDestinoReturnViewModel> ConsultaBlendingFormularioDestino(string aliado)
        {
            int procResult;
            return ConsultaBlendingFormularioDestino(aliado, out procResult);
        }

        public System.Collections.Generic.List<ConsultaBlendingFormularioDestinoReturnViewModel> ConsultaBlendingFormularioDestino( string aliado, out int procResult)
        {

            var aliadoParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Aliado", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = aliado, Size = 200 };
            if (aliadoParam.Value == null)
                aliadoParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };
            var procResultData = Database.SqlQuery<ConsultaBlendingFormularioDestinoReturnViewModel>("EXEC @procResult = [dbo].[CONSULTA_BLENDING_FORMULARIO_DESTINO]  @Aliado",  aliadoParam, procResultParam).ToList();

            procResult = (int)procResultParam.Value;
            return procResultData;
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.List<ConsultaBlendingFormularioDestinoReturnViewModel>> ConsultaBlendingFormularioDestinoAsync( string aliado)
        {
            var aliadoParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Aliado", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = aliado, Size = 200 };
            if (aliadoParam.Value == null)
                aliadoParam.Value = System.DBNull.Value;

            var procResultData = await Database.SqlQuery<ConsultaBlendingFormularioDestinoReturnViewModel>("EXEC [dbo].[CONSULTA_BLENDING_FORMULARIO_DESTINO] @Aliado",  aliadoParam).ToListAsync();

            return procResultData;
        }

        //procedimiento apartar cuenta back elite

        public int ApartarCuentaGestionBackElite(decimal Cedula)
        {
            var cedulaParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Usuario", SqlDbType = System.Data.SqlDbType.Decimal, Direction = System.Data.ParameterDirection.Input, Value = Cedula, Precision = 18, Scale = 0 };
            if (cedulaParam.Value== null)
                cedulaParam.Value = System.DBNull.Value;
            
            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };

            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[Apartar_Cuenta_Back_Elite] @Usuario", cedulaParam, procResultParam);

            return (int)procResultParam.Value;
        }

        public int ApartarCuentaGestionRecurrencia(decimal idAsesor)
        {
            var IdAsesorParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@USUARIO", SqlDbType = System.Data.SqlDbType.Decimal, Direction = System.Data.ParameterDirection.Input, Value = idAsesor, Precision = 18, Scale = 0 };
            if (IdAsesorParam.Value == null)
                IdAsesorParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };

            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[APARTAR_CUENTA_RECURRENCIA] @USUARIO", IdAsesorParam, procResultParam);

            return (int)procResultParam.Value;
        }


        public System.Collections.Generic.List<ConsultaBlendingOperacionDestinoReturnViewModel> ConsultaBlendingOperacionDestino(string aliado, string formulario)
        {
            int procResult;
            return ConsultaBlendingOperacionDestino(aliado, formulario, out procResult);
        }

        public System.Collections.Generic.List<ConsultaBlendingOperacionDestinoReturnViewModel> ConsultaBlendingOperacionDestino(string aliado, string formulario, out int procResult)
        {

            var aliadoParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Aliado", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = aliado, Size = 200 };
            if (aliadoParam.Value == null)
                aliadoParam.Value = System.DBNull.Value;

            var formularioParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Formulario_destino", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = formulario, Size = 200 };
            if (formularioParam.Value == null)
                formularioParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };
            var procResultData = Database.SqlQuery<ConsultaBlendingOperacionDestinoReturnViewModel>("EXEC @procResult = [dbo].[CONSULTA_BLENDING_OPERACION_DESTINO]  @Aliado, @Formulario_destino", aliadoParam, formularioParam, procResultParam).ToList();

            procResult = (int)procResultParam.Value;
            return procResultData;
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.List<ConsultaBlendingOperacionDestinoReturnViewModel>> ConsultaBlendingOperacionDestinoAsync(string aliado, string formulario)
        {
            var aliadoParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Aliado", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = aliado, Size = 200 };
            if (aliadoParam.Value == null)
                aliadoParam.Value = System.DBNull.Value;

            var formularioParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Formulario_destino", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = formulario, Size = 200 };
            if (formularioParam.Value == null)
                formularioParam.Value = System.DBNull.Value;

            var procResultData = await Database.SqlQuery<ConsultaBlendingOperacionDestinoReturnViewModel>("EXEC [dbo].[CONSULTA_BLENDING_OPERACION_DESTINO] @Aliado, @Formulario_destino", aliadoParam, formularioParam).ToListAsync();

            return procResultData;
        }


        public System.Collections.Generic.List<ConsultaBlendingCampañaDestinoReturnViewModel> ConsultaBlendingCampanaDestino(string aliado, string formulario, string operacion)
        {
            int procResult;
            return ConsultaBlendingCampanaDestino(aliado, formulario, operacion, out procResult);
        }

        public System.Collections.Generic.List<ConsultaBlendingCampañaDestinoReturnViewModel> ConsultaBlendingCampanaDestino(string aliado, string formulario, string operacion, out int procResult)
        {

            var aliadoParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Aliado", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = aliado, Size = 200 };
            if (aliadoParam.Value == null)
                aliadoParam.Value = System.DBNull.Value;

            var formularioParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Formulario_destino", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = formulario, Size = 200 };
            if (formularioParam.Value == null)
                formularioParam.Value = System.DBNull.Value;

            var operacionParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Operacion_destino", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = operacion, Size = 200 };
            if (operacionParam.Value == null)
                operacionParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };
            var procResultData = Database.SqlQuery<ConsultaBlendingCampañaDestinoReturnViewModel>("EXEC @procResult = [dbo].[CONSULTA_BLENDING_CAMPAÑA_DESTINO]  @Aliado, @Formulario_destino, @Operacion_destino", aliadoParam, formularioParam, operacionParam, procResultParam).ToList();

            procResult = (int)procResultParam.Value;
            return procResultData;
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.List<ConsultaBlendingCampañaDestinoReturnViewModel>> ConsultaBlendingCampanaDestinoAsync(string aliado, string formulario, string operacion)
        {
            var aliadoParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Aliado", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = aliado, Size = 200 };
            if (aliadoParam.Value == null)
                aliadoParam.Value = System.DBNull.Value;

            var formularioParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Formulario_destino", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = formulario, Size = 200 };
            if (formularioParam.Value == null)
                formularioParam.Value = System.DBNull.Value;

            var operacionParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Operacion_destino", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = operacion, Size = 200 };
            if (operacionParam.Value == null)
                operacionParam.Value = System.DBNull.Value;

            var procResultData = await Database.SqlQuery<ConsultaBlendingCampañaDestinoReturnViewModel>("EXEC [dbo].[CONSULTA_BLENDING_CAMPAÑA_DESTINO] @Aliado, @Formulario_destino, @Operacion_destino", aliadoParam, formularioParam, operacionParam).ToListAsync();

            return procResultData;
        }

        //procedimiento apartar BITACORA DE INCIDENTES

        public int ApartarCuentaIncidente(decimal Cedula, decimal IdRegistro)
        {
            var cedulaParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Usuario", SqlDbType = System.Data.SqlDbType.Decimal, Direction = System.Data.ParameterDirection.Input, Value = Cedula, Precision = 18, Scale = 0 };
            if (cedulaParam.Value == null)
                cedulaParam.Value = System.DBNull.Value;

            var registroParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@IdRegistro", SqlDbType = System.Data.SqlDbType.Decimal, Direction = System.Data.ParameterDirection.Input, Value = IdRegistro, Precision = 18, Scale = 0 };
            if (registroParam.Value == null)
                registroParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };

            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[Actualizar_Usuario_Back_Incidentes] @IdRegistro, @Usuario", registroParam, cedulaParam, procResultParam);

            return (int)procResultParam.Value;
        }

        public int ActualizaBDPersonal()
        {

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };

            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[INSERTAR_BASE_PERSONAL_HOLOS] ", procResultParam);

            return (int)procResultParam.Value;
        }

    }
}
