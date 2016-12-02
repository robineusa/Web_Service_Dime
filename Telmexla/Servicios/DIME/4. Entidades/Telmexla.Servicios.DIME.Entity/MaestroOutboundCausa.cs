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

    // MAESTRO_OUTBOUND_CAUSA
    public class MaestroOutboundCausa
    {
        public decimal IdCausa { get; set; } // ID_CAUSA (Primary key)
        public decimal IdRazon { get; set; } // ID_RAZON
        public string Causa { get; set; } // CAUSA (length: 100)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<MaestroOutboundMotivo> MaestroOutboundMotivoes { get; set; } // MAESTRO_OUTBOUND_MOTIVO.FK__MAESTRO_O__ID_CA__5555A4F4

        // Foreign keys
        public virtual MaestroOutboundRazon MaestroOutboundRazon { get; set; } // FK__MAESTRO_O__ID_RA__1881A0DE

        public MaestroOutboundCausa()
        {
            MaestroOutboundMotivoes = new System.Collections.Generic.List<MaestroOutboundMotivo>();
        }
    }

}
