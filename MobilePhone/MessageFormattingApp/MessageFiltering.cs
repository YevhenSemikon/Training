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
        private int selectedIndex = 0;
        private string previousMessageStartButton = "Start Message Creation";
        Font myFont = new Font("Aerial", 10, FontStyle.Regular | FontStyle.Italic);
        HashSet<string> users;
        SimCorpMobilePhone mobile;
        Provider Provider;
        ICharge phoneCharger;
        ICharge noCharger;

        public MessageFiltering() {
            InitializeComponent();
            this.FormattingListComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            this.FormattingListComboBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.FormattingListComboBox_DrawItem);
            mobile = new SimCorpMobilePhone(new BatteryChargeLevelTask());
            Provider = new ProviderTask();
            phoneCharger = new iPhoneCharger();
            noCharger = new NullCharger();
            users = new HashSet<string>() { "None" };
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

        public void ShowCalls(List<List<MobilePhone.Call>> groupCallsList)
        {
            callsTree.BeginUpdate();
            List<List<Call>> GroupCalls = new List<List<Call>>();            
                GroupCalls.AddRange(groupCallsList);
            callsTree.Nodes.Clear();
            foreach (List<Call> callsList in GroupCalls)
            {
                string selectedUser = userFilterComboBox.SelectedItem?.ToString();
                DateTime selectedStartDate = startDateTimePicker.Value;
                 DateTime selectedEndDate = endDateTimePicker.Value;
                string selectedText = messageFilterTextBox.Text;
                bool ANDCondition = ANDConditionCheckBox.Checked;
                List<Call> filteredCalls = CallAction.FilterCalls(callsList, selectedUser,
                    selectedStartDate, selectedEndDate, selectedText, ANDCondition);
                if (filteredCalls.Count != 0)
                {
                    var mainNode = callsTree.Nodes.Add(filteredCalls[0].CallContact.Name + " " + filteredCalls[0].CallContact.LastName + " (" +
                        filteredCalls.Count + ")");
                    foreach (Call calls in filteredCalls)
                    {
                        mainNode.Nodes.Add(calls.Direction + " " + calls.CallContact.Name + " " + calls.CallContact.ContactPhoneNumber + " " +
                            calls.ReceivingCallTime);
                    }
                }
            }
            callsTree.EndUpdate();
        }

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

        private void UserFilterComboBox_TextChanged(object sender, EventArgs e) {
            ShowMessage(mobile.Storage.MessagesList);
            ShowCalls(mobile.Storage.GroupedCallsList);
        }

        private void MessageFilterTextBox_TextChanged(object sender, EventArgs e) {
            ShowMessage(mobile.Storage.MessagesList);
            ShowCalls(mobile.Storage.GroupedCallsList);
        }

        private void ANDConditionCheckBox_CheckedChanged(object sender, EventArgs e) {
            ShowMessage(mobile.Storage.MessagesList);
            ShowCalls(mobile.Storage.GroupedCallsList);
        }

        private void StartDateTimePicker_ValueChanged(object sender, EventArgs e) {
            ShowMessage(mobile.Storage.MessagesList);
            ShowCalls(mobile.Storage.GroupedCallsList);
        }

        private void EndDateTimePicker_ValueChanged(object sender, EventArgs e) {
            ShowMessage(mobile.Storage.MessagesList);
            ShowCalls(mobile.Storage.GroupedCallsList);
        }

        private void StartMessageButton_Click(object sender, EventArgs e) {            
            if (tabInfoControl.SelectedTab.Name == "CallsPage")
            {
                if (mobile.Storage.GroupedCallsList.Count == 0)
                {
                    MessageBox.Show("No Calls in the Mobile Storage, please try later");
                }
                 ShowCalls(mobile.Storage.GroupedCallsList);
            }
            else
            {
                if (StartMessageButton.Text == "Start Message Creation")
                {

                    Provider.StartMessageCreation(mobile.Storage);
                    Thread.Sleep(100);
                    StartMessageButton.Text = "Stop Message Creation";
                }
                else
                {              
                    Provider.StopMessageCreation();
                    Thread.Sleep(100);
                    StartMessageButton.Text = "Start Message Creation";
                }
                previousMessageStartButton = StartMessageButton.Text;
            }

        }

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
            else {
                ChargingBar.Value = value;
            }
        }

        private void TabInfoControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabInfoControl.SelectedTab.Name == "CallsPage")
            {
                StartMessageButton.Text = "Get Calls";               
                FormattingListComboBox.Enabled = false;
                AutoScrollCheckBox.Visible = false;
            }
            else
            {
                StartMessageButton.Text = previousMessageStartButton;
                FormattingListComboBox.Enabled = true;
                AutoScrollCheckBox.Visible = true;
            }
        }
    }
}


