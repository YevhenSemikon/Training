using MobilePhone.MobileComponents.Charger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Battery {
    public class BatteryChargeLevelTask : BatteryChargeLevel {
        public BatteryChargeLevelTask() : base() { }
        internal BatteryChargeLevelTask(int currentChargeLevel) : base(currentChargeLevel) { }
        public override void StartCharging(ICharge charger, BatteryBase battery, CancellationToken token) {
            Task chargingTask = Task.Factory.StartNew(() => Charging(charger, battery, token),token);
            vChargingTask = chargingTask;
        }
        public override void StartDisCharging(BatteryBase battery, CancellationToken token) {
            Task DisChargingTask = Task.Factory.StartNew(() => DisCharging(battery, token),token);
            vDisChargingTask = DisChargingTask;            
        }
    }
}
