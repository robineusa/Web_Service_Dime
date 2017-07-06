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

    // TMP_GBC_FUERA_NIVELES
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class GbcFueraNiveleConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<GbcFueraNivele>
    {
        public GbcFueraNiveleConfiguration()
            : this("dbo")
        {
        }

        public GbcFueraNiveleConfiguration(string schema)
        {
            ToTable("TMP_GBC_FUERA_NIVELES", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.Cmts).HasColumnName(@"CMTS").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TipoModem).HasColumnName(@"TIPO_MODEM").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Prioridad).HasColumnName(@"PRIORIDAD").IsOptional().HasColumnType("int");
        }
    }

}
// </auto-generated>