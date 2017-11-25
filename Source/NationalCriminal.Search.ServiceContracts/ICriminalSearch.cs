using System.ServiceModel;
using NationalCriminal.Search.DataContracts;

namespace NationalCriminal.Search.ServiceContracts
{
    [ServiceContract]
    public interface ICriminalSearch
    {
        [OperationContract]
        bool Search(CriminalSearchRequest searchRequest);
    }
}
