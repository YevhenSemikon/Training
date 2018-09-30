using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone;
using MobilePhone.CommonUtilities;

namespace UnitTestMobilePhone {
    [TestClass]
    public class FormattingTest {
        [TestMethod]
        public void NoneFormatMessage() {
            var expected = "None Changes";
            var actual = MessageAction.NoneFormat(expected);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EndWithDateFormatMessage() {
            var message = "]";
            var expected = true;
            var actual = MessageAction.EndWithDate(message).EndsWith(message);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void StartWithDateFormatMessage() {
            var message = "[";
            var expected = true;
            var actual = MessageAction.StartWithDate(message).StartsWith(message);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UpperCaseFormatMessage() {
            var message = "Check message";
            var expected = "CHECK MESSAGE";
            var actual = MessageAction.UpperFormat(message);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LowerCaseFormatMessage() {
            var message = "Check message";
            var expected = "check message";
            var actual = MessageAction.LowerFormat(message);
            Assert.AreEqual(expected, actual);
        }
    }
}
