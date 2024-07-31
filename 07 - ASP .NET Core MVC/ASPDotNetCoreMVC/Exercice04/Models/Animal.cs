using System.ComponentModel.DataAnnotations;
namespace Exercice04.Models;


public class Animal
{
    public int Id { get; set; }
    [Display(Name = "Prénom de l'animal")]
    [Required(ErrorMessage = "Le nom est requis.")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Le nom doit être compris entre 3 et 30 caractères.")]
    public string? FirstName { get; set; }
    [Display(Name = "Age de l'animal")]
    [Required(ErrorMessage = "L'age est requis.")]
    [Range(0, 120, ErrorMessage = "L'age doit être compris entre 0 et 120")]
    public int? Age { get; set; }
    [Display(Name = "Espèce de l'animal")]
    public string? Species { get; set; }
    [Display(Name = "Photo de l'animal")]
    public string? PicturePath { get; set; }
}
