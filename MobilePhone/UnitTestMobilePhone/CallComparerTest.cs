using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone.CommonUtilities;
using MobilePhone;

namespace UnitTestMobilePhone {
    [TestClass]
    public class CallComparerTest {
        [TestMethod]
        public void CallsEqual() {
            Call callOne = new Call(Direction.Incoming, DateTime.Now, new Contact("Dart", "Spring", 20, "+380931234568"));
            Call callTwo = new Call(Direction.Incoming, DateTime.Now.AddSeconds(3), new Contact("Dart", "Spring", 20, "+380931234568"));
            Assert.IsTrue(callOne.Equals(callTwo));
        }

        [TestMethod]
        public void CallsNotEqualByDirection() {
            Call callOne = new Call(Direction.Outgoing, DateTime.Now, new Contact("Dart", "Spring", 20, "+380931234568"));
            Call callTwo = new Call(Direction.Incoming, DateTime.Now.AddSeconds(3), new Contact("Dart", "Spring", 20, "+380931234568"));
            Assert.IsFalse(callOne.Equals(callTwo));
        }
        [TestMethod]
        public void CallsNotEqualByPhoneNumber() {
            Call callOne = new Call(Direction.Outgoing, DateTime.Now, new Contact("Dart", "Spring", 20, "+380931234568"));
            Call callTwo = new Call(Direction.Incoming, DateTime.Now.AddSeconds(3), new Contact("Dart", "Spring", 20, "+380931234567"));
            Assert.IsFalse(callOne.Equals(callTwo));
        }

        [TestMethod]
        public void CallsEqualNullTest() {
            Call callOne = new Call(Direction.Outgoing, DateTime.Now, new Contact("Dart", "Spring", 20, "+380931234568"));
            Call callTwo = null;
            Assert.IsFalse(callOne.Equals(callTwo));
        }

        [TestMethod]
        public void CallsEqualToAnotherObject() {
            Call callOne = new Call(Direction.Outgoing, DateTime.Now, new Contact("Dart", "Spring", 20, "+380931234568"));
            Storage callTwo = new Storage();
            Assert.IsFalse(callOne.Equals(callTwo));
        }
    }
}
