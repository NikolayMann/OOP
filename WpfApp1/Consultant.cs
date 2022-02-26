using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    public class Consultant : IBankWorker
    {
        public ClientDatabase database;
        public Consultant()
        {
            if (database == null)
            {
                database = new ClientDatabase();
            }
        }
        public string GetName(int ClientID)
        {
            string result = "";
            Client client = database.GetDatabaseClient(ClientID);
            if (client != null)
            {
                result = $"{client.Name}";
            }
            return result;
        }
        public virtual string GetPassport(int ClientID)
        {
            if (database.DataBase[ClientID].Passport != "")
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
            if (ClientID < database.DataBase.Count)
            {
                result = $"{database.DataBase[ClientID].Telephone}";
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

        public virtual bool SaveDatabase()
        {
            bool result = false;
            return result;
        }

        public virtual bool SetTelephone(int ClientID, string new_telephone)
        {
            bool result = false;
            if (ClientID < database.DataBase.Count)
            {
                database.DataBase[ClientID].Telephone = new_telephone;
                database.DataBase[ClientID].Lastchanger = "Consultant";
                database.DataBase[ClientID].LastwritedTime = DateTime.Now;
                result = true;
            }
            return result;
        }
        public ObservableCollection<Client> ClientDataBase()
        {
            ObservableCollection<Client> clients = new ObservableCollection<Client>();
            for (int i = 0; i < database.DataBase.Count; i++)
            {
                Client local_client = database.DataBase[i];
                local_client.Passport = this.GetPassport(i);
                clients.Add(local_client);
            }
            return clients;
        }

        public void SortDatabase()
        {
            database.Sort();
        }

    }
}
    

