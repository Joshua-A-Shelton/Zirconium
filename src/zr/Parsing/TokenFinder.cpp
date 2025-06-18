#include "TokenFinder.h"

namespace zr
{
    namespace parsing
    {
        TokenFinder::TokenFinder(const std::string& regex, TokenType tokenType)
        {
            _regex = regex;
            _type = tokenType;
        }

        Token TokenFinder::find(const std::string& code, uint64_t cursor, uint64_t line, uint64_t column)
        {
            std::smatch match;
            if (std::regex_match(code.begin()+cursor, code.end(),match, _regex,std::regex_constants::match_continuous))
            {
                auto text = match.str();
                uint64_t endLine = line;
                uint64_t endColumn = column;
                for (int i=0; i<text.size(); i++)
                {
                    endColumn++;
                    if (text[i] == '\n')
                    {
                        endLine++;
                        endColumn = 0;
                    }
                }
                return Token(_type,TextSpan(line,column,endLine,endColumn),text);
            }
            return Token(TokenType::NO_TOKEN,TextSpan(0,0,0,0),"");
        }
    } // parsing
} // zr
