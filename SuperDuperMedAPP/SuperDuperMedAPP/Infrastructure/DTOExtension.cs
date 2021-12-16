using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using CryptoHelper;

namespace SuperDuperMedAPP.Infrastructure
{
    // ReSharper disable once InconsistentNaming
    public static class DTOExtension
    {
        public static Medication ToMedication(this AddMedicationDTO dto, Medicine medicine)
        {
            return new Medication
            {
                Name = dto.Name,
                Dose = dto.Dose,
                DoctorNote = dto.DoctorNote,
                Date = DateTime.Now.ToLocalTime(),
                PatientID = dto.PatientID,
                Medicine = medicine
            };
        }

        // ReSharper disable once InconsistentNaming
        public static GetPatientsMedicationSingleDTO ToGetPatientsMedicationSingleDTO(this Medication medication)
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

        // ReSharper disable once InconsistentNaming
        public static List<GetPatientsMedicationAllDTO>? ToGetPatientsMedicationAllDTO(
            this List<Medication>? medications)
        {
            return medications?.Select(x => new GetPatientsMedicationAllDTO
            {
                Name = x.Name,
                Medicine = x.Medicine,
                Date = x.Date.ToLocalTime().ToShortDateString(),
                DoctorNote = x.DoctorNote,
                Dose = x.Dose,
                medicationID = x.MedicationID
            }).ToList();
        }

        // ReSharper disable once InconsistentNaming
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

        // ReSharper disable once InconsistentNaming
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

        // ReSharper disable once InconsistentNaming
        public static GetUserToAuthDTO ToGetUserToAuthDTO(this User user)
        {
            return new GetUserToAuthDTO
            {
                Id = user.ID,
                HashPassword = user.HashPassword,
                Role = user.Role
            };
        }

        public static Doctor HashDoctorPassword(this Doctor unhashedDoctor)
        {
            return new Doctor
            {
                Name = unhashedDoctor.Name,
                DateOfBirth = unhashedDoctor.DateOfBirth,
                Email = unhashedDoctor.Email,
                PhoneNumber = unhashedDoctor.PhoneNumber,
                Username = unhashedDoctor.Username,
                HashPassword = Crypto.HashPassword(unhashedDoctor.HashPassword),
                Role = unhashedDoctor.Role,
                RegistrationNumber = unhashedDoctor.RegistrationNumber
            };
        }

        public static Patient HashPatientPassword(this Patient unhashedPatient)
        {
            return new Patient
            {
                Name = unhashedPatient.Name,
                DateOfBirth = unhashedPatient.DateOfBirth,
                Email = unhashedPatient.Email,
                PhoneNumber = unhashedPatient.PhoneNumber,
                Username = unhashedPatient.Username,
                HashPassword = Crypto.HashPassword(unhashedPatient.HashPassword),
                Role = unhashedPatient.Role,
                SocialSecurityNumber = unhashedPatient.SocialSecurityNumber
            };
        }

        // ReSharper disable once InconsistentNaming
        public static PatientDetailDTO ToPatientDetailDTO(this Patient patient)
        {
            return new PatientDetailDTO
            {
                Name = patient.Name,
                DateOfBirth = patient.DateOfBirth.ToLocalTime().ToShortDateString(),
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
                SocialSecurityNumber = patient.SocialSecurityNumber
            };
        }
        // ReSharper disable once InconsistentNaming
        public static DoctorDetailDTO ToDoctorDetailDTO(this Doctor doctor)
        {
            return new DoctorDetailDTO
            {
                Name = doctor.Name,
                DateOfBirth = doctor.DateOfBirth.ToLocalTime().ToShortDateString(),
                Email = doctor.Email,
                PhoneNumber = doctor.PhoneNumber,
                 RegistrationNumber= doctor.RegistrationNumber
            };
        }
    }
}