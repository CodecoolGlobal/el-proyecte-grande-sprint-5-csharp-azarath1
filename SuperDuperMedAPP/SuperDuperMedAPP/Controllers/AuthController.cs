using Microsoft.AspNetCore.Mvc;
using SuperDuperMedAPP.Data.Repositories;
using SuperDuperMedAPP.Data.Services;
using SuperDuperMedAPP.Infrastructure;
using SuperDuperMedAPP.Models;
using SuperDuperMedAPP.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDuperMedAPP.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IRegistrationNumberRepository _registrationNumberRepository;
        private readonly ISocialSecurityNumberRepository _securityNumberRepository;

        public AuthController(IAuthService authService, IPatientRepository patientRepository,
            IDoctorRepository doctorRepository, IRegistrationNumberRepository registrationNumberRepository,
            ISocialSecurityNumberRepository securityNumberRepository)
        {
            _authService = authService;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _registrationNumberRepository = registrationNumberRepository;
            _securityNumberRepository = securityNumberRepository;
        }

        [HttpPost]
        [Route("/login")]
        public async Task<ActionResult<AuthData>> Login([FromBody] LoginData model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await GetUserToAuth(model.Username);

            if (user == null)
            {
                return BadRequest(new {error = "invalid username/password"});
            }

            var passwordValid = _authService.VerifyPassword(model.Password, user.HashPassword);
            if (!passwordValid)
            {
                return BadRequest(new {error = "invalid username/password"});
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

            var emailUniq = await IsEmailUniq(model.Email, model.Role);
            if (!emailUniq) return BadRequest(new {error = "user with this email already exists"});

            var usernameUniq = await IsUsernameUniq(model.Username, model.Role);
            if (!usernameUniq) return BadRequest(new {error = "user with this email already exists"});

            var socNumberValid = await _securityNumberRepository.SocNumberValid(model.SocialSecurityNumber);
            var socNumberInUse = await _patientRepository.SocNumberInUse(model.SocialSecurityNumber);
            if (!socNumberValid || (socNumberValid && socNumberInUse))
                return BadRequest(new {error = "Social Security number invalid, or already in use!"});

            var patient = model.HashPatientPassword();
            await _patientRepository.AddPatient(patient);

            return _authService.GetAuthData(patient.ID, patient.Role);
        }

        [HttpPost]
        [Route("register/doctor")]
        public async Task<ActionResult<AuthData>> RegisterDoctor([FromBody] Doctor model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);


            var emailUniq = await IsEmailUniq(model.Email, model.Role);
            if (!emailUniq) return BadRequest(new {error = "user with this email already exists"});

            var usernameUniq = await IsUsernameUniq(model.Username, model.Role);
            if (!usernameUniq) return BadRequest(new {error = "user with this email already exists"});

            var regNumberValid = await _registrationNumberRepository.RegNumberValid(model.RegistrationNumber);
            var isRegNumberInUse = await _doctorRepository.RegNumberInUse(model.RegistrationNumber);
            if (!regNumberValid || (regNumberValid && isRegNumberInUse))
                return BadRequest(new {error = "Registration number invalid, or already in use!"});

            var doctor = model.HashDoctorPassword();
            await _doctorRepository.AddDoctor(doctor);

            return _authService.GetAuthData(doctor.ID, doctor.Role);
        }

        // todo if more roles are added, use switch!
        private async Task<bool> IsUsernameUniq(string modelUsername, string role)
        {
            return role.Equals("doctor")
                ? await _doctorRepository.IsUsernameUnique(modelUsername)
                : await _patientRepository.IsUsernameUnique(modelUsername);
        }

        private async Task<bool> IsEmailUniq(string modelEmail, string role)
        {
            return role.Equals("doctor")
                ? await _doctorRepository.IsEmailUnique(modelEmail)
                : await _patientRepository.IsEmailUnique(modelEmail);
        }
    }
}