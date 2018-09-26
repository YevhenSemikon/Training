using MobilePhone.MobileComponents.Battery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Charger {
    public class iPhoneCharger : ICharge {
        private IOutput Output;
        private double vChargerCoef;

        public iPhoneCharger(IOutput output) {
            ChargerCoef = 1;
            Output = output;
            Output.WriteLine($"{nameof(iPhoneCharger)} selected");
        }

        public double ChargerCoef { get; set; }
        public void Charge(){         
            Output.WriteLine("Charging Mobile:");
            Output.WriteLine($"Charging by {nameof(iPhoneCharger)}");
            
        }
        public void Charge(MobilePhone mobile, bool turnOn){ mobile.Battery.ChargingBattery(mobile, turnOn);}
        
        public override string ToString() {
            return "iPhoneCharger";
        }
    }
}
