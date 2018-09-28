using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Charger {
    public class NullCharger : ICharge {
        private IOutput Output;
        public NullCharger(IOutput output) {
            Output = output;
            Output.WriteLine("No charger connected");
        }
        public NullCharger() {
            ChargerCoef = 0;
        }
        public double ChargerCoef { get; set; }
        public void Charge() {
            Output.WriteLine("Mobile is not charging");
        }
    }
}
