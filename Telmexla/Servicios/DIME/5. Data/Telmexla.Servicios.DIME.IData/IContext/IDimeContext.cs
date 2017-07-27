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
using Telmexla.Servicios.DIME.Entity;


namespace Telmexla.Servicios.DIME.IData.IContext
{

    public interface IDimeContext : System.IDisposable
    {
        System.Data.Entity.DbSet<Acceso> Accesoes { get; set; } // TBL_ACCESOS
        System.Data.Entity.DbSet<ClientesTodo> ClientesTodoes { get; set; } // TBL_CLIENTES_TODOS
        System.Data.Entity.DbSet<DatosAdicionalesCliente> DatosAdicionalesClientes { get; set; } // TBL_DATOS_ADICIONALES_CLIENTES
        System.Data.Entity.DbSet<GestionOutbound> GestionOutbounds { get; set; } // TBL_GESTION_OUTBOUND
        System.Data.Entity.DbSet<BasePersonalHolo> BasePersonalHoloes { get; set; } // TBL_BASE_PERSONAL_HOLOS
        System.Data.Entity.DbSet<Linea> Lineas { get; set; } // TBL_LINEA
        System.Data.Entity.DbSet<ModosLogin> ModosLogins { get; set; } // TBL_MODOS_LOGINS
        System.Data.Entity.DbSet<PreguntasDesbloqueo> PreguntasDesbloqueos { get; set; } // TBL_PREGUNTAS_DESBLOQUEO
        System.Data.Entity.DbSet<RegistroSesion> RegistroSesions { get; set; } // TBL_REGISTRO_SESION
        System.Data.Entity.DbSet<Usuario> Usuarios { get; set; } // TBL_USUARIOS
        System.Data.Entity.DbSet<CcSegundaTipificacion> CcSegundaTipificacions { get; set; }
        System.Data.Entity.DbSet<UsuariosXAcceso> UsuariosXAccesoes { get; set; } // TBL_USUARIOS_X_ACCESOS
        System.Data.Entity.DbSet<UsuariosXPreguntasDesb> UsuariosXPreguntasDesbs { get; set; } // TBL_USUARIOS_X_PREGUNTAS_DESB
        System.Data.Entity.DbSet<TmpMaestroHobbiesCliente> TmpMaestroHobbiesClientes { get; set; } // TMP_MAESTRO_HOBBIES_CLIENTE
        System.Data.Entity.DbSet<ConvenioElectronico> ConvenioElectronicoes { get; set; } // TBL_CONVENIO_ELECTRONICO
        System.Data.Entity.DbSet<CierreCiclo> CierreCicloes { get; set; } // TBL_CIERRE_CICLO
        System.Data.Entity.DbSet<ClaroVideo> ClaroVideos { get; set; } // TBL_CLARO_VIDEO
        System.Data.Entity.DbSet<DocsisOverlap> DocsisOverlaps { get; set; } // TBL_DOCSIS_OVERLAP
        System.Data.Entity.DbSet<Ingreso> Ingresoes { get; set; } // TBL_INGRESOS
        System.Data.Entity.DbSet<NotasIngreso> NotasIngresoes { get; set; } // TBL_NOTAS_INGRESO
        System.Data.Entity.DbSet<MaestroMarcacione> MaestroMarcaciones { get; set; } //TMP_MAESTRO_MARCACION
        System.Data.Entity.DbSet<NotificacionesBuenServicio> NotificacionesBuenServicio { get; set; } //NOTIFICACIONES_BUEN_SERVICIO
        System.Data.Entity.DbSet<LogCierreCiclo> LogCierreCicloes { get; set; } // TBL_LOG_CIERRE_CICLO
        System.Data.Entity.DbSet<LogClaroVideo> LogClaroVideos { get; set; } // TBL_LOG_CLARO_VIDEO
        System.Data.Entity.DbSet<LogConvenioElectronico> LogConvenioElectronicoes { get; set; } // TBL_LOG_CONVENIO_ELECTRONICO
        System.Data.Entity.DbSet<LogDocsisOverlap> LogDocsisOverlaps { get; set; } // TBL_LOG_DOCSIS_OVERLAP
        System.Data.Entity.DbSet<PqrMaestroCodCierre> PqrMaestroCodCierres { get; set; } // TMP_PQR_MAESTRO_COD_CIERRE
        System.Data.Entity.DbSet<Rechazo> Rechazoes { get; set; } // TBL_RECHAZOS
        System.Data.Entity.DbSet<IngresoTraslado> IngresoTraslados { get; set; } // TBL_INGRESOS_TRASLADOS
        System.Data.Entity.DbSet<NotasTraslado> NotasTraslados { get; set; } // TBL_NOTAS_TRASLADOS
        System.Data.Entity.DbSet<MaestroNodo> MaestroNodos { get; set; } // TBL_NOTAS_TRASLADOS
        System.Data.Entity.DbSet<ActivacionClaroVideo> ActivacionesClaroVideo { get; set; } // TBL_ACTIVACION_CLARO_VIDEO
        System.Data.Entity.DbSet<CuentasSiembraHD> CuentasSiembra { get; set; } // TBL_CUENTAS_SIEMBRA_HD
        System.Data.Entity.DbSet<SiembraHD> ActivacionSiembra { get; set; } // TBL_SIEMBRA_HD
        System.Data.Entity.DbSet<CambioEstrato> cambioEstratos { get; set; } // TBL_CAMBIO_DE_ESTRATO
        System.Data.Entity.DbSet<TraficoTraslado> traficoTraslados { get; set; } // TBL_TRAFICO_TRASLADO
        System.Data.Entity.DbSet<LiberacionHomePass> liberacionesHomePass { get; set; } // TBL_LIBERACION_HOME_PASS
        System.Data.Entity.DbSet<GestionMatriz> gestionMatrices { get; set; } // TBL_GESTION_MATRICES
        System.Data.Entity.DbSet<IngresosSoporte> IngresosSoportes { get; set; } // TBL_INGRESOS_SOPORTE
        System.Data.Entity.DbSet<RazonIngresoSoporte> RazonIngresoSoportes { get; set; } // TBL_RAZON_INGRESO_SOPORTE
        System.Data.Entity.DbSet<Subrazon1IngresoSoporte> Subrazon1IngresoSoporte { get; set; } // TBL_SUBRAZON1_INGRESO_SOPORTE
        System.Data.Entity.DbSet<Subrazon2IngresoSoporte> Subrazon2IngresoSoporte { get; set; } // TBL_SUBRAZON2_INGRESO_SOPORTE
        System.Data.Entity.DbSet<UsuariosNotificados> usuariosNotificados { get; set; } // TBL_USUARIOS_NOTIFICADOS
        System.Data.Entity.DbSet<BalanceScoreCard> balanceScoreCards { get; set; } // TBL_BALANCE_SCORE_CARD
        System.Data.Entity.DbSet<CuentasSiguienteMejorOferta> CuentaSMO { get; set; } // TBL_CUENTAS_SIGUENTE_MEJOR_OFERTA
        System.Data.Entity.DbSet<SiguienteMejorOferta> SMO { get; set; } // TBL_VENTAS_SMO_INBOUND
        System.Data.Entity.DbSet<SmoRentaActual> SmoRentaActuals { get; set; } // TBL_SMO_RENTA_ACTUAL
        System.Data.Entity.DbSet<SmoTarifaActual> SmoTarifaActuals { get; set; } // TBL_SMO_TARIFA_ACTUAL
        System.Data.Entity.DbSet<TrasladoFallido> TrasladoFallidos { get; set; } // TBL_TRASLADOS_FALLIDOS
        System.Data.Entity.DbSet<UsabilidadConvenioInbound> UsabilidadConvenioInbound { get; set; } // TBL_USABILIDAD_ACTIVACION_CONVENIO
        System.Data.Entity.DbSet<Departamento> Departamentos { get; set; } // TBL_DEPARTAMENTOS_CIUDADES
        System.Data.Entity.DbSet<UsabilidadBusquedaCuentaInbound> UsabilidadBusquedaClienteInbound { get; set; } // TBL_USABILIDAD_BUSQUEDA_CLIENTE
        System.Data.Entity.DbSet<SkillsUsuariosBlending> SkillsUsuariosBlending { get; set; } // TBL_SKILLS_USUARIOS_BLENDING
        System.Data.Entity.DbSet<BlendingFueraNivel> blendingFueraNiveles { get; set; } // TMP_GBC_FUERA_NIVELES
        System.Data.Entity.DbSet<DistribucionBlending> DistribucionBlendings { get; set; } // TBL_DISTRIBUCIONES_BLENDING
        System.Data.Entity.DbSet<GBPFueraNiveles> GBPFueradeNiveles { get; set; } // TBL_GBP_FUERA_NIVELES
        System.Data.Entity.DbSet<GBLFueraNiveles> GBLFueradeNiveles { get; set; } // TBL_GBL_FUERA_NIVELES
        System.Data.Entity.DbSet<GBPRentabilizacion> GBPRentabilizacion { get; set; } // TBL_GBP_RENTABILIZACION
        System.Data.Entity.DbSet<GBLRentabilizacion> GBLRentabilizacion { get; set; } // TBL_GBL_RENTABILIZACION
        System.Data.Entity.DbSet<GBC_Rentabilizacion> GBCRentabilizacion { get; set; } // TMP_GBC_RENTABILIZACION
        System.Data.Entity.DbSet<CuentasMejorasTecnicas> CuentasMejorasTecnicas { get; set; } // TBL_CUENTAS_MEJORAS_TECNICAS
        System.Data.Entity.DbSet<MejorasTecnicas> MejorasTecnicas { get; set; } // TBL_MEJORAS_TECNICAS
        System.Data.Entity.DbSet<GBPProducto> GBPProducto { get; set; } // TBL_GBP_PRODUCTO
        System.Data.Entity.DbSet<GBLProducto> GBLProducto { get; set; } // TBL_GBL_PRODUCTO
        System.Data.Entity.DbSet<GBCProducto> GBCProducto { get; set; } // TMP_GBC_PRODUCTO
        System.Data.Entity.DbSet<GBPDocsis> GBPDocsis { get; set; } // TBL_GBP_DOCSIS_OVERLAP
        System.Data.Entity.DbSet<GBLDocsis> GBLDocsis { get; set; } // TBL_GBL_DOCSIS_OVERLAP
        System.Data.Entity.DbSet<GBCDocsis> GBCDocsis { get; set; } // TMP_GBC_DOCSIS_OVERLAP
        System.Data.Entity.DbSet<Retencion> Retencion { get; set; } // TBL_RETENCION
        System.Data.Entity.DbSet<MultiplayCargue> MultiplayCargue { get; set; } 
        System.Data.Entity.DbSet<MultiPlayRegistro> MultiPlayRegistro { get; set; } 
        System.Data.Entity.DbSet<MecMonitoreosP> MecMonitoreosP { get; set; }
        System.Data.Entity.DbSet<MecMonitoreosL> MecMonitoreosL { get; set; }
        System.Data.Entity.DbSet<MecProcesos> MecProcesos { get; set; }
        System.Data.Entity.DbSet<MecLineas> MecLineas { get; set; }
        System.Data.Entity.DbSet<MecListasDistribucion> MecListasDistribucion { get; set; }
        System.Data.Entity.DbSet<MecTipoAlarmas> MecTipoAlarmas { get; set; }
        System.Data.Entity.DbSet<CargaBaseFoxInbound> CargaBaseFoxInbound { get; set; }
        System.Data.Entity.DbSet<GestionFoxInbound> GestionFoxInbound { get; set; }
        System.Data.Entity.DbSet<CcBaseMejoramiento> CcBaseMejoramientoes { get; set; } // TBL_CC_BASE_MEJORAMIENTO
        System.Data.Entity.DbSet<CcGestionResidencialPredictivo> CcGestionResidencialPredictivoes { get; set; } // TBL_CC_GESTION_RESIDENCIAL_PREDICTIVO
        System.Data.Entity.DbSet<CcResidencialPredictivoInfo> CcResidencialPredictivoInfoes { get; set; } // TBL_CC_RESIDENCIAL_PREDICTIVO_INFO
        System.Data.Entity.DbSet<BELSolicitudes> BELSolicitudes { get; set; }
        System.Data.Entity.DbSet<BEMDetalleDeGestion> BEMDetalleDeGestion { get; set; }
        System.Data.Entity.DbSet<BEMDetalleEscalamientos> BEMDetalleEscalamientos { get; set; }
        System.Data.Entity.DbSet<BEMDistribuciones> BEMDistribuciones { get; set; }
        System.Data.Entity.DbSet<BEMRazonMalEscalamiento> BEMRazonMalEscalamiento { get; set; }
        System.Data.Entity.DbSet<BEMTipoDeEscalamientos> BEMTipoDeEscalamientos { get; set; }
        System.Data.Entity.DbSet<BEPSolicitudes> BEPSolicitudes { get; set; }
        System.Data.Entity.DbSet<NodosZonificados> NodosZonificados { get; set; }


