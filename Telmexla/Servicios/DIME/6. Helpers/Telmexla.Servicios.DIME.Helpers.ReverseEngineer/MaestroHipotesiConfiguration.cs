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

    // MAESTRO_HIPOTESIS
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class MaestroHipotesiConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MaestroHipotesi>
    {
        public MaestroHipotesiConfiguration()
            : this("dbo")
        {
        }

        public MaestroHipotesiConfiguration(string schema)
        {
            ToTable("MAESTRO_HIPOTESIS", schema);
            HasKey(x => new { x.IdHipotesis, x.Hipotesis });

            Property(x => x.IdHipotesis).HasColumnName(@"ID_HIPOTESIS").IsRequired().HasColumnType("numeric");
            Property(x => x.Hipotesis).HasColumnName(@"HIPOTESIS").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(20);
        }
    }

}
// </auto-generated>
