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
                DataBase[ClientID].PassportSet(this, new_passport);
            }
            return result;
        }

        private bool SetClientName(int ClientID, string[] name_info)
        {
            bool result = false;
            if (name_info.Length == 3)
            {
                DataBase[ClientID].NameSet(this, name_info);
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
    }
}
