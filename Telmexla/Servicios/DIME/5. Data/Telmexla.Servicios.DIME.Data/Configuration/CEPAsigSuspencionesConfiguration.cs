#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
   public  class CEPAsigSuspencionesConfiguration: System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CEPAsigSuspenciones>
    {
        public CEPAsigSuspencionesConfiguration()
            : this("dbo")
        {
        }

        public CEPAsigSuspencionesConfiguration(string schema)
        {
            ToTable("TBL_CEP_ASIGNACION_SUSPENSIONES", schema);
            HasKey(x => new { x.IdAsignacion });

            Property(x => x.IdAsignacion).HasColumnName(@"ID_ASIGNACION").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.CanalDeIngreso).HasColumnName(@"CANAL_DE_INGRESO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaCreacion).HasColumnName(@"FECHA_CREACION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioCreacion).HasColumnName(@"USUARIO_CREACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.UsuarioGestionando).HasColumnName(@"USUARIO_GESTIONANDO").IsOptional().HasColumnType("numeric");
        }
    }
}
