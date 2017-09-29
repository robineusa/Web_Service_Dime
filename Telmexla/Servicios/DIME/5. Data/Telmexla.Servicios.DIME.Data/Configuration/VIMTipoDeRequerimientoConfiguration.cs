#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
   public class VIMTipoDeRequerimientoConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<VIMTipoDeRequerimiento>
    { 
        public VIMTipoDeRequerimientoConfiguration() : this("dbo") { }
        public VIMTipoDeRequerimientoConfiguration(string schema)
        {
            ToTable("TBL_VIM_TIPO_DE_REQUERIMIENTO", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.TipoDeRequerimiento).HasColumnName(@"TIPO_DE_REQUERIMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);

        }
    }
}
