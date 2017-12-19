
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
   public class MacroprocesosConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Macroprocesos>
    {
        public MacroprocesosConfiguration()
            : this("dbo")
        { }

        public MacroprocesosConfiguration(string schema)
        {
            ToTable("TBL_MACROPROCESOS", schema);
            HasKey(x => new { x.IdCategoria });

            Property(x => x.IdCategoria).HasColumnName(@"ID_CATEGORIA").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdCategoriaPadre).HasColumnName(@"ID_CATEGORIA_PADRE").IsRequired().HasColumnType("int");
            Property(x => x.Descripcion).HasColumnName(@"DESCRIPCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.DescripcionPadre).HasColumnName(@"DESCRIPCION_PADRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

        }

    }
}
