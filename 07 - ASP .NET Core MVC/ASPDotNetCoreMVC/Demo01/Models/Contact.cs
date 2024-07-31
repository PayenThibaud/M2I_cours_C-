using System.ComponentModel.DataAnnotations;

namespace Demo01.Models;

public class Contact
{
    // L'annotation Display précise comment on devrait afficher une certaine propriété dans la partie présentation
    // Elle sera utile pour Html.DisplayNameFor(...)

    public int Id { get; set; }
    [Display(Name = "Prénom")] // par défaut le display correspond au nom de la propriété => "FirstName"
    [Required(ErrorMessage = "Prénom Manquant")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Le prénom doit être compris entre 3 et 30 caractères.")]
    public string? FirstName { get; set; }
    [Display(Name = "Nom")]
    [Required(ErrorMessage = "Nom Manquant")]
    [StringLength(30, MinimumLength = 3, ErrorMessage = "Le nom doit être compris entre 3 et 30 caractères.")]
    public string? LastName { get; set; }
    [Display(Name = "Adresse Mail")]
    [Required(ErrorMessage = "Email Manquant")]
    [RegularExpression(@"^([a-zA-Z0-9\.\-_]+)@([a-zA-Z0-9\-_]+)(\.)?([a-zA-Z0-9\-_]+)?(\.){1}([a-zA-Z]{2,11})$", ErrorMessage = "Email Invalide !")]
    public string? Email { get; set; }
    [Display(Name = "Numéro de téléphone")]
    [Required(ErrorMessage = "Téléphone Manquant")]
    [RegularExpression(@"^([0|\+33|33]+)(\.|\-|\s)?([1-9]{1})((\.|\-|\s)?[0-9]{2}){4}$", ErrorMessage = "Téléphone Invalide !")]
    public string? Phone { get; set; }
}
