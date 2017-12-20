using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class NotificacionSiganlRConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<NotificacionSignalR>
    {
        public NotificacionSiganlRConfiguration()
            : this("dbo")
        {
        }

        public NotificacionSiganlRConfiguration(string schema)
        {
            ToTable("TBL_NOTIFICACION_SIGNALR", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.TipoNotificacion).HasColumnName(@"TIPO_NOTIFICACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.ContenidoAlerta).HasColumnName(@"CONTENIDO_ALERTA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(null);
            Property(x => x.UsuarioNotifica).HasColumnName(@"USUARIO_NOTIFICA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.FechaEntrega).HasColumnName(@"FECHA_ENTREGA").IsOptional().HasColumnType("datetime");
            Property(x => x.NombreUsuarioNotifica).HasColumnName(@"NOMBRE_USUARIO_NOTIFICA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
