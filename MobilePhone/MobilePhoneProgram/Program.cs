using MobilePhone;
using System;
using MobilePhone.MobileComponents.AudioJack;
using MobilePhone.MobilePhoneProgram;

namespace MobilePhoneProgram {
    class Program {
        static void Main(string[] args) {
            ConsoleOutput consoleOutput = new ConsoleOutput();
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();          
            var newMessage = new Message("1323", "hi", DateTime.Now);
            mobile.Storage.AddMessage(newMessage);
            var messages = mobile.Storage.MessagesList;
            foreach (Message message in messages)
            {
                Console.WriteLine(message.User+" "+message.Text+" "+message.ReceivingTime);
            }
            //Console.WriteLine(messages);
            //consoleOutput.WriteLine(mobile.GetDescription());
            //consoleOutput.WriteLine("Press any key to continue...");
            //Console.ReadKey();
            //var consolePlaybackComponent = new ConsolePlaybackComponent();
            //IPlayback playbackComponent = consolePlaybackComponent.SelectPlaybackComponent(consoleOutput);
            //mobile.PlaybackComponent = playbackComponent;
            //consoleOutput.WriteLine("Set playback to Mobile...");
            //mobile.Play();
            //consoleOutput.WriteLine("Press any key to continue...");
            //Console.ReadKey();
            //var consoleChargerComponent = new ConsoleChargeComponent();
            //mobile.ChargerComponent = consoleChargerComponent.SelectChargerComponent(consoleOutput);
            //consoleOutput.WriteLine("Set charger to Mobile...");
            //mobile.Charge();
            //consoleOutput.WriteLine("Press any key to continue...");
            //Console.ReadKey();
            //Console.Clear();
            //consoleOutput.WriteLine(mobile.GetDescription());
        }
    }
}

