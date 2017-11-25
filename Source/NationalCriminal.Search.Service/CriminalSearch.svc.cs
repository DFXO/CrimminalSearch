using System;
using System.Threading;
using NationalCriminal.Search.DataContracts;
using NationalCriminal.Search.Service.BusinessLogic;
using NationalCriminal.Search.ServiceContracts;

namespace NationalCriminal.Search.Service
{    
    public class CriminalSearch : ICriminalSearch
    {        
        public bool Search(CriminalSearchRequest searchRequest)
        {
            try
            {
                Validator.ValidateCriminalSearchRequest(searchRequest);

                //Background thread to send emails.
                Thread backgroundThread = new Thread((SendEmail))
                {
                    IsBackground = true
                };

                backgroundThread.Start(searchRequest);

                //SearchController controller = new SearchController();
                //CriminalSearchRequest request = searchRequest as CriminalSearchRequest;
                //controller.SendMailWithCriminalRecords(request);
            }
            catch (Exception)
            {                
                return false;             
            }
            return true;
        }        

        /// <summary>
        /// This method is is used to send email to user.
        /// </summary>
        /// <param name="searchRequest"></param>
        private static void SendEmail(object searchRequest)
        {
            SearchController controller = new SearchController();
            CriminalSearchRequest request = searchRequest as CriminalSearchRequest;
            controller.SendMailWithCriminalRecords(request);
        }
    }
}
