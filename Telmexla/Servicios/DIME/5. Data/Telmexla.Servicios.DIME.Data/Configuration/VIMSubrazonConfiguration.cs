#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class VIMSubrazonConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<VIMSubrazon>
    {
        public VIMSubrazonConfiguration() : this("dbo") { }
        public VIMSubrazonConfiguration(string schema)
        {
            ToTable("TBL_VIM_SUBRAZON", schema);
            HasKey(x => new { x.IdSubrazon });

            Property(x => x.IdSubrazon).HasColumnName(@"ID_SUBRAZON").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdGestion).HasColumnName(@"ID_GESTION").IsOptional().HasColumnType("numeric");
            Property(x => x.Subrazon).HasColumnName(@"SUBRAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.EstadoFinal).HasColumnName(@"ESTADO_FINAL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
