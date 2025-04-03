using awww_az.Models;
using System.Collections.Generic;

namespace awww_az.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relacja wiele-do-wielu z Article
        public virtual ICollection<Article> Articles { get; set; }

        public Tag()
        {
            Articles = new HashSet<Article>();
        }
    }
}
