using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
namespace Bank
{
    public struct OperationInfo
    {
        public string OperationBy;
        public DateTime OperationWhen;
        public string Operation;
        public string NewParameter;
        public int ClientID;
    };
    public class Journal
    {
        public OperationInfo Operation;
        XmlSerializer serializer = new XmlSerializer(typeof(OperationInfo));
        public void SerializeJournal()
        {
            using (Stream file = new FileStream("Journal.xml", FileMode.Append, FileAccess.Write))
            {
                serializer.Serialize(file, Operation);
            }
        }
    }
}
