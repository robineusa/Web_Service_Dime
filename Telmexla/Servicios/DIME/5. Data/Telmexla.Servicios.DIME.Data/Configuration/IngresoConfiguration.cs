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

    // TBL_INGRESOS
    public class IngresoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Ingreso>
    {
        public IngresoConfiguration()
            : this("dbo")
        {
        }

        public IngresoConfiguration(string schema)
        {
            ToTable("TBL_INGRESOS", schema);
            HasKey(x => x.IdIngreso);

            Property(x => x.IdIngreso).HasColumnName(@"ID_INGRESO").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Cuenta).HasColumnName(@"CUENTA").IsRequired().HasColumnType("numeric");
            Property(x => x.HomePass).HasColumnName(@"HOME_PASS").IsOptional().HasColumnType("float");
            Property(x => x.Nombre).HasColumnName(@"NOMBRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Apellido).HasColumnName(@"APELLIDO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Cedula).HasColumnName(@"CEDULA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Nodo).HasColumnName(@"NODO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Red).HasColumnName(@"RED").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Division).HasColumnName(@"DIVISION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Area).HasColumnName(@"AREA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Zona).HasColumnName(@"ZONA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Distrito).HasColumnName(@"DISTRITO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.NombreComunidad).HasColumnName(@"NOMBRE_COMUNIDAD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Departamento).HasColumnName(@"DEPARTAMENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Estrato).HasColumnName(@"ESTRATO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.TipoCliente).HasColumnName(@"TIPO_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Descripcion).HasColumnName(@"DESCRIPCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.GrupoSeg).HasColumnName(@"GRUPO_SEG").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Productos).HasColumnName(@"PRODUCTOS").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Ticket).HasColumnName(@"TICKET").IsRequired().HasColumnType("numeric");
            Property(x => x.FechaApertura).HasColumnName(@"FECHA_APERTURA").IsOptional().HasColumnType("date");
            Property(x => x.HoraApertura).HasColumnName(@"HORA_APERTURA").IsOptional().HasColumnType("datetime");
            Property(x => x.FechaCierre).HasColumnName(@"FECHA_CIERRE").IsOptional().HasColumnType("date");
            Property(x => x.HoraCierre).HasColumnName(@"HORA_CIERRE").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioApertura).HasColumnName(@"USUARIO_APERTURA").IsRequired().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.UsuarioCierre).HasColumnName(@"USUARIO_CIERRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.FechaUltimaActualizacion).HasColumnName(@"FECHA_ULTIMA_ACTUALIZACION").IsOptional().HasColumnType("date");
            Property(x => x.UsuarioUltimaActualizacion).HasColumnName(@"USUARIO_ULTIMA_ACTUALIZACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.HoraUltimaActualizacion).HasColumnName(@"HORA_ULTIMA_ACTUALIZACION").IsOptional().HasColumnType("datetime");
            Property(x => x.Macroproceso).HasColumnName(@"MACROPROCESO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Marcacion).HasColumnName(@"MARCACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.IdEstado).HasColumnName(@"ID_ESTADO").IsOptional().HasColumnType("int");
            Property(x => x.Semaforo).HasColumnName(@"SEMAFORO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.TiempoRespuesta).HasColumnName(@"TIEMPO_RESPUESTA").IsOptional().HasColumnType("numeric");
            Property(x => x.UsuarioBackoffice).HasColumnName(@"USUARIO_BACKOFFICE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.AliadoApertura).HasColumnName(@"ALIADO_APERTURA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.NombreLineaIngreso).HasColumnName(@"NOMBRE_LINEA_INGRESO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.NombreLineaEscalado).HasColumnName(@"NOMBRE_LINEA_ESCALADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.IdServicio).HasColumnName(@"ID_SERVICIO").IsOptional().HasColumnType("int");
            Property(x => x.IdIngresoSiriac).HasColumnName(@"ID_INGRESO_SIRIAC").IsOptional().HasColumnType("int");
        }
    }

}
// </auto-generated>
