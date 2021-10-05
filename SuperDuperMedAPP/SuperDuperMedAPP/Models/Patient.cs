using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Models
{
    public class Patient : SuperUserModel
    {

        public int SocialSecurityNumber { get; set; }
        public ICollection<Medication> Medications { get; set; }

    }
}
