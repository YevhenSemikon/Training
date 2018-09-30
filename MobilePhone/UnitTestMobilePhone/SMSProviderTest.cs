using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone;
using MessageFormattingApp;
using System.Threading;

namespace UnitTestMobilePhone {
    [TestClass]
    public class SMSProviderTest {
        [TestMethod]
        public void SMSProviderThreadTest() {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            Provider smsProvider = new ProviderThread();
            smsProvider.StartMessageCreation(mobile.Storage);
            smsProvider.StopMessageCreation();
            Thread.Sleep(1000); // May get in pause of 1000 millisec between message creation
            Assert.IsTrue(!smsProvider.messageThreadGenerator.IsAlive);
        }

        [TestMethod]
        public void SMSProviderTaskTest() {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            Provider smsProvider = new ProviderTask();
            smsProvider.StartMessageCreation(mobile.Storage);
            smsProvider.StopMessageCreation();
            Thread.Sleep(1000); // May get in pause of 1000 millisec between message creation
            Console.WriteLine(smsProvider.messageTaskGenerator.Status);
            Assert.IsTrue(smsProvider.messageTaskGenerator.IsCompleted);
        }
    }
}
