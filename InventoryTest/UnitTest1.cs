using _10._1C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Numerics;


namespace InventoryTest
{
    [TestFixture]
    public class Tests
    {
        private Inventory _inventory;
        private Item _sword;
        private Item _shield;

        [SetUp]
        public void Setup()
        {
            _inventory = new Inventory();
            _sword = new Item(new string[] { "sword", "blade" }, "Excalibur", "A strong sword");
            _shield = new Item(new string[] { "shield", "safeguard" }, "Aegis", "A strong shield");
        }

        [TestCase]
        public void TestFindItem()
        {
            _inventory.Put(_sword);
            Assert.IsTrue(_inventory.HasItem("sword"));
        }

        [TestCase]
        public void TestNoItemFind()
        {
            Assert.IsFalse(_inventory.HasItem("spear"));
        }

        [TestCase]
        public void TestFetchItem()
        {
            _inventory.Put(_sword);
            Item fetchedItem = _inventory.Fetch("sword");
            Assert.AreEqual(_sword, fetchedItem);
            Assert.IsTrue(_inventory.HasItem("sword"));
        }

        [TestCase]
        public void TestTakeItem()
        {
            _inventory.Put(_shield);
            Item takenItem = _inventory.Take("shield");
            Assert.AreEqual(takenItem, _shield);
            Assert.IsFalse(_inventory.HasItem("shield"), "Inventory should not contain the shield because it has been taken");

        }

        [TestCase]
        public void TestItemList()
        {
            _inventory.Put(_sword);
            _inventory.Put(_shield);
            string expectedList = "\tExcalibur\n\tAegis";
            Assert.AreEqual(expectedList, _inventory.ItemList);
        }
    }
}