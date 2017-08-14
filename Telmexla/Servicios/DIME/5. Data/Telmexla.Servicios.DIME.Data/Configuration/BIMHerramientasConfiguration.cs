#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
   public class BIMHerramientasConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BIMHerramientas>
    {
        public BIMHerramientasConfiguration()
            : this("dbo")
        { }
        public BIMHerramientasConfiguration(string schema)
        {
            ToTable("TBL_BIM_HERRAMIENTAS", schema);
            HasKey(x => new { x.IdHerramienta });

            Property(x => x.IdHerramienta).HasColumnName(@"ID_HERRAMIENTA").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.NombreHerramienta).HasColumnName(@"NOMBRE_HERRAMIENTA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
