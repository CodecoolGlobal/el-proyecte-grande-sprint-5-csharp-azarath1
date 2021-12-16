using System;
using System.Collections.Generic;

namespace SuperDuperMedAPP.Models.DTO
{
    // ReSharper disable once InconsistentNaming
    public class PatientDetailDTO
    {
        public string? Name { get; set; } = null!;
        public string DateOfBirth { get; set; } = null!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string SocialSecurityNumber { get; set; } = null!;
    }
}