using System.Threading.Tasks;

namespace SuperDuperMedAPP.Data.Repositories
{
    public interface IRegistrationNumberRepository
    {
        Task<bool> IsRegNumberValid(string regNumber);
    }
}