using System.Collections.Generic;
using Antlr4.Runtime;

namespace Zirconium.AST.Statements
{
    public class ScopeNode: AbstractNode
    {
        private List<StatementNode> statements = new List<StatementNode>();
        public IReadOnlyList<StatementNode> Statements => statements;
        public ScopeNode(IEnumerable<StatementNode> statements, string file, IToken first, IToken last) : base(file,
            first, last)
        {
            this.statements.AddRange(statements);
        }
    }
}