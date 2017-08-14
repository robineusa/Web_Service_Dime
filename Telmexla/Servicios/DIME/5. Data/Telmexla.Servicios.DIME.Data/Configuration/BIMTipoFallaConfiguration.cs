#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class BIMTipoFallaConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BIMTipoFalla>
    {
        public BIMTipoFallaConfiguration()
            : this("dbo")
        { }
        public BIMTipoFallaConfiguration(string schema)
        {
            ToTable("TBL_BIM_TIPO_FALLA", schema);
            HasKey(x => new { x.IdTipoFalla });

            Property(x => x.IdTipoFalla).HasColumnName(@"ID_TIPO_FALLA").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.TipoFalla).HasColumnName(@"TIPO_FALLA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
