using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone;
using MobilePhone.MobileComponents.Charger;
using MobilePhone.MobileComponents;
using MobilePhone.MobilePhoneProgram;

namespace UnitTestMobilePhone {
    [TestClass]
    public class ChargerTest {
        [TestMethod]
        public void iPhoneChargerTest() {
            var mobile = new SimCorpMobilePhone();
            var consoleOutput = new ConsoleOutput();
            ICharge chargerComponent = new iPhoneCharger(consoleOutput);
            mobile.ChargerComponent = chargerComponent;
            var expected1 = "iPhoneCharger selected";
            var actual1 = consoleOutput.textTest;
            Assert.AreEqual(expected1, actual1);
            mobile.Charge();
            var expected = "Charging by iPhoneCharger";
            var actual = consoleOutput.textTest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SamsungChargerTest() {
            var mobile = new SimCorpMobilePhone();
            var consoleOutput = new ConsoleOutput();
            ICharge chargerComponent = new SamsungCharger(consoleOutput);
            mobile.ChargerComponent = chargerComponent;
            var expected1 = "SamsungCharger selected";
            var actual1 = consoleOutput.textTest;
            Assert.AreEqual(expected1, actual1);
            mobile.Charge();
            var expected = "Charging by SamsungCharger";
            var actual = consoleOutput.textTest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UnofficialiPhoneChargerTest() {
            var mobile = new SimCorpMobilePhone();
            var consoleOutput = new ConsoleOutput();
            ICharge chargerComponent = new UnofficialiPhoneCharger(consoleOutput);
            mobile.ChargerComponent = chargerComponent;
            var expected1 = "UnofficialiPhoneCharger selected";
            var actual1 = consoleOutput.textTest;
            Assert.AreEqual(expected1, actual1);
            mobile.Charge();
            var expected = "Charging by UnofficialiPhoneCharger";
            var actual = consoleOutput.textTest;
            Assert.AreEqual(expected, actual);
        }
    }
}
