using System;
using System.Collections.Generic;

namespace SuperDuperMedAPP.Models
{

    public class Patient : User
    {
        public String SocialSecurityNumber { get; set; } = null!;

        // ReSharper disable once InconsistentNaming
        public int? DoctorID { get; set; }
        public ICollection<Medication>? Medications { get; set; }





    }
}
