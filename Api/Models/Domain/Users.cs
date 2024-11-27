using System.ComponentModel.DataAnnotations;
namespace Api.Models;
public class Usuario
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nombre { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }


}
