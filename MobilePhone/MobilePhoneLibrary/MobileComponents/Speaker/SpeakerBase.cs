using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Speaker {
    public abstract class SpeakerBase {
        protected int currentVolume;
        private int previousVolume;
        private int maxVolume = 100;
        private int minVolume = 0;
        public SpeakerBase() {   
            power = 2;
            currentVolume = 30;
        }
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
            if (currentVolume != minVolume) { currentVolume -=1; }
        }

        public  void VolumeUp() {
            if (currentVolume != maxVolume) {currentVolume +=1; }
        }
        public void VolumeUp(int value)
        {
            if ((currentVolume == maxVolume)||(currentVolume + value >= maxVolume)) {
                currentVolume = maxVolume;
            }
            else {
                currentVolume += value;
            }
        }
        public void VolumeDown(int value)
        {
            if ((currentVolume == minVolume) || (currentVolume - value <= minVolume)) {
                currentVolume = minVolume;
            }
            else {
                currentVolume -= value;
            }
        }
    }
}
