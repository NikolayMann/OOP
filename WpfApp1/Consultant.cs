using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls.Primitives;

namespace WpfApp1
{
    public enum Actions
    {
        SetTelephone, SetName, SetPassport, AddAccount, DelAccount, Resend
    };
    public class Consultant : IBankWorker
    {
        public ClientDatabase database;
        public event Action<IBankWorker, Actions, int, string> AccountChanges = null;
        public event Action<string> LogAdded = null;
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
                result = $"{client.FirstName} {client.Secondname} {client.Lastname}";
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
            AccountChanges?.Invoke(this, Actions.SetName, ClientID, new_name);
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
                AccountChanges?.Invoke(this, Actions.SetTelephone, ClientID, new_telephone);
            }
            
            return result;
        }
        public ObservableCollection<Client> ClientDataBase()
        {
            ObservableCollection<Client> clients = new ObservableCollection<Client>();
            for (int i = 0; i < database.DataBase.Count; i++)
            {
                Client local_client = database.DataBase[i];
                local_client.PropertyChanged -= Local_client_PropertyChanged;
                local_client.Passport = this.GetPassport(i);
                local_client.PropertyChanged += Local_client_PropertyChanged;
                clients.Add(local_client);
            }
            return clients;
        }

        private void Local_client_PropertyChanged(string arg1, string arg2)
        {
            Journal journal = new Journal();
            journal.Operation.Operation = arg1;
            journal.Operation.OperationBy = this.ToString();
            journal.Operation.OperationWhen = DateTime.Now;
            journal.Operation.NewParameter = arg2;
            journal.SerializeJournal();
            string Log = $"{arg1} {this.ToString()}\r\n{arg2} {DateTime.Now}\r\n";
            LogAdded?.Invoke(Log);
        }

        public ObservableCollection<TreeViewItem> Accounts(int ClientID)
        {
            ObservableCollection<TreeViewItem> result = new ObservableCollection<TreeViewItem>();
            TreeViewItem itemDeposit = new TreeViewItem();
            itemDeposit.Header = "Deposit";
            TreeViewItem itemNotDeposit = new TreeViewItem();
            itemNotDeposit.Header = "Not deposit";
            if (ClientID >= 0)
            {
                Client local_client = database.DataBase[ClientID];

                for (int i = 0; i < local_client.Account_List.Count; i++)
                {
                    if (!local_client.Account_List[i].isDeposit)
                    {
                        itemNotDeposit.Items.Add($"Number: {local_client.Account_List[i].Number}");
                    }
                    else
                    {
                        itemDeposit.Items.Add($"Number: {local_client.Account_List[i].Number}");
                    }
                }
            }
            result.Add(itemDeposit);
            result.Add(itemNotDeposit);
            return result;
        }

        public void SortDatabase()
        {
            database.Sort();
        }

        public void AddAccount(int CliendID, bool isDeposit)
        {
            Account<bool, string> account = new Account<bool, string>(isDeposit);
            Random random = new Random();
            account.Number = random.Next().ToString();
            account.Balance = "0";
            database.DataBase[CliendID].Account_List.Add(account);
            AccountChanges?.Invoke(this, Actions.AddAccount, CliendID, account.Number);
        }

        public void DeleteAccount(int CliendID, string Number)
        {
            for (int i = 0; i < database.DataBase[CliendID].Account_List.Count; i++)
            {
                if (database.DataBase[CliendID].Account_List[i].Number == Number)
                {
                    database.DataBase[CliendID].Account_List.Remove(database.DataBase[CliendID].Account_List[i]);
                    AccountChanges?.Invoke(this, Actions.DelAccount, CliendID, Number);
                    break;
                }
            }            
        }

        public string GetAccountInfo(int CliendID, string Number)
        {
            string result = "";
            for (int i = 0; i < database.DataBase[CliendID].Account_List.Count; i++)
            {
                if (database.DataBase[CliendID].Account_List[i].Number == Number)
                {
                    result = $"Number: {database.DataBase[CliendID].Account_List[i].Number}";
                    result += $" Balance: {database.DataBase[CliendID].Account_List[i].Balance}";
                    result += $" Is deposit: {database.DataBase[CliendID].Account_List[i].isDeposit}";
                    break;
                }
            }
            return result;
        }

        public void SendMoney(int ClientID, string Src, string Dst, int ToSend)
        {
            int Balance = 0, src_account_id = 0, dst_account_id = 0;
            for (int i = 0; i < database.DataBase[ClientID].Account_List.Count; i++)
            {
                if (database.DataBase[ClientID].Account_List[i].Number == Src)
                {
                    src_account_id = i;
                    Balance = Convert.ToInt32(database.DataBase[ClientID].Account_List[i].Balance);
                }
                else if (database.DataBase[ClientID].Account_List[i].Number == Dst)
                {
                    dst_account_id = i;
                }
            }

            if (Balance < ToSend)
            {
                MessageBox.Show("Not enough money on src account!");
            }
            else
            {
                int Dest_Balance = Convert.ToInt32(database.DataBase[ClientID].Account_List[dst_account_id].Balance);
                Balance -= ToSend;
                Dest_Balance += ToSend;
                database.DataBase[ClientID].Account_List[src_account_id].Balance = Balance.ToString();
                database.DataBase[ClientID].Account_List[dst_account_id].Balance = Dest_Balance.ToString();
                AccountChanges?.Invoke(this, Actions.Resend, ClientID, Src);
            }
        }
    }
}
    

