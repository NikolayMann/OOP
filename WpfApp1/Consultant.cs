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
        public string GetName(Client client)
        {
            string result = "";
            if (client != null)
            {
                result = $"{client.Name}";
            }
            return result;
        }
        public virtual string GetPassport(int ClientID)
        {
            if (ClientDatabase.DataBase[ClientID].Passport != "")
            {
                return "*********************";
            }
            else
            {
                return "";
            }
        }
        public string GetTelephone(int ClientID)
        {
            string result = "Item not exist";
            if (ClientID < ClientDatabase.DataBase.Count)
            {
                result = $"{ClientDatabase.DataBase[ClientID].Telephone}";
            }
            return result;
        }
        public virtual bool SetName(int ClientID, string new_name)
        {
            return false;
        }

        public virtual bool SetPassport(int ClientID, string new_passport)
        {
            return false;
        }

        public virtual bool SetTelephone(int ClientID, string new_telephone)
        {
            bool result = false;
            if (ClientID < ClientDatabase.DataBase.Count)
            {
                ClientDatabase.DataBase[ClientID].Telephone = new_telephone;
                ClientDatabase.DataBase[ClientID].lastchanger = "Consultant";
                ClientDatabase.DataBase[ClientID].LastwritedTime = DateTime.Now;
                result = true;
            }
            return result;
        }
    }
}