        int SaveChanges();
        System.Threading.Tasks.Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken);

        // Stored Procedures
        System.Collections.Generic.List<ActualizarUsuarioGestionBackIngresoReturnModel> ActualizarUsuarioGestionBackIngreso(decimal? idIngreso, string usuarioBack);
        System.Collections.Generic.List<ActualizarUsuarioGestionBackIngresoReturnModel> ActualizarUsuarioGestionBackIngreso(decimal? idIngreso, string usuarioBack, out int procResult);
        System.Threading.Tasks.Task<System.Collections.Generic.List<ActualizarUsuarioGestionBackIngresoReturnModel>> ActualizarUsuarioGestionBackIngresoAsync(decimal? idIngreso, string usuarioBack);


        System.Collections.Generic.List<ActualizaUsuarioGestionBackTrasladoReturnModel> ActualizaUsuarioGestionBackTraslado(decimal? idTransaccion, string usuarioBack);
        System.Collections.Generic.List<ActualizaUsuarioGestionBackTrasladoReturnModel> ActualizaUsuarioGestionBackTraslado(decimal? idTransaccion, string usuarioBack, out int procResult);
        System.Threading.Tasks.Task<System.Collections.Generic.List<ActualizaUsuarioGestionBackTrasladoReturnModel>> ActualizaUsuarioGestionBackTrasladoAsync(decimal? idTransaccion, string usuarioBack);


