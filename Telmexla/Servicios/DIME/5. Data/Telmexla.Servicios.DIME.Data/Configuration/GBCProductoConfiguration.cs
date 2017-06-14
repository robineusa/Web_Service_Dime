#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class GBCProductoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<GBCProducto>
    {
        public GBCProductoConfiguration()
            : this("dbo")
        { }
        public GBCProductoConfiguration(string schema)
        {
            ToTable("TMP_GBC_PRODUCTO", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
       }
    }
}
