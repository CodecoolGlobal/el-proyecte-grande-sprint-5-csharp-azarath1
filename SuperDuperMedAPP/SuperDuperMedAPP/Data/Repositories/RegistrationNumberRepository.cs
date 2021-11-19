using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SuperDuperMedAPP.Data.Repositories
{
    public class RegistrationNumberRepository : IRegistrationNumberRepository
    {
        public readonly AppDbContext _db;

        public RegistrationNumberRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> IsRegNumberValid(string regNumber)
        {
            return await _db.RegistrationNumbers.Select(x => x.RegNumber.Equals(regNumber)).FirstOrDefaultAsync();

        }
    }
}