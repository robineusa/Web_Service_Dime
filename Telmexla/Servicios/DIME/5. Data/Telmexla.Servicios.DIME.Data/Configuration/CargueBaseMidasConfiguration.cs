using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class CargueBaseMidasConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<CargueBaseMidas>
    {
        public CargueBaseMidasConfiguration()
            : this("dbo")
        {
        }

        public CargueBaseMidasConfiguration(string schema)
        {
            ToTable("TMP_GMC_MIDAS", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.CuentaCliente).HasColumnName(@"CUENTA_CLIENTE").IsOptional().HasColumnType("numeric");
            Property(x => x.FechaAsignacion).HasColumnName(@"FECHA_ASIGNACION").IsOptional().HasColumnType("datetime");
            Property(x => x.ConsumosPPV).HasColumnName(@"CONSUMOS_PPV").IsOptional().HasColumnType("numeric");
            Property(x => x.UltimoPPV).HasColumnName(@"ULTIMA_PPV").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SiembraHD).HasColumnName(@"SIEMBRA_HD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.SiembraVoz).HasColumnName(@"SIEMBRA_VOZ").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.BlindajeInternet).HasColumnName(@"BLINDAJE_INTERNET").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.UltimaMarca1).HasColumnName(@"ULTIMA_MARCA_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaUltimaMarca1).HasColumnName(@"FECHA_ULTIMA_MARCA_1").IsOptional().HasColumnType("datetime");
            Property(x => x.UltimaMarca2).HasColumnName(@"ULTIMA_MARCA_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(255);
            Property(x => x.FechaUltimaMarca2).HasColumnName(@"FECHA_ULTIMA_MARCA2").IsOptional().HasColumnType("datetime");
            Property(x => x.UltimaMarcaCancelacion).HasColumnName(@"ULTIMA_MARCA_CANCELACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.FechaUltimaMarcaCancelacion).HasColumnName(@"FECHA_ULTIMA_MARCA_CANCELACION").IsOptional().HasColumnType("datetime");
            Property(x => x.Ofrecimiento1).HasColumnName(@"OFRECIMIENTO_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.Ofrecimiento2).HasColumnName(@"OFRECIMIENTO_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.Ofrecimiento3).HasColumnName(@"OFRECIMIENTO_3").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.Campaña1).HasColumnName(@"CAMPAÑA_1").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.Campaña2).HasColumnName(@"CAMPAÑA_2").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.Campaña3).HasColumnName(@"CAMPAÑA_3").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.UsuarioGestionando).HasColumnName(@"USUARIO_GESTIONANDO").IsOptional().HasColumnType("numeric");
        }
    }
}
