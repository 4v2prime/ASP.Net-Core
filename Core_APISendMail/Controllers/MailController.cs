using Core_APISendMail.Modal;
using Core_APISendMail.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_APISendMail.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailServices _emailService;
        public MailController(IMailServices emailService)
        {
            _emailService = emailService;
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] Email model)
        {
            if (model==null)
                return BadRequest(ModelState);

            var result = await _emailService.SendEmailAsync(model);

            if (result)
                return Ok(new { message = "Email sent successfully" });
            else
                return StatusCode(500, new { message = "Failed to send email" });
        }
    }
}
