using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class MaestroFestivosConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MaestroFestivos>
    {
        public MaestroFestivosConfiguration()
            : this("dbo")
        {
        }

        public MaestroFestivosConfiguration(string schema)
        {
            ToTable("TMP_MAESTRO_FESTIVOS", schema);
            HasKey(x => new { x.Id });
            Property(x => x.Id).HasColumnName(@"ID").IsOptional().HasColumnType("numeric");
            Property(x => x.Ano).HasColumnName(@"ANO").IsOptional().HasColumnType("varchar").HasMaxLength(5);
            Property(x => x.Fecha).HasColumnName(@"FECHA").IsOptional().HasColumnType("datetime");
            Property(x => x.FechaRR).HasColumnName(@"FECHA_RR").IsOptional().HasColumnType("varchar").HasMaxLength(8);
            Property(x => x.NombreDia).HasColumnName(@"NOMBRE_DIA").IsOptional().HasColumnType("varchar").HasMaxLength(20);
            Property(x => x.NombreMes).HasColumnName(@"NOMBRE_MES").IsOptional().HasColumnType("varchar").HasMaxLength(20);
            Property(x => x.NumeroDia).HasColumnName(@"NUMERO_DIA").IsOptional().HasColumnType("varchar").HasMaxLength(2);
            Property(x => x.NumeroMes).HasColumnName(@"NUMERO_MES").IsOptional().HasColumnType("varchar").HasMaxLength(2);
            Property(x => x.TipoDiaFestivo).HasColumnName(@"TIPO_DIA_FESTIVO").IsOptional().HasColumnType("varchar").HasMaxLength(8);
            Property(x => x.TipoDiaLunSab).HasColumnName(@"TIPO_DIA_LUNES_SABADO").IsOptional().HasColumnType("varchar").HasMaxLength(8);
            Property(x => x.TipoDiaLunVier).HasColumnName(@"TIPO_DIA_LUNES_VIERNES").IsOptional().HasColumnType("varchar").HasMaxLength(8);
        }
    }
}
