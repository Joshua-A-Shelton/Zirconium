using Antlr4.Runtime;

namespace Zirconium.AST.Statements
{
    public class BreakNode: StatementNode
    {
        public BreakNode(string file, IToken first, IToken last) : base(file, first, last)
        {
            
        }
    }
}