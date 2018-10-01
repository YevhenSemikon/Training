using MobilePhone;
using MobilePhone.CommonUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone {
    public class Storage {
        public delegate void MessageAddDelegate(List<Message> messages);
        public delegate void MessageRemoveDelegate(List<Message> messages);
        public event MessageAddDelegate OnMessageAdd;
        public event MessageRemoveDelegate OnMessageRemove;

        public List<Message> MessagesList { get; } = new List<Message>();
        public List<Call> CallsList { get; private set; } = new List<Call>();
        public List<List<Call>> GroupedCallsList { get; private set; } = new List<List<Call>>();

        public Storage() { }
        public Storage(bool addCall) {
            AddCall(new Call());
        }
        public void AddMessage(Message message) {
            MessagesList.Add(message);
            OnMessageAdd?.Invoke(MessagesList);
        }
        public void RemoveMessage(Message message) {
            MessagesList.Remove(message);
            OnMessageRemove?.Invoke(MessagesList);
        }
        public void AddCall(Call call) {
            CallsList.Add(call);
            CallsList.Sort(new CallComparer());
            GroupedCallsList = CallAction.GroupCalls(GroupedCallsList, call);
        }
        public void RemoveCall(Call call) {
            CallsList.Remove(call);
            CallsList.Sort(new CallComparer());
        }
    }
}
