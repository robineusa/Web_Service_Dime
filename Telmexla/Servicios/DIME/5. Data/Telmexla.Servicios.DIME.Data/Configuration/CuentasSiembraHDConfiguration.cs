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
    public class CuentasSiembraHDConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CuentasSiembraHD>
    {

        //TBL_CUENTAS_SIEMBRA_HD
        public CuentasSiembraHDConfiguration()
            : this("dbo")
        {
        }

        public CuentasSiembraHDConfiguration(string schema)
        {
            ToTable("TBL_CUENTAS_SIEMBRA_HD", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsRequired().HasColumnType("numeric");
            Property(x => x.Ofrecimiento).HasColumnName(@"OFRECIMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
        }
    }
}
