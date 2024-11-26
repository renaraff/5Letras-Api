namespace Api.Models
{
    public class PublicarModel
    {
        public int PublicarId { get; set; }

        public int UsuarioId { get; set; }

        public int MateriaId { get; set; }

        public string PublicarTexto { get; set; } = string.Empty;

        public static implicit operator List<object>(PublicarModel v)
        {
            throw new NotImplementedException();
        }
    }
}
