using System;

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
            this.FormattingListComboBox.Location = new System.Drawing.Point(12, 87);
            this.FormattingListComboBox.Name = "FormattingListComboBox";
            this.FormattingListComboBox.Size = new System.Drawing.Size(134, 21);
            this.FormattingListComboBox.TabIndex = 0;
            this.FormattingListComboBox.Text = "Select Formatting";
            this.FormattingListComboBox.SelectedIndexChanged += new System.EventHandler(this.FormattingListComboBox_SelectedIndexChanged);
            // 
            // AutoScrollCheckBox
            // 
            this.AutoScrollCheckBox.AutoSize = true;
            this.AutoScrollCheckBox.Location = new System.Drawing.Point(288, 91);
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
            this.MessageListView.Location = new System.Drawing.Point(10, 126);
            this.MessageListView.MultiSelect = false;
            this.MessageListView.Name = "MessageListView";
            this.MessageListView.Size = new System.Drawing.Size(355, 236);
            this.MessageListView.TabIndex = 3;
            this.MessageListView.TileSize = new System.Drawing.Size(330, 30);
            this.MessageListView.UseCompatibleStateImageBehavior = false;
            this.MessageListView.View = System.Windows.Forms.View.Tile;
            // 
            // userFilterComboBox
            // 
            this.userFilterComboBox.FormattingEnabled = true;
            this.userFilterComboBox.Location = new System.Drawing.Point(176, 12);
            this.userFilterComboBox.Name = "userFilterComboBox";
            this.userFilterComboBox.Text = "Select Phone Number";
            this.userFilterComboBox.Items.Add("None");
            this.userFilterComboBox.Size = new System.Drawing.Size(193, 21);
            this.userFilterComboBox.TabIndex = 4;
            this.userFilterComboBox.TextChanged += new System.EventHandler(this.UserFilterComboBox_TextChanged);
            // 
            // messageFilterTextBox
            // 
            this.messageFilterTextBox.Location = new System.Drawing.Point(176, 39);
            this.messageFilterTextBox.Name = "messageFilterTextBox";
            this.messageFilterTextBox.Size = new System.Drawing.Size(193, 20);
            this.messageFilterTextBox.TabIndex = 5;
            this.messageFilterTextBox.TextChanged += new System.EventHandler(this.MessageFilterTextBox_TextChanged);
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateTimePicker.Location = new System.Drawing.Point(176, 65);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(95, 20);
            this.startDateTimePicker.TabIndex = 6;
            this.startDateTimePicker.Value = DateTime.Now.Date;
            this.startDateTimePicker.ValueChanged += new System.EventHandler(this.StartDateTimePicker_ValueChanged);
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDateTimePicker.Location = new System.Drawing.Point(277, 65);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(92, 20);
            this.endDateTimePicker.TabIndex = 7;
            this.endDateTimePicker.Value = DateTime.Now.Date.AddDays(1).AddSeconds(-1);
            this.endDateTimePicker.ValueChanged += new System.EventHandler(this.EndDateTimePicker_ValueChanged);
            // 
            // ANDConditionCheckBox
            // 
            this.ANDConditionCheckBox.AutoSize = true;
            this.ANDConditionCheckBox.Location = new System.Drawing.Point(176, 91);
            this.ANDConditionCheckBox.Name = "ANDConditionCheckBox";
            this.ANDConditionCheckBox.Size = new System.Drawing.Size(96, 17);
            this.ANDConditionCheckBox.TabIndex = 8;
            this.ANDConditionCheckBox.Text = "AND Condition";
            this.ANDConditionCheckBox.UseVisualStyleBackColor = true;
            this.ANDConditionCheckBox.Visible = false;
            this.ANDConditionCheckBox.CheckedChanged += new System.EventHandler(this.ANDConditionCheckBox_CheckedChanged);
            // 
            // MessageFiltering
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(384, 372);
            this.Controls.Add(this.ANDConditionCheckBox);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.messageFilterTextBox);
            this.Controls.Add(this.userFilterComboBox);
            this.Controls.Add(this.MessageListView);
            this.Controls.Add(this.AutoScrollCheckBox);
            this.Controls.Add(this.FormattingListComboBox);
            this.Name = "MessageFiltering";
            this.Text = "Message Filtering";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
    }
}

