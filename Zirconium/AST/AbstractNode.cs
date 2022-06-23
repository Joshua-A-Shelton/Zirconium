using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Zirconium.AST.Statements.Expressions;

namespace Zirconium.AST.Statements
{
    public abstract class AbstractNode
    {
        public string File { get; protected set; }
        public int Line { get; protected set; }
        public int Column { get; protected set; }
        public int EndLine { get; protected set; }
        public int EndColumn { get; protected set; }

        private IToken first;
        private IToken last;

        public AbstractNode(string file, IToken first, IToken last)
        {
            this.File = file;
            this.first = first;
            this.last = last;
        }

        /*protected abstract void SelfValidate(CompilationPassInfo info);

        public void Validate(CompilationPassInfo info)
        {
            foreach (var child in Children)
            {
                if(child!=null)
                    child.Validate(info);
            }
            SelfValidate(info);
        }
        //public abstract void Emit();
        */
        private List<AbstractNode> children;
        public IReadOnlyList<AbstractNode> Children
        {
            get
            {
                if (children == null)
                {
                    children = new List<AbstractNode>();
                    var fields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
                    foreach (var field in fields)
                    {
                        if (field.FieldType.IsAssignableTo(typeof(AbstractNode)))
                        {
                            var val = (AbstractNode) field.GetValue(this);
                            if(val!=null)
                                children.Add(val);
                        }
                        else if (field.FieldType.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>)  && t.GenericTypeArguments[0].IsAssignableTo(typeof(AbstractNode))
                        ))
                        {
                            foreach (var child in (IEnumerable)field.GetValue(this))
                            {
                                children.Add((AbstractNode)child);
                            }
                        }
                    }
                }

                return children;
            }
        }
        
        public string Location()
        {
            return File + "@" + Line + "," + Column;
        }
        
    }
}