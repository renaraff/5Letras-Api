namespace Api.Models
{
    public class DuvidaModel
    {
        public int DuvidaId { get; set; }

        public int AlunoId { get; set; }

        public int MateriasId { get; set; } 

        public string DuvidaTexto { get; set; } = string.Empty;


        public static implicit operator List<object>(DuvidaModel v)
        {
            throw new NotImplementedException();
        }
    }
}