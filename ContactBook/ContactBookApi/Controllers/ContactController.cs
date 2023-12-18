using ContactBook.Application.Interfaces;
using ContactBook.Dtos.Contacts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactBookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
            => Ok(await _contactService.FindAllAsync());

        [HttpGet("id:int")]
        public async Task<IActionResult> GetAsync([FromRoute]int id)
            => Ok(await _contactService.FindByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]ContactDto contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _contactService.InsertAsync(contact));
        }

        [HttpPut("id:int")]
        public async Task<IActionResult> PostAsync([FromRoute]int id, [FromBody]ContactDto contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _contactService.InsertAsync(contact));
        }

        [HttpDelete("id:int")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
            => Ok(await _contactService.RemoveDataAsync(id));

    }
}
