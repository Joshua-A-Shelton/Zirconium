using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zrc.Build
{
    public class StubNamespace: IContext
    {
        public string Name { get; private set; }
        
        public StubNamespace(string fullyQualified)
        {
            Name = fullyQualified;
        }
        
    }
}