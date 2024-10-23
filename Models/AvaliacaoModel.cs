namespace Api.Models
{
    public class AvaliacaoModel
    {
        public int AvaliacaoId { get; set; }

        public int AlunoId { get; set; }

        public int ProfessorId { get; set; }

        public string AvaliacaoDescricao { get; set; } = string.Empty;

        public string AvaliacaoEstrela { get; set; } = string.Empty;

        public static implicit operator List<object>(AvaliacaoModel v)
        {
            throw new NotImplementedException();
        }
    }
}