using System.Collections.Generic;
using Antlr4.Runtime;
using Zirconium.AST.Statements.Expressions;

namespace Zirconium.AST.Statements
{
    public class FileNode: AbstractNode
    {
        private List<ClassNode> classes = new List<ClassNode>();
        public IReadOnlyList<ClassNode> Classes => classes;
        public FileNode(string filename, IEnumerable<ClassNode> compilables, IToken first, IToken last) : base(filename, first, last)
        {
           this.classes.AddRange(compilables); 
        }
    }
}