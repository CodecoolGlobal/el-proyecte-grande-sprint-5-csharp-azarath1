using System;
using System.Collections.Generic;

namespace SuperDuperMedAPP.Models.DTO
{
    public class PatientDetailDTO
    {
        public string? Name { get; set; }
        public string DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? SocialSecurityNumber { get; set; }
    }
}