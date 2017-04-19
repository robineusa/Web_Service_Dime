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
    public class GestionMatrizConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<GestionMatriz>
    {
        public GestionMatrizConfiguration()
            : this("dbo")
        {
        }

        public GestionMatrizConfiguration(string schema)
        {
            ToTable("TBL_GESTION_MATRICES", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdTransaccion).HasColumnName(@"ID_TRANSACCION").IsRequired().HasColumnType("numeric");
            Property(x => x.UsuarioTransaccion).HasColumnName(@"USUARIO_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.CanalTransaccion).HasColumnName(@"CANAL_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.FechaTransaccion).HasColumnName(@"FECHA_TRANSACCION").IsOptional().HasColumnType("date");
            Property(x => x.NombreLineaTransaccion).HasColumnName(@"NOMBRE_LINEA_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.TipoGestionMatriz).HasColumnName(@"TIPO_GESTION_MATRIZ").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.TipoCliente).HasColumnName(@"TIPO_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(5);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.CuentaMatriz).HasColumnName(@"CUENTA_MATRIZ").IsOptional().HasColumnType("numeric");
            Property(x => x.OrdenTrabajo).HasColumnName(@"ORDEN_DE_TRABAJO").IsOptional().HasColumnType("numeric");
            Property(x => x.Direccion).HasColumnName(@"DIRECCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Nodo).HasColumnName(@"NODO").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(15);
            Property(x => x.NombreConjuntoEdificio).HasColumnName(@"NOMBRE_CONJUNTO_EDIFICIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.TelefonoCLiente).HasColumnName(@"TELEFONO_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(20);
            Property(x => x.TelefonoAdministrador).HasColumnName(@"TELEFONO_ADMINISTRADOR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(20);
            Property(x => x.NombreAdministrador).HasColumnName(@"NOMBRE_ADMINISTRADOR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Razon).HasColumnName(@"RAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Subrazon).HasColumnName(@"SUBRAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Observacion).HasColumnName(@"OBSERVACION").IsOptional().HasColumnType("ntext").IsMaxLength();
            Property(x => x.EstadoTransaccion).HasColumnName(@"ESTADO_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.UsuarioBackOfficeCreacion).HasColumnName(@"USUARIO_BACKOFFICE_CREACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
            Property(x => x.UsuarioBackOfficeGestion).HasColumnName(@"USUARIO_BACKOFFICE_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(30);
        }
    }
}
