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
            TimeSpan executionTime = new TimeSpan();
            DateTime time = DateTime.Now;
            while (mobile.Battery.ChargeLevel.vChargingTask.IsCompleted == false) {
                executionTime = DateTime.Now - time;
                if (executionTime.Seconds > 10) {
                    throw new StackOverflowException("Time of execution is too high: " + executionTime);
                }
            }
            int actual = mobile.Battery.ChargeLevel.CurrentChargeLevel;
            Thread.Sleep(2000); // Waiting for completion of all threads.
            Assert.IsTrue(actual > 99 && mobile.Battery.ChargeLevel.vDisChargingTask.IsCompleted);
        }

        [TestMethod]
        public void ChargeDecrease() {
            SimCorpMobilePhone mobile = new SimCorpMobilePhone(new BatteryChargeLevelTask(1));
            TimeSpan executionTime = new TimeSpan();
            DateTime time = DateTime.Now;
            while (mobile.Battery.ChargeLevel.vDisChargingTask.IsCompleted == false) {
                executionTime = DateTime.Now - time;
                if (executionTime.Seconds > 10) {
                    throw new StackOverflowException("Time of execution is too high: " + executionTime);
                }
            }
            int actual = mobile.Battery.ChargeLevel.CurrentChargeLevel;
            Assert.IsTrue(actual < 1 && mobile.Battery.ChargeLevel?.vChargingTask == null);
        }
    }
}
