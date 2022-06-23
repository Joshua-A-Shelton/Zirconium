using Zirconium.AST.Statements.Expressions;

namespace Zirconium.Visitors
{
    public class ExpressionVisitor: ZirconiumBaseVisitor<AbstractExpressionNode>
    {
        private string File;
        private CompilationPassInfo CompilationPassInfo;
        public ExpressionVisitor(string file, CompilationPassInfo passInfo)
        {
            File = file;
            CompilationPassInfo = passInfo;
        }
        
    }
}