
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class ArbolConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Arbol>
    {
        public ArbolConfiguration()
            : this("dbo")
        { }
        public ArbolConfiguration(string schema)
        {
            ToTable("TBL_ARBOL", schema);
            HasKey(x => new { x.Id });

            Property(x => x.NombreArbol).HasColumnName(@"TIPO_FALLA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

        }
    }
}