        System.Collections.Generic.List<ActualizaUsuarioGestionOutTrasladoReturnModel> ActualizaUsuarioGestionOutTraslado(decimal? idTransaccion, string usuarioOut);
        System.Collections.Generic.List<ActualizaUsuarioGestionOutTrasladoReturnModel> ActualizaUsuarioGestionOutTraslado(decimal? idTransaccion, string usuarioOut, out int procResult);
        System.Threading.Tasks.Task<System.Collections.Generic.List<ActualizaUsuarioGestionOutTrasladoReturnModel>> ActualizaUsuarioGestionOutTrasladoAsync(decimal? idTransaccion, string usuarioOut);


        int ApartarCuentaGestionOutboundAsesor(int? idAsesor, string gestion, string aliado, string linea);
        //este procedimiento seleciona una cuenta disponible para la gestion outbound
        int ApartarCuentaGestionOutbound(int? idAsesor, string formulario, string aliado, string operacion, string campana);
        // ApartarCuentaGestionOutboundAsesorAsync cannot be created due to having out parameters, or is relying on the procedure result (int)

        int Consultas(decimal? nombreCab, System.Data.DataTable detalles);
        // ConsultasAsync cannot be created due to having out parameters, or is relying on the procedure result (int)

        // Stored Procedures Cambio Estrato
        System.Collections.Generic.List<ActualizaUsuarioGestionCambioEstratoReturnViewModel> ActualizaUsuarioGestionBackCambioEstrato(decimal? idIngreso, string usuarioBack);
        System.Collections.Generic.List<ActualizaUsuarioGestionCambioEstratoReturnViewModel> ActualizaUsuarioGestionBackCambioEstrato(decimal? idIngreso, string usuarioBack, out int procResult);
        System.Threading.Tasks.Task<System.Collections.Generic.List<ActualizaUsuarioGestionCambioEstratoReturnViewModel>> ActualizaUsuarioGestionBackCambioEstratoAsync(decimal? idIngreso, string usuarioBack);

