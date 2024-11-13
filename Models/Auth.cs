namespace Api.Models
{
    public class Auth
    {
        public int UsuarioId { get; set; }

        public string UsuarioNome { get; set; } = string.Empty;

        public string UsuarioEmail { get; set; } = string.Empty;

        public string? UsuarioSenha { get; set; } = string.Empty;

        public string UsuarioTipo { get; set; } = string.Empty;

    }
}
