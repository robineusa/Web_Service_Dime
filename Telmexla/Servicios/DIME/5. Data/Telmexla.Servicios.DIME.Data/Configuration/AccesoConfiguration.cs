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

    // TBL_ACCESOS
    public class AccesoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Acceso>
    {
        public AccesoConfiguration()
            : this("dbo")
        {
        }

        public AccesoConfiguration(string schema)
        {
            ToTable("TBL_ACCESOS", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Nombre).HasColumnName(@"NOMBRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.IdModoLogin).HasColumnName(@"ID_MODO_LOGIN").IsOptional().HasColumnType("int");

            // Foreign keys
            HasOptional(a => a.ModosLogin).WithMany(b => b.Accesoes).HasForeignKey(c => c.IdModoLogin).WillCascadeOnDelete(false); // FK__TBL_ACCES__ID_MO__7A3223E8
        }
    }

}
