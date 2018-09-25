using MobilePhone;
using MobilePhone.MobileComponents.AudioJack;
using MobilePhone.MobileComponents.Charger;
using MobilePhone.MobilePhoneApp;
using System;
using System.Windows.Forms;

namespace MobilePhoneApp {
    public partial class Form1 : Form {
        SimCorpMobilePhone mobile = new SimCorpMobilePhone();
        public Form1() {
            InitializeComponent();
        }
        public void button1_Click(object sender, EventArgs e) {
            textBox1.Clear();
            label1.Text = "Select playback component";
            label1.Name = "PlaybackComponent";
            label1.Visible = true;
            //Initialize radiobutton1;
            radioButton1.Text = "iPhone Headset";
            radioButton1.Visible = true;
            radioButton1.Checked = true;
            //Initialize radiobutton2;
            radioButton2.Text = "Samsung Headset";
            radioButton2.Visible = true;
            //Initialize radiobutton3;
            radioButton3.Text = "Unofficial iPhone Headset";
            radioButton3.Visible = true;
            //Initialize radiobutton4;
            radioButton4.Text = "Phone Speaker";
            radioButton4.Visible = true;
            //Initialize ApplyButton;
            button4.Visible = true;
        }
        public void button2_Click(object sender, EventArgs e) {
            textBox1.Clear();
            label1.Text = "Select charge component";
            label1.Name = "ChargeComponent";
            label1.Visible = true;
            //Initialize radiobutton1;
            radioButton1.Text = "iPhone Charger";
            radioButton1.Visible = true;
            radioButton1.Checked = true;
            //Initialize radiobutton2;
            radioButton2.Text = "Samsung Charger";
            radioButton2.Visible = true;
            //Initialize radiobutton3;
            radioButton3.Text = "Unofficial iPhone Charger";
            radioButton3.Visible = true;
            //Initialize radiobutton4;
            radioButton4.Visible = false;
            //Initialize ApplyButton;
            button4.Visible = true;
        }
        private void button3_Click(object sender, EventArgs e) {
            textBox1.Clear();
            label1.Visible = false;
            //Initialize radiobutton1;
            radioButton1.Visible = false;
            //Initialize radiobutton2;
            radioButton2.Visible = false;
            //Initialize radiobutton3;
            radioButton3.Visible = false;
            //Initialize radiobutton4;
            radioButton4.Visible = false;
            //Initialize ApplyButton;
            button4.Visible = false;
            var text = mobile.GetDescription();
            textBox1.AppendText(text);
        }
        private void button4_Click(object sender, EventArgs e) {
            WinFormOuput winformOutput = new WinFormOuput(textBox1);
            textBox1.Clear();
            label1.Visible = false;
            //Initialize radiobutton1;
            radioButton1.Visible = false;
            //Initialize radiobutton2;
            radioButton2.Visible = false;
            //Initialize radiobutton3;
            radioButton3.Visible = false;
            //Initialize radiobutton4;
            radioButton4.Visible = false;
            //Initialize ApplyButton;
            button4.Visible = false;
            if (label1.Name == "PlaybackComponent") {
                SetPlaybackComponentToMobile(winformOutput);
            }
            else if (label1.Name == "ChargeComponent") {
                SetChargeComponentToMobile(winformOutput);
            }
        }
        private void SetPlaybackComponentToMobile(WinFormOuput winformOutput) {
            IPlayback playbackComponent = null;
            if (radioButton1.Checked) {
                playbackComponent = new iPhoneHeadset(winformOutput);
            }
            else if (radioButton2.Checked) {
                playbackComponent = new SamsungHeadset(winformOutput);
            }
            else if (radioButton3.Checked) {
                playbackComponent = new UnofficialiPhoneHeadset(winformOutput);
            }
            else if (radioButton4.Checked) {
                playbackComponent = new PhoneSpeaker(winformOutput);
            }
            mobile.PlaybackComponent = playbackComponent;
            winformOutput.WriteLine("Set playback to Mobile...");
            mobile.Play();
        }
        private void SetChargeComponentToMobile(WinFormOuput winformOutput) {
            ICharge chargeComponent = null;
            if (radioButton1.Checked) {
                chargeComponent = new iPhoneCharger(winformOutput);
            }
            else if (radioButton2.Checked) {
                chargeComponent = new SamsungCharger(winformOutput);
            }
            else if (radioButton3.Checked) {
                chargeComponent = new UnofficialiPhoneCharger(winformOutput);
            }
            mobile.ChargerComponent = chargeComponent;
            winformOutput.WriteLine("Set charger to Mobile...");
            mobile.Charge();
        }
    }
}
