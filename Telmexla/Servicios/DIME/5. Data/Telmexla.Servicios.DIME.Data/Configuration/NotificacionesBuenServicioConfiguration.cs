using Telmexla.Servicios.DIME.Entity;
namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class NotificacionesBuenServicioConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<NotificacionesBuenServicio>
    {

        public NotificacionesBuenServicioConfiguration()
            : this("dbo")
        {
        }
        public NotificacionesBuenServicioConfiguration(string schema)
        {
            ToTable("NOTIFICACIONES_BUEN_SERVICIO", schema);
            HasKey(x => x.Id);
            Property(x => x.Id).HasColumnName(@"ID_NOTIFICADO").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Fecha_Publicacion).HasColumnName(@"FECHA_PUBLICACION").IsOptional().HasColumnType("datetime");
            Property(x => x.Usuario_Publicacion).HasColumnName(@"USUARIO_PUBLICACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.Nombre_Imagen).HasColumnName(@"NOMBRE_IMAGEN").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Link_Direccionamiento).HasColumnName(@"LINK_DIRECCIONAMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.Descripcion).HasColumnName(@"DESCRIPCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.Aliado_Destino).HasColumnName(@"ALIADO_DESTINO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Perfil_Destino).HasColumnName(@"PERFIL_DESTINO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Nombre_Linea_Destino).HasColumnName(@"NOMBRE_LINEA_DESTINO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);

        }
    }
}
