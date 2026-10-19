using System.ComponentModel.DataAnnotations;

namespace RezeptApi.Models;

// Entspricht einer Entity/einem DTO in Spring Boot.
public class Recipe
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    public List<string> Ingredients { get; set; } = new();
    public string Instructions { get; set; } = string.Empty;
}
