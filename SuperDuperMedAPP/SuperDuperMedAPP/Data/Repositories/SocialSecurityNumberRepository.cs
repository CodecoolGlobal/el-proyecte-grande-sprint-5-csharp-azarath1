using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SuperDuperMedAPP.Data.Repositories
{
    public class SocialSecurityNumberRepository: ISocialSecurityNumberRepository
    {
        private readonly AppDbContext _db;

        public SocialSecurityNumberRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> SocNumberValid(string socNumber)
        {
            return await _db.SocialSecurityNumbers.AnyAsync(x => x.SocialSecurityNum.Equals(socNumber));
        }
    }
}