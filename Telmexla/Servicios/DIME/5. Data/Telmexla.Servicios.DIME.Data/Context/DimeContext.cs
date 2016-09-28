
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
        public System.Data.Entity.DbSet<Linea> Lineas { get; set; } // TBL_LINEA
        public System.Data.Entity.DbSet<ModosLogin> ModosLogins { get; set; } // TBL_MODOS_LOGINS
        public System.Data.Entity.DbSet<PreguntasDesbloqueo> PreguntasDesbloqueos { get; set; } // TBL_PREGUNTAS_DESBLOQUEO
        public System.Data.Entity.DbSet<RegistroSesion> RegistroSesions { get; set; } // TBL_REGISTRO_SESION
        public System.Data.Entity.DbSet<Usuario> Usuarios { get; set; } // TBL_USUARIOS
        public System.Data.Entity.DbSet<UsuariosXAcceso> UsuariosXAccesoes { get; set; } // TBL_USUARIOS_X_ACCESOS
        public System.Data.Entity.DbSet<UsuariosXPreguntasDesb> UsuariosXPreguntasDesbs { get; set; } // TBL_USUARIOS_X_PREGUNTAS_DESB

        static DimeContext()
        {
            System.Data.Entity.Database.SetInitializer<DimeContext>(null);
        }

        public DimeContext()
            : base("Name=DimeContext")
        {
            Configuration.ProxyCreationEnabled = false;
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
            modelBuilder.Configurations.Add(new LineaConfiguration());
            modelBuilder.Configurations.Add(new ModosLoginConfiguration());
            modelBuilder.Configurations.Add(new PreguntasDesbloqueoConfiguration());
            modelBuilder.Configurations.Add(new RegistroSesionConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new UsuariosXAccesoConfiguration());
            modelBuilder.Configurations.Add(new UsuariosXPreguntasDesbConfiguration());
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new AccesoConfiguration(schema));
            modelBuilder.Configurations.Add(new LineaConfiguration(schema));
            modelBuilder.Configurations.Add(new ModosLoginConfiguration(schema));
            modelBuilder.Configurations.Add(new PreguntasDesbloqueoConfiguration(schema));
            modelBuilder.Configurations.Add(new RegistroSesionConfiguration(schema));
            modelBuilder.Configurations.Add(new UsuarioConfiguration(schema));
            modelBuilder.Configurations.Add(new UsuariosXAccesoConfiguration(schema));
            modelBuilder.Configurations.Add(new UsuariosXPreguntasDesbConfiguration(schema));
            return modelBuilder;
        }
    }
}