        // Stored Procedures Liberaciones de Home Pass
        System.Collections.Generic.List<ActualizarUsuarioGestionHHPPReturnViewModel> ActualizaUsuarioGestionBackHomePass(decimal? idIngreso, string usuarioBack);
        System.Collections.Generic.List<ActualizarUsuarioGestionHHPPReturnViewModel> ActualizaUsuarioGestionBackHomePass(decimal? idIngreso, string usuarioBack, out int procResult);
        System.Threading.Tasks.Task<System.Collections.Generic.List<ActualizarUsuarioGestionHHPPReturnViewModel>> ActualizaUsuarioGestionBackHomePassAsync(decimal? idIngreso, string usuarioBack);
        //store procedure matrices
        System.Collections.Generic.List<ActualizarUsuarioGestionBackCreacionMatrizReturnModel> ActualizaUsuarioGestionBackCreacionMatriz(decimal? idIngreso, string usuarioBack);
        System.Collections.Generic.List<ActualizarUsuarioGestionBackCreacionMatrizReturnModel> ActualizaUsuarioGestionBackCreacionMatriz(decimal? idIngreso, string usuarioBack, out int procResult);
        System.Threading.Tasks.Task<System.Collections.Generic.List<ActualizarUsuarioGestionBackCreacionMatrizReturnModel>> ActualizaUsuarioGestionBackCreacionMatrizAsync(decimal? idIngreso, string usuarioBack);
        System.Collections.Generic.List<ActualizarUsuarioGestionBackGestionMatrizReturnModel> ActualizaUsuarioGestionBackGestionMatriz(decimal? idIngreso, string usuarioBack);
        System.Collections.Generic.List<ActualizarUsuarioGestionBackGestionMatrizReturnModel> ActualizaUsuarioGestionBackGestionMatriz(decimal? idIngreso, string usuarioBack, out int procResult);
        System.Threading.Tasks.Task<System.Collections.Generic.List<ActualizarUsuarioGestionBackGestionMatrizReturnModel>> ActualizaUsuarioGestionBackGestionMatrizAsync(decimal? idIngreso, string usuarioBack);

