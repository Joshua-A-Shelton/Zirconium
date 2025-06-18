#include "CompilerMessage.h"

#include <regex>
#include <stdexcept>

namespace zr
{
    CompilerMessage::CompilerMessage(CompilerMessageType type,CompilerMessageID id, const std::string& location,const TextSpan& span, const std::string& message):
        _type(type),
        _id(id),
        _location(location),
        _span(span),
        _message(message)

    {
    }

    CompilerMessageType CompilerMessage::type() const
    {
        return _type;
    }

    CompilerMessageID CompilerMessage::id() const
    {
        return _id;
    }

    std::string CompilerMessage::location() const
    {
        return _location;
    }

    std::string CompilerMessage::message() const
    {
        return _message;
    }

    TextSpan CompilerMessage::span() const
    {
        return _span;
    }

    std::string CompilerMessage::toString() const
    {
        std::string out="{[";
        switch (_type)
        {
            case CompilerMessageType::INFORMATION:
                out += "INFORMATION";
                break;
            case CompilerMessageType::WARNING:
                out += "WARNING";
                break;
            case CompilerMessageType::ERROR:
                out += "ERROR";
                break;
        }
        out += "] ID:"+std::to_string(_id)+" @\""+_location+"\" "+_span.toString() +" "+ _message+"}";
        return out;
    }

    CompilerMessage CompilerMessage::fromString(const std::string& message)
    {
        size_t readLength=0;
        auto cm = fromString(message,0,&readLength);
        if (readLength!=message.size())
        {
            throw std::invalid_argument("message is expected to be total length of the string");
        }
        return cm;
    }

    CompilerMessage CompilerMessage::fromString(const std::string& message, size_t start, size_t* readLength)
    {
        *readLength = 0;
        size_t currentCursor = start;
        std::smatch matches;
        auto startFrom = message.begin() + start;
        auto endAt = message.end();
        std::regex_search(startFrom,endAt,matches,std::regex("^\\{\\[([a-zA-Z]+?)\\] ID:([0-9]+) \\@\\\"(.+?)\\\" \\(line: ([0-9]+), column: ([0-9]+)\\)-\\(line: ([0-9]+), column: ([0-9]+)\\) (.+?)\\}"));
        if (matches.size()==0)
        {
            throw std::invalid_argument("Invalid message format");
        }
        std::string typeText = matches[1];
        std::string idText = matches[2];
        std::string locationText = matches[3];
        std::string startLineText = matches[4];
        std::string startColumnText = matches[5];
        std::string endLineText = matches[6];
        std::string endColumnText = matches[7];
        std::string messageText = matches[8];

        CompilerMessageType type = CompilerMessageType::INFORMATION;

        if (typeText == "INFORMATION")
        {
            type = CompilerMessageType::INFORMATION;
        }
        else if (typeText == "WARNING")
        {
            type = CompilerMessageType::WARNING;
        }
        else if (typeText == "ERROR")
        {
            type = CompilerMessageType::ERROR;
        }
        else
        {
            throw std::invalid_argument("Invalid message type provided");
        }

        CompilerMessageID cid = (CompilerMessageID)std::stoi(idText);

        uint64_t startLine = std::stoull(startLineText);
        uint64_t startColumn = std::stoull(startColumnText);
        uint64_t endLine = std::stoull(endLineText);
        uint64_t endColumn = std::stoull(endColumnText);

        *readLength = matches.length();

        return CompilerMessage(type,cid,locationText,TextSpan(startLine,startColumn,endLine,endColumn),messageText);
    }

    CompilerMessage CompilerMessage::InvalidToken(const std::string& location, const parsing::Token& invalidToken)
    {
        return CompilerMessage(CompilerMessageType::ERROR,CompilerMessageID::INVALID_TOKEN,location,invalidToken.span(),"Encountered invalid Token: '"+invalidToken.text()+"'");
    }
} // zr
