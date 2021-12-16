using SuperDuperMedAPP.Models.DTO;

namespace SuperDuperMedAPP.Data.Services
{
    public interface IAuthService
    {
        AuthData GetAuthData(int id, string role);
        string HashPassword(string password);
        bool VerifyPassword(string? actualPassword, string hashedPassword);
    }
}