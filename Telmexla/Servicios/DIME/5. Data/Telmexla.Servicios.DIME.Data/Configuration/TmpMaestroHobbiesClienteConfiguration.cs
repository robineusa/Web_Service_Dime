// <auto-generated>
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

    // TMP_MAESTRO_HOBBIES_CLIENTE
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class TmpMaestroHobbiesClienteConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<TmpMaestroHobbiesCliente>
    {
        public TmpMaestroHobbiesClienteConfiguration()
            : this("dbo")
        {
        }

        public TmpMaestroHobbiesClienteConfiguration(string schema)
        {
            ToTable("TMP_MAESTRO_HOBBIES_CLIENTE", schema);
            HasKey(x => x.IdHobby);

            Property(x => x.IdHobby).HasColumnName(@"ID_HOBBY").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Hobby).HasColumnName(@"HOBBY").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
        }
    }

}
// </auto-generated>
