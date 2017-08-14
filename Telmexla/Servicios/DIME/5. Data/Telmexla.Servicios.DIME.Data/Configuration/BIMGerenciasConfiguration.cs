#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class BIMGerenciasConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BIMGerencias>
    {
        public BIMGerenciasConfiguration()
            : this("dbo")
        { }
        public BIMGerenciasConfiguration(string schema)
        {
            ToTable("TBL_BIM_GERENCIAS", schema);
            HasKey(x => new { x.IdGerencia });

            Property(x => x.IdGerencia).HasColumnName(@"ID_GERENCIA").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.NombreGerencia).HasColumnName(@"NOMBRE_GERENCIA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
