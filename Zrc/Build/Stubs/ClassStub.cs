using System.Collections.Generic;
using System.Text;
using Zrc.Util;

namespace Zrc.Build
{
    public class ClassStub: IStubType, IContext
    {
        public StubNamespace? InNamespace { get; private set; }

        public string Name { get; private set; }

        private List<string> _genericSymbols = new List<string>();
        public IReadOnlyList<string> GenericSymbols
        {
            get { return _genericSymbols; }
        }
        

        private List<Accessible<IStubType>> _members;
    }
}