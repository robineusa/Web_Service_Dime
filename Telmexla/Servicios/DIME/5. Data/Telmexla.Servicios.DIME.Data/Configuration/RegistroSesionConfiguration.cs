
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

    // TBL_REGISTRO_SESION
    public class RegistroSesionConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<RegistroSesion>
    {
        public RegistroSesionConfiguration()
            : this("dbo")
        {
        }

        public RegistroSesionConfiguration(string schema)
        {
            ToTable("TBL_REGISTRO_SESION", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.EsIngreso).HasColumnName(@"ES_INGRESO").IsOptional().HasColumnType("bit");
            Property(x => x.IdUsuario).HasColumnName(@"ID_USUARIO").IsOptional().HasColumnType("int");
            Property(x => x.IpCreacion).HasColumnName(@"IP_CREACION").IsOptional().HasColumnType("nvarchar").HasMaxLength(15);
            Property(x => x.FechaCreacion).HasColumnName(@"FECHA_CREACION").IsOptional().HasColumnType("date");
            Property(x => x.HoraCreacion).HasColumnName(@"HORA_CREACION").IsOptional().HasColumnType("time");

            // Foreign keys
            HasOptional(a => a.Usuario).WithMany(b => b.RegistroSesions).HasForeignKey(c => c.IdUsuario).WillCascadeOnDelete(false); // FK__TBL_REGIS__ID_US__123EB7A3
        }
    }

}
