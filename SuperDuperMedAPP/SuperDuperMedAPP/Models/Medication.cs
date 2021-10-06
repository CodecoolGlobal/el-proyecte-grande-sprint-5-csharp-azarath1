using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Models
{
    public class Medication
    {
        public int MedicationID { get; set; }
        public string Name { get => Name; set => Name = Medicine.Name; }
       public int Doses { get; set; }
       public string DoctorNotes { get; set; }
       public DateTime Date { get; set; }
       public int MedicineID { get; set; }
       public int PatientID { get; set; }
       public Patient Patient { get; set; }
       public Medicine Medicine { get; set; }    
    }
}
