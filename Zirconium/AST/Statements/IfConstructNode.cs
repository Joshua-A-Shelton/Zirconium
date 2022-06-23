using System.Collections.Generic;
using Antlr4.Runtime;

namespace Zirconium.AST.Statements
{
    public class IfConstructNode: StatementNode
    {
        public IfNode If { get; private set; }
        private List<IfNode> elseIfs = new List<IfNode>();
        public IReadOnlyList<IfNode> ElseIfs => elseIfs;
        public ScopeNode Else { get; private set; }

        public IfConstructNode(IfNode ifnode, IEnumerable<IfNode> elseIfs, ScopeNode elseNode, string file, IToken first,
            IToken last) : base(file, first, last)
        {
            If = ifnode;
            this.elseIfs.AddRange(elseIfs);
            Else = elseNode;
        }
    }
}