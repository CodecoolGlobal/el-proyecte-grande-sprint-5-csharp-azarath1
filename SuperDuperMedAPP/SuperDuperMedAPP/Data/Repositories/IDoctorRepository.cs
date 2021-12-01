using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Data.Repositories
{
    public interface IDoctorRepository
    {
        Task AddDoctor(Doctor doctor);
        Task<Doctor?> GetDoctorByUsername(string? username);
        Task<Doctor?> GetDoctorById(int userid);
        Task<bool> RegNumberInUse(string? regNumber);
        Task<List<Doctor>?> GetAllDoctors();
        //todo
        Task UpdateDoctor(Doctor doctor);
        Task UpdateDoctorContacts(UserContacts contacts, int id);
        Task DeleteDoctor(int id);
        //todo
        Task<string?> GetHashedPassword(string username);
        Task EditPassword(int id, string password);
    }
}