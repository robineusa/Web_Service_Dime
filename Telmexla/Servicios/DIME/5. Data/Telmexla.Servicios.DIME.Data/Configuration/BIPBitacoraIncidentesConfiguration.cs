#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class BIPBitacoraIncidentesConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BIPBitacoraIncidentes>
    {
        public BIPBitacoraIncidentesConfiguration()
            : this("dbo")
        { }
        public BIPBitacoraIncidentesConfiguration(string schema)
        {
            ToTable("TBL_BIP_BITACORA_DE_INCIDENTES", schema);
            HasKey(x => new { x.IdRegistro });

            Property(x => x.IdRegistro).HasColumnName(@"ID_REGISTRO").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
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
            Property(x => x.Herramienta).HasColumnName(@"HERRAMIENTA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TipoDeFalla).HasColumnName(@"TIPO_DE_FALLA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.ModuloAfectado).HasColumnName(@"MODULO_AFECTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.DescripcionAfectacion).HasColumnName(@"DESCRIPCION_AFECTACION").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.Prioridad).HasColumnName(@"PRIORIDAD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.EscaladoA).HasColumnName(@"ESCALADO_A").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CantidadUsuariosAfectados).HasColumnName(@"CANTIDAD_DE_USUARIOS_AFECTADOS").IsOptional().HasColumnType("numeric");
            Property(x => x.ComentariosDeCierre).HasColumnName(@"COMENTARIO_DE_CIERRE").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.EstadoDelCaso).HasColumnName(@"ESTADO_DEL_CASO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
