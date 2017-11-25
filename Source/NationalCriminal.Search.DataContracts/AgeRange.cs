using System.Runtime.Serialization;

namespace NationalCriminal.Search.DataContracts
{
    [DataContract]
    public class Range
    {
        [DataMember]
        public int Start { get; set; }

        [DataMember]
        public int End { get; set; }
    }
}
