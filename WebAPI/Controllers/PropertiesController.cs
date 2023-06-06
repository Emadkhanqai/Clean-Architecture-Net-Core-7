using Application.Features.Properties.Commands;
using Application.Features.Properties.Queries;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly ISender _mediatrSender;

        public PropertiesController(ISender mediatrSender)
        {
            _mediatrSender = mediatrSender;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddNewProperty([FromBody] NewPropertyDto dto)
        {
            bool isSuccessful = await _mediatrSender.Send(new CreatePropertyRequest(dto));
            if (isSuccessful)
            {
                return Ok("Property Created Successfully");

            }

            return BadRequest("Failed to create property");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateProperty([FromBody] UpdatePropertyDto dto)
        {
            bool isSuccessful = await _mediatrSender.Send(new UpdatePropertyRequest(dto));
            if (isSuccessful)
            {
                return Ok("Property Updated Successfully");

            }

            return NotFound("Property not exist.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyById(int id)
        {
            PropertyDto propertyDto = await _mediatrSender.Send(new GetPropertyByIdRequest(id));
            if (propertyDto != null)
            {
                return Ok(propertyDto);

            }

            return NotFound("No Property Found.");
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetProperties()
        {
            List<PropertyDto> propertyDto = await _mediatrSender.Send(new GetPropertiesRequest());
            if (propertyDto != null)
            {
                return Ok(propertyDto);

            }

            return NotFound("No Properties Found.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemovePropertyById(int id)
        {
            bool isDeleted = await _mediatrSender.Send(new DeletePropertyRequest(id));
            if (isDeleted)
            {
                return Ok("Property Deleted Successfully");

            }

            return NotFound("No Property Found.");
        }


    }
}
