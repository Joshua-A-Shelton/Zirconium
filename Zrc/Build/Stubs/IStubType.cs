using System.Collections.Generic;
using Zrc.Util;

namespace Zrc.Build
{
    public interface IStubType: IMangleable
    {
        public IReadOnlyList<string> GenericSymbols { get; }
    }
}