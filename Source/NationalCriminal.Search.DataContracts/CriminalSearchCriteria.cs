using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NationalCriminal.Search.DataContracts
{
    [DataContract]    
    public class CriminalSearchCriteria
    {
        [DataMember]
        public List<string> CriminalNames { get; set; }

        [DataMember]
        public Range Age { get; set; }

        [DataMember]
        public Range Height { get; set; }

        [DataMember]
        public Range Weight { get; set; }

        [DataMember]
        public string Sex { get; set; }

        [DataMember]
        public string Nationality { get; set; }
    }
}
