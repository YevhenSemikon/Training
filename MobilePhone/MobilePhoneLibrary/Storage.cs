using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone {
    public class Storage {
        public delegate string FormatDelegate(string message);
        public delegate void MessageAddDelegate(List<Message> messages);
        public delegate void MessageRemoveDelegate(List<Message> messages);
        public event MessageAddDelegate MessageAdd;
        public event MessageRemoveDelegate MessageRemove;
        private List<Message> messagesList = new List<Message>();
        public List<Message> MessagesList { get { return messagesList; } }
        public void AddMessage(Message message) {
            messagesList.Add(message);
            MessageAdd?.Invoke(messagesList);
        }
        public void RemoveMessage(Message message) {
            messagesList.Remove(message);
            MessageRemove?.Invoke(messagesList);
        }
        public List<Message> FilterMessage(IEnumerable<Message> messages,
                            string selectedUser, DateTime selectedStartDate,
                            DateTime selectedEndDate, string selectedText, bool ANDCondition) {
            var filteredByUser = FilterMessageByUser(messages, selectedUser);
            var filteredByText = FilterMessageByText(messages, selectedText);
            var filteredByDate = FilterMessageByDate(messages, selectedStartDate, selectedEndDate);
            return CreateFilteredList(filteredByUser, filteredByText, filteredByDate, ANDCondition);
        }
        private List<Message> CreateFilteredList(IEnumerable<Message> filteredByUser, IEnumerable<Message> filteredByText, IEnumerable<Message> filteredByDate, bool ANDCondition) {
            IEnumerable<Message> filterNew;
            if (ANDCondition) {
                filterNew = filteredByUser.Intersect(filteredByText);
                filterNew = filterNew.Intersect(filteredByDate);
            }
            else {
                filterNew = filteredByUser.Union(filteredByText);
                filterNew = filterNew.Union(filteredByDate);
            }
            return filterNew.ToList();
        }
        private IEnumerable<Message> FilterMessageByDate(IEnumerable<Message> messages, DateTime selectedStartDate, DateTime selectedEndDate) {
            return messages.Where(d => d.ReceivingTime >= selectedStartDate && d.ReceivingTime <= selectedEndDate);
        }
        private IEnumerable<Message> FilterMessageByText(IEnumerable<Message> messages, string selectedText) {
            if (string.IsNullOrEmpty(selectedText)) { return messages.Where(t => t.Text == null); }
            else { return messages.Where(t => t.Text.Contains(selectedText)); }
        }
        private IEnumerable<Message> FilterMessageByUser(IEnumerable<Message> messages, string selectedUser) {
            return messages.Where(u => u.User == selectedUser);
        }
        public static string NoneFormat(string message) { return message; }
        public static string LowerFormat(string message) { return message.ToLower(); }
        public static string StartWithDate(string message) { return $"[{DateTime.Now}] {message}"; }
        public static string EndWithDate(string message) { return $"{message} [{DateTime.Now}]"; }
        public static string UpperFormat(string message) { return message.ToUpper(); }


    }
}
