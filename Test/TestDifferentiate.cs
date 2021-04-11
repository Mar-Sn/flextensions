using System.Collections.Generic;
using System.Linq;
using Flextensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class TestDifferentiate
    {
        [TestMethod]
        public void TestOversize()
        {
            var a = new List<int> { 1, 2, 3, 4 };
            var b = new List<int> { 1, 2, 3, 4, 5, 6 };

            var missing = a.Differ(b, e => e);

            var left = missing.Item1.ToList();
            var right = missing.Item2.ToList();

            Assert.AreEqual(2, left.Count);
            Assert.AreEqual(0, right.Count);

            Assert.AreEqual(5, left[0]);
            Assert.AreEqual(6, left[1]);
        }

        [TestMethod]
        public void TestUndersize()
        {
            var a = new List<int> { 1, 2, 3, 4, 5, 6 };
            var b = new List<int> { 1, 2, 3, 4 };

            var missing = a.Differ(b, e => e);

            var left = missing.Item1.ToList();
            var right = missing.Item2.ToList();


            Assert.AreEqual(0, left.Count);
            Assert.AreEqual(2, right.Count);

            Assert.AreEqual(5, right[0]);
            Assert.AreEqual(6, right[1]);
        }
    }
}
