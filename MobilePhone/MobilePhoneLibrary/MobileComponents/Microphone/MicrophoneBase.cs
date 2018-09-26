using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Microphone {
    public abstract class MicrophoneBase {
        public MicrophoneBase() { Sensitivity = 54; }
        public abstract int Sensitivity { get; set; }
        public abstract int MaxFrequency { get; }
        public abstract int MinFrequency { get; }
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