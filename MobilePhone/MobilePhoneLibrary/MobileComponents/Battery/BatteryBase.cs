using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Battery {
    public abstract class BatteryBase {
      public abstract int size {get; set;}
      public abstract int capacity {get; set;}

    }
}
