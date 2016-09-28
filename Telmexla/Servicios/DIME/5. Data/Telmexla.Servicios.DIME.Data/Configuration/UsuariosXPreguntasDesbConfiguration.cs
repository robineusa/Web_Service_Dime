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

    // TBL_USUARIOS_X_PREGUNTAS_DESB

    public class UsuariosXPreguntasDesbConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UsuariosXPreguntasDesb>
    {
        public UsuariosXPreguntasDesbConfiguration()
            : this("dbo")
        {
        }

        public UsuariosXPreguntasDesbConfiguration(string schema)
        {
            ToTable("TBL_USUARIOS_X_PREGUNTAS_DESB", schema);
            HasKey(x => new { x.Id, x.IdPregunta, x.IdUsuario });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdPregunta).HasColumnName(@"ID_PREGUNTA").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.IdUsuario).HasColumnName(@"ID_USUARIO").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Respuesta).HasColumnName(@"RESPUESTA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);

            // Foreign keys
            HasRequired(a => a.PreguntasDesbloqueo).WithMany(b => b.UsuariosXPreguntasDesbs).HasForeignKey(c => c.IdPregunta).WillCascadeOnDelete(false); // FK__TBL_USUAR__ID_PR__3A4CA8FD
            HasRequired(a => a.Usuario).WithMany(b => b.UsuariosXPreguntasDesbs).HasForeignKey(c => c.IdUsuario).WillCascadeOnDelete(false); // FK__TBL_USUAR__ID_US__3B40CD36
        }
    }

}

