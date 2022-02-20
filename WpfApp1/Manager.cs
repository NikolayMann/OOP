using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Manager:Consultant
    {
        public override bool SetPassport(int ClientID, string new_passport)
        {
            bool result = false;
            if (ClientID < ClientDatabase.DataBase.Count)
            {
                result = true;
                ClientDatabase.DataBase[ClientID].Passport = new_passport;
                ClientDatabase.DataBase[ClientID].lastchanger = "Manager";
                ClientDatabase.DataBase[ClientID].LastwritedTime = DateTime.Now;
            }
            return result;
        }

        private bool SetClientName(int ClientID, string[] name_info)
        {
            bool result = false;
            if (name_info.Length == 3)
            {
                ClientDatabase.DataBase[ClientID].Name = name_info[0];
                ClientDatabase.DataBase[ClientID].Secondname = name_info[1];
                ClientDatabase.DataBase[ClientID].Lastname = name_info[2];
                ClientDatabase.DataBase[ClientID].lastchanger = "Manager";
                ClientDatabase.DataBase[ClientID].LastwritedTime = DateTime.Now;
                result = true;
            }            
            return result;
        }

        public override bool SetName(int ClientID, string new_name)
        {
            bool result = false;
            if (ClientID < ClientDatabase.DataBase.Count)
            {
                string[] fio = new_name.Split(' ');
                result = SetClientName(ClientID, fio);
            }
            return result;
        }

        public override string GetPassport(int ClientID)
        {
            return ClientDatabase.DataBase[ClientID].Passport;
        }

        public override bool SetTelephone(int ClientID, string new_telephone)
        {
            bool result = false;
            if (ClientID < ClientDatabase.DataBase.Count)
            {
                ClientDatabase.DataBase[ClientID].Telephone = new_telephone;
                ClientDatabase.DataBase[ClientID].lastchanger = "Manager";
                ClientDatabase.DataBase[ClientID].LastwritedTime = DateTime.Now;
                result = true;
            }
            return result;
        }
    }
}
