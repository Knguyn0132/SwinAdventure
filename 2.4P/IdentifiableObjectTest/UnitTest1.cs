using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2._4P;
using NUnit.Framework;


namespace NUnitTests
{
    [TestFixture]
    public class TestIdentifiableObject
    {
        private IdentifiableObject _objectIdentifier; 
        private IdentifiableObject _emptyObjectIdentifier;
        private IdentifiableObject _objectIdentifierNoStuId;

        [SetUp]
        public void SetUp()
        {
            _objectIdentifier = new IdentifiableObject(new string[] { "104772183", "Khoi Nguyen", "Pham" });
            _emptyObjectIdentifier = new IdentifiableObject(new string[] { });
            _objectIdentifierNoStuId = new IdentifiableObject(new string[] { "1111", "Khoi Nguyen", "Pham" });
        }

        [TestCase]
        public void TestAreYou()
        {
            Assert.IsTrue(_objectIdentifier.AreYou("104772183"));
            Assert.IsTrue(_objectIdentifier.AreYou("Khoi Nguyen"));
        }

        [TestCase]
        public void TestNotAreYou()
        {
            Assert.IsFalse(_objectIdentifier.AreYou("nonexistent identifier"));
        }

        

        [TestCase]
        public void TestFirstId()
        {
            Assert.AreEqual("104772183", _objectIdentifier.FirstId);
        }

        [TestCase]
        public void TestFirstIdWithNoId()
        {
            Assert.AreEqual("", _emptyObjectIdentifier.FirstId);
        }

        [TestCase]
        public void TestAddId()
        {
            _objectIdentifier.AddIdentifier("Nevan");
            Assert.IsTrue(_objectIdentifier.AreYou("Nevan"));
        }

        [TestCase]
        public void TestCaseSensitivity()
        {
            Assert.IsTrue(_objectIdentifier.AreYou("khOI NGUyEN"));
            Assert.IsTrue(_objectIdentifier.AreYou("PhAM"));
        }

        [TestCase]
        public void TestPrivilegeEscalation()
        {
            

                string correctPin = "2183"; 
                string expectedFirstId = "7";


            _objectIdentifierNoStuId.PrivilegeEscalation(correctPin);

            // Assert
            Assert.AreEqual(expectedFirstId, _objectIdentifierNoStuId.FirstId);
        }
    }


        

}

