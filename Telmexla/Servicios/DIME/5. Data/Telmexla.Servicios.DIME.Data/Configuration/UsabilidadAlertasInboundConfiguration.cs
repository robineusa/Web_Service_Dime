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
    public class UsabilidadAlertasInboundConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UsabilidadAlertasInbound>
    {
        public UsabilidadAlertasInboundConfiguration()
            : this("dbo")
        {
        }

        public UsabilidadAlertasInboundConfiguration(string schema)
        {
            ToTable("TBL_USABILIDAD_ALERTAS", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaRevision).HasColumnName(@"FECHA_REVISION").IsOptional().HasColumnType("datetime"); ;
            Property(x => x.IdUsuarioRevision).HasColumnName(@"ID_USUARIO_REVISION").IsOptional().HasColumnType("int");
            Property(x => x.NombreUsuarioRevision).HasColumnName(@"NOMBRE_USARIO_REVISON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Aliado).HasColumnName(@"ALIADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.CuentaRevisoTabla).HasColumnName(@"CUENTA_REVISO_TABLA").IsOptional().HasColumnType("int");
            Property(x => x.Alerta).HasColumnName(@"ALERTA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
        }
    }
}
