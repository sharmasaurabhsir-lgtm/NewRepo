using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentPortal.DTOs;
using PaymentPortal.Services;

namespace PaymentPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentsController(IPaymentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentDto dto)
        {
            var result = await _service.CreatePayment(dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAll());

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdatePaymentDto dto)
        {
            var result = await _service.Update(id, dto);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.Delete(id);
            if (!success) return NotFound();
            return Ok();
        }
    }
}
