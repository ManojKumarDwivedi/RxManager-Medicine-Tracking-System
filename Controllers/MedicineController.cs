using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSDemo_MedicineApp_ByMkd.DTOs;
using PSDemo_MedicineApp_ByMkd.Helpers;
using PSDemo_MedicineApp_ByMkd.Services;

namespace PSDemo_MedicineApp_ByMkd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly MedicineService _service = new MedicineService();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _service.GetAll();

                if (data == null || data.Count == 0)
                    return NoContent();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] MedicineDto dto)
        {
            try
            {
                // Validation
                if (dto == null)
                    return BadRequest("Request body is required");

                if (string.IsNullOrWhiteSpace(dto.FullName))
                    return BadRequest("Medicine name is required");

                if (dto.Price <= 0)
                    return BadRequest("Price must be greater than 0");

                if (dto.Quantity < 0)
                    return BadRequest("Quantity cannot be negative");

                _service.Add(dto);

                return Ok("Medicine added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
