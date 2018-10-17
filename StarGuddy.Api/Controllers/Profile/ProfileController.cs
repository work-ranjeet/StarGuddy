using Microsoft.AspNetCore.Mvc;
using StarGuddy.Api.Constants;
using StarGuddy.Business.Interface.Account;
using StarGuddy.Business.Interface.Profile;
using StarGuddy.Business.Interface.UserJobs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace StarGuddy.Api.Controllers.Profile
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/Profile")]
    public class ProfileController : ControllerBase
    {
        /// <summary>
        /// The account manager
        /// </summary>       
        //private readonly IAccountManager _accountManager;
        private readonly IProfileManager _profileManager;
        private readonly IUserManager _userManager;
        private readonly IJobManager _jobManager;


        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileEditController"/> class.
        /// </summary>
        /// <param name="accountManager">The account manager.</param>
        /// <param name="profileManager">The profile manager.</param>
        public ProfileController(IProfileManager profileManager, IUserManager userManager, IJobManager jobManager)
        {
            // _accountManager = accountManager;
            _profileManager = profileManager;
            _userManager = userManager;
            _jobManager = jobManager;
        }

        [HttpGet]
        [Route("{profileUrl}")]
        public async Task<IActionResult> GetProfileByUrl(string profileUrl)
        {
            if (string.IsNullOrWhiteSpace(profileUrl))
            {
                return BadRequest(HttpStatusText.InvalidRequest);
            }

            var profileResult = await _profileManager.GetUserProfile(profileUrl);
            if (profileResult == null)
            {
                return NotFound(profileUrl);
            }

            return Ok(profileResult);
        }

        [HttpGet]
        [Route("{profileUrl}/Header")]
        public async Task<IActionResult> GetProfileHeader(string profileUrl)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(profileUrl))
                {
                    return BadRequest();
                }

                var result = await _profileManager.GetProfileHeaderByProfileUrl(profileUrl);
                if (result.IsNull())
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        [HttpGet]
        [Route("{profileUrl}/PhysicalApperance")]
        public async Task<IActionResult> GetPhysicalApperance(string profileUrl)
        {
            if (string.IsNullOrWhiteSpace(profileUrl))
            {
                return BadRequest(HttpStatusText.InvalidRequest);
            }

            var result = await _profileManager.GetPhysicalAppreance(profileUrl);

            if (result.IsNull())
            {
                return NotFound();
            }

            return Ok(result);

        }

        [HttpGet]
        [Route("{profileUrl}/Credit")]
        public async Task<IActionResult> GetUserCredits(string profileUrl)
        {
            if (string.IsNullOrWhiteSpace(profileUrl))
            {
                return BadRequest(HttpStatusText.InvalidRequest);
            }

            var creditResult = await _profileManager.GetUserCredits(profileUrl);

            if (!creditResult.IsNull() && creditResult.Any())
            {
                return Ok(creditResult);
            }

            if (!creditResult.IsNull() && !creditResult.Any())
            {
                return NoContent();
            }

            return NotFound(creditResult);
        }

        [HttpGet]
        [Route("{profileUrl}/Dancing")]
        public async Task<IActionResult> GetUserDancing(string profileUrl)
        {
            if (string.IsNullOrWhiteSpace(profileUrl))
            {
                return BadRequest(HttpStatusText.InvalidRequest);
            }

            var dancingResult = await _profileManager.GetUserDancingAsync(profileUrl);

            if (dancingResult.IsNull())
            {
                return NotFound(dancingResult);
            }

            return Ok(dancingResult);
        }

        [HttpGet]
        [Route("{profileUrl}/Acting")]
        public async Task<IActionResult> GetUserActingDetails(string profileUrl)
        {
            if (string.IsNullOrWhiteSpace(profileUrl))
            {
                return BadRequest(HttpStatusText.InvalidRequest);
            }

            var actingResult = await _profileManager.GetUserActingDetailAsync(profileUrl);

            if (actingResult.IsNull())
            {
                return NotFound(actingResult);
            }

            return Ok(actingResult);
        }

        [HttpGet]
        [Route("{profileUrl}/Modeling")]
        public async Task<IActionResult> GetUserModelingDetails(string profileUrl)
        {
            if (string.IsNullOrWhiteSpace(profileUrl))
            {
                return BadRequest(HttpStatusText.InvalidRequest);
            }

            var actingResult = await _profileManager.GetUserModelingDetailAsync(profileUrl);

            if (actingResult.IsNull())
            {
                return NotFound(actingResult);
            }

            return Ok(actingResult);
        }

    }
}
