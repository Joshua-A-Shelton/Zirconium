using System.Collections.Generic;
using Zirconium.AST.Statements;

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

        public override ScopeNode VisitScope(ZirconiumParser.ScopeContext context)
        {
            StatementVisitor statementVisitor = new StatementVisitor(File, CompilationPassInfo);
            List<StatementNode> statements = new List<StatementNode>();
            foreach (var statementContext in context.scopeStatement())
            {
                statements.Add(statementContext.Accept(statementVisitor));
            }

            return new ScopeNode(statements, File, context.Start, context.Stop);
        }
    }
}