using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Charger {
    public class iPhoneCharger : ICharge {
        private IOutput Output;
        public iPhoneCharger(IOutput output) {
            Output = output;
            Output.WriteLine($"{nameof(iPhoneCharger)} selected");
        }
        public void Charge() {
            Output.WriteLine("Charging Mobile:");
            Output.WriteLine($"Charging by {nameof(iPhoneCharger)}");
        }
        public override string ToString() {
            return "iPhoneCharger";
        }
    }
}
