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

    // TBL_SUBRAZON2_INGRESO_SOPORTE
    public class Subrazon2IngresoSoporteConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Subrazon2IngresoSoporte>
    {
        public Subrazon2IngresoSoporteConfiguration()
            : this("dbo")
        {
        }

        public Subrazon2IngresoSoporteConfiguration(string schema)
        {
            ToTable("TBL_SUBRAZON2_INGRESO_SOPORTE", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Nombre).HasColumnName(@"NOMBRE").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.IdSubrazon1).HasColumnName(@"ID_SUBRAZON1").IsOptional().HasColumnType("int");

            // Foreign keys
            HasOptional(a => a.Subrazon1IngresoSoporte).WithMany(b => b.Subrazon2IngresoSoporte).HasForeignKey(c => c.IdSubrazon1).WillCascadeOnDelete(false); // FK__TBL_SUBRA__ID_SU__0A688BB1
        }
    }

}
// </auto-generated>
