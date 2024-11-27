using System.ComponentModel.DataAnnotations;
namespace Api.Models;
public class Email
{
    public int Id { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    
    public string EmailAddress { get; set; }

    public string Subject { get; set; }

    public string NumeroTelefono { get; set; }

    public string Mensaje { get; set; }

    
}
