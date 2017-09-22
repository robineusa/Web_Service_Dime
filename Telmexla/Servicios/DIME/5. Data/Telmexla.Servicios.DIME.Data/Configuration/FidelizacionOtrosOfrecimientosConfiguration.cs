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
    //TBL_FID_OTROS_OFRECIMIENTOS
    public class FidelizacionOtrosOfrecimientosConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<FidelizacionOtrosOfrecimientos>
    {
        public FidelizacionOtrosOfrecimientosConfiguration()
            : this("dbo")
        {
        }

        public FidelizacionOtrosOfrecimientosConfiguration(string schema)
        {
            ToTable("TBL_FID_OTROS_OFRECIMIENTOS", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Nombre).HasColumnName(@"NOMBRE").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(250);
            Property(x => x.UsuarioId).HasColumnName(@"USUARIO_ID").IsRequired().HasColumnType("int");
            Property(x => x.Activo).HasColumnName(@"ACTIVO").IsRequired().HasColumnType("numeric");
            Property(x => x.Eliminado).HasColumnName(@"ELIMINADO").IsRequired().HasColumnType("numeric");
        }
    }
}
