#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;


namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class VIMTipoDeEquiposConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<VIMTipoDeEquipos>
    {
        public VIMTipoDeEquiposConfiguration() : this("dbo") { }
        public VIMTipoDeEquiposConfiguration(string schema)
        {
            ToTable("TBL_VIM_TIPO_DE_EQUIPOS", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.TipoDeEquipo).HasColumnName(@"TIPO_DE_EQUIPO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
