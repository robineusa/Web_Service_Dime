using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class LineaConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Linea>
    {
        public LineaConfiguration()
            : this("dbo")
        {
        }

        public LineaConfiguration(string schema)
        {
            ToTable("TBL_LINEA", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Nombre).HasColumnName(@"NOMBRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.IdModoLogin).HasColumnName(@"ID_MODO_LOGIN").IsOptional().HasColumnType("int");

            // Foreign keys
            HasOptional(a => a.ModosLogin).WithMany(b => b.Lineas).HasForeignKey(c => c.IdModoLogin).WillCascadeOnDelete(false); // FK__TBL_LINEA__ID_MO__0F6D37F0
        }
    }

}
// </auto-generated>
