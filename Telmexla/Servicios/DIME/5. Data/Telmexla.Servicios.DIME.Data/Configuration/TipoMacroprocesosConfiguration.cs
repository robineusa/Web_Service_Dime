using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class  TipoMacroprocesosConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<TiposMacroprocesos>
    {
        public TipoMacroprocesosConfiguration()
        : this("dbo")
    { }
        public TipoMacroprocesosConfiguration(string schema)
        {
            ToTable("TBL_TIPO_MACROPROCESOS", schema);
            HasKey(x => new { x.IdTipo });

            Property(x => x.IdTipo).HasColumnName(@"ID_TIPO_CATEGORIA").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Descripcion).HasColumnName(@"DESCRIPCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        
        }


    }
}
