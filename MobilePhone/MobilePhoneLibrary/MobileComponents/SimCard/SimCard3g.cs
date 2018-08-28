using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.SimCard {
    public class SimCard3g : SimCardBase {
        public override string size { get; set; }
        public override int networkSpeed { get; set; }
        public override string ToString() { return "3g"; }
    }
}
