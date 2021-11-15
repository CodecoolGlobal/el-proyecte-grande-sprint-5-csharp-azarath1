using System.Collections.Generic;
using System.Threading.Tasks;
using SuperDuperMedAPP.Models;

namespace SuperDuperMedAPP.Data.Repositories
{
    public interface IMedicationRepository
    {
        Task AddMedication(Medication medication);
        Task<List<Medication>?> GetAllMedication(int patientId);
        Task<Medication?> GetMedicationById(int medicationId);
        Task UpdateMedication(Medication medication);
        Task DeleteMedication(int medicationId);
        Task EditMedicationDosage(int medicationId, string newDosage);
        Task EditMedicationNote(int medicationId, string newNote);
    }
}