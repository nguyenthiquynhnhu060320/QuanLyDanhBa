using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySDT
{
    public class ListPhoneBook
    {
        private static ListPhoneBook intance;
        List<PhoneBook> listNbphone;

        public List<PhoneBook> ListNbphone { get => listNbphone; set => listNbphone = value; }
        public static ListPhoneBook Intance
        {
            get
            {
                if (intance == null)
                    intance = new ListPhoneBook();
                return intance;
            } 
            set => intance = value;
        }

        private ListPhoneBook()
        {
            listNbphone = new List<PhoneBook>();
            //listNbphone.Add(new PhoneBook("0375204538", "Cty ABC", "Quỳnh Như", "Giám đốc"));
            //listNbphone.Add(new PhoneBook("0375204111", "Cty Z", "Quỳnh ", "Giám đốc"));
            //listNbphone.Add(new PhoneBook("0375204222", "Cty 7", "Như", "Giám đốc"));
            //listNbphone.Add(new PhoneBook("0371.04333", "ubnd 8", "Khang 1", "Giám đốc"));
            //listNbphone.Add(new PhoneBook("0375204111", "cttnhh 9", "Quỳnh 1", "Giám đốc"));
            //listNbphone.Add(new PhoneBook("05685204222", "Cong ty 10", "Như 1", "Giám đốc"));
            //listNbphone.Add(new PhoneBook("03752545333", "Cty 11", "Khang 3", "Giám đốc"));
        }
    }
}
