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
        public CancellationTokenSource cancelChargeToken = new CancellationTokenSource();
        public CancellationTokenSource cancelDisChargeToken = new CancellationTokenSource();
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
        internal ICharge BatteryCharger {
            get { return vBatteryCharger; }
            set {
                vBatteryCharger = value;
                if (value is NullCharger) {
                    Charge = false;
                }
                else { Charge = true; }
            }
        }
        public BatteryChargeLevel ChargeLevel { get; internal set; }
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
                Thread.Sleep(200);
                ChargeLevel.StartCharging(BatteryCharger, this, cancelChargeToken.Token);
                cancelDisChargeToken = new CancellationTokenSource();
            }
            else {
                cancelChargeToken.Cancel();
                Thread.Sleep(200);
                ChargeLevel.StartDisCharging(this, cancelDisChargeToken.Token);
                cancelChargeToken = new CancellationTokenSource();
            }
        }

        public void CancelThreads() {
            cancelChargeToken.Cancel();
            cancelDisChargeToken.Cancel();
            Thread.Sleep(400);
        }
    }
}
