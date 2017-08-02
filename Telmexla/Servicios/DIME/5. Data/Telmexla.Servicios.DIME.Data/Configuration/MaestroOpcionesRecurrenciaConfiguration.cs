using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class MaestroOpcionesRecurrenciaConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MaestroOpcionesRecurrencia>
    {
        public MaestroOpcionesRecurrenciaConfiguration()
            : this("dbo")
        {
        }

        public MaestroOpcionesRecurrenciaConfiguration(string schema)
        {
            ToTable("MAESTRO_OPCIONES_RECURRENCIA", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdProceso).HasColumnName(@"ID_PROCESO").IsOptional().HasColumnType("int");
            Property(x => x.OpcionesRecurrencia).HasColumnName(@"OPCIONES_RECURRENCIA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);

        }
    }
}
