using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using iS3.Core;

namespace iS3.Geology
{
    [DataContract]
    public class Borehole : DGObject
    {
        [DataMember]
        public double Top { get; set; }
        [DataMember]
        public double Base { get; set; }
        [DataMember]
        public double Mileage { get; set; }
        [DataMember]
        public string Type { get; set; }

        public List<BoreholeGeology> Geologies { get; set; }

        public Borehole()
        { }
    }
}
