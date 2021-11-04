﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Models
{
    public class Doctor : User
    {
        public string RegistrationNumber { get; set; }
        public ICollection<Patient>? Patients { get; set; }
    }
}
