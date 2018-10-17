using Microsoft.AspNetCore.Mvc;
using StarGuddy.Business.Interface.Search;
using System.Threading.Tasks;

namespace StarGuddy.Api.Controllers.Search
{
    [ApiController]
    [Route("api/Search")]
    [Produces("application/json")]
    public class SearchController : ControllerBase
    {

        private readonly ISearchManager _searchManager;

        public SearchController(ISearchManager searchManager)
        {
            _searchManager = searchManager;
        }

        [HttpGet]
        [Route("TalentGroups")]
        public async Task<IActionResult> GetTalentGroups()
        {
            var result = await _searchManager.GetUserGobGroup();
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("name")]
        public async Task<IActionResult> GetName()
        {
            try
            {
                var result = await _searchManager.GetName();
                return Ok(result);
            }
            catch (System.Exception ex)
            {

                return Ok(ex);
            }

        }
    }
}
