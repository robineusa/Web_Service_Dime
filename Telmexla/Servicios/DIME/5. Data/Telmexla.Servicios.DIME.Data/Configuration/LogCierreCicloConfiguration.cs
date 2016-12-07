// <auto-generated>
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
    // TBL_LOG_CIERRE_CICLO
    public class LogCierreCicloConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<LogCierreCiclo>
    {
        public LogCierreCicloConfiguration()
            : this("dbo")
        {
        }

        public LogCierreCicloConfiguration(string schema)
        {
            ToTable("TBL_LOG_CIERRE_CICLO", schema);
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"ID").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.FechaGestion).HasColumnName(@"FECHA_GESTION").IsOptional().HasColumnType("datetime");
            Property(x => x.UsuarioGestion).HasColumnName(@"USUARIO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.AliadoGestion).HasColumnName(@"ALIADO_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Cuenta).HasColumnName(@"CUENTA").IsOptional().HasColumnType("float");
            Property(x => x.Ofrecimiento1).HasColumnName(@"OFRECIMIENTO_1").IsOptional().HasColumnType("numeric");
            Property(x => x.Ofrecimiento2).HasColumnName(@"OFRECIMIENTO_2").IsOptional().HasColumnType("numeric");
            Property(x => x.Ofrecimiento3).HasColumnName(@"OFRECIMIENTO_3").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio1).HasColumnName(@"P_SERVICIO_1").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio2).HasColumnName(@"P_SERVICIO_2").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio3).HasColumnName(@"P_SERVICIO_3").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio4).HasColumnName(@"P_SERVICIO_4").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio5).HasColumnName(@"P_SERVICIO_5").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio6).HasColumnName(@"P_SERVICIO_6").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio7).HasColumnName(@"P_SERVICIO_7").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio8).HasColumnName(@"P_SERVICIO_8").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio9).HasColumnName(@"P_SERVICIO_9").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio10).HasColumnName(@"P_SERVICIO_10").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio11).HasColumnName(@"P_SERVICIO_11").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio12).HasColumnName(@"P_SERVICIO_12").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio13).HasColumnName(@"P_SERVICIO_13").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio14).HasColumnName(@"P_SERVICIO_14").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio15).HasColumnName(@"P_SERVICIO_15").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio16).HasColumnName(@"P_SERVICIO_16").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio17).HasColumnName(@"P_SERVICIO_17").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio18).HasColumnName(@"P_SERVICIO_18").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio19).HasColumnName(@"P_SERVICIO_19").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio20).HasColumnName(@"P_SERVICIO_20").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio21).HasColumnName(@"P_SERVICIO_21").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio22).HasColumnName(@"P_SERVICIO_22").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio23).HasColumnName(@"P_SERVICIO_23").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio24).HasColumnName(@"P_SERVICIO_24").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio25).HasColumnName(@"P_SERVICIO_25").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio26).HasColumnName(@"P_SERVICIO_26").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio27).HasColumnName(@"P_SERVICIO_27").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio28).HasColumnName(@"P_SERVICIO_28").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio29).HasColumnName(@"P_SERVICIO_29").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio30).HasColumnName(@"P_SERVICIO_30").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio31).HasColumnName(@"P_SERVICIO_31").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio32).HasColumnName(@"P_SERVICIO_32").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio33).HasColumnName(@"P_SERVICIO_33").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio34).HasColumnName(@"P_SERVICIO_34").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio35).HasColumnName(@"P_SERVICIO_35").IsOptional().HasColumnType("numeric");
            Property(x => x.PServicio36).HasColumnName(@"P_SERVICIO_36").IsOptional().HasColumnType("numeric");
            Property(x => x.TipoContacto).HasColumnName(@"TIPO_CONTACTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Gestion).HasColumnName(@"GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Cierre).HasColumnName(@"CIERRE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Razon).HasColumnName(@"RAZON").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Obervaciones).HasColumnName(@"OBERVACIONES").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(1000);
            Property(x => x.Base).HasColumnName(@"BASE").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.OperacionGestion).HasColumnName(@"OPERACION_GESTION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(50);
            Property(x => x.Motivo).HasColumnName(@"MOTIVO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(100);
            Property(x => x.Seguimiento).HasColumnName(@"SEGUIMIENTO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(2);
            Property(x => x.FechaSeguimiento).HasColumnName(@"FECHA_SEGUIMIENTO").IsOptional().HasColumnType("datetime");
        }
    }

}
// </auto-generated>
