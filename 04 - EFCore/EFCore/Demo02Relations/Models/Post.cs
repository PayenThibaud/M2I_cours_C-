using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02Relations.Models
{
    internal class Post
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public string Contenu { get; set; }
        public DateTime DatePublication { get; set; } = DateTime.Now;

        //[ForeignKey(nameof(Blog))] Utilisation de l'annotation ForeignKey lorsque l'on respecte pas la convention
        // La propriété <entité>Id va être interprété comme une foreign key par EFCore
        // Le fait de créér cette propriété n'est pas obligatoire, mais elle sera pratique pour la sérialisation de l'objet
        public int BlogId { get; set; }

        // Ma propriété blog est lié à ma propriété BlogId
        public Blog Blog { get; set; }

        public List<PostTag> PostTags { get; set; } = new();
    }
}
