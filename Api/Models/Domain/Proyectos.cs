using System.ComponentModel.DataAnnotations;
namespace Api.Models;
public class Proyecto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string startDate { get; set; }

    public string repository { get; set; }

    public string img { get; set; }

    


   
}
