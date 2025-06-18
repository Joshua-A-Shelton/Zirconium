#ifndef ZIRCONIUM_TOKENSTREAM_H
#define ZIRCONIUM_TOKENSTREAM_H
#include <filesystem>
#include <string>
#include <vector>
#include "Token.h"
#include "../CompilerRunData.h"

namespace zr
{
    namespace parsing
    {
        class TokenStream
        {
        private:
            std::vector<Token> _tokens;
            size_t _cursor = 0;
            void move(TokenStream& other);
        public:
            TokenStream(const std::filesystem::path& filePath, CompilerRunData& compileData);
            ~TokenStream()=default;
            TokenStream(const TokenStream&) = delete;
            TokenStream& operator=(const TokenStream&) = delete;
            TokenStream(TokenStream&& from);
            TokenStream& operator=(TokenStream&& from);
            Token next();
            Token peek();
            void seek(size_t pos);

        };
    }
} // zr

#endif //ZIRCONIUM_TOKENSTREAM_H
