using HummanResourceManagementSystem.DTOs.Authantication.Request;

namespace HummanResourceManagementSystem.Interfaces
{
    public interface IAuthanticationService
    {
        Task<string> Login(LoginDTO input);
    }
}
