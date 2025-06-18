#ifndef ZIRCONIUM_TESTINGUTILITIES_H
#define ZIRCONIUM_TESTINGUTILITIES_H
#include <filesystem>

#include "CompileResult.h"

class TestingUtilities
{
public:
    static CompileResult compile(const std::string& arguments);
};


#endif //ZIRCONIUM_TESTINGUTILITIES_H