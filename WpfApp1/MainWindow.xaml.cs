using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Xml.Serialization;
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BankWorker Worker = new Manager();
        public MainWindow()
        {
            InitializeComponent();
            InitClientInfo();
            RefreshFormData();
        }

        void InitClientInfo()
        {
            if (File.Exists("base.txt"))
            {
                using (Stream file = new FileStream("base.txt", FileMode.Open))
                {
                    using(StreamReader reader = new StreamReader(file))
                    {
                        int counter = 0;
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            string[] customer = line.Split('|');
                            string[] FullName = customer[0].Split(' ');
                            if (FullName.Length == 3)
                            {
                                Client client = new Client(FullName[0], FullName[1], FullName[2], customer[1]);
                                Manager.DataBase.Add(client);
                                Manager temp = new Manager();
                                temp.SetPassport(counter, customer[2]);
                                client.lastchanger = customer[3];
                                client.LastwritedTime = Convert.ToDateTime(customer[4]);
                                ClientList.Items.Add(Worker.GetName(counter));
                                counter++;
                            }
                        }
                    }
                }
                ClientList.SelectedIndex = 0;
            }
        }

        void RefreshFormData()
        {
            if (ClientList.SelectedIndex >= 0)
            {
                ClientFullName.Text = Worker.GetName(ClientList.SelectedIndex);
                Telephone.Text = Worker.GetTelephone(ClientList.SelectedIndex);
                Passport.Text = Worker.GetPassport(ClientList.SelectedIndex);
                RecordInfo.Text = $"Changed {Manager.DataBase[ClientList.SelectedIndex].lastchanger}\r\n At {Manager.DataBase[ClientList.SelectedIndex].LastwritedTime}";
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshFormData();
        }

        private void AddNewCustomer()
        {
            string[] name_info = ClientList.Text.Split(' ');
            if (name_info.Length < 3)
            {
                MessageBox.Show("Имя введено неправильно! Введите ФИО полностью через пробел!");
            }
            else
            {
                if (Telephone.Text != "")
                {
                    Client client = new Client(name_info[0], name_info[1], name_info[2], Telephone.Text);
                    Manager.DataBase.Add(client);
                    string pas_num = $" {Passport.Text} ";
                    string[] ser_num = pas_num.Split(' ');
                    pas_num = "";
                    foreach (string s in ser_num)
                    {
                        pas_num += s;
                    }
                    Worker.SetPassport(Manager.DataBase.Count - 1, pas_num);
                    int ID = Manager.DataBase.Count - 1;
                    using (Stream file = new FileStream("base.txt", FileMode.Append))
                    {
                        using (StreamWriter writer = new StreamWriter(file))
                        {
                            string str = $"{Worker.GetName(ID)}|{Worker.GetTelephone(ID)}|{Worker.GetPassport(ID)}|{client.lastchanger}|{client.LastwritedTime}";
                            writer.WriteLine(str);
                        }
                    }
                    ClientList.Items.Add(Worker.GetName(ID));
                    Save.IsEnabled = false;
                    Add.IsEnabled = true;
                }
            }
        }

        private void SaveOldCustomer()
        {
            if (Telephone.Text != "")
            {
                Worker.SetTelephone(ClientList.SelectedIndex, Telephone.Text);
                using (Stream file = new FileStream("base.txt", FileMode.Append))
                {
                    using (StreamWriter writer = new StreamWriter(file))
                    {
                        for (int i = 0; i < Manager.DataBase.Count; i++)
                        {
                            string str = $"{Worker.GetName(i)}|{Worker.GetTelephone(i)}|{Manager.DataBase[i].Passport}|{Manager.DataBase[i].lastchanger}|{Manager.DataBase[i].LastwritedTime}";
                            writer.WriteLine(str);
                        }
                    }
                }
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Worker is Manager)
            {
                AddNewCustomer();
            }
            else
            {
                SaveOldCustomer();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {            
            ClientList.Text = "Новый клиент";
            Telephone.Text = "";
            Passport.Text = "";
            RecordInfo.Text = "";
            Add.IsEnabled = false;
            Save.IsEnabled = true;
        }

        private void manager_Checked(object sender, RoutedEventArgs e)
        {
            Worker = new Manager();
            Add.IsEnabled = true;
            Save.IsEnabled = false;
            RefreshFormData();
        }

        private void consultant_Checked(object sender, RoutedEventArgs e)
        {
            Worker = new Consultant();
            Add.IsEnabled = false;
            Save.IsEnabled = true;
            RefreshFormData();
        }
    }
}
