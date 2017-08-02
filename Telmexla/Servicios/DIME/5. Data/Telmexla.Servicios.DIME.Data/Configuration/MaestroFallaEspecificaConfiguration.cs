using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration 
{
    public class MaestroFallaEspecificaConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MaestroFallaEspecifica>
    {
        public MaestroFallaEspecificaConfiguration()
            : this("dbo")
        {
        }

        public MaestroFallaEspecificaConfiguration(string schema)
        {
            ToTable("MAESTRO_FALLA_ESPECIFICA", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdOpcionesRecurrencia).HasColumnName(@"ID_OPCIONES_RECURRENCIA").IsOptional().HasColumnType("int");
            Property(x => x.FallaEspecificaCCAA).HasColumnName(@"FALLA_ESPECIFICA_CCAA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);

        }
    }
}
