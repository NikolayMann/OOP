using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
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

        ObservableCollection<Client> ClientDataBase();
        void SortDatabase();
    }
}
