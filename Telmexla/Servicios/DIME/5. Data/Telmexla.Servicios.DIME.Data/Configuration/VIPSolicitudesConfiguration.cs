#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;


namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class VIPSolicitudesConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<VIPSolicitudes>
    {
        public VIPSolicitudesConfiguration() :this("dbo"){}
        public VIPSolicitudesConfiguration(string schema)
        {
            ToTable("TBL_VIP_SOLICITUDES", schema);
            HasKey(x => new { x.IdSolicitud });

            Property(x => x.IdSolicitud).HasColumnName(@"ID_SOLICITUD").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaSolicitud).HasColumnName(@"FECHA_DE_SOLICITUD").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioSolicitud).HasColumnName(@"USUARIO_SOLICITUD").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreUsuarioSolicitud).HasColumnName(@"NOMBRE_USUARIO_SOLICITUD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AliadoSolicitud).HasColumnName(@"ALIADO_SOLICITUD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.OperacionSolicitud).HasColumnName(@"OPERACION_SOLICITUD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaUltimaActualizacion).HasColumnName(@"FECHA_ULTIMA_ACTUALIZACION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioUltimaActualizacion).HasColumnName(@"USUARIO_ULTIMA_ACTUALIZACION").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreUsuarioUltimaActualizacion).HasColumnName(@"NOMBRE_USUARIO_ULTIMA_ACTUALIZACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.TipoDeRequerimiento).HasColumnName(@"TIPO_DE_REQUERIMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.RequiereAjuste).HasColumnName(@"REQUIERE_AJUSTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(10);
            Property(x => x.Nodo).HasColumnName(@"NODO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Gestion).HasColumnName(@"GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Subrazon).HasColumnName(@"SUBRAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.EstadoSolicitud).HasColumnName(@"ESTADO_SOLICITUD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AliadoTecnico).HasColumnName(@"ALIADO_TECNICO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Observaciones).HasColumnName(@"OBSERVACIONES").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.UsuarioGestionando).HasColumnName(@"USUARIO_GESTIONANDO").IsOptional().HasColumnType("numeric");
        }
    }
}
