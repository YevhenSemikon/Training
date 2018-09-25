using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone;

namespace UnitTestMobilePhone
{
    [TestClass]
    public class StorageTest
    {
        List<Message> actualMessages;
        [TestMethod]
        public void AddMessageToStorage()
        {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            mobile.Storage.MessageAdd += CheckMessage;
            mobile.Storage.AddMessage(new Message("Bob", "Hi, it's Bob!", DateTime.Now));
            var expectedMessageText = "Hi, it's Bob!";
            Assert.IsTrue(actualMessages.FindAll(t=>t.Text==expectedMessageText).Count==1);
        }

        [TestMethod]
        public void RemoveMessageFromStorage()
        {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            mobile.Storage.MessageAdd += CheckMessage;
            mobile.Storage.MessageRemove += CheckMessage;
            var checkedMessage = new Message("Bob", "Hi, it's Bob!", DateTime.Now);
            mobile.Storage.AddMessage(checkedMessage);
            mobile.Storage.AddMessage(new Message("Adam", "Hi, it's Adam!", DateTime.Now));          
            mobile.Storage.RemoveMessage(checkedMessage);
            var expectedMessageText = "Hi, it's Adam!";
            Assert.IsTrue(actualMessages.FindAll(t => t.Text == expectedMessageText).Count == 1);
        }

        private void CheckMessage(List<Message> messages)
        {
            actualMessages = messages;
        }
    }
}
