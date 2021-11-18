﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperDuperMedAPP.Data.Repositories;
using SuperDuperMedAPP.Data.Services;
using SuperDuperMedAPP.Infrastructure;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;

namespace SuperDuperMedAPP.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private IPatientRepository _patientRepository;
        private IDoctorRepository _doctorRepository;

        public AuthController(IAuthService authService, IPatientRepository patientRepository,
            IDoctorRepository doctorRepository)
        {
            _authService = authService;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }

        [HttpPost]
        [Route("/login")]
        public async Task<ActionResult<AuthData>> Login([FromBody] LoginData model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await GetUserToAuth(model.Username);

            if (user == null)
            {
                return BadRequest(new {email = "no user with this email"});
            }

            var passwordValid = _authService.VerifyPassword(model.Password, user.HashPassword);
            if (!passwordValid)
            {
                return BadRequest(new {password = "invalid password"});
            }

            return _authService.GetAuthData(user.Id, user.Role);
        }

        private async Task<GetUserToAuthDTO?> GetUserToAuth(string username)
        {
            var patient = await _patientRepository.GetPatientByUsername(username);
            var doctor = await _doctorRepository.GetDoctorByUsername(username);
            return patient?.TGetUserToAuthDto() ?? doctor?.TGetUserToAuthDto();
        }


        [HttpPost]
        [Route("register/patient")]
        public async Task<ActionResult<AuthData>> RegisterPatient([FromBody] Patient model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var users = await _patientRepository.GetAllPatients();

            var emailUniq = users != null && IsEmailUniq(model.Email, users.Select(x => x.Email).ToList());
            if (!emailUniq) return BadRequest(new {email = "user with this email already exists"});

            var usernameUniq = users != null && IsUsernameUniq(model.Username, users.Select(x => x.Username).ToList());
            if (!usernameUniq) return BadRequest(new {username = "user with this email already exists"});

            await _patientRepository.AddPatient(model);

            return _authService.GetAuthData(model.ID, model.Role);
        }

        [HttpPost]
        [Route("register/doctor")]
        public async Task<ActionResult<AuthData>> RegisterDoctor([FromBody] Doctor model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var users = await _doctorRepository.GetAllDoctors();

            var emailUniq = users != null && IsEmailUniq(model.Email, users.Select(x => x.Email).ToList());
            if (!emailUniq) return BadRequest(new {email = "user with this email already exists"});

            var usernameUniq = users != null && IsUsernameUniq(model.Username, users.Select(x => x.Username).ToList());
            if (!usernameUniq) return BadRequest(new {username = "user with this email already exists"});

            await _doctorRepository.AddDoctor(model);

            return _authService.GetAuthData(model.ID, model.Role);
        }

        private bool IsUsernameUniq(string modelUsername, List<string> usernames)
        {
            return !usernames.Contains(modelUsername);
        }

        private bool IsEmailUniq(string? modelEmail, List<string?> emails)
        {
            return !emails.Contains(modelEmail);
        }
    }
}