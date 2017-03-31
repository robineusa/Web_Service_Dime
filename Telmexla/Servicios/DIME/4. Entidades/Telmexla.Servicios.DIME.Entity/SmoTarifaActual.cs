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

    // TBL_SMO_TARIFA_ACTUAL
    public class SmoTarifaActual
    {
        public int Id { get; set; } // ID (Primary key)
        public string NombreTarifa { get; set; } // NOMBRE_TARIFA (length: 255)
        public string Estrato { get; set; } // ESTRATO (length: 10)
        public string CodTarifaRes { get; set; } // COD_TARIFA_RES (length: 255)
        public string CodTarifaSoho { get; set; } // COD_TARIFA_SOHO (length: 255)
        public string TipoInternet { get; set; } // TIPO_INTERNET (length: 255)
        public string TipoTv { get; set; } // TIPO_TV (length: 255)
        public string Voz { get; set; } // VOZ (length: 255)
        public string Paquete { get; set; } // PAQUETE (length: 255)
        public string ProductoPaq { get; set; } // PRODUCTO_PAQ (length: 255)
        public decimal? RentaPromocion { get; set; } // RENTA_PROMOCION
        public decimal? RentaTotal { get; set; } // RENTA_TOTAL
        public string IncluyeHd { get; set; } // INCLUYE_HD (length: 255)
        public string IncluyePvr { get; set; } // INCLUYE_PVR (length: 255)
        public string InclyeClarovideo { get; set; } // INCLYE_CLAROVIDEO (length: 255)
        public string Periodo { get; set; } // PERIODO (length: 255)
        public string Tarifa { get; set; } // TARIFA (length: 255)
    }

}
// </auto-generated>
