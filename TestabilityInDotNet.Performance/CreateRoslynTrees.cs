using BenchmarkDotNet.Attributes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BenchmarkTreeGeneration
{
	[MemoryDiagnoser]
	public class CreateRoslynTrees
	{
		[Benchmark(Baseline = true)]
#pragma warning disable CA1822 // Mark members as static
#pragma warning disable CA1303 // Do not pass literals as localized parameters
		public CompilationUnitSyntax CreateTreeViaParsing() =>
			SyntaxFactory.ParseCompilationUnit(
@"using System;

namespace HelloWorld 
{  
	class Program  
	{    
		static void Main(string[] args)    
		{      
			Console.Out.WriteLine(""Hello compiled world"");    
		}  
	} 
}");

		[Benchmark]
		public CompilationUnitSyntax CreateTreeViaFactory() =>
			// Generated from http://roslynquoter.azurewebsites.net/
			SyntaxFactory.CompilationUnit()
				.WithUsings(
					 SyntaxFactory.SingletonList<UsingDirectiveSyntax>(
						  SyntaxFactory.UsingDirective(
								SyntaxFactory.IdentifierName("System"))
						  .WithUsingKeyword(
								SyntaxFactory.Token(
									 SyntaxFactory.TriviaList(),
									 SyntaxKind.UsingKeyword,
									 SyntaxFactory.TriviaList(
										  SyntaxFactory.Space)))
						  .WithSemicolonToken(
								SyntaxFactory.Token(
									 SyntaxFactory.TriviaList(),
									 SyntaxKind.SemicolonToken,
									 SyntaxFactory.TriviaList(
										  SyntaxFactory.LineFeed)))))
				.WithMembers(
					 SyntaxFactory.SingletonList<MemberDeclarationSyntax>(
						  SyntaxFactory.NamespaceDeclaration(
								SyntaxFactory.IdentifierName(
									 SyntaxFactory.Identifier(
										  SyntaxFactory.TriviaList(),
										  "HelloWorld",
										  SyntaxFactory.TriviaList(
												new[]{
										 SyntaxFactory.Space,
										 SyntaxFactory.LineFeed}))))
						  .WithNamespaceKeyword(
								SyntaxFactory.Token(
									 SyntaxFactory.TriviaList(
										  SyntaxFactory.LineFeed),
									 SyntaxKind.NamespaceKeyword,
									 SyntaxFactory.TriviaList(
										  SyntaxFactory.Space)))
						  .WithOpenBraceToken(
								SyntaxFactory.Token(
									 SyntaxFactory.TriviaList(),
									 SyntaxKind.OpenBraceToken,
									 SyntaxFactory.TriviaList(
										  new[]{
									SyntaxFactory.Whitespace("  "),
									SyntaxFactory.LineFeed})))
						  .WithMembers(
								SyntaxFactory.SingletonList<MemberDeclarationSyntax>(
									 SyntaxFactory.ClassDeclaration(
										  SyntaxFactory.Identifier(
												SyntaxFactory.TriviaList(),
												"Program",
												SyntaxFactory.TriviaList(
													 new[]{
											  SyntaxFactory.Whitespace("  "),
											  SyntaxFactory.LineFeed})))
									 .WithKeyword(
										  SyntaxFactory.Token(
												SyntaxFactory.TriviaList(
													 SyntaxFactory.Tab),
												SyntaxKind.ClassKeyword,
												SyntaxFactory.TriviaList(
													 SyntaxFactory.Space)))
									 .WithOpenBraceToken(
										  SyntaxFactory.Token(
												SyntaxFactory.TriviaList(
													 SyntaxFactory.Tab),
												SyntaxKind.OpenBraceToken,
												SyntaxFactory.TriviaList(
													 new[]{
											  SyntaxFactory.Whitespace("    "),
											  SyntaxFactory.LineFeed})))
									 .WithMembers(
										  SyntaxFactory.SingletonList<MemberDeclarationSyntax>(
												SyntaxFactory.MethodDeclaration(
													 SyntaxFactory.PredefinedType(
														  SyntaxFactory.Token(
																SyntaxFactory.TriviaList(),
																SyntaxKind.VoidKeyword,
																SyntaxFactory.TriviaList(
																	 SyntaxFactory.Space))),
													 SyntaxFactory.Identifier("Main"))
												.WithModifiers(
													 SyntaxFactory.TokenList(
														  SyntaxFactory.Token(
																SyntaxFactory.TriviaList(
																	 SyntaxFactory.Whitespace("		")),
																SyntaxKind.StaticKeyword,
																SyntaxFactory.TriviaList(
																	 SyntaxFactory.Space))))
												.WithParameterList(
													 SyntaxFactory.ParameterList(
														  SyntaxFactory.SingletonSeparatedList<ParameterSyntax>(
																SyntaxFactory.Parameter(
																	 SyntaxFactory.Identifier("args"))
																.WithType(
																	 SyntaxFactory.ArrayType(
																		  SyntaxFactory.PredefinedType(
																				SyntaxFactory.Token(SyntaxKind.StringKeyword)))
																	 .WithRankSpecifiers(
																		  SyntaxFactory.SingletonList<ArrayRankSpecifierSyntax>(
																				SyntaxFactory.ArrayRankSpecifier(
																					 SyntaxFactory.SingletonSeparatedList<ExpressionSyntax>(
																						  SyntaxFactory.OmittedArraySizeExpression()
																						  .WithOmittedArraySizeExpressionToken(
																								SyntaxFactory.Token(SyntaxKind.OmittedArraySizeExpressionToken))))
																				.WithOpenBracketToken(
																					 SyntaxFactory.Token(SyntaxKind.OpenBracketToken))
																				.WithCloseBracketToken(
																					 SyntaxFactory.Token(
																						  SyntaxFactory.TriviaList(),
																						  SyntaxKind.CloseBracketToken,
																						  SyntaxFactory.TriviaList(
																								SyntaxFactory.Space))))))))
													 .WithOpenParenToken(
														  SyntaxFactory.Token(SyntaxKind.OpenParenToken))
													 .WithCloseParenToken(
														  SyntaxFactory.Token(
																SyntaxFactory.TriviaList(),
																SyntaxKind.CloseParenToken,
																SyntaxFactory.TriviaList(
																	 new[]{
															  SyntaxFactory.Whitespace("    "),
															  SyntaxFactory.LineFeed}))))
												.WithBody(
													 SyntaxFactory.Block(
														  SyntaxFactory.SingletonList<StatementSyntax>(
																SyntaxFactory.ExpressionStatement(
																	 SyntaxFactory.InvocationExpression(
																		  SyntaxFactory.MemberAccessExpression(
																				SyntaxKind.SimpleMemberAccessExpression,
																				SyntaxFactory.MemberAccessExpression(
																					 SyntaxKind.SimpleMemberAccessExpression,
																					 SyntaxFactory.IdentifierName(
																						  SyntaxFactory.Identifier(
																								SyntaxFactory.TriviaList(
																									 SyntaxFactory.Whitespace("			")),
																								"Console",
																								SyntaxFactory.TriviaList())),
																					 SyntaxFactory.IdentifierName("Out"))
																				.WithOperatorToken(
																					 SyntaxFactory.Token(SyntaxKind.DotToken)),
																				SyntaxFactory.IdentifierName("WriteLine"))
																		  .WithOperatorToken(
																				SyntaxFactory.Token(SyntaxKind.DotToken)))
																	 .WithArgumentList(
																		  SyntaxFactory.ArgumentList(
																				SyntaxFactory.SeparatedList<ArgumentSyntax>(
																					 new SyntaxNodeOrToken[]{
																			  SyntaxFactory.Argument(
																					SyntaxFactory.LiteralExpression(
																						 SyntaxKind.StringLiteralExpression,
																						 SyntaxFactory.Literal(""))),
																			  SyntaxFactory.MissingToken(SyntaxKind.CommaToken),
																			  SyntaxFactory.Argument(
																					SyntaxFactory.IdentifierName(
																						 SyntaxFactory.Identifier(
																							  SyntaxFactory.TriviaList(),
																							  "Hello",
																							  SyntaxFactory.TriviaList(
																									SyntaxFactory.Space)))),
																			  SyntaxFactory.MissingToken(SyntaxKind.CommaToken),
																			  SyntaxFactory.Argument(
																					SyntaxFactory.IdentifierName(
																						 SyntaxFactory.Identifier(
																							  SyntaxFactory.TriviaList(),
																							  "compiled",
																							  SyntaxFactory.TriviaList(
																									SyntaxFactory.Space)))),
																			  SyntaxFactory.MissingToken(SyntaxKind.CommaToken),
																			  SyntaxFactory.Argument(
																					SyntaxFactory.IdentifierName("world")),
																			  SyntaxFactory.MissingToken(SyntaxKind.CommaToken),
																			  SyntaxFactory.Argument(
																					SyntaxFactory.LiteralExpression(
																						 SyntaxKind.StringLiteralExpression,
																						 SyntaxFactory.Literal("")))}))
																		  .WithOpenParenToken(
																				SyntaxFactory.Token(SyntaxKind.OpenParenToken))
																		  .WithCloseParenToken(
																				SyntaxFactory.Token(SyntaxKind.CloseParenToken))))
																.WithSemicolonToken(
																	 SyntaxFactory.Token(
																		  SyntaxFactory.TriviaList(),
																		  SyntaxKind.SemicolonToken,
																		  SyntaxFactory.TriviaList(
																				new[]{
																		 SyntaxFactory.Whitespace("    "),
																		 SyntaxFactory.LineFeed})))))
													 .WithOpenBraceToken(
														  SyntaxFactory.Token(
																SyntaxFactory.TriviaList(
																	 SyntaxFactory.Whitespace("		")),
																SyntaxKind.OpenBraceToken,
																SyntaxFactory.TriviaList(
																	 new[]{
															  SyntaxFactory.Whitespace("      "),
															  SyntaxFactory.LineFeed})))
													 .WithCloseBraceToken(
														  SyntaxFactory.Token(
																SyntaxFactory.TriviaList(
																	 SyntaxFactory.Whitespace("		")),
																SyntaxKind.CloseBraceToken,
																SyntaxFactory.TriviaList(
																	 new[]{
															  SyntaxFactory.Whitespace("  "),
															  SyntaxFactory.LineFeed}))))))
									 .WithCloseBraceToken(
										  SyntaxFactory.Token(
												SyntaxFactory.TriviaList(
													 SyntaxFactory.Tab),
												SyntaxKind.CloseBraceToken,
												SyntaxFactory.TriviaList(
													 new[]{
											  SyntaxFactory.Space,
											  SyntaxFactory.LineFeed})))))
						  .WithCloseBraceToken(
								SyntaxFactory.Token(SyntaxKind.CloseBraceToken))))
				.WithEndOfFileToken(
					 SyntaxFactory.Token(SyntaxKind.EndOfFileToken));
	}
#pragma warning restore CA1303 // Do not pass literals as localized parameters
#pragma warning restore CA1822 // Mark members as static
}