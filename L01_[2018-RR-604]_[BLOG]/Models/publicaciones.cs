using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace L01__2018_RR_604___BLOG_.Models
{
    public class publicaciones
    {
        public int publicacionId { get; set; }

        public string titulo { get; set; }

        public string descripcion { get; set; }

        public int? usuarioId { get; set; }
    }
}
