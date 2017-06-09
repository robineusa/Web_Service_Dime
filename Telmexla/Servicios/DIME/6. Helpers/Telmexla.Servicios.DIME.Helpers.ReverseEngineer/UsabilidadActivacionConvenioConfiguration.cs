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

    // TBL_USABILIDAD_ACTIVACION_CONVENIO
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class UsabilidadActivacionConvenioConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UsabilidadActivacionConvenio>
    {
        public UsabilidadActivacionConvenioConfiguration()
            : this("dbo")
        {
        }

        public UsabilidadActivacionConvenioConfiguration(string schema)
        {
            ToTable("TBL_USABILIDAD_ACTIVACION_CONVENIO", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaRevision).HasColumnName(@"FECHA_REVISION").IsOptional().HasColumnType("datetime");
            Property(x => x.IdUsuarioRevision).HasColumnName(@"ID_USUARIO_REVISION").IsOptional().HasColumnType("int");
            Property(x => x.NombreUsarioRevison).HasColumnName(@"NOMBRE_USARIO_REVISON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.CuentaRevisoTabla).HasColumnName(@"CUENTA_REVISO_TABLA").IsOptional().HasColumnType("int");
        }
    }

}
// </auto-generated>
