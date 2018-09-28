using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MobilePhone.MobileComponents.Charger;

namespace MobilePhone.MobileComponents.Battery {
    public class BatteryChargeLevelThread : BatteryChargeLevel {
        public BatteryChargeLevelThread() : base() { }

        internal BatteryChargeLevelThread(int currentChargeLevel) : base(currentChargeLevel) {
        }

        public override void StartCharging(ICharge charger, BatteryBase battery, CancellationToken token) {
            Thread chargingThread = new Thread(() => Charging(charger, battery, token));
            chargingThread.Name = "Charging Thread";
            chargingThread.Start();
            vChargingThread = chargingThread;
        }
        public override void StartDisCharging(BatteryBase battery, CancellationToken token) {
            Thread disChargingThread = new Thread(() => DisCharging(battery, token));
            disChargingThread.Name = "DisCharging Thread";
            disChargingThread.Start();
            vDisChargingThread = disChargingThread;
        }
    }
}
