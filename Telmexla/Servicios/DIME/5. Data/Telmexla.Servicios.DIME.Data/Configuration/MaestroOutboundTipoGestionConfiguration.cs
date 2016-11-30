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

    // MAESTRO_OUTBOUND_TIPO_GESTION
    public class MaestroOutboundTipoGestionConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MaestroOutboundTipoGestion>
    {
        public MaestroOutboundTipoGestionConfiguration()
            : this("dbo")
        {
        }

        public MaestroOutboundTipoGestionConfiguration(string schema)
        {
            ToTable("MAESTRO_OUTBOUND_TIPO_GESTION", schema);
            HasKey(x => x.IdTipoGestion);

            Property(x => x.IdTipoGestion).HasColumnName(@"ID_TIPO_GESTION").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.TipoGestion).HasColumnName(@"TIPO_GESTION").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
        }
    }

}
