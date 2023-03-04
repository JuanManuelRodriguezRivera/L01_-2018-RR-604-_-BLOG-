using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace L01__2018_RR_604___BLOG_.Models
{
    public class usuario
    {
        public int UsurioId { get; set; }
        
        public int RolId { get; set; }

        public string NombreUsuario { get; set; }

        public string Clave { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }
    }

}
