using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class RecurrenciaCargueBaseConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<RecurrenciaCargaBase>
    {
        public RecurrenciaCargueBaseConfiguration()
            : this("dbo")
        {
        }

        public RecurrenciaCargueBaseConfiguration(string schema)
        {
            ToTable("TMP_RCB_RECURRENCIA", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Cuenta).HasColumnName(@"CUENTA").IsRequired().HasColumnType("numeric");
            Property(x => x.Marcaciones).HasColumnName(@"MARCACIONES").IsOptional().HasColumnType("numeric");
            Property(x => x.FechaUltimaMarcacion).HasColumnName(@"FECHA_ULTIMA_MARCACION").IsOptional().HasColumnType("date");
            Property(x => x.FechaUltimaGestion).HasColumnName(@"FECHA_ULTIMA_GESTION").IsOptional().HasColumnType("date");
            Property(x => x.IncluyeClaroVideo).HasColumnName(@"INCLUYE_CLARO_VIDEO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.UsoClaroVideo).HasColumnName(@"USO_CLARO_VIDEO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.ClienteNagra).HasColumnName(@"CLIENTE_NAGRA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.Ofrecimiento1).HasColumnName(@"OFRECIMIENTO_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.Ofrecimiento2).HasColumnName(@"OFRECIMIENTO_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.Ofrecimiento3).HasColumnName(@"OFRECIMIENTO_3").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.Diferenciador).HasColumnName(@"DIFERENCIADOR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.Prioridad).HasColumnName(@"PRIORIDAD").IsOptional().HasColumnType("numeric");
            Property(x => x.Veces_Gestionado).HasColumnName(@"VECES_GESTIONADO").IsOptional().HasColumnType("numeric");
            Property(x => x.Usuario_gestionando).HasColumnName(@"USUARIO_GESTIONANDO").IsOptional().HasColumnType("numeric");
            Property(x => x.FechaCargueBase).HasColumnName(@"FECHA_CARGUE_BASE").IsOptional().HasColumnType("date");

        }
    }
}
