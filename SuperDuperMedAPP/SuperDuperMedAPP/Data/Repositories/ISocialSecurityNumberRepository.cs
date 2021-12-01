using System.Threading.Tasks;

namespace SuperDuperMedAPP.Data.Repositories
{
    public interface ISocialSecurityNumberRepository
    {
        Task<bool> SocNumberValid(string? socNumber);
    }
}