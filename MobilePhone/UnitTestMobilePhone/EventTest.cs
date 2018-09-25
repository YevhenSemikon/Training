using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone;

namespace UnitTestMobilePhone {
   // public delegate 
    /// <summary>
    /// Summary description for EventTest
    /// </summary>
    [TestClass]
    public class EventTest {
        List<Message> actualEventMessage;

        [TestMethod]
        public void EventMessageTest () {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();           
            mobile.Storage.MessageAdd += CheckEventMessage;
            mobile.AddSMSProvider(messageNumber: 1, pause: 0);
            var expectedEventMessage = "Message #0 received!";
            Assert.AreEqual(expectedEventMessage, actualEventMessage[0].Text);
        }
        private void CheckEventMessage(List<Message> message) {
            actualEventMessage=message;
        }  
    }
}
