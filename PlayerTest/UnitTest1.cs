using _10._1C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Numerics;

namespace PlayerTest
{
    [TestFixture] //mark a class that contains tests. It tells NUnit that this class should be treated as a test suite.
    public class Tests
    {
        private Player _player;


        [SetUp] //mark a method that should be run before each test method. It’s useful for setting up common test data or state.
        public void Setup()
        {
            _player = new Player("Nevan", "a human");
        }

        [Test] // mark a method inside a [TestFixture] class as a test method. 
        public void TestPlayerIsIdentifiable()
        {
            Assert.IsTrue(_player.AreYou("me"));
            Assert.IsTrue(_player.AreYou("inventory"));
        }

        [Test]
        public void TestPlayerLocatesItem()
        {
            Item sword = new Item(new string[] { "sword", "blade" }, "Excalibur", "A strong sword");
            _player.Inventory.Put(sword);
            Assert.AreEqual(sword, _player.Locate("sword"));
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            Assert.AreEqual(_player, _player.Locate("me"));
        }

        [Test]
        public void TestLocatesNothing()
        {
            Assert.IsNull(_player.Locate("sth not exist"));
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            Item sword = new Item(new string[] { "sword", "blade" }, "Excalibur", "A strong sword");
            _player.Inventory.Put(sword);
            Assert.AreEqual("You are Nevan, a human\nYou are carrying:\n\tExcalibur (sword)\n", _player.FullDescription);
        }


    }
}