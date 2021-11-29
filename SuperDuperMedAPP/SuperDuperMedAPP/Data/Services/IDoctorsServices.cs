using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Data.Services
{
    public interface IDoctorsServices
    {
        Task<Doctor?> GetDoctorById(int id);
        Task UpdateDoctorContacts(UserContacts contacts, int id);
        Task DeleteDoctor(int id);
        Task EditPassword(int id, string password);
    }
}