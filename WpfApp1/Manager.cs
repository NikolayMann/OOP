using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Manager : Consultant
    {
        public Manager()
        {
            if (database == null)
            {
                database = new ClientDatabase();
            }
        }
     
        public override bool SetPassport(int ClientID, string new_passport)
        {
            bool result = false;
            if (ClientID < database.DataBase.Count)
            {
                result = true;
                database.DataBase[ClientID].Passport = new_passport;
                database.DataBase[ClientID].Lastchanger = "Manager";
                database.DataBase[ClientID].LastwritedTime = DateTime.Now;
            }
            return result;
        }

        private bool SetClientName(int ClientID, string[] name_info)
        {
            bool result = false;
            if (name_info.Length == 3)
            {
                database.DataBase[ClientID].Name = name_info[0];
                database.DataBase[ClientID].Secondname = name_info[1];
                database.DataBase[ClientID].Lastname = name_info[2];
                database.DataBase[ClientID].Lastchanger = "Manager";
                database.DataBase[ClientID].LastwritedTime = DateTime.Now;
                result = true;
            }            
            return result;
        }

        public override bool SetName(int ClientID, string new_name)
        {
            bool result = false;
            if (ClientID < database.DataBase.Count)
            {
                string[] fio = new_name.Split(' ');
                result = SetClientName(ClientID, fio);
            }
            return result;
        }

        public override string GetPassport(int ClientID)
        {
            return database.DataBase[ClientID].Passport;
        }

        public override bool SetTelephone(int ClientID, string new_telephone)
        {
            bool result = false;
            if (ClientID < database.DataBase.Count)
            {
                database.DataBase[ClientID].Telephone = new_telephone;
                database.DataBase[ClientID].Lastchanger = "Manager";
                database.DataBase[ClientID].LastwritedTime = DateTime.Now;
                result = true;
            }
            return result;
        }

        public override bool SaveDatabase()
        {
            database.SaveDatabase();
            return true;
        }
        public void AddNewClient()
        {
            Client client = new Client("Иван", "Иванович", "Иванов", "+79991234567");
            database.DataBase.Add(client);
        }
    }
}
