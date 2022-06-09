using System.Collections.Generic;
using Zirconium.AST;

namespace Zirconium.Visitors
{
    public class ClassVisitor: ZirconiumBaseVisitor<AbstractNode>
    {
        private IEnumerable<NameSpaceNode> PredefinedNamespaces;
        private NameSpaceNode CurrentNameSpace;
        private string File;
        private CompilationPassInfo PassInfo;
        public ClassVisitor(IEnumerable<NameSpaceNode> predefinedNamespaces, NameSpaceNode currentNameSpace, string file, CompilationPassInfo passInfo)
        {
            PredefinedNamespaces = predefinedNamespaces;
            CurrentNameSpace = currentNameSpace;
            File = file;
            PassInfo = passInfo;
        }

        public override AbstractNode VisitClass(ZirconiumParser.ClassContext context)
        {
            ClassNode.Accessibility access = ClassNode.Accessibility.Private;
            var classAccessibility = context.classAccessibility();
            if (classAccessibility != null)
            {
                string text = classAccessibility.GetText();
                switch (text)
                {
                    case "public":
                        access = ClassNode.Accessibility.Public;
                        break;
                    case "private":
                        access = ClassNode.Accessibility.Private;
                        break;
                    case "protected":
                        access = ClassNode.Accessibility.Protected;
                        break;
                    case "internal":
                        access = ClassNode.Accessibility.Internal;
                        break;
                }
            }

            var classSpecial = context.classSpecial();
            bool isAbstract = false;
            bool isStatic = false;
            if (classSpecial != null)
            {
                string text = classSpecial.GetText();
                switch (text)
                {
                    case "abstract":
                        isAbstract = true;
                        break;
                    case "static":
                        isStatic = true;
                        break;
                }
            }

            var classID = context.IDENTIFIER();
            IdentifierNode name = new IdentifierNode(classID, File);
            //TODO: generics
            //TODO: extensions

            List<ClassFieldNode> fields = new List<ClassFieldNode>();
            List<ClassFunctionNode> functions = new List<ClassFunctionNode>();
            List<ClassPropertyNode> properties = new List<ClassPropertyNode>();
            List<ClassConstructorNode> constructors = new List<ClassConstructorNode>();
            ClassDestructorNode destructor = null;
            foreach (var member in context.classMember())
            {
                var node = member.Accept(this);
                if (node is ClassFieldNode)
                {
                    fields.Add((ClassFieldNode)node);
                }
                else if (node is ClassFunctionNode)
                {
                    functions.Add((ClassFunctionNode)node);
                }
                else if (node is ClassPropertyNode)
                {
                    properties.Add((ClassPropertyNode)node);
                }
                else if (node is ClassConstructorNode)
                {
                    constructors.Add((ClassConstructorNode)node);
                }
                else
                {
                    if (destructor == null)
                    {
                        destructor = (ClassDestructorNode) node;
                    }
                    else
                    {
                        PassInfo.AddError("Only one destructor may be defined per class, Previously defined at: "+destructor.Location(),node);
                    }
                }
            }

            return new ClassNode(PredefinedNamespaces, CurrentNameSpace, name, fields, properties,functions,constructors,destructor, isStatic, isAbstract, File,
                context.Start, context.Stop);
        }

        public override AbstractNode VisitField(ZirconiumParser.FieldContext context)
        {
            var access = GetAccess(context.memberAccessibility());
            bool isStatic = context.STATIC() != null;
            var type = context.instanceableType();
            var typeNode = new TypeNode( type.GetText(),File,type.Start, type.Stop);
            string id = context.IDENTIFIER().GetText();
            return new ClassFieldNode(id, access, typeNode, isStatic, File, context.Start, context.Stop);
        }

        public override AbstractNode VisitFunction(ZirconiumParser.FunctionContext context)
        {
            var access = GetAccess(context.memberAccessibility());
            bool isStatic = false;
            bool isOverride = false;
            bool isVirtual = false;
            var special = context.functionSpecial();
            if (special != null)
            {
                switch (special.GetText())
                {
                    case "static":
                        isStatic = true;
                        break;
                    case "override":
                        isOverride = true;
                        break;
                    case "virtual":
                        isVirtual = true;
                        break;
                }
            }

            var type = context.returnableType();
            var typeNode = new TypeNode(type.GetText(), File, type.Start, type.Stop);
            string id = context.IDENTIFIER().GetText();
            //TODO: generics
            List<ParameterDeclarationNode> parameters = new List<ParameterDeclarationNode>();
            foreach (var parameter in context.parameterDeclaration())
            {
                var paramType = parameter.instanceableType();
                var paramTypeNode = new TypeNode(paramType.GetText(), File, paramType.Start, paramType.Stop);

                var identifier = new IdentifierNode(parameter.IDENTIFIER(), File);
                parameters.Add(new ParameterDeclarationNode(paramTypeNode, identifier, File, parameter.Start, parameter.Stop));
            }

            ScopeNode scope = context.scope().Accept(new ScopeVisitor(File,PassInfo));
            return new ClassFunctionNode();
        }

        public override AbstractNode VisitProperty(ZirconiumParser.PropertyContext context)
        {
            return base.VisitProperty(context);
        }

        public override AbstractNode VisitDestructor(ZirconiumParser.DestructorContext context)
        {
            return base.VisitDestructor(context);
        }

        private ClassFieldNode.Access GetAccess(ZirconiumParser.MemberAccessibilityContext context)
        {
            ClassFieldNode.Access access = ClassFieldNode.Access.Private;
            if (context != null)
            {
                switch (context.GetText())
                {
                    case "public":
                        access = ClassFieldNode.Access.Public;
                        break;
                    case "private":
                        access = ClassFieldNode.Access.Private;
                        break;
                    case "protected":
                        access = ClassFieldNode.Access.Protected;
                        break;
                    case "internal":
                        access = ClassFieldNode.Access.Internal;
                        break;
                }
            }

            return access;
        }
    }
}