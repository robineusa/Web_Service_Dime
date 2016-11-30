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

    // MACROPROCESO
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class MacroprocesoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Macroproceso>
    {
        public MacroprocesoConfiguration()
            : this("dbo")
        {
        }

        public MacroprocesoConfiguration(string schema)
        {
            ToTable("MACROPROCESO", schema);
            HasKey(x => new { x.IdMacroProceso, x.Descripcion });

            Property(x => x.IdMacroProceso).HasColumnName(@"ID_MACRO_PROCESO").IsRequired().HasColumnType("int");
            Property(x => x.Descripcion).HasColumnName(@"DESCRIPCION").IsRequired().IsFixedLength().HasColumnType("nchar").HasMaxLength(200);
        }
    }

}
// </auto-generated>
