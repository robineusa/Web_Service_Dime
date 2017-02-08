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

    // TBL_RAZON_INGRESO_SOPORTE
    public class RazonIngresoSoporte
    {
        public int Id { get; set; } // ID (Primary key)
        public string Nombre { get; set; } // NOMBRE (length: 100)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<Subrazon1IngresoSoporte> Subrazon1IngresoSoporte { get; set; } // TBL_SUBRAZON1_INGRESO_SOPORTE.FK__TBL_SUBRA__ID_RA__078C1F06

        public RazonIngresoSoporte()
        {
            Subrazon1IngresoSoporte = new System.Collections.Generic.List<Subrazon1IngresoSoporte>();
        }
    }

}
// </auto-generated>
