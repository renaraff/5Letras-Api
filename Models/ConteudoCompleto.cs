namespace Api.Models
{
    public class ConteudoCompleto
    {
        public int ConteudoId { get; set; }

        public int ProfessorId { get; set; }

        public string ProfessorNome { get; set; } = string.Empty;

        public MateriasModel Materia { get; set; }

        public string ConteudoTexto { get; set; } = string.Empty;
    }
}
