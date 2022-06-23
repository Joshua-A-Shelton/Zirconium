using Antlr4.Runtime;

namespace Zirconium.AST.Statements
{
    public abstract class StatementNode: AbstractNode
    {
        public StatementNode(string file, IToken first, IToken last) : base(file, first, last)
        {
        }
    }
}