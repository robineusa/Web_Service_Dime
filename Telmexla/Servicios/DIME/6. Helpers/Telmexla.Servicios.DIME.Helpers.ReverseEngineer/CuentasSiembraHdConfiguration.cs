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

namespace Telmexla.Servicios.DIME.Helpers.ReverseEngineer
{

    // TBL_CUENTAS_SIEMBRA_HD
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class CuentasSiembraHdConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CuentasSiembraHd>
    {
        public CuentasSiembraHdConfiguration()
            : this("dbo")
        {
        }

        public CuentasSiembraHdConfiguration(string schema)
        {
            ToTable("TBL_CUENTAS_SIEMBRA_HD", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.Ofrecimiento).HasColumnName(@"OFRECIMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
        }
    }

}
// </auto-generated>
