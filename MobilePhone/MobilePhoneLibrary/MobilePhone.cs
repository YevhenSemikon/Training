using MobilePhone.MobileComponents.Battery;
using MobilePhone.MobileComponents.Speaker;
using MobilePhone.MobileComponents.Microphone;
using MobilePhone.MobileComponents.Screen;
using MobilePhone.MobileComponents.SimCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhone.MobileComponents.AudioJack;

namespace MobilePhone {
    public abstract class MobilePhone {
        private IPlayback vplaybackComponent;

        public IPlayback PlaybackComponent {
            get { return vplaybackComponent; }
            set {
                if (value.ToString() == "UnknownHeadset") {
                    Console.WriteLine("Playback could not be set to Mobile");
                    vplaybackComponent = value;
                }
                else {
                    Console.WriteLine("Set playback to Mobile...");
                }
                              
            }
        }

        public abstract ScreenBase Screen { get; }
        public abstract MicrophoneBase Microphone { get; }
        public abstract BatteryBase Battery { get; }
        public abstract SpeakerBase Speaker { get; }
        public abstract SimCardBase SimCard { get; }
        private void Show(IScreenImage screenImage) { Screen.Show(screenImage); }
        public string GetDescription()
        {
            var descriptionBuilder = new StringBuilder();
            descriptionBuilder.AppendLine($"Screen Type: {Screen.ToString()}");
            descriptionBuilder.AppendLine($"Microphone Type: {Microphone.ToString()}");
            descriptionBuilder.AppendLine($"Battery Type: {Battery.ToString()}");
            descriptionBuilder.AppendLine($"Speaker Type: {Speaker.ToString()}");
            descriptionBuilder.AppendLine($"SimCard Type: {SimCard.ToString()}");
            return descriptionBuilder.ToString();
        }
        public void Play(object data)
        {
            if (data.ToString() != "UnknownHeadset") {
                Console.WriteLine("Play sound in Mobile:");
                PlaybackComponent.Play(data);
            }

        }
    }
}
