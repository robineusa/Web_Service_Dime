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

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    //TBL_FID_MAESTRO_SERVICIOS
    public class FidelizacionMaestroServiciosConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<FidelizacionMaestroServicios>
    {
        public FidelizacionMaestroServiciosConfiguration()
            : this("dbo")
        {
        }

        public FidelizacionMaestroServiciosConfiguration(string schema)
        {
            ToTable("TBL_FID_MAESTRO_SERVICIOS", schema);
            HasKey(x => new { x.IdServicio });

            Property(x => x.IdServicio).HasColumnName(@"ID_SERVICIO").IsRequired().HasColumnType("varchar").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdRetencion).HasColumnName(@"ID_RETENCION").IsOptional().HasColumnType("numeric");
            Property(x => x.Nombre).HasColumnName(@"NOMBRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
        }
    }
}
