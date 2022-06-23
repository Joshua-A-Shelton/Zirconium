using Antlr4.Runtime;
using Zirconium.AST.Statements.Expressions;

namespace Zirconium.AST.Statements.Statements
{
    public class DeleteNode: StatementNode
    {
        private AbstractExpressionNode value;
        private bool isArrayDelete;
        public DeleteNode(AbstractExpressionNode value, bool isArrayDelete, string file, IToken first, IToken last) :
            base(file, first, last)
        {
            this.value = value;
            this.isArrayDelete = isArrayDelete;
        }
    }
}