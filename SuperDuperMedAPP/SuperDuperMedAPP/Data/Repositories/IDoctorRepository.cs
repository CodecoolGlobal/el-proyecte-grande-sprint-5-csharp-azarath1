using System.Collections.Generic;
using System.Threading.Tasks;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;

namespace SuperDuperMedAPP.Data.Repositories
{
    public interface IDoctorRepository
    {
        Task AddDoctor(Doctor doctor);
        Task<Doctor?> GetDoctorByUsername(string username);
        Task<Doctor?> GetDoctorById(int userid);
        Task<List<Doctor>?> GetAllDoctors();
        Task UpdateDoctor(Doctor doctor);
        Task UpdateDoctorContacts(UserContacts contacts,int id);
        Task DeleteDoctor(int id);
        Task<string?> GetHashedPassword(string username);
        Task EditPassword(int id, string password);
    }
}