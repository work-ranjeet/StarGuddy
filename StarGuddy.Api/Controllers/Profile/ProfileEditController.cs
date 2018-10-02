using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarGuddy.Api.Constants;
using StarGuddy.Api.Models.Dto;
using StarGuddy.Api.Models.Interface.Profile;
using StarGuddy.Api.Models.Profile;
using StarGuddy.Api.Models.UserJobs;
using StarGuddy.Business.Interface.Account;
using StarGuddy.Business.Interface.Profile;
using StarGuddy.Business.Interface.UserJobs;
using StarGuddy.Core.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StarGuddy.Api.Controllers.Profile
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Profile/Operations")]
    public class ProfileEditController : BaseApiController
    {
        /// <summary>
        /// The account manager
        /// </summary>
        private readonly IUserManager _userManager;
        private readonly IAccountManager _accountManager;
        private readonly IProfileEditManager _profileEditManager;
        private readonly IJobManager _jobManager;
        //private read only IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileEditController"/> class.
        /// </summary>
        /// <param name="accountManager">The account manager.</param>
        /// <param name="profileEditManager">The profile manager.</param>
        public ProfileEditController(IUserManager userManager, IProfileEditManager profileEditManager, IJobManager jobManager, IAccountManager accountManager)
        {
            _userManager = userManager;
            _accountManager = accountManager;
            _profileEditManager = profileEditManager;
            _jobManager = jobManager;
        }

        #region Physical appearance
        [HttpPost]
        [Route("SavePhysicalApperance")]
        public async Task<IActionResult> SavePhysicalApperance([FromBody]PhysicalAppearanceModal physicalAppearance)
        {
            if (physicalAppearance.IsNull())
            {
                return BadRequest(HttpStatusText.InvalidRequest);
            }

            physicalAppearance.UserId = UserContext.Current.UserId;
            return Ok(await _profileEditManager.PerformSave(physicalAppearance));
        }


        [HttpGet]
        [Route("PhysicalApperance")]
        public async Task<IActionResult> GetPhysicalApperance()
        {
            var result = await _profileEditManager.GetPhysicalAppreance();

            if (result.IsNull())
            {
                return NotFound();
            }

            return Ok(result);

        }
        #endregion

        #region Credits
        [HttpGet]
        [Route("Credit")]
        public async Task<IActionResult> GetUserCredits()
        {
            var creditResult = await _profileEditManager.GetUserCredits();

            if (!creditResult.IsNull() && creditResult.Any())
            {
                return Ok(creditResult);
            }

            return StatusCode(StatusCodes.Status204NoContent, new List<IUserCreditModel>());
        }

        [HttpPost]
        [Route("Credit")]
        public async Task<IActionResult> SaveUserCredits([FromBody]List<UserCreditModel> credits)
        {
            if (credits.IsNull())
            {
                return BadRequest(HttpStatusText.InvalidRequest);
            }

            var isSuccess = await _profileEditManager.SaveUserCredits(credits);
            if (isSuccess)
            {
                return Ok(isSuccess);
            }

            return StatusCode(StatusCodes.Status304NotModified, this);
        }

        [HttpDelete]
        [Route("Credit")]
        public async Task<IActionResult> DeleteUserCredits(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest(HttpStatusText.InvalidRequest);
            }

            var isDeleted = await _profileEditManager.DeleteUserCredits(userId);

            if (isDeleted)
            {
                return Ok(isDeleted);
            }

            return StatusCode(StatusCodes.Status304NotModified, false);
        }
        #endregion

        #region Dancing
        [HttpGet]
        [Route("Dancing")]
        public async Task<IActionResult> GetUserDancing()
        {
            var dancingResult = await _profileEditManager.GetUserDancingAsync();

            if (dancingResult.IsNull())
            {
                return NotFound(dancingResult);
            }

            return Ok(dancingResult);
        }

        [HttpPost]
        [Route("Dancing")]
        public async Task<IActionResult> SaveUserDancing([FromBody]DancingModel dancingModel)
        {
            if (dancingModel.IsNull())
            {
                return BadRequest(HttpStatusText.InvalidRequest);
            }

            var isSuccess = await _profileEditManager.SaveUserDancingAsync(dancingModel);
            if (isSuccess)
            {
                return Ok(isSuccess);
            }

            return StatusCode(StatusCodes.Status304NotModified, this);
        }
        #endregion

        #region Acting
        [HttpGet]
        [Route("Acting")]
        public async Task<IActionResult> GetUserActingDetails()
        {
            var actingResult = await _profileEditManager.GetUserActingDetailAsync();

            if (actingResult.IsNull())
            {
                return NotFound(actingResult);
            }

            return Ok(actingResult);
        }

        [HttpPost]
        [Route("Acting")]
        public async Task<IActionResult> SaveUserActingDetails([FromBody]UserActingModel userActingModel)
        {
            if (userActingModel.IsNull())
            {
                return BadRequest(HttpStatusText.InvalidRequest);
            }

            var isSuccess = await _profileEditManager.SaveUserActingDetailsAsync(userActingModel);
            if (isSuccess)
            {
                return Ok(isSuccess);
            }

            return StatusCode(StatusCodes.Status304NotModified, this);
        }
        #endregion

        #region Modeling
        [HttpGet]
        [Route("Modeling")]
        public async Task<IActionResult> GetUserModelingDetails()
        {
            var actingResult = await _profileEditManager.GetUserModelingDetailAsync();

            if (actingResult.IsNull())
            {
                return NotFound(actingResult);
            }

            return Ok(actingResult);
        }

        [HttpPost]
        [Route("Modeling")]
        public async Task<IActionResult> SaveUserModelingDetails([FromBody]UserModelingModel userModelingModel)
        {
            if (userModelingModel.IsNull())
            {
                return BadRequest(HttpStatusText.InvalidRequest);
            }

            var isSuccess = await _profileEditManager.SaveUserModelingDetailsAsync(userModelingModel);
            if (isSuccess)
            {
                return Ok(isSuccess);
            }

            return StatusCode(StatusCodes.Status304NotModified, this);
        }
        #endregion

        #region Job Groups
        [HttpGet]
        [Route("Interests")]
        public async Task<IActionResult> GetUserInterests()
        {
            var result = await _jobManager.GetUserGobGroup();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        [Route("Interests")]
        public async Task<IActionResult> SaveUserInterests([FromBody] List<JobGroupModel> jobGroups)
        {
            if (jobGroups.IsNull() || !jobGroups.Any())
            {
                return BadRequest();
            }

            if (await _jobManager.SaveUserGobGroup(jobGroups))
            {
                return Ok(true);
            }

            return StatusCode(StatusCodes.Status304NotModified, HttpStatusText.NotModified);
        }
        #endregion

        #region Name
        [HttpGet]
        [Route("name")]
        public async Task<IActionResult> GetName()
        {
            var result = await _profileEditManager.GetNameDetailsByUserId(UserContext.Current.UserId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPatch]
        [Route("name")]
        public async Task<IActionResult> SaveName([FromBody]UserNameModel nameModel)
        {
            if (nameModel.IsNull() || string.IsNullOrWhiteSpace(nameModel.FirstName) || string.IsNullOrWhiteSpace(nameModel.DisplayName))
            {
                return BadRequest();
            }

            if (await _profileEditManager.SaveNameDetails(nameModel))
            {
                return Ok(true);
            }

            return StatusCode(StatusCodes.Status304NotModified, this);
        }
        #endregion

        [HttpGet]
        [Route("header")]
        public async Task<IActionResult> GetProfileHeader()
        {
            var result = await _profileEditManager.GetProfileHeaderByUserId(UserContext.Current.UserId);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpGet]
        [Route("detail")]
        public async Task<IActionResult> GetProfileDetail()
        {
            var result = await _profileEditManager.GetProfileDetail();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPatch]
        [Route("intro")]
        public async Task<IActionResult> SaveIntro([FromBody]UserDetailModel model)
        {
            if (model.IsNull() || string.IsNullOrWhiteSpace(model.About) || string.IsNullOrWhiteSpace(model.ProfileAddress))
            {
                return BadRequest();
            }

            if (await _profileEditManager.SaveUserIntro(model))
            {
                return Ok(true);
            }

            return StatusCode(StatusCodes.Status304NotModified, this);
        }


        [HttpGet]
        [Route("address")]
        public async Task<IActionResult> GetCurrentAddress()
        {
            var result = await _userManager.GetCurrentAddress();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPatch]
        [Route("address")]
        public async Task<IActionResult> UpdateAddress([FromBody]AddressDto model)
        {
            if (model.IsNull() ||
                string.IsNullOrWhiteSpace(model.CityOrTown) || string.IsNullOrWhiteSpace(model.Country) ||
                string.IsNullOrWhiteSpace(model.StateOrProvince) || string.IsNullOrWhiteSpace(model.ZipOrPostalCode))
            {
                return BadRequest();
            }

            if (await _userManager.UpdateCurrentAddress(model))
            {
                return Ok(true);
            }

            return StatusCode(StatusCodes.Status304NotModified, this);
        }
    }
}