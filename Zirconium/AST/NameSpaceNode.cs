using Antlr4.Runtime;

namespace Zirconium.AST
{
    public class NameSpaceNode: AbstractNode
    {
        public string NameSpace { get; private set; }
        public NameSpaceNode(string _namespace, string file, IToken first, IToken last):base(file,first,last)
        {
            NameSpace = _namespace;
        }
    }
}