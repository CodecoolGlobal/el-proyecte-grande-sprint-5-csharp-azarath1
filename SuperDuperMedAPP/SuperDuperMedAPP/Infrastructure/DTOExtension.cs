using System;
using System.Collections.Generic;
using System.Linq;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;

namespace SuperDuperMedAPP.Infrastructure
{
    public static class DTOExtension
    {
        public static Medication ToMedication(this AddMedicationDTO dto, Medicine medicine)
        {
            return new Medication
            {
                Name = dto.Name,
                Dose = dto.Dose,
                DoctorNote = dto.DoctorNote,
                Date = new DateTime().ToLocalTime(),
                PatientID = dto.PatientID,
                Medicine = medicine
            };
        }

        public static GetPatientsMedicationSingleDTO ToGetPatientsMedicationSingleDto(this Medication medication)
        {
            return new GetPatientsMedicationSingleDTO
            {
                Name = medication.Name,
                Date = medication.Date.ToShortDateString(),
                Dose = medication.Dose,
                DoctorNote = medication.DoctorNote,
                medicationID = medication.MedicationID
            };
        }

        public static List<GetPatientsMedicationAllDTO>? ToGetPatientsMedicationAllDTO(this List<Medication>? medications)
        {
            return medications?.Select(x => new GetPatientsMedicationAllDTO
            {
                Name = x.Name,
                Date = x.Date.ToShortDateString(),
                DoctorNote = x.DoctorNote,
                Dose = x.Dose,
                medicationID = x.MedicationID
            }).ToList();
        }

        public static List<GetDoctorsPatientsDTO> ToGetDoctorsPatientsDTOs(this List<Patient>? patients)
        {
            return (patients ?? new List<Patient>())
                .Select(x => new GetDoctorsPatientsDTO()
                {
                    Name = x.Name,
                    DateOfBirth = x.DateOfBirth.ToShortDateString(),
                    SocialSecurityNumber = x.SocialSecurityNumber,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    ID = x.ID
                }).ToList();
        }
        public static List<GetAllPatientsDTO> ToGetAllPatientsDTOs(this List<Patient>? patients)
        {
            return (patients ?? new List<Patient>())
                .Select(x => new GetAllPatientsDTO()
                {
                    ID = x.ID,
                    Name = x.Name,
                    DateOfBirth = x.DateOfBirth.ToShortDateString(),
                    SocialSecurityNumber = x.SocialSecurityNumber,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    DoctorID = x.DoctorID
                }).ToList();
        }
    }
}