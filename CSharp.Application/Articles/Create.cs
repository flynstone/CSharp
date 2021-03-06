using CSharp.Application.Core;
using CSharp.Application.Interfaces;
using CSharp.Data;
using CSharp.Entities.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CSharp.Application.Articles
{
    public class Create
    {
        // Not returning a result using ** Unit from MediatR
        public class Command : IRequest<Result<Unit>>
        {
            public Article Article { get; set; }
        }

        // Using FluentValidation
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Article).SetValidator(new ArticleValidator());
            }
        }

        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly AppDbContext _context;
            private readonly IUserAccessor _userAccessor;
            public Handler(AppDbContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == _userAccessor.GetUsername());

                var contributor = new ArticleContributor
                {
                    AppUser = user,
                    Article = request.Article,
                    IsCreator = true
                };

                request.Article.Contributors.Add(contributor);

                _context.Articles.Add(request.Article);

                // Return true or false if the result is found or not
                var result = await _context.SaveChangesAsync() > 0;

                // Handle not found
                if (!result) return Result<Unit>.Failure("Failed to create article");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
