
 import React from 'react';
import CodeEditor from '@uiw/react-textarea-code-editor';

export default function AppDbContext() {
  const [code, setCode] = React.useState(
    `public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) 
        : base(options) { }

    public DbSet<Article> Articles { get; set; }
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