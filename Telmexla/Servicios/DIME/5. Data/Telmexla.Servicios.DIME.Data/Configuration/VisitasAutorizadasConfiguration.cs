#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class VisitasAutorizadasConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<VisitasAutorizadas>
    {
        public VisitasAutorizadasConfiguration()
            : this("dbo") { }
        public VisitasAutorizadasConfiguration(string schema)
        {
            ToTable("TBL_VAP_VISITAS_AUTORIZADAS", schema);
            HasKey(x => new { x.IdVisita });

            Property(x => x.IdVisita).HasColumnName(@"ID_VISITA").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaRegistro).HasColumnName(@"FECHA_REGISTRO").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioRegistro).HasColumnName(@"USUARIO_REGISTRO").IsOptional().HasColumnType("numeric");
            Property(x => x.AliadoRegistro).HasColumnName(@"ALIADO_REGISTRO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.OperacionRegistro).HasColumnName(@"OPERACION_REGISTRO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.LlamadaServicio).HasColumnName(@"LLAMADA_SERVICIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Aviso).HasColumnName(@"AVISO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Motivo).HasColumnName(@"MOTIVO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CedulaUsuarioGestion).HasColumnName(@"CEDULA_USUARIO_GESTION").IsOptional().HasColumnType("numeric");
        }
    }
}
