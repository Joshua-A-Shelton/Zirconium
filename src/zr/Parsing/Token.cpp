#include "Token.h"

namespace zr
{
    namespace parsing
    {
        Token::Token(TokenType type, TextSpan span, uint64_t streamPosition, uint64_t streamLength, const std::string& text):_type(type),_span(span),_streamPosition(streamPosition),_streamLength(streamLength),_text(text){}

        TokenType Token::type() const
        {
            return _type;
        }

        const TextSpan& Token::span() const
        {
            return _span;
        }

        uint64_t Token::streamPosition() const
        {
            return _streamPosition;
        }

        uint64_t Token::streamLength() const
        {
            return _streamLength;
        }

        uint64_t Token::streamEndPosition() const
        {
            return _streamPosition + _streamLength;
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
