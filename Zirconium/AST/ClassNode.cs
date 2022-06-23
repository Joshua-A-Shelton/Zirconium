using System.Collections.Generic;
using Antlr4.Runtime;

namespace Zirconium.AST.Statements
{
    public class ClassNode: AbstractNode
    {
        public enum Accessibility
        {
            Public,
            Private,
            Protected,
            Internal
        }
        public bool IsStatic { get; private set; }
        public bool IsAbstract { get; private set; }
        private List<NameSpaceNode> usingNamespaces = new List<NameSpaceNode>();
        private List<ClassFieldNode> fields = new List<ClassFieldNode>();
        private List<ClassPropertyNode> properties = new List<ClassPropertyNode>();
        private List<ClassFunctionNode> functions = new List<ClassFunctionNode>();
        private List<ClassConstructorNode> constructors = new List<ClassConstructorNode>();
        public ClassDestructorNode Destructor { get; private set; }

        public IReadOnlyList<NameSpaceNode> UsingNamespaces
        {
            get { return usingNamespaces; }
        }
        
        public NameSpaceNode NameSpace { get; private set; }
        public IdentifierNode Name { get; private set; }

        public ClassNode(IEnumerable<NameSpaceNode> usingNamespaces, NameSpaceNode classNamespace, IdentifierNode className, IEnumerable<ClassFieldNode> fields, IEnumerable<ClassPropertyNode> properties, IEnumerable<ClassFunctionNode> functions, IEnumerable<ClassConstructorNode>constructors, ClassDestructorNode destructor, bool isStatic, bool isAbstract, string file, IToken first, IToken last) : base(file, first, last)
        {
            this.usingNamespaces.AddRange(usingNamespaces);
            this.fields.AddRange(fields);
            this.properties.AddRange(properties);
            this.functions.AddRange(functions);
            this.constructors.AddRange(constructors);
            Destructor = destructor;

            IsStatic = isStatic;
            IsAbstract = isAbstract;

            NameSpace = classNamespace;
            Name = className;
        }
        
    }
}