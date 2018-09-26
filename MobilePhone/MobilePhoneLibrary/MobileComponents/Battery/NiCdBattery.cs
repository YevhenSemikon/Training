using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Battery {
    public class NiCdBattery : BatteryBase {
        public NiCdBattery() : base() {
            BatteryChargeCoef = 0.95;
            BatteryDisChargeCoef = 1.1;
        }
        public override int Capacity { get; set; }
        public override double BatteryChargeCoef { get; set; }
        public override double BatteryDisChargeCoef { get; set; }
        public override double MinVoltage { get { return 1.2; } }
        public override double MaxVoltage { get { return 1.35; } }
        public override int MinWorkingTempreture { get { return -50; } }
        public override int MaxWorkingTempreture { get { return +40; } }
        public string BatteryType { get { return "Ni-Cd"; } }
        public override string ToString() { return "Ni-Cd Battery"; }
    }
}
