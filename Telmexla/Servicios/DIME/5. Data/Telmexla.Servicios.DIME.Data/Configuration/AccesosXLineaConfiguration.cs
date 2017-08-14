using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class AccesosXLineaConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<AccesosXLinea>
    {
        public AccesosXLineaConfiguration()
            : this("dbo")
        {
        }

        public AccesosXLineaConfiguration(string schema)
        {
            ToTable("TBL_ACCESOS_X_LINEA", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdAcceso).HasColumnName(@"ID_ACCESO").IsOptional().HasColumnType("int");
            Property(x => x.IdLinea).HasColumnName(@"ID_LINEA").IsOptional().HasColumnType("int");

            // Foreign keys
            HasOptional(a => a.Acceso).WithMany(b => b.AccesosXLineas).HasForeignKey(c => c.IdAcceso).WillCascadeOnDelete(false); // FK__TBL_ACCES__ID_AC__5BED93EA
            HasOptional(a => a.Linea).WithMany(b => b.AccesosXLineas).HasForeignKey(c => c.IdLinea).WillCascadeOnDelete(false); // FK__TBL_ACCES__ID_LI__5CE1B823
        }
    }

}
