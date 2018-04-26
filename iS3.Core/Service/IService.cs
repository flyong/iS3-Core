using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace iS3.Core
{
    public interface IService
    {
        IDataService DataService { get; set; }
    }
}
