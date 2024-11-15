using _10._1C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Numerics;


namespace CommandProcessorTest
{
    [TestFixture]
    public class CommandProcessorTests
    {

        private CommandProcessor _commandProcessor;
        private Player _player;


        [SetUp]
        public void SetUp()
        {
            _commandProcessor = new CommandProcessor();

            _player = new Player("Nguyen", "A programmer");

            Location mountain1 = new Location(new string[] { "mountain1" }, "Mountain 1", "first mountain");
            Location mountain2 = new Location(new string[] { "mountain2" }, "Mountain 2", "second mountain");
            Item sword = new Item(new string[] { "sword" }, "Excalibur", "a strong sword");
            _player.Inventory.Put(sword);


            Paths pathToMountain1 = new Paths(new string[] { "west" }, "Journey to the West", "path leading West", mountain1);
            Paths pathToMountain2 = new Paths(new string[] { "east" }, "Journey to the East", "path leading East", mountain2);

            _player.Location = mountain1;
            _player.Location = mountain2;
            mountain2.AddPath(pathToMountain1);
            mountain1.AddPath(pathToMountain2);
        }

        [Test]
        public void TestValidLookCommand()
        {
            // Arrange
            string input = "look at sword in inventory";
            string expectedResponse = "a strong sword";

            // Act
            string response = _commandProcessor.ExecuteCommand(input, _player);

            // Assert
            Assert.AreEqual(expectedResponse, response);
        }

        [Test]
        public void TestValidMoveCommand()
        {
            // Arrange
            string input = "move west";
            string expectedResponse = "You move west to Mountain 1.";

            // Act
            string response = _commandProcessor.ExecuteCommand(input, _player);

            // Assert
            Assert.AreEqual(expectedResponse, response);
            Assert.AreEqual("Mountain 1", _player.Location.Name);
        }

        [Test]
        public void TestUnknownCommand()
        {
            // Arrange
            string input = "fly";
            string expectedResponse = "Unknown command: fly";

            // Act
            string response = _commandProcessor.ExecuteCommand(input, _player);

            // Assert
            Assert.AreEqual(expectedResponse, response);
        }

        [Test]
        public void TestEmptyCommand()
        {
            // Arrange
            string input = ""; // Empty command string
            string expectedResponse = "Invalid command.";

            // Act
            string response = _commandProcessor.ExecuteCommand(input, _player);

            // Assert
            Assert.AreEqual(expectedResponse, response);
        }
    }

}