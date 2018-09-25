using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Battery {
    public class NiCdBattery : BatteryBase {
        public NiCdBattery() : base() {}
        public override int capacity { get; set; }
        public override double minVoltage { get { return 1.2; } }
        public override double maxVoltage { get { return 1.35; } }
        public override int minWorkingTempreture { get { return -50; } }
        public override int maxWorkingTempreture { get { return +40; } }
        public string batteryType { get { return "Ni-Cd"; } }
        public override string ToString() { return "Ni-Cd Battery"; }
    }
}
