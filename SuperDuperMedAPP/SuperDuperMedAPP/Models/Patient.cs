using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Models
{

    public class Patient : User
    {
        public String SocialSecurityNumber { get; set; }
        public int? DoctorID { get; set; }
        public ICollection<Medication>? Medications { get; set; }





    }
}
