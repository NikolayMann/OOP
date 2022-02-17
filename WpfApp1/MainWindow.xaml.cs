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
        ClientDatabase database = new ClientDatabase();
        public MainWindow()
        {
            InitializeComponent();         
            database.InitClientInfo(ref ClientList);
            RefreshFormData();
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
            if (database.SaveNewClient(ClientList.Text, Telephone.Text, Passport.Text))
            {
                int ID = Manager.DataBase.Count - 1;
                ClientList.Items.Add(Worker.GetName(ID));
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
