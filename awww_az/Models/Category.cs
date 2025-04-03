using awww_az.Models;
using System.Collections.Generic;

namespace awww_az.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Relacja 1 (Category) -> * (Article)
        public virtual ICollection<Article> Articles { get; set; }

        public Category()
        {
            Articles = new HashSet<Article>();
        }
    }
}
