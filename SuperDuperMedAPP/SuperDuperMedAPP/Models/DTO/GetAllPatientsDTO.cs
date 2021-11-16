namespace SuperDuperMedAPP.Models.DTO
{
    public class GetAllPatientsDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? DoctorID { get; set; }
    }
}