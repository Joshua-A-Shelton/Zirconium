using System.Collections.Generic;
using Zirconium.AST.Statements;

namespace Zirconium.Visitors
{
    public class CompilableVisitor: ZirconiumBaseVisitor<FileNode>
    {
        private string File;
        private CompilationPassInfo PassInfo;
        public CompilableVisitor(string file, CompilationPassInfo passInfo)
        {
            File = file;
            PassInfo = passInfo;
        }
        public override FileNode VisitCompilable(ZirconiumParser.CompilableContext context)
        {
            List<NameSpaceNode> namespaces = new List<NameSpaceNode>();
            var usingStatements = context.usingStatements();
            if (usingStatements != null)
            {
                foreach (var usingStatement in usingStatements.usingStatement())
                {
                    namespaces.Add(new NameSpaceNode(usingStatement.@namespace().GetText(),File,usingStatement.Start,usingStatement.Stop));
                }
            }

            var compilable = context.compilableStruct();
            List<ClassNode> classes = new List<ClassNode>();
            if (compilable != null)
            {
                NameSpaceNode nameSpace = null;
                if (compilable.NAMESPACE() != null)
                {
                    nameSpace = new NameSpaceNode(compilable.IDENTIFIER().GetText(),File,compilable.Start,compilable.Stop);
                }
                
                foreach (var comp in compilable.compilationUnit())
                {
                    if (comp.@class() != null)
                    {
                        classes.Add((ClassNode)comp.@class().Accept(new ClassVisitor(namespaces, nameSpace, File, PassInfo)));
                    }
                    //TODO: interfaces and free functions
                }
            }

            return new FileNode(File, classes, context.Start, context.Stop);
        }
        
    }
}