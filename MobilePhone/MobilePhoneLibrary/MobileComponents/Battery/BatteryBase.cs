using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Battery {
    public abstract class BatteryBase {
        public BatteryBase() { capacity = 800; charge = 15;
            Thread messageGenerator = new Thread(DisCharging);
            messageGenerator.Start();
        }
        public abstract int capacity { get; set; }
        public abstract int charge { get; set; }
        public abstract int minWorkingTempreture { get; }
        public abstract int maxWorkingTempreture { get; }
        public abstract double minVoltage { get; }
        public abstract double maxVoltage { get; }

        public Thread Charging() {

        }

        public void DisCharging() {
            while (charge>0) {
                charge -= 1;
                System.Threading.Thread.Sleep(100);
            }
        }


    }
}
