using System.Collections.Generic;
using System.Threading.Tasks;
using SuperDuperMedAPP.Data.Repositories;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;

namespace SuperDuperMedAPP.Data.Services
{
    public class PatientServices: IPatientServices
    {
        private readonly IPatientRepository _repository;

        public PatientServices(IPatientRepository repository)
        {
            _repository = repository;
        }

        public async Task<Patient?> GetPatientById(int patientId)
        {
            return await _repository.GetPatientById(patientId);
        }

        public async Task EditDoctorId(int patientId, int newDoctorId)
        {
            await _repository.EditDoctorId(patientId, newDoctorId);
        }

        public async Task<List<Patient>?> GetAllPatients()
        {
            return await _repository.GetAllPatients();
        }

        public async Task<List<Patient>?> GetAllPatientsByPageNumber(int pageNumber)
        {
            return await _repository.GetAllPatientsByPageNumber(pageNumber);
        }

        public async Task<List<Patient>?> GetDoctorsPatients(int doctorId, int pageNumber)
        {
            return await _repository.GetPatientsByDoctorId(doctorId, pageNumber);
        }

        public async Task UpdatePatientsContacts(UserContacts contacts, int id)
        {
            await _repository.UpdatePatientContacts(contacts, id);
        }

        public async Task EditPassword(int id, string password)
        {
            await _repository.EditPassword(id, password);
        }
    }
}