using System.Threading.Tasks;

namespace SuperDuperMedAPP.Data.Repositories
{
    public interface IRegistrationNumberRepository
    {
        Task<bool> RegNumberValid(string? regNumber);
    }
}