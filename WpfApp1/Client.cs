using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Client
    {
        public void NameSet(BankWorker worker, string[] name_info)
        {
            if (name_info.Length == 3)
            {
                _name = name_info[0];
                _secondname = name_info[1];
                _lastname = name_info[2];
                if (worker is Manager)
                {
                    lastchanger = "Manager";
                }
                else
                {
                    lastchanger = "Consultant";
                }
                LastwritedTime = DateTime.Now;
            }
        }
        public void PassportSet(BankWorker worker, uint new_num)
        {
            _passport = new_num;
            if (worker is Manager)
            {
                lastchanger = "Manager";
            }
            else
            {
                lastchanger = "Consultant";
            }
            LastwritedTime = DateTime.Now;
        }
        public void TelephoneSet(BankWorker worker, string new_num)
        {
            _telephone = new_num;
            if (worker is Manager)
            {
                lastchanger = "Manager";
            }
            else
            {
                lastchanger = "Consultant";
            }
            LastwritedTime = DateTime.Now;
        }

        private string _name;
        private string _secondname;
        private string _lastname;
        public string lastchanger { get; set; }
        public DateTime LastwritedTime;
        private uint _passport {get; set;}
        private string _telephone;
        public Client(string name, string sec_name, string last_name, string telephone)
        {
            _name = name;
            _secondname = sec_name;
            _lastname = last_name;
            _telephone = telephone;
            lastchanger = "Manager";
            LastwritedTime = DateTime.Now;
        }

        public string Name
        {
            get { return $"{_name} {_secondname} {_lastname}"; }
            set { }
        }

        public string Passport { get { return _passport.ToString(); } }

        public string Telephone { get { return _telephone; } }
        private Client() { }
    }
}
