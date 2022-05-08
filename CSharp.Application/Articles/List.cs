using AutoMapper;
using AutoMapper.QueryableExtensions;
using CSharp.Application.Core;
using CSharp.Application.Interfaces;
using CSharp.Data;
using MediatR;

namespace CSharp.Application.Articles
{
    public class List
    {
        public class Query : IRequest<Result<PagedList<ArticleDto>>>
        {
            public ArticleParams Params { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PagedList<ArticleDto>>>
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

            public async Task<Result<PagedList<ArticleDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _context.Articles
                    .Where(d => d.CreatedAt <= request.Params.StartDate)
                    .OrderBy(d => d.CreatedAt)
                    .ProjectTo<ArticleDto>(_mapper.ConfigurationProvider, new { currentUsername = _userAccessor.GetUsername() })
                    .AsQueryable();

                if (request.Params.IsContributor && !request.Params.IsCreator)
                {
                    query = query.Where(x => x.Contributors.Any(a => a.Username == _userAccessor.GetUsername()));
                }

                if (request.Params.IsCreator && !request.Params.IsContributor)
                {
                    query = query.Where(x => x.CreatorUsername == _userAccessor.GetUsername());
                }

                return Result<PagedList<ArticleDto>>.Success(
                    await PagedList<ArticleDto>.CreateAsync(query, request.Params.PageNumber, request.Params.PageSize)
                );
            }
        }
    }
}
