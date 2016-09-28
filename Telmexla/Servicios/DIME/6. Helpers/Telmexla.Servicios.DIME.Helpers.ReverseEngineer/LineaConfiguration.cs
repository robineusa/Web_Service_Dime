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

    // TBL_LINEA
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class LineaConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Linea>
    {
        public LineaConfiguration()
            : this("dbo")
        {
        }

        public LineaConfiguration(string schema)
        {
            ToTable("TBL_LINEA", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Nombre).HasColumnName(@"NOMBRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(20);
            Property(x => x.IdModoLogin).HasColumnName(@"ID_MODO_LOGIN").IsOptional().HasColumnType("int");

            // Foreign keys
            HasOptional(a => a.ModosLogin).WithMany(b => b.Lineas).HasForeignKey(c => c.IdModoLogin).WillCascadeOnDelete(false); // FK__TBL_LINEA__ID_MO__2A164134
        }
    }

}
// </auto-generated>
