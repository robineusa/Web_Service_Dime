﻿
namespace Telmexla.Servicios.DIME.Entity
{
    public class GBLProductoCA
    {
        public decimal Id { get; set; }
        public System.DateTime? FechaGestion { get; set; }
        public string UsuarioGestion { get; set; }
        public decimal CedulaUsuario { get; set; }
        public string NombreUsuarioGestion { get; set; }
        public string AliadoGestion { get; set; }
        public string OperacionGestion { get; set; }
        public string CampanaGestion { get; set; }
        public decimal CuentaCliente { get; set; }
        public string TipoContacto { get; set; }
        public string Gestion { get; set; }
        public string Cierre { get; set; }
        public string Causa { get; set; }
        public string Observaciones { get; set; }
        public System.DateTime? FechaSeguimiento { get; set; }
    }
}
