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
        string actualEventMessage;

        [TestMethod]
        public void EventMessageTest () {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
           // mobile.SMSProvider.SMSReceived += CheckEventMessage;
            //SMSProvider.SMSStartSendingDelegate startDel = mobile.SMSProvider.ReceiveMessage;
            //startDel(1);
            var expectedEventMessage = "Message #0 received!";
            Assert.AreEqual(expectedEventMessage, actualEventMessage);
        }
        private void CheckEventMessage(string message) {
            actualEventMessage=message;
        }  
    }
}
