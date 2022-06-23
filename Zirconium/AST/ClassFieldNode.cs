using Antlr4.Runtime;
using Zirconium.AST.Statements.Expressions;

namespace Zirconium.AST.Statements
{
    public class ClassFieldNode: AbstractNode
    {
        public enum Access
        {
            Public,
            Private,
            Protected,
            Internal
        }
        
        public Access Protection { get; private set; }
        public string Name { get; private set; }
        public TypeNode DeclaredType { get; private set; }
        public bool IsStatic { get; private set; }
        public ClassFieldNode(string name, Access protection, TypeNode declaredType, bool isStatic, string file, IToken first, IToken last) : base(file, first,last)
        {
            Name = name;
            Protection = protection;
            DeclaredType = declaredType;
            IsStatic = isStatic;

        }

    }
}