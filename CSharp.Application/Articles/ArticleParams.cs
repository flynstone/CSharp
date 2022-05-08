using CSharp.Application.Core;

namespace CSharp.Application.Articles
{
    public class ArticleParams : PagingParams
    {
        public bool IsContributor { get; set; }
        public bool IsCreator { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;

    }
}
