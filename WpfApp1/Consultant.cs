using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    public class Consultant : BankWorker
    {
        public static ObservableCollection<Client> DataBase = new ObservableCollection<Client>();
        public string GetName(int ClientID)
        {
            string result = "Item not exist";
            if (ClientID < DataBase.Count)
            {
                result = $"{DataBase[ClientID].Name}";
            }
            return result;
        }
        public virtual string GetPassport(int ClientID)
        {
            return "*********************";
        }
        public string GetTelephone(int ClientID)
        {
            string result = "Item not exist";
            if (ClientID < DataBase.Count)
            {
                result = $"{DataBase[ClientID].Telephone}";
            }
            return result;
        }
        public virtual bool SetName(int ClientID, string new_name)
        {
            return false;
        }

        public virtual bool SetPassport(int ClientID, uint new_passport)
        {
            return false;
        }

        public bool SetTelephone(int ClientID, string new_telephone)
        {
            bool result = false;
            if (ClientID < DataBase.Count)
            {
                DataBase[ClientID].TelephoneSet(this,new_telephone);
                result = true;
            }
            return result;
        }
    }
}
