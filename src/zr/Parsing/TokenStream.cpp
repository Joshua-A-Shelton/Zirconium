#include "TokenStream.h"

#include <fstream>
#include <stdexcept>

#include "TokenFinder.h"

namespace zr
{
    namespace parsing
    {
        std::vector<TokenFinder> TOKEN_FINDERS
        {
        #define DEFINITION(token, prettyName, channel, regex) TokenFinder(regex,token),
            TOKEN_DEFINITIONS(DEFINITION)
        #undef DEFINITION
        };


        void TokenStream::move(TokenStream& other)
        {
            _tokens.swap(other._tokens);
            _cursor = other._cursor;
        }

        TokenStream::TokenStream(const std::filesystem::path& filePath, CompilerRunData& compileData)
        {
            std::ifstream file(filePath);
            std::stringstream fileBuffer;
            fileBuffer << file.rdbuf();
            const std::string code = fileBuffer.str();
            file.close();

            uint64_t currentCursor = 0;
            uint64_t currentLine = 1;
            uint64_t currentColumn = 1;
            std::vector<Token> unexpectedTokens;
            while (currentCursor < code.size())
            {
                Token best(TokenType::NO_TOKEN,TextSpan(1,1,1,1),0,0,"");
                for (auto& finder : TOKEN_FINDERS)
                {
                    auto found = finder.find(code,currentCursor,currentLine,currentColumn);
                    if (found != TokenType::NO_TOKEN)
                    {
                        if (found.span().end() > best.span().end())
                        {
                            best = found;
                        }
                        else if (found.span().end() == best.span().end() && best == TokenType::IDENTIFIER)
                        {
                            best = found;
                        }
                    }
                }
                if (best == TokenType::NO_TOKEN)
                {
                    char composedString[5] = {'\0'};
                    composedString[0] = code[currentCursor];
                    uint64_t codePointLength = 1;
                    if ((code[currentCursor] & 0b11110000) == 0b11110000)
                    {
                        codePointLength=4;
                    }
                    else if ((code[currentCursor] & 0b11100000) == 0b11100000)
                    {
                        codePointLength=3;
                    }
                    else if ((code[currentCursor] & 0b11000000) == 0b11000000)
                    {
                        codePointLength=2;
                        continue;
                    }

                    unexpectedTokens.push_back(Token(TokenType::INVALID_TOKEN,TextSpan(currentLine,currentColumn,currentLine,currentColumn+1),currentCursor,codePointLength,composedString));
                    currentColumn++;
                    currentCursor+=codePointLength;
                }
                else
                {
                    if (!unexpectedTokens.empty())
                    {
                        std::string allText;
                        for (auto i=0; i<unexpectedTokens.size(); i++)
                        {
                            allText+=unexpectedTokens[i].text();
                        }
                        _tokens.push_back(Token(TokenType::INVALID_TOKEN,TextSpan(unexpectedTokens[0].span().start(),unexpectedTokens[unexpectedTokens.size()-1].span().end()),unexpectedTokens[0].streamPosition(),allText.length(),allText));
                        compileData.addMessage(CompilerMessage::InvalidToken(absolute(filePath).string(),_tokens.back()));
                        unexpectedTokens.clear();
                    }
                    if (tokenTypeChannel(best.type()) != TokenChannel::DROP_CHANNEL)
                    {
                        _tokens.push_back(best);
                    }
                    currentLine = best.span().end().line();
                    currentColumn = best.span().end().column();
                    currentCursor+=best.text().size();
                }
            }
            if (!unexpectedTokens.empty())
            {
                std::string allText;
                for (auto i=0; i<unexpectedTokens.size(); i++)
                {
                    allText+=unexpectedTokens[i].text();
                }
                _tokens.push_back(Token(TokenType::INVALID_TOKEN,TextSpan(unexpectedTokens[0].span().start(),unexpectedTokens[unexpectedTokens.size()-1].span().end()),unexpectedTokens[0].streamPosition(),allText.length(),allText));
                compileData.addMessage(CompilerMessage::InvalidToken(absolute(filePath).string(),_tokens.back()));
                unexpectedTokens.clear();
            }
        }

        TokenStream::TokenStream(TokenStream&& from)
        {
            move(from);
        }

        TokenStream& TokenStream::operator=(TokenStream&& from)
        {
            move(from);
            return *this;
        }

        Token TokenStream::next()
        {
            if (_cursor >= _tokens.size())
            {
                if (_tokens.empty())
                {
                    return Token(END_OF_FILE,TextSpan(1,1,1,1),0,0,"");
                }
                auto& lastToken = _tokens.back();
                return Token(END_OF_FILE,TextSpan(lastToken.span().end(),lastToken.span().end()),lastToken.streamEndPosition(),0,"");
            }
            auto& token = _tokens[_cursor];
            return _tokens[_cursor++];
        }

        Token TokenStream::peek()
        {
            if (_cursor >= _tokens.size())
            {
                if (_tokens.empty())
                {
                    return Token(END_OF_FILE,TextSpan(1,1,1,1),0,0,"");
                }
                auto& lastToken = _tokens.back();
                return Token(END_OF_FILE,TextSpan(lastToken.span().end(),lastToken.span().end()),lastToken.streamEndPosition(),0,"");
            }
            return _tokens[_cursor];
        }

        void TokenStream::seek(size_t pos)
        {
            if (pos <= _tokens.size())
            {
                _cursor = pos;
            }
            else
            {
                throw std::out_of_range("TokenStream::seek");
            }
        }
    }
} // zr
