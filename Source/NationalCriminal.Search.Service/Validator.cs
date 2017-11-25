using System;
using System.Activities;
using System.Net.Mail;
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

            ValidateEmailId(searchRequest);           

            ValidateForSearchFields(searchRequest);

            ValidateRange(searchRequest.SearchCriteria.Age,"age");

            ValidateRange(searchRequest.SearchCriteria.Height, "height");

            ValidateRange(searchRequest.SearchCriteria.Weight, "weight");            
        }

        /// <summary>
        /// This method is used to check if user have not choosen any search field
        /// </summary>
        /// <param name="searchRequest">CriminalSearchRequest searchRequest</param>
        private static void ValidateForSearchFields(CriminalSearchRequest searchRequest)
        {
            if (searchRequest.SearchCriteria.CriminalNames == null && searchRequest.SearchCriteria.Age == null
                && string.IsNullOrEmpty(searchRequest.EmailId) && searchRequest.SearchCriteria.Height == null
                && string.IsNullOrEmpty(searchRequest.SearchCriteria.Nationality) &&
                string.IsNullOrEmpty(searchRequest.SessionId))
            {
                throw new ValidationException("Please specify atleast one search criteria.");
            }
        }

        /// <summary>
        /// This method is used to validate the email.
        /// </summary>
        /// <param name="searchRequest">CriminalSearchRequest searchRequest</param>
        private static void ValidateEmailId(CriminalSearchRequest searchRequest)
        {
            bool isvalid= false;

            if (string.IsNullOrEmpty(searchRequest.EmailId))
            {
                throw new ValidationException("Requester email id cannot be null/empty.");
            }

            try
            {
                var addr = new MailAddress(searchRequest.EmailId);
                isvalid = addr.Address == searchRequest.EmailId;
            }
            catch (Exception exception)
            {
                throw new ValidationException("Requester email id is not valid.", exception);
            }
            finally
            {
                if (!isvalid)
                {
                    throw new ValidationException("Requester email id is not valid.");
                }
            }
        }

        /// <summary>
        ///  This method is used to validate the age range, height range and weight range.
       /// </summary>
        /// <param name="range">Range range</param>
        /// <param name="value">string value</param>
        private static void ValidateRange(Range range, string value)
        {
            if (range!= null && (range.End!=0 && range.Start > range.End))
            {
                throw new ValidationException(String.Format("Criminal {0} range is not valid. Please specify valid range",value));
            }
        }
      
    }
}