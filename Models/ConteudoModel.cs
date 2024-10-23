namespace Api.Models
{
    public class ConteudoModel
    {
        public int ConteudoId { get; set; }

        public int ProfessorId { get; set; } 

        public int MateriasId { get; set; } 

        public string ConteudoTexto { get; set; } = string.Empty;

        public static implicit operator List<object>(ConteudoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
