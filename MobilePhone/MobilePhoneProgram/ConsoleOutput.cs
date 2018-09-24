using MobilePhone.MobileComponents.AudioJack;
using MobilePhone.MobileComponents.Charger;
using MobilePhone.MobileComponents;
using System;
using System.Text;

namespace MobilePhone.MobilePhoneProgram {
    public class ConsoleOutput : IOutput {
        public string textTest;
        public void Write(string text) {
            Console.Write(text);
        }
        public void WriteLine(string text) {
            Console.WriteLine(text);
            textTest = text;
        }
        internal string GetChosenIndex(IPlayback playbackComponent) {
            var text = new StringBuilder();
            text.Append("Select playback component (specify index): " + System.Environment.NewLine);
            text.Append("1 - iPhoneHeadset" + System.Environment.NewLine);
            text.Append("2 - SamsungHeadset" + System.Environment.NewLine);
            text.Append("3 - UnofficialiPhoneHeadset" + System.Environment.NewLine);
            text.Append("4 - PhoneSpeaker");
            Console.WriteLine(text.ToString());
            string playbackIndex = Console.ReadLine();
            return playbackIndex;
        }
        internal string GetChosenIndex(ICharge chargeComponent) {
            var text = new StringBuilder();
            text.Append("Select charger component (specify index): " + System.Environment.NewLine);
            text.Append("1 - iPhoneCharger" + System.Environment.NewLine);
            text.Append("2 - SamsungCharger" + System.Environment.NewLine);
            text.Append("3 - UnofficialiPhoneCharger");
            Console.WriteLine(text.ToString());
            string playbackIndex = Console.ReadLine();
            return playbackIndex;
        }
    }
}
