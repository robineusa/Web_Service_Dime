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

    // TBL_USUARIOS_X_ACCESOS
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class UsuariosXAcceso
    {
        public int Id { get; set; } // ID (Primary key)
        public int IdUsuario { get; set; } // ID_USUARIO (Primary key)
        public int IdAcceso { get; set; } // ID_ACCESO (Primary key)
        public int? IdUserCambioo { get; set; } // ID_USER_CAMBIOO
        public System.DateTime? FechaCreacion { get; set; } // FECHA_CREACION
        public System.TimeSpan? HoraCreacion { get; set; } // HORA_CREACION
        public string IpPublicaCreacion { get; set; } // IP_PUBLICA_CREACION (length: 15)
        public string IpPrivadaCreacion { get; set; } // IP_PRIVADA_CREACION (length: 15)

        // Foreign keys
        public virtual Acceso Acceso { get; set; } // FK__TBL_USUAR__ID_AC__20C1E124
        public virtual Usuario Usuario { get; set; } // FK__TBL_USUAR__ID_US__21B6055D
    }

}
// </auto-generated>
