import React from 'react';
import CodeEditor from '@uiw/react-textarea-code-editor';

export default function ArticleClass() {
  const [code, setCode] = React.useState(
    `public class Article 
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    // This will create the date in utc format whenever a new record is inserted in the database.
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
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