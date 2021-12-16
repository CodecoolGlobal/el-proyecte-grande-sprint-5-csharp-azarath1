using System.Collections.Generic;

namespace SuperDuperMedAPP.Models
{
    public class Doctor : User
    {
        public string RegistrationNumber { get; set; } = null!;
        public ICollection<Patient>? Patients { get; set; }
    }
}
