using System;
using Antlr4.Runtime;

namespace Zirconium.AST.Statements
{
    public class ClassPropertyNode: AbstractNode
    {
        public ClassFieldNode.Access GetAccess { get; private set; }
        public ScopeNode GetComplexScope { get; private set; }
        public ClassFieldNode.Access SetAccess { get; private set; }
        public ScopeNode SetComplexScope { get; private set; }

        public bool SetIsDefined { get; private set; } = false;
        
        public bool IsAutoBacked
        {
            get { return GetComplexScope != null && (!SetIsDefined || SetComplexScope != null); }
        }

        public ClassPropertyNode(ClassFieldNode.Access getAccess, ScopeNode getScope, ClassFieldNode.Access setAccess,
            ScopeNode setScope, string file, IToken first, IToken last) : base(file, first, last)
        {
            GetAccess = getAccess;
            GetComplexScope = getScope;
            SetAccess = setAccess;
            SetComplexScope = setScope;
            if (setScope != null)
            {
                SetIsDefined = true;
            }
        }

        public ClassPropertyNode(ClassFieldNode.Access getAccess, ClassFieldNode.Access setAccess, bool setIsDefined, string file,
            IToken first, IToken last) : base(file, first, last)
        {
            GetAccess = getAccess;
            SetAccess = setAccess;
            SetIsDefined = setIsDefined;
        }
    }
}