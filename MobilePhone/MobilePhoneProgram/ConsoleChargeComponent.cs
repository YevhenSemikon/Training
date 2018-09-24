using MobilePhone.MobileComponents.Charger;
using MobilePhone.MobilePhoneProgram;
using System;

namespace MobilePhoneProgram {
    public class ConsoleChargeComponent {
        private ICharge chargeComponent;
        public ICharge SelectChargerComponent(ConsoleOutput consoleOutput) {
            Console.Clear();
            string chargeIndex = consoleOutput.GetChosenIndex(chargeComponent);
            switch (chargeIndex) {
                case "1":
                chargeComponent = new iPhoneCharger(consoleOutput);
                break;
                case "2":
                chargeComponent = new SamsungCharger(consoleOutput);
                break;
                case "3":
                chargeComponent = new UnofficialiPhoneCharger(consoleOutput);
                break;
                default:
                consoleOutput.WriteLine("Unknown charger component selected, please select component from the list.");
                consoleOutput.WriteLine("Press any key to continue...");
                Console.ReadKey();
                chargeComponent = SelectChargerComponent(consoleOutput);
                break;
            }
            return chargeComponent;
        }
    }
}
