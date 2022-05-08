using CSharp.Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace CSharp.Data.Seeds
{
    public class Seed
    {
        public static async Task SeedUserData(AppDbContext context, UserManager<AppUser> userManager)
        {
            // If no users exist in the database, create
            if (!userManager.Users.Any() && !context.Articles.Any())
            {
                var users = new List<AppUser>
                {
                    // Create new user
                    new AppUser
                    {
                        Id = "86fdb32b-e0a8-4d04-95ed-13889be52d59",
                        DisplayName = "Guest",
                        UserName = "guest",
                        Email = "guest@test.com",
                    },
                    new AppUser
                    {
                        Id = "b4d1f4aa-e95c-49b9-95c9-4bdabd0f5d86",
                        DisplayName = "Test",
                        UserName = "test",
                        Email = "test@mail.com"
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "P@$$w0rd");
                }

                var articles = new List<Article>
                {
                     new Article
                    {
                        Id = Guid.NewGuid(),
                        Title = "Have you ever seen the curve?",
                        Content = "What if I told you some people still believe the earth is flat? I wouldn't count myself out of these people. Here is why, have you ever been in a plane? Have you looked in the window just before going above the clouds? I have and I could not see any signs of a curve. What about the videos and pictures we are shown by Nasa? Have you seen how much money is invested into Nasa each year? What if those images and videos where all created like special effects in a movie? I remain skeptical.",
                        Contributors = new List<ArticleContributor>
                        {
                            new ArticleContributor
                            {
                                AppUser = users[0],
                                IsCreator = true,
                            }
                        }
                    },
                    new Article
                    {
                        Id = Guid.NewGuid(),
                        Title = "Did you know that the Pentagon released a statement confirming UFOs are real.",
                        Content = "I am very surprised that this information has not been talked much about.",
                        Contributors = new List<ArticleContributor>
                        {
                            new ArticleContributor
                            {
                                AppUser = users[0],
                                IsCreator = true,
                            }
                        }
                    }
                };

                await context.Articles.AddRangeAsync(articles);
                await context.SaveChangesAsync();
            }
        }
    }
}
