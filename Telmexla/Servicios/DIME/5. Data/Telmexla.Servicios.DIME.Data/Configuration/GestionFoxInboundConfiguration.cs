using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class GestionFoxInboundConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<GestionFoxInbound>
    {
        public GestionFoxInboundConfiguration()
            : this("dbo")
        {
        }

        public GestionFoxInboundConfiguration(string schema)
        {
            ToTable("TBL_FGP_FOX_INBOUND", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaGestion).HasColumnName(@"FECHA_DE_GESTION").IsOptional().HasColumnType("date");
            Property(x => x.UsuarioGestion).HasColumnName(@"USUARIO_DE_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.NombreUsuarioGestion).HasColumnName(@"NOMBRE_USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.AliadoGestion).HasColumnName(@"ALIADO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsRequired().HasColumnType("numeric");
            Property(x => x.Ofrecimiento).HasColumnName(@"OFRECIMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.AceptacionFoxInbound).HasColumnName(@"ACEPTACION_FOX_INBOUND").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(2);
        }
    }
}