        System.Collections.Generic.List<ConsultaPaloteoSqlReturnModel> ConsultaPaloteoSql(string fechaInicial, string fechaFinal);
        System.Collections.Generic.List<ConsultaPaloteoSqlReturnModel> ConsultaPaloteoSql(string fechaInicial, string fechaFinal, out int procResult);
        System.Threading.Tasks.Task<System.Collections.Generic.List<ConsultaPaloteoSqlReturnModel>> ConsultaPaloteoSqlAsync(string fechaInicial, string fechaFinal);
        System.Collections.Generic.List<ConsultaGestionSqlReturnModel> ConsultaGestionSql(System.DateTime? fechaInicial, System.DateTime? fechaFinal, string aliado);
        System.Collections.Generic.List<ConsultaGestionSqlReturnModel> ConsultaGestionSql(System.DateTime? fechaInicial, System.DateTime? fechaFinal, string aliado, out int procResult);
        System.Threading.Tasks.Task<System.Collections.Generic.List<ConsultaGestionSqlReturnModel>> ConsultaGestionSqlAsync(System.DateTime? fechaInicial, System.DateTime? fechaFinal, string aliado);
        System.Collections.Generic.List<ConsultaRechazosAdminSqlReturnModel> ConsultaRechazosAdminSql(System.DateTime? fechaInicial, System.DateTime? fechaFinal);
        System.Collections.Generic.List<ConsultaRechazosAdminSqlReturnModel> ConsultaRechazosAdminSql(System.DateTime? fechaInicial, System.DateTime? fechaFinal, out int procResult);
        System.Threading.Tasks.Task<System.Collections.Generic.List<ConsultaRechazosAdminSqlReturnModel>> ConsultaRechazosAdminSqlAsync(System.DateTime? fechaInicial, System.DateTime? fechaFinal);
        System.Collections.Generic.List<ConsultaBlendingFormularioDestinoReturnViewModel> ConsultaBlendingFormularioDestino(string aliado);
         System.Collections.Generic.List<ConsultaBlendingFormularioDestinoReturnViewModel> ConsultaBlendingFormularioDestino(string aliado, out int procResult);
        System.Threading.Tasks.Task<System.Collections.Generic.List<ConsultaBlendingFormularioDestinoReturnViewModel>> ConsultaBlendingFormularioDestinoAsync(string aliado);

        //apartar cuenta de gestion back elite
        int ApartarCuentaGestionBackElite(decimal Cedula, string TipoTrabajo);

    }



}
