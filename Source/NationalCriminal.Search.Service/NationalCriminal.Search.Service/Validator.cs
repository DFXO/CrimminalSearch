using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NationalCriminal.Search.DataContracts;

namespace NationalCriminal.Search.Service
{
    public static class Validator
    {
        public static void ValidateCriminalSearchRequest(CriminalSearchRequest searchRequest)
        {
            if (searchRequest==null)
            {
                 throw new ValidationException("Request cannot be null/empty.");   
            }

            if (string.IsNullOrEmpty(searchRequest.EmailId))
            {
                throw new ValidationException("Requester email id cannot be null/empty.");  
            }

            if (searchRequest.SearchCriteria == null)
            {
                throw new ValidationException("Search criteria cannot be null/empty.");  
            }

            if (searchRequest.SearchCriteria.CriminalNames == null || searchRequest.SearchCriteria.CriminalNames.Count<1)
            {

            }
        }
    }
}