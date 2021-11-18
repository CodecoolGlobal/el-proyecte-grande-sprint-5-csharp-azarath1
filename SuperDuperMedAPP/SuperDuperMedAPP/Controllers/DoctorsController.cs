﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperDuperMedAPP.Data.Services;
using SuperDuperMedAPP.Models.DTO;
using System.Threading.Tasks;


namespace SuperDuperMedAPP.Controllers
{
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorsServices _services;

        public DoctorsController(IDoctorsServices services)
        {
            _services = services;
        }

        [Authorize(Roles = "doctor")]
        [Route("doctor/{id:int}/details")]
        public async Task<ActionResult> GetLoggedInDoctorDetails([FromRoute] int id)
        {
            var result = await _services.GetDoctorById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [Authorize(Roles = "doctor")]
        [HttpPut]
        [Route("doctor/{id:int}/edit-contacts")]
        public async Task<ActionResult> EditContacts(UserContacts userContact, [FromRoute] int id)
        {
            await _services.UpdateDoctorContacts(userContact, id);
            return Ok();
        }
        [Authorize(Roles = "doctor")]
        [Route("doctor/{id:int}/password")]
        public async Task<ActionResult> EditPassword([FromRoute] int id, string password)
        {
            await _services.EditPassword(id, password);
            return Ok();
        }
    }
}