using MobilePhone.MobileComponents;
using System.Windows.Forms;

namespace MobilePhone.MobilePhoneApp {
    public class WinFormOuput : IOutput {
        private TextBox vtextBox;
        public WinFormOuput(TextBox textBox) {
            vtextBox = textBox;
        }
        public void WriteLine(string text) {
            vtextBox.AppendText(text + System.Environment.NewLine);
        }
        public void Write(string text) {
            vtextBox.AppendText(text);
        }
    }
}
