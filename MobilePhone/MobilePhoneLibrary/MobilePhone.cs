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

namespace MobilePhone {
    public abstract class MobilePhone {
        public abstract ScreenBase Screen { get; }
        public abstract MicrophoneBase Microphone { get; }
        public abstract BatteryBase Battery { get; }
        public abstract SpeakerBase Speaker { get; }
        public abstract SimCardBase SimCard { get; }
        private void Show(IScreenImage screenImage) { Screen.Show(screenImage); }
        public string GetDescription(){
            var descriptionBuilder = new StringBuilder();
            descriptionBuilder.AppendLine($"Screen Type: {Screen.ToString()}");
            descriptionBuilder.AppendLine($"Microphone Type: {Microphone.ToString()}");
            descriptionBuilder.AppendLine($"Battery Type: {Battery.ToString()}");
            descriptionBuilder.AppendLine($"Speaker Type: {Speaker.ToString()}");
            descriptionBuilder.AppendLine($"SimCard Type: {SimCard.ToString()}");
            return descriptionBuilder.ToString();
        }
    }
}
