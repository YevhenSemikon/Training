using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Microphone {
    public abstract class MicrophoneBase {
        public MicrophoneBase() { sensitivity = 54; }
        public abstract int sensitivity { get; set; }
        public abstract int maxFrequency { get; }
        public abstract int minFrequency { get; }
        public void Mute(bool mute) {
            if (mute) {
                Console.WriteLine("Microphone is muted");
            }
            else {
                Console.WriteLine("Microphone is unmuted");
            };
        }
    }
}