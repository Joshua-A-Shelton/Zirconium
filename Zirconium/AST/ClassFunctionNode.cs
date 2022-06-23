using System.Collections.Generic;
using Antlr4.Runtime;

namespace Zirconium.AST.Statements
{
    public class ClassFunctionNode: AbstractNode
    {
        public ClassFieldNode.Access Access { get; private set; }
        public bool IsStatic { get; private set; }
        public bool IsOverride { get; private set; }
        public bool IsVirtual { get; private set; }
        public IdentifierNode Name { get; private set; }
        private List<ParameterDeclarationNode> parameters = new List<ParameterDeclarationNode>();
        public IReadOnlyList<ParameterDeclarationNode> Parameters
        {
            get { return parameters; }
        }
        public ScopeNode Body { get; private set; }

        public ClassFunctionNode(ClassFieldNode.Access access, bool isStatic, bool isOverride, bool isVirtual,
            IdentifierNode name, IEnumerable<ParameterDeclarationNode> parameters, ScopeNode body, string file, IToken start, IToken stop): base(file,start,stop)
        {
            Access = access;
            IsStatic = isStatic;
            IsOverride = isOverride;
            IsVirtual = isVirtual;
            Name = name;
            this.parameters.AddRange(parameters);
            Body = body;
        }
        
    }
}