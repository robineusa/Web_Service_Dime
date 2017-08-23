#pragma warning disable 1591
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class POMSolicitudesConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<POMSolicitudes>
    {
        public POMSolicitudesConfiguration()
            : this("dbo")
        { }
        public POMSolicitudesConfiguration(string schema)
        {
            ToTable("TBL_POM_SOLICITUDES", schema);
            HasKey(x => new { x.IdRegistro });

            Property(x => x.IdRegistro).HasColumnName(@"ID_REGISTRO").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaSolicitud).HasColumnName(@"FECHA_SOLICITUD").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioSolicitud).HasColumnName(@"USUARIO_SOLICITUD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.TelefonoCeluar).HasColumnName(@"TELEFONO_CELULAR").IsOptional().HasColumnType("numeric");
            Property(x => x.CorreoElectronico).HasColumnName(@"CORREO_ELECTRONICO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.MovilClaro).HasColumnName(@"MOVIL_CLARO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

        }
    }
}
