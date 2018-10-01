using MobilePhone.CommonUtilities;
using System;
using System.Threading;

namespace MessageFormattingApp {
    partial class MessageFiltering {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            mobile.Battery.CancelThreads();
            Provider.StopMessageCreation();
            Provider.StopCallsCreation();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.FormattingListComboBox = new System.Windows.Forms.ComboBox();
            this.AutoScrollCheckBox = new System.Windows.Forms.CheckBox();
            this.MessageListView = new System.Windows.Forms.ListView();
            this.User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Message = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.userMessageFilterComboBox = new System.Windows.Forms.ComboBox();
            this.FilterMessageTextBox = new System.Windows.Forms.TextBox();
            this.startMessageDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endMessageDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ANDConditionMessageCheckBox = new System.Windows.Forms.CheckBox();
            this.StartMessageButton = new System.Windows.Forms.Button();
            this.ChargeButton = new System.Windows.Forms.Button();
            this.ChargingBar = new System.Windows.Forms.ProgressBar();
            this.callsTree = new System.Windows.Forms.TreeView();
            this.tabInfoControl = new System.Windows.Forms.TabControl();
            this.MessagesPage = new System.Windows.Forms.TabPage();
            this.CallsPage = new System.Windows.Forms.TabPage();
            this.DirectionCallFilterComboBox = new System.Windows.Forms.ComboBox();
            this.ANDConditionCallCheckBox = new System.Windows.Forms.CheckBox();
            this.GetCallsButton = new System.Windows.Forms.Button();
            this.EndCallsDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StartCallsDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.FilterCallsTextBox = new System.Windows.Forms.TextBox();
            this.PhoneFilterCallsComboBox = new System.Windows.Forms.ComboBox();
            this.tabInfoControl.SuspendLayout();
            this.MessagesPage.SuspendLayout();
            this.CallsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormattingListComboBox
            // 
            this.FormattingListComboBox.Items.AddRange(new object[] {
            "None",
            "Start with Date",
            "End with Date",
            "UpperCase",
            "LowerCase"});
            this.FormattingListComboBox.Location = new System.Drawing.Point(6, 108);
            this.FormattingListComboBox.Name = "FormattingListComboBox";
            this.FormattingListComboBox.Size = new System.Drawing.Size(161, 21);
            this.FormattingListComboBox.TabIndex = 0;
            this.FormattingListComboBox.Text = "Select Formatting";
            this.FormattingListComboBox.SelectedIndexChanged += new System.EventHandler(this.FormattingListComboBox_SelectedIndexChanged);
            // 
            // AutoScrollCheckBox
            // 
            this.AutoScrollCheckBox.AutoSize = true;
            this.AutoScrollCheckBox.Location = new System.Drawing.Point(130, 85);
            this.AutoScrollCheckBox.Name = "AutoScrollCheckBox";
            this.AutoScrollCheckBox.Size = new System.Drawing.Size(77, 17);
            this.AutoScrollCheckBox.TabIndex = 2;
            this.AutoScrollCheckBox.Text = "Auto Scroll";
            this.AutoScrollCheckBox.UseVisualStyleBackColor = true;
            // 
            // MessageListView
            // 
            this.MessageListView.AutoArrange = false;
            this.MessageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.User,
            this.Message});
            this.MessageListView.Location = new System.Drawing.Point(6, 138);
            this.MessageListView.MultiSelect = false;
            this.MessageListView.Name = "MessageListView";
            this.MessageListView.Size = new System.Drawing.Size(361, 247);
            this.MessageListView.TabIndex = 3;
            this.MessageListView.TileSize = new System.Drawing.Size(330, 30);
            this.MessageListView.UseCompatibleStateImageBehavior = false;
            this.MessageListView.View = System.Windows.Forms.View.Tile;
            // 
            // userMessageFilterComboBox
            // 
            this.userMessageFilterComboBox.FormattingEnabled = true;
            this.userMessageFilterComboBox.Items.AddRange(new object[] {
            "None"});
            this.userMessageFilterComboBox.Location = new System.Drawing.Point(6, 6);
            this.userMessageFilterComboBox.Name = "userMessageFilterComboBox";
            this.userMessageFilterComboBox.Size = new System.Drawing.Size(201, 21);
            this.userMessageFilterComboBox.TabIndex = 4;
            this.userMessageFilterComboBox.Text = "Select Phone Number";
            this.userMessageFilterComboBox.TextChanged += new System.EventHandler(this.UserFilterComboBox_TextChanged);
            // 
            // FilterMessageTextBox
            // 
            this.FilterMessageTextBox.Location = new System.Drawing.Point(6, 33);
            this.FilterMessageTextBox.Name = "FilterMessageTextBox";
            this.FilterMessageTextBox.Size = new System.Drawing.Size(201, 20);
            this.FilterMessageTextBox.TabIndex = 5;
            this.FilterMessageTextBox.TextChanged += new System.EventHandler(this.MessageFilterTextBox_TextChanged);
            // 
            // startMessageDateTimePicker
            // 
            this.startMessageDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startMessageDateTimePicker.Location = new System.Drawing.Point(6, 59);
            this.startMessageDateTimePicker.Name = "startMessageDateTimePicker";
            this.startMessageDateTimePicker.Size = new System.Drawing.Size(95, 20);
            this.startMessageDateTimePicker.TabIndex = 6;
            this.startMessageDateTimePicker.Value = new System.DateTime(2018, 10, 1, 0, 0, 0, 0);
            this.startMessageDateTimePicker.ValueChanged += new System.EventHandler(this.StartMessageDateTimePicker_ValueChanged);
            // 
            // endMessageDateTimePicker
            // 
            this.endMessageDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endMessageDateTimePicker.Location = new System.Drawing.Point(115, 59);
            this.endMessageDateTimePicker.Name = "endMessageDateTimePicker";
            this.endMessageDateTimePicker.Size = new System.Drawing.Size(92, 20);
            this.endMessageDateTimePicker.TabIndex = 7;
            this.endMessageDateTimePicker.Value = new System.DateTime(2018, 10, 1, 23, 59, 59, 0);
            this.endMessageDateTimePicker.ValueChanged += new System.EventHandler(this.EndMessageDateTimePicker_ValueChanged);
            // 
            // ANDConditionMessageCheckBox
            // 
            this.ANDConditionMessageCheckBox.AutoSize = true;
            this.ANDConditionMessageCheckBox.Location = new System.Drawing.Point(6, 85);
            this.ANDConditionMessageCheckBox.Name = "ANDConditionMessageCheckBox";
            this.ANDConditionMessageCheckBox.Size = new System.Drawing.Size(96, 17);
            this.ANDConditionMessageCheckBox.TabIndex = 8;
            this.ANDConditionMessageCheckBox.Text = "AND Condition";
            this.ANDConditionMessageCheckBox.UseVisualStyleBackColor = true;
            this.ANDConditionMessageCheckBox.Visible = false;
            this.ANDConditionMessageCheckBox.CheckedChanged += new System.EventHandler(this.ANDConditionMessageCheckBox_CheckedChanged);
            // 
            // StartMessageButton
            // 
            this.StartMessageButton.Location = new System.Drawing.Point(240, 108);
            this.StartMessageButton.Name = "StartMessageButton";
            this.StartMessageButton.Size = new System.Drawing.Size(127, 24);
            this.StartMessageButton.TabIndex = 9;
            this.StartMessageButton.Text = "Start Message Creation";
            this.StartMessageButton.UseVisualStyleBackColor = true;
            this.StartMessageButton.Click += new System.EventHandler(this.StartMessageButton_Click);
            // 
            // ChargeButton
            // 
            this.ChargeButton.Location = new System.Drawing.Point(13, 45);
            this.ChargeButton.Name = "ChargeButton";
            this.ChargeButton.Size = new System.Drawing.Size(91, 23);
            this.ChargeButton.TabIndex = 10;
            this.ChargeButton.Text = "Charge";
            this.ChargeButton.UseVisualStyleBackColor = true;
            this.ChargeButton.Click += new System.EventHandler(this.ChargeButton_Click);
            // 
            // ChargingBar
            // 
            this.ChargingBar.Location = new System.Drawing.Point(13, 16);
            this.ChargingBar.Name = "ChargingBar";
            this.ChargingBar.Size = new System.Drawing.Size(177, 23);
            this.ChargingBar.TabIndex = 11;
            // 
            // callsTree
            // 
            this.callsTree.Location = new System.Drawing.Point(3, 138);
            this.callsTree.Name = "callsTree";
            this.callsTree.Size = new System.Drawing.Size(365, 247);
            this.callsTree.TabIndex = 12;
            // 
            // tabInfoControl
            // 
            this.tabInfoControl.Controls.Add(this.MessagesPage);
            this.tabInfoControl.Controls.Add(this.CallsPage);
            this.tabInfoControl.Location = new System.Drawing.Point(9, 74);
            this.tabInfoControl.Name = "tabInfoControl";
            this.tabInfoControl.SelectedIndex = 0;
            this.tabInfoControl.Size = new System.Drawing.Size(381, 417);
            this.tabInfoControl.TabIndex = 13;
            // 
            // MessagesPage
            // 
            this.MessagesPage.Controls.Add(this.MessageListView);
            this.MessagesPage.Controls.Add(this.StartMessageButton);
            this.MessagesPage.Controls.Add(this.FormattingListComboBox);
            this.MessagesPage.Controls.Add(this.userMessageFilterComboBox);
            this.MessagesPage.Controls.Add(this.AutoScrollCheckBox);
            this.MessagesPage.Controls.Add(this.FilterMessageTextBox);
            this.MessagesPage.Controls.Add(this.endMessageDateTimePicker);
            this.MessagesPage.Controls.Add(this.ANDConditionMessageCheckBox);
            this.MessagesPage.Controls.Add(this.startMessageDateTimePicker);
            this.MessagesPage.Location = new System.Drawing.Point(4, 22);
            this.MessagesPage.Name = "MessagesPage";
            this.MessagesPage.Padding = new System.Windows.Forms.Padding(3);
            this.MessagesPage.Size = new System.Drawing.Size(373, 391);
            this.MessagesPage.TabIndex = 0;
            this.MessagesPage.Text = "Messages";
            this.MessagesPage.UseVisualStyleBackColor = true;
            // 
            // CallsPage
            // 
            this.CallsPage.Controls.Add(this.DirectionCallFilterComboBox);
            this.CallsPage.Controls.Add(this.ANDConditionCallCheckBox);
            this.CallsPage.Controls.Add(this.GetCallsButton);
            this.CallsPage.Controls.Add(this.EndCallsDateTimePicker);
            this.CallsPage.Controls.Add(this.StartCallsDateTimePicker);
            this.CallsPage.Controls.Add(this.FilterCallsTextBox);
            this.CallsPage.Controls.Add(this.PhoneFilterCallsComboBox);
            this.CallsPage.Controls.Add(this.callsTree);
            this.CallsPage.Location = new System.Drawing.Point(4, 22);
            this.CallsPage.Name = "CallsPage";
            this.CallsPage.Padding = new System.Windows.Forms.Padding(3);
            this.CallsPage.Size = new System.Drawing.Size(373, 391);
            this.CallsPage.TabIndex = 1;
            this.CallsPage.Text = "Calls";
            this.CallsPage.UseVisualStyleBackColor = true;
            // 
            // DirectionCallFilterComboBox
            // 
            this.DirectionCallFilterComboBox.FormattingEnabled = true;
            this.DirectionCallFilterComboBox.Items.AddRange(new object[] {
            Direction.None,
            Direction.Incoming,
            Direction.Outgoing
            });
            this.DirectionCallFilterComboBox.Location = new System.Drawing.Point(6, 59);
            this.DirectionCallFilterComboBox.Name = "DirectionCallFilterComboBox";
            this.DirectionCallFilterComboBox.Size = new System.Drawing.Size(201, 21);
            this.DirectionCallFilterComboBox.TabIndex = 20;
            this.DirectionCallFilterComboBox.Text = "Select Call Direction";
            this.DirectionCallFilterComboBox.SelectedIndexChanged += new System.EventHandler(this.DirectionCallFilterComboBox_SelectedIndexChanged);
            // 
            // ANDConditionCallCheckBox
            // 
            this.ANDConditionCallCheckBox.AutoSize = true;
            this.ANDConditionCallCheckBox.Location = new System.Drawing.Point(5, 115);
            this.ANDConditionCallCheckBox.Name = "ANDConditionCallCheckBox";
            this.ANDConditionCallCheckBox.Size = new System.Drawing.Size(96, 17);
            this.ANDConditionCallCheckBox.TabIndex = 19;
            this.ANDConditionCallCheckBox.Text = "AND Condition";
            this.ANDConditionCallCheckBox.UseVisualStyleBackColor = true;
            this.ANDConditionCallCheckBox.CheckedChanged += new System.EventHandler(this.ANDConditionCallCheckBox_CheckedChanged);
            // 
            // GetCallsButton
            // 
            this.GetCallsButton.Location = new System.Drawing.Point(243, 108);
            this.GetCallsButton.Name = "GetCallsButton";
            this.GetCallsButton.Size = new System.Drawing.Size(127, 24);
            this.GetCallsButton.TabIndex = 14;
            this.GetCallsButton.Text = "Get Calls";
            this.GetCallsButton.UseVisualStyleBackColor = true;
            this.GetCallsButton.Click += new System.EventHandler(this.GetCallsButton_Click);
            // 
            // EndCallsDateTimePicker
            // 
            this.EndCallsDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.EndCallsDateTimePicker.Location = new System.Drawing.Point(115, 86);
            this.EndCallsDateTimePicker.Name = "EndCallsDateTimePicker";
            this.EndCallsDateTimePicker.Size = new System.Drawing.Size(92, 20);
            this.EndCallsDateTimePicker.TabIndex = 18;
            this.EndCallsDateTimePicker.Value = new System.DateTime(2018, 10, 1, 23, 59, 59, 0);
            this.EndCallsDateTimePicker.ValueChanged += new System.EventHandler(this.EndCallsDateTimePicker_ValueChanged);
            // 
            // StartCallsDateTimePicker
            // 
            this.StartCallsDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.StartCallsDateTimePicker.Location = new System.Drawing.Point(6, 86);
            this.StartCallsDateTimePicker.Name = "StartCallsDateTimePicker";
            this.StartCallsDateTimePicker.Size = new System.Drawing.Size(95, 20);
            this.StartCallsDateTimePicker.TabIndex = 17;
            this.StartCallsDateTimePicker.Value = new System.DateTime(2018, 10, 1, 0, 0, 0, 0);
            this.StartCallsDateTimePicker.ValueChanged += new System.EventHandler(this.StartCallsDateTimePicker_ValueChanged);
            // 
            // FilterCallsTextBox
            // 
            this.FilterCallsTextBox.Location = new System.Drawing.Point(6, 33);
            this.FilterCallsTextBox.Name = "FilterCallsTextBox";
            this.FilterCallsTextBox.Size = new System.Drawing.Size(201, 20);
            this.FilterCallsTextBox.TabIndex = 16;
            this.FilterCallsTextBox.TextChanged += new System.EventHandler(this.FilterCallsTextBox_TextChanged);
            // 
            // PhoneFilterCallsComboBox
            // 
            this.PhoneFilterCallsComboBox.FormattingEnabled = true;
            this.PhoneFilterCallsComboBox.Items.AddRange(new object[] {
            "None"});
            this.PhoneFilterCallsComboBox.Location = new System.Drawing.Point(6, 6);
            this.PhoneFilterCallsComboBox.Name = "PhoneFilterCallsComboBox";
            this.PhoneFilterCallsComboBox.Size = new System.Drawing.Size(201, 21);
            this.PhoneFilterCallsComboBox.TabIndex = 15;
            this.PhoneFilterCallsComboBox.Text = "Select Phone Number";
            this.PhoneFilterCallsComboBox.SelectedIndexChanged += new System.EventHandler(this.PhoneFilterCallsComboBox_SelectedIndexChanged);
            // 
            // MessageFiltering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(395, 493);
            this.Controls.Add(this.tabInfoControl);
            this.Controls.Add(this.ChargingBar);
            this.Controls.Add(this.ChargeButton);
            this.MaximizeBox = false;
            this.Name = "MessageFiltering";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Message Filtering";
            this.tabInfoControl.ResumeLayout(false);
            this.MessagesPage.ResumeLayout(false);
            this.MessagesPage.PerformLayout();
            this.CallsPage.ResumeLayout(false);
            this.CallsPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox FormattingListComboBox;
        private System.Windows.Forms.CheckBox AutoScrollCheckBox;
        private System.Windows.Forms.ColumnHeader User;
        private System.Windows.Forms.ComboBox userMessageFilterComboBox;
        private System.Windows.Forms.TextBox FilterMessageTextBox;
        private System.Windows.Forms.DateTimePicker startMessageDateTimePicker;
        private System.Windows.Forms.DateTimePicker endMessageDateTimePicker;
        private System.Windows.Forms.ColumnHeader Message;
        private System.Windows.Forms.CheckBox ANDConditionMessageCheckBox;
        private System.Windows.Forms.Button StartMessageButton;
        private System.Windows.Forms.Button ChargeButton;
        private System.Windows.Forms.ProgressBar ChargingBar;
        private System.Windows.Forms.TreeView callsTree;
        private System.Windows.Forms.TabControl tabInfoControl;
        private System.Windows.Forms.TabPage CallsPage;
        private System.Windows.Forms.TabPage MessagesPage;
        private System.Windows.Forms.ListView MessageListView;
        private System.Windows.Forms.Button GetCallsButton;
        private System.Windows.Forms.DateTimePicker EndCallsDateTimePicker;
        private System.Windows.Forms.DateTimePicker StartCallsDateTimePicker;
        private System.Windows.Forms.TextBox FilterCallsTextBox;
        private System.Windows.Forms.ComboBox PhoneFilterCallsComboBox;
        private System.Windows.Forms.CheckBox ANDConditionCallCheckBox;
        private System.Windows.Forms.ComboBox DirectionCallFilterComboBox;
    }
}

