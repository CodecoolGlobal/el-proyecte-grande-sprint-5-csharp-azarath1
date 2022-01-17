using SuperDuperMedAPP.Data.Repositories;
using SuperDuperMedAPP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Data.Services
{
    public class MedicationServices : IMedicationService
    {
        private IMedicationRepository _medicationRepository;
        private IMedicineRepository _medicineRepository;

        public MedicationServices(IMedicationRepository medicationRepository, IMedicineRepository medicineRepository)
        {
            _medicationRepository = medicationRepository;
            _medicineRepository = medicineRepository;
        }

        public async Task AddMedication(Medication medication)
        {
            await _medicationRepository.AddMedication(medication);
        }

        public async Task<Medicine?> GetMedicineById(int medId)
        {
            return await _medicineRepository.GetMedicineById(medId);
        }

        public async Task DeleteMedication(int medId)
        {
            await _medicationRepository.DeleteMedication(medId);
        }

        public async Task EditMedicationDosage(int medicationId, string? newDosage)
        {
            await _medicationRepository.EditMedicationDosage(medicationId, newDosage);
        }

        public async Task EditMedicationNote(int medicationId, string newNote)
        {
            await _medicationRepository.EditMedicationNote(medicationId, newNote);
        }

        public async Task<List<Medication>?> GetAllMedicationByPatientId(int patientId, int pageNumber)
        {
            return await _medicationRepository.GetMedicationByPageNumber(patientId, pageNumber);
        }
        public async Task<Medication?> GetMedicationById(int medicationId)
        {
            return await _medicationRepository.GetMedicationById(medicationId);
        }
    }
}