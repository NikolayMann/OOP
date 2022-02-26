using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        IBankWorker Worker = null;
        public MainWindow()
        {
            InitializeComponent();
            Table.ItemsSource = Worker.ClientDataBase();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Worker.SaveDatabase();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {        
            
            if (Worker is Manager)
            {
                (Worker as Manager).AddNewClient();
            }
            Add.IsEnabled = false;
            Save.IsEnabled = true;
        }

        private void manager_Checked(object sender, RoutedEventArgs e)
        {
            Worker = new Manager();
            Add.IsEnabled = true;
            Save.IsEnabled = false;
            Table.ItemsSource = Worker.ClientDataBase();
        }

        private void consultant_Checked(object sender, RoutedEventArgs e)
        {
            Worker = new Consultant();
            Add.IsEnabled = false;
            Save.IsEnabled = true;
            for (int i = 0; i < Table.Columns.Count; i++)
            {
                Table.Columns[i].IsReadOnly = true;
            }
            Table.Columns[1].IsReadOnly = false;
            Table.ItemsSource = Worker.ClientDataBase();
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            Worker.SortDatabase();
            Table.ItemsSource = Worker.ClientDataBase();
        }
    }
}
