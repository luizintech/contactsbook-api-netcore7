using ContactBook.Application.Interfaces;
using ContactBook.Dtos.ContactTypeValues;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTypeValueController : ControllerBase
    {
        private readonly IContactTypeValueService _contactTypeValueService;
        public ContactTypeValueController(IContactTypeValueService contactTypeValueService)
        {
            _contactTypeValueService = contactTypeValueService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
            => Ok(await _contactTypeValueService.FindAllAsync());

        [HttpGet("id:int")]
        public async Task<IActionResult> GetAsync([FromRoute] int id)
            => Ok(await _contactTypeValueService.FindByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ContactTypeValueDto contactTypeValue)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _contactTypeValueService.InsertAsync(contactTypeValue));
        }

        [HttpPut("id:int")]
        public async Task<IActionResult> PostAsync([FromRoute] int id, [FromBody] ContactTypeValueDto contactTypeValue)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _contactTypeValueService.InsertAsync(contactTypeValue));
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await _contactTypeValueService.RemoveDataAsync(id));
    }
}
