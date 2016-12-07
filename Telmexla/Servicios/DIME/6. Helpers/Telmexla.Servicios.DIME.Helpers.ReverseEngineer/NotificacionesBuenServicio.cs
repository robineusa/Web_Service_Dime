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

    // NOTIFICACIONES_BUEN_SERVICIO
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class NotificacionesBuenServicio
    {
        public decimal IdNotificado { get; set; } // ID_NOTIFICADO (Primary key)
        public System.DateTime? FechaPublicacion { get; set; } // FECHA_PUBLICACION
        public string UsuarioPublicacion { get; set; } // USUARIO_PUBLICACION (length: 30)
        public string NombreImagen { get; set; } // NOMBRE_IMAGEN (length: 50)
        public string LinkDireccionamiento { get; set; } // LINK_DIRECCIONAMIENTO (length: 500)
        public string Descripcion { get; set; } // DESCRIPCION (length: 500)
        public string AliadoDestino { get; set; } // ALIADO_DESTINO (length: 100)
        public string PerfilDestino { get; set; } // PERFIL_DESTINO (length: 100)
        public string NombreLineaDestino { get; set; } // NOMBRE_LINEA_DESTINO (length: 100)
    }

}
// </auto-generated>
