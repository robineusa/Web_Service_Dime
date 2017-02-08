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

    // TBL_SUBRAZON1_INGRESO_SOPORTE
    public class Subrazon1IngresoSoporte
    {
        public int Id { get; set; } // ID (Primary key)
        public string Nombre { get; set; } // NOMBRE (length: 100)
        public int? IdRazon { get; set; } // ID_RAZON

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<Subrazon2IngresoSoporte> Subrazon2IngresoSoporte { get; set; } // TBL_SUBRAZON2_INGRESO_SOPORTE.FK__TBL_SUBRA__ID_SU__0A688BB1

        // Foreign keys
        public virtual RazonIngresoSoporte RazonIngresoSoporte { get; set; } // FK__TBL_SUBRA__ID_RA__078C1F06

        public Subrazon1IngresoSoporte()
        {
            Subrazon2IngresoSoporte = new System.Collections.Generic.List<Subrazon2IngresoSoporte>();
        }
    }

}
// </auto-generated>
