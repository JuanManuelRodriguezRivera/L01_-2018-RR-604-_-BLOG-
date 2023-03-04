using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace L01__2018_RR_604___BLOG_.Models
{
    public class comentarios
    {
        public int cometarioId { get; set; }

        public int? publicacionId { get; set; }

        public string comentario { get; set; }

        public int? usuarioId { get; set; }
    }
}
