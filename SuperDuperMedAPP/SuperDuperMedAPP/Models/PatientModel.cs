using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Models
{
    public class PatientModel : SuperUserModel
    {

        public int SocialSecurityNumber { get; set; }
        public ICollection<MedicationModel> Medications { get; set; }

    }
}
