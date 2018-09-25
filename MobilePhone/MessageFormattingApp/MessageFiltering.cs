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

    public partial class MessageFiltering : Form {
        Storage.FormatDelegate Formatter = Storage.NoneFormat;

        private int disabledItemIndex = -1;
        private int selectedIndex = 0;
        private Thread threadGenerator;
        Font myFont = new Font("Aerial", 10, FontStyle.Regular | FontStyle.Italic);
        HashSet<string> users = new HashSet<string>() { "None" };
        SimCorpMobilePhone mobile = new SimCorpMobilePhone();
        SMSProviderThread smsProvider = new SMSProviderThread();

        public MessageFiltering() {
            InitializeComponent();
            this.FormattingListComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.FormattingListComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.FormattingListComboBox_DrawItem);
            mobile.Storage.MessageAdd += ShowMessage;
            //AddSMSProviderDelegate addSMSProvider = SMSProvider.CreateMessages;
            // addSMSProvider.BeginInvoke(messageNumber: 100, pause: 1000, storage: mobile.Storage, callback: null, @object: null);
        }

        public void ShowMessage(List<MobilePhone.Message> messages) {
            if (MessageListView.InvokeRequired) {
                Invoke(new Storage.MessageAddDelegate(ShowMessage), messages);
            }
            else {
                List<Message> filteredMessages = messages;
                MessageListView.Items.Clear();

                //Conditions
                string selectedUser = userFilterComboBox.SelectedItem?.ToString();
                DateTime selectedStartDate = startDateTimePicker.Value;
                DateTime selectedEndDate = endDateTimePicker.Value;
                string selectedText = messageFilterTextBox.Text;
                bool ANDCondition = ANDConditionCheckBox.Checked;

                //Enable or Disable ANDCondition checkBox if more than 1 condition specified
                if ((selectedUser == "None" || string.IsNullOrEmpty(selectedUser)) && string.IsNullOrEmpty(selectedText)) {
                    ANDConditionCheckBox.Visible = false;
                }
                else { ANDConditionCheckBox.Visible = true; }

                //Filter Messages by user input conditions
                filteredMessages = mobile.Storage.FilterMessage(filteredMessages, selectedUser,
                   selectedStartDate, selectedEndDate, selectedText, ANDCondition);

                //Display messages
                foreach (Message message in filteredMessages) {
                    users.Add(message.User);
                    string formattedMessage = $"{Formatter(message.Text)}{ Environment.NewLine}";
                    MessageListView.Items.Add(new ListViewItem(new[] { message.User, formattedMessage }));

                    //Enable AutoScroll  
                    if (AutoScrollCheckBox.Checked) {
                        MessageListView.Items[MessageListView.Items.Count - 1].EnsureVisible();
                    }
                }

                //Add Users into userFilterComboBox from new coming messages                 
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

        private void UserFilterComboBox_TextChanged(object sender, EventArgs e) {
            ShowMessage(mobile.Storage.MessagesList);
        }

        private void MessageFilterTextBox_TextChanged(object sender, EventArgs e) {
            ShowMessage(mobile.Storage.MessagesList);
        }

        private void ANDConditionCheckBox_CheckedChanged(object sender, EventArgs e) {
            ShowMessage(mobile.Storage.MessagesList);
        }

        private void StartDateTimePicker_ValueChanged(object sender, EventArgs e) {
            ShowMessage(mobile.Storage.MessagesList);
        }

        private void EndDateTimePicker_ValueChanged(object sender, EventArgs e) {
            ShowMessage(mobile.Storage.MessagesList);
        }

        private void StartMessageButton_Click(object sender, EventArgs e) {
            if (StartMessageButton.Text == "Start Receiving") {
                threadGenerator = smsProvider.Start(messageNumber: 100, pause: 1000, storage: mobile.Storage);
                StartMessageButton.Text = "Stop Receiving";
            }
            else {
                smsProvider.Stop(threadGenerator);
                StartMessageButton.Text = "Start Receiving";
            }
        }
    }
}


