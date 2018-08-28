using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.SimCard {
    public abstract class SimCardBase {
        public abstract string size { get; set; }
        public abstract int networkSpeed { get; set; }
    }
}
