using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Controls;
namespace WpfApp1
{
    public interface IBankWorker
    {        
        string GetPassport(int ClientID);
        string GetName(int ClientID);
        string GetTelephone(int ClientID);
        bool SetTelephone(int ClientID, string new_telephone);
        bool SetName(int ClientID, string new_name);
        bool SetPassport(int ClientID, string new_passport);
        bool SaveDatabase();
        void AddAccount(int CliendID, bool isDeposit);

        void DeleteAccount(int CliendID, string Number);

        string GetAccountInfo(int CliendID, string Number);
        ObservableCollection<Client> ClientDataBase();
        ObservableCollection<TreeViewItem> Accounts(int ClientID);
        void SortDatabase();

        void SendMoney(int ClientID, string Src, string Dst, int ToSend);
    }
}
