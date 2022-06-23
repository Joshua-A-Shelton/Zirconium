grammar Zirconium;

compilable: usingStatements? compilableStruct? EOF;

usingStatements: usingStatement+;
usingStatement: USING namespace SEMICOLON;
compilableStruct: (NAMESPACE IDENTIFIER OPENCURLY compilationUnit* CLOSECURLY) | compilationUnit+;
namespace: IDENTIFIER (DOT IDENTIFIER)*;
compilationUnit: class | interface | freeFunction;
genericDeclaration: LESSTHAN IDENTIFIER (COMMA IDENTIFIER)* GREATERTHAN;
genericImplmentation: LESSTHAN instanceableType (COMMA instanceableType)* GREATERTHAN;
type: (namespace COLON)? IDENTIFIER genericImplmentation?;
knownType:type (STAR+ | OPENBRACE CLOSEBRACE)?;
voidPointer: VOID STAR;
instanceableType: knownType | voidPointer;
returnableType: knownType | VOID;

class: classAccessibility? classSpecial? CLASS IDENTIFIER genericDeclaration? classExtension? OPENCURLY classMember* CLOSECURLY;
classAccessibility: PUBLIC | PRIVATE | INTERNAL;
classSpecial: STATIC | ABSTRACT;
classExtension: COLON type (COMMA type);

classMember: field | function | property | constructor | destructor;

memberAccessibility: PUBLIC | PRIVATE | PROTECTED | INTERNAL;
field: memberAccessibility? STATIC? instanceableType IDENTIFIER SEMICOLON;//no preassignment yet
property: memberAccessibility? instanceableType IDENTIFIER OPENCURLY (getSet | autoGetSet) CLOSECURLY;
getSet: GET getscope=scope (memberAccessibility? SET setscope=scope)?;
autoGetSet: GET SEMICOLON (memberAccessibility? SET SEMICOLON)?;
function: memberAccessibility? functionSpecial? returnableType IDENTIFIER genericDeclaration? OPENPAREN (parameterDeclaration (COMMA parameterDeclaration)*)? CLOSEPAREN (scope | SEMICOLON);
functionSpecial: STATIC | OVERRIDE | VIRTUAL;
parameterDeclaration: instanceableType IDENTIFIER;
constructor: memberAccessibility? IDENTIFIER genericDeclaration? OPENPAREN (parameterDeclaration (COMMA parameterDeclaration)*)? CLOSEPAREN (scope | SEMICOLON);
destructor: VIRTUAL? TILDE IDENTIFIER genericDeclaration? OPENPAREN CLOSEPAREN (scope | SEMICOLON);

interface: interfaceAccessibility? INTERFACE IDENTIFIER genericDeclaration? classExtension OPENCURLY interfaceMember* CLOSECURLY;
interfaceAccessibility: PUBLIC | INTERNAL;
interfaceMember: functionDefinition | propertyDefinition;
functionDefinition: interfaceAccessibility? returnableType IDENTIFIER genericDeclaration? OPENPAREN (parameterDeclaration (COMMA parameterDeclaration)*)? CLOSEPAREN SEMICOLON;
propertyDefinition: interfaceAccessibility? instanceableType IDENTIFIER OPENCURLY GET SEMICOLON (interfaceAccessibility? SET SEMICOLON)? CLOSECURLY;

freeFunction: freeFunctionAccessibility?  returnableType IDENTIFIER genericDeclaration? OPENPAREN (parameterDeclaration (COMMA parameterDeclaration)*)? CLOSEPAREN scope;
freeFunctionAccessibility: PUBLIC | INTERNAL;

scope: OPENCURLY scopeStatement* CLOSECURLY;
scopeStatement: semiColonStatement | flowControl;
semiColonStatement: (initialization | expression | delete | return | break | continue) SEMICOLON;
initialization: (instanceableType | LET) IDENTIFIER EQUALS expression;
new: NEW instanceableType (OPENBRACE expression CLOSEBRACE);
delete: DELETE (OPENBRACE CLOSEBRACE)? expression;
return: RETURN expression?;
break: BREAK;
continue: CONTINUE;
flowControl: ifConstruct | forConstruct | whileConstruct;

ifConstruct: if elseif* else?;
if: IF OPENPAREN expression CLOSEPAREN scope;
elseif: ELSE if;
else: ELSE scope;

forConstruct: FOR OPENPAREN (initialization (COMMA initialization)*)? SEMICOLON condition=expression? SEMICOLON (expression (COMMA expression)*)? CLOSEPAREN scope;

whileConstruct: WHILE OPENPAREN expression CLOSEPAREN scope;

expression
    : OPENPAREN expression CLOSEPAREN                   #parenExpression
    | expression postfix                                #postfixExpression
    | unary expression                                  #unaryExpression
    | new                                               #newExpression
    | left=expression op=multiply right=expression      #multiplyExpression
    | left=expression op=add right=expression           #addExpression
    | left=expression op=shift right=expression         #shiftExpression
    | left=expression op=relational right=expression    #relationalExpression
    | left=expression op=equality right=expression      #equalityExpression
    | left=expression op=bitwiseAnd right=expression    #bitwiseAndExpression
    | left=expression op=bitwiseXor right=expression    #bitwiseXorExpression
    | left=expression op=bitwiseOr right=expression     #bitwiseOrExpression
    | left=expression op=logicalAnd right=expression    #logicalAndExpression
    | left=expression op=logicalOr right=expression     #logicalOrExpression
    | left=expression op=assignment right=expression    #assignmentExpression
    | literal                                           #literalExpression
    | NULL                                              #nullExpression
    | IDENTIFIER                                        #identifierExpression
    ;

