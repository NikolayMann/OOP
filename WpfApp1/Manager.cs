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
            if (ClientID < DataBase.Count)
            {
                result = true;
                DataBase[ClientID].Passport = new_passport;
                DataBase[ClientID].lastchanger = "Manager";
                DataBase[ClientID].LastwritedTime = DateTime.Now;
            }
            return result;
        }

        private bool SetClientName(int ClientID, string[] name_info)
        {
            bool result = false;
            if (name_info.Length == 3)
            {
                DataBase[ClientID].Name = name_info[0];
                DataBase[ClientID].Secondname = name_info[1];
                DataBase[ClientID].Lastname = name_info[2];
                DataBase[ClientID].lastchanger = "Manager";
                DataBase[ClientID].LastwritedTime = DateTime.Now;
                result = true;
            }            
            return result;
        }

        public override bool SetName(int ClientID, string new_name)
        {
            bool result = false;
            if (ClientID < DataBase.Count)
            {
                string[] fio = new_name.Split(' ');
                result = SetClientName(ClientID, fio);
            }
            return result;
        }

        public override string GetPassport(int ClientID)
        {
            return DataBase[ClientID].Passport;
        }

        public override bool SetTelephone(int ClientID, string new_telephone)
        {
            bool result = false;
            if (ClientID < DataBase.Count)
            {
                DataBase[ClientID].Telephone = new_telephone;
                DataBase[ClientID].lastchanger = "Manager";
                DataBase[ClientID].LastwritedTime = DateTime.Now;
                result = true;
            }
            return result;
        }
    }
}
