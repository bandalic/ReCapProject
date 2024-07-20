using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        IImageService _imageService;
        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }
        [HttpGet("getimagesbyimageid")]
        public IActionResult GetImagesByCarId(int id)
        {
            var result = _imageService.GetImagesByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] Image image)
        {
            var result = _imageService.Add(file, image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(Image image)
        {
            var result = _imageService.Delete(image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] Image image)
        {
            var result = _imageService.Update(file, image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
