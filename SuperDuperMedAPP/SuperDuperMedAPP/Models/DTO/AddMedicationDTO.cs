using System;

namespace SuperDuperMedAPP.Models.DTO
{
    public class AddMedicationDTO
    {
        public int MedicationID { get; set; }
        public string Name { get; set; }
        public string Dose { get; set; }
        public string? DoctorNote { get; set; }
        public int PatientID { get; set; }
        public int MedicineID { get; set; }
    }
}