using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Dynamic {
    public class StereoDynamic : DynamicBase {
        public int volume { get { return currentVolume; } }
        public override int power { get; set; }
        public override string ToString() { return "Stereo-Dynamic"; }
    }
}
