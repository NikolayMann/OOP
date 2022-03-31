using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WpfApp1
{
    public class Client
    {
        private string _telephone;
        private string _passport;
        private string _lastchanger;
        private string _fname;
        private string _sname;
        private string _lname;
        private DateTime _lastChangeTime;

        public string FirstName { get => _fname; set
            {
                _fname = value;
                PropertyChanged?.Invoke("FirstName", value);
            }
        }
        public string Secondname
        {
            get => _sname; set
            {
                _sname = value;
                PropertyChanged?.Invoke("SecondName", value);
            }
        }
        public string Lastname
        {
            get => _lname; set
            {
                _lname = value;
                PropertyChanged?.Invoke("LastName", value);
            }
        }

        public string Telephone { get => _telephone; set {
                _telephone = value;
                PropertyChanged?.Invoke("Telephone", value);} }

        public string Passport { get => _passport; set {
                _passport = value;
                PropertyChanged?.Invoke("Passport", value);
            } }

        public string Lastchanger { get => _lastchanger; set {
                _lastchanger = value;
                PropertyChanged?.Invoke("Changer", value);
            } }

        public DateTime LastwritedTime { get => _lastChangeTime; set {
                _lastChangeTime = value;
                PropertyChanged?.Invoke("LastTime", value.ToString());
            }
        }
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

        public event Action<string, string> PropertyChanged;

        private Client() { }        
    }
}
