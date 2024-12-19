using CodigoDelSurApp.Application.Interfaces;
using CodigoDelSurApp.Domain.Entities;
using CodigoDelSurApp.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodigoDelSurApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PreferenceController : Controller
    {
        private readonly IPreferenceService _preferenceService;

        public PreferenceController(IPreferenceService preferenceService)
        {
            _preferenceService = preferenceService;
        }

        /// <summary>
        /// Get All Preference by User
        /// </summary>
        /// <returns>All Preference By User</returns>
        /// <respose code="200">The Books was retrieved </respose>
        /// <respose code="500">Error Ocurred retrieving the information </respose>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<UserPreference>>> GetAllByUserAsync()
        {
            try
            {
                var preferences = await _preferenceService.GetAllPreferenceByUserAsync();

                return Ok(preferences);
            }
            catch (Exception ex)
            {
                //TODO: Log Error
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Update a reference por the User
        /// </summary>
        /// <returns>Update success status</returns>
        /// <respose code="200">The Preference was updated </respose>
        /// <respose code="400">Preference not found </respose>
        /// <respose code="500">Error Ocurred retrieving the information </respose>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<UserPreference>>> UpdatePreferenceAsync([FromBody] UserPreferenceDto preferenceDto)
        {
            try
            {
                var preference = new UserPreference()
                {
                    UserId = Guid.Empty,
                    PreferenceKey = preferenceDto.PreferenceKey,
                    PreferenceValue = preferenceDto.PreferenceValue
                };

                bool preferenceChaged = await _preferenceService.UpdatePreferenceAsync(preference);

                if (preferenceChaged)
                {
                    return Ok();
                }
                else { 
                    return BadRequest(new { Description = "preference not found" });
                }
            }
            catch (Exception ex)
            {
                //TODO: Log Error
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create a reference por the User
        /// </summary>
        /// <returns>Preference was created</returns>
        /// <respose code="200">The Preference was updated </respose>
        /// <respose code="400">Preference already Exists </respose>
        /// <respose code="500">Error Ocurred retrieving the information </respose>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<UserPreference>>> CreatePreferenceAsync([FromBody] UserPreferenceDto preferenceDto)
        {
            try
            {
                var preference = new UserPreference()
                {
                    UserId = Guid.Empty,
                    PreferenceKey = preferenceDto.PreferenceKey,
                    PreferenceValue = preferenceDto.PreferenceValue
                };

                bool preferenceCreated = await _preferenceService.CreatePreferenceAsync(preference);

                if (preferenceCreated)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(new { Description = "preference already created" });
                }
            }
            catch (Exception ex)
            {
                //TODO: Log Error
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Delete a reference por the User
        /// </summary>
        /// <returns></returns>
        /// <respose code="200">The Preference was updated </respose>
        /// <respose code="400">Preference already Exists </respose>
        /// <respose code="500">Error Ocurred retrieving the information </respose>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<UserPreference>>> DeletePreferenceAsync([FromQuery]string key)
        {
            try
            {
                bool preferenceDeleted = await _preferenceService.DeletePreferenceAsync(key);

                if (preferenceDeleted)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(new { Description = "preference not found" });
                }
            }
            catch (Exception ex)
            {
                //TODO: Log Error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
