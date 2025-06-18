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
            if (std::regex_search(code.begin()+cursor, code.end(),match, _regex,std::regex_constants::match_continuous))
            {
                auto text = match.str();
                uint64_t endLine = line;
                uint64_t endColumn = column;
                for (int i=0; i<text.size(); i++)
                {
                    endColumn++;
                    //account of UTF8 encoding
                    unsigned char curByte = text[i];
                    if ((curByte & 0b11110000) == 0b11110000)
                    {
                        i+=3;
                        continue;
                    }
                    else if ((curByte & 0b11100000) == 0b11100000)
                    {
                        i+=2;
                        continue;
                    }
                    else if ((curByte & 0b11000000) == 0b11000000)
                    {
                        i+=1;
                        continue;
                    }
                    //end UTF8
                    //check for newline
                    if (text[i] == '\n')
                    {
                        endLine++;
                        endColumn = 1;
                    }
                }
                return Token(_type,TextSpan(line,column,endLine,endColumn),cursor,text.length(),text);
            }
            return Token(TokenType::NO_TOKEN,TextSpan(0,0,0,0),0,0,"");
        }
    } // parsing
} // zr
