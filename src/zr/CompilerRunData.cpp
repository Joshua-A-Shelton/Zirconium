#include "CompilerRunData.h"

namespace zr
{
    void CompilerRunData::addMessage(const CompilerMessage& message)
    {
        _messages.push_back(message);
    }

    const std::vector<CompilerMessage>& CompilerRunData::messages() const
    {
        return _messages;
    }
} // zr
