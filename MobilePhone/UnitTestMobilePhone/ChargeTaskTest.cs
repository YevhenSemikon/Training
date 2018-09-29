using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobilePhone;
using MobilePhone.MobileComponents.Battery;
using MobilePhone.MobileComponents.Charger;
using System.Threading;

namespace UnitTestMobilePhone {
    [TestClass]
    public class ChargeTaskTest {

        [TestMethod]
        public void ChargeTaskIncrease() {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone(new BatteryChargeLevelTask(99));
            mobile.ChargerComponent = new iPhoneCharger();
            Thread.Sleep(3000);
            int actual = mobile.Battery.ChargeLevel.CurrentChargeLevel;
            Assert.IsTrue(actual > 99 && mobile.Battery.ChargeLevel?.vDisChargingTask == null);
        }

        [TestMethod]
        public void ChargeTaskDecrease() {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone(new BatteryChargeLevelTask(1));
            mobile.ChargerComponent = new NullCharger();
            Thread.Sleep(5000);
            int actual = mobile.Battery.ChargeLevel.CurrentChargeLevel;
            Assert.IsTrue(actual < 1 && mobile.Battery.ChargeLevel?.vChargingTask == null);
        }
    }
}
