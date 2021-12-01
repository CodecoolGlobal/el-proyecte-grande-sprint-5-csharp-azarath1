namespace SuperDuperMedAPP.Models.DTO
{
    public class GetPatientsMedicationAllDTO
    {
        public string? Name { get; set; }
        public string? Dose { get; set; }
        public string? Date { get; set; }
        public string? DoctorNote { get; set; }
        public int MedicationID { get; set; }
        public Medicine? Medicine { get; set; }
    }
}