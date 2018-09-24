using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.SimCard {
    public abstract class SimCardBase {
        public SimCardBase() {
            networkStandard = "2g";
            formFactor = "MiniSim";
        }
        public abstract string formFactor { get; set; }
        public abstract string networkStandard { get; set; }
        public override string ToString() { return networkStandard; }
    }
}
