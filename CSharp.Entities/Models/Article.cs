namespace CSharp.Entities.Models
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsClosed { get; set; }

        public ICollection<ArticleContributor> Contributors { get; set; } = new List<ArticleContributor>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
