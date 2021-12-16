using System;

namespace SuperDuperMedAPP.Models.DTO
{
    public class DoctorDetailDTO
    {
        public string? Name { get; set; } = null!;
        public string DateOfBirth { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string RegistrationNumber { get; set; } = null!;
    }
}