using Telmexla.Servicios.DIME.Entity;


namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class NodoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Nodo>
    {
        public NodoConfiguration()
            : this("dbo")
        { }
        public NodoConfiguration(string schema)
        {
            ToTable("TBL_NODOS", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdArbol).HasColumnName(@"ID_ARBOL").IsRequired().HasColumnType("int");
            Property(x => x.IdPadre).HasColumnName(@"ID_PADRE").IsRequired().HasColumnType("int");
            Property(x => x.NombreNodo).HasColumnName(@"NOMBRE_NODO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CodigoHtml).HasColumnName(@"CODIGO_HTML").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(null);
            Property(x => x.FechaCreacion).HasColumnName(@"FECHA_CREACION").IsRequired().HasColumnType("datetime");
            Property(x => x.EsNodoFinal).HasColumnName(@"ES_NODO_FINAL").IsRequired().HasColumnType("bit");
        }
    }
}
   
