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

    // TBL_LINEA
    public class Linea
    {
        public int Id { get; set; } // ID (Primary key)
        public string Nombre { get; set; } // NOMBRE (length: 50)
        public int? IdModoLogin { get; set; } // ID_MODO_LOGIN

        public virtual System.Collections.Generic.ICollection<Usuario> Usuarios { get; set; } // TBL_USUARIOS.FK__TBL_USUAR__ID_LI__0E6E26BF

        // Foreign keys
        public virtual ModosLogin ModosLogin { get; set; } // FK__TBL_LINEA__ID_MO__1ED998B2

        public Linea()
        {
            Usuarios = new System.Collections.Generic.List<Usuario>();
        }
    }

}
