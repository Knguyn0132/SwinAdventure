using _10._1C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Numerics;

namespace LookCommandTest
{
    [TestFixture]
    public class Tests
    {
        private Bag _bag;
        private Item _item;
        private Player _player;

        [SetUp]
        public void Setup()
        {
            _bag = new Bag(new string[] { "backpack" }, "Backpack", "very gud backpack");
            _item = new Item(new string[] { "diamond" }, "Diamond", "shiny diamond");
            _player = new Player("Nevan", "a desparate programmer");
        }

        [TestCase]
        public void TestLookAtMe()
        {
            LookCommand look = new LookCommand();
            string expectedDescription = look.Execute(_player, new string[] { "look", "at", "inventory" });
            Assert.AreEqual(_player.FullDescription, expectedDescription);
        }

        [TestCase]
        public void TestLookAtGem()
        {
            LookCommand look = new LookCommand();
            _player.Inventory.Put(_item);
            string result = look.Execute(_player, new string[] { "look", "at", "diamond" });
            Assert.AreEqual(_item.FullDescription, result);
        }

        [TestCase]
        public void TestLookAtUnk()
        {
            LookCommand look = new LookCommand();
            string result = look.Execute(_player, new string[] { "look", "at", "diamond" });
            Assert.AreEqual("I cannot find the diamond in Nevan", result);
        }

        [TestCase]
        public void TestLookAtGemInMe()
        {
            _player.Inventory.Put(_item);
            LookCommand look = new LookCommand();
            string expectedDescription = look.Execute(_player, new string[] { "look", "at", "diamond", "in", "inventory" });
            Assert.AreEqual(_item.FullDescription, expectedDescription);
        }

        [TestCase]
        public void TestLookAtGemInBag()
        {
            _player.Inventory.Put(_bag);
            _bag.Inventory.Put(_item);
            LookCommand look = new LookCommand();
            string expectedDescription = look.Execute(_player, new string[] { "look", "at", "diamond", "in", "backpack" });
            Assert.AreEqual(_item.FullDescription, expectedDescription);
        }

        [TestCase]
        public void TestLookAtGemInNoBag()
        {
            //_player.Inventory.Put(_bag);
            _bag.Inventory.Put(_item);
            LookCommand look = new LookCommand();
            string expectedDescription = look.Execute(_player, new string[] { "look", "at", "diamond", "in", "backpack" });
            Assert.AreEqual("I cannot find the backpack", expectedDescription);
        }

        [TestCase]
        public void TestLookAtNoGemInNBag()
        {
            _player.Inventory.Put(_bag);
            //_bag.Inventory.Put(_item);
            LookCommand look = new LookCommand();
            string expectedDescription = look.Execute(_player, new string[] { "look", "at", "diamond", "in", "backpack" });
            Assert.AreEqual("I cannot find the diamond in Backpack", expectedDescription);
        }

        [TestCase]
        public void TestInvalidLook() //
        {
            LookCommand look = new LookCommand();
            string expectedDescription = look.Execute(_player, new string[] { "look", "around" });
            Assert.AreEqual("I don't know how to look like that", expectedDescription);

            expectedDescription = look.Execute(_player, new string[] { "hello", "104772183"});
            Assert.AreEqual("I don't know how to look like that", expectedDescription);

            expectedDescription = look.Execute(_player, new string[] { "look", "at", "Nguyen"});
            Assert.AreEqual("I cannot find the Nguyen in Nevan", expectedDescription);



        }

    }
}