using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.SimCard {
    public class LifeSimCard : SimCardBase {
        public LifeSimCard() : base() {
            NetworkStandard = "4g";
            FormFactor = "NanoSim";
        }
        public LifeSimCard(string formFactor, string networkStandard) {
            this.NetworkStandard = networkStandard;
            this.FormFactor = formFactor;
        }
        public string PhoneNumber { get; set; }
        public override string FormFactor { get; set; }
        public override string NetworkStandard { get; set; }
    }
}