postfix
    : PLUSPLUS              #plusPlusPostfix
    | MINUSMINUS            #minusMinusPostfix
    | functionCall          #functionCallPostfix
    | subscript             #subscriptPostfix
    | DOT IDENTIFIER        #dotPostfix
    | ARROW IDENTIFIER      #arrowPostfix
    ;

functionCall: OPENPAREN (expression (COMMA expression)*)? CLOSEPAREN;
subscript: OPENBRACE (expression (COMMA expression)*)? CLOSEBRACE;

unary
    : PLUSPLUS                                  #plusPlusUnary
    | MINUSMINUS                                #minusMinusUnary
    | MINUS                                     #negateUnary
    | BANG                                      #logicalNotUnary
    | TILDE                                     #bitwiseNotUnary
    | OPENPAREN instanceableType CLOSEPAREN     #typecastUnary
    | STAR                                      #dereferenceUnary
    | AND                                       #referenceUnary
    ;

multiply: STAR | DIVIDE | MODULUS;
add: PLUS | MINUS;
shift: leftshift | rightshift;
leftshift: LESSTHAN LESSTHAN;
rightshift: GREATERTHAN GREATERTHAN;
relational: LESSTHAN | LESSTHANEQUAL | GREATERTHAN | GREATERTHANEQUAL;
equality: EQUALEQUAL | NOTEQUAL;
bitwiseAnd: AND;
bitwiseXor: XOR;
bitwiseOr: OR;
logicalAnd: ANDAND;
logicalOr: OROR;
assignment
    : EQUALS
    | PLUSEQUALS
    | MINUSEQUALS
    | TIMESEQUALS
    | DIVIDEEQUALS
    | MODULUSEQUALS
    | lshiftEquals
    | rshiftEquals
    | ANDEQUALS
    | XOREQUALS
    | OREQUALS
    ;
lshiftEquals: LESSTHAN LESSTHAN EQUALS;
rshiftEquals: GREATERTHAN GREATERTHAN EQUALS;

literal
    : stringLiteral
    | charLiteral
    | boolLiteral
    | intLiteral
    | floatLiteral
    | doubleLiteral
    ;
    
stringLiteral: STRINGLITERAL;
charLiteral: CHARLITERAL;
boolLiteral: TRUE | FALSE;
intLiteral: INTLITERAL;
floatLiteral: FLOATLITERAL;
doubleLiteral: DOUBLELITERAL;

USING: 'using';
NAMESPACE: 'namespace';
CLASS: 'class';
INTERFACE: 'interface';
PUBLIC: 'public';
PRIVATE: 'private';
PROTECTED: 'protected';
INTERNAL: 'internal';
STATIC: 'static';
ABSTRACT: 'abstract';
VIRTUAL: 'virtual';
OVERRIDE: 'override';
LET: 'let';
NEW: 'new';
DELETE: 'delete';
RETURN: 'return';
BREAK: 'break';
CONTINUE: 'continue';
FOR: 'for';
WHILE: 'while';
IF: 'if';
ELSE: 'else';
GET: 'get';
SET: 'set';
VOID: 'void';
NULL: 'null';

fragment ESC: '\\"';
STRINGLITERAL: '"' ( ESC | ~[\\"] )* '"';
CHARLITERAL: '\'' ('\\')? . '\'';
TRUE: 'true';
FALSE: 'false';
FLOATLITERAL: [0-9]*'.'?[0-9]+'f';
DOUBLELITERAL:[0-9]*'.'[0-9]+;
INTLITERAL: [0-9]+;

PLUSPLUS: '++';
MINUSMINUS: '--';
PLUSEQUALS: '+=';
MINUSEQUALS: '-=';
TIMESEQUALS: '*=';
DIVIDEEQUALS: '/=';
MODULUSEQUALS: '%=';
EQUALEQUAL: '==';
NOTEQUAL: '!=';
ANDEQUALS: '&=';
XOREQUALS: '^=';
OREQUALS: '|=';
LESSTHANEQUAL: '<=';
GREATERTHANEQUAL: '>=';
LESSTHAN: '<';
GREATERTHAN: '>';
EQUALS: '=';
ANDAND: '&&';
OROR: '||';
AND: '&';
OR: '|';
XOR: '^';
DOT: '.';
ARROW: '->';
PLUS: '+';
MINUS: '-';
STAR: '*';
DIVIDE: '/';
MODULUS: '%';
BANG: '!';
TILDE: '~';
COLON: ':';
SEMICOLON: ';';
COMMA: ',';
OPENPAREN: '(';
CLOSEPAREN: ')';
OPENBRACE: '[';
CLOSEBRACE: ']';
OPENCURLY: '{';
CLOSECURLY: '}';




IDENTIFIER: [a-zA-Z_][a-zA-Z0-9_]*;

WS : [ \t\r\n]+ -> skip;