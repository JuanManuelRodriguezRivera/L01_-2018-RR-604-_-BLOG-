using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace L01__2018_RR_604___BLOG_.Models
{
    public class usuarios
    {
        public int usurioId { get; set; }
        
        public int rolId { get; set; }

        public string nombreUsuario { get; set; }

        public string clave { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }
    }

}
