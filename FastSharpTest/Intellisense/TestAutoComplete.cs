using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FastSharpLib.Intellisense;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FastSharpTest.Intellisense
{
    [TestClass]
    public class TestAutoComplete
    {
        private INode Root { get; set; }

        private IAutoComplete AutoComplete { get; set; }

        [TestInitialize]
        public void Setup()
        {
            Root = Node.CreateRoot();
            AutoComplete = new AutoComplete(Root);
        }

        [TestMethod]
        public void TestRegisterAssembly()
        {
            AutoComplete.ReadAssembly(Assembly.GetAssembly(typeof(AutoComplete)));
            Assert.IsTrue(Root.Children.Count > 0);
        }

        [TestMethod]
        public void TestFindMatches_NamespaceMatch()
        {
            AutoComplete.ReadAssembly(Assembly.GetAssembly(typeof(AutoComplete)));
            Assert.IsTrue(Root.Children.Count > 0);

            IEnumerable<string> matches = AutoComplete.FindMatches("FastSharpLib");
            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Any());

            // deeper type
            matches = AutoComplete.FindMatches("Intellisense");
            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Any());
        }

        [TestMethod]
        public void TestFindMatches_ClassMatch()
        {
            AutoComplete.ReadAssembly(Assembly.GetAssembly(typeof(AutoComplete)));
            Assert.IsTrue(Root.Children.Count > 0);

            IEnumerable<string> matches = AutoComplete.FindExact("StringExtensions");
            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Any());

            matches = AutoComplete.FindExact("NodeEx");
            Assert.IsNotNull(matches);
            Assert.IsTrue(matches.Any());
        }

        [TestMethod]
        public void TestFindMatches_Unknown()
        {
            AutoComplete.ReadAssembly(Assembly.GetAssembly(typeof(AutoComplete)));
            Assert.IsTrue(Root.Children.Count > 0);

            IEnumerable<string> matches = AutoComplete.FindMatches("unknown");
            Assert.IsNotNull(matches);
            Assert.IsFalse(matches.Any());
        }
    }
}