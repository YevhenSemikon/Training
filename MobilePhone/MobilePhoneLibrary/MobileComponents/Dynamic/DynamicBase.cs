using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Dynamic {
    public abstract class DynamicBase {
        protected int currentVolume;
        private int previousVolume;
        private int maxVolume = 100;
        private int minVolume = 0;
        public abstract int power { get; set; }
        public void SilenceMode(bool mode) {
            if (mode) {
                Console.WriteLine("Silence mode is on");
                previousVolume = currentVolume;
                currentVolume = minVolume;
            }
            else {
                Console.WriteLine("Silence mode is off");
                currentVolume = previousVolume;
            }
        }

        public void VolumeDown() {
            if (currentVolume != minVolume) { currentVolume = -1; }
        }

        public  void VolumeUp() {
            if (currentVolume != maxVolume) { currentVolume = +1; }
        }
    }
}
