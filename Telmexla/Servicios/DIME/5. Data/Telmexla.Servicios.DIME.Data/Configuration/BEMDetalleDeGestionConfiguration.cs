#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;


namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class BEMDetalleDeGestionConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BEMDetalleDeGestion>
    {
        public BEMDetalleDeGestionConfiguration()
            : this("dbo")
        { }
        public BEMDetalleDeGestionConfiguration(string schema)
        {
            ToTable("TBL_BEM_DETALLE_DE_GESTION", schema);
            HasKey(x => new { x.IdGestion });

            Property(x => x.IdGestion).HasColumnName(@"ID_GESTION").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdTipo).HasColumnName(@"ID_TIPO").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreGestion).HasColumnName(@"NOMBRE_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.EstadoGestion).HasColumnName(@"ESTADO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
