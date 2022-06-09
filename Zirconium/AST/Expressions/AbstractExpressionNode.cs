namespace Zirconium.AST.Expressions
{
    public abstract class AbstractExpressionNode: AbstractNode
    {
        public AbstractExpressionNode(string file, int line, int column, int endLine, int endColumn) 
            : base(file, line, column, endLine, endColumn)
        {
        }
        
        public abstract string Type { get; }

        
    }
}