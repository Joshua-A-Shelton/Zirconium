#ifndef ZIRCONIUM_TOKENIZER_H
#define ZIRCONIUM_TOKENIZER_H
#include "../TextLocation.h"
//TOKEN, Pretty Name, TokenChannel, matching Regex
#define TOKEN_DEFINITIONS(DEFINITION)\
DEFINITION(WHITESPACE, "Whitespace", DROP_CHANNEL, "\\s+")\
DEFINITION(INLINE_COMMENT, "Comment", DROP_CHANNEL, "//.*?\\n")\
DEFINITION(MULTILINE_COMMENT, "Comment", DROP_CHANNEL, "/\\*(.*?)\\*/")\
DEFINITION(INLINE_DOCUMENTATION, "Comment", METADATA_CHANNEL, "///")\
DEFINITION(MULTILINE_DOCUMENTATION, "Comment", METADATA_CHANNEL, "/\\*\\*\\*(.*?)\\*/")\
DEFINITION(KEYWORD_BREAK, "Keyword: 'break'",MAIN_CHANNEL,"break")\
DEFINITION(KEYWORD_CASE, "Keyword: 'case'",MAIN_CHANNEL,"case")\
DEFINITION(KEYWORD_CLASS, "Keyword: 'class'",MAIN_CHANNEL,"class")\
DEFINITION(KEYWORD_CONTINUE, "Keyword: 'continue'",MAIN_CHANNEL,"continue")\
DEFINITION(KEYWORD_DELETE, "Keyword: 'delete'",MAIN_CHANNEL,"delete")\
DEFINITION(KEYWORD_ELSE, "Keyword: 'else'",MAIN_CHANNEL,"else")\
DEFINITION(KEYWORD_FALLTHROUGH, "Keyword: 'fallthrough'",MAIN_CHANNEL,"fallthrough")\
DEFINITION(KEYWORD_FOR, "Keyword: 'for'",MAIN_CHANNEL,"for")\
DEFINITION(KEYWORD_FOREACH, "Keyword: 'foreach'",MAIN_CHANNEL,"foreach")\
DEFINITION(KEYWORD_GET, "Keyword: 'get'",MAIN_CHANNEL,"get")\
DEFINITION(KEYWORD_IF, "Keyword: 'if'",MAIN_CHANNEL,"if")\
DEFINITION(KEYWORD_INTERFACE, "Keyword: 'interface'",MAIN_CHANNEL,"interface")\
DEFINITION(KEYWORD_INTERNAL, "Keyword: 'internal'",MAIN_CHANNEL,"internal")\
DEFINITION(KEYWORD_NAMESPACE, "Keyword: 'namespace'",MAIN_CHANNEL,"namespace")\
DEFINITION(KEYWORD_NEW, "Keyword: 'new'",MAIN_CHANNEL,"new")\
DEFINITION(KEYWORD_NULL,"Keyword: 'null'",MAIN_CHANNEL,"null")\
DEFINITION(KEYWORD_PUBLIC, "Keyword: 'public'",MAIN_CHANNEL,"public")\
DEFINITION(KEYWORD_PRIVATE, "Keyword: 'private'",MAIN_CHANNEL,"private")\
DEFINITION(KEYWORD_PROTECTED, "Keyword: 'protected'",MAIN_CHANNEL,"protected")\
DEFINITION(KEYWORD_RETURN, "Keyword: 'return'",MAIN_CHANNEL,"return")\
DEFINITION(KEYWORD_SET, "Keyword: 'set'",MAIN_CHANNEL,"set")\
DEFINITION(KEYWORD_SWITCH, "Keyword: 'switch'",MAIN_CHANNEL,"switch")\
DEFINITION(KEYWORD_USING, "Keyword: 'using'",MAIN_CHANNEL,"using")\
DEFINITION(KEYWORD_VAR,"Keyword: 'var'",MAIN_CHANNEL,"var")\
DEFINITION(KEYWORD_VOID, "Keyword: 'void'",MAIN_CHANNEL,"void")\
DEFINITION(KEYWORD_WHILE, "Keyword: 'while'",MAIN_CHANNEL,"while")\
DEFINITION(OPEN_PAREN,"(",MAIN_CHANNEL,"\\(")\
DEFINITION(CLOSE_PAREN,")",MAIN_CHANNEL,"\\)")\
DEFINITION(OPEN_CURLY,"{",MAIN_CHANNEL,"\\{")\
DEFINITION(CLOSE_CURLY,"}",MAIN_CHANNEL,"\\}")\
DEFINITION(OPEN_BRACKET,"[",MAIN_CHANNEL,"\\[")\
DEFINITION(CLOSE_BRACKET,"]",MAIN_CHANNEL,"\\]")\
DEFINITION(PLUS,"+",MAIN_CHANNEL,"\\+")\
DEFINITION(MINUS,"-",MAIN_CHANNEL,"\\-")\
DEFINITION(STAR,"*",MAIN_CHANNEL,"\\*")\
DEFINITION(DIVIDE,"/",MAIN_CHANNEL,"/")\
DEFINITION(MODULUS,"%",MAIN_CHANNEL,"%")\
DEFINITION(LESS_THAN,"<",MAIN_CHANNEL,"\\<")\
DEFINITION(LESS_THAN_EQUAL,"<=",MAIN_CHANNEL,"\\<\\=")\
DEFINITION(GREATER_THAN,">",MAIN_CHANNEL,"\\>")\
DEFINITION(GREATER_THAN_EQUAL,">=",MAIN_CHANNEL,"\\>\\=")\
DEFINITION(EQUIVELENT,"==",MAIN_CHANNEL,"\\=\\=")\
DEFINITION(ASSIGN,"=",MAIN_CHANNEL,"\\=")\
DEFINITION(PLUS_ASSIGN,"+=",MAIN_CHANNEL,"\\+\\=")\
DEFINITION(MINUS_ASSIGN,"-=",MAIN_CHANNEL,"\\-\\=")\
DEFINITION(MULTIPLY_ASSIGN,"*=",MAIN_CHANNEL,"\\*\\=")\
DEFINITION(DIVIDE_ASSIGN,"/=",MAIN_CHANNEL,"/\\=")\
DEFINITION(MODULUS_ASSIGN,"%=",MAIN_CHANNEL,"%\\=")\
DEFINITION(AND_ASSIGN,"&=",MAIN_CHANNEL,"\\&\\=")\
DEFINITION(OR_ASSIGN,"|=",MAIN_CHANNEL,"\\|\\=")\
DEFINITION(BITWISE_AND,"&",MAIN_CHANNEL,"\\&")\
DEFINITION(BITWISE_OR,"|",MAIN_CHANNEL,"\\|")\
DEFINITION(EXCLUSIVE_OR,"^",MAIN_CHANNEL,"\\^")\
DEFINITION(LOGICAL_AND,"&&",MAIN_CHANNEL,"\\&\\&")\
DEFINITION(LOGICAL_OR,"||",MAIN_CHANNEL,"\\|\\|")\
DEFINITION(DOT,".",MAIN_CHANNEL,"\\.")\
DEFINITION(ARROW,"->",MAIN_CHANNEL,"\\-\\>")\
DEFINITION(COMMA,",",MAIN_CHANNEL,"\\,")\
DEFINITION(COLON,":",MAIN_CHANNEL,"\\:")\
DEFINITION(ACCESSOR,"::",MAIN_CHANNEL,"\\:\\:")\
DEFINITION(SEMICOLON,";",MAIN_CHANNEL,"\\;")\
DEFINITION(INCREMENT, "++",MAIN_CHANNEL,"\\+\\+")\
DEFINITION(DECREMENT, "--",MAIN_CHANNEL,"\\-\\-")\
DEFINITION(LITERAL_INTEGER, "Integer Literal", MAIN_CHANNEL,"[0-9]+")\
DEFINITION(LITERAL_DOUBLE, "Double Literal", MAIN_CHANNEL,"[0-9]*\\.[0-9]+")\
DEFINITION(LITERAL_FlOAT, "Float Literal", MAIN_CHANNEL,"[0-9]*\\.[0-9]+f")\
DEFINITION(LITERAL_STRING, "String Literal", MAIN_CHANNEL,"\"((\\\")|[^\"])*\"")\
DEFINITION(IDENTIFIER, "Identifier", MAIN_CHANNEL,"[_a-zA-Z][_a-zA-Z0-9]*")\


namespace zr
{

    namespace parsing
    {
        enum TokenType
        {
#define DEFINITION(token, prettyName, channel, regex) token,
            TOKEN_DEFINITIONS(DEFINITION)
#undef DEFINITION
            END_OF_FILE,
            INVALID_TOKEN,
            NO_TOKEN,
        };

        enum TokenChannel
        {
            MAIN_CHANNEL,
            METADATA_CHANNEL,
            DROP_CHANNEL
        };
        class Token
        {
        private:
            TokenType _type;
            TextSpan _span;
            uint64_t _streamPosition;
            uint64_t _streamLength;
            std::string _text;

        public:
            Token(TokenType type, TextSpan span, uint64_t streamPosition, uint64_t streamLength, const std::string& text);
            TokenType type() const;
            const TextSpan& span() const;
            uint64_t streamPosition() const;
            uint64_t streamLength() const;
            uint64_t streamEndPosition() const;
            const std::string& text() const;
            TokenChannel channel() const;

            bool operator==(TokenType other) const;
            bool operator!=(TokenType other) const;
        };

        TokenChannel tokenTypeChannel(TokenType type);
    } // parsing
} // zr

#endif //ZIRCONIUM_TOKENIZER_H
