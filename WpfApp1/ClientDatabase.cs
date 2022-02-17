using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
namespace WpfApp1
{
    class ClientDatabase
    {
        public void InitClientInfo(ref ComboBox ClientList)
        {
            if (File.Exists("base.txt"))
            {
                using (Stream file = new FileStream("base.txt", FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(file))
                    {
                        int counter = 0;
                        while (!reader.EndOfStream)
                        {
                            string file_record = reader.ReadLine();
                            string[] info = file_record.Split('|');
                            string[] fio = info[0].Split(' ');
                            Client client = new Client(fio[0], fio[1], fio[2], info[1]);
                            Manager ger = new Manager();
                            Manager.DataBase.Add(client);
                            ger.SetPassport(counter, info[2]);
                            ClientList.Items.Add(client.Name);
                            counter++;
                        }
                    }
                }
            }
        }

        public bool SaveNewClient(string full_name, string telephone, string passport)
        {
            bool result = false;
            string[] name_info = full_name.Split(' ');
            if (name_info.Length < 3)
            {
                MessageBox.Show("Имя введено неправильно! Введите ФИО полностью через пробел!");
            }
            else
            {
                if (telephone != "")
                {
                    Client client = new Client(name_info[2], name_info[1], name_info[0], telephone);
                    Manager.DataBase.Add(client);
                    string pas_num = passport;
                    string[] ser_num = passport.Split(' ');
                    pas_num = "";
                    foreach (string s in ser_num)
                    {
                        pas_num += s;
                    }
                    int ID = Manager.DataBase.Count - 1;
                    Manager.DataBase[ID].Passport = pas_num;                    
                    using (Stream file = new FileStream("base.txt", FileMode.OpenOrCreate))
                    {
                        using (StreamWriter writer = new StreamWriter(file))
                        {
                            string str = $"{Manager.DataBase[ID].Name}|{Manager.DataBase[ID].Telephone}|{Manager.DataBase[ID].Passport}|{client.lastchanger}|{client.LastwritedTime}";
                            writer.WriteLine(str);
                        }
                    }
                    result = true;
                }
            }
            return result;
        }

        public void UpdateDatabase()
        {
            using (Stream file = new FileStream("base.txt", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {
                    for (int i = 0; i < Manager.DataBase.Count; i++)
                    {
                        string str = $"{Manager.DataBase[i].Name}|{Manager.DataBase[i].Telephone}|{Manager.DataBase[i].Passport}|{Manager.DataBase[i].lastchanger}|{Manager.DataBase[i].LastwritedTime}";
                        writer.WriteLine(str);
                    }
                }
            }
        }
    }
}
