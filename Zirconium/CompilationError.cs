using Zirconium.AST;

namespace Zirconium
{
    public class CompilationError
    {
        public string Message { get; private set; }
        public string File { get; private set; }
        public int Line { get; private set; }
        public int Column { get; private set; }
        public int EndLine { get; private set; }
        public int EndColumn { get; private set; }

        public CompilationError(string message, AbstractNode sourceNode)
        {
            Message = message;
            File = sourceNode.File;
            Line = sourceNode.Line;
            Column = sourceNode.Column;
            EndLine = sourceNode.EndLine;
            EndColumn = sourceNode.EndColumn;
        }
        
        public CompilationError(string message, string file, int line, int column, int endLine, int endColumn)
        {
            Message = message;
            File = file;
            Line = line;
            Column = column;
            EndLine = endLine;
            EndColumn = endColumn;
        }
    }
}