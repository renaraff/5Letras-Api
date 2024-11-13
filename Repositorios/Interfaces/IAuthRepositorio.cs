using Api.Models;

namespace Api.Repositorios.Interfaces
{
    public interface IAuthRepositorio
    {
        Task<Auth> Login(string email, string senha );
    }
}
