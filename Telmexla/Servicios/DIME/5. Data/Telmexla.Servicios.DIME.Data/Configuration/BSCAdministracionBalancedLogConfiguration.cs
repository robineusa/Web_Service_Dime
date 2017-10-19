#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class BSCAdministracionBalancedLogConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<BSCAdministracionBalancedLog>
    {
        public BSCAdministracionBalancedLogConfiguration()
            : this("dbo")
        { }
        public BSCAdministracionBalancedLogConfiguration(string schema)
        {
            ToTable("TBL_BSC_ADMINISTRACION_UMBRALES_LOG", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Skill).HasColumnName(@"SKILL").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreSkill).HasColumnName(@"NOMBRE_SKILL").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Tmo).HasColumnName(@"TMO").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.LlamadasAtendidas).HasColumnName(@"LLAMADAS_ATENDIDAS").IsOptional().HasColumnType("numeric");
            Property(x => x.Marcaciones).HasColumnName(@"MARCACIONES").IsOptional().HasColumnType("numeric");
            Property(x => x.AjustesCorrectos).HasColumnName(@"AJUSTES_CORRECTOS").IsOptional().HasColumnType("numeric");
            Property(x => x.PqrEscalados).HasColumnName(@"PQR_ESCALADOS").IsOptional().HasColumnType("numeric");
            Property(x => x.VolumenDeVentas).HasColumnName(@"VOLUMEN_DE_VENTAS").IsOptional().HasColumnType("numeric");
            Property(x => x.Reincidencia).HasColumnName(@"REINCIDENCIA").IsOptional().HasColumnType("numeric");
            Property(x => x.Recomendacion).HasColumnName(@"RECOMENDACION").IsOptional().HasColumnType("numeric");
            Property(x => x.NotaCalidad).HasColumnName(@"NOTA_CALIDAD").IsOptional().HasColumnType("numeric");
            Property(x => x.NotaBuenServicio).HasColumnName(@"NOTA_BUEN_SERVICIO").IsOptional().HasColumnType("numeric");
            Property(x => x.ActivacionClaroVideo).HasColumnName(@"ACTIVACION_CLARO_VIDEO").IsOptional().HasColumnType("numeric");
            Property(x => x.ActivacionConvenioElectronico).HasColumnName(@"ACTIVACION_CONVENIO_ELECTRONICO").IsOptional().HasColumnType("numeric");
            Property(x => x.UsoCCAA).HasColumnName(@"USO_CCAA").IsOptional().HasColumnType("numeric");
            Property(x => x.TipoTransaccion).HasColumnName(@"TIPO_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaTransaccion).HasColumnName(@"FECHA_TRANSACCION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioTransaccion).HasColumnName(@"USUARIO_TRANSACCION").IsOptional().HasColumnType("numeric");
            Property(x => x.NombreUsuarioTransaccion).HasColumnName(@"NOMBRE_USUARIO_TRANSACCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
        }
    }
}
