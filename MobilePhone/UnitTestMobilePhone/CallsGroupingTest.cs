using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone;
using MobilePhone.CommonUtilities;
using System.Collections.Generic;

namespace UnitTestMobilePhone {
    [TestClass]
    public class CallsGroupingTest {        
        [TestMethod]

        // Group calls by Direction and Phone Number
        public void StandardCallsGrouping() {
            Storage storage = new Storage();

            //1st group, calls must be sorted by desc order: callThree,callTwo,callOne
            var callOne = new Call(Direction.Incoming, DateTime.Now.AddMinutes(1), new Contact("Dart", "Spring", 20, "+380931234568"));
            var callTwo = new Call(Direction.Incoming, DateTime.Now.AddMinutes(2), new Contact("Dart", "Spring", 20, "+380931234568"));
            var callThree = new Call(Direction.Incoming, DateTime.Now.AddMinutes(3), new Contact("Dart", "Spring", 20, "+380931234568"));

            //2nd group, calls must be sorted by desc order: callFive, callFour
            var callFour = new Call(Direction.Incoming, DateTime.Now.AddMinutes(4), new Contact("Jane", "Spring", 20, "+380931234569"));
            var callFive = new Call(Direction.Incoming, DateTime.Now.AddMinutes(5), new Contact("Jane", "Spring", 20, "+380931234569"));

            //1st Group
            HashSet<Call> actualGroupCallsOne = new HashSet<Call>() {
                   callThree,            
                    callTwo,
                    callOne
            };

            //2nd Group
            HashSet<Call> actualGroupCallsTwo = new HashSet<Call>() {
                callFive,
                callFour              
            };

            //Main program
            storage.AddCall(callOne);
            storage.AddCall(callTwo);
            storage.AddCall(callThree);
            storage.AddCall(callFour);
            storage.AddCall(callFive);

            //Groups also must be sorted by desc order according to Max time of last call in list: 2nd Group, 1st Group
            Assert.IsTrue(actualGroupCallsTwo.SetEquals(storage.GroupedCallsList[0]) &&
                          actualGroupCallsOne.SetEquals(storage.GroupedCallsList[1]));

        }
    }
}
