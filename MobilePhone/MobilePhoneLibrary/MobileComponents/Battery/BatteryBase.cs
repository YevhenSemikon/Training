using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Battery {
    public abstract class BatteryBase {
        public BatteryBase() { capacity = 800; }
        public abstract int capacity { get; set; }
        public abstract int minWorkingTempreture { get; }
        public abstract int maxWorkingTempreture { get; }
        public abstract double minVoltage { get; }
        public abstract double maxVoltage { get; }
    }
}
