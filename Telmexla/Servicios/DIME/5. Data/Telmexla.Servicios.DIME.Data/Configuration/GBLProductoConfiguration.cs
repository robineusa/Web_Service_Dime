#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class GBLProductoConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<GBLProducto>
    {
        public GBLProductoConfiguration()
            : this("dbo")
        { }
        public GBLProductoConfiguration(string schema)
        {
            ToTable("TBL_GBL_PRODUCTO", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaGestion).HasColumnName(@"FECHA_GESTION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioGestion).HasColumnName(@"USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.NombreUsuarioGestion).HasColumnName(@"NOMBRE_USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.AliadoGestion).HasColumnName(@"ALIADO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.OperacionGestion).HasColumnName(@"OPERACION_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CampanaGestion).HasColumnName(@"CAMPANA_DESTINO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.TipoContacto).HasColumnName(@"TIPO_DE_CONTACTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Gestion).HasColumnName(@"TIPO_DE_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Cierre).HasColumnName(@"CIERRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Causa).HasColumnName(@"RAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Observaciones).HasColumnName(@"OBSERVACIONES").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.FechaSeguimiento).HasColumnName(@"FECHA_SEGUIMIENTO").IsOptional().HasColumnType("datetime");
        }
    }
}
