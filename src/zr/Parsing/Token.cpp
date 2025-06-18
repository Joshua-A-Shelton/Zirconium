#include "Token.h"

namespace zr
{
    namespace parsing
    {
        Token::Token(TokenType type, TextSpan span, const std::string& text):_type(type),_span(span),_text(text){}

        TokenType Token::type() const
        {
            return _type;
        }

        const TextSpan& Token::span() const
        {
            return _span;
        }

        const std::string& Token::text() const
        {
            return _text;
        }

        TokenChannel Token::channel() const
        {
            return tokenTypeChannel(_type);
        }

        bool Token::operator==(TokenType other) const
        {
            return _type == other;
        }

        bool Token::operator!=(TokenType other) const
        {
            return _type != other;
        }

        TokenChannel tokenTypeChannel(TokenType type)
        {
            switch (type)
            {
#define DEFINITION(token, prettyName, channel, regex) case token: return channel;
                TOKEN_DEFINITIONS(DEFINITION)
    #undef DEFINITION
                default:
                    return TokenChannel::DROP_CHANNEL;
            }
        }
    } // parsing
} // zr
