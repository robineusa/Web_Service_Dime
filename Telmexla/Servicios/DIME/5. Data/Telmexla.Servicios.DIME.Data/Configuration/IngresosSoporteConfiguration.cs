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

    // TBL_INGRESOS_SOPORTE
    public class IngresosSoporteConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<IngresosSoporte>
    {
        public IngresosSoporteConfiguration()
            : this("dbo")
        {
        }

        public IngresosSoporteConfiguration(string schema)
        {
            ToTable("TBL_INGRESOS_SOPORTE", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdIngreso).HasColumnName(@"ID_INGRESO").IsOptional().HasColumnType("numeric");
            Property(x => x.Cuenta).HasColumnName(@"CUENTA").IsRequired().HasColumnType("numeric");
            Property(x => x.Nombre).HasColumnName(@"NOMBRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.Apellido).HasColumnName(@"APELLIDO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.TipoSegumiento).HasColumnName(@"TIPO_SEGUMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.IncidenciaCcaa).HasColumnName(@"INCIDENCIA_CCAA").IsRequired().HasColumnType("numeric");
            Property(x => x.NombreAutoriza).HasColumnName(@"NOMBRE_AUTORIZA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);
            Property(x => x.CcaaIndicaVisitaTecnica).HasColumnName(@"CCAA_INDICA_VISITA_TECNICA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(2);
            Property(x => x.IdServicio).HasColumnName(@"ID_SERVICIO").IsOptional().HasColumnType("int");
            Property(x => x.Razon).HasColumnName(@"RAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Subrazon1).HasColumnName(@"SUBRAZON1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Subrazon2).HasColumnName(@"SUBRAZON2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
        }
    }

}
// </auto-generated>