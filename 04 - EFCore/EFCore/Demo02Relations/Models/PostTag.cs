using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02Relations.Models
{
    // [Index(nameof(PostId), nameof(TagId))]
    internal class PostTag
    {
        // Utilisation d'une clé primaire propre à la table
        //public int Id { get; set; }

        // Creation d'une primary key composite
        // càd : la primary key est la concaténation du PostId et du TagId
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
