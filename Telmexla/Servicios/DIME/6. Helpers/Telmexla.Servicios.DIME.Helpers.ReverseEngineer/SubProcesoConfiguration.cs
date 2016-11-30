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

    // SUB_PROCESO
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class SubProcesoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<SubProceso>
    {
        public SubProcesoConfiguration()
            : this("dbo")
        {
        }

        public SubProcesoConfiguration(string schema)
        {
            ToTable("SUB_PROCESO", schema);
            HasKey(x => new { x.IdSubProceso, x.Descripcion });

            Property(x => x.IdSubProceso).HasColumnName(@"ID_SUB_PROCESO").IsRequired().HasColumnType("int");
            Property(x => x.IdProceso).HasColumnName(@"ID_PROCESO").IsOptional().HasColumnType("int");
            Property(x => x.Descripcion).HasColumnName(@"DESCRIPCION").IsRequired().IsFixedLength().HasColumnType("nchar").HasMaxLength(200);
        }
    }

}
// </auto-generated>
