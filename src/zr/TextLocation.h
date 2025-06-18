#ifndef ZIRCONIUM_TEXTLOCATION_H
#define ZIRCONIUM_TEXTLOCATION_H
#include <cstdint>
#include <string>

namespace zr
{
    class TextLocation
    {
    private:
        uint64_t _line;
        uint64_t _column;
    public:
        TextLocation(uint64_t line, uint64_t column);
        uint64_t line() const;
        uint64_t column() const;

        bool operator==(const TextLocation& other) const;
        bool operator!=(const TextLocation& other) const;
        bool operator<(const TextLocation& other) const;
        bool operator>(const TextLocation& other) const;
        bool operator<=(const TextLocation& other) const;
        bool operator>=(const TextLocation& other) const;
    };

    class TextSpan
    {
    private:
        TextLocation _start;
        TextLocation _end;
    public:
        TextSpan(TextLocation start, TextLocation end);
        TextSpan(uint64_t startLine, uint64_t startColumn, uint64_t endLine, uint64_t endColumn);
        TextLocation start() const;
        TextLocation end() const;
        std::string toString() const;
    };
} // zr

#endif //ZIRCONIUM_TEXTLOCATION_H
