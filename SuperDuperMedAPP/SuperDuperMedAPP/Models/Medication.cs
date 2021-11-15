using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Models
{
    public class Medication
    {
        public int MedicationID { get; set; }
        public string Name { get; set; }
       public string Dose { get; set; }
       public string? DoctorNote { get; set; }
       public DateTime Date { get; set; }
       public int PatientID { get; set; }
       public Medicine Medicine { get; set; }
    }
}
