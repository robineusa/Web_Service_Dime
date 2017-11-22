#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class RSPSeguimientosConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<RSPSeguimientos>
    {
        public RSPSeguimientosConfiguration()
            : this("dbo")
        { }
        public RSPSeguimientosConfiguration(string schema)
        {
            ToTable("TBL_RSP_SEGUIMIENTOS", schema);
            HasKey(x => new { x.IdSolicitud });

            Property(x => x.IdSolicitud).HasColumnName(@"ID_SOLICITUD").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaSolicitud).HasColumnName(@"FECHA_SOLICITUD").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioSolicitud).HasColumnName(@"USUARIO_SOLICITUD").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreUsuarioSolicitud).HasColumnName(@"NOMBRE_USUARIO_SOLICITUD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AliadoSolicitud).HasColumnName(@"ALIADO_SOLICITUD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.OperacionSolicitud).HasColumnName(@"OPERACION_SOLICITUD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LineaSolicitud).HasColumnName(@"LINEA_SOLICITUD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaActualizacion).HasColumnName(@"FECHA_ACTUALIZACION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioActualizacion).HasColumnName(@"USUARIO_ACTUALIZACION").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreUsuarioActualizacion).HasColumnName(@"NOMBRE_USUARIO_ACTUALIZACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.TipoEscalamiento).HasColumnName(@"TIPO_DE_ESCALAMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.DetalleEscalamiento).HasColumnName(@"DETALLE_ESCALAMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.MotivoEscalamiento).HasColumnName(@"MOTIVO_ESCALAMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.RazonEscalamiento).HasColumnName(@"RAZON_ESCALAMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SubRazonEscalamiento).HasColumnName(@"SUB_RAZON_ESCALAMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estrategia1).HasColumnName(@"ESTRATEGIA_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estrategia2).HasColumnName(@"ESTRATEGIA_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estrategia3).HasColumnName(@"ESTRATEGIA_3").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TicketRr).HasColumnName(@"TICKET_RR").IsOptional().HasColumnType("numeric");
            Property(x => x.EstadoSolicitud).HasColumnName(@"ESTADO_SOLICITUD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Observaciones).HasColumnName(@"OBSERVACIONES").IsOptional().IsUnicode(false).HasColumnType("varchar");
        }
    }
}
