
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
        public System.Data.Entity.DbSet<CuentasSiembraHD> CuentasSiembra { get; set; } // TBL_ACTIVACION_CLARO_VIDEO


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

        public int ApartarCuentaGestionOutboundAsesor(int? idAsesor, string gestion)
        {
            var idAsesorParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Id_Asesor", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Input, Value = idAsesor.GetValueOrDefault(), Precision = 10, Scale = 0 };
            if (!idAsesor.HasValue)
                idAsesorParam.Value = System.DBNull.Value;

            var gestionParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@Gestion", SqlDbType = System.Data.SqlDbType.VarChar, Direction = System.Data.ParameterDirection.Input, Value = gestion, Size = 50 };
            if (gestionParam.Value == null)
                gestionParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };

            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[APARTAR_CUENTA_GESTION_OUTBOUND_ASESOR] @Id_Asesor, @Gestion", idAsesorParam, gestionParam, procResultParam);

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
    }
}
