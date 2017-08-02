using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class MaestroRecurrenciaConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MaestroRecurrencia>
    {
        public MaestroRecurrenciaConfiguration()
            : this("dbo")
        {
        }

        public MaestroRecurrenciaConfiguration(string schema)
        {
            ToTable("MAESTRO_RECURRENCIA", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Proceso).HasColumnName(@"PROCESO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
        }
    }
}
