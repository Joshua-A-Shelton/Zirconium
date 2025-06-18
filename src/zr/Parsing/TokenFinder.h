#ifndef ZIRCONIUM_TOKENFINDER_H
#define ZIRCONIUM_TOKENFINDER_H
#include <regex>

#include "Token.h"

namespace zr
{
    namespace parsing
    {
        class TokenFinder
        {
        public:
            TokenFinder(const std::string& regex,TokenType tokenType);
            Token find(const std::string& code, uint64_t cursor, uint64_t line, uint64_t column);
        private:
            std::regex _regex;
            TokenType _type;
        };
    } // parsing
} // zr

#endif //ZIRCONIUM_TOKENFINDER_H
