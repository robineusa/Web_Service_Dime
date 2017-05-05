#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
   public class DistribucionBlendingConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<DistribucionBlending>
    {
        public DistribucionBlendingConfiguration()
        {

        }
        public DistribucionBlendingConfiguration(string schema)
        {
            ToTable("TBL_DISTRIBUCIONES_BLENDING", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.FormularioDestino).HasColumnName(@"FORMULARIO_DESTINO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AliadoDestino).HasColumnName(@"ALIADO_DESTINO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.OperacionDestino).HasColumnName(@"OPERACION_DESTINO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CampanaDestino).HasColumnName(@"CAMPANA_DESTINO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.UsuarioGestionando).HasColumnName(@"USUARIO_GESTIONANDO").IsOptional().HasColumnType("numeric");
            Property(x => x.FechaAsignacion).HasColumnName(@"FECHA_ASIGNACION").IsOptional().HasColumnType("date");
            Property(x => x.UsuarioAsignacion).HasColumnName(@"USUARIO_ASIGNACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            }
    }
}
