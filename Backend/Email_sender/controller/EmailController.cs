
using System.Security.Cryptography;
using Backend_Flet.Email_sender.EmailCollection;
using Microsoft.AspNetCore.Mvc;
using Backend_Flet.Email_sender.Model;
namespace Backend_Flet.Email_sender.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var emailCollection = new Email_collection();
                await emailCollection.SendEmail(request.to, request.subject, request.body);
                return Ok("Email sent successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error sending email: {ex.Message}");
            }
        } 
        [HttpGet]
        public IActionResult GetEmailSettings()
        {
            return Ok("Email settings endpoint is working.");
        }
    }
}