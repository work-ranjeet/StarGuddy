using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using StarGuddy.Api.Models.Files;
using StarGuddy.Business.Interface.Files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace StarGuddy.Api.Controllers.Files
{
    [Produces("application/json")]
    [Route("api/Profile/Image")]
    public class ImageController : BaseApiController
    {
        private readonly IImageManager _imageManager;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ImageController(IHttpContextAccessor httpContextAccessor, IImageManager imageManager)
        {
            _imageManager = imageManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [Route("headshot")]
        public async Task<IActionResult> GetHeadShotDetails()
        {

            var result = await _imageManager.GetHeadShotImageDetail();
            if(result.IsNull())
            {
                return NotFound();
            }

            return Ok(result);
             
        }

        [HttpPost]
        [Route("headshot")]
        public async Task<IActionResult> SaveHeadShotDetails([FromBody]ImageModel imageModel)
        {
            if (imageModel.IsNull() || imageModel.DataUrl == string.Empty)
                return BadRequest();

            if (await _imageManager.SaveUpdateHeadShot(imageModel))
            {
                return Ok("Upload Successful.");
            }

            return StatusCode(StatusCodes.Status304NotModified, "Oops! there are some error occurred. Please try after some times");
        }

        //[HttpPost]
        //[Route("UploadImage")]
        //public IActionResult UploadImage(IFormFile file)
        //{
        //var context = _httpContextAccessor.HttpContext;
        //string imageName = null;
        //var httpRequest = HttpContext.Current.Request;
        ////Upload Image
        //var postedFile = httpRequest.Files["Image"];
        ////Create custom filename
        //imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
        //imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(postedFile.FileName);
        //var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
        //postedFile.SaveAs(filePath);

        ////Save to DB
        //using (DBModel db = new DBModel())
        //{
        //    Image image = new Image()
        //    {
        //        ImageCaption = httpRequest["ImageCaption"],
        //        ImageName = imageName
        //    };
        //    db.Images.Add(image);
        //    db.SaveChanges();
        //}
        //    System.Threading.Thread.Sleep(5000);
        //    return Json("Upload Successful.");
        //}
    }
}
