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

    // MAESTRO_OUTBOUND_TIPO_CONTACTO
    public class MaestroOutboundTipoContactoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MaestroOutboundTipoContacto>
    {
        public MaestroOutboundTipoContactoConfiguration()
            : this("dbo")
        {
        }

        public MaestroOutboundTipoContactoConfiguration(string schema)
        {
            ToTable("MAESTRO_OUTBOUND_TIPO_CONTACTO", schema);
            HasKey(x => x.IdTipoContacto);

            Property(x => x.IdTipoContacto).HasColumnName(@"ID_TIPO_CONTACTO").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdTipoGestion).HasColumnName(@"ID_TIPO_GESTION").IsRequired().HasColumnType("numeric");
            Property(x => x.TipoContacto).HasColumnName(@"TIPO_CONTACTO").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);

            // Foreign keys
            HasRequired(a => a.MaestroOutboundTipoGestion).WithMany(b => b.MaestroOutboundTipoContactoes).HasForeignKey(c => c.IdTipoGestion).WillCascadeOnDelete(false); // FK__MAESTRO_O__TIPO___3B0BC30C
        }
    }

}
