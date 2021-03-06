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

    // MAESTRO_OUTBOUND_RAZON
    public class MaestroOutboundRazonConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MaestroOutboundRazon>
    {
        public MaestroOutboundRazonConfiguration()
            : this("dbo")
        {
        }

        public MaestroOutboundRazonConfiguration(string schema)
        {
            ToTable("MAESTRO_OUTBOUND_RAZON", schema);
            HasKey(x => x.IdRazon);

            Property(x => x.IdRazon).HasColumnName(@"ID_RAZON").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdCierre).HasColumnName(@"ID_CIERRE").IsRequired().HasColumnType("numeric");
            Property(x => x.Razon).HasColumnName(@"RAZON").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);

            // Foreign keys
            HasRequired(a => a.MaestroOutboundCierre).WithMany(b => b.MaestroOutboundRazons).HasForeignKey(c => c.IdCierre).WillCascadeOnDelete(false); // FK__MAESTRO_O__RAZON__40C49C62
        }
    }

}
