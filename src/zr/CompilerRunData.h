#ifndef ZIRCONIUM_COMPILERRUNDATA_H
#define ZIRCONIUM_COMPILERRUNDATA_H
#include <vector>

#include "Messages/CompilerMessage.h"

namespace zr
{
    class CompilerRunData
    {
    private:
        std::vector<CompilerMessage> _messages;
    public:
        void addMessage(const CompilerMessage& message);
        const std::vector<CompilerMessage>& messages() const;
    };
} // zr

#endif //ZIRCONIUM_COMPILERRUNDATA_H
