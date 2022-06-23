using Antlr4.Runtime;
using Zirconium.AST.Statements.Expressions;

namespace Zirconium.AST.Statements
{
    public class ReturnNode: StatementNode
    {
        public AbstractExpressionNode Value { get; private set; } 
        public ReturnNode(AbstractExpressionNode value, string file, IToken first, IToken last) : base(file, first,
            last)
        {
            Value = value;
        }
    }
}