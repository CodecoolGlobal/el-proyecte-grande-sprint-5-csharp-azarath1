using SuperDuperMedAPP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Data.Services
{
    public interface IMedicationService
    {
        Task AddMedication(Medication medication);
        Task<Medicine?> GetMedicineById(int medId);
        Task DeleteMedication(int medId);
        Task EditMedicationDosage(int medicationId, string newDosage);
        Task EditMedicationNote(int medicationId, string newNote);
        Task<List<Medication>?> GetAllMedicationByPatientId(int patientId, int pageNumber);
        Task<Medication?> GetMedicationById(int medicationId);
    }
}