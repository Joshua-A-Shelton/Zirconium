#include "TestingUtilities.h"
#include <array>

CompileResult TestingUtilities::compile(const std::string& arguments)
{

    int i=0;
    if (arguments.empty())
    {
        throw std::invalid_argument("cannot call compiler with no arguments");
    }
    int exitcode = 255;
    std::string result;
    std::array<char, 2048> buffer {};


#ifdef _WIN32
#define popen _popen
#define pclose _pclose
#define WEXITSTATUS
    std::string call = "zrc "+arguments;
#else
    std::string call = "./zrc "+arguments;
#endif
    FILE *pipe = popen(call.c_str(), "r");
    if (pipe == nullptr) {
        throw std::runtime_error("popen() failed!");
    }
    try {
        std::size_t bytesread;
        while ((bytesread = fread(buffer.data(), sizeof(buffer.at(0)), sizeof(buffer), pipe)) != 0) {
            result += std::string(buffer.data(), bytesread);
        }
    } catch (...) {
        pclose(pipe);
        throw;
    }

    exitcode = WEXITSTATUS(pclose(pipe));
    return CompileResult(exitcode, result);
}
