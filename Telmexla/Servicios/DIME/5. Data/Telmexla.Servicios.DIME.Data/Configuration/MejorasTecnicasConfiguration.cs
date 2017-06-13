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
    public class MejorasTecnicasConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MejorasTecnicas>
    {
        public MejorasTecnicasConfiguration()
            : this("dbo")
        {
        }

        public MejorasTecnicasConfiguration(string schema)
        {
            ToTable("TBL_MEJORAS_TECNICAS", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaGestion).HasColumnName(@"FECHA_DE_GESTION").IsOptional().HasColumnType("date");
            Property(x => x.UsuarioGestion).HasColumnName(@"USUARIO_DE_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.NombreUsuarioGestion).HasColumnName(@"NOMBRE_USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.AliadoGestion).HasColumnName(@"ALIADO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsRequired().HasColumnType("numeric");
            Property(x => x.Accionable).HasColumnName(@"ACCIONABLE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(500);
            Property(x => x.AceptacionMejorasTecnicas).HasColumnName(@"ACEPTACION_MEJORAS_TECNICAS").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(2);
        }
    }
}
