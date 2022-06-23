using System.Collections.Generic;
using Antlr4.Runtime;

namespace Zirconium.AST.Statements
{
    public class ClassConstructorNode: AbstractNode
    {
        public ClassFieldNode.Access Access { get; private set; }
        private List<ParameterDeclarationNode> parameters = new List<ParameterDeclarationNode>();
        public IReadOnlyList<ParameterDeclarationNode> Parameters
        {
            get { return parameters; }
        }
        public ScopeNode Body { get; private set; }

        public ClassConstructorNode(ClassFieldNode.Access access, IEnumerable<ParameterDeclarationNode> parameters,
            ScopeNode body, string file, IToken first, IToken last) : base(file, first, last)
        {
            Access = access;
            this.parameters.AddRange(parameters);
            Body = body;
        }
    }
}