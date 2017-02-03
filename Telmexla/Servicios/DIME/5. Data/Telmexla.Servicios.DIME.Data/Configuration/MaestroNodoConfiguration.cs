// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.51
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    //[TBL_INFORMACION_NODOS]
    public class MaestroNodoConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MaestroNodo>
    {
        public MaestroNodoConfiguration()
            : this("dbo")
        {
        }

        public MaestroNodoConfiguration(string schema)
        {
            ToTable("TBL_INFORMACION_NODOS", schema);
            HasKey(x => new { x.IdNodo });

            Property(x => x.IdNodo).HasColumnName(@"ID_NODO").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Nodo).HasColumnName(@"NODO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.NombreNodo).HasColumnName(@"NOMBRE_NODO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Div).HasColumnName(@"DIV").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Com).HasColumnName(@"COM").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Divisional).HasColumnName(@"DIVISIONAL").IsOptional().HasColumnType("numeric");
            Property(x => x.Area).HasColumnName(@"AREA").IsOptional().HasColumnType("numeric");
            Property(x => x.Distrito).HasColumnName(@"DISTRITO").IsOptional().HasColumnType("numeric");
            Property(x => x.Ugestion).HasColumnName(@"UGESTION").IsOptional().HasColumnType("numeric");
            Property(x => x.Usuario).HasColumnName(@"USUARIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaCreacion).HasColumnName(@"FECHA_CREACION").IsOptional().HasColumnType("date");
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Red).HasColumnName(@"RED").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Aliado).HasColumnName(@"ALIADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.NombreComunidad).HasColumnName(@"NOMBRE_COMUNIDAD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Departamento).HasColumnName(@"DEPARTAMENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
        }
    }
}
