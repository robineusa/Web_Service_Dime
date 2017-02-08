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

    // TBL_RAZON_INGRESO_SOPORTE
    public class RazonIngresoSoporteConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<RazonIngresoSoporte>
    {
        public RazonIngresoSoporteConfiguration()
            : this("dbo")
        {
        }

        public RazonIngresoSoporteConfiguration(string schema)
        {
            ToTable("TBL_RAZON_INGRESO_SOPORTE", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Nombre).HasColumnName(@"NOMBRE").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
        }
    }

}
// </auto-generated>
