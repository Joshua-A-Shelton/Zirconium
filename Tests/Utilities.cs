using System.IO;
using Antlr4.Runtime;
using Zirconium;
using Zirconium.AST.Statements;
using Zirconium.Visitors;

namespace Tests
{
    public static class Utilities
    {
        public static FileNode Compile(string filename)
        {
            AntlrInputStream inputStream = new AntlrFileStream(filename);
            ZirconiumLexer lexer = new ZirconiumLexer(inputStream);
            CommonTokenStream tokenStream = new CommonTokenStream(lexer);
            ZirconiumParser parser = new ZirconiumParser(tokenStream);
            return parser.compilable().Accept(new CompilableVisitor(filename,new CompilationPassInfo()));
        }
    }
}