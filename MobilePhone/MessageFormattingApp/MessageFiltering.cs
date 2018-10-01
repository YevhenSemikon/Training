using MobilePhone;
using MobilePhone.CommonUtilities;
using MobilePhone.MobileComponents.Battery;
using MobilePhone.MobileComponents.Charger;
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
        MessageAction.FormatDelegate Formatter = MessageAction.NoneFormat;
        private int disabledItemIndex = -1;
        private int selectedMessageIndex = 0;
        private int selectedCallIndex = 0;
        Font myFont = new Font("Aerial", 10, FontStyle.Regular | FontStyle.Italic);
        HashSet<string> users;
        HashSet<string> phones;
        SimCorpMobilePhone mobile;
        Provider Provider;
        ICharge phoneCharger;
        ICharge noCharger;

        public MessageFiltering() {
            InitializeComponent();
            this.FormattingListComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.FormattingListComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.FormattingListComboBox_DrawItem);
            mobile = new SimCorpMobilePhone(new BatteryChargeLevelTask());
            Provider = new ProviderThread();
            phoneCharger = new iPhoneCharger();
            noCharger = new NullCharger();
            users = new HashSet<string>() { "None" };
            phones = new HashSet<string>() { "None" };
            mobile.ChargerComponent = noCharger;
            mobile.Storage.OnMessageAdd += ShowMessage;
            mobile.Battery.ChargeLevel.OnChargingLevelChange += UpdateProgressBar;
            ChargingBar.Value = mobile.Battery.ChargeLevel.CurrentChargeLevel;
            Provider.StartCallsCreation(mobile.Storage);
        }

        public void ShowMessage(List<MobilePhone.Message> messages) {
            if (MessageListView.InvokeRequired) {
                try {
                    Invoke(new Storage.MessageAddDelegate(ShowMessage), messages);
                }
                catch (ObjectDisposedException) {
                    // Ignore. Control is disposed cannot update the UI. 
                }
            }
            else {
                List<Message> filteredMessages = messages;
                MessageListView.Items.Clear();

                //Conditions
                string selectedUser = userMessageFilterComboBox.SelectedItem?.ToString();
                DateTime selectedStartDate = startMessageDateTimePicker.Value;
                DateTime selectedEndDate = endMessageDateTimePicker.Value;
                string selectedText = FilterMessageTextBox.Text;
                bool ANDCondition = ANDConditionMessageCheckBox.Checked;

                //Enable or Disable ANDCondition checkBox if more than 1 condition specified
                if ((selectedUser == "None" || string.IsNullOrEmpty(selectedUser)) && string.IsNullOrEmpty(selectedText)) {
                    ANDConditionMessageCheckBox.Visible = false;
                    ANDConditionMessageCheckBox.Checked = false;
                }
                else { ANDConditionMessageCheckBox.Visible = true; }

                //Filter Messages by user input conditions
                filteredMessages = MessageAction.FilterMessage(filteredMessages, selectedUser,
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

                //Add Users into userMessageFilterComboBox from new coming messages                 
                var userItemArray = new string[userMessageFilterComboBox.Items.Count];
                userMessageFilterComboBox.Items.CopyTo(userItemArray, 0);
                selectedMessageIndex = userMessageFilterComboBox.SelectedIndex;
                if (!users.SetEquals(userItemArray)) {
                    this.userMessageFilterComboBox.Items.Clear();
                    foreach (string user in users) { userMessageFilterComboBox.Items.Add(user); }
                    userMessageFilterComboBox.SelectedIndex = selectedMessageIndex;
                }
            }
        }
        public void ShowCalls(List<List<MobilePhone.Call>> groupCallsList) {
            callsTree.BeginUpdate();
            // Create new object and add incoming collection to avoid change of collection during processing
            List<List<Call>> GroupCalls = new List<List<Call>>();
            GroupCalls.AddRange(groupCallsList);
            callsTree.Nodes.Clear();
            foreach (List<Call> callsList in GroupCalls) {
                string selectedPhone = PhoneFilterCallsComboBox.SelectedItem?.ToString();
                DateTime selectedStartDate = StartCallsDateTimePicker.Value;
                DateTime selectedEndDate = EndCallsDateTimePicker.Value;
                string selectedName = FilterCallsTextBox.Text;
                bool ANDCondition = ANDConditionCallCheckBox.Checked;
                Direction directionCallCondition = (Direction)DirectionCallFilterComboBox.SelectedIndex;

                //Enable or Disable ANDCondition checkBox if more than 1 condition specified
                if ((directionCallCondition == Direction.None || directionCallCondition == Direction.NoSpecified)
                    && (selectedPhone == "None" || string.IsNullOrEmpty(selectedPhone))
                    && string.IsNullOrEmpty(selectedName)) {
                    ANDConditionCallCheckBox.Visible = false;
                    ANDConditionCallCheckBox.Checked = false;
                }
                else { ANDConditionCallCheckBox.Visible = true; }

                //Filter Calls by user input conditions
                List<Call> filteredCalls = CallAction.FilterCalls(callsList, selectedPhone,
                    selectedStartDate, selectedEndDate, selectedName, ANDCondition, directionCallCondition);

                //Display calls
                if (filteredCalls.Count != 0) {

                    var mainNode = callsTree.Nodes.Add($"{filteredCalls[0].CallContact.Name} {filteredCalls[0].CallContact.LastName} ({filteredCalls.Count})");
                    foreach (Call calls in filteredCalls) {
                        phones.Add(calls.CallContact.ContactPhoneNumber);
                        mainNode.Nodes.Add($"{calls.Direction} {calls.CallContact.Name} {calls.CallContact.ContactPhoneNumber} {calls.ReceivingCallTime}");
                    }

                    var phonesItemArray = new string[PhoneFilterCallsComboBox.Items.Count];
                    PhoneFilterCallsComboBox.Items.CopyTo(phonesItemArray, 0);
                    selectedCallIndex = PhoneFilterCallsComboBox.SelectedIndex;
                    if (!phones.SetEquals(phonesItemArray)) {
                        this.PhoneFilterCallsComboBox.Items.Clear();
                        foreach (string phone in phones) { PhoneFilterCallsComboBox.Items.Add(phone); }
                        PhoneFilterCallsComboBox.SelectedIndex = selectedCallIndex;
                    }
                }
            }
            callsTree.EndUpdate();
        }

        //Message page UI control
        private void FormattingListComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            disabledItemIndex = FormattingListComboBox.SelectedIndex;
            string itemName = FormattingListComboBox.SelectedItem.ToString();
            if (itemName == "None") { Formatter = MessageAction.NoneFormat; }
            else if (itemName == "Start with Date") { Formatter = MessageAction.StartWithDate; }
            else if (itemName == "End with Date") { Formatter = MessageAction.EndWithDate; }
            else if (itemName == "UpperCase") { Formatter = MessageAction.UpperFormat; }
            else if (itemName == "LowerCase") { Formatter = MessageAction.LowerFormat; }
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

        private void UserFilterComboBox_TextChanged(object sender, EventArgs e) { ShowMessage(mobile.Storage.MessagesList); }
        private void MessageFilterTextBox_TextChanged(object sender, EventArgs e) { ShowMessage(mobile.Storage.MessagesList); }
        private void ANDConditionMessageCheckBox_CheckedChanged(object sender, EventArgs e) { ShowMessage(mobile.Storage.MessagesList); }
        private void StartMessageDateTimePicker_ValueChanged(object sender, EventArgs e) { ShowMessage(mobile.Storage.MessagesList); }
        private void EndMessageDateTimePicker_ValueChanged(object sender, EventArgs e) { ShowMessage(mobile.Storage.MessagesList); }
        private void StartMessageButton_Click(object sender, EventArgs e) {
            if (StartMessageButton.Text == "Start Message Creation") {
                Provider.StartMessageCreation(mobile.Storage);
                Thread.Sleep(100);
                StartMessageButton.Text = "Stop Message Creation";
            }
            else {
                Provider.StopMessageCreation();
                Thread.Sleep(100);
                StartMessageButton.Text = "Start Message Creation";
            }
        }

        //Calls page UI control        
        private void PhoneFilterCallsComboBox_SelectedIndexChanged(object sender, EventArgs e) { ShowCalls(mobile.Storage.GroupedCallsList); }
        private void FilterCallsTextBox_TextChanged(object sender, EventArgs e) { ShowCalls(mobile.Storage.GroupedCallsList); }
        private void StartCallsDateTimePicker_ValueChanged(object sender, EventArgs e) { ShowCalls(mobile.Storage.GroupedCallsList); }
        private void EndCallsDateTimePicker_ValueChanged(object sender, EventArgs e) { ShowCalls(mobile.Storage.GroupedCallsList); }
        private void ANDConditionCallCheckBox_CheckedChanged(object sender, EventArgs e) { ShowCalls(mobile.Storage.GroupedCallsList); }
        private void GetCallsButton_Click(object sender, EventArgs e) { ShowCalls(mobile.Storage.GroupedCallsList); }
        private void DirectionCallFilterComboBox_SelectedIndexChanged(object sender, EventArgs e) { ShowCalls(mobile.Storage.GroupedCallsList); }

        // Charge UI control
        private void ChargeButton_Click(object sender, EventArgs e) {
            if (ChargeButton.Text == "Charge") {
                mobile.ChargerComponent = phoneCharger; //Connect charger to phone
                Thread.Sleep(100);
                ChargeButton.Text = "Stop Charge";
            }
            else {
                mobile.ChargerComponent = noCharger; //Disconnect charger from phone
                Thread.Sleep(100);
                ChargeButton.Text = "Charge";
            }
        }

        public void UpdateProgressBar(int value) {
            if (ChargingBar.InvokeRequired) {
                try {
                    Invoke(new BatteryChargeLevel.ChargeLevelChange(UpdateProgressBar), value);
                }
                catch (ObjectDisposedException) {
                    // Ignore. Control is disposed cannot update the UI. 
                }
            }
            else { ChargingBar.Value = value; }
        }
    }
}


