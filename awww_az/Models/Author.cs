using awww_az.Models;
using System.Collections.Generic;

namespace awww_az.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Relacja 1 (Author) -> * (Article)
        public virtual ICollection<Article> Articles { get; set; }

        public Author()
        {
            Articles = new HashSet<Article>();
        }
    }
}
