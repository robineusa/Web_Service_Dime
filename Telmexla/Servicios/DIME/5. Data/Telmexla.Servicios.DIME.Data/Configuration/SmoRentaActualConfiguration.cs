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

    // TBL_SMO_RENTA_ACTUAL
    public class SmoRentaActualConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<SmoRentaActual>
    {
        public SmoRentaActualConfiguration()
            : this("dbo")
        {
        }

        public SmoRentaActualConfiguration(string schema)
        {
            ToTable("TBL_SMO_RENTA_ACTUAL", schema);
            HasKey(x => x.Cuenta);

            Property(x => x.Cuenta).HasColumnName(@"CUENTA").IsRequired().HasColumnType("float").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.HomePass).HasColumnName(@"HOME_PASS").IsOptional().HasColumnType("float");
            Property(x => x.Estrato).HasColumnName(@"ESTRATO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(5);
            Property(x => x.Antiguedad).HasColumnName(@"ANTIGUEDAD").IsOptional().HasColumnType("float");
            Property(x => x.Tarifa).HasColumnName(@"TARIFA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(4);
            Property(x => x.Productos).HasColumnName(@"PRODUCTOS").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(4000);
            Property(x => x.TipoTv).HasColumnName(@"TIPO_TV").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(16);
            Property(x => x.VelocidadInternet).HasColumnName(@"VELOCIDAD_INTERNET").IsOptional().HasColumnType("float");
            Property(x => x.VelocidadHomologada).HasColumnName(@"VELOCIDAD_HOMOLOGADA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(6);
            Property(x => x.SrvHd).HasColumnName(@"SRV_HD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(2);
            Property(x => x.CantidadDecos).HasColumnName(@"CANTIDAD_DECOS").IsOptional().HasColumnType("float");
            Property(x => x.Voz).HasColumnName(@"VOZ").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(2);
            Property(x => x.CantidadHd).HasColumnName(@"CANTIDAD_HD").IsOptional().HasColumnType("float");
            Property(x => x.CantidadPvr).HasColumnName(@"CANTIDAD_PVR").IsOptional().HasColumnType("float");
            Property(x => x.Ip).HasColumnName(@"IP").IsOptional().HasColumnType("float");
            Property(x => x.Hbo).HasColumnName(@"HBO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(2);
            Property(x => x.Fox).HasColumnName(@"FOX").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(2);
            Property(x => x.Ufc).HasColumnName(@"UFC").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(2);
            Property(x => x.Gld).HasColumnName(@"GLD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(2);
            Property(x => x.Revista).HasColumnName(@"REVISTA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(2);
            Property(x => x.Adultos).HasColumnName(@"ADULTOS").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(2);
            Property(x => x.ClaroVideo).HasColumnName(@"CLARO_VIDEO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(2);
            Property(x => x.RentaVoz).HasColumnName(@"RENTA_VOZ").IsOptional().HasColumnType("float");
            Property(x => x.RentaInternet).HasColumnName(@"RENTA_INTERNET").IsOptional().HasColumnType("float");
            Property(x => x.RentaTv).HasColumnName(@"RENTA_TV").IsOptional().HasColumnType("float");
            Property(x => x.RentaBasica).HasColumnName(@"RENTA_BASICA").IsOptional().HasColumnType("float");
            Property(x => x.RentaRevista).HasColumnName(@"RENTA_REVISTA").IsOptional().HasColumnType("float");
            Property(x => x.RentaHd).HasColumnName(@"RENTA_HD").IsOptional().HasColumnType("float");
            Property(x => x.RentaPvr).HasColumnName(@"RENTA_PVR").IsOptional().HasColumnType("float");
            Property(x => x.RentaHbo).HasColumnName(@"RENTA_HBO").IsOptional().HasColumnType("float");
            Property(x => x.RentaFox).HasColumnName(@"RENTA_FOX").IsOptional().HasColumnType("float");
            Property(x => x.RentaAdu).HasColumnName(@"RENTA_ADU").IsOptional().HasColumnType("float");
            Property(x => x.RentaCv).HasColumnName(@"RENTA_CV").IsOptional().HasColumnType("float");
            Property(x => x.RentaOtros).HasColumnName(@"RENTA_OTROS").IsOptional().HasColumnType("float");
            Property(x => x.RentaAdicional).HasColumnName(@"RENTA_ADICIONAL").IsOptional().HasColumnType("float");
            Property(x => x.RentaTotal).HasColumnName(@"RENTA_TOTAL").IsOptional().HasColumnType("float");
            Property(x => x.VariasLineas).HasColumnName(@"VARIAS_LINEAS").IsOptional().HasColumnType("float");
            Property(x => x.Pvr).HasColumnName(@"PVR").IsOptional().HasColumnType("float");
            Property(x => x.TipoServicio).HasColumnName(@"TIPO_SERVICIO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(2);
            Property(x => x.ValidacionEstrato).HasColumnName(@"VALIDACION_ESTRATO").IsOptional().HasColumnType("float");
            Property(x => x.Ot).HasColumnName(@"OT").IsOptional().HasColumnType("float");
            Property(x => x.CampanaAplicada).HasColumnName(@"CAMPANA_APLICADA").IsOptional().HasColumnType("float");
            Property(x => x.FechaFinCampa).HasColumnName(@"FECHA_FIN_CAMPA").IsOptional().HasColumnType("float");
            Property(x => x.Excluidos).HasColumnName(@"EXCLUIDOS").IsOptional().HasColumnType("float");
            Property(x => x.Verificacion).HasColumnName(@"VERIFICACION").IsOptional().HasColumnType("float");
            Property(x => x.TarifaHomologada).HasColumnName(@"TARIFA_HOMOLOGADA").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(10);
            Property(x => x.IncluyeHd).HasColumnName(@"INCLUYE_HD").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(10);
            Property(x => x.IncluyePvr).HasColumnName(@"INCLUYE_PVR").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(10);
            Property(x => x.InclyeClarovideo).HasColumnName(@"INCLYE_CLAROVIDEO").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(10);
            Property(x => x.RentaHomologada).HasColumnName(@"RENTA_HOMOLOGADA").IsOptional().HasColumnType("bigint");
            Property(x => x.HomIp).HasColumnName(@"HOM_IP").IsOptional().HasColumnType("float");
            Property(x => x.HomHbo).HasColumnName(@"HOM_HBO").IsOptional().HasColumnType("float");
            Property(x => x.HomFox).HasColumnName(@"HOM_FOX").IsOptional().HasColumnType("float");
            Property(x => x.HomRevista).HasColumnName(@"HOM_REVISTA").IsOptional().HasColumnType("float");
            Property(x => x.HomAdu).HasColumnName(@"HOM_ADU").IsOptional().HasColumnType("float");
            Property(x => x.HomCv).HasColumnName(@"HOM_CV").IsOptional().HasColumnType("float");
            Property(x => x.HomUfc).HasColumnName(@"HOM_UFC").IsOptional().HasColumnType("float");
            Property(x => x.HomGld).HasColumnName(@"HOM_GLD").IsOptional().HasColumnType("float");
            Property(x => x.ArriendoDecos).HasColumnName(@"ARRIENDO_DECOS").IsOptional().HasColumnType("float");
            Property(x => x.HomPvrHd).HasColumnName(@"HOM_PVR_HD").IsOptional().HasColumnType("float");
            Property(x => x.HomAdicional).HasColumnName(@"HOM_ADICIONAL").IsOptional().HasColumnType("float");
            Property(x => x.HomTotal).HasColumnName(@"HOM_TOTAL").IsOptional().HasColumnType("float");
            Property(x => x.DiferenciaRentas).HasColumnName(@"DIFERENCIA_RENTAS").IsOptional().HasColumnType("float");
            Property(x => x.Clasificacion).HasColumnName(@"CLASIFICACION").IsOptional().IsUnicode(false).HasColumnType("varchar").HasMaxLength(14);
            Property(x => x.DecosNagra).HasColumnName(@"DECOS_NAGRA").IsOptional().HasColumnType("float");
        }
    }

}
// </auto-generated>
