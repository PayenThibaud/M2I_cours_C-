using System.ComponentModel.DataAnnotations;

namespace DemoBlazor.Models
{
    public class Gorilla
    {
        public int Id { get; set; }
        [Required, StringLength(12, MinimumLength = 3, ErrorMessage = "Le nom doit faire entre 3 et 12 caractères")]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Range(typeof(bool), "true", "true", ErrorMessage = "Le gorille doit avoir une banane")]
        public bool OwnsBanana { get; set; }
        [Required]
        [Range(1, 5, ErrorMessage = "La couleur est requise.")]
        public FurColor FurColor { get; set; }

        public override string ToString()
        {
            return $"{Name} {Description} {OwnsBanana} {FurColor}";
        }
    }
    public enum FurColor
    {
        Nothing,
        Red,
        Brown,
        Pink,
        Orange,
        White
    }
}
