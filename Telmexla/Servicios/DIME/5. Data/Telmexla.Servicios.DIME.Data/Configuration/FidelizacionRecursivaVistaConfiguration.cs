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
    //TMP_FID_RECURSIVA
    public class FidelizacionRecursivaVistaConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<FidelizacionRecursivaVista>
    {
        public FidelizacionRecursivaVistaConfiguration()
            : this("dbo")
        {
        }

        public FidelizacionRecursivaVistaConfiguration(string schema)
        {
            ToTable("TMP_FID_RECURSIVA", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Nombre).HasColumnName(@"NOMBRE").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(250);
            Property(x => x.ParentId).HasColumnName(@"PARENT_ID").IsOptional().HasColumnType("numeric");
            Property(x => x.VerNivel).HasColumnName(@"VER_NIVEL").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.Nivel).HasColumnName(@"NIVEL").IsOptional().HasColumnType("numeric");
            Property(x => x.Label).HasColumnName(@"LABEL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.Ordr).HasColumnName(@"ORDR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);

        }
    }
}
