#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class BitacoraIncidentesLogConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BitacoraIncidentesLog>
    {
        public BitacoraIncidentesLogConfiguration()
            : this("dbo")
        { }
        public BitacoraIncidentesLogConfiguration(string schema)
        {
            ToTable("TBL_BITACORA_DE_INCIDENTES_LOG", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdRegistro).HasColumnName(@"ID_REGISTRO").IsOptional().HasColumnType("numeric");
            Property(x => x.UsuarioCreacion).HasColumnName(@"USUARIO_CREACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.NombreUsuarioCreacion).HasColumnName(@"NOMBRE_USUARIO_CREACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaDeRegistro).HasColumnName(@"FECHA_DE_REGISTRO").IsOptional().HasColumnType("datetime");
            Property(x => x.FechaUltimaActualizacion).HasColumnName(@"FECHA_ULTIMA_ACTUALIZACION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioUltimaActualizacion).HasColumnName(@"USUARIO_ULTIMA_ACTUALIZACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.NombreUsuarioUltimaActualizacion).HasColumnName(@"NOMBRE_USUARIO_ULTIMA_ACTUALIZACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CasoSD).HasColumnName(@"CASO_SD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.IM).HasColumnName(@"IM").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaDeCreacionTicket).HasColumnName(@"FECHA_DE_CREACION_TICKET").IsOptional().HasColumnType("datetime");
            Property(x => x.FechaDeCierreTicket).HasColumnName(@"FECHA_DE_CIERRE_TICKET").IsOptional().HasColumnType("datetime");
            Property(x => x.FechaDeCierreAfectacion).HasColumnName(@"FECHA_DE_CIERRE_AFECTACION").IsOptional().HasColumnType("datetime");
            Property(x => x.HorasDeAfectacion).HasColumnName(@"HORAS_DE_AFECTACION").IsOptional().HasColumnType("numeric");
            Property(x => x.DiasDeAfectacion).HasColumnName(@"DIAS_DE_AFECTACION").IsOptional().HasColumnType("numeric");
            Property(x => x.Herramienta).HasColumnName(@"HERRAMIENTA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TipoDeFalla).HasColumnName(@"TIPO_DE_FALLA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.ModuloAfectado).HasColumnName(@"MODULO_AFECTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.DescripcionAfectacion).HasColumnName(@"DESCRIPCION_AFECTACION").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.Prioridad).HasColumnName(@"PRIORIDAD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Gerencia).HasColumnName(@"GERENCIA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AliadoQueReporta).HasColumnName(@"ALIADO_QUE_REPORTA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.OperacionQueReporta).HasColumnName(@"OPERACION_QUE_REPORTA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.EscaladoA).HasColumnName(@"ESCALADO_A").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CantidadUsuariosAfectados).HasColumnName(@"CANTIDAD_DE_USUARIOS_AFECTADOS").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.ComentariosDeCierre).HasColumnName(@"COMENTARIO_DE_CIERRE").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.EstadoDelCaso).HasColumnName(@"ESTADO_DEL_CASO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
