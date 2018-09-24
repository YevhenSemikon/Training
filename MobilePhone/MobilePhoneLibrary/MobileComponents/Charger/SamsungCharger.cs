using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Charger {
    public class SamsungCharger : ICharge {
        private IOutput Output;
        public SamsungCharger(IOutput output) {
            Output = output;
            Output.WriteLine($"{nameof(SamsungCharger)} selected");
        }
        public void Charge() {
            Output.WriteLine("Charging Mobile:");
            Output.WriteLine($"Charging by {nameof(SamsungCharger)}");
        }
        public override string ToString() {
            return "SamsungCharger";
        }
    }
}
