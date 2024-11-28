using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using Api.Models;

namespace Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmailController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("send")]
        public IActionResult SendEmail([FromBody] Email request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var emailSettings = _configuration.GetSection("EmailSettings");

                var smtpClient = new SmtpClient(emailSettings["SmtpServer"])
                {
                    Port = int.Parse(emailSettings["Port"]),
                    Credentials = new NetworkCredential(emailSettings["SenderEmail"], emailSettings["SenderPassword"]),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(emailSettings["SenderEmail"], "Formulario de Contacto"),
                    Subject = request.Subject,
                    Body = $"Nombre: {request.Nombre} {request.Apellido}\nCorreo: {request.EmailAddress}\nTeléfono: {request.NumeroTelefono}\n\nMensaje:\n{request.Mensaje}",
                    IsBodyHtml = false,
                };

                mailMessage.To.Add(emailSettings["RecipientEmail"]);

                smtpClient.Send(mailMessage);

                return Ok(new { message = "Correo enviado exitosamente." });
            }
            catch (SmtpException ex)
            {
                return StatusCode(500, new { error = $"Error al enviar el correo: {ex.Message}" });
            }
        }
    }
}
