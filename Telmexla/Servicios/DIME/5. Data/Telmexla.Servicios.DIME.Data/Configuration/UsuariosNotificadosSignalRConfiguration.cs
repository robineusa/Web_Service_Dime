using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class UsuariosNotificadosSignalRConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UsuariosNotificadosSignalR>
    {
        public UsuariosNotificadosSignalRConfiguration()
            : this("dbo")
        {
        }

        public UsuariosNotificadosSignalRConfiguration(string schema)
        {
            ToTable("TBL_USUARIOS_NOTIFICADOS_SIGNALR", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdNotificacion).HasColumnName(@"ID_NOTIFICACION").IsOptional().HasColumnType("numeric");
            Property(x => x.UsuarioNotificado).HasColumnName(@"USUARIO_NOTIFICADO").IsOptional().HasColumnType("numeric");

            // Foreign keys
            HasOptional(a => a.notificacionSignalR).WithMany(b => b.usersNoti).HasForeignKey(c => c.IdNotificacion).WillCascadeOnDelete(false);
            
        }
    }
}
