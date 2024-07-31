using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02Relations.Models
{
    internal class Blog
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Url { get; set; }

        // Propriétés de navigations
        // Many-to-One
        public List<Post> Posts { get; set; } = new List<Post>();

        // Many-To-Many
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
