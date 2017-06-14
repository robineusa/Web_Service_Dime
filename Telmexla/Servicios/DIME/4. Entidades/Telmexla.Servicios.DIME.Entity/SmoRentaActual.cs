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


namespace Telmexla.Servicios.DIME.Entity
{
    public class SmoRentaActual
    {
        public double Cuenta { get; set; } // CUENTA (Primary key)
        public double? HomePass { get; set; } // HOME_PASS
        public string Estrato { get; set; } // ESTRATO (length: 5)
        public double? Antiguedad { get; set; } // ANTIGUEDAD
        public string Tarifa { get; set; } // TARIFA (length: 3)
        public string Productos { get; set; } // PRODUCTOS (length: 4000)
        public string TipoTv { get; set; } // TIPO_TV (length: 16)
        public double? VelocidadInternet { get; set; } // VELOCIDAD_INTERNET
        public string VelocidadHomologada { get; set; } // VELOCIDAD_HOMOLOGADA (length: 6)
        public string SrvHd { get; set; } // SRV_HD (length: 2)
        public double? CantidadDecos { get; set; } // CANTIDAD_DECOS
        public string Voz { get; set; } // VOZ (length: 2)
        public double? CantidadHd { get; set; } // CANTIDAD_HD
        public double? CantidadPvr { get; set; } // CANTIDAD_PVR
        public double? Ip { get; set; } // IP
        public string Hbo { get; set; } // HBO (length: 2)
        public string Fox { get; set; } // FOX (length: 2)
        public string Ufc { get; set; } // UFC (length: 2)
        public string Gld { get; set; } // GLD (length: 2)
        public string Revista { get; set; } // REVISTA (length: 2)
        public string Adultos { get; set; } // ADULTOS (length: 2)
        public string ClaroVideo { get; set; } // CLARO_VIDEO (length: 2)
        public double? RentaVoz { get; set; } // RENTA_VOZ
        public double? RentaInternet { get; set; } // RENTA_INTERNET
        public double? RentaTv { get; set; } // RENTA_TV
        public double? RentaBasica { get; set; } // RENTA_BASICA
        public double? RentaRevista { get; set; } // RENTA_REVISTA
        public double? RentaHd { get; set; } // RENTA_HD
        public double? RentaPvr { get; set; } // RENTA_PVR
        public double? RentaHbo { get; set; } // RENTA_HBO
        public double? RentaFox { get; set; } // RENTA_FOX
        public double? RentaAdu { get; set; } // RENTA_ADU
        public double? RentaCv { get; set; } // RENTA_CV
        public double? RentaOtros { get; set; } // RENTA_OTROS
        public double? RentaAdicional { get; set; } // RENTA_ADICIONAL
        public double? RentaTotal { get; set; } // RENTA_TOTAL
        public double? VariasLineas { get; set; } // VARIAS_LINEAS
        public double? Pvr { get; set; } // PVR
        public string TipoServicio { get; set; } // TIPO_SERVICIO (length: 2)
        public double? ValidacionEstrato { get; set; } // VALIDACION_ESTRATO
        public double? Ot { get; set; } // OT
        public double? CampanaAplicada { get; set; } // CAMPANA_APLICADA
        public double? FechaFinCampa { get; set; } // FECHA_FIN_CAMPA
        public double? Excluidos { get; set; } // EXCLUIDOS
        public double? Verificacion { get; set; } // VERIFICACION
        public string TarifaHomologada { get; set; } // TARIFA_HOMOLOGADA (length: 10)
        public string IncluyeHd { get; set; } // INCLUYE_HD (length: 10)
        public string IncluyePvr { get; set; } // INCLUYE_PVR (length: 10)
        public string InclyeClarovideo { get; set; } // INCLYE_CLAROVIDEO (length: 10)
        public long? RentaHomologada { get; set; } // RENTA_HOMOLOGADA
        public double? HomIp { get; set; } // HOM_IP
        public double? HomHbo { get; set; } // HOM_HBO
        public double? HomFox { get; set; } // HOM_FOX
        public double? HomRevista { get; set; } // HOM_REVISTA
        public double? HomAdu { get; set; } // HOM_ADU
        public double? HomCv { get; set; } // HOM_CV
        public double? HomUfc { get; set; } // HOM_UFC
        public double? HomGld { get; set; } // HOM_GLD
        public double? ArriendoDecos { get; set; } // ARRIENDO_DECOS
        public double? HomPvrHd { get; set; } // HOM_PVR_HD
        public double? HomAdicional { get; set; } // HOM_ADICIONAL
        public double? HomTotal { get; set; } // HOM_TOTAL
        public double? DiferenciaRentas { get; set; } // DIFERENCIA_RENTAS
        public string Clasificacion { get; set; } // CLASIFICACION (length: 14)
        public double? DecosNagra { get; set; } // DECOS_NAGRA
    }

}
// </auto-generated>
