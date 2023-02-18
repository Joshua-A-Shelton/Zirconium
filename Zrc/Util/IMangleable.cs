using System.Collections.Generic;
using Zrc.Build;

namespace Zrc.Util
{
    public interface IMangleable: IFriendlyName
    {
        public string MangledName(IReadOnlyDictionary<string,IStubType> genericsDefinitions);
    }
}