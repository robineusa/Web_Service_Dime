using Telmexla.Servicios.DIME.Entity;


namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class TrazabilidadArbolConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<TrazabilidadArbol>
    {
        public TrazabilidadArbolConfiguration()
            : this("dbo")
        { }

        public TrazabilidadArbolConfiguration(string schema)
        {
            HasKey(x => new { x.Id });
            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdUsuario).HasColumnName(@"ID_USUARIO").IsRequired().HasColumnType("int");
            Property(x => x.NombreUsuario).HasColumnName(@"NOMBRE_USUARIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.CuentaAsociada).HasColumnName(@"CUENTA_ASOCIADA").IsRequired().HasColumnType("int");
            Property(x => x.NodoActual).HasColumnName(@"NODO_ACTUAL").IsRequired().HasColumnType("int");
            Property(x => x.FinalizoProceso).HasColumnName(@"FINALIZO_PROCESO").IsRequired().HasColumnType("bit");

        }
    }
}
