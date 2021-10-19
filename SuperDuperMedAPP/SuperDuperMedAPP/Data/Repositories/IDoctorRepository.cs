using System.Threading.Tasks;
using SuperDuperMedAPP.Models;

namespace SuperDuperMedAPP.Data.Repositories
{
    public interface IDoctorRepository
    {
        Task AddDoctor(Doctor doctor);
        Task<Doctor?> GetDoctorByUsername(string username);
        Task UpdateDoctor(Doctor doctor);
        Task DeleteDoctor(int id);
        Task<string?> GetHashedPassword(string username);
    }
}