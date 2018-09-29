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
            this.Text = "Waiting for completion of all processes before closing";
            mobile.Battery.cancelChargeToken.Cancel();
            mobile.Battery.cancelDisChargeToken.Cancel();
            cancelMessageToken.Cancel();
            smsProvider.vMessageGeneratorTask?.Wait();
            smsProvider.vMessageGeneratorThread?.Abort();
            mobile.Battery.ChargeLevel.vChargingThread?.Abort();
            mobile.Battery.ChargeLevel.vDisChargingThread?.Abort();
            mobile.Battery.ChargeLevel.vDisChargingTask?.Wait();
            mobile.Battery.ChargeLevel.vChargingTask?.Wait();
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
            this.userFilterComboBox = new System.Windows.Forms.ComboBox();
            this.messageFilterTextBox = new System.Windows.Forms.TextBox();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ANDConditionCheckBox = new System.Windows.Forms.CheckBox();
            this.StartMessageButton = new System.Windows.Forms.Button();
            this.ChargeButton = new System.Windows.Forms.Button();
            this.ChargingBar = new System.Windows.Forms.ProgressBar();
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
            this.FormattingListComboBox.Location = new System.Drawing.Point(12, 114);
            this.FormattingListComboBox.Name = "FormattingListComboBox";
            this.FormattingListComboBox.Size = new System.Drawing.Size(161, 21);
            this.FormattingListComboBox.TabIndex = 0;
            this.FormattingListComboBox.Text = "Select Formatting";
            this.FormattingListComboBox.SelectedIndexChanged += new System.EventHandler(this.FormattingListComboBox_SelectedIndexChanged);
            // 
            // AutoScrollCheckBox
            // 
            this.AutoScrollCheckBox.AutoSize = true;
            this.AutoScrollCheckBox.Location = new System.Drawing.Point(309, 91);
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
            this.MessageListView.Location = new System.Drawing.Point(10, 150);
            this.MessageListView.MultiSelect = false;
            this.MessageListView.Name = "MessageListView";
            this.MessageListView.Size = new System.Drawing.Size(376, 238);
            this.MessageListView.TabIndex = 3;
            this.MessageListView.TileSize = new System.Drawing.Size(330, 30);
            this.MessageListView.UseCompatibleStateImageBehavior = false;
            this.MessageListView.View = System.Windows.Forms.View.Tile;
            // 
            // userFilterComboBox
            // 
            this.userFilterComboBox.FormattingEnabled = true;
            this.userFilterComboBox.Items.AddRange(new object[] {
            "None"});
            this.userFilterComboBox.Location = new System.Drawing.Point(192, 12);
            this.userFilterComboBox.Name = "userFilterComboBox";
            this.userFilterComboBox.Size = new System.Drawing.Size(193, 21);
            this.userFilterComboBox.TabIndex = 4;
            this.userFilterComboBox.Text = "Select Phone Number";
            this.userFilterComboBox.TextChanged += new System.EventHandler(this.UserFilterComboBox_TextChanged);
            // 
            // messageFilterTextBox
            // 
            this.messageFilterTextBox.Location = new System.Drawing.Point(192, 39);
            this.messageFilterTextBox.Name = "messageFilterTextBox";
            this.messageFilterTextBox.Size = new System.Drawing.Size(193, 20);
            this.messageFilterTextBox.TabIndex = 5;
            this.messageFilterTextBox.TextChanged += new System.EventHandler(this.MessageFilterTextBox_TextChanged);
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateTimePicker.Location = new System.Drawing.Point(192, 65);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(95, 20);
            this.startDateTimePicker.TabIndex = 6;
            this.startDateTimePicker.Value = DateTime.Now.Date;
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.StartDateTimePicker_ValueChanged);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDateTimePicker.Location = new System.Drawing.Point(294, 65);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(92, 20);
            this.endDateTimePicker.TabIndex = 7;
            this.endDateTimePicker.Value = DateTime.Now.Date.AddDays(1);
            this.endDateTimePicker.ValueChanged += new System.EventHandler(this.EndDateTimePicker_ValueChanged);
            // 
            // ANDConditionCheckBox
            // 
            this.ANDConditionCheckBox.AutoSize = true;
            this.ANDConditionCheckBox.Location = new System.Drawing.Point(192, 91);
            this.ANDConditionCheckBox.Name = "ANDConditionCheckBox";
            this.ANDConditionCheckBox.Size = new System.Drawing.Size(96, 17);
            this.ANDConditionCheckBox.TabIndex = 8;
            this.ANDConditionCheckBox.Text = "AND Condition";
            this.ANDConditionCheckBox.UseVisualStyleBackColor = true;
            this.ANDConditionCheckBox.Visible = false;
            this.ANDConditionCheckBox.CheckedChanged += new System.EventHandler(this.ANDConditionCheckBox_CheckedChanged);
            // 
            // StartMessageButton
            // 
            this.StartMessageButton.Location = new System.Drawing.Point(298, 114);
            this.StartMessageButton.Name = "StartMessageButton";
            this.StartMessageButton.Size = new System.Drawing.Size(88, 24);
            this.StartMessageButton.TabIndex = 9;
            this.StartMessageButton.Text = "Start Receiving";
            this.StartMessageButton.UseVisualStyleBackColor = true;
            this.StartMessageButton.Click += new System.EventHandler(this.StartMessageButton_Click);
            // 
            // ChargeButton
            // 
            this.ChargeButton.Location = new System.Drawing.Point(53, 62);
            this.ChargeButton.Name = "ChargeButton";
            this.ChargeButton.Size = new System.Drawing.Size(91, 23);
            this.ChargeButton.TabIndex = 10;
            this.ChargeButton.Text = "Charge";
            this.ChargeButton.UseVisualStyleBackColor = true;
            this.ChargeButton.Click += new System.EventHandler(this.ChargeButton_Click);
            // 
            // ChargingBar
            // 
            this.ChargingBar.Location = new System.Drawing.Point(9, 26);
            this.ChargingBar.Name = "ChargingBar";
            this.ChargingBar.Size = new System.Drawing.Size(177, 23);
            this.ChargingBar.TabIndex = 11;
            // 
            // MessageFiltering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(412, 400);
            this.Controls.Add(this.ChargingBar);
            this.Controls.Add(this.ChargeButton);
            this.Controls.Add(this.StartMessageButton);
            this.Controls.Add(this.ANDConditionCheckBox);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.messageFilterTextBox);
            this.Controls.Add(this.userFilterComboBox);
            this.Controls.Add(this.MessageListView);
            this.Controls.Add(this.AutoScrollCheckBox);
            this.Controls.Add(this.FormattingListComboBox);
            this.MaximizeBox = false;
            this.Name = "MessageFiltering";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Message Filtering";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox FormattingListComboBox;
        private System.Windows.Forms.CheckBox AutoScrollCheckBox;
        private System.Windows.Forms.ListView MessageListView;
        private System.Windows.Forms.ColumnHeader User;
        private System.Windows.Forms.ComboBox userFilterComboBox;
        private System.Windows.Forms.TextBox messageFilterTextBox;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.ColumnHeader Message;
        private System.Windows.Forms.CheckBox ANDConditionCheckBox;
        private System.Windows.Forms.Button StartMessageButton;
        private System.Windows.Forms.Button ChargeButton;
        private System.Windows.Forms.ProgressBar ChargingBar;
    }
}

