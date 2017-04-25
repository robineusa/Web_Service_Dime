using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data
{
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
            Property(x => x.Cedula).HasColumnName(@"CEDULA").IsRequired().HasColumnType("int");
            Property(x => x.Operacion).HasColumnName(@"OPERACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.Campaña).HasColumnName(@"CAMPAÑA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.Fecha_Actualizacion).HasColumnName(@"FECHA_ACTUALIZACION").IsOptional().HasColumnType("datetime");
            Property(x => x.Id_Usuario_Actualizacion).HasColumnName(@"ID_USUARIO_ACTUALIZACION").IsOptional().HasColumnType("int");
            

        }
    }
}
