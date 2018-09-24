using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhone;
using MobilePhone.MobileComponents;
using MobilePhone.MobileComponents.AudioJack;
using MobilePhone.MobilePhoneProgram;

namespace UnitTestMobilePhone {
    [TestClass]
    public class AudioJackTest {
        [TestMethod]
        public void iPhoneHeadsetTest() {
            var mobile = new SimCorpMobilePhone();
            var consoleOutput = new ConsoleOutput();
            IPlayback playbackComponent = new iPhoneHeadset(consoleOutput);
            mobile.PlaybackComponent = playbackComponent;
            var expected1 = "iPhoneHeadset playback selected";
            var actual1 = consoleOutput.textTest;
            Assert.AreEqual(expected1, actual1);
            mobile.Play();
            var expected = "iPhoneHeadset sound";
            var actual = consoleOutput.textTest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SamsungHeadsetTest() {
            var mobile = new SimCorpMobilePhone();
            var consoleOutput = new ConsoleOutput();
            IPlayback playbackComponent = new SamsungHeadset(consoleOutput);
            mobile.PlaybackComponent = playbackComponent;
            var expected1 = "SamsungHeadset playback selected";
            var actual1 = consoleOutput.textTest;
            Assert.AreEqual(expected1, actual1);
            mobile.Play();
            var expected = "SamsungHeadset sound";
            var actual = consoleOutput.textTest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PhoneSpeakerTest() {
            var mobile = new SimCorpMobilePhone();
            var consoleOutput = new ConsoleOutput();
            IPlayback playbackComponent = new PhoneSpeaker(consoleOutput);
            mobile.PlaybackComponent = playbackComponent;
            var expected1 = "PhoneSpeaker playback selected";
            var actual1 = consoleOutput.textTest;
            Assert.AreEqual(expected1, actual1);
            mobile.Play();
            var expected = "PhoneSpeaker sound";
            var actual = consoleOutput.textTest;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UnofficialiPhoneHeadsetTest() {
            var mobile = new SimCorpMobilePhone();
            var consoleOutput = new ConsoleOutput();
            IPlayback playbackComponent = new UnofficialiPhoneHeadset(consoleOutput);
            mobile.PlaybackComponent = playbackComponent;
            var expected1 = "UnofficialiPhoneHeadset playback selected";
            var actual1 = consoleOutput.textTest;
            Assert.AreEqual(expected1, actual1);
            mobile.Play();
            var expected = "UnofficialiPhoneHeadset sound";
            var actual = consoleOutput.textTest;
            Assert.AreEqual(expected, actual);
        }

    }
}
