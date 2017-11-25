using System.Runtime.Serialization;

namespace NationalCriminal.Search.DataContracts
{
    [DataContract]
    public class CriminalSearchRequest
    {
        [DataMember]
        public CriminalSearchCriteria SearchCriteria { get; set; }

        [DataMember]
        public int? MaxResults { get; set; }

        [DataMember]
        public string EmailId { get; set; }

        [DataMember]
        public string SessionId { get; set; }
    }
}
