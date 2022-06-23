using Antlr4.Runtime;

namespace Zirconium.AST.Statements.Expressions
{
    public abstract class AbstractExpressionNode: StatementNode
    {
        public AbstractExpressionNode(string file, IToken first, IToken last) 
            : base(file, first, last)
        {
        }
        
        public abstract string Type { get; }
        public abstract bool ModifiesData { get; }

        
    }
}