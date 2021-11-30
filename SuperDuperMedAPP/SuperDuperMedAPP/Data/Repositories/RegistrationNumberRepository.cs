using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SuperDuperMedAPP.Data.Repositories
{
    public class RegistrationNumberRepository : IRegistrationNumberRepository
    {
        private readonly AppDbContext _db;

        public RegistrationNumberRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> RegNumberValid(string regNumber)
        {
            return await _db.RegistrationNumbers.AnyAsync(x => x.RegNumber.Equals(regNumber));

        }
    }
}