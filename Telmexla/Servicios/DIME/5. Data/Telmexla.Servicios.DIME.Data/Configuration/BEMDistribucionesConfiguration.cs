#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;


namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class BEMDistribucionesConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BEMDistribuciones>
    {
        public BEMDistribucionesConfiguration()
            : this("dbo")
        { }
        public BEMDistribucionesConfiguration(string schema)
        {
            ToTable("TBL_BEM_DISTRIBUCIONES", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CedulaUsuario).HasColumnName(@"CEDULA_USUARIO").IsOptional().HasColumnType("numeric");
            Property(x => x.TipoEscalamientoAsignado).HasColumnName(@"TIPO_DE_ESCALAMIENTO_ASIGNADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            
        }
    }
}
