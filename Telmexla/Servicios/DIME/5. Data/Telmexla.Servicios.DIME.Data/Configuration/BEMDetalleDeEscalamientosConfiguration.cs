#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;


namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class BEMDetalleDeEscalamientosConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BEMDetalleEscalamientos>
    {
        public BEMDetalleDeEscalamientosConfiguration()
            : this("dbo")
        { }
        public BEMDetalleDeEscalamientosConfiguration(string schema)
        {
            ToTable("TBL_BEM_DETALLE_ESCALAMIENTO", schema);
            HasKey(x => new { x.IdDetalle });

            Property(x => x.IdDetalle).HasColumnName(@"ID_DETALLE").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdTipo).HasColumnName(@"ID_TIPO").IsOptional().HasColumnType("numeric");
            Property(x => x.DetalleEscalamiento).HasColumnName(@"DETALLE_ESCALAMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
