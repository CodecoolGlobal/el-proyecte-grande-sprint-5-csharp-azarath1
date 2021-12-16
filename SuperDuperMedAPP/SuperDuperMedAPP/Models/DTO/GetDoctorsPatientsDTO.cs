namespace SuperDuperMedAPP.Models.DTO
{
    // ReSharper disable once InconsistentNaming
    public class GetDoctorsPatientsDTO
    {
        public string? Name { get; set; } = null!;
        public string DateOfBirth { get; set; } = null!;
        public string SocialSecurityNumber { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int ID { get; set; }
    }
}