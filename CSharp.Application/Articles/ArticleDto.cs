namespace CSharp.Application.Articles
{
    public class ArticleDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatorUsername { get; set; }
        public bool IsClosed { get; set; }
        public ICollection<ContributorDto> Contributors { get; set; }
    }
}
