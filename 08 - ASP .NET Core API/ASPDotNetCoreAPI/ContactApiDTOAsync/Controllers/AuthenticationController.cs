
using ContactApiDTO.Data;
using ContactApiDTOAsync.DTOs;
using ContactApiDTOAsync.Helpers;
using ContactApiDTOAsync.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace ContactApiDTOAsync.Controllers
{
    [Route("api/[controller]")] // Définit le chemin d'accès au contrôleur
    [ApiController] // Indique que ce contrôleur répond aux requêtes API
    public class AuthenticationController : ControllerBase
    {
        private readonly AppDbContext _appDbContext1; // Contexte de la base de données
        private readonly AppSettings _appSettings1; // Paramètres de configuration Appsettings

        // Constructeur pour injecter les dépendances
        public AuthenticationController(AppDbContext appDbContext, IOptions<AppSettings> appSettings)
        {
            _appDbContext1 = appDbContext; // Injection du contexte de la base de données
            _appSettings1 = appSettings.Value; // Injection des paramètres de configuration Appsettings
        }

        [HttpPost("register")] // Méthode pour l'inscription des utilisateurs
        public async Task<IActionResult> Register([FromBody] User user) // Inscription asynchrone
        {
            // Vérifie si l'email existe déjà dans la base de données
            if (await _appDbContext1.Users.FirstOrDefaultAsync(u => u.Email == user.Email) != null)
                return BadRequest("Email exist"); // Retourne une erreur si l'email existe

            // Crypte le mot de passe avant de le sauvegarder
            user.Password = PasswordCrypter.Encrypt(user.Password, _appSettings1.SecretKey);

            // Ajoute le nouvel utilisateur à la base de données
            await _appDbContext1.AddAsync(user);

            // Sauvegarde les changements dans la base de données
            if (await _appDbContext1.SaveChangesAsync() > 0) return Ok("User crée"); // Confirme la création de l'utilisateur
            return BadRequest("Probleme creation User"); // Signale un problème lors de la création
        }

        [HttpPost("login")] // Méthode pour la connexion des utilisateurs
        public async Task<IActionResult> Login([FromBody] LoginRequestDto login) // Connexion asynchrone
        {
            // Crypte le mot de passe pour la comparaison
            login.Password = PasswordCrypter.Encrypt(login.Password, _appSettings1.SecretKey!);

            // Vérifie l'existence de l'utilisateur avec l'email et le mot de passe crypté
            var user = await _appDbContext1.Users.FirstOrDefaultAsync(u => u.Email == login.Email && u.Password == login.Password);

            // Si l'utilisateur n'existe pas, retourne une erreur d'authentification
            if (user == null) return BadRequest("Invalid Authentication !");

            // Attribue le rôle basé sur le statut d'administrateur de l'utilisateur
            var role = user.IsAdmin ? Constants.RoleAdmin : Constants.RoleUser;

            // Crée une liste de revendications (claims) incluant le rôle et l'ID de l'utilisateur
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role, role),
                new Claim("Userid",user.Id.ToString())
            };

            // Prépare les informations de signature pour le token
            SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSettings1.SecretKey!)), SecurityAlgorithms.HmacSha256);

            // Crée le JWT
            JwtSecurityToken jwt = new JwtSecurityToken(
               claims: claims, // Liste des revendications (claims) associées à l'utilisateur
                issuer: _appSettings1.ValidIssuer, // L'émetteur du token, utilisé pour la validation du token côté serveur
                audience: _appSettings1.ValidAudience, // Le public cible du token, spécifie à qui le token est destiné
                signingCredentials: signingCredentials, // Les credentials utilisées pour signer le token
                expires: DateTime.Now.AddHours(2)); // La durée de validité du token, ici fixée à 2 heures après l'émission. Expire après 2 heures

            // Génère le token à partir du JWT
            string token = new JwtSecurityTokenHandler().WriteToken(jwt);

            // Retourne le token et des informations sur l'utilisateur
            return Ok(new
            {
                Token = token,
                Message = "Authentication Succefull !!",
                User = user
            });
        }
    }
}
