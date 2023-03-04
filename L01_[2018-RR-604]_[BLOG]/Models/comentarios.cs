namespace L01__2018_RR_604___BLOG_.Models
{
    public class comentarios
    {
        public int ComentarioId { get; set; }

        public int? PublicacionId { get; set; }

        public string Comentario { get; set; }

        public int? UsuarioId { get; set; }
    }
}
