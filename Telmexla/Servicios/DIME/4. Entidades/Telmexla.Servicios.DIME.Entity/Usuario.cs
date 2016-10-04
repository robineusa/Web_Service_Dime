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

using System.ComponentModel.DataAnnotations;

namespace Telmexla.Servicios.DIME.Entity
{

    // TBL_USUARIOS
    public class Usuario
    {
        public int Id { get; set; } // ID (Primary key)

        [Display(Name="Cedula de Ciudadania")]
        public decimal? Cedula { get; set; } // CEDULA
        public string Nombre { get; set; } // NOMBRE (length: 20)
        public string Contrasena { get; set; } // CONTRASENA (length: 300)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<RegistroSesion> RegistroSesions { get; set; } // TBL_REGISTRO_SESION.FK__TBL_REGIS__ID_US__37703C52
        public virtual System.Collections.Generic.ICollection<UsuariosXAcceso> UsuariosXAccesoes { get; set; } // Many to many mapping
        public virtual System.Collections.Generic.ICollection<UsuariosXPreguntasDesb> UsuariosXPreguntasDesbs { get; set; } // Many to many mapping

        public Usuario()
        {
            RegistroSesions = new System.Collections.Generic.List<RegistroSesion>();
            UsuariosXAccesoes = new System.Collections.Generic.List<UsuariosXAcceso>();
            UsuariosXPreguntasDesbs = new System.Collections.Generic.List<UsuariosXPreguntasDesb>();
        }
    }

}
