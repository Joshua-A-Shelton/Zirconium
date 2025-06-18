

#include "TextLocation.h"

namespace zr {
    TextLocation::TextLocation(uint64_t line, uint64_t column)
    {
        _line = line;
        _column = column;
    }

    uint64_t TextLocation::line() const
    {
        return _line;
    }

    uint64_t TextLocation::column() const
    {
        return _column;
    }

    bool TextLocation::operator==(const TextLocation& other) const
    {
        return _line == other._line && _column == other._column;
    }

    bool TextLocation::operator!=(const TextLocation& other) const
    {
        return _line != other._line || _column != other._column;
    }

    bool TextLocation::operator<(const TextLocation& other) const
    {
        if (_line < other._line)
        {
            return true;
        }
        else if (_line == other._line)
        {
            return _column < other._column;
        }
        return false;
    }

    bool TextLocation::operator>(const TextLocation& other) const
    {
        if (_line > other._line)
        {
            return true;
        }
        else if (_line == other._line)
        {
            return _column > other._column;
        }
        return false;
    }

    bool TextLocation::operator<=(const TextLocation& other) const
    {
        if (_line < other._line)
        {
            return true;
        }
        else if (_line == other._line)
        {
            return _column <= other._column;
        }
        return false;
    }

    bool TextLocation::operator>=(const TextLocation& other) const
    {
        if (_line > other._line)
        {
            return true;
        }
        else if (_line == other._line)
        {
            return _column >= other._column;
        }
        return false;
    }

    TextSpan::TextSpan(TextLocation start, TextLocation end):_start(start),_end(end){}

    TextSpan::TextSpan(uint64_t startLine, uint64_t startColumn, uint64_t endLine, uint64_t endColumn):_start(startLine,startColumn),_end(endLine,endColumn){}

    TextLocation TextSpan::start() const
    {
        return _start;
    }

    TextLocation TextSpan::end() const
    {
        return _end;
    }

    std::string TextSpan::toString() const
    {
        return (std::string("(line: "+_start.line())+(", column: "+_start.column())+(")-(line: "+_end.line())+(", column: "+_end.column())+")");
    }
} // zr