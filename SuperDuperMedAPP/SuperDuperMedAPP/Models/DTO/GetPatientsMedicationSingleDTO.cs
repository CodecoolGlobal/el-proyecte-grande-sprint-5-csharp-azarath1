namespace SuperDuperMedAPP.Models.DTO
{
    public class GetPatientsMedicationSingleDTO
    {
        public string Name { get; set; }
        public string Dose { get; set; }
        public string Date { get; set; }
        public string? DoctorNote { get; set; }
        public int medicationID { get; set; }
    }
}