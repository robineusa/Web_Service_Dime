
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

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.NombreArbol).HasColumnName(@"NOMBRE_ARBOL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(250);
            Property(x => x.NombreArbol).HasColumnName(@"CODIGO_HTML").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(null);
            Property(x => x.NombreArbol).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}

