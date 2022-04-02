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
using System.Windows.Input;
using System.Windows.Media;
using System.Web.UI.WebControls;
using Bank;
namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        IBankWorker Worker = null;
        int SelectedPersonID = 0;
        public MainWindow()
        {
            InitializeComponent();
            Table.ItemsSource = Worker.ClientDataBase();
            Accounts.ItemsSource = Worker.Accounts(SelectedPersonID);
            MoneyMenu.Header = "Replace money from...";    
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Worker.SaveDatabase();
            }
            catch(Exception err)
            {
                MessageBox.Show($"{err.Message}");
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Worker is Manager)
            {
                (Worker as Manager).AddNewClient();
                Table.ItemsSource = Worker.ClientDataBase();
            }
            Add.IsEnabled = false;
            Save.IsEnabled = true;
        }

        private void manager_Checked(object sender, RoutedEventArgs e)
        {
            Worker = new Manager();
            Worker.LogAdded += Worker_LogAdded;
            (Worker as Manager).AccountChanges += MainWindow_AccountChanges;
            Table.ItemsSource = Worker.ClientDataBase();
        }

        private void consultant_Checked(object sender, RoutedEventArgs e)
        {
            Worker = new Consultant();
            Worker.LogAdded += Worker_LogAdded;
            (Worker as Consultant).AccountChanges += MainWindow_AccountChanges;
            for (int i = 0; i < Table.Columns.Count; i++)
            {
                Table.Columns[i].IsReadOnly = true;
            }
            Table.Columns[3].IsReadOnly = false;
            Table.ItemsSource = Worker.ClientDataBase();
        }

        private void Worker_LogAdded(string obj)
        {
            Log.Text += obj;
        }

        private void MainWindow_AccountChanges(IBankWorker arg1, Actions arg2, int arg3, string arg4)
        {
            Journal journal = new Journal();
            journal.Operation.Operation = arg2.ToString();
            journal.Operation.OperationBy = arg1.ToString();
            journal.Operation.OperationWhen = DateTime.Now;
            journal.Operation.NewParameter = arg4;
            journal.Operation.ClientID = arg3;
            journal.SerializeJournal();
        }

        private void Sort_Click(object sender, RoutedEventArgs e)
        {
            Worker.SortDatabase();
            Table.ItemsSource = Worker.ClientDataBase();
        }

        private string source_Account = "";
        private string dest_Account = "";
        private void ReplaceMoney(object sender, RoutedEventArgs e)
        {            
            if (MoneyMenu.Header == "Replace money from...")
            {
                MoneyMenu.Header = "Replace money to";
                if ((Accounts.SelectedItem != null) && (Accounts.SelectedItem.ToString().Contains("Number:")))
                {
                    string acc = Accounts.SelectedItem.ToString();
                    source_Account = acc.Substring(acc.IndexOf(' ') + 1);
                }
            }
            else
            {
                MoneyMenu.Header = "Replace money from...";
                if ((Accounts.SelectedItem != null) && (Accounts.SelectedItem.ToString().Contains("Number:")))
                {
                    string acc = Accounts.SelectedItem.ToString();
                    dest_Account = acc.Substring(acc.IndexOf(' ') + 1);
                    Window1 w = new Window1();
                    w.ShowDialog();
                    Worker.SendMoney(SelectedPersonID, source_Account, dest_Account, BetweenTwoForms.HowMuch);
                }
            }
        }

        private void DeleteAccount(object sender, RoutedEventArgs e) 
        {
            if ((Accounts.SelectedItem is TreeViewItem == false) && (Accounts.SelectedItem != null))
            {
                string acc = Accounts.SelectedItem.ToString();
                acc = acc.Substring(acc.IndexOf(' ') + 1);
                Worker.DeleteAccount(SelectedPersonID, acc);
                Accounts.ItemsSource = Worker.Accounts(SelectedPersonID);
            }
        }

        private void AddAccount(object sender, RoutedEventArgs e)
        {
            bool isDeposit = false;
            bool falsch_click = false;
            if (Accounts.SelectedItem == null)
            {
                Point p = Mouse.GetPosition(Accounts);
                if (p.Y < 50)
                {
                    isDeposit = true;
                }
                else
                {
                    isDeposit = false;
                }
            }
            else
            {
                if (Accounts.SelectedItem is TreeViewItem)
                {
                    if ((Accounts.SelectedItem as TreeViewItem).Header.ToString() == "Deposit")
                    {
                        isDeposit = true;
                    }
                    else if ((Accounts.SelectedItem as TreeViewItem).Header.ToString() == "Not deposit")
                    {
                        isDeposit = false;
                    }
                }
                else
                {
                    falsch_click = true;
                }
            }

            if (!falsch_click)
            {
                Worker.AddAccount(SelectedPersonID, isDeposit);
                Accounts.ItemsSource = Worker.Accounts(SelectedPersonID);
            }
        }

        private void Table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedPersonID = Table.SelectedIndex;
            Accounts.ItemsSource = Worker.Accounts(SelectedPersonID);
            AccountInfo.Text = "";
        }

        private void Accounts_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if ((e.NewValue != null) && (e.NewValue.ToString().Contains("Number:")))
            {
                string acc = Accounts.SelectedItem.ToString();
                acc = acc.Substring(acc.IndexOf(' ') + 1);               
                AccountInfo.Text = Worker.GetAccountInfo(SelectedPersonID, acc);
            }
        }

        private void Table_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }
    }
}
