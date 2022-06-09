using Zirconium.AST;

namespace Zirconium.Visitors
{
    public class ScopeVisitor: ZirconiumBaseVisitor<ScopeNode>
    {
        private string File;
        private CompilationPassInfo CompilationPassInfo;
        public ScopeVisitor(string file, CompilationPassInfo passInfo)
        {
            File = file;
            CompilationPassInfo = passInfo;
        }
    }
}