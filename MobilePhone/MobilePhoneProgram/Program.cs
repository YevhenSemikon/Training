using MobilePhone;
using MobilePhone.MobileComponents.Dynamic;
using MobilePhone.MobileComponents.Screen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneProgram {
    class Program {
        static void Main(string[] args){
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            string result=mobile.GetDescription();
            Console.WriteLine(result);
        }
    }
}
