using MobilePhone.MobileComponents.Battery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    public class Contact
    {
        public Contact()
        {
            Name = "Adam";
            LastName = "Bush";
            Age = 23;
            ContactPhoneNumber = "+380931234567";
        }
        public Contact(string name,string lastName, int age, string contactphoneNumber)
        {
            Name = name;
            LastName = lastName;
            Age = age;
            ContactPhoneNumber = contactphoneNumber;
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string ContactPhoneNumber { get; set; }

    }
}
