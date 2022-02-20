using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Data;
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BankWorker Worker = new Manager();
        ClientDatabase database = new ClientDatabase();
        public MainWindow()
        {
            InitializeComponent();
            RefreshFormData();
            Binding binding = new Binding();
          
        }

        void RefreshFormData()
        {
            if (ClientList.SelectedIndex >= 0)
            {
                int ID = ClientList.SelectedIndex;
                Client client = database.GetDatabaseClient(ID);                
                ClientFullName.Text = Worker.GetName(client);
                Telephone.Text = Worker.GetTelephone(ID);
                Passport.Text = Worker.GetPassport(ID);
                RecordInfo.Text = $"Changed {client.lastchanger}\r\n At {client.LastwritedTime}";
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshFormData();
        }

        private void AddNewCustomer()
        {
            if (database.SaveNewClient(ClientList.Text, Telephone.Text, Passport.Text))
            {
                int ID = ClientDatabase.DataBase.Count - 1;
                Client client = database.GetDatabaseClient(ID);
                ClientList.Items.Add(Worker.GetName(client));
                Save.IsEnabled = false;
                Add.IsEnabled = true;
            }
        }

        private void SaveOldCustomer()
        {
            if (Telephone.Text != "")
            {
                Worker.SetTelephone(ClientList.SelectedIndex, Telephone.Text);
                database.UpdateDatabase();
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
