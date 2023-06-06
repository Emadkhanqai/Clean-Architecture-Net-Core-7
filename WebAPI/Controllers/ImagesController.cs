using Application.Features.Images.Commands;
using Application.Features.Images.Queries;
using Application.Features.Properties.Queries;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly ISender _mediatrSender;

        public ImagesController(ISender mediatrSender)
        {
            _mediatrSender = mediatrSender;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNewProperty([FromBody] NewImageDto dto)
        {
            bool isSuccessful = await _mediatrSender.Send(new CreateImageRequest(dto));
            if (isSuccessful)
            {
                return Ok("Image Added Successfully");

            }

            return BadRequest("Failed to add image");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateImage([FromBody] UpdateImageDto dto)
        {
            bool isSuccessful = await _mediatrSender.Send(new UpdateImageRequest(dto));
            if (isSuccessful)
            {
                return Ok("Image Updated Successfully");

            }

            return NotFound("Image not exist.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveImageById(int id)
        {
            bool isDeleted = await _mediatrSender.Send(new DeleteImageRequest(id));
            if (isDeleted)
            {
                return Ok("Image Deleted Successfully");

            }

            return NotFound("No Image Found.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageById(int id)
        {
            ImageDto imageDto= await _mediatrSender.Send(new GetImageByIdRequest(id));
            if (imageDto != null)
            {
                return Ok(imageDto);

            }

            return NotFound("No Image Found.");
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetImages()
        {
            List<ImageDto> imageDto= await _mediatrSender.Send(new GetImagesRequest());
            if (imageDto != null)
            {
                return Ok(imageDto);

            }

            return NotFound("No Images Found.");
        }

    }
}
