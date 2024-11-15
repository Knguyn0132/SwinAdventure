using _10._1C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Numerics;

namespace LocationTest
{
    [TestFixture]
    public class Tests
    {
        private Location _location;
        private Item _sword;
        private Player _player;

        [SetUp]
        public void Setup()            
        {
            _sword = new Item(new string[] { "sword" }, "Excalibur", "a strong sword");
            _player = new Player("Nevan", "a human");
            _location = new Location(new string[] { "classroom" }, "EN310", "Swinburne's classroom");
            _location.Inventory.Put(_sword);
            
        }

        [TestCase]
        public void TestLocationsIdentifyThemselves()
        {
            Assert.IsTrue(_location.AreYou("classroom"));
        }

        [TestCase]
        public void TestLocationsCanLocateItems()
        {
            Assert.AreEqual(_sword, _location.Locate("sword"));
        }

        [TestCase]
        public void TestPlayerCanLocateItemInLocation()
        {
            _player.Location = _location; //player in a location that has a sword, so don't necessary need to have sword in inventory
            //_player.Inventory.Put(_sword);
            Assert.AreEqual(_sword, _player.Locate("sword"));
        }
    }
}