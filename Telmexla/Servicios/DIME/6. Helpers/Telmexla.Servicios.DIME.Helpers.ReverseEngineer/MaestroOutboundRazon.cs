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

namespace Telmexla.Servicios.DIME.Helpers.ReverseEngineer
{

    // MAESTRO_OUTBOUND_RAZON
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class MaestroOutboundRazon
    {
        public decimal IdRazon { get; set; } // ID_RAZON (Primary key)
        public decimal IdCierre { get; set; } // ID_CIERRE
        public string Razon { get; set; } // RAZON (length: 100)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<MaestroOutboundCausa> MaestroOutboundCausas { get; set; } // MAESTRO_OUTBOUND_CAUSA.FK__MAESTRO_O__ID_RA__1881A0DE

        // Foreign keys
        public virtual MaestroOutboundCierre MaestroOutboundCierre { get; set; } // FK__MAESTRO_O__RAZON__40C49C62

        public MaestroOutboundRazon()
        {
            MaestroOutboundCausas = new System.Collections.Generic.List<MaestroOutboundCausa>();
        }
    }

}
// </auto-generated>
