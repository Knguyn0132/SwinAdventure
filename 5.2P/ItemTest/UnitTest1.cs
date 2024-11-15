using _5._2P;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Numerics;

namespace ItemTest
{
    [TestFixture]
    public class Tests
    {
        private Item _sword;

        [SetUp]
        public void Setup()
        {
            _sword = new Item(new string[] { "sword", "blade" }, "Excalibur", "A strong sword");
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            Assert.IsTrue(_sword.AreYou("sword"), "Item should be identifiable as 'sword'");
            Assert.IsTrue(_sword.AreYou("blade"), "Item should be identifiable as 'blade'");
        }

        [Test]
        public void TestShortDescription()
        {
            Assert.AreEqual("Excalibur (sword)", _sword.ShortDescription);
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.AreEqual("A strong sword", _sword.FullDescription);
        }

        [Test]
        public void TestPrivilegeEscalation()
        {
            string correctPin = "2183";
            string expectedFirstId = "7";
            _sword.PrivilegeEscalation(correctPin);
            Assert.AreEqual(expectedFirstId, _sword.FirstId);

        }
    }
}