using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone;

namespace UnitTestMobilePhone
{
    [TestClass]
    public class MessageFilteringTest
    {
        [TestMethod]
        public void FilterByUser()
        {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            mobile.AddSMSProvider(messageNumber: 3, pause: 0);
            string selectedUser = "+380971234567";
            var messageList=mobile.Storage.FilterMessageByUser(mobile.Storage.MessagesList, selectedUser);
            int expectedCount = 3;
            Assert.AreEqual(expectedCount, messageList.FindAll(u => u.User == selectedUser).Count);
        }

        [TestMethod]
        public void FilterByText()
        {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            mobile.AddSMSProvider(messageNumber: 3, pause: 0);            
            string selectedText = "Message #1 received!";
            var messageList = mobile.Storage.FilterMessageByText(mobile.Storage.MessagesList, selectedText);
            int expectedCount = 1;
            Assert.AreEqual(expectedCount,messageList.FindAll(t => t.Text == selectedText).Count);
        }

        [TestMethod]
        public void FilterByDatePositive()
        {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            mobile.AddSMSProvider(messageNumber: 1, pause: 0);
            var startDate = DateTime.Now.AddMinutes(-1);
            var endDate = DateTime.Now.AddHours(1);
            var messageList = mobile.Storage.FilterMessageByDate(mobile.Storage.MessagesList, startDate,endDate);
            int expectedCount = 3;
            Assert.AreEqual(expectedCount, messageList.Count);
        }

        [TestMethod]
        public void FilterByDateNegative()
        {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            mobile.AddSMSProvider(messageNumber : 1, pause : 0);
            var startDate = DateTime.Now.AddDays(-1);
            var endDate = DateTime.Now.AddHours(-1);
            var messageList = mobile.Storage.FilterMessageByDate(mobile.Storage.MessagesList,startDate,endDate);
            int expectedCount = 0;
            Assert.AreEqual(expectedCount, messageList.Count);
        }

        [TestMethod]
        //Number of Messages filtered by date = 0, by user = 3, total messages = 3 
        public void FilterByDateOrUser()
        {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            mobile.AddSMSProvider(messageNumber: 3, pause: 0);
            var startDate = DateTime.Now.AddDays(-1);
            var endDate = DateTime.Now.AddHours(-1);
            string selectedUser = "+380971234567";
            bool ANDCondition = false;
            string selectedText = "";
            var messageList = mobile.Storage.FilterMessage(mobile.Storage.MessagesList,
                selectedUser, startDate, endDate, selectedText, ANDCondition);
            int expectedCount = 3;
            Assert.AreEqual(expectedCount, messageList.Count);
        }

        [TestMethod]
        //Number of Messages filtered by date = 9, by user = 3, total messages = 9 (3 messages included in 9)
        public void FilterByUserOrDate()
        {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            mobile.AddSMSProvider(messageNumber: 3, pause: 0);
            var startDate = DateTime.Now.AddMinutes(-1);
            var endDate = DateTime.Now.AddHours(1);
            string selectedUser = "+380971234567";
            bool ANDCondition = false;
            string selectedText = "";
            var messageList = mobile.Storage.FilterMessage(mobile.Storage.MessagesList,
                selectedUser, startDate, endDate, selectedText, ANDCondition);
            int expectedCount = 9;
            Assert.AreEqual(expectedCount, messageList.Count);
        }

        [TestMethod]
        //Number of Messages filtered by date = 0, by text = 1, total messages = 1
        public void FilterByDateOrText()
        {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            mobile.AddSMSProvider(messageNumber: 3, pause: 0);
            var startDate = DateTime.Now.AddDays(-1);
            var endDate = DateTime.Now.AddHours(-1);
            string selectedUser = "";
            bool ANDCondition = false;
            string selectedText = "1";
            var messageList = mobile.Storage.FilterMessage(mobile.Storage.MessagesList,
                selectedUser, startDate, endDate, selectedText, ANDCondition);
            int expectedCount = 1;
            Assert.AreEqual(expectedCount, messageList.Count);
        }

        [TestMethod]
        //Number of Messages filtered by date = 9, by text = 0, total messages = 9
        public void FilterByTextOrDate()
        {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            mobile.AddSMSProvider(messageNumber: 3, pause: 0);
            var startDate = DateTime.Now.AddMinutes(-1);
            var endDate = DateTime.Now.AddHours(1);
            string selectedUser = "";
            bool ANDCondition = false;
            string selectedText = "15";
            var messageList = mobile.Storage.FilterMessage(mobile.Storage.MessagesList,
                selectedUser, startDate, endDate, selectedText, ANDCondition);
            int expectedCount = 9;
            Assert.AreEqual(expectedCount, messageList.Count);
        }

        [TestMethod]
        //Number of Messages filtered by date = 0, by text = 1,by user = 3, total messages = 4 (all messages unique)
        public void FilterByDateOrTextorUser()
        {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            mobile.AddSMSProvider(messageNumber: 3, pause: 0);
            var startDate = DateTime.Now.AddDays(-1);
            var endDate = DateTime.Now.AddHours(-1);
            string selectedUser = "+380971234567";
            bool ANDCondition = false;
            string selectedText = "2";
            var messageList = mobile.Storage.FilterMessage(mobile.Storage.MessagesList,
                selectedUser, startDate, endDate, selectedText, ANDCondition);
            int expectedCount = 4;
            Assert.AreEqual(expectedCount, messageList.Count);
        }

        [TestMethod]
        //Number of Messages filtered by date = 9, by text = 1, total messages = 1
        public void FilterByDateAndText()
        {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            mobile.AddSMSProvider(messageNumber: 3, pause: 0);
            var startDate = DateTime.Now.AddMinutes(-1);
            var endDate = DateTime.Now.AddHours(1);
            string selectedUser = "";
            bool ANDCondition = true;
            string selectedText = "1";
            var messageList = mobile.Storage.FilterMessage(mobile.Storage.MessagesList,
                selectedUser, startDate, endDate, selectedText, ANDCondition);
            int expectedCount = 1;
            Assert.AreEqual(expectedCount, messageList.FindAll(t => t.Text == "Message #1 received!").Count);
        }

        [TestMethod]
        //Number of Messages filtered by date = 9, by user = 3, total messages = 3
        public void FilterByDateAndUser()
        {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            mobile.AddSMSProvider(messageNumber: 3, pause: 0);
            var startDate = DateTime.Now.AddMinutes(-1);
            var endDate = DateTime.Now.AddHours(1);
            string selectedUser = "+380971234567";
            bool ANDCondition = true;
            string selectedText = "";
            var messageList = mobile.Storage.FilterMessage(mobile.Storage.MessagesList,
                selectedUser, startDate, endDate, selectedText, ANDCondition);
            int expectedCount = 3;
            Assert.AreEqual(expectedCount, messageList.FindAll(u => u.User == selectedUser).Count);
        }

        [TestMethod]
        //Number of Messages filtered by date = 9, by user = 3, by text 1, total messages = 1
        public void FilterByDateAndUserAndText()
        {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            mobile.AddSMSProvider(messageNumber: 3, pause: 0);
            var startDate = DateTime.Now.AddMinutes(-1);
            var endDate = DateTime.Now.AddHours(1);
            string selectedUser = "+380971234567";
            bool ANDCondition = true;
            string selectedText = "0";
            var messageList = mobile.Storage.FilterMessage(mobile.Storage.MessagesList,
                selectedUser, startDate, endDate, selectedText, ANDCondition);
            int expectedCount = 1;
            Assert.AreEqual(expectedCount, messageList.FindAll(t => t.Text == "Message #0 received!").Count);
        }

    }
}
