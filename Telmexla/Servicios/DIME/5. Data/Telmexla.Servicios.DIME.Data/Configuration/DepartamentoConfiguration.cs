#pragma warning disable 1591    

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    //TBL_DEPARTAMENTOS_CIUDADES
    public class DepartamentoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Departamento>
    {
        public DepartamentoConfiguration()
            : this("dbo")
        {
        }

        public DepartamentoConfiguration(string schema)
        {
            ToTable("TMP_DEPARTAMENTOS_CIUDADES", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.NombreDepartamento).HasColumnName(@"DEPARTAMENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.NombreComunidad).HasColumnName(@"NOMBRE_COMUNIDAD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Comunidad).HasColumnName(@"COMUNIDAD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(20);
            Property(x => x.Red).HasColumnName(@"RED").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
        }
    }
}
