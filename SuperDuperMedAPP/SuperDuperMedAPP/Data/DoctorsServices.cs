using System.Collections.Generic;
using System.Threading.Tasks;
using SuperDuperMedAPP.Data.Repositories;
using SuperDuperMedAPP.Models;

namespace SuperDuperMedAPP.Data
{
    public class DoctorsServices : IDoctorsServices
    {
        private IDoctorRepository _doctorRepository;
        private IPatientRepository _patientRepository;
        private IMedicationRepository _medicationRepository;
        private IMedicineRepository _medicineRepository;

        public DoctorsServices(IDoctorRepository doctorRepository, IPatientRepository patientRepository, IMedicationRepository medicationRepository, IMedicineRepository medicineRepository)
        {
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _medicationRepository = medicationRepository;
            _medicineRepository = medicineRepository;
        }

        public async Task AddDoctor(Doctor doctor)
        {
            await _doctorRepository.AddDoctor(doctor);
        }

        public async Task<Doctor?> GetDoctorByUsername(string username)
        {
            return await _doctorRepository.GetDoctorByUsername(username);
        }

        public async Task<Doctor?> GetDoctorById(int id)
        {
            return await _doctorRepository.GetDoctorById(id);
        }

        public async Task<List<Doctor>?> GetAllDoctors()
        {
            return await _doctorRepository.GetAllDoctors();
        }

        public async Task UpdateDoctor(Doctor doctor)
        {
            await _doctorRepository.UpdateDoctor(doctor);
        }

        public async Task UpdateDoctorContacts(UserContacts contacts, int id)
        {
            await _doctorRepository.UpdateDoctorContacts(contacts, id);
        }

        public async Task DeleteDoctor(int id)
        {
            await _doctorRepository.DeleteDoctor(id);
        }

        public async Task<string?> GetHashedPassword(string username)
        {
            return await _doctorRepository.GetHashedPassword(username);
        }

        public async Task EditPassword(int id, string password)
        {
            await _doctorRepository.EditPassword(id, password);
        }

        public async Task<List<Medicine>?> GetAllMedicine()
        {
            return await _medicineRepository.GetAllMedicine();
        }
        public async Task<List<Patient>?> GetAllPatients()
        {
            return await _patientRepository.GetAllPatients();
        }
        public async Task<List<Medication>?> GetAllMedicationByPatientId(int patientId)
        {
            return await _medicationRepository.GetAllMedication(patientId);
        }


    }
}