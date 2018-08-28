using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.SimCard {
    class SimCard4g : SimCardBase {
        public override string size { get; set; }
        public override int networkSpeed { get; set; }
        public override string ToString() { return "4g"; }
    }
}
