using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone;
using MobilePhone.CommonUtilities;

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
            mobile.Storage.OnMessageAdd += CheckMessage;
            mobile.Storage.AddMessage(new Message("Bob", "Hi, it's Bob!", DateTime.Now));
            var expectedMessageText = "Hi, it's Bob!";
            Assert.IsTrue(actualMessages.FindAll(t=>t.Text==expectedMessageText).Count==1);
        }

        [TestMethod]
        public void RemoveMessageFromStorage()
        {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            mobile.Storage.OnMessageAdd += CheckMessage;
            mobile.Storage.OnMessageRemove += CheckMessage;
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

        [TestMethod]
        public void AddCallToStorage() {
            Storage storage = new Storage();
            var callOne = new Call(Direction.Incoming, DateTime.Now, new Contact("Dart", "Spring", 20, "+380931234568"));
            var callTwo = new Call(Direction.Incoming, DateTime.Now.AddSeconds(3), new Contact("Dart", "Spring", 20, "+380931234568"));
            HashSet < Call > actual = new HashSet<Call>() { 
                callTwo,
                callOne
            };
            storage.AddCall(callOne);
            storage.AddCall(callTwo);           
            Assert.IsTrue(actual.SetEquals(storage.CallsList));
        }

        [TestMethod]
        public void RemoveCallFromStorage() {
            Storage storage = new Storage();
            var callOne = new Call(Direction.Incoming, DateTime.Now, new Contact("Dart", "Spring", 20, "+380931234568"));
            var callTwo = new Call(Direction.Incoming, DateTime.Now.AddSeconds(5), new Contact("Dart", "Spring", 20, "+380931234568"));
            var callThree = new Call(Direction.Incoming, DateTime.Now.AddSeconds(3), new Contact("Dart", "Spring", 20, "+380931234568"));
            HashSet<Call> actual = new HashSet<Call>() {
                callThree,
                callOne
            };
            storage.AddCall(callOne);
            storage.AddCall(callTwo);
            storage.AddCall(callThree);
            storage.RemoveCall(callTwo);
            Assert.IsTrue(actual.SetEquals(storage.CallsList));
        }
    }
}
