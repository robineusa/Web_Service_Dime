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

    // PROCESOS
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class ProcesoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Proceso>
    {
        public ProcesoConfiguration()
            : this("dbo")
        {
        }

        public ProcesoConfiguration(string schema)
        {
            ToTable("PROCESOS", schema);
            HasKey(x => new { x.IdProceso, x.Descripcion, x.IdMacroProceso });

            Property(x => x.IdProceso).HasColumnName(@"ID_PROCESO").IsRequired().HasColumnType("int");
            Property(x => x.Descripcion).HasColumnName(@"DESCRIPCION").IsRequired().IsFixedLength().HasColumnType("nchar").HasMaxLength(200);
            Property(x => x.IdMacroProceso).HasColumnName(@"ID_MACRO_PROCESO").IsRequired().HasColumnType("int");
        }
    }

}
// </auto-generated>