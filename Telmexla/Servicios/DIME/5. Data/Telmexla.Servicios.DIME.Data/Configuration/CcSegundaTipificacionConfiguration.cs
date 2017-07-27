using Telmexla.Servicios.DIME.Entity;


namespace Telmexla.Servicios.DIME.Data.Configuration
{


    public class CcSegundaTipificacionConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CcSegundaTipificacion>
    {
        public CcSegundaTipificacionConfiguration()
            : this("dbo")
        {
        }

        public CcSegundaTipificacionConfiguration(string schema)
        {
            ToTable("TBL_CC_SEGUNDA_TIPIFICACION", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("bigint").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.IdGestionado).HasColumnName(@"ID_GESTIONADO").IsOptional().HasColumnType("int");
            Property(x => x.TipoCierre).HasColumnName(@"TIPO_CIERRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
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
            Property(x => x.Macroproceso).HasColumnName(@"MACROPROCESO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Clasificacion).HasColumnName(@"CLASIFICACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.ProblemaDelCliente).HasColumnName(@"PROBLEMA_DEL_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.SoporteDado).HasColumnName(@"SOPORTE_DADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.EstadoCliente).HasColumnName(@"ESTADO_CLIENTE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Seguimiento).HasColumnName(@"SEGUIMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Observacion).HasColumnName(@"OBSERVACION").IsOptional().HasColumnType("ntext").IsMaxLength();
        }
    }

}
// </auto-generated>
