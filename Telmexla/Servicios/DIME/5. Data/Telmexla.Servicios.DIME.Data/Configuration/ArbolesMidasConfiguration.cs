using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class ArbolesMidasConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ArbolesMidas>
    {
        public ArbolesMidasConfiguration()
            : this("dbo")
        { }
        public ArbolesMidasConfiguration(string schema)
        {
            ToTable("TBL_MM_ARBOLES", schema);
            HasKey(x => new { x.IdArbol });

            Property(x => x.IdArbol).HasColumnName(@"ID_ARBOL").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdPadre).HasColumnName(@"ID_PADRE").IsOptional().HasColumnType("numeric");
            Property(x => x.Descripcion).HasColumnName(@"DESCRIPCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.EstadoArbol).HasColumnName(@"ESTADO_ARBOL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
