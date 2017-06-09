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

    // TBL_SKILLS_USUARIOS_BLENDING
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class SkillsUsuariosBlendingConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<SkillsUsuariosBlending>
    {
        public SkillsUsuariosBlendingConfiguration()
            : this("dbo")
        {
        }

        public SkillsUsuariosBlendingConfiguration(string schema)
        {
            ToTable("TBL_SKILLS_USUARIOS_BLENDING", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Cedula).HasColumnName(@"CEDULA").IsOptional().HasColumnType("int");
            Property(x => x.Operacion).HasColumnName(@"OPERACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.Campaña).HasColumnName(@"CAMPAÑA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.FechaActualizacion).HasColumnName(@"FECHA_ACTUALIZACION").IsOptional().HasColumnType("datetime");
            Property(x => x.IdUsuarioActualizacion).HasColumnName(@"ID_USUARIO_ACTUALIZACION").IsOptional().HasColumnType("int");
        }
    }

}
// </auto-generated>
