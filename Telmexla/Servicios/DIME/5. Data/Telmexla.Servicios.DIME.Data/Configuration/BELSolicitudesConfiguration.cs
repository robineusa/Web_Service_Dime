#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class BELSolicitudesConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BELSolicitudes>
    {
        public BELSolicitudesConfiguration()
            : this("dbo")
        { }
        public BELSolicitudesConfiguration(string schema)
        {
            ToTable("TBL_BEL_SOLICITUDES", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdSolicitud).HasColumnName(@"ID_SOLICITUD").IsOptional().HasColumnType("numeric");
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.LlsOt).HasColumnName(@"LLSOT").IsOptional().HasColumnType("numeric");
            Property(x => x.TipoDeSolicitud).HasColumnName(@"TIPO_DE_SOLICITUD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.DetalleDeSolicitud).HasColumnName(@"DETALLE_DE_SOLICITUD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaDeSolicitud).HasColumnName(@"FECHA_DE_SOLICITUD").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioQueSolicita).HasColumnName(@"USUARIO_QUE_SOLICTA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.NombreUsuarioQueSolicita).HasColumnName(@"NOMBRE_USUARIO_QUE_SOLICTA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AliadoQueSolicita).HasColumnName(@"ALIADO_QUE_SOLICITA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.OperacionQueSolicita).HasColumnName(@"OPERACION_QUE_SOLICITA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaUltimaActualizacion).HasColumnName(@"FECHA_ULTIMA_ACTUALIZACION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioUltimaActualizacion).HasColumnName(@"USUARIO_ULTIMA_ACTUALIZACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.NombreUsuarioUltimaActualizacion).HasColumnName(@"NOMBRE_USUARIO_ULTIMA_ACTUALIZACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaDeFinalizacion).HasColumnName(@"FECHA_DE_FINALIZACION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioQueFinaliza).HasColumnName(@"USUARIO_QUE_FINALIZA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.NombreUsuarioQueFinaliza).HasColumnName(@"NOMBRE_USUARIO_QUE_FINALIZA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Nodo).HasColumnName(@"NODO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Malescalado).HasColumnName(@"MAL_ESCALADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.DetalleMalEscalado).HasColumnName(@"DETALLE_MAL_ESCALADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Gestion).HasColumnName(@"GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.EstadoEscalamiento).HasColumnName(@"ESTADO_ESCALAMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaDeAgenda).HasColumnName(@"FECHA_DE_AGENDA").IsOptional().HasColumnType("datetime");
            Property(x => x.Observaciones).HasColumnName(@"OBSERVACIONES").IsOptional().IsUnicode(false).HasColumnType("varchar");
            
        }
    }
}
