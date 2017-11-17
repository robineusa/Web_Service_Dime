
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    class NodoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Nodo>
    {
        public NodoConfiguration()
            : this("dbo")
        { }
        public NodoConfiguration(string schema)
        {
            ToTable("TBL_NODOS", schema);
            HasKey(x => new { x.Id });

            Property(x => x.IdPadre).HasColumnName(@"ID_PADRE").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdArbol).HasColumnName(@"ID_ARBOL").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
        }
    }
}
