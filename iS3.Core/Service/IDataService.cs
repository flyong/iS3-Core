using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Core
{
    public interface IDataService
    {
        string _constrPrefix { get; }
        string TableNamePrex { get; set; }
        string ServerIP { get; set; }
        string ServerUser { get; set; }
        string ServerPWD { get; set; }
        IDataService GetInstance();
        void initialDataService(string DatabaseName);
        void initialDataService(string IP, string Name, string Password);
        void initialDataService(string IP, string Name, string Password,string DatabaseName);
        DataSet Query(string tableNameSQL, string orderSQL, string conditionSQL);
    }
}
