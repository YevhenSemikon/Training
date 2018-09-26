using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Charger {
    public interface ICharge {

        double ChargerCoef { get; set; }
        void Charge();
        void Charge(MobilePhone mobile, bool turnOn);
    }
}
