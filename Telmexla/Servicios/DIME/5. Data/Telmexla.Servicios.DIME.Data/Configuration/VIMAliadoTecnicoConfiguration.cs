#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class VIMAliadoTecnicoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<VIMAliadoTecnico>
    {
        public VIMAliadoTecnicoConfiguration() : this("dbo") { }
        public VIMAliadoTecnicoConfiguration(string schema)
        {
            ToTable("TBL_VIM_ALIADO_TECNICO", schema);
            HasKey(x => new { x.IdAliado });

            Property(x => x.IdAliado).HasColumnName(@"ID_ALIADO").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.AliadoTecnico).HasColumnName(@"ALIADO_TECNICO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
