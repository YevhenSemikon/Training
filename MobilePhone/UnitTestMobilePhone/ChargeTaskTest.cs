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
            if (!mobile.Battery.ChargeLevel.vDisChargingTask.IsCanceled) {
                mobile.Battery.ChargeLevel.vDisChargingTask.Wait();
            }
            mobile.Battery.ChargeLevel.vChargingTask.Wait();
            int actual = mobile.Battery.ChargeLevel.CurrentChargeLevel;
            Assert.IsTrue(actual > 99 && (mobile.Battery.ChargeLevel.vDisChargingTask.IsCompleted
            || mobile.Battery.ChargeLevel.vDisChargingTask.IsCanceled)
                );
        }

        [TestMethod]
        public void ChargeDecrease() {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone(new BatteryChargeLevelTask(1));
            mobile.Battery.ChargeLevel.vDisChargingTask.Wait();
            int actual = mobile.Battery.ChargeLevel.CurrentChargeLevel;
            Assert.IsTrue(actual < 1 && mobile.Battery.ChargeLevel?.vChargingTask == null);
        }
    }
}
