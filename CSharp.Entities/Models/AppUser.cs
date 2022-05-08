using Microsoft.AspNetCore.Identity;

namespace CSharp.Entities.Models
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string? Bio { get; set; }

        public ICollection<ArticleContributor> Articles { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<UserFollowing> Followings { get; set; }
        public ICollection<UserFollowing> Followers { get; set; }
        // Adding a new list of token will save us from including the list
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
