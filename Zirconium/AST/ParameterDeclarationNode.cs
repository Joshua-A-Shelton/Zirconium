using Antlr4.Runtime;

namespace Zirconium.AST.Statements
{
    public class ParameterDeclarationNode: AbstractNode
    {
        public TypeNode Type { get; private set; }
        public IdentifierNode Name { get; private set; }
        public ParameterDeclarationNode(TypeNode type, IdentifierNode name, string file, IToken first, IToken last) : base(file, first, last)
        {
            Type = type;
            Name = name;
        }
    }
}