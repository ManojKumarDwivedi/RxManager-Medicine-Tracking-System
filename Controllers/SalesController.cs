using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSDemo_MedicineApp_ByMkd.DTOs;
using PSDemo_MedicineApp_ByMkd.Helpers;
using PSDemo_MedicineApp_ByMkd.Models;
using PSDemo_MedicineApp_ByMkd.Services;

namespace PSDemo_MedicineApp_ByMkd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SaleService _service = new SaleService();

        [HttpGet]
        public IActionResult Get()
        {
            var sales = FileHelper.ReadList<SaleRecord>("Data/sales.json");
            return Ok(sales);
        }

        [HttpPost]
        public IActionResult Sell(SaleRecordDto dto)
        {
            try
            {
                _service.AddSale(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
