#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class CEPSuspensionesConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CEPSuspensiones>
    {
        public CEPSuspensionesConfiguration()
            : this("dbo")
        {
        }

        public CEPSuspensionesConfiguration(string schema)
        {
            ToTable("TBL_CEP_SUSPENSIONES", schema);
            HasKey(x => x.IdGestion);

            Property(x => x.IdGestion).HasColumnName(@"ID_GESTION").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaGestion).HasColumnName(@"FECHA_DE_GESTION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioDeGestion).HasColumnName(@"USUARIO_GESTION").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreUsuarioGestion).HasColumnName(@"NOMBRE_USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.CanalDeIngreso).HasColumnName(@"CANAL_DE_INGRESO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaCreacion).HasColumnName(@"FECHA_CREACION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioCreacion).HasColumnName(@"USUARIO_CREACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.ServiciosSuspender).HasColumnName(@"SERVICIOS_SUSPENDER").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.MotivosSuspension).HasColumnName(@"MOTIVOS_SUSPENSION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.MesesSuspender).HasColumnName(@"MESES_SUSPENDER").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Gestion).HasColumnName(@"GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Subrazon).HasColumnName(@"SUBRAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaSeguimiento).HasColumnName(@"FECHA_SEGUIMIENTO").IsOptional().HasColumnType("datetime");
            Property(x => x.Observaciones).HasColumnName(@"OBSERVACIONES").IsOptional().HasColumnType("varchar");
            
        }
    }
}
