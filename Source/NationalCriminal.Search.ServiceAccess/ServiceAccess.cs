using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NationalCriminal.Search.Service.ServiceTests.CriminalSearchRefernce;

namespace NationalCriminal.Search.ServiceAccess
{
    public class ServiceAccess
    {       
        public bool CriminalSearch(CriminalSearchRequest request)
        {
            bool isServiceCallSuccess = false;
            try
            {
                Binding binding = new BasicHttpBinding();
                EndpointAddress endpointAddress = GetEndpointAddress();

                using (var serviceClient = new CriminalSearchClient(binding, endpointAddress))
                {
                    using (new OperationContextScope(serviceClient.InnerChannel))
                    {
                        isServiceCallSuccess = serviceClient.Search(request);
                    }
                }                                                     
            }
            catch (Exception exception)
            {
                throw new ServiceActivationException("Error occured while accessing criminal service." + exception);
            }
            return isServiceCallSuccess;
        }

        private EndpointAddress GetEndpointAddress()
        {
            return new
                EndpointAddress(System.Configuration.ConfigurationManager.AppSettings.Get("ServiceBaseUrl"));            
        }
    }
}
