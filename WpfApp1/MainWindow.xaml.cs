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
            ClientList.ItemsSource = Consultant.DataBase;            
        }

        void InitClientInfo()
        { 
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string[] name_info = ClientList.Text.Split(' ');
            if (name_info.Length != 3)
            {
                MessageBox.Show("Имя введено неправильно! Введите ФИО полностью через пробел!");
            }
            else
            {
                if (Telephone.Text != "")
                {
                    Client client = new Client(name_info[2], name_info[1], name_info[0], Telephone.Text);
                    Manager.DataBase.Add(client);
                    string pas_num = Passport.Text;
                    string[] ser_num = pas_num.Split(' ');
                    pas_num = "";
                    foreach(string s in ser_num)
                    {
                        pas_num += s;
                    }
                    uint passport_num = 0;
                    try
                    {
                        passport_num = Convert.ToUInt32(pas_num);
                    }
                    catch
                    {
                        passport_num = 0x7FFFFFFF;
                    }
                    Worker.SetPassport(Manager.DataBase.Count, passport_num);
                    int ID = Manager.DataBase.Count - 1;
                    using (Stream file = new FileStream("base.txt", FileMode.OpenOrCreate))
                    {
                        using (StreamWriter writer = new StreamWriter(file))
                        {
                            string str = $"{Worker.GetName(ID)}|{Worker.GetTelephone(ID)}|{Worker.GetPassport(ID)}|{client.lastchanger}|{client.LastwritedTime}";
                            writer.WriteLine(str);
                        }                       
                    }
                    Save.IsEnabled = false;
                    Add.IsEnabled = true;
                }
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
        }

        private void consultant_Checked(object sender, RoutedEventArgs e)
        {
            Worker = new Consultant();
        }
    }
}
