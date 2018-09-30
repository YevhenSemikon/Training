using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.CommonUtilities
{
    public static class MessageAction
    {
        public delegate string FormatDelegate(string message);

        public static List<Message> FilterMessage(IEnumerable<Message> messages,
                           string selectedUser, DateTime selectedStartDate,
                           DateTime selectedEndDate, string selectedText, bool ANDCondition)
        {

            //Add list of Filtered messages by date (constant condition)
            List<List<Message>> messagesList = new List<List<Message>>(){
            FilterMessageByDate(messages, selectedStartDate, selectedEndDate).ToList()
            };
            //Check if User condition specified
            if (selectedUser != "None" && !string.IsNullOrEmpty(selectedUser))
            {
                messagesList.Add(FilterMessageByUser(messages, selectedUser).ToList());
            }
            //Check if Text condition specified
            if (!string.IsNullOrEmpty(selectedText))
            {
                messagesList.Add(FilterMessageByText(messages, selectedText).ToList());
            }
            return CreateFilteredList(messagesList, ANDCondition);
        }

        private static List<Message> CreateFilteredList(List<List<Message>> messagesList, bool ANDCondition)
        {
            var filteredList = messagesList[0].AsEnumerable();
            if (ANDCondition) { foreach (var messages in messagesList) { filteredList = filteredList.Intersect(messages); } }
            else { foreach (var messages in messagesList) { filteredList = filteredList.Union(messages); } }
            return filteredList.ToList();
        }

        internal static List<Message> FilterMessageByDate(IEnumerable<Message> messages, DateTime selectedStartDate, DateTime selectedEndDate)
        {
            return messages.Where(d => d.ReceivingTime >= selectedStartDate && d.ReceivingTime <= selectedEndDate).ToList();
        }

        internal static List<Message> FilterMessageByText(IEnumerable<Message> messages, string selectedText)
        {
            return messages.Where(t => t.Text.Contains(selectedText)).ToList();
        }

        internal static List<Message> FilterMessageByUser(IEnumerable<Message> messages, string selectedUser)
        {
            return messages.Where(u => u.User == selectedUser).ToList();
        }

        //Format incoming message
        public static string NoneFormat(string message) { return message; }
        public static string LowerFormat(string message) { return message.ToLower(); }
        public static string StartWithDate(string message) { return $"[{DateTime.Now}] {message}"; }
        public static string EndWithDate(string message) { return $"{message} [{DateTime.Now}]"; }
        public static string UpperFormat(string message) { return message.ToUpper(); }

    }
}

