using Antlr4.Runtime;
using Zirconium.AST.Statements.Expressions;

namespace Zirconium.AST.Statements.Statements
{
    public class InitializationNode: StatementNode
    {
        private IdentifierNode identifier;
        //may be null initially if implicit typing is used
        private TypeNode type;
        private AbstractExpressionNode value;
        public InitializationNode(TypeNode type, IdentifierNode identifier, AbstractExpressionNode value ,string file, IToken first, IToken last) : base(file, first, last)
        {
            this.type = type;
            this.identifier = identifier;
            this.value = value;
        }
    }
}