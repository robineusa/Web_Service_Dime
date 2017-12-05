#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;
namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class BACActualizarDatosConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BACActualizarDatos>
    {
        public BACActualizarDatosConfiguration()
            : this("dbo")
        {
        }

        public BACActualizarDatosConfiguration(string schema)
        {
            ToTable("TBL_BAC_ACTUALIZACION_DE_DATOS", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Telefono).HasColumnName(@"TELEFONO").IsOptional().HasColumnType("numeric");
            Property(x => x.CuentaAsociada).HasColumnName(@"CUENTA_ASOCIADA").IsOptional().HasColumnType("numeric");
            Property(x => x.Direccion).HasColumnName(@"DIRECCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Ciudad).HasColumnName(@"CIUDAD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
