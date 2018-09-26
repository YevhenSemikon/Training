using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.SimCard {
    public abstract class SimCardBase {
        public SimCardBase() {
            NetworkStandard = "2g";
            FormFactor = "MiniSim";
        }
        public abstract string FormFactor { get; set; }
        public abstract string NetworkStandard { get; set; }
        public override string ToString() { return NetworkStandard; }
    }
}
