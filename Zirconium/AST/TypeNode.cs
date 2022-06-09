using Antlr4.Runtime;

namespace Zirconium.AST
{
    public class TypeNode: AbstractNode
    {
        public string Type { get; private set; }
        public string NameSpaceQualifier { get; private set; }
        public bool IsVoid { get; set;  }
        public TypeNode(string given, string file, IToken first, IToken last) : base(file, first, last)
        {
            if (given.Contains(':'))
            {
                var splits = given.Split(':');
                NameSpaceQualifier = splits[0];
                Type = splits[1];
            }
            else
            {
                Type = given;
            }

            if (Type == "void")
            {
                IsVoid = true;
            }
        }
    }
}