using System;

namespace ProyectoRoot.Controllers.Models
{
    public class Contacto
    {
        public int Id{ get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Apodo { get; set; }
        public string Ubicacion { get; set; }
        public DateTime FechaCreacion{ get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
