using SuperDuperMedAPP.Data.Repositories;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Data.Services
{
    public class DoctorsServices : IDoctorsServices
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IMedicationRepository _medicationRepository;
        private readonly IMedicineRepository _medicineRepository;

        public DoctorsServices(IDoctorRepository doctorRepository, IPatientRepository patientRepository, IMedicationRepository medicationRepository, IMedicineRepository medicineRepository)
        {
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _medicationRepository = medicationRepository;
            _medicineRepository = medicineRepository;
        }

        public async Task<Doctor?> GetDoctorById(int id)
        {
            return await _doctorRepository.GetDoctorById(id);
        }

        public async Task UpdateDoctorContacts(UserContacts contacts, int id)
        {
            await _doctorRepository.UpdateDoctorContacts(contacts, id);
        }

        public async Task DeleteDoctor(int id)
        {
            await _doctorRepository.DeleteDoctor(id);
        }

        public async Task EditPassword(int id, string password)
        {
            await _doctorRepository.EditPassword(id, password);
        }
    }
}