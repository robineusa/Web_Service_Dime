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
            ToTable("TBL_ENCUESTA_CAVS", schema);
            HasKey(x => new { x.IdTansaccion });

            Property(x => x.IdTansaccion).HasColumnName(@"ID_TRANSACCION").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaTransaccion).HasColumnName(@"FECHA_TRANSACCION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioTransaccion).HasColumnName(@"USUARIO_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CanalTransaccion).HasColumnName(@"CANAL_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ZonaTransaccion).HasColumnName(@"ZONA_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TelefonoCeluar).HasColumnName(@"TELEFONO_CELULAR").IsOptional().HasColumnType("numeric");
            Property(x => x.TelefonoDeContacto).HasColumnName(@"TELEFONO_CONTACTO").IsOptional().HasColumnType("numeric");
            Property(x => x.CorreoElectronico).HasColumnName(@"CORREO_ELECTRONICO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.Operacion).HasColumnName(@"OPERACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TokenId).HasColumnName(@"TOKEN_ID").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SubCanal).HasColumnName(@"SUB_CANAL_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaEnvioEncuesta).HasColumnName(@"FECHA_ENVIO_ENCUESTA").IsOptional().HasColumnType("datetime");
            Property(x => x.MinOrigen).HasColumnName(@"MIN_ORIGEN").IsOptional().HasColumnType("numeric");
            Property(x => x.EnviaReintento).HasColumnName(@"ENVIA_REINTENTO").IsOptional().HasColumnType("numeric");
            Property(x => x.EnviaSoloEmail).HasColumnName(@"ENVIA_SOLO_EMAIL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.IdEncuesta).HasColumnName(@"ID_ENCUESTA").IsOptional().HasColumnType("numeric");

        }
    }
}
