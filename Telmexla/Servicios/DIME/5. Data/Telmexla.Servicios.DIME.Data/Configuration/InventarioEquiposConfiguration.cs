using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telmexla.Servicios.DIME.Entity;

namespace Telmexla.Servicios.DIME.Data.Configuration
{
    public class InventarioEquiposConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<InventarioEquipos>
    {
        public InventarioEquiposConfiguration():this("dbo")
        {

        }

        public InventarioEquiposConfiguration(string schema)
        {
            ToTable("TBL_INVENTARIO_EQUIPOS", schema);
            HasKey(x => new { x.Id });

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("numeric").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Cuenta).HasColumnName(@"CUENTA").IsRequired().HasColumnType("decimal");
            Property(x => x.Tipo).HasColumnName(@"TIPO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(3);
            Property(x => x.FabEquipo).HasColumnName(@"FAB_EQUIPO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(10);
            Property(x => x.SerieEquipo).HasColumnName(@"SERIE_EQUIPO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Estado).HasColumnName(@"ESTADO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(10);
            Property(x => x.Descripcion).HasColumnName(@"DESCRIPCION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(150);
        }
    }
}
