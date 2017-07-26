#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class BEMRazonMalEscalamientoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BEMRazonMalEscalamiento>
    {
        public BEMRazonMalEscalamientoConfiguration()
            : this("dbo")
        { }
        public BEMRazonMalEscalamientoConfiguration(string schema)
        {
            ToTable("TBL_BEM_RAZON_MAL_ESCALAMIENTO", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdTipo).HasColumnName(@"ID_TIPO").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreRazonEscalamiento).HasColumnName(@"NOMBRE_RAZON_ESCALAMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
