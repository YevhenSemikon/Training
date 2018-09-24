using MobilePhone.MobileComponents.AudioJack;
using MobilePhone.MobilePhoneProgram;
using System;

namespace MobilePhoneProgram {
    public class ConsolePlaybackComponent {
        private IPlayback playbackComponent;
        public IPlayback SelectPlaybackComponent(ConsoleOutput consoleOutput) {
            Console.Clear();
            string playbackIndex =consoleOutput.GetChosenIndex(playbackComponent);
            switch (playbackIndex) {
                case "1":
                playbackComponent = new iPhoneHeadset(consoleOutput);
                break;
                case "2":
                playbackComponent = new SamsungHeadset(consoleOutput);
                break;
                case "3":
                playbackComponent = new UnofficialiPhoneHeadset(consoleOutput);
                break;
                case "4":
                playbackComponent = new PhoneSpeaker(consoleOutput);
                break;
                default:
                consoleOutput.WriteLine("Unknown playback component selected, please select component from the list.");
                consoleOutput.WriteLine("Press any key to continue...");
                Console.ReadKey();
                playbackComponent = SelectPlaybackComponent(consoleOutput);
                break;
            }
            return playbackComponent;
        }
    }
}
