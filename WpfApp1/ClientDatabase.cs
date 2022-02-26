using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Collections;

namespace WpfApp1
{
    public class ClientDatabase
    {
        public ObservableCollection<Client> DataBase = new ObservableCollection<Client>();
        public ClientDatabase()
        {            
            InitClientInfo();
        }
        private void InitClientInfo()
        {
            if (File.Exists("base.txt"))
            {
                using (Stream file = new FileStream("base.txt", FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(file))
                    {
                        while (!reader.EndOfStream)
                        {
                            string file_record = reader.ReadLine();
                            string[] info = file_record.Split('|');
                            string[] fio = info[0].Split(' ');
                            Client client = new Client(fio[0], fio[1], fio[2], info[1]);
                            client.Passport = info[2];
                            DataBase.Add(client);
                        }
                    }
                }
            }
        }
        public bool SaveDatabase()
        {
            bool result = false;
            if ((DataBase[DataBase.Count - 1].Passport != "") && (DataBase[DataBase.Count - 1].Passport != null))
            {
                using (Stream file = new FileStream("base.txt", FileMode.OpenOrCreate))
                {
                    using (StreamWriter writer = new StreamWriter(file))
                    {
                        foreach (var client in DataBase)
                        {
                            string str = $"{client.Name}|{client.Telephone}|{client.Passport}|{client.Lastchanger}|{client.LastwritedTime}";
                            writer.WriteLine(str);
                        }
                    }
                }
                result = true;
            }
            else
            {
                MessageBox.Show("Серия и номер паспорта не введены!");
            }
            return result;
        }


        public void Sort()
        {
            ObservableCollection<Client> Local = new ObservableCollection<Client>();
            var result = from user in DataBase
                         orderby user.Lastname, user.Lastname.Length
                         select user;
            foreach (Client u in result)
            {
                Local.Add(u);
            }
            DataBase = Local;
        }

        /// <summary>
        /// Возвращает выбранный экземпляр класса Client из базы данных.
        /// </summary>
        /// <param name="ClientID">Идентификатор клиента</param>
        /// <returns> null если элемент отсутствет в базе</returns>
        public Client GetDatabaseClient(int ClientID)
        {
            Client result = null;
            if (ClientID < DataBase.Count)
            {
                result = DataBase[ClientID];
            }
            return result;
        }
    }
}
