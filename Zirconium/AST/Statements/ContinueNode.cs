using Antlr4.Runtime;

namespace Zirconium.AST.Statements
{
    public class ContinueNode: StatementNode
    {
        public ContinueNode(string file, IToken first, IToken last): base(file,first,last)
        {}
    }
}