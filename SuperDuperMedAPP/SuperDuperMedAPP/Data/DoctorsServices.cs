using System.Collections.Generic;
using System.Threading.Tasks;
using SuperDuperMedAPP.Data.Repositories;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;

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

        public async Task AddMedication(Medication medication)
        {
            await _medicationRepository.AddMedication(medication);
        }

        public async Task<Patient?> GetPatientById(int PatientId)
        {
            return await _patientRepository.GetPatientById(PatientId);
        }

        public async Task<Doctor?> GetDoctorByUsername(string username)
        {
            return await _doctorRepository.GetDoctorByUsername(username);
        }

        public async Task<Medicine?> GetMedicineById(int medId)
        {
           return await _medicineRepository.GetMedicineById(medId);
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

        public async Task DeleteMedication(int medId)
        {
            await _medicationRepository.DeleteMedication(medId);
        }

        public async Task<string?> GetHashedPassword(string username)
        {
            return await _doctorRepository.GetHashedPassword(username);
        }

        public async Task EditPassword(int id, string password)
        {
            await _doctorRepository.EditPassword(id, password);
        }

        public async Task EditDoctorId(int id, int newDoctorId)
        {
            await _patientRepository.EditDoctorId(id, newDoctorId);
        }

        public async Task EditMedicationDosage(int medicationId, string newDosage)
        {
            await _medicationRepository.EditMedicationDosage(medicationId, newDosage);
        }

        public async Task EditMedicationNote(int medicationId, string newNote)
        {
            await _medicationRepository.EditMedicationNote(medicationId, newNote);
        }

        public async Task<List<Medicine>?> GetAllMedicine()
        {
            return await _medicineRepository.GetAllMedicine();
        }
        public async Task<List<Patient>?> GetAllPatients()
        {
            return await _patientRepository.GetAllPatients();
        }

        public async Task<List<Patient>?> GetDoctorsPatients(int doctorId)
        {
            return await _patientRepository.GetPatientsByDoctorId(doctorId);
        }

        public async Task<List<Medication>?> GetAllMedicationByPatientId(int patientId)
        {
            return await _medicationRepository.GetAllMedication(patientId);
        }
        public async Task<Medication?> GetMedicationById(int medicationId)
        {
            return await _medicationRepository.GetMedicationById(medicationId);
        }


    }
}