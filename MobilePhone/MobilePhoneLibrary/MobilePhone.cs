using MobilePhone.MobileComponents.Battery;
using MobilePhone.MobileComponents.Speaker;
using MobilePhone.MobileComponents.Microphone;
using MobilePhone.MobileComponents.Screen;
using MobilePhone.MobileComponents.SimCard;
using System.Text;
using MobilePhone.MobileComponents.AudioJack;
using MobilePhone.MobileComponents.Charger;

namespace MobilePhone {
    public abstract class MobilePhone {
        public Storage Storage { get; set; }
        public IPlayback PlaybackComponent { get; set; }
        public ICharge ChargerComponent { get; set; }
        public abstract ScreenBase Screen { get; }
        public abstract MicrophoneBase Microphone { get; }
        public abstract BatteryBase Battery { get; }
        public abstract SpeakerBase Speaker { get; }
        public abstract SimCardBase SimCard { get; }
        private void Show(IScreenImage screenImage) { Screen.Show(screenImage); }
        public string GetDescription() {
            var descriptionBuilder = new StringBuilder();
            descriptionBuilder.AppendLine($"Screen Type: {Screen.ToString()}");
            descriptionBuilder.AppendLine($"Microphone Type: {Microphone.ToString()}");
            descriptionBuilder.AppendLine($"Battery Type: {Battery.ToString()}");
            descriptionBuilder.AppendLine($"Speaker Type: {Speaker.ToString()}");
            descriptionBuilder.AppendLine($"SimCard Type: {SimCard.ToString()}");
            descriptionBuilder.AppendLine($"AudioJack Type: {PlaybackComponent?.ToString() ?? "AudioJack is not set"}");
            descriptionBuilder.AppendLine($"Charger Type: {ChargerComponent?.ToString() ?? "Charger is not set"}");
            return descriptionBuilder.ToString();
        }
        public void Play() {
            PlaybackComponent.Play();
        }
        public void Charge() {
            ChargerComponent.Charge();
        }
    }
}
