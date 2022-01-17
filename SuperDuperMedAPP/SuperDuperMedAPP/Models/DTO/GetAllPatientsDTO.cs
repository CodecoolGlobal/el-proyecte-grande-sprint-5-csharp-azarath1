namespace SuperDuperMedAPP.Models.DTO
{
    public class GetAllPatientsDTO
    {
        // ReSharper disable once InconsistentNaming
        public int ID { get; set; }
        public string? Name { get; set; } = null!;
        public string DateOfBirth { get; set; } = null!;
        public string SocialSecurityNumber { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        // ReSharper disable once InconsistentNaming
        public int? DoctorID { get; set; }
    }
}