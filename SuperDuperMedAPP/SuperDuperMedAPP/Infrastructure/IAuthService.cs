using SuperDuperMedAPP.Models.DTO;

namespace SuperDuperMedAPP.Infrastructure
{
    public interface IAuthService
    {
        AuthData GetAuthData(string id);
        string HashPassword(string password);
        bool VerifyPassword(string actualPassword, string hashedPassword);
    }
}