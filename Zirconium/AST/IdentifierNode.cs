using Antlr4.Runtime.Tree;

namespace Zirconium.AST.Statements
{
    public class IdentifierNode: AbstractNode
    {
        public string Text { get; private set; }

        public IdentifierNode(ITerminalNode node, string file) : base(file, node.Symbol,node.Symbol)
        {
            Text = node.GetText();
        }
    }
}