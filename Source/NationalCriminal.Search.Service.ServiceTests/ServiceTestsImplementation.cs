using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NationalCriminal.Search.Service.ServiceTests.CriminalSearchRefernce;

namespace NationalCriminal.Search.Service.ServiceTests
{
    [TestClass]
    public class ServiceTestsImplementation
    {        
        [TestMethod]
        public void Search()
        {
            CriminalSearchRequest request = new CriminalSearchRequest()
            {
                MaxResults = 200,
                SessionId = new Guid().ToString(),
                SearchCriteria = TestData.GetSearchCriteria(),
                EmailId = "abhishek.bande2008@gmail.com",
            };

            Binding binding = new BasicHttpBinding();
            //Create endpointAddress of the Service
            EndpointAddress endpointAddress = GetEndpointAddress();
            //Create Client of the Service
            CriminalSearchClient serviceClient = new CriminalSearchClient(binding, endpointAddress);
            //Call Service method using ServiceClient            

            bool isSuccess = serviceClient.Search(request);
           Assert.IsTrue(isSuccess);
        }


        private EndpointAddress GetEndpointAddress()
        {
            return new
                EndpointAddress(ConfigurationManager.AppSettings["ServiceBaseUrl"]);
        }
        
    }
}
