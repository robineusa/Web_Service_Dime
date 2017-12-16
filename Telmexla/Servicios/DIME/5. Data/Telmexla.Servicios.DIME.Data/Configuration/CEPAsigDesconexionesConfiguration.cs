#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;
namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class CEPAsigDesconexionesConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CEPAsigDesconexiones>
    {
        public CEPAsigDesconexionesConfiguration()
            : this("dbo")
        {
        }

        public CEPAsigDesconexionesConfiguration(string schema)
        {
            ToTable("TBL_CEP_ASIGNACION_DESCONEXIONES", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CanalDeIngreso).HasColumnName(@"CANAL_DE_INGRESO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.MotivoDeDesconexion).HasColumnName(@"MOTIVO_DESCONEXION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Codigo).HasColumnName(@"CODIGO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Nota1).HasColumnName(@"NOTA_1").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.Nota2).HasColumnName(@"NOTA_2").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.Nota3).HasColumnName(@"NOTA_3").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.Nota4).HasColumnName(@"NOTA_4").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.Nota5).HasColumnName(@"NOTA_5").IsOptional().IsUnicode(false).HasColumnType("varchar");
            Property(x => x.Red).HasColumnName(@"RED").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.Servicios).HasColumnName(@"SERVICIOS").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaDeSolicitud).HasColumnName(@"FECHA_DE_SOLICITUD").IsOptional().HasColumnType("datetime");
            Property(x => x.FechaDeCorte).HasColumnName(@"FECHA_DE_CORTE").IsOptional().HasColumnType("datetime");
            Property(x => x.FechaDePreaviso).HasColumnName(@"FECHA_DE_PREAVISO").IsOptional().HasColumnType("datetime");
            Property(x => x.DiaDeDesconexion).HasColumnName(@"DIA_DE_DESCONEXION").IsOptional().HasColumnType("numeric");
            Property(x => x.TarifaAnterior).HasColumnName(@"TARIFA_ANTERIOR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaDeAsignacion).HasColumnName(@"FECHA_DE_ASIGNACION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioGestionando).HasColumnName(@"USUARIO_GESTIONANDO").IsOptional().HasColumnType("numeric");
            
        }
    }
}
