using System;

namespace SuperDuperMedAPP.Models
{
    public class Medication
    {
        // ReSharper disable once InconsistentNaming
        public int MedicationID { get; set; }
        public string? Name { get; set; }
        public string? Dose { get; set; }
        public string? DoctorNote { get; set; }
        public DateTime Date { get; set; }
        // ReSharper disable once InconsistentNaming
        public int PatientID { get; set; }
        public Medicine Medicine { get; set; } = null!;
    }
}
