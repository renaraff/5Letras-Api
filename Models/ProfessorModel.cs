namespace Api.Models
{
    public class ProfessorModel
    {
        public int ProfessorId { get; set; }

        public string ProfessorNome { get; set; } = string.Empty;

        public string ProfessorEmail { get; set; } = string.Empty;

        public string ProfessorSenha { get; set; } = string.Empty;

        public string ProfessorGraduacao { get; set; } = string.Empty;

        public string ProfessorDescricao { get; set; } = string.Empty;

        public string ProfessorOcupacao { get; set; } = string.Empty;

        public static implicit operator List<object>(ProfessorModel v)
        {
            throw new NotImplementedException();
        }
    }
}
