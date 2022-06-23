using Antlr4.Runtime;
using Zirconium.AST.Statements.Expressions;

namespace Zirconium.AST.Statements
{
    public class IfNode: AbstractNode
    {
        public AbstractExpressionNode Condition { get; private set; }
        public ScopeNode Scope { get; private set; }

        public IfNode(AbstractExpressionNode condition, ScopeNode scope, string file, IToken first, IToken last) : base(
            file, first, last)
        {
            Condition = condition;
            Scope = scope;
        }
    }
}