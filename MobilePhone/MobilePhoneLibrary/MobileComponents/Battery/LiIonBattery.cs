using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Battery {
    public class LiIonBattery : BatteryBase {
        public LiIonBattery() : base() { }
        public override int capacity { get; set; }
        public override double minVoltage { get { return 3.7; } }
        public override double maxVoltage { get { return 4.2; } }
        public override int minWorkingTempreture { get { return -20; } }
        public override int maxWorkingTempreture { get { return +50; } }
        public string batteryType { get { return "Li-Ion"; }}
        public override string ToString() { return "Li-Ion Battery"; }
    }
}
