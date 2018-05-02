using iS3.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Geology
{
    [DataContract]
    public class BoreholeGeology : DGObject
    {
        [DataMember]
        public double Top { get; set; }
        [DataMember]
        public double Base { get; set; }
        [DataMember]
        public int StratumID { get; set; }
        [DataMember]
        public int RefBoreholeID { get; set; }
        public BoreholeGeology()
        { }
    }
}
