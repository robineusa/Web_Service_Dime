#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class BlendingFueraNivelConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BlendingFueraNivel>
    {
        public BlendingFueraNivelConfiguration()
            : this("dbo")
        {
        }

        public BlendingFueraNivelConfiguration(string schema)
        {
            ToTable("TMP_GBC_FUERA_NIVELES", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.Cmts).HasColumnName(@"CMTS").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TipoModem).HasColumnName(@"TIPO_MODEM").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Prioridad).HasColumnName(@"PRIORIDAD").IsOptional().HasColumnType("numeric");
        }
}
}
