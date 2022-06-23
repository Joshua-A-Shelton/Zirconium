using Antlr4.Runtime;
using Zirconium.AST.Statements.Expressions;

namespace Zirconium.AST.Statements
{
    public class WhileNode: StatementNode
    {
        public AbstractExpressionNode Condition { get; private set; }
        public ScopeNode Body { get; private set; }

        public WhileNode(AbstractExpressionNode condition, ScopeNode body, string file, IToken first, IToken last) :
            base(file, first, last)
        {
            Condition = condition;
            Body = body;
        }
    }
}