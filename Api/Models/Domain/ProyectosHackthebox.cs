using System.ComponentModel.DataAnnotations;
namespace Api.Models;
public class Hackthebox
{
    public int Id { get; set; }

   
    public string Nombre { get; set; }

   
    public string title { get; set; }

    public string description { get; set; }

    public string img { get; set; }

    public string linkCertificado { get; set; }


}
