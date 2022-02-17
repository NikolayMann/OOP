using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Client
    {
        public string FirstName;
        public string Secondname;
        public string Lastname;
        public string Telephone;
        public string Passport;
        public string lastchanger { get; set; }
        public DateTime LastwritedTime;
        public Client(string name, string sec_name, string last_name, string telephone)
        {
            FirstName = name;
            Secondname = sec_name;
            Lastname = last_name;
            Telephone = telephone;
            lastchanger = "Manager";
            LastwritedTime = DateTime.Now;
        }

        public string Name
        {
            get { return $"{FirstName} {Secondname} {Lastname}"; }
            set { }
        }
        
        private Client() { }
    }
}
