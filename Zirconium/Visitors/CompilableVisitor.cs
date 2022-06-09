using System.Collections.Generic;
using Zirconium.AST;

namespace Zirconium.Visitors
{
    public class CompilableVisitor: ZirconiumBaseVisitor<AbstractNode>
    {
        private string File;
        public CompilableVisitor(string file)
        {
            File = file;
        }
        public override AbstractNode VisitCompilable(ZirconiumParser.CompilableContext context)
        {
            List<NameSpaceNode> namespaces = new List<NameSpaceNode>();
            var usingStatements = context.usingStatements();
            if (usingStatements != null)
            {
                foreach (var usingStatement in usingStatements.usingStatement())
                {
                    namespaces.Add(new NameSpaceNode(usingStatement.@namespace().GetText(),File,usingStatement.Start.Line,usingStatement.Start.Column,usingStatement.Stop.Line,usingStatement.Stop.Column));
                }
            }
            
            
        }
        
    }
}