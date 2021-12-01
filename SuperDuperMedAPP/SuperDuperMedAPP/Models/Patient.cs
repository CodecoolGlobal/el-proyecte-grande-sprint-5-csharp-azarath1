using System;
using System.Collections.Generic;

namespace SuperDuperMedAPP.Models
{

    public class Patient : User
    {
        public string? SocialSecurityNumber { get; set; }
        public int? DoctorID { get; set; }
        public ICollection<Medication>? Medications { get; set; }





    }
}
