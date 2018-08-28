using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Battery {
   public class LiPolBattery : BatteryBase {
        public override int capacity { get; set; }
        public override int size { get; set; }
        public override string ToString() { return "Li-Pol Battery"; } 
    }
}
