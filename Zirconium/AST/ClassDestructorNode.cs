using Antlr4.Runtime;

namespace Zirconium.AST.Statements
{
    public class ClassDestructorNode: AbstractNode
    {
        public ScopeNode Body { get; private set; }
        public ClassDestructorNode(ScopeNode body, string file, IToken first, IToken last) : base(file, first, last)
        {
            Body = body;
        }
    }
}