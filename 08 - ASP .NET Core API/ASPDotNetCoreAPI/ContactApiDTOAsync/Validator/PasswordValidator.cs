using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ContactApiDTOAsync.Validator
{
    // Classe PasswordValidator héritant de ValidationAttribute pour personnaliser la validation de mot de passe
    public class PasswordValidator : ValidationAttribute
    {
        // Méthode override IsValid pour définir les critères de validation personnalisés
        public override bool IsValid(object? value)
        {
            var input = value?.ToString(); // Convertit la valeur entrée en chaîne de caractères
            ErrorMessage = string.Empty; // Initialise le message d'erreur

            if (string.IsNullOrEmpty(input))
            {
                // Vérifie si le mot de passe est vide
                ErrorMessage = "Le mot de passe ne doit pas être vide";
            }
            else
            {
                // Définit les critères de validation à l'aide d'expressions régulières
                var hasNumber = new Regex(@"[0-9]{2,}"); // Au moins deux chiffres
                var hasUpperLetters = new Regex(@"[A-Z]{2,}"); // Au moins deux lettres majuscules
                var hasLowerCase = new Regex(@"[a-z]{2,}"); // Au moins deux lettres minuscules
                var hasEnoughChars = new Regex(@".{8,15}"); // Longueur entre 8 et 15 caractères
                var hasSymbol = new Regex(@"[.+*?!:;,^@/$(){}|]{2,}"); // Au moins deux symboles spéciaux

                // Vérifie chaque critère et ajoute un message d'erreur si nécessaire
                if (!hasNumber.IsMatch(input))
                {
                    ErrorMessage += "Il manque des chiffres. ";
                }
                if (!hasUpperLetters.IsMatch(input))
                {
                    ErrorMessage += "Il manque des lettres majuscules. ";
                }
                if (!hasLowerCase.IsMatch(input))
                {
                    ErrorMessage += "Il manque des lettres minuscules. ";
                }
                if (!hasEnoughChars.IsMatch(input))
                {
                    ErrorMessage += "Le mot de passe doit avoir entre 8 et 15 caractères. ";
                }
                if (!hasSymbol.IsMatch(input))
                {
                    ErrorMessage += "Il manque des symboles. ";
                }

                // Si aucun message d'erreur n'a été ajouté, le mot de passe est valide
                if (ErrorMessage == string.Empty)
                    return true;
            }

            // Retourne false si le mot de passe ne respecte pas les critères
            return false;

        }
    }
}
