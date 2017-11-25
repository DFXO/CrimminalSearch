using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using NationalCriminal.Search.DataContracts;
using NationalCriminal.Search.ServiceContracts;

namespace NationalCriminal.Search.Service
{    
    public class CriminalSearch : ICriminalSearch
    {
        public bool Search(CriminalSearchRequest searchRequest)
        {
            try
            {

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
