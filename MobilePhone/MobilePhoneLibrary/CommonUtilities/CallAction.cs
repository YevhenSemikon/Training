using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.CommonUtilities
{
    public class CallAction
    {
        public static List<List<Call>> GroupCalls(List<List<Call>> GroupedCallsList, Call call)
        {
            if (GroupedCallsList.Count == 0)
            {
                GroupedCallsList.Add(new List<Call>() { call });
                return GroupedCallsList;
            };
            List<Call> lastCalls = GroupedCallsList.First();
            Call lastCall = lastCalls.Last();
            if (CompareCalls(call, lastCall))
            {
                lastCalls.Add(call);
                lastCalls.Sort(new CallComparer());              
            }
            else
            {
                GroupedCallsList.Add(new List<Call>() { call });
               
            }
            GroupedCallsList.Sort(new CallComparer());
            return GroupedCallsList;
        }
                   
        private static bool CompareCalls (Call call,Call lastCall)
        {
            if (lastCall.Direction == call.Direction && lastCall.CallContact.ContactPhoneNumber==call.CallContact.ContactPhoneNumber)
            {
                return true;
            }
            return false;
        }

        public static List<Call> FilterCalls (IEnumerable<Call> calls,
                         string selectedUser, DateTime selectedStartDate,
                         DateTime selectedEndDate, string selectedText, bool ANDCondition)
        {

            //Add list of Filtered messages by date (constant condition)
            List<List<Call>> callList = new List<List<Call>>(){
            FilterMessageByDate(calls, selectedStartDate, selectedEndDate).ToList()
            };
            //Check if User condition specified
            if (selectedUser != "None" && !string.IsNullOrEmpty(selectedUser))
            {
                callList.Add(FilterMessageByUser(calls, selectedUser).ToList());
            }
            //Check if Text condition specified
            if (!string.IsNullOrEmpty(selectedText))
            {
                callList.Add(FilterMessageByText(calls, selectedText).ToList());
            }
            return CreateFilteredList(callList, ANDCondition);
        }

        internal static List<Call> FilterMessageByDate(IEnumerable<Call> calls, DateTime selectedStartDate, DateTime selectedEndDate)
        {
            return calls.Where(c=> c.ReceivingCallTime >= selectedStartDate && c.ReceivingCallTime<= selectedEndDate).ToList();
        }

        internal static List<Call> FilterMessageByText(IEnumerable<Call> calls, string selectedText)
        {
            return calls.Where(c => c.CallContact.Name.Contains(selectedText)).ToList();
        }

        internal static List<Call> FilterMessageByUser(IEnumerable<Call> calls, string selectedUser)
        {
            return calls.Where(c => c.CallContact.ContactPhoneNumber == selectedUser).ToList();
        }

        private static List<Call> CreateFilteredList(List<List<Call>> callList, bool ANDCondition)
        {
            var filteredList = callList[0].AsEnumerable();
            if (ANDCondition) { foreach (var call in callList) { filteredList = filteredList.Intersect(call); } }
            else { foreach (var call in callList) { filteredList = filteredList.Union(call); } }
            return filteredList.ToList();
        }

    }
}
