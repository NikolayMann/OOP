using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public struct ClientCard
    {
        public string FirstName { get; set; }
        public string Secondname { get; set; }
        public string Lastname { get; set; }
        public string Telephone { get; set; }
        public string Passport { get; set; }
    }
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
