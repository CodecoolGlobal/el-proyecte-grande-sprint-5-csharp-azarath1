using System.Collections.Generic;
using System.Threading.Tasks;
using SuperDuperMedAPP.Models;

namespace SuperDuperMedAPP.Data.Repositories
{
    public interface IMedicationRepository
    {
        Task AddMedication(Medication medication);
        Task<List<Medication>?> GetAllMedication(int patientId);
        Task<Medication?> GetMedicationById(int patientId);
        Task UpdateMedication(Medication medication);
        Task DeleteMedication(int medicationId);
    }
}