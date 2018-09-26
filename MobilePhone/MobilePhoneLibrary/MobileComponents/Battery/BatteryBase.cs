using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Battery {
    public abstract class BatteryBase {


        public BatteryBase() {
            Capacity = 800;
            ChargeLevel = new ChargeLevel(30);
            BatteryChargeCoef = 1;
            BatteryDisChargeCoef = 1;
        }
        public bool Charge { get; private set; }
        public abstract int Capacity { get; set; }
        public ChargeLevel ChargeLevel { get; private set; }
        public abstract double BatteryChargeCoef { get;set;}
        public abstract double BatteryDisChargeCoef { get; set; }
        public abstract int MinWorkingTempreture { get; }
        public abstract int MaxWorkingTempreture { get; }
        public abstract double MinVoltage { get; }
        public abstract double MaxVoltage { get; }

        internal void ChargingBattery(MobilePhone mobile,bool turnOn)
        {
            if (turnOn)
            {
                Charge = true;
                Thread ChargingThread = new Thread(ChargeLevel.DisCharging);
                ChargingThread.Start();
            }
            else
            {
                Charge = false;
            }         
        }
    }
}
