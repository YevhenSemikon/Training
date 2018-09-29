using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone;
using MobilePhone.MobileComponents.Battery;
using MobilePhone.MobileComponents.Charger;
using System.Threading;

namespace UnitTestMobilePhone {
    [TestClass]
    public class ChargeThreadTest {
        [TestMethod]
        public void ChargeThreadIncrease() {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone(new BatteryChargeLevelThread(99));
            mobile.ChargerComponent = new iPhoneCharger();
            Thread.Sleep(3000);
            int actual = mobile.Battery.ChargeLevel.CurrentChargeLevel;
            Assert.IsTrue(actual > 99 && mobile.Battery.ChargeLevel?.vDisChargingThread == null);
        }
        [TestMethod]
        public void ChargeThreadDecrease() {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone(new BatteryChargeLevelThread(1));
            mobile.ChargerComponent = new NullCharger();
            Thread.Sleep(5000);
            int actual = mobile.Battery.ChargeLevel.CurrentChargeLevel;
            Assert.IsTrue(actual < 1 && mobile.Battery.ChargeLevel?.vChargingThread == null);
        }
    }
}
