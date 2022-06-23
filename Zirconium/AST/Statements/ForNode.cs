using System.Collections.Generic;
using System.Formats.Asn1;
using Antlr4.Runtime;
using Zirconium.AST.Statements.Expressions;
using Zirconium.AST.Statements.Statements;

namespace Zirconium.AST.Statements
{
    public class ForNode: StatementNode
    {
        private List<InitializationNode> initializations = new List<InitializationNode>();
        public IReadOnlyList<InitializationNode> Initialization => initializations;
        public AbstractExpressionNode Condition { get; private set; }
        private List<AbstractExpressionNode> postLoopOperations = new List<AbstractExpressionNode>();
        public IReadOnlyList<AbstractExpressionNode> PostLoopOperations => postLoopOperations;
        public ScopeNode Body { get; private set; }

        public ForNode(IEnumerable<InitializationNode> initializations, AbstractExpressionNode condition,
            IEnumerable<AbstractExpressionNode> postLoopOperations, ScopeNode body, string file, IToken first, IToken last) : base(file,
            first, last)
        {
            this.initializations.AddRange(initializations);
            Condition = condition;
            this.postLoopOperations.AddRange(postLoopOperations);
            Body = body;
        }
    }
}