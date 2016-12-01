
using Telmexla.Servicios.DIME.Entity;


namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class MaestroMarcacionesConfiguration :  System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MaestroMarcacione>
    {

        public MaestroMarcacionesConfiguration()
            : this("dbo")
        {
        }

        public MaestroMarcacionesConfiguration(string schema)
        {
            ToTable("TMP_MAESTRO_MARCACIONES", schema);
            HasKey(x => x.Id);
            Property(x => x.Razon).HasColumnName(@"RAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Subrazon).HasColumnName(@"SUBRAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Submarcacion).HasColumnName(@"SUBMARCACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.EstadoMarcacion).HasColumnName(@"ESTADO_MARCACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Descripcion).HasColumnName(@"DESCRIPCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.Spc).HasColumnName(@"SPC").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Qmf).HasColumnName(@"QMF").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.Responsable).HasColumnName(@"RESPONSABLE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.AreaResponsable).HasColumnName(@"AREA_RESPONSABLE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Macroproceso).HasColumnName(@"MACROPROCESO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Clase).HasColumnName(@"CLASE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.ReporteTrimestral).HasColumnName(@"REPORTE_TRIMESTRAL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Servicios).HasColumnName(@"SERVICIOS").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.CanalHabilitadp).HasColumnName(@"CANAL_HABILITADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.QueHacer).HasColumnName(@"QUE_HACER").IsOptional().IsUnicode(false).HasColumnType("ntext").IsMaxLength();
            Property(x => x.QueHacerHtml).HasColumnName(@"QUE_HACER_HTML").IsOptional().IsUnicode(false).HasColumnType("ntext").IsMaxLength();
            Property(x => x.AreayUsuarioEscala).HasColumnName(@"AREA_Y_USUARIO_ESCALA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.QuienFinaliza).HasColumnName(@"QUIEN_FINALIZA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.TipologiasCun).HasColumnName(@"TIPOLOGIAS_CUN").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.CantidadDias).HasColumnName(@"CANTIDAD_DIAS").IsOptional().HasColumnType("int");
            Property(x => x.Canal).HasColumnName(@"CANAL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.TipoMarcacion).HasColumnName(@"TIPO_MARCACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.FechaCreacion).HasColumnName(@"FEHCA_CREACION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioCreacion).HasColumnName(@"USUARIO_CREACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.FechaActualizacion).HasColumnName(@"FEHCA_ACTUALIZACION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioActualizacion).HasColumnName(@"USUARIO_ACTUALIZACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            
            
        }


    }
}
