using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.SimCard {
    public class LifeSimCard : SimCardBase {
        public LifeSimCard() : base() {
            networkStandard = "4g";
            formFactor = "NanoSim";
        }
        public LifeSimCard(string formFactor, string networkStandard) {
            this.networkStandard = networkStandard;
            this.formFactor = formFactor;
        }
        public string phoneNumber { get; set; }
        public override string formFactor { get; set; }
        public override string networkStandard { get; set; }
    }
}
