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
    public class CambioEstratoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CambioEstrato>
    {

        public CambioEstratoConfiguration()
            : this("dbo")
        {
        }

        public CambioEstratoConfiguration(string schema)
        {
            ToTable("TBL_CAMBIO_DE_ESTRATO", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdTransaccion).HasColumnName(@"ID_TRANSACCION").IsOptional().HasColumnType("numeric");
            Property(x => x.UsuarioTransaccion).HasColumnName(@"USUARIO_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.CanalTransaccion).HasColumnName(@"CANAL_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.FechaTransaccion).HasColumnName(@"FECHA_TRANSACCION").IsOptional().HasColumnType("date");
            Property(x => x.NombreLineaTransaccion).HasColumnName(@"NOMBRE_LINEA_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsRequired().HasColumnType("numeric");
            Property(x => x.Direccion).HasColumnName(@"DIRECCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estrato).HasColumnName(@"ESTRATO").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Nodo).HasColumnName(@"NODO").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(15);
            Property(x => x.TelefonoCelular).HasColumnName(@"TELEFONO_CELULAR").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(20);
            Property(x => x.TelefonoFijo).HasColumnName(@"TELEFONO_FIJO").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(20);
            Property(x => x.Razon).HasColumnName(@"RAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Subrazon).HasColumnName(@"SUBRAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Observacion).HasColumnName(@"OBSERVACION").IsOptional().HasColumnType("ntext").IsMaxLength();
            Property(x => x.EstadoTransaccion).HasColumnName(@"ESTADO_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.UsuarioBackOffice).HasColumnName(@"USUARIO_BACKOFFICE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.CorreoElectronico).HasColumnName(@"CORREO_ELECTRONICO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(200);

        }
    }
}
