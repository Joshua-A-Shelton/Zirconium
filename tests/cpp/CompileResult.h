#ifndef ZIRCONIUM_COMPILERESULT_H
#define ZIRCONIUM_COMPILERESULT_H
#include <string>
#include <vector>

#include <zr/Messages/CompilerMessage.h>

class CompileResult
{
private:
    int _exitCode;
    std::string _output;
public:
    CompileResult(int exitCode, std::string&& output);
    CompileResult(int exitCode, std::string& output);
    int exitCode() const;
    const std::string& output() const;
    std::vector<zr::CompilerMessage> compilerMessages() const;
};

#endif //ZIRCONIUM_COMPILERESULT_H