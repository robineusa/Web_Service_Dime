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


        int ApartarCuentaGestionOutboundAsesor(int? idAsesor, string gestion);
        // ApartarCuentaGestionOutboundAsesorAsync cannot be created due to having out parameters, or is relying on the procedure result (int)

        int Consultas(decimal? nombreCab, System.Data.DataTable detalles);
        // ConsultasAsync cannot be created due to having out parameters, or is relying on the procedure result (int)


    }

}


