using MobilePhone;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Message = MobilePhone.Message;

namespace MessageFormattingApp {

    public partial class MessageFormatting : Form {
        Storage.FormatDelegate Formatter = Storage.NoneFormat;

        private int disabledItemIndex = -1;
        private int selectedIndex = 0;
        Font myFont = new Font("Aerial", 10, FontStyle.Regular | FontStyle.Italic);
        HashSet<string> users = new HashSet<string>() { "None" };
        SimCorpMobilePhone mobile = new SimCorpMobilePhone();

        public MessageFormatting() {
            InitializeComponent();
            this.FormattingListComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.FormattingListComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.FormattingListComboBox_DrawItem);
            SimCorpMobilePhone.AddSMSProviderDelegate addSMSProvider = mobile.AddSMSProvider;
            mobile.Storage.MessageAdd += ShowMessage;
            addSMSProvider.BeginInvoke(null, null);
        }

        public void ShowMessage(List<MobilePhone.Message> messages) {
            if (MessageListView.InvokeRequired) {
                Invoke(new Storage.MessageAddDelegate(ShowMessage), messages);
            }
            else {
                List<Message> filteredMessages = messages.ToList();
                MessageListView.Items.Clear();
                string selectedUserName = userFilterComboBox.SelectedItem?.ToString();
                DateTime selectedStartDate = startDateTimePicker.Value;
                DateTime selectedEndDate = endDateTimePicker.Value;
                string selectedText = messageFilterTextBox.Text;
                if ((selectedUserName=="None" || string.IsNullOrEmpty(selectedUserName)) && string.IsNullOrEmpty(selectedText)) {
                    ANDConditionCheckBox.Visible = false;
                }
                else {                   
                    ANDConditionCheckBox.Visible = true;
                }
                bool ANDCondition = ANDConditionCheckBox.Checked;
                filteredMessages = mobile.Storage.FilterMessage(filteredMessages, selectedUserName,
                    selectedStartDate, selectedEndDate, selectedText, ANDCondition);
                foreach (Message message in filteredMessages) {
                    users.Add(message.User);
                    string formattedMessage = $"{Formatter(message.Text)}{ Environment.NewLine}";
                    MessageListView.Items.Add(new ListViewItem(new[] { message.User, formattedMessage }));
                    if (AutoScrollCheckBox.Checked) {
                        MessageListView.Items[MessageListView.Items.Count - 1].EnsureVisible();
                    }
                }
                //Add Users into userFilterComboBox from existing messages                 
                var userItemArray = new string[userFilterComboBox.Items.Count];
                userFilterComboBox.Items.CopyTo(userItemArray, 0);
                selectedIndex = userFilterComboBox.SelectedIndex;
                if (!users.SetEquals(userItemArray)) {
                    this.userFilterComboBox.Items.Clear();
                    foreach (string user in users) { userFilterComboBox.Items.Add(user); }
                    userFilterComboBox.SelectedIndex = selectedIndex;
                }
            }
        }
        private void FormattingListComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            disabledItemIndex = FormattingListComboBox.SelectedIndex;
            string itemName = FormattingListComboBox.SelectedItem.ToString();
            if (itemName == "None") { Formatter = Storage.NoneFormat; }
            else if (itemName == "Start with Date") { Formatter = Storage.StartWithDate; }
            else if (itemName == "End with Date") { Formatter = Storage.EndWithDate; }
            else if (itemName == "UpperCase") { Formatter = Storage.UpperFormat; }
            else if (itemName == "LowerCase") { Formatter = Storage.LowerFormat; }
            ShowMessage(mobile.Storage.MessagesList);
        }
        private void FormattingListComboBox_DrawItem(object sender, DrawItemEventArgs e) {
            if (e.Index == disabledItemIndex) {
                e.Graphics.DrawString(FormattingListComboBox.Items[e.Index].ToString(), myFont, Brushes.Gray, e.Bounds);
            }
            else {
                e.DrawBackground();
                e.Graphics.DrawString(FormattingListComboBox.Items[e.Index].ToString(), myFont, Brushes.Black, e.Bounds);
                e.DrawFocusRectangle();
            }
        }
        private void userFilterComboBox_TextChanged(object sender, EventArgs e) {
            ShowMessage(mobile.Storage.MessagesList);
        }
        private void messageFilterTextBox_TextChanged(object sender, EventArgs e) {
            ShowMessage(mobile.Storage.MessagesList);
        }
        private void ANDConditionCheckBox_CheckedChanged(object sender, EventArgs e) {
            ShowMessage(mobile.Storage.MessagesList);
        }
        private void startDateTimePicker_ValueChanged(object sender, EventArgs e) {
            ShowMessage(mobile.Storage.MessagesList);
        }
        private void endDateTimePicker_ValueChanged(object sender, EventArgs e) {
            ShowMessage(mobile.Storage.MessagesList);
        }
    }
}


