//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from C:/Users/jshelton/RiderProjects/Zirconium/Zirconium\Zirconium.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="ZirconiumParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public interface IZirconiumVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.compilable"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompilable([NotNull] ZirconiumParser.CompilableContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.usingStatements"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUsingStatements([NotNull] ZirconiumParser.UsingStatementsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.usingStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUsingStatement([NotNull] ZirconiumParser.UsingStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.compilableStruct"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompilableStruct([NotNull] ZirconiumParser.CompilableStructContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.namespace"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNamespace([NotNull] ZirconiumParser.NamespaceContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.compilationUnit"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCompilationUnit([NotNull] ZirconiumParser.CompilationUnitContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.genericDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGenericDeclaration([NotNull] ZirconiumParser.GenericDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.genericImplmentation"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGenericImplmentation([NotNull] ZirconiumParser.GenericImplmentationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType([NotNull] ZirconiumParser.TypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.knownType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitKnownType([NotNull] ZirconiumParser.KnownTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.voidPointer"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVoidPointer([NotNull] ZirconiumParser.VoidPointerContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.instanceableType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInstanceableType([NotNull] ZirconiumParser.InstanceableTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.returnableType"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturnableType([NotNull] ZirconiumParser.ReturnableTypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.class"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClass([NotNull] ZirconiumParser.ClassContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.classAccessibility"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassAccessibility([NotNull] ZirconiumParser.ClassAccessibilityContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.classSpecial"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassSpecial([NotNull] ZirconiumParser.ClassSpecialContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.classExtension"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassExtension([NotNull] ZirconiumParser.ClassExtensionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.classMember"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitClassMember([NotNull] ZirconiumParser.ClassMemberContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.memberAccessibility"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMemberAccessibility([NotNull] ZirconiumParser.MemberAccessibilityContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.field"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitField([NotNull] ZirconiumParser.FieldContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.property"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitProperty([NotNull] ZirconiumParser.PropertyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.getSet"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGetSet([NotNull] ZirconiumParser.GetSetContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.autoGetSet"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAutoGetSet([NotNull] ZirconiumParser.AutoGetSetContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.function"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunction([NotNull] ZirconiumParser.FunctionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.functionSpecial"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionSpecial([NotNull] ZirconiumParser.FunctionSpecialContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.parameterDeclaration"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParameterDeclaration([NotNull] ZirconiumParser.ParameterDeclarationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.constructor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstructor([NotNull] ZirconiumParser.ConstructorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.destructor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDestructor([NotNull] ZirconiumParser.DestructorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.interface"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInterface([NotNull] ZirconiumParser.InterfaceContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.interfaceAccessibility"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInterfaceAccessibility([NotNull] ZirconiumParser.InterfaceAccessibilityContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.interfaceMember"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInterfaceMember([NotNull] ZirconiumParser.InterfaceMemberContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.functionDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionDefinition([NotNull] ZirconiumParser.FunctionDefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.propertyDefinition"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPropertyDefinition([NotNull] ZirconiumParser.PropertyDefinitionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.freeFunction"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFreeFunction([NotNull] ZirconiumParser.FreeFunctionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.freeFunctionAccessibility"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFreeFunctionAccessibility([NotNull] ZirconiumParser.FreeFunctionAccessibilityContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.scope"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScope([NotNull] ZirconiumParser.ScopeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.scopeStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitScopeStatement([NotNull] ZirconiumParser.ScopeStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.semiColonStatement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSemiColonStatement([NotNull] ZirconiumParser.SemiColonStatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.initialization"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInitialization([NotNull] ZirconiumParser.InitializationContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.new"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNew([NotNull] ZirconiumParser.NewContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.delete"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDelete([NotNull] ZirconiumParser.DeleteContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.return"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturn([NotNull] ZirconiumParser.ReturnContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.break"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBreak([NotNull] ZirconiumParser.BreakContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.continue"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitContinue([NotNull] ZirconiumParser.ContinueContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.flowControl"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFlowControl([NotNull] ZirconiumParser.FlowControlContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.ifConstruct"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfConstruct([NotNull] ZirconiumParser.IfConstructContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.if"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIf([NotNull] ZirconiumParser.IfContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.elseif"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElseif([NotNull] ZirconiumParser.ElseifContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.else"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElse([NotNull] ZirconiumParser.ElseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.forConstruct"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitForConstruct([NotNull] ZirconiumParser.ForConstructContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.whileConstruct"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitWhileConstruct([NotNull] ZirconiumParser.WhileConstructContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>bitwiseXorExpression</c>
	/// labeled alternative in <see cref="ZirconiumParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBitwiseXorExpression([NotNull] ZirconiumParser.BitwiseXorExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>shiftExpression</c>
	/// labeled alternative in <see cref="ZirconiumParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitShiftExpression([NotNull] ZirconiumParser.ShiftExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>relationalExpression</c>
	/// labeled alternative in <see cref="ZirconiumParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRelationalExpression([NotNull] ZirconiumParser.RelationalExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>newExpression</c>
	/// labeled alternative in <see cref="ZirconiumParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNewExpression([NotNull] ZirconiumParser.NewExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>identifierExpression</c>
	/// labeled alternative in <see cref="ZirconiumParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIdentifierExpression([NotNull] ZirconiumParser.IdentifierExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>assignmentExpression</c>
	/// labeled alternative in <see cref="ZirconiumParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignmentExpression([NotNull] ZirconiumParser.AssignmentExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>parenExpression</c>
	/// labeled alternative in <see cref="ZirconiumParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParenExpression([NotNull] ZirconiumParser.ParenExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>multiplyExpression</c>
	/// labeled alternative in <see cref="ZirconiumParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultiplyExpression([NotNull] ZirconiumParser.MultiplyExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>logicalOrExpression</c>
	/// labeled alternative in <see cref="ZirconiumParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicalOrExpression([NotNull] ZirconiumParser.LogicalOrExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>bitwiseOrExpression</c>
	/// labeled alternative in <see cref="ZirconiumParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBitwiseOrExpression([NotNull] ZirconiumParser.BitwiseOrExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>addExpression</c>
	/// labeled alternative in <see cref="ZirconiumParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAddExpression([NotNull] ZirconiumParser.AddExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>nullExpression</c>
	/// labeled alternative in <see cref="ZirconiumParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNullExpression([NotNull] ZirconiumParser.NullExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>bitwiseAndExpression</c>
	/// labeled alternative in <see cref="ZirconiumParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBitwiseAndExpression([NotNull] ZirconiumParser.BitwiseAndExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>equalityExpression</c>
	/// labeled alternative in <see cref="ZirconiumParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEqualityExpression([NotNull] ZirconiumParser.EqualityExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>logicalAndExpression</c>
	/// labeled alternative in <see cref="ZirconiumParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicalAndExpression([NotNull] ZirconiumParser.LogicalAndExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>unaryExpression</c>
	/// labeled alternative in <see cref="ZirconiumParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitUnaryExpression([NotNull] ZirconiumParser.UnaryExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>literalExpression</c>
	/// labeled alternative in <see cref="ZirconiumParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLiteralExpression([NotNull] ZirconiumParser.LiteralExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>postfixExpression</c>
	/// labeled alternative in <see cref="ZirconiumParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPostfixExpression([NotNull] ZirconiumParser.PostfixExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>plusPlusPostfix</c>
	/// labeled alternative in <see cref="ZirconiumParser.postfix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPlusPlusPostfix([NotNull] ZirconiumParser.PlusPlusPostfixContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>minusMinusPostfix</c>
	/// labeled alternative in <see cref="ZirconiumParser.postfix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMinusMinusPostfix([NotNull] ZirconiumParser.MinusMinusPostfixContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>functionCallPostfix</c>
	/// labeled alternative in <see cref="ZirconiumParser.postfix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionCallPostfix([NotNull] ZirconiumParser.FunctionCallPostfixContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>subscriptPostfix</c>
	/// labeled alternative in <see cref="ZirconiumParser.postfix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubscriptPostfix([NotNull] ZirconiumParser.SubscriptPostfixContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>dotPostfix</c>
	/// labeled alternative in <see cref="ZirconiumParser.postfix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDotPostfix([NotNull] ZirconiumParser.DotPostfixContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>arrowPostfix</c>
	/// labeled alternative in <see cref="ZirconiumParser.postfix"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArrowPostfix([NotNull] ZirconiumParser.ArrowPostfixContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.functionCall"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunctionCall([NotNull] ZirconiumParser.FunctionCallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.subscript"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSubscript([NotNull] ZirconiumParser.SubscriptContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>plusPlusUnary</c>
	/// labeled alternative in <see cref="ZirconiumParser.unary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitPlusPlusUnary([NotNull] ZirconiumParser.PlusPlusUnaryContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>minusMinusUnary</c>
	/// labeled alternative in <see cref="ZirconiumParser.unary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMinusMinusUnary([NotNull] ZirconiumParser.MinusMinusUnaryContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>negateUnary</c>
	/// labeled alternative in <see cref="ZirconiumParser.unary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNegateUnary([NotNull] ZirconiumParser.NegateUnaryContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>logicalNotUnary</c>
	/// labeled alternative in <see cref="ZirconiumParser.unary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicalNotUnary([NotNull] ZirconiumParser.LogicalNotUnaryContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>bitwiseNotUnary</c>
	/// labeled alternative in <see cref="ZirconiumParser.unary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBitwiseNotUnary([NotNull] ZirconiumParser.BitwiseNotUnaryContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>typecastUnary</c>
	/// labeled alternative in <see cref="ZirconiumParser.unary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypecastUnary([NotNull] ZirconiumParser.TypecastUnaryContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>dereferenceUnary</c>
	/// labeled alternative in <see cref="ZirconiumParser.unary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDereferenceUnary([NotNull] ZirconiumParser.DereferenceUnaryContext context);
	/// <summary>
	/// Visit a parse tree produced by the <c>referenceUnary</c>
	/// labeled alternative in <see cref="ZirconiumParser.unary"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReferenceUnary([NotNull] ZirconiumParser.ReferenceUnaryContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.multiply"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitMultiply([NotNull] ZirconiumParser.MultiplyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.add"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAdd([NotNull] ZirconiumParser.AddContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.shift"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitShift([NotNull] ZirconiumParser.ShiftContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.leftshift"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLeftshift([NotNull] ZirconiumParser.LeftshiftContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.rightshift"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRightshift([NotNull] ZirconiumParser.RightshiftContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.relational"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRelational([NotNull] ZirconiumParser.RelationalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.equality"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitEquality([NotNull] ZirconiumParser.EqualityContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.bitwiseAnd"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBitwiseAnd([NotNull] ZirconiumParser.BitwiseAndContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.bitwiseXor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBitwiseXor([NotNull] ZirconiumParser.BitwiseXorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.bitwiseOr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBitwiseOr([NotNull] ZirconiumParser.BitwiseOrContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.logicalAnd"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicalAnd([NotNull] ZirconiumParser.LogicalAndContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.logicalOr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLogicalOr([NotNull] ZirconiumParser.LogicalOrContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.assignment"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAssignment([NotNull] ZirconiumParser.AssignmentContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.lshiftEquals"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLshiftEquals([NotNull] ZirconiumParser.LshiftEqualsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.rshiftEquals"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitRshiftEquals([NotNull] ZirconiumParser.RshiftEqualsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.literal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLiteral([NotNull] ZirconiumParser.LiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.stringLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStringLiteral([NotNull] ZirconiumParser.StringLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.charLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCharLiteral([NotNull] ZirconiumParser.CharLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.boolLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolLiteral([NotNull] ZirconiumParser.BoolLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.intLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIntLiteral([NotNull] ZirconiumParser.IntLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.floatLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFloatLiteral([NotNull] ZirconiumParser.FloatLiteralContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="ZirconiumParser.doubleLiteral"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDoubleLiteral([NotNull] ZirconiumParser.DoubleLiteralContext context);
}
