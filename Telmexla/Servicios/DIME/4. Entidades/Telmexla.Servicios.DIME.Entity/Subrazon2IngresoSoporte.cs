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

    // TBL_SUBRAZON2_INGRESO_SOPORTE
    public class Subrazon2IngresoSoporte
    {
        public int Id { get; set; } // ID (Primary key)
        public string Nombre { get; set; } // NOMBRE (length: 100)
        public int? IdSubrazon1 { get; set; } // ID_SUBRAZON1

        // Foreign keys
        public virtual Subrazon1IngresoSoporte Subrazon1IngresoSoporte { get; set; } // FK__TBL_SUBRA__ID_SU__0A688BB1
    }

}
// </auto-generated>
