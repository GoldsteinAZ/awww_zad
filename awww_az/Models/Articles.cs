using awww_az.Models;
using System;
using System.Collections.Generic;

namespace awww_az.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }

        // Klucz obcy do Author
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        // Klucz obcy do Category
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        // Relacja 1 (Article) -> * (Comment)
        public virtual ICollection<Comment> Comments { get; set; }

        // Relacja wiele-do-wielu z Tag
        public virtual ICollection<Tag> Tags { get; set; }

        public Article()
        {
            Comments = new HashSet<Comment>();
            Tags = new HashSet<Tag>();
        }
    }
}
