#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;


namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class BIMAliadosConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BIMAliados>
    {
        public BIMAliadosConfiguration()
            : this("dbo")
        { }
        public BIMAliadosConfiguration(string schema)
        {
            ToTable("TBL_BIM_ALIADOS", schema);
            HasKey(x => new { x.IdAliado });

            Property(x => x.IdAliado).HasColumnName(@"ID_ALIADO").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.NombreAliado).HasColumnName(@"NOMBRE_ALIADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            
        }
    }
}
