#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class VIMGestionConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<VIMGestion>
    {
        public VIMGestionConfiguration() : this("dbo") { }
        public VIMGestionConfiguration(string schema)
        {
            ToTable("TBL_VIM_GESTION", schema);
            HasKey(x => new { x.IdGestion });

            Property(x => x.IdGestion).HasColumnName(@"ID_GESTION").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Gestion).HasColumnName(@"GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
