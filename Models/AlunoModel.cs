namespace Api.Models
{
    public class AlunoModel
    {
        public int AlunoId { get; set; }

        public string AlunoNome { get; set; } = string.Empty;

        public string AlunoEmail { get; set; } = string.Empty;

        public string AlunoSenha { get; set; } = string.Empty;

        public string AlunoEscolaridade { get; set; } = string.Empty;

        public static implicit operator List<object>(AlunoModel v)
        {
            throw new NotImplementedException();
        }
    }
}
