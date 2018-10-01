using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone;
using MobilePhone.CommonUtilities;
using System.Collections.Generic;

namespace UnitTestMobilePhone {
    [TestClass]
    public class CallsGroupingTest {
        [TestMethod]
        public void StandardCallsGrouping() {
            Storage storage = new Storage();
            var callOne = new Call(Direction.Incoming, DateTime.Now, new Contact("Dart", "Spring", 20, "+380931234568"));
            var callTwo = new Call(Direction.Incoming, DateTime.Now.AddSeconds(5), new Contact("Dart", "Spring", 20, "+380931234568"));
            var callThree = new Call(Direction.Incoming, DateTime.Now.AddSeconds(3), new Contact("Dart", "Spring", 20, "+380931234568"));

            HashSet<List<Call>> actual = new HashSet<List<Call>>() {
                callThree,
                callOne
            };

        }
    }
}
