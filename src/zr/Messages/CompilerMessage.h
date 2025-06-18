#ifndef ZIRCONIUM_COMPILERMESSAGE_H
#define ZIRCONIUM_COMPILERMESSAGE_H
#include <string>
#include "../TextLocation.h"
#include "../Parsing/Token.h"

namespace zr
{
    enum CompilerMessageType
    {
        INFORMATION,
        WARNING,
        ERROR
    };

    enum CompilerMessageID
    {
        INVALID_TOKEN,
    };

    class CompilerMessage
    {
    private:
        CompilerMessageType _type;
        CompilerMessageID _id;
        std::string _location;
        std::string _message;
        TextSpan _span;
        CompilerMessage(CompilerMessageType type, CompilerMessageID id, const std::string& location,const TextSpan& span, const std::string& message);

    public:
        CompilerMessageType type() const;
        CompilerMessageID id() const;
        std::string location() const;
        std::string message() const;
        TextSpan span() const;

        std::string toString()const;
        static CompilerMessage fromString(const std::string& message);
        static CompilerMessage fromString(const std::string& message, size_t start, size_t* readLength);
        static CompilerMessage InvalidToken(const std::string& location, const parsing::Token& invalidToken);
    };
} // zr

#endif //ZIRCONIUM_COMPILERMESSAGE_H