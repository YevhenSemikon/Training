using MobilePhone.MobileComponents.Charger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Battery {
    public abstract class BatteryBase {
        private ICharge vBatteryCharger;
        private bool vCharge;
        private BatteryChargeLevel vBatteryChargeLevel;
        internal CancellationTokenSource cancelChargeToken = new CancellationTokenSource();
        internal CancellationTokenSource cancelDisChargeToken = new CancellationTokenSource();
        public BatteryBase() {
            Capacity = 800;
            BatteryChargeCoef = 1;
            BatteryDisChargeCoef = 1;
            ChargeLevel = new BatteryChargeLevelThread();
        }
        public bool Charge {
            get { return vCharge; }
            private set {
                ChargingBattery(value);
                vCharge = value;
            }
        }
        public ICharge BatteryCharger {
            get { return vBatteryCharger; }
            set {
                if (value is NullCharger) {
                    Charge = false;
                }
                else { Charge = true; }
                vBatteryCharger = value;
            }
        }
        public BatteryChargeLevel ChargeLevel {
            get { return vBatteryChargeLevel; }
            set {
                if (vBatteryChargeLevel != null) {
                    cancelChargeToken.Cancel();
                    cancelDisChargeToken.Cancel();
                    cancelDisChargeToken = new CancellationTokenSource();
                    cancelChargeToken = new CancellationTokenSource();
                }
                vBatteryChargeLevel = value;
            }
        }
        public abstract int Capacity { get; set; }
        public abstract double BatteryChargeCoef { get; set; }
        public abstract double BatteryDisChargeCoef { get; set; }
        public abstract int MinWorkingTempreture { get; }
        public abstract int MaxWorkingTempreture { get; }
        public abstract double MinVoltage { get; }
        public abstract double MaxVoltage { get; }

        internal void ChargingBattery(bool turnOn) {
            if (turnOn) {
                cancelDisChargeToken.Cancel();
                ChargeLevel.StartCharging(BatteryCharger, this, cancelChargeToken.Token);
                cancelDisChargeToken = new CancellationTokenSource();
            }
            else {
                cancelChargeToken.Cancel();
                ChargeLevel.StartDisCharging(this, cancelDisChargeToken.Token);
                cancelChargeToken = new CancellationTokenSource();
            }
        }
    }
}
