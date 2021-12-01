using SuperDuperMedAPP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Data.Repositories
{
    public interface IMedicationRepository
    {
        Task AddMedication(Medication medication);
        Task<List<Medication>?> GetMedicationByPageNumber(int patientId, int pageNumber);
        Task<Medication?> GetMedicationById(int medicationId);
        Task DeleteMedication(int medicationId);
        Task EditMedicationDosage(int medicationId, string? newDosage);
        Task EditMedicationNote(int medicationId, string newNote);
    }
}