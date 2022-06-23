using System.Collections.Generic;
using Zirconium.AST.Statements;
using Zirconium.AST.Statements.Expressions;
using Zirconium.AST.Statements.Statements;

namespace Zirconium.Visitors
{
    public class StatementVisitor: ZirconiumBaseVisitor<StatementNode>
    {
        private string File;
        private CompilationPassInfo CompilationPassInfo;

        public StatementVisitor(string file, CompilationPassInfo info)
        {
            File = file;
            CompilationPassInfo = info;
        }

        public override StatementNode VisitSemiColonStatement(ZirconiumParser.SemiColonStatementContext context)
        {
            if (context.expression() != null)
            {
                return context.expression().Accept(new ExpressionVisitor(File, CompilationPassInfo));
            }
            return base.VisitSemiColonStatement(context);
        }

        public override StatementNode VisitInitialization(ZirconiumParser.InitializationContext context)
        {
            TypeNode type = null;
            IdentifierNode identifier = new IdentifierNode(context.IDENTIFIER(), File);
            AbstractExpressionNode value =
                context.expression().Accept(new ExpressionVisitor(File, CompilationPassInfo));
            if (context.LET() == null)
            {
                type = new TypeNode(context.instanceableType().GetText(), File, context.instanceableType().Start,
                    context.instanceableType().Stop);
            }

            return new InitializationNode(type, identifier, value, File, context.Start, context.Stop);
        }

        public override StatementNode VisitDelete(ZirconiumParser.DeleteContext context)
        {
            var expression = context.expression().Accept(new ExpressionVisitor(File, CompilationPassInfo));
            return new DeleteNode(expression, context.OPENBRACE() != null, File, context.Start, context.Stop);
        }

        public override StatementNode VisitReturn(ZirconiumParser.ReturnContext context)
        {
            AbstractExpressionNode returnValue = null;
            if (context.expression() != null)
            {
                returnValue = context.expression().Accept(new ExpressionVisitor(File, CompilationPassInfo));
            }

            return new ReturnNode(returnValue, File, context.Start, context.Stop);
        }

        public override StatementNode VisitBreak(ZirconiumParser.BreakContext context)
        {
            return new BreakNode(File, context.Start, context.Stop);
        }

        public override StatementNode VisitContinue(ZirconiumParser.ContinueContext context)
        {
            return new ContinueNode(File, context.Start, context.Stop);
        }

        public override StatementNode VisitIfConstruct(ZirconiumParser.IfConstructContext context)
        {
            var expressionVisitor = new ExpressionVisitor(File, CompilationPassInfo);
            var scopeVisitor = new ScopeVisitor(File, CompilationPassInfo);
            IfNode initialIf = new IfNode(context.@if().expression().Accept(expressionVisitor),
                context.@if().scope().Accept(scopeVisitor), File, context.@if().Start, context.@if().Stop);
            List<IfNode> elseifs = new List<IfNode>();
            foreach (var elseif in context.elseif())
            {
                elseifs.Add(new IfNode(elseif.@if().expression().Accept(expressionVisitor),
                    elseif.@if().scope().Accept(scopeVisitor), File, elseif.Start, elseif.Stop));
            }

            ScopeNode elseNode = null;
            if (context.@else() != null)
            {
                elseNode = context.@else().Accept(scopeVisitor);
            }

            return new IfConstructNode(initialIf, elseifs, elseNode, File, context.Start, context.Stop);
        }

        public override StatementNode VisitForConstruct(ZirconiumParser.ForConstructContext context)
        {
            List<InitializationNode> initializations = new List<InitializationNode>();
            var expressionVisitor = new ExpressionVisitor(File, CompilationPassInfo);
            foreach (var initializationContext in context.initialization())
            {
                initializations.Add((InitializationNode)initializationContext.Accept(this));
            }

            AbstractExpressionNode condition = null;
            if (context.condition != null)
            {
                condition = context.condition.Accept(expressionVisitor);
            }

            List<AbstractExpressionNode> postExpressions = new List<AbstractExpressionNode>();
            foreach (var expressionContext in context.expression())
            {
                postExpressions.Add(expressionContext.Accept(expressionVisitor));
            }

            var body = context.scope().Accept(new ScopeVisitor(File, CompilationPassInfo));

            return new ForNode(initializations, condition, postExpressions, body, File, context.Start, context.Stop);
        }

        public override StatementNode VisitWhileConstruct(ZirconiumParser.WhileConstructContext context)
        {
            var expressionVisitor = new ExpressionVisitor(File, CompilationPassInfo);
            var condition = context.expression().Accept(expressionVisitor);
            var body = context.scope().Accept(new ScopeVisitor(File, CompilationPassInfo));
            return new WhileNode(condition, body, File, context.Start, context.Stop);
        }
    }
}