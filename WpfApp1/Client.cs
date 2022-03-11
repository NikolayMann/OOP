using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Client
    {
        public string Name
        {
            get { return $"{FirstName} {Secondname} {Lastname}"; }
            set { }
        }

        public string FirstName;
        public string Secondname;
        public string Lastname;
        public string Telephone { get; set; }

        public string Passport { get; set; }
        public string Lastchanger { get; set; }
        public DateTime LastwritedTime { get; set; }
        public Client(string name, string sec_name, string last_name, string telephone)
        {
            FirstName = name;
            Secondname = sec_name;
            Lastname = last_name;
            Telephone = telephone;
            Lastchanger = "Manager";
            LastwritedTime = DateTime.Now;
        }                    
        public ObservableCollection<Account<bool,string>> Account_List = new ObservableCollection<Account<bool, string>>();
        private Client() { }        
    }
}
