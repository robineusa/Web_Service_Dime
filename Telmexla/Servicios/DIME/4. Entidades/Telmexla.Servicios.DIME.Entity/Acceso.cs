
namespace Telmexla.Servicios.DIME.Entity
{
    // TBL_ACCESOS
    public class Acceso
    {
        public int Id { get; set; } // ID (Primary key)
        public string Nombre { get; set; } // NOMBRE (length: 50)
        public int? IdModoLogin { get; set; } // ID_MODO_LOGIN

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<AccesosXLinea> AccesosXLineas { get; set; } // TBL_ACCESOS_X_LINEA.FK__TBL_ACCES__ID_AC__5BED93EA
        public virtual System.Collections.Generic.ICollection<UsuariosXAcceso> UsuariosXAccesoes { get; set; } // TBL_USUARIOS_X_ACCESOS.FK__TBL_USUAR__ID_AC__52E34C9D

        // Foreign keys
        public virtual ModosLogin ModosLogin { get; set; } // FK__TBL_ACCES__ID_MO__1DE57479

        public Acceso()
        {
            AccesosXLineas = new System.Collections.Generic.List<AccesosXLinea>();
            UsuariosXAccesoes = new System.Collections.Generic.List<UsuariosXAcceso>();
        }
    }

}
