namespace SuperDuperMedAPP.Models.DTO
{
    // ReSharper disable once InconsistentNaming
    public class GetPatientsMedicationSingleDTO
    {
        public string? Name { get; set; } = null!;
        public string? Dose { get; set; } = null!;
        public string Date { get; set; } = null!;
        public string? DoctorNote { get; set; }
        // ReSharper disable once InconsistentNaming
        public int medicationID { get; set; }
    }
}