namespace SuperDuperMedAPP.Models.DTO
{
    // ReSharper disable once InconsistentNaming
    public class AddMedicationDTO
    {
        // ReSharper disable once InconsistentNaming
        public int MedicationID { get; set; }
        public string? Name { get; set; }
        public string? Dose { get; set; }
        public string? DoctorNote { get; set; }
        // ReSharper disable once InconsistentNaming
        public int PatientID { get; set; }
        // ReSharper disable once InconsistentNaming
        public int MedicineID { get; set; }
    }
}