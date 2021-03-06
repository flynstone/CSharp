using AutoMapper;
using AutoMapper.QueryableExtensions;
using CSharp.Application.Core;
using CSharp.Application.Interfaces;
using CSharp.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CSharp.Application.Articles
{
    public class Details
    {
        public class Query : IRequest<Result<ArticleDto>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<ArticleDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            private readonly IUserAccessor _userAccessor;
            public Handler(AppDbContext context, IMapper mapper, IUserAccessor userAccessor)
            {
                _context = context;
                _mapper = mapper;
                _userAccessor = userAccessor;
            }

            public async Task<Result<ArticleDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var article = await _context.Articles
                    .ProjectTo<ArticleDto>(_mapper.ConfigurationProvider, new { currentUsername = _userAccessor.GetUsername() })
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                return Result<ArticleDto>.Success(article);
            }
        }
    }
}
