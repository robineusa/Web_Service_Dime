using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class CargueBaseFoxInboundConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CargaBaseFoxInbound>
    {
        //TMP_FCB_FOX_INBOUND
        public CargueBaseFoxInboundConfiguration()
            : this("dbo")
        {
        }

        public CargueBaseFoxInboundConfiguration(string schema)
        {
            ToTable("TMP_FCB_FOX_INBOUND", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Cuenta).HasColumnName(@"CUENTA").IsRequired().HasColumnType("numeric");
            Property(x => x.FechaVencimiento).HasColumnName(@"FECHA_VENCIMIENTO").IsOptional().HasColumnType("date");
            Property(x => x.Ofrecimiento).HasColumnName(@"OFRECIMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);

        }
    }
}
