using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02Relations.Models
{
    internal class Tag
    {
        public int Id { get; set; }
        public string Titre { get; set; }

        // Relation many-to-many SANS une table intermédaire
        public List<Blog> Blogs { get; set; } = new List<Blog>();

        // Relation many-to-many AVEC une table intermédaire
        public List<PostTag> TagPosts { get; set; } = new();
    }
}
