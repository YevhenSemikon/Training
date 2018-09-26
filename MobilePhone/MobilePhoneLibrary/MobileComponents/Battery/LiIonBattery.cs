using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Battery {
    public class LiIonBattery : BatteryBase {
        public LiIonBattery() : base() {
            BatteryChargeCoef = 0.7;
            BatteryDisChargeCoef = 0.85;
        }
        public override int Capacity { get; set; }
        public override double BatteryChargeCoef { get ; set; }
        public override double BatteryDisChargeCoef { get; set; }
        public override double MinVoltage { get { return 3.7; } }
        public override double MaxVoltage { get { return 4.2; } }
        public override int MinWorkingTempreture { get { return -20; } }
        public override int MaxWorkingTempreture { get { return +50; } }
        public string BatteryType { get { return "Li-Ion"; }}
        public override string ToString() { return "Li-Ion Battery"; }
    }
}
