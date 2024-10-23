namespace Api.Models
{
    public class ComentarioModel
    {
        public int ComentarioId { get; set; }

        public int ConteudoId { get; set; } 

        public int DuvidaId { get; set; } 

        public int ProfessorId { get; set; }

        public int AlunoId { get; set; } 

        public string ComentarioTexto { get; set; } = string.Empty;


        public static implicit operator List<object>(ComentarioModel v)
        {
            throw new NotImplementedException();
        }
    }
}
