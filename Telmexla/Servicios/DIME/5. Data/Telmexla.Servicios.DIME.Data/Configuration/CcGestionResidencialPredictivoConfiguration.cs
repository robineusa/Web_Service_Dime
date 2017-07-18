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
    public class CcGestionResidencialPredictivoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CcGestionResidencialPredictivo>
    {
        public CcGestionResidencialPredictivoConfiguration()
            : this("dbo")
        {
        }

        public CcGestionResidencialPredictivoConfiguration(string schema)
        {
            ToTable("TBL_CC_GESTION_RESIDENCIAL_PREDICTIVO", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdResdPredInfo).HasColumnName(@"ID_RESD_PRED_INFO").IsOptional().HasColumnType("int");
            Property(x => x.IdBaseMejora).HasColumnName(@"ID_BASE_MEJORA").IsOptional().HasColumnType("int");
            Property(x => x.FechaGestion).HasColumnName(@"FECHA_GESTION").IsOptional().HasColumnType("datetime");
            Property(x => x.IdUsuarioGestion).HasColumnName(@"ID_USUARIO_GESTION").IsOptional().HasColumnType("int");
            Property(x => x.AliadoUsrGestion).HasColumnName(@"ALIADO_USR_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.LineaUsrGestion).HasColumnName(@"LINEA_USR_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.CedulaUsrGestion).HasColumnName(@"CEDULA_USR_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Cuenta).HasColumnName(@"CUENTA").IsOptional().HasColumnType("float");
            Property(x => x.Ciudad).HasColumnName(@"CIUDAD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Nombre).HasColumnName(@"NOMBRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Telefono1).HasColumnName(@"TELEFONO_1").IsOptional().HasColumnType("bigint");
            Property(x => x.Telefono2).HasColumnName(@"TELEFONO_2").IsOptional().HasColumnType("bigint");
            Property(x => x.TelfAdicional1).HasColumnName(@"TELF_ADICIONAL_1").IsOptional().HasColumnType("bigint");
            Property(x => x.TelfAdicional2).HasColumnName(@"TELF_ADICIONAL_2").IsOptional().HasColumnType("bigint");
            Property(x => x.NombreContacto).HasColumnName(@"NOMBRE_CONTACTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Servicio).HasColumnName(@"SERVICIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.TipoCliente).HasColumnName(@"TIPO_CLIENTE").IsOptional().HasColumnType("int");
            Property(x => x.Division).HasColumnName(@"DIVISION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(10);
            Property(x => x.Comunidad).HasColumnName(@"COMUNIDAD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Usuario).HasColumnName(@"USUARIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Nodo).HasColumnName(@"NODO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(10);
            Property(x => x.Aliado).HasColumnName(@"ALIADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Canal).HasColumnName(@"CANAL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Operacion).HasColumnName(@"OPERACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.DetalleInforme).HasColumnName(@"DETALLE_INFORME").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Base).HasColumnName(@"BASE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.DetalleMarcacion).HasColumnName(@"DETALLE_MARCACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.PersisteFalla).HasColumnName(@"PERSISTE_FALLA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(10);
            Property(x => x.ClasificacionPorServicio).HasColumnName(@"CLASIFICACION_POR_SERVICIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.ServicioAfectado).HasColumnName(@"SERVICIO_AFECTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.FallaDelCliente).HasColumnName(@"FALLA_DEL_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.SolucionFalla).HasColumnName(@"SOLUCION_FALLA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.MotivosNoSolucion).HasColumnName(@"MOTIVOS_NO_SOLUCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.ProblemaDelCliente).HasColumnName(@"PROBLEMA_DEL_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Atributo).HasColumnName(@"ATRIBUTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.FechaInstalacion).HasColumnName(@"FECHA_INSTALACION").IsOptional().HasColumnType("datetime");
            Property(x => x.ClaveWifi).HasColumnName(@"CLAVE_WIFI").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.EquiposInternet).HasColumnName(@"EQUIPOS_INTERNET").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.ReferenciaEquiInternet).HasColumnName(@"REFERENCIA_EQUI_INTERNET").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.EquiposTelevision).HasColumnName(@"EQUIPOS_TELEVISION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.ReferenciaEquiTelevision).HasColumnName(@"REFERENCIA_EQUI_TELEVISION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.SerialEquiFalla).HasColumnName(@"SERIAL_EQUI_FALLA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Observacion).HasColumnName(@"OBSERVACION").IsOptional().HasColumnType("ntext").IsMaxLength();
        }
    }

}
// </auto-generated>
