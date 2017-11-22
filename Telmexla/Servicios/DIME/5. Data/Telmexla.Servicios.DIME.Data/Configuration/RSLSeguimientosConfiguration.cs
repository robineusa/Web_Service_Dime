#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class RSLSeguimientosConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<RSLSeguimientos>
    {
        public RSLSeguimientosConfiguration()
            : this("dbo")
        { }
        public RSLSeguimientosConfiguration(string schema)
        {
            ToTable("TBL_RSL_SEGUIMIENTOS", schema);
            HasKey(x => new { x.IdTransaccion });

            Property(x => x.IdTransaccion).HasColumnName(@"ID_TRANSACCION").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdSolicitud).HasColumnName(@"ID_SOLICITUD").IsOptional().HasColumnType("numeric");
            Property(x => x.FechaTransaccion).HasColumnName(@"FECHA_TRANSACCION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioTransaccion).HasColumnName(@"USUARIO_TRANSACCION").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreUsuarioTransaccion).HasColumnName(@"NOMBRE_USUARIO_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AliadoTransaccion).HasColumnName(@"ALIADO_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.OperacionTransaccion).HasColumnName(@"OPERACION_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.LineaTransaccion).HasColumnName(@"LINEA_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
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
