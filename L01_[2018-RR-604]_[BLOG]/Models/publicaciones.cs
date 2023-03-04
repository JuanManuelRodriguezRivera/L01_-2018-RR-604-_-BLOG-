namespace L01__2018_RR_604___BLOG_.Models
{
    public class publicaciones
    {
        public int publicacionId { get; set; }

        public string comentario { get; set; }

        public int? usuarioId { get; set; }

        public int? calificacionId { get; set; }
    }
}
