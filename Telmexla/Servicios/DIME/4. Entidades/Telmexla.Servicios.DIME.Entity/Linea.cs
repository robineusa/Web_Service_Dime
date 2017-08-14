namespace Telmexla.Servicios.DIME.Entity
{
    public class Linea
    {
        public int Id { get; set; } // ID (Primary key)
        public string Nombre { get; set; } // NOMBRE (length: 50)
        public int? IdModoLogin { get; set; } // ID_MODO_LOGIN

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<AccesosXLinea> AccesosXLineas { get; set; } // TBL_ACCESOS_X_LINEA.FK__TBL_ACCES__ID_LI__5CE1B823
        public virtual System.Collections.Generic.ICollection<Usuario> Usuarios { get; set; } // TBL_USUARIOS.FK__TBL_USUAR__ID_LI__68D28DBC

        // Foreign keys
        public virtual ModosLogin ModosLogin { get; set; } // FK__TBL_LINEA__ID_MO__0F6D37F0

        public Linea()
        {
            AccesosXLineas = new System.Collections.Generic.List<AccesosXLinea>();
            Usuarios = new System.Collections.Generic.List<Usuario>();
        }
    }

}
// </auto-generated>
