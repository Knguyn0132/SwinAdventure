using _10._1C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Numerics;

namespace PathTest
{    

    [TestFixture]
    public class Tests
    {
        private Location _mountain1;
        private Location _mountain2;
        private Player _player;
        private Item _sword;
        private MoveCommand _moveCommand;
        private Paths _pathToMountain1;
        private Paths _pathToMountain2;
        [SetUp]
        public void Setup()
        {

            _mountain1 = new Location(new string[] { "mountain1" }, "Mountain 1", "first mountain");
            _mountain2 = new Location(new string[] { "mountain2" }, "Mountain 2", "second mountain");
            _sword = new Item(new string[] { "sword" }, "Excalibur", "a strong sword");
            _mountain1.Inventory.Put(_sword);


            _pathToMountain1 = new Paths(new string[] { "west" }, "Journey to the West", "path leading West", _mountain1);
            _pathToMountain2 = new Paths(new string[] { "east" }, "Journey to the East", "path leading East", _mountain2);

            _mountain1.AddPath(_pathToMountain2);
            _mountain2.AddPath(_pathToMountain1);
            _player = new Player("Wukong", "The monkey");
            _player.Location = _mountain1;

            
            _moveCommand = new MoveCommand();
        }

        [Test]
        public void TestPathCanMovePlayer()
        {
            string result = _moveCommand.Execute(_player, new string[] { "move", "east" });
            Assert.AreEqual(_mountain2, _player.Location);
            
        }

        [Test]
        public void TestGetPathFromLocation()
        {
            Paths path = _mountain1.GetPath("east");
            Assert.IsNotNull(path);
            Assert.AreEqual(_mountain2, path.Destination);
        }

        [Test]
        public void TestPlayerCanLeaveLocation()
        {
            _moveCommand.Execute(_player, new string[] { "head", "east" });
            Assert.AreEqual(_mountain2, _player.Location);


        }

        [Test]
        public void TestPlayerRemainInLocation()
        {
            _moveCommand.Execute(_player, new string[] { "head", "north" });
            Assert.AreNotEqual(_mountain2, _player.Location);
        }
    }
}