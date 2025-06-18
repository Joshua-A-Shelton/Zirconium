#include "CompileResult.h"

CompileResult::CompileResult(int exitCode, std::string&& output)
{
    _exitCode = exitCode;
    _output = std::move(output);
}

CompileResult::CompileResult(int exitCode, std::string& output)
{
    _exitCode = exitCode;
    _output = output;
}

int CompileResult::exitCode() const
{
    return _exitCode;
}

const std::string& CompileResult::output() const
{
    return _output;
}

std::vector<zr::CompilerMessage> CompileResult::compilerMessages() const
{
    std::vector<zr::CompilerMessage> messages;
    size_t cursor = 0;
    while (cursor < _output.size())
    {
        if (_output[cursor] == '{')
        {
            uint64_t readLength = 0;
            messages.push_back(zr::CompilerMessage::fromString(_output,cursor,&readLength));
            cursor += readLength;
        }
        else
        {
            cursor++;
        }
    }
    return messages;
}
