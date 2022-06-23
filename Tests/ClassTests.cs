using NUnit.Framework;
using Zirconium.AST.Statements;

namespace Tests
{
    [TestFixture]
    public class ClassTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestSimpleClass()
        {
            var file = Utilities.Compile("Resources/RealSimpleClass.zr");
            Assert.IsTrue(file.Classes.Count ==1);
            ClassNode simpleclass = file.Classes[0];

        }
    }
}