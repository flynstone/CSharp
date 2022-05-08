import React from 'react';
import CodeEditor from '@uiw/react-textarea-code-editor';

export default function ArticleL() {
  const [code, setCode] = React.useState(
    `public class List 
{
    public class Query : IRequest<List<Article>> { }

    public class Handler : IRequestHandler<Query, List<Article>>
    {
        private readonly AppDbContext _context;
        public Handler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Article>> Handle(Query request, CancellationToken cancellationToken)
        {
            return Result<List<Article>>.Success(await _context.Articles.ToListAsync(cancellationToken));
        }
    }
}`
  );

  return(
              <CodeEditor
                value={code}
                language="csharp"
                padding={15}
                style={{
                  fontSize: 18,
                  backgroundColor: "#343434",
                  fontFamily: 'Fira Code',
                }}          
                />
  )
}