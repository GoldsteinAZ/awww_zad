namespace awww_az.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }

        // Klucz obcy do Article
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}
