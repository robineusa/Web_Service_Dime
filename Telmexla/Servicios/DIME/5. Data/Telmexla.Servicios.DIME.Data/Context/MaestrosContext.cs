// <auto-generated>
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
    using IData.IContext;
    using System.Linq;
    using Telmexla.Servicios.DIME.Entity;
    using Telmexla.Servicios.DIME.Data.Configuration;

    public class MaestrosContext : System.Data.Entity.DbContext, IMaestrosContext
    {

        public System.Data.Entity.DbSet<MaestroOutboundCausa> MaestroOutboundCausas { get; set; } // MAESTRO_OUTBOUND_CAUSA
        public System.Data.Entity.DbSet<MaestroOutboundCierre> MaestroOutboundCierres { get; set; } // MAESTRO_OUTBOUND_CIERRE
        public System.Data.Entity.DbSet<MaestroOutboundMotivo> MaestroOutboundMotivoes { get; set; } // MAESTRO_OUTBOUND_MOTIVO
        public System.Data.Entity.DbSet<MaestroOutboundRazon> MaestroOutboundRazons { get; set; } // MAESTRO_OUTBOUND_RAZON
        public System.Data.Entity.DbSet<MaestroOutboundTipoContacto> MaestroOutboundTipoContactoes { get; set; } // MAESTRO_OUTBOUND_TIPO_CONTACTO
        public System.Data.Entity.DbSet<MaestroOutboundTipoGestion> MaestroOutboundTipoGestions { get; set; } // MAESTRO_OUTBOUND_TIPO_GESTION


        static MaestrosContext()
        {
            System.Data.Entity.Database.SetInitializer<MaestrosContext>(null);
        }

        public MaestrosContext()
            : base("Name=MaestrosContext")
        {
           
        }

        public MaestrosContext(string connectionString)
            : base(connectionString)
        {
        }

        public MaestrosContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
        }

        public MaestrosContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public MaestrosContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
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


            modelBuilder.Configurations.Add(new MaestroOutboundCausaConfiguration());
            modelBuilder.Configurations.Add(new MaestroOutboundCierreConfiguration());
            modelBuilder.Configurations.Add(new MaestroOutboundMotivoConfiguration());
            modelBuilder.Configurations.Add(new MaestroOutboundRazonConfiguration());
            modelBuilder.Configurations.Add(new MaestroOutboundTipoContactoConfiguration());
            modelBuilder.Configurations.Add(new MaestroOutboundTipoGestionConfiguration());

        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {

            modelBuilder.Configurations.Add(new MaestroOutboundCausaConfiguration(schema));
            modelBuilder.Configurations.Add(new MaestroOutboundCierreConfiguration(schema));
            modelBuilder.Configurations.Add(new MaestroOutboundMotivoConfiguration(schema));
            modelBuilder.Configurations.Add(new MaestroOutboundRazonConfiguration(schema));
            modelBuilder.Configurations.Add(new MaestroOutboundTipoContactoConfiguration(schema));
            modelBuilder.Configurations.Add(new MaestroOutboundTipoGestionConfiguration(schema));
            return modelBuilder;
        }
        
        // Stored Procedures
        public int ReporteMRazonCe()
        {
            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[Reporte_M_Razon_CE] ", procResultParam);
 
            return (int) procResultParam.Value;
        }





     

    }
}
// </auto-generated>
