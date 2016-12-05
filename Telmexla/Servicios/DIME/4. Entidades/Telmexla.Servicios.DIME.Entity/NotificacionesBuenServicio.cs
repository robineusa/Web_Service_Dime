namespace Telmexla.Servicios.DIME.Entity
{
    public class NotificacionesBuenServicio
    {
        public int Id { get; set; } // ID (Primary key)
        public System.DateTime? Fecha_Publicacion { get; set; } // Fecha de la publicaion
        public string Usuario_Publicacion { get; set; }// Usuario de publicacion (varchar 30)
        public string Nombre_Imagen    { get; set; }// Nombre Imgen
        public string Link_Direccionamiento { get; set; }// Link Direccionamiento

        public string Descripcion { get; set; }// Descripcion de la imagen.

        public string Aliado_Destino { get; set; }// Aliado Destino
        public string Perfil_Destino { get; set; }// Perfil destino
        public string Nombre_Linea_Destino { get; set; }// Linea destino
    }
}
