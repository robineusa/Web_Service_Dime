#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;


namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class BEMTipoDeEscalamientosConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BEMTipoDeEscalamientos>
    {
        public BEMTipoDeEscalamientosConfiguration()
            : this("dbo")
        { }
        public BEMTipoDeEscalamientosConfiguration(string schema)
        {
            ToTable("TBL_BEM_TIPO_DE_ESCALAMIENTOS", schema);
            HasKey(x => new { x.IdTipo });

            Property(x => x.IdTipo).HasColumnName(@"ID_TIPO").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.TipoEscalamiento).HasColumnName(@"TIPO_ESCALAMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
