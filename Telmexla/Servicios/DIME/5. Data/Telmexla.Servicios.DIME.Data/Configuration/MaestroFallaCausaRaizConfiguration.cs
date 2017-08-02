using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class MaestroFallaCausaRaizConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MaestroFallaCausaRaiz>
    {
        public MaestroFallaCausaRaizConfiguration()
            : this("dbo")
        {
        }

        public MaestroFallaCausaRaizConfiguration(string schema)
        {
            ToTable("MAESTRO_FALLA_CAUSA_RAIZ", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdFallaEspecifica).HasColumnName(@"ID_FALLA_ESPECIFICA").IsOptional().HasColumnType("int");
            Property(x => x.FallaCausaRaiz).HasColumnName(@"FALLA_CAUSA_RAIZ").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);

        }
    }
}
