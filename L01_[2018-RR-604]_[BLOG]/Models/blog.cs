using System.ComponentModel.DataAnnotations;
namespace L01__2018_RR_604___BLOG_.Models
{
    public class blog
    {
        public int rolId { get; set; }

        public string rol { get; set; }

        public int usuarioId { get; set; }

        public int rolId { get; set; }

        public string nombreUsuario { get; set; }

        public string clave { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public int publicacionId { get; set; }

        public string titulo { get; set; }

        public string descripcion { get; set; }

        public int usuarioId { get; set; }

        public int comentarioId { get; set; }

        public int? publicacionId { get; set; }

        public string comentario {get; set; }

        public int usuarioId { get; set; }

        public int calificacionId { get; set; }

        public int? publicacionId { get; set; }

        public int? usuario { get; set; }

        public int? calificacion { get; set; }
    }
}
