using NUnit.Framework;
using Zrc;

namespace DevelopmentTests
{
    public class BasicTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestFiles()
        {
            Compiler compiler = new Compiler();
            compiler.ParseFile("Resources/BasicTest/Basic.zr");
            compiler.ParseFile("Resources/BasicTest/Consuming.zr");
            compiler.RegisterFileContents();
            compiler.ResolveFileContents();
            int i = 0;
        }

        [Test]
        public void TestGenerics()
        {
            Compiler compiler = new Compiler();
            compiler.ParseFile("Resources/GenericTest/SuperConsumingGenericClass.zr");
            compiler.ParseFile("Resources/GenericTest/HyperConsumingGenericClass.zr");
            compiler.ParseFile("Resources/GenericTest/GenericClass.zr");
            compiler.ParseFile("Resources/GenericTest/ConsumingGenericClass.zr");
            compiler.RegisterFileContents();
            compiler.ResolveFileContents();
            int i = 0;
        }
    }
}